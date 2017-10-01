﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPlayer
{
    public class MDChipParams
    {
        public int Cminutes = -1;
        public int Csecond = -1;
        public int Cmillisecond = -1;

        public int TCminutes = -1;
        public int TCsecond = -1;
        public int TCmillisecond = -1;

        public int LCminutes = -1;
        public int LCsecond = -1;
        public int LCmillisecond = -1;

        public ChipLEDs chipLED = new ChipLEDs();



        public class Channel
        {

            public int pan = -1;
            public int pantp = -1;
            public int note = -1;
            public int volume = -1;
            public int volumeL = -1;
            public int volumeR = -1;
            public int freq = -1;
            public int pcmMode = -1;
            public int pcmBuff = 0;
            public bool mask = false;
            public int tp = -1;
            public int kf = -1;//OPM only
            public int tn = 0;//PSG only
            public int tntp = -1;
            public bool dda = false;//HuC6280
            public bool noise = false;//HuC6280
            public int nfrq = -1;//HuC6280

            public int[] inst = new int[48];
            public int[] typ = new int[48];

            public Channel()
            {
                for (int i = 0; i < inst.Length; i++)
                {
                    inst[i] = -1;
                    typ[i] = 0;
                }
            }
        }

        public class YM2203
        {
            public int nfrq = -1;
            public int efrq = -1;
            public int etype = -1;
            public Channel[] channels = new Channel[9] { new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel() };

        }
        public YM2203[] ym2203 = new YM2203[] { new YM2203(), new YM2203() };

        public class YM2612
        {
            public enmFileFormat fileFormat = enmFileFormat.unknown;
            public bool lfoSw = false;
            public int lfoFrq = -1;
            public int[] xpcmVolL = new int[4] { -1, -1, -1, -1 };
            public int[] xpcmVolR = new int[4] { -1, -1, -1, -1 };
            public int[] xpcmInst = new int[4] { -1, -1, -1, -1 };

            public Channel[] channels = new Channel[9] { new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel() };

        }
        public YM2612[] ym2612 = new YM2612[] { new YM2612(), new YM2612() };

        public class SN76489
        {

            public Channel[] channels = new Channel[4] { new Channel(), new Channel(), new Channel(), new Channel() };

        }
        public SN76489[] sn76489 = new SN76489[] { new SN76489(), new SN76489() };

        public class RF5C164
        {
            public Channel[] channels = new Channel[8] { new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel() };
        }
        public RF5C164[] rf5c164 = new RF5C164[] { new RF5C164(), new RF5C164() };

        public class C140
        {
            public Channel[] channels = new Channel[24] { new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel() };
        }
        public C140[] c140 = new C140[] { new C140(), new C140() };

        public class OKIM6258
        {
            public int pan = -1;
            public int pantp = -1;
            public int masterFreq = -1;
            public int divider=-1;
            public int pbFreq = -1;
            public int volumeL = -1;
            public int volumeR = -1;
            public bool keyon = false;
            public bool mask = false;

        }
        public OKIM6258[] okim6258 = new OKIM6258[] { new OKIM6258(), new OKIM6258() };

        public class OKIM6295
        {

        }
        public OKIM6295[] okim6295 = new OKIM6295[] { new OKIM6295(), new OKIM6295() };

        public class SegaPcm
        {
            public Channel[] channels = new Channel[16] { new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel() };
        }
        public SegaPcm[] segaPcm = new SegaPcm[] { new SegaPcm(), new SegaPcm() };

        public class AY8910
        {
            public int nfrq = -1;
            public int efrq = -1;
            public int etype = -1;
            public Channel[] channels = new Channel[3] { new Channel(), new Channel(), new Channel() };
        }
        public AY8910[] ay8910 = new AY8910[] { new AY8910(), new AY8910() };

        public class YM2151
        {
            public int ne = -1;
            public int nfrq = -1;
            public int lfrq = -1;
            public int pmd = -1;
            public int amd = -1;
            public int waveform = -1;
            public int lfosync = -1;
            public Channel[] channels = new Channel[8] { new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel()};

        }
        public YM2151[] ym2151 = new YM2151[] { new YM2151(), new YM2151() };

        public class YM2608
        {
            public bool lfoSw = false;
            public int lfoFrq = -1;
            public int nfrq = -1;
            public int efrq = -1;
            public int etype = -1;

            public Channel[] channels = new Channel[19] {
                new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel() //FM 0
                ,new Channel(), new Channel(), new Channel() //SSG 9
                ,new Channel() //ADPCM 12
                ,new Channel(), new Channel(), new Channel(),new Channel(), new Channel(), new Channel() //RHYTHM 13
            };

        }
        public YM2608[] ym2608 = new YM2608[] { new YM2608(), new YM2608() };

        public class YM2610
        {
            public bool lfoSw = false;
            public int lfoFrq = -1;
            public int nfrq = -1;
            public int efrq = -1;
            public int etype = -1;

            public Channel[] channels = new Channel[19] {
                new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel() //FM 0
                ,new Channel(), new Channel(), new Channel() //SSG 9
                ,new Channel() //ADPCM 12
                ,new Channel(), new Channel(), new Channel(),new Channel(), new Channel(), new Channel() //RHYTHM 13
            };

        }
        public YM2610[] ym2610 = new YM2610[] { new YM2610(), new YM2610() };

        public class HuC6280
        {
            public int mvolL = -1;
            public int mvolR = -1;
            public int LfoCtrl = -1;
            public int LfoFrq = -1;

            public Channel[] channels = new Channel[6] { new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel() };
        }
        public HuC6280[] huc6280 = new HuC6280[] { new HuC6280(), new HuC6280() };

        public class YM2413
        {

            public Channel[] channels = new Channel[14] {
                new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel() //FM 9
                ,new Channel(), new Channel(), new Channel(), new Channel(), new Channel() //Ryhthm 5
            };

        }
        public YM2413[] ym2413 = new YM2413[] { new YM2413(), new YM2413() };

        public class YM2612MIDI
        {
            public bool lfoSw = false;
            public int lfoFrq = -1;
            public bool IsMONO = true;
            public int useFormat = 0;
            public int selectCh = -1;
            public int selectParam = -1;

            public Channel[] channels = new Channel[9] { new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel(), new Channel() };

            public int[][] noteLog = new int[6][] { new int[10], new int[10], new int[10], new int[10], new int[10], new int[10] };
            public bool[] useChannel = new bool[6] { false, false, false, false, false, false };
        }
        public YM2612MIDI ym2612Midi = new YM2612MIDI();

        public MIDIParam[] midi = new MIDIParam[] { new MIDIParam(), new MIDIParam() };

        public class Mixer
        {
            public class VolumeInfo
            {
                public int Volume = -9999;
                public int VisVolume1 = -1;
                public int VisVolume2 = -1;
                public int VisVol2Cnt = 30;
            }
            public VolumeInfo AY8910 = new VolumeInfo();
            public VolumeInfo C140 = new VolumeInfo();
            public VolumeInfo C352 = new VolumeInfo();
            public VolumeInfo HuC6280 = new VolumeInfo();
            public VolumeInfo K054539 = new VolumeInfo();
            public VolumeInfo Master = new VolumeInfo();
            public VolumeInfo OKIM6258 = new VolumeInfo();
            public VolumeInfo OKIM6295 = new VolumeInfo();
            public VolumeInfo PWM = new VolumeInfo();
            public VolumeInfo RF5C164 = new VolumeInfo();
            public VolumeInfo SEGAPCM = new VolumeInfo();
            public VolumeInfo SN76489 = new VolumeInfo();
            public VolumeInfo YM2151 = new VolumeInfo();
            public VolumeInfo YM2203FM = new VolumeInfo();
            public VolumeInfo YM2203PSG = new VolumeInfo();
            public VolumeInfo YM2203 = new VolumeInfo();
            public VolumeInfo YM2413 = new VolumeInfo();
            public VolumeInfo YM2608Adpcm = new VolumeInfo();
            public VolumeInfo YM2608FM = new VolumeInfo();
            public VolumeInfo YM2608PSG = new VolumeInfo();
            public VolumeInfo YM2608Rhythm = new VolumeInfo();
            public VolumeInfo YM2608 = new VolumeInfo();
            public VolumeInfo YM2610AdpcmA = new VolumeInfo();
            public VolumeInfo YM2610AdpcmB = new VolumeInfo();
            public VolumeInfo YM2610FM = new VolumeInfo();
            public VolumeInfo YM2610PSG = new VolumeInfo();
            public VolumeInfo YM2610 = new VolumeInfo();
            public VolumeInfo YM2612 = new VolumeInfo();
            public VolumeInfo APU = new VolumeInfo();
            public VolumeInfo DMC = new VolumeInfo();
            public VolumeInfo FDS = new VolumeInfo();
            public VolumeInfo MMC5 = new VolumeInfo();
            public VolumeInfo N160 = new VolumeInfo();
            public VolumeInfo VRC6 = new VolumeInfo();
            public VolumeInfo VRC7 = new VolumeInfo();
            public VolumeInfo FME7 = new VolumeInfo();
        }
        public Mixer mixer = new Mixer();

    }
}
