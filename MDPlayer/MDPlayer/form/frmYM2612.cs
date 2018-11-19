﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDPlayer.form
{
    public partial class frmYM2612 : Form
    {
        public bool isClosed = false;
        public int x = -1;
        public int y = -1;
        public frmMain parent = null;
        private int frameSizeW = 0;
        private int frameSizeH = 0;
        private int chipID = 0;
        private int zoom = 1;

        private MDChipParams.YM2612 newParam = null;
        private MDChipParams.YM2612 oldParam = new MDChipParams.YM2612();
        private FrameBuffer frameBuffer = new FrameBuffer();

        public frmYM2612(frmMain frm, int chipID, int zoom, MDChipParams.YM2612 newParam)
        {
            parent = frm;
            this.chipID = chipID;
            this.zoom = zoom;
            InitializeComponent();

            this.newParam = newParam;
            frameBuffer.Add(pbScreen, Properties.Resources.planeYM2612, null, zoom);
            screenInit();
            update();
        }

        public void screenInit()
        {
            bool YM2612Type = (chipID == 0) ? parent.setting.YM2612Type.UseScci : parent.setting.YM2612SType.UseScci;
            int tp = YM2612Type ? 1 : 0;
            DrawBuff.screenInitYM2612(frameBuffer, tp, (chipID == 0) ? parent.setting.YM2612Type.OnlyPCMEmulation : parent.setting.YM2612SType.OnlyPCMEmulation, newParam.fileFormat == enmFileFormat.XGM);
            newParam.channels[5].pcmBuff = 100;
        }

        public void update()
        {
            frameBuffer.Refresh(null);
        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        private void frmYM2612_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                parent.setting.location.PosYm2612[chipID] = Location;
            }
            else
            {
                parent.setting.location.PosYm2612[chipID] = RestoreBounds.Location;
            }
            isClosed = true;
        }

        private void frmYM2612_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x, y);

            frameSizeW = this.Width - this.ClientSize.Width;
            frameSizeH = this.Height - this.ClientSize.Height;

            changeZoom();
        }

        public void changeZoom()
        {
            this.MaximumSize = new System.Drawing.Size(frameSizeW + Properties.Resources.planeYM2612.Width * zoom, frameSizeH + Properties.Resources.planeYM2612.Height * zoom);
            this.MinimumSize = new System.Drawing.Size(frameSizeW + Properties.Resources.planeYM2612.Width * zoom, frameSizeH + Properties.Resources.planeYM2612.Height * zoom);
            this.Size = new System.Drawing.Size(frameSizeW + Properties.Resources.planeYM2612.Width * zoom, frameSizeH + Properties.Resources.planeYM2612.Height * zoom);
            frmYM2612_Resize(null, null);

        }

        private void frmYM2612_Resize(object sender, EventArgs e)
        {

        }

        protected override void WndProc(ref Message m)
        {
            if (parent != null)
            {
                parent.windowsMessage(ref m);
            }

            try { base.WndProc(ref m); }
            catch (Exception ex)
            {
                log.ForcedWrite(ex);
            }
        }

        public void screenChangeParams()
        {
            int[][] fmRegister = Audio.GetFMRegister(chipID);
            int[][] fmVol = Audio.GetFMVolume(chipID);
            int[] fmCh3SlotVol = Audio.GetFMCh3SlotVolume(chipID);
            int[] fmKey = Audio.GetFMKeyOn(chipID);

            bool isFmEx = (fmRegister[0][0x27] & 0x40) > 0;

            newParam.lfoSw = (fmRegister[0][0x22] & 0x8) != 0;
            newParam.lfoFrq = (fmRegister[0][0x22] & 0x7);

            for (int ch = 0; ch < 6; ch++)
            {
                int p = (ch > 2) ? 1 : 0;
                int c = (ch > 2) ? ch - 3 : ch;
                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 8 : ((i == 2) ? 4 : 12));
                    newParam.channels[ch].inst[i * 11 + 0] = fmRegister[p][0x50 + ops + c] & 0x1f; //AR
                    newParam.channels[ch].inst[i * 11 + 1] = fmRegister[p][0x60 + ops + c] & 0x1f; //DR
                    newParam.channels[ch].inst[i * 11 + 2] = fmRegister[p][0x70 + ops + c] & 0x1f; //SR
                    newParam.channels[ch].inst[i * 11 + 3] = fmRegister[p][0x80 + ops + c] & 0x0f; //RR
                    newParam.channels[ch].inst[i * 11 + 4] = (fmRegister[p][0x80 + ops + c] & 0xf0) >> 4;//SL
                    newParam.channels[ch].inst[i * 11 + 5] = fmRegister[p][0x40 + ops + c] & 0x7f;//TL
                    newParam.channels[ch].inst[i * 11 + 6] = (fmRegister[p][0x50 + ops + c] & 0xc0) >> 6;//KS
                    newParam.channels[ch].inst[i * 11 + 7] = fmRegister[p][0x30 + ops + c] & 0x0f;//ML
                    newParam.channels[ch].inst[i * 11 + 8] = (fmRegister[p][0x30 + ops + c] & 0x70) >> 4;//DT
                    newParam.channels[ch].inst[i * 11 + 9] = (fmRegister[p][0x60 + ops + c] & 0x80) >> 7;//AM
                    newParam.channels[ch].inst[i * 11 + 10] = fmRegister[p][0x90 + ops + c] & 0x0f;//SG
                }
                newParam.channels[ch].inst[44] = fmRegister[p][0xb0 + c] & 0x07;//AL
                newParam.channels[ch].inst[45] = (fmRegister[p][0xb0 + c] & 0x38) >> 3;//FB
                newParam.channels[ch].inst[46] = (fmRegister[p][0xb4 + c] & 0x38) >> 4;//AMS
                newParam.channels[ch].inst[47] = fmRegister[p][0xb4 + c] & 0x07;//FMS

                newParam.channels[ch].pan = (fmRegister[p][0xb4 + c] & 0xc0) >> 6;

                int freq = 0;
                int octav = 0;
                int n = -1;
                if (ch != 2 || !isFmEx)
                {
                    freq = fmRegister[p][0xa0 + c] + (fmRegister[p][0xa4 + c] & 0x07) * 0x100;
                    octav = (fmRegister[p][0xa4 + c] & 0x38) >> 3;

                    if (fmKey[ch] > 0) n = Math.Min(Math.Max(octav * 12 + common.searchFMNote(freq), 0), 95);
                    newParam.channels[ch].volumeL = Math.Min(Math.Max(fmVol[ch][0] / 80, 0), 19);
                    newParam.channels[ch].volumeR = Math.Min(Math.Max(fmVol[ch][1] / 80, 0), 19);
                }
                else
                {
                    freq = fmRegister[0][0xa9] + (fmRegister[0][0xad] & 0x07) * 0x100;
                    octav = (fmRegister[0][0xad] & 0x38) >> 3;

                    if ((fmKey[2] & 0x10) > 0) n = Math.Min(Math.Max(octav * 12 + common.searchFMNote(freq), 0), 95);
                    newParam.channels[2].volumeL = Math.Min(Math.Max(fmCh3SlotVol[0] / 80, 0), 19);
                    newParam.channels[2].volumeR = Math.Min(Math.Max(fmCh3SlotVol[0] / 80, 0), 19);
                }
                newParam.channels[ch].note = n;


            }

            for (int ch = 6; ch < 9; ch++)
            {
                //Operator 1′s frequency is in A9 and ADH
                //Operator 2′s frequency is in AA and AEH
                //Operator 3′s frequency is in A8 and ACH
                //Operator 4′s frequency is in A2 and A6H

                int[] exReg = new int[3] { 2, 0, -6 };
                int c = exReg[ch - 6];

                newParam.channels[ch].pan = 0;

                if (isFmEx)
                {
                    int freq = fmRegister[0][0xa8 + c] + (fmRegister[0][0xac + c] & 0x07) * 0x100;
                    int octav = (fmRegister[0][0xac + c] & 0x38) >> 3;
                    int n = -1;
                    if ((fmKey[2] & (0x20 << (ch - 6))) > 0) n = Math.Min(Math.Max(octav * 12 + common.searchFMNote(freq), 0), 95);
                    newParam.channels[ch].note = n;
                    newParam.channels[ch].volumeL = Math.Min(Math.Max(fmCh3SlotVol[ch - 5] / 80, 0), 19);
                }
                else
                {
                    newParam.channels[ch].note = -1;
                    newParam.channels[ch].volumeL = 0;
                }
            }

            newParam.channels[5].pcmMode = (fmRegister[0][0x2b] & 0x80) >> 7;
            if (newParam.channels[5].pcmBuff > 0)
                newParam.channels[5].pcmBuff--;

            if (newParam.fileFormat == enmFileFormat.XGM && Audio.driverVirtual is xgm)
            {
                if (Audio.driverVirtual != null && ((xgm)Audio.driverVirtual).xgmpcm != null)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (((xgm)Audio.driverVirtual).xgmpcm[i].isPlaying)
                        {
                            newParam.xpcmInst[i] = (int)(((xgm)Audio.driverVirtual).xgmpcm[i].inst);
                            int d = (((xgm)Audio.driverVirtual).xgmpcm[i].data / 6);
                            d = Math.Min(d, 19);
                            newParam.xpcmVolL[i] = d;
                            newParam.xpcmVolR[i] = d;
                        }
                        else
                        {
                            newParam.xpcmInst[i] = 0;
                            newParam.xpcmVolL[i] = 0;
                            newParam.xpcmVolR[i] = 0;
                        }
                    }
                }
            }
        }

        public void screenDrawParams()
        {
            for (int c = 0; c < 9; c++)
            {

                MDChipParams.Channel oyc = oldParam.channels[c];
                MDChipParams.Channel nyc = newParam.channels[c];

                bool YM2612type = (chipID == 0) ? parent.setting.YM2612Type.UseScci : parent.setting.YM2612SType.UseScci;
                int tp = YM2612type ? 1 : 0;

                if (c < 5)
                {
                    DrawBuff.Volume(frameBuffer, c, 1, ref oyc.volumeL, nyc.volumeL, tp);
                    DrawBuff.Volume(frameBuffer, c, 2, ref oyc.volumeR, nyc.volumeR, tp);
                    DrawBuff.Pan(frameBuffer, c, ref oyc.pan, nyc.pan, ref oyc.pantp, tp);
                    DrawBuff.KeyBoard(frameBuffer, c, ref oyc.note, nyc.note, tp);
                    DrawBuff.Inst(frameBuffer, 1, 12, c, oyc.inst, nyc.inst);
                    DrawBuff.ChYM2612(frameBuffer, c, ref oyc.mask, nyc.mask, tp);
                }
                else if (c == 5)
                {
                    int tp6 = tp;
                    int tp6v = tp;
                    if (tp6 == 1 && parent.setting.YM2612Type.OnlyPCMEmulation)
                    {
                        tp6v = newParam.channels[5].pcmMode == 0 ? 1 : 0;//volumeのみモードの判定を行う
                                                                         //tp6 = 0;
                    }

                    DrawBuff.Pan(frameBuffer, c, ref oyc.pan, nyc.pan, ref oyc.pantp, tp6v);
                    DrawBuff.Inst(frameBuffer, 1, 12, c, oyc.inst, nyc.inst);

                    if (newParam.fileFormat != enmFileFormat.XGM)
                    {
                        DrawBuff.Ch6YM2612(frameBuffer, nyc.pcmBuff, ref oyc.pcmMode, nyc.pcmMode, ref oyc.mask, nyc.mask, ref oyc.tp, tp6v);
                        DrawBuff.Volume(frameBuffer, c, 1, ref oyc.volumeL, nyc.volumeL, tp6v);
                        DrawBuff.Volume(frameBuffer, c, 2, ref oyc.volumeR, nyc.volumeR, tp6v);
                        DrawBuff.KeyBoard(frameBuffer, c, ref oyc.note, nyc.note, tp6v);
                    }
                    else
                    {
                        DrawBuff.Ch6YM2612XGM(frameBuffer,nyc.pcmBuff, ref oyc.pcmMode, nyc.pcmMode, ref oyc.mask, nyc.mask, ref oyc.tp, tp6v);
                        if (newParam.channels[5].pcmMode == 0)
                        {
                            DrawBuff.Volume(frameBuffer, c, 1, ref oyc.volumeL, nyc.volumeL, tp6v);
                            DrawBuff.Volume(frameBuffer, c, 2, ref oyc.volumeR, nyc.volumeR, tp6v);
                            DrawBuff.KeyBoard(frameBuffer, c, ref oyc.note, nyc.note, tp6v);
                        }
                        else
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                DrawBuff.VolumeXY(frameBuffer, 13 + i * 17, 12, 1, ref oldParam.xpcmVolL[i], newParam.xpcmVolL[i], tp6v);
                                DrawBuff.VolumeXY(frameBuffer, 13 + i * 17, 12, 2, ref oldParam.xpcmVolR[i], newParam.xpcmVolR[i], tp6v);
                                if (oldParam.xpcmInst[i] != newParam.xpcmInst[i])
                                {
                                    DrawBuff.drawFont4Int2(frameBuffer, 44 + i * 17 * 4, 48, tp6v, 2, newParam.xpcmInst[i]);
                                    oldParam.xpcmInst[i] = newParam.xpcmInst[i];
                                }
                            }
                        }
                    }
                }
                else
                {
                    DrawBuff.Volume(frameBuffer, c, 0, ref oyc.volumeL, nyc.volumeL, tp);
                    DrawBuff.KeyBoard(frameBuffer, c, ref oyc.note, nyc.note, tp);
                    DrawBuff.ChYM2612(frameBuffer, c, ref oyc.mask, nyc.mask, tp);
                }

            }

            DrawBuff.LfoSw(frameBuffer, 4, 44, ref oldParam.lfoSw, newParam.lfoSw);
            DrawBuff.LfoFrq(frameBuffer, 16, 44, ref oldParam.lfoFrq, newParam.lfoFrq);

        }

        private void pbScreen_MouseClick(object sender, MouseEventArgs e)
        {
            int py = e.Location.Y / zoom;
            int px = e.Location.X / zoom;

            //上部のラベル行の場合は何もしない
            if (py < 1 * 8) return;

            //鍵盤
            if (py < 10 * 8)
            {
                int ch = (py / 8) - 1;
                if (ch < 0) return;

                if (e.Button == MouseButtons.Left)
                {
                    //マスク
                    if (ch < 6) parent.SetChannelMask(enmUseChip.YM2612, chipID, ch);
                    else parent.SetChannelMask(enmUseChip.YM2612, chipID, 2);
                    return;
                }

                //マスク解除
                for (ch = 0; ch < 6; ch++) parent.ResetChannelMask(enmUseChip.YM2612, chipID, ch);
                return;
            }

            //音色で右クリックした場合は何もしない
            if (e.Button == MouseButtons.Right) return;

            // 音色表示欄の判定
            int h = (py - 10 * 8) / (6 * 8);
            int w = Math.Min(px / (13 * 8), 2);
            int instCh = h * 3 + w;

            if (instCh < 6)
            {
                //クリップボードに音色をコピーする
                parent.getInstCh(enmUseChip.YM2612, instCh, chipID);
            }

        }
    }
}
