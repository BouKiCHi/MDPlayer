﻿using sidplayFpNET.libsidplayfp.builders.resid_builder;
using sidplayFpNET.libsidplayfp.sidplayfp;
using System;
using System.Text;
using System.IO;

namespace MDPlayer.Driver.SID
{
    public class sid : baseDriver
    {
        public const int FCC_PSID = 0x44495350;
        public const int FCC_RSID = 0x44495352;
        public int songs;
        public int song;

        private sidplayfp m_engine;
        private bool initial = false;

        public override GD3 getGD3Info(byte[] buf, uint vgmGd3)
        {
            if (buf == null) return null;

            if (
                common.getLE32(buf, 0) != FCC_PSID
                && common.getLE32(buf, 0) != FCC_RSID
                ) return null;

            songs = (int)common.getBE16(buf, 0x0e);

            GD3 gd3 = new GD3();
            gd3.TrackName = Encoding.ASCII.GetString(buf, 0x16, 32).Trim();
            gd3.TrackName = gd3.TrackName.Substring(0, gd3.TrackName.IndexOf((char)0));
            gd3.Composer = Encoding.ASCII.GetString(buf, 0x36, 32).Trim();
            gd3.Composer = gd3.Composer.Substring(0, gd3.Composer.IndexOf((char)0));
            gd3.Notes = Encoding.ASCII.GetString(buf, 0x56, 32).Trim();
            gd3.Notes = gd3.Notes.Substring(0, gd3.Notes.IndexOf((char)0));

            return gd3;
        }

        public override bool init(byte[] vgmBuf, ChipRegister chipRegister, enmModel model, enmUseChip[] useChip, uint latency)
        {
            this.vgmBuf = vgmBuf;
            this.chipRegister = chipRegister;
            this.model = model;
            this.useChip = useChip;
            this.latency = latency;

            if (model == enmModel.RealModel)
            {
                Stopped = true;
                vgmCurLoop = 9999;
                return true;
            }

            Counter = 0;
            TotalCounter = 0;
            LoopCounter = 0;
            vgmCurLoop = 0;
            Stopped = false;
            vgmFrameCounter = 0;
            vgmSpeed = 1;
            vgmSpeedCounter = 0;

            GD3 = getGD3Info(vgmBuf, 0);

            SidInit(vgmBuf);
            initial = true;

            return true;
        }

        public override void oneFrameProc()
        {
            if (model == enmModel.RealModel) return;
            try
            {
                vgmSpeedCounter += vgmSpeed;
                while (vgmSpeedCounter >= 1.0 && !Stopped)
                {
                    vgmSpeedCounter -= 1.0;
                    if (vgmFrameCounter > -1)
                    {
                        Counter++;
                    }
                    else
                    {
                        vgmFrameCounter++;
                    }
                }
                //Stopped = !IsPlaying();
            }
            catch (Exception ex)
            {
                log.ForcedWrite(ex);

            }
        }

        public UInt32 Render(Int16[] b, UInt32 length)
        {
            if (!initial)
            {
                return length;
            }

            m_engine.fastForward(50);
            m_engine.play(b, length);
            for (int i = 0; i < length/2; i++) oneFrameProc();

            return length;
        }

        private void SidInit(byte[] vgmBuf)
        {
            byte[] aryKernal = null;
            byte[] aryBasic = null;
            byte[] aryCharacter = null;
            if (File.Exists(setting.sid.RomKernalPath))
                using (FileStream fs = new FileStream(setting.sid.RomKernalPath, FileMode.Open, FileAccess.Read))
                {
                    aryKernal = new byte[fs.Length];
                    fs.Read(aryKernal, 0, aryKernal.Length);
                }
            if (File.Exists(setting.sid.RomBasicPath))
                using (FileStream fs = new FileStream(setting.sid.RomBasicPath, FileMode.Open, FileAccess.Read))
                {
                    aryBasic = new byte[fs.Length];
                    fs.Read(aryBasic, 0, aryBasic.Length);
                }
            if (File.Exists(setting.sid.RomCharacterPath))
                using (FileStream fs = new FileStream(setting.sid.RomCharacterPath, FileMode.Open, FileAccess.Read))
                {
                    aryCharacter = new byte[fs.Length];
                    fs.Read(aryCharacter, 0, aryCharacter.Length);
                }

            m_engine = new sidplayfp();
            m_engine.debug(false, null);
            m_engine.setRoms(aryKernal, aryBasic, aryCharacter);

            ReSIDBuilder rs = new ReSIDBuilder("ReSID");

            uint maxsids = (m_engine.info()).maxsids();
            rs.create(maxsids);

            SidTune tune = new SidTune(vgmBuf, (uint)vgmBuf.Length);
            tune.selectSong((uint)song);

            if (!m_engine.load(tune))
            {
                System.Console.WriteLine("Error: " + m_engine.error());
                return;
            }

            // Get tune details
            sidplayFpNET.libsidplayfp.sidplayfp.SidTuneInfo tuneInfo = tune.getInfo();
            //if (!m_track.single)
            //    m_track.songs = (UInt16)tuneInfo.songs();
            //if (!createOutput(m_driver.output, tuneInfo))
            //    return false;
            //if (!createSidEmu(m_driver.sid))
            //    return false;

            SidConfig cfg = new SidConfig();
            cfg.frequency = (uint)common.SampleRate;
            cfg.samplingMethod = (setting.sid.Quality & 2) == 0 ? SidConfig.sampling_method_t.INTERPOLATE : SidConfig.sampling_method_t.RESAMPLE_INTERPOLATE;
            cfg.fastSampling = (setting.sid.Quality & 1) == 0;
            cfg.playback = SidConfig.playback_t.STEREO;
            cfg.sidEmulation = rs;
            
            if (!m_engine.config(ref cfg))
            {
                System.Console.WriteLine("Error: " + m_engine.error());
                return;
            }

        }
    }
}
