﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDPlayer.form
{
    public partial class frmYMF278B : Form
    {
        public bool isClosed = false;
        public int x = -1;
        public int y = -1;
        public frmMain parent = null;
        private int frameSizeW = 0;
        private int frameSizeH = 0;
        private int chipID = 0;
        private int zoom = 1;

        private MDChipParams.YMF278B newParam = null;
        private MDChipParams.YMF278B oldParam = new MDChipParams.YMF278B();
        private FrameBuffer frameBuffer = new FrameBuffer();

        public frmYMF278B(frmMain frm, int chipID, int zoom, MDChipParams.YMF278B newParam)
        {
            parent = frm;
            this.chipID = chipID;
            this.zoom = zoom;
            InitializeComponent();

            this.newParam = newParam;
            frameBuffer.Add(pbScreen, Properties.Resources.planeYMF278B, null, zoom);
            bool YMF278BType = (chipID == 0) ? parent.setting.YMF278BType.UseScci : parent.setting.YMF278BType.UseScci;
            int tp = YMF278BType ? 1 : 0;
            DrawBuff.screenInitYMF278B(frameBuffer, tp);
            update();
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

        private void frmYMF278B_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x, y);

            frameSizeW = this.Width - this.ClientSize.Width;
            frameSizeH = this.Height - this.ClientSize.Height;

            changeZoom();
        }

        private void frmYMF278B_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.setting.location.PosYmf278b[chipID] = Location;
            isClosed = true;
        }

        public void changeZoom()
        {
            this.MaximumSize = new System.Drawing.Size(frameSizeW + Properties.Resources.planeYMF278B.Width * zoom, frameSizeH + Properties.Resources.planeYMF278B.Height * zoom);
            this.MinimumSize = new System.Drawing.Size(frameSizeW + Properties.Resources.planeYMF278B.Width * zoom, frameSizeH + Properties.Resources.planeYMF278B.Height * zoom);
            this.Size = new System.Drawing.Size(frameSizeW + Properties.Resources.planeYMF278B.Width * zoom, frameSizeH + Properties.Resources.planeYMF278B.Height * zoom);
            frmYMF278B_Resize(null, null);

        }

        private void frmYMF278B_Resize(object sender, EventArgs e)
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

        private int[] slot1Tbl = new int[] { 0, 6, 1, 7, 2, 8, 12, 13, 14, 18, 24, 19, 25, 20, 26, 30, 31, 32 };
        private int[] slot2Tbl = new int[] { 3, 9, 4, 10, 5, 11, 15, 16, 17, 21, 27, 22, 28, 23, 29, 33, 34, 35 };

        public void screenChangeParams()
        {
            int[][] ymf278bRegister = Audio.GetYMF278BRegister(chipID);
            MDChipParams.Channel nyc;
            int slot = 0;
            int slotP = 0;

            //FM
            for (int c = 0; c < 18; c++)
            {
                nyc = newParam.channels[c];
                for (int i = 0; i < 2; i++)
                {

                    if (i == 0)
                    {
                        slot = slot1Tbl[c] % 18;
                        slotP = slot1Tbl[c] / 18;
                    }
                    else
                    {
                        slot = slot2Tbl[c] % 18;
                        slotP = slot2Tbl[c] / 18;
                    }
                    slot = (slot % 6) + 8 * (slot / 6);

                    //CN
                    nyc.inst[14 + i * 17] = (ymf278bRegister[slotP][0xc0 + slot] & 1);

                    if (i == 0)
                    {
                        //modFlg
                        int n = ymf278bRegister[slotP][0xc0 + slot] & 1;
                        nyc.inst[16] = n == 0 ? 0 : 1;
                        nyc.inst[33] = 1;
                    }

                    //AR
                    nyc.inst[0 + i * 17] = ymf278bRegister[slotP][0x60 + slot] >> 4;
                    //DR
                    nyc.inst[1 + i * 17] = ymf278bRegister[slotP][0x60 + slot] & 0xf;
                    //SL
                    nyc.inst[2 + i * 17] = ymf278bRegister[slotP][0x80 + slot] >> 4;
                    //RR
                    nyc.inst[3 + i * 17] = ymf278bRegister[slotP][0x80 + slot] & 0xf;
                    //KL
                    nyc.inst[4 + i * 17] = ymf278bRegister[slotP][0x40 + slot] >> 6;
                    //TL
                    nyc.inst[5 + i * 17] = ymf278bRegister[slotP][0x40 + slot] & 0x3f;
                    //MT
                    nyc.inst[6 + i * 17] = ymf278bRegister[slotP][0x20 + slot] & 0xf;
                    //AM
                    nyc.inst[7 + i * 17] = ymf278bRegister[slotP][0x20 + slot] >> 7;
                    //VB
                    nyc.inst[8 + i * 17] = (ymf278bRegister[slotP][0x20 + slot] >> 6) & 1;
                    //EG
                    nyc.inst[9 + i * 17] = (ymf278bRegister[slotP][0x20 + slot] >> 5) & 1;
                    //KR
                    nyc.inst[10 + i * 17] = (ymf278bRegister[slotP][0x20 + slot] >> 4) & 1;
                    //BL
                    nyc.inst[11 + i * 17] = (ymf278bRegister[slotP][0xb0 + slot] >> 2) & 7;
                    //FNUM
                    nyc.inst[12 + i * 17] = ymf278bRegister[slotP][0xa0 + slot]
                        + ((ymf278bRegister[slotP][0xb0 + slot] & 3) << 8);
                    //WS
                    nyc.inst[13 + i * 17] = (ymf278bRegister[slotP][0xe0 + slot] & 7);
                    //FB
                    nyc.inst[15 + i * 17] = (ymf278bRegister[slotP][0xc0 + slot] >> 1) & 7;
                }
            }

            newParam.channels[18].dda = ((ymf278bRegister[1][0xbd] >> 7) & 0x01) != 0;
            newParam.channels[19].dda = ((ymf278bRegister[1][0xbd] >> 6) & 0x01) != 0;

            //ConnectSelect
            for (int c = 0; c < 6; c++)
            {
                newParam.channels[c].dda = (ymf278bRegister[1][0x04] & (0x1 << c)) != 0;
                newParam.channels[c].inst[34] = newParam.channels[c].dda ? 1 : 0;
                newParam.channels[c].inst[35] = newParam.channels[c].dda ? 2 : 0;
                if (newParam.channels[c].dda)
                {
                    //OP4 mode
                    int ch = (c < 3) ? c * 2 : ((c - 3) * 2 + 9);
                    //cnt=14
                    int a = newParam.channels[ch].inst[14] * 2 + newParam.channels[ch].inst[14 + 17];
                    //mod=16
                    switch (a)
                    {
                        case 0:
                            newParam.channels[ch].inst[16] = 0;
                            newParam.channels[ch].inst[16 + 17] = 0;
                            newParam.channels[ch + 1].inst[16] = 0;
                            newParam.channels[ch + 1].inst[16 + 17] = 1;
                            break;
                        case 1:
                            newParam.channels[ch].inst[16] = 0;
                            newParam.channels[ch].inst[16 + 17] = 1;
                            newParam.channels[ch + 1].inst[16] = 0;
                            newParam.channels[ch + 1].inst[16 + 17] = 1;
                            break;
                        case 2:
                            newParam.channels[ch].inst[16] = 1;
                            newParam.channels[ch].inst[16 + 17] = 0;
                            newParam.channels[ch + 1].inst[16] = 0;
                            newParam.channels[ch + 1].inst[16 + 17] = 1;
                            break;
                        case 3:
                            newParam.channels[ch].inst[16] = 1;
                            newParam.channels[ch].inst[16 + 17] = 0;
                            newParam.channels[ch + 1].inst[16] = 1;
                            newParam.channels[ch + 1].inst[16 + 17] = 1;
                            break;
                    }
                }
            }

            //PCM
            int pcmKey = Audio.getYMF278BPCMKeyON(chipID);
            for (int c = 20; c < 20 + 24; c++)
            {
                nyc = newParam.channels[c];
                //Pan
                nyc.pan = (ymf278bRegister[2][0x68 + (c - 20)] & 0xf);
                nyc.pan = (nyc.pan == 8 ? 0 :
                    (
                        (nyc.pan < 8 ? (15 - nyc.pan * 2) : 15)
                        + ((nyc.pan > 8 ? (nyc.pan * 2 - 18) : 15) << 4)
                    ));
                //Volume
                if ((pcmKey & (1 << (c - 20))) != 0)
                {
                    nyc.note = (ymf278bRegister[2][0x68 + (c - 20)] & 0x80);
                    nyc.volumeL = (127 - (ymf278bRegister[2][0x50 + (c - 20)] >> 1)) * (nyc.pan & 0xf) / 16 / 6;
                    nyc.volumeR = (127 - (ymf278bRegister[2][0x50 + (c - 20)] >> 1)) * (nyc.pan >> 4) / 16 / 6;
                }
                else
                {
                    nyc.volumeL--;
                    if (nyc.volumeL < 0) nyc.volumeL = 0;
                    nyc.volumeR--;
                    if (nyc.volumeR < 0) nyc.volumeR = 0;
                }
                //AR
                nyc.inst[0] = (ymf278bRegister[2][0x98 + (c - 20)] >> 4);
                //D1
                nyc.inst[1] = (ymf278bRegister[2][0x98 + (c - 20)]) & 0xf;
                //DL
                nyc.inst[2] = (ymf278bRegister[2][0xb0 + (c - 20)] >> 4);
                //D2
                nyc.inst[3] = (ymf278bRegister[2][0xb0 + (c - 20)]) & 0xf;
                //RC
                nyc.inst[4] = (ymf278bRegister[2][0xc8 + (c - 20)] >> 4);
                //RR
                nyc.inst[5] = (ymf278bRegister[2][0xc8 + (c - 20)]) & 0xf;
                //AM
                nyc.inst[6] = (ymf278bRegister[2][0xe0 + (c - 20)]) & 0x7;
                //Vib
                nyc.inst[7] = (ymf278bRegister[2][0x80 + (c - 20)]) & 0x7;
                //Lfo
                nyc.inst[8] = (ymf278bRegister[2][0x80 + (c - 20)] >> 3) & 0x7;
                //Reverb
                nyc.inst[9] = (ymf278bRegister[2][0x38 + (c - 20)] >> 3) & 0x1;
                //LD
                nyc.inst[10] = (ymf278bRegister[2][0x50 + (c - 20)] & 0x1);
                //TL
                nyc.inst[11] = (ymf278bRegister[2][0x50 + (c - 20)] >> 1);
                //Wav
                nyc.inst[12] = (ymf278bRegister[2][0x08 + (c - 20)]) + ((ymf278bRegister[2][0x20 + (c - 20)] & 0x1) << 8);
                //Oct
                nyc.inst[13] = (ymf278bRegister[2][0x38 + (c - 20)] >> 4);
                //F-Num
                nyc.inst[14] = (ymf278bRegister[2][0x20+(c-20)] >> 1) + ((ymf278bRegister[2][0x38+(c-20)] & 0x7) << 8);
            }
            Audio.resetYMF278BPCMKeyON(chipID);
        }

        public void screenDrawParams()
        {
            int tp = parent.setting.YMF278BType.UseScci ? 1 : 0;
            MDChipParams.Channel oyc;
            MDChipParams.Channel nyc;

            //FM
            for (int c = 0; c < 18; c++)
            {

                oyc = oldParam.channels[c];
                nyc = newParam.channels[c];

                for (int i = 0; i < 2; i++)
                {
                    DrawBuff.SUSFlag(frameBuffer, 81 + i * 41, c * 2 + 2, 1, ref oyc.inst[16 + i * 17], nyc.inst[16 + i * 17]);
                    DrawBuff.font4Int2(frameBuffer, 336 + 0 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[0 + i * 17], nyc.inst[0 + i * 17]);//AR
                    DrawBuff.font4Int2(frameBuffer, 336 + 8 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[1 + i * 17], nyc.inst[1 + i * 17]);//DR
                    DrawBuff.font4Int2(frameBuffer, 336 + 16 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[2 + i * 17], nyc.inst[2 + i * 17]);//SL
                    DrawBuff.font4Int2(frameBuffer, 336 + 24 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[3 + i * 17], nyc.inst[3 + i * 17]);//RR
                    DrawBuff.font4Int2(frameBuffer, 336 + 32 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[4 + i * 17], nyc.inst[4 + i * 17]);//KL
                    DrawBuff.font4Int2(frameBuffer, 336 + 40 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[5 + i * 17], nyc.inst[5 + i * 17]);//TL
                    DrawBuff.font4Int2(frameBuffer, 336 + 48 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[6 + i * 17], nyc.inst[6 + i * 17]);//MT
                    DrawBuff.font4Int2(frameBuffer, 336 + 56 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[7 + i * 17], nyc.inst[7 + i * 17]);//AM
                    DrawBuff.font4Int2(frameBuffer, 336 + 64 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[8 + i * 17], nyc.inst[8 + i * 17]);//VB
                    DrawBuff.font4Int2(frameBuffer, 336 + 72 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[9 + i * 17], nyc.inst[9 + i * 17]);//EG
                    DrawBuff.font4Int2(frameBuffer, 336 + 80 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[10 + i * 17], nyc.inst[10 + i * 17]);//KR
                    DrawBuff.font4Int2(frameBuffer, 336 + 88 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[11 + i * 17], nyc.inst[11 + i * 17]);//BL
                    DrawBuff.font4Hex12Bit(frameBuffer, 336 + 104 + i * 164, c * 8 + 8, 0, ref oyc.inst[12 + i * 17], nyc.inst[12 + i * 17]);//F-Num
                    DrawBuff.font4Int2(frameBuffer, 336 + 116 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[13 + i * 17], nyc.inst[13 + i * 17]);//WS
                    DrawBuff.font4Int2(frameBuffer, 336 + 124 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[14 + i * 17], nyc.inst[14 + i * 17]);//CN
                    DrawBuff.font4Int2(frameBuffer, 336 + 132 + i * 164, c * 8 + 8, 0, 0, ref oyc.inst[15 + i * 17], nyc.inst[15 + i * 17]);//FB
                }

                //DrawBuff.Volume(frameBuffer, c, 0, ref oyc.volumeL, nyc.volumeL, tp);
                //DrawBuff.KeyBoard(frameBuffer, c, ref oyc.note, nyc.note, tp);

                //DrawBuff.drawInstNumber(frameBuffer, (c % 3) * 16 + 37, (c / 3) * 2 + 24, ref oyc.inst[0], nyc.inst[0]);
                //DrawBuff.SUSFlag(frameBuffer, (c % 3) * 16 + 41, (c / 3) * 2 + 24, ref oyc.inst[1], nyc.inst[1]);
                //DrawBuff.SUSFlag(frameBuffer, (c % 3) * 16 + 44, (c / 3) * 2 + 24, ref oyc.inst[2], nyc.inst[2]);
                //DrawBuff.drawInstNumber(frameBuffer, (c % 3) * 16 + 46, (c / 3) * 2 + 24, ref oyc.inst[3], nyc.inst[3]);

            }

            for (int c = 0; c < 6; c++)
            {
                //CS
                DrawBuff.drawNESSw(frameBuffer, 79 * 4 + c * 4, 19 * 8, ref oldParam.channels[c].dda, newParam.channels[c].dda);
                int ch = (c < 3) ? c * 2 : ((c - 3) * 2 + 9);
                DrawBuff.Kakko(frameBuffer, 4 * 80, (c < 3 ? 0 : 24)+c * 16 + 8, 0, ref oldParam.channels[c].inst[34], newParam.channels[c].inst[34]);
                DrawBuff.Kakko(frameBuffer, 4*160, (c < 3 ? 0 : 24)+c *16+8, 0, ref oldParam.channels[c].inst[35], newParam.channels[c].inst[35]);
            }
            DrawBuff.drawNESSw(frameBuffer, 88 * 4 , 19 * 8, ref oldParam.channels[18].dda, newParam.channels[18].dda);//DA
            DrawBuff.drawNESSw(frameBuffer, 92 * 4 , 19 * 8, ref oldParam.channels[19].dda, newParam.channels[19].dda);//DV

            for (int c = 18; c < 18 + 5; c++)
            {
            }

            //PCM
            for (int c = 20; c < 20 + 24; c++)
            {
                oyc = oldParam.channels[c];
                nyc = newParam.channels[c];
                DrawBuff.PanType2(frameBuffer, c-1, ref oyc.pan, nyc.pan);
                DrawBuff.font4Int2(frameBuffer, 516 + 0, c * 8, 0, 0, ref oyc.inst[0], nyc.inst[0]);//AR
                DrawBuff.font4Int2(frameBuffer, 516 + 8, c * 8, 0, 0, ref oyc.inst[1], nyc.inst[1]);//D1
                DrawBuff.font4Int2(frameBuffer, 516 + 16, c * 8, 0, 0, ref oyc.inst[2], nyc.inst[2]);//DL
                DrawBuff.font4Int2(frameBuffer, 516 + 24, c * 8, 0, 0, ref oyc.inst[3], nyc.inst[3]);//D2
                DrawBuff.font4Int2(frameBuffer, 516 + 32, c * 8, 0, 0, ref oyc.inst[4], nyc.inst[4]);//RC
                DrawBuff.font4Int2(frameBuffer, 516 + 40, c * 8, 0, 0, ref oyc.inst[5], nyc.inst[5]);//RR
                DrawBuff.font4Int2(frameBuffer, 516 + 48, c * 8, 0, 0, ref oyc.inst[6], nyc.inst[6]);//AM
                DrawBuff.font4Int2(frameBuffer, 516 + 56, c * 8, 0, 0, ref oyc.inst[7], nyc.inst[7]);//VB
                DrawBuff.font4Int2(frameBuffer, 516 + 64, c * 8, 0, 0, ref oyc.inst[8], nyc.inst[8]);//Lfo
                DrawBuff.font4Int2(frameBuffer, 516 + 72, c * 8, 0, 0, ref oyc.inst[9], nyc.inst[9]);//RV
                DrawBuff.font4Int2(frameBuffer, 516 + 80, c * 8, 0, 0, ref oyc.inst[10], nyc.inst[10]);//LD
                DrawBuff.font4Int2(frameBuffer, 516 + 88, c * 8, 0, 3, ref oyc.inst[11], nyc.inst[11]);//TL
                DrawBuff.font4Int2(frameBuffer, 516 +100, c * 8, 0, 3, ref oyc.inst[12], nyc.inst[12]);//WV
                DrawBuff.font4Int2(frameBuffer, 516 +112, c * 8, 0, 0, ref oyc.inst[13], nyc.inst[13]);//Oct
                DrawBuff.font4Hex12Bit(frameBuffer, 516 + 128, c * 8, 0, ref oyc.inst[14], nyc.inst[14]);//F-Num

                DrawBuff.VolumeXY(frameBuffer, 113, c * 2+0, 1, ref oyc.volumeL, nyc.volumeL, tp);
                DrawBuff.VolumeXY(frameBuffer, 113, c * 2+1, 1, ref oyc.volumeR, nyc.volumeR, tp);
            }

        }

        private void pbScreen_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
