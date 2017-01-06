﻿using System;
using System.Collections.Generic;
using System.IO;

namespace MDPlayer
{
    public class ChipRegister
    {

        private Setting setting = null;
        private MDSound.MDSound mds = null;

        private NScci.NSoundChip[] scSN76489 = new NScci.NSoundChip[2] { null, null };
        private Setting.ChipType[] ctSN76489 = new Setting.ChipType[2] { null, null };
        private NScci.NSoundChip[] scYM2612 = new NScci.NSoundChip[2] { null, null };
        private Setting.ChipType[] ctYM2612 = new Setting.ChipType[2] { null, null };
        private NScci.NSoundChip[] scYM2608 = new NScci.NSoundChip[2] { null, null };
        private Setting.ChipType[] ctYM2608 = new Setting.ChipType[2] { null, null };
        private NScci.NSoundChip[] scYM2151 = new NScci.NSoundChip[2] { null, null };
        private Setting.ChipType[] ctYM2151 = new Setting.ChipType[2] { null, null };
        private NScci.NSoundChip[] scYM2203 = new NScci.NSoundChip[2] { null, null };
        private Setting.ChipType[] ctYM2203 = new Setting.ChipType[2] { null, null };
        private NScci.NSoundChip[] scYM2610 = new NScci.NSoundChip[2] { null, null };
        private Setting.ChipType[] ctYM2610 = new Setting.ChipType[2] { null, null };

        private byte[] algM = new byte[] { 0x08, 0x08, 0x08, 0x08, 0x0c, 0x0e, 0x0e, 0x0f };
        private int[] opN = new int[] { 0, 2, 1, 3 };
        private int[] noteTbl = new int[] { 2, 4, 5, -1, 6, 8, 9, -1, 10, 12, 13, -1, 14, 0, 1, -1 };
        private int[] noteTbl2 = new int[] { 13, 14, 0, -1, 1, 2, 4, -1, 5, 6, 8, -1, 9, 10, 12, -1 };

        public int ChipPriOPN = 0;
        public int ChipPriOPN2 = 0;
        public int ChipPriOPNA = 0;
        public int ChipPriOPNB = 0;
        public int ChipPriOPM = 0;
        public int ChipPriDCSG = 0;
        public int ChipPriRF5C = 0;
        public int ChipPriPWM = 0;
        public int ChipPriOKI5 = 0;
        public int ChipPriOKI9 = 0;
        public int ChipPriC140 = 0;
        public int ChipPriSPCM = 0;
        public int ChipSecOPN = 0;
        public int ChipSecOPN2 = 0;
        public int ChipSecOPNA = 0;
        public int ChipSecOPNB = 0;
        public int ChipSecOPM = 0;
        public int ChipSecDCSG = 0;
        public int ChipSecRF5C = 0;
        public int ChipSecPWM = 0;
        public int ChipSecOKI5 = 0;
        public int ChipSecOKI9 = 0;
        public int ChipSecC140 = 0;
        public int ChipSecSPCM = 0;

        public int[][] fmRegisterYM2151 = new int[][] { null, null };
        public int[][] fmKeyOnYM2151 = new int[][] { null, null };
        public int[][][] fmVolYM2151 = new int[][][] {
            new int[8][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
            , new int[8][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
        };
        private int[] nowYM2151FadeoutVol = new int[] { 0, 0 };
        private bool[][] maskFMChYM2151 = new bool[][] {
            new bool[8] { false, false, false, false, false, false, false, false }
            ,new bool[8] { false, false, false, false, false, false, false, false }
        };

        public int[][] fmRegisterYM2203 = new int[][] { null, null };
        public int[][] fmKeyOnYM2203 = new int[][] { null, null };
        public int[][] fmCh3SlotVolYM2203 = new int[][] { new int[4], new int[4] };
        private int[] nowYM2203FadeoutVol = new int[] { 0, 0 };
        public int[][] fmVolYM2203 = new int[][] { new int[9], new int[9] };
        private bool[][] maskFMChYM2203 = new bool[][] {
            new bool[9] { false, false, false, false, false, false, false, false , false }
            ,new bool[9] { false, false, false, false, false, false, false, false , false }
        };

        public int[][][] fmRegisterYM2612 = new int[][][] { new int[][] { null, null }, new int[][] { null, null } };
        public int[][] fmKeyOnYM2612 = new int[][] { null, null };
        public int[][][] fmVolYM2612 = new int[][][] {
            new int[9][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
            ,new int[9][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
        };
        public int[][] fmCh3SlotVolYM2612 = new int[][] { new int[4], new int[4] };
        private int[] nowYM2612FadeoutVol = new int[] { 0, 0 };
        private bool[][] maskFMChYM2612 = new bool[][] { new bool[6] { false, false, false, false, false, false }, new bool[6] { false, false, false, false, false, false } };

        public int[][][] fmRegisterYM2608 = new int[][][] { new int[][] { null, null }, new int[][] { null, null } };
        public int[][] fmKeyOnYM2608 = new int[][] { null, null };
        public int[][][] fmVolYM2608 = new int[][][] {
            new int[9][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
            ,new int[9][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
        };
        public int[][] fmCh3SlotVolYM2608 = new int[][] { new int[4], new int[4] };
        public int[][][] fmVolYM2608Rhythm = new int[][][] {
            new int[6][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
            , new int[6][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
        };
        public int[][] fmVolYM2608Adpcm = new int[][] { new int[2], new int[2] };
        public int[] fmVolYM2608AdpcmPan = new int[] { 0, 0 };
        private int[] nowYM2608FadeoutVol = new int[] { 0, 0 };
        private bool[][] maskFMChYM2608 = new bool[][] {
            new bool[14] { false, false, false, false, false, false, false, false, false, false, false, false, false, false}
            , new bool[14] { false, false, false, false, false, false, false, false, false, false, false, false, false, false}
        };

        public int[][][] fmRegisterYM2610 = new int[][][] { new int[][] { null, null }, new int[][] { null, null } };
        public int[][] fmKeyOnYM2610 = new int[][] { null, null };
        public int[][][] fmVolYM2610 = new int[][][] {
            new int[9][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
            ,new int[9][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
        };
        public int[][] fmCh3SlotVolYM2610 = new int[][] { new int[4], new int[4] };
        public int[][][] fmVolYM2610Rhythm = new int[][][] {
            new int[6][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
            , new int[6][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] }
        };
        public int[][] fmVolYM2610Adpcm = new int[][] { new int[2], new int[2] };
        public int[] fmVolYM2610AdpcmPan = new int[] { 0, 0 };
        private int[] nowYM2610FadeoutVol = new int[] { 0, 0 };
        private bool[][] maskFMChYM2610 = new bool[][] {
            new bool[14] { false, false, false, false, false, false, false, false, false, false, false, false, false, false }
            , new bool[14] { false, false, false, false, false, false, false, false, false, false, false, false, false, false }
        };

        public int[][] sn76489Register = new int[][] { null, null };
        public int[][][] sn76489Vol = new int[][][] {
            new int[4][] { new int[2], new int[2], new int[2], new int[2] }
            ,new int[4][] { new int[2], new int[2], new int[2], new int[2] }
        };
        public int[] nowSN76489FadeoutVol = new int[] { 0, 0 };
        public bool[][] maskChSN76489 = new bool[][] {
            new bool[4] {false,false,false,false }
            ,new bool[4] {false,false,false,false }
        };

        private int[] LatchedRegister = new int[] { 0, 0 };
        private int[] NoiseFreq = new int[] { 0, 0 };

        private int volF = 1;


        public ChipRegister(Setting setting
            , MDSound.MDSound mds
            , NScci.NSoundChip[] scYM2612
            , NScci.NSoundChip[] scSN76489
            , NScci.NSoundChip[] scYM2608
            , NScci.NSoundChip[] scYM2151
            , NScci.NSoundChip[] scYM2203
            , NScci.NSoundChip[] scYM2610
            , Setting.ChipType[] ctYM2612
            , Setting.ChipType[] ctSN76489
            , Setting.ChipType[] ctYM2608
            , Setting.ChipType[] ctYM2151
            , Setting.ChipType[] ctYM2203
            , Setting.ChipType[] ctYM2610
            )
        {
            this.setting = setting;
            this.mds = mds;

            this.scYM2612 = scYM2612;
            this.scYM2608 = scYM2608;
            this.scYM2151 = scYM2151;
            this.scSN76489 = scSN76489;
            this.scYM2203 = scYM2203;
            this.scYM2610 = scYM2610;

            this.ctYM2612 = ctYM2612;
            this.ctYM2608 = ctYM2608;
            this.ctYM2151 = ctYM2151;
            this.ctSN76489 = ctSN76489;
            this.ctYM2203 = ctYM2203;
            this.ctYM2610 = ctYM2610;

            initChipRegister();
        }


        public void initChipRegister()
        {
            for (int chipID = 0; chipID < 2; chipID++)
            {

                fmRegisterYM2612[chipID] = new int[2][] { new int[0x100], new int[0x100] };
                for (int i = 0; i < 0x100; i++)
                {
                    fmRegisterYM2612[chipID][0][i] = 0;
                    fmRegisterYM2612[chipID][1][i] = 0;
                }
                fmRegisterYM2612[chipID][0][0xb4] = 0xc0;
                fmRegisterYM2612[chipID][0][0xb5] = 0xc0;
                fmRegisterYM2612[chipID][0][0xb6] = 0xc0;
                fmRegisterYM2612[chipID][1][0xb4] = 0xc0;
                fmRegisterYM2612[chipID][1][0xb5] = 0xc0;
                fmRegisterYM2612[chipID][1][0xb6] = 0xc0;
                fmKeyOnYM2612[chipID] = new int[6] { 0, 0, 0, 0, 0, 0 };

                fmRegisterYM2608[chipID] = new int[2][] { new int[0x100], new int[0x100] };
                for (int i = 0; i < 0x100; i++)
                {
                    fmRegisterYM2608[chipID][0][i] = 0;
                    fmRegisterYM2608[chipID][1][i] = 0;
                }
                fmRegisterYM2608[chipID][0][0xb4] = 0xc0;
                fmRegisterYM2608[chipID][0][0xb5] = 0xc0;
                fmRegisterYM2608[chipID][0][0xb6] = 0xc0;
                fmRegisterYM2608[chipID][1][0xb4] = 0xc0;
                fmRegisterYM2608[chipID][1][0xb5] = 0xc0;
                fmRegisterYM2608[chipID][1][0xb6] = 0xc0;
                fmKeyOnYM2608[chipID] = new int[6] { 0, 0, 0, 0, 0, 0 };

                fmRegisterYM2610[chipID] = new int[2][] { new int[0x100], new int[0x100] };
                for (int i = 0; i < 0x100; i++)
                {
                    fmRegisterYM2610[chipID][0][i] = 0;
                    fmRegisterYM2610[chipID][1][i] = 0;
                }
                fmRegisterYM2610[chipID][0][0xb4] = 0xc0;
                fmRegisterYM2610[chipID][0][0xb5] = 0xc0;
                fmRegisterYM2610[chipID][0][0xb6] = 0xc0;
                fmRegisterYM2610[chipID][1][0xb4] = 0xc0;
                fmRegisterYM2610[chipID][1][0xb5] = 0xc0;
                fmRegisterYM2610[chipID][1][0xb6] = 0xc0;
                fmKeyOnYM2610[chipID] = new int[6] { 0, 0, 0, 0, 0, 0 };

                fmRegisterYM2151[chipID] = new int[0x100];
                for (int i = 0; i < 0x100; i++)
                {
                    fmRegisterYM2151[chipID][i] = 0;
                }
                fmKeyOnYM2151[chipID] = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

                fmRegisterYM2203[chipID] = new int[0x100];
                for (int i = 0; i < 0x100; i++)
                {
                    fmRegisterYM2203[chipID][i] = 0;
                }
                fmKeyOnYM2203[chipID] = new int[6] { 0, 0, 0, 0, 0, 0 };

                sn76489Register[chipID] = new int[8] { 0, 15, 0, 15, 0, 15, 0, 15 };

            }
        }


        public void setYM2151Register(int chipID, int dPort, int dAddr, int dData, vgm.enmModel model, int hosei)
        {
            if (ctYM2151 == null) return;

            if (chipID == 0) ChipPriOPM = 2;
            else ChipSecOPM = 2;

            if (model == vgm.enmModel.VirtualModel) fmRegisterYM2151[chipID][dAddr] = dData;

            if ((model == vgm.enmModel.RealModel && ctYM2151[chipID].UseScci) || (model == vgm.enmModel.VirtualModel && !ctYM2151[chipID].UseScci))
            {
                if (dAddr == 0x08) //Key-On/Off
                {
                    int ch = dData & 0x7;
                    if (ch >= 0 && ch < 8)
                    {
                        if ((dData & 0x78) > 0)
                        {
                            fmKeyOnYM2151[chipID][ch] = dData & 0x78;
                            //0x2x Pan/FL/CON
                            fmVolYM2151[chipID][ch][0] = (int)(256 * 6 * ((fmRegisterYM2151[chipID][0x20 + ch] & 0x80) > 0 ? 1 : 0) * ((127 - (fmRegisterYM2151[chipID][0x78 + ch] & 0x7f)) / 127.0));
                            fmVolYM2151[chipID][ch][1] = (int)(256 * 6 * ((fmRegisterYM2151[chipID][0x20 + ch] & 0x40) > 0 ? 1 : 0) * ((127 - (fmRegisterYM2151[chipID][0x78 + ch] & 0x7f)) / 127.0));
                        }
                        else
                        {
                            fmKeyOnYM2151[chipID][ch] = 0;
                        }
                    }
                }
            }

            if ((dAddr & 0xf8) == 0x20)
            {
                int al = dData & 0x07;//AL
                int ch = (dAddr & 0x7);

                for (int i = 0; i < 4; i++)
                {
                    int slot = (i == 0) ? 0 : ((i == 1) ? 2 : ((i == 2) ? 1 : 3));
                    if ((algM[al] & (1 << slot)) > 0)
                    {
                        if (maskFMChYM2151[chipID][ch])
                        {
                            if (model == vgm.enmModel.VirtualModel)
                            {
                                if (!ctYM2151[chipID].UseScci && ctYM2151[chipID].UseEmu)
                                {
                                    mds.WriteYM2151((byte)chipID, (byte)(0x60 + i * 8 + ch), (byte)127);
                                }
                            }
                            else
                            {
                                if (scYM2151 != null) scYM2151[chipID].setRegister(0x60 + i * 8 + ch, 127);
                            }
                        }
                    }
                }
            }

            if ((dAddr & 0xf0) == 0x60 || (dAddr & 0xf0) == 0x70)//TL
            {
                int ch = (dAddr & 0x7);
                dData &= 0x7f;

                dData = Math.Min(dData + nowYM2151FadeoutVol[chipID], 127);
                dData = maskFMChYM2151[chipID][ch] ? 127 : dData;
            }

            if (model == vgm.enmModel.VirtualModel)
            {
                if (!ctYM2151[chipID].UseScci && ctYM2151[chipID].UseEmu)
                {
                    mds.WriteYM2151((byte)chipID, (byte)dAddr, (byte)dData);
                }
            }
            else
            {
                if (scYM2151 == null) return;
                if (chipID != 0) return;

                if (dAddr >= 0x28 && dAddr <= 0x2f)
                {
                    if (hosei == 0)
                    {
                        scYM2151[chipID].setRegister(dAddr, dData);
                    }
                    else
                    {
                        int oct = (dData & 0x70) >> 4;
                        int note = dData & 0xf;
                        note = (note < 3) ? note : ((note < 7) ? (note - 1) : ((note < 11) ? (note - 2) : (note - 3)));
                        note += hosei;
                        if (note < 0)
                        {
                            oct += (note / 12) - 1;
                            note = (note % 12) + 12;
                        }
                        else
                        {
                            oct += (note / 12);
                            note %= 12;
                        }

                        note = (note < 3) ? note : ((note < 6) ? (note + 1) : ((note < 9) ? (note + 2) : (note + 3)));
                        if (scYM2151[chipID] != null)
                            scYM2151[chipID].setRegister(dAddr, (oct << 4) | note);
                    }
                }
                else
                {
                    if (scYM2151[chipID] != null)
                        scYM2151[chipID].setRegister(dAddr, dData);
                }
            }

        }

        public void setYM2203Register(int chipID, int dAddr, int dData, vgm.enmModel model)
        {
            if (ctYM2203 == null) return;

            if (chipID == 0) ChipPriOPN = 2;
            else ChipSecOPN = 2;

            if (model == vgm.enmModel.VirtualModel) fmRegisterYM2203[chipID][dAddr] = dData;

            if ((model == vgm.enmModel.RealModel && ctYM2203[chipID].UseScci) || (model == vgm.enmModel.VirtualModel && !ctYM2203[chipID].UseScci))
            {
                if (dAddr == 0x28)
                {
                    int ch = dData & 0x3;
                    if (ch >= 0 && ch < 3)
                    {
                        if (ch != 2 || (fmRegisterYM2203[chipID][0x27] & 0xc0) != 0x40)
                        {
                            fmKeyOnYM2203[chipID][ch] = dData & 0xf0;
                            int c = ch;
                            fmVolYM2203[chipID][ch] = (int)(256 * 6 * ((127 - (fmRegisterYM2203[chipID][0x4c + c] & 0x7f)) / 127.0));
                        }
                        else
                        {
                            fmKeyOnYM2203[chipID][2] = dData & 0xf0;
                            if ((dData & 0x10) > 0) fmCh3SlotVolYM2203[chipID][0] = (int)(256 * 6 * ((127 - (fmRegisterYM2203[chipID][0x40 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x20) > 0) fmCh3SlotVolYM2203[chipID][2] = (int)(256 * 6 * ((127 - (fmRegisterYM2203[chipID][0x44 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x40) > 0) fmCh3SlotVolYM2203[chipID][1] = (int)(256 * 6 * ((127 - (fmRegisterYM2203[chipID][0x48 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x80) > 0) fmCh3SlotVolYM2203[chipID][3] = (int)(256 * 6 * ((127 - (fmRegisterYM2203[chipID][0x4c + 2] & 0x7f)) / 127.0));
                        }
                    }
                }

            }


            if ((dAddr & 0xf0) == 0x40)//TL
            {
                int ch = (dAddr & 0x3);
                dData &= 0x7f;

                if (ch != 3)
                {
                    dData = Math.Min(dData + nowYM2203FadeoutVol[chipID], 127);
                    dData = maskFMChYM2203[chipID][ch] ? 127 : dData;
                }
            }

            if ((dAddr & 0xf0) == 0xb0)//AL
            {
                int ch = (dAddr & 0x3);
                int al = dData & 0x07;//AL

                if (ch != 3 && maskFMChYM2203[chipID][ch])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int slot = (i == 0) ? 0 : ((i == 1) ? 2 : ((i == 2) ? 1 : 3));
                        if ((algM[al] & (1 << slot)) > 0)
                        {
                            setYM2203Register(chipID, 0x40 + ch + slot * 4, fmRegisterYM2203[chipID][0x40 + ch], model);
                        }
                    }
                }
            }

            //ssg level
            if ((dAddr == 0x08 || dAddr == 0x09 || dAddr == 0x0a))
            {
                int d = nowYM2203FadeoutVol[chipID] >> 3;
                dData = Math.Max(dData - d, 0);
                dData = maskFMChYM2203[chipID][dAddr - 0x08 + 3] ? 0 : dData;
            }

            if (model == vgm.enmModel.VirtualModel)
            {
                if (!ctYM2203[chipID].UseScci)
                {
                    mds.WriteYM2203((byte)chipID, (byte)dAddr, (byte)dData);
                }
            }
            else
            {
                if (scYM2203[chipID] == null) return;

                scYM2203[chipID].setRegister(dAddr, dData);
            }
        }

        public void setYM2608Register(int chipID, int dPort, int dAddr, int dData, vgm.enmModel model)
        {
            if (ctYM2608 == null) return;

            if (chipID == 0) ChipPriOPNA = 2;
            else ChipSecOPNA = 2;

            if (model == vgm.enmModel.VirtualModel) fmRegisterYM2608[chipID][dPort][dAddr] = dData;

            if ((model == vgm.enmModel.RealModel && ctYM2608[chipID].UseScci) || (model == vgm.enmModel.VirtualModel && !ctYM2608[chipID].UseScci))
            {
                if (dPort == 0 && dAddr == 0x28)
                {
                    int ch = (dData & 0x3) + ((dData & 0x4) > 0 ? 3 : 0);
                    if (ch >= 0 && ch < 6)// && (dData & 0xf0) > 0)
                    {
                        if (ch != 2 || (fmRegisterYM2608[chipID][0][0x27] & 0xc0) != 0x40)
                        {
                            fmKeyOnYM2608[chipID][ch] = dData & 0xf0;
                            int p = (ch > 2) ? 1 : 0;
                            int c = (ch > 2) ? (ch - 3) : ch;
                            fmVolYM2608[chipID][ch][0] = (int)(256 * 6 * ((fmRegisterYM2608[chipID][p][0xb4 + c] & 0x80) > 0 ? 1 : 0) * ((127 - (fmRegisterYM2608[chipID][p][0x4c + c] & 0x7f)) / 127.0));
                            fmVolYM2608[chipID][ch][1] = (int)(256 * 6 * ((fmRegisterYM2608[chipID][p][0xb4 + c] & 0x40) > 0 ? 1 : 0) * ((127 - (fmRegisterYM2608[chipID][p][0x4c + c] & 0x7f)) / 127.0));
                        }
                        else
                        {
                            fmKeyOnYM2608[chipID][2] = dData & 0xf0;
                            if ((dData & 0x10) > 0) fmCh3SlotVolYM2608[chipID][0] = (int)(256 * 6 * ((127 - (fmRegisterYM2608[chipID][0][0x40 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x20) > 0) fmCh3SlotVolYM2608[chipID][2] = (int)(256 * 6 * ((127 - (fmRegisterYM2608[chipID][0][0x44 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x40) > 0) fmCh3SlotVolYM2608[chipID][1] = (int)(256 * 6 * ((127 - (fmRegisterYM2608[chipID][0][0x48 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x80) > 0) fmCh3SlotVolYM2608[chipID][3] = (int)(256 * 6 * ((127 - (fmRegisterYM2608[chipID][0][0x4c + 2] & 0x7f)) / 127.0));
                        }
                    }
                }

                if (dPort == 1 && dAddr == 0x01)
                {
                    fmVolYM2608AdpcmPan[chipID] = (dData & 0xc0) >> 6;
                    if (fmVolYM2608AdpcmPan[chipID] > 0)
                    {
                        fmVolYM2608Adpcm[chipID][0] = (int)((256 * 6.0 * fmRegisterYM2608[chipID][1][0x0b] / 64.0) * ((fmVolYM2608AdpcmPan[chipID] & 0x02) > 0 ? 1 : 0));
                        fmVolYM2608Adpcm[chipID][1] = (int)((256 * 6.0 * fmRegisterYM2608[chipID][1][0x0b] / 64.0) * ((fmVolYM2608AdpcmPan[chipID] & 0x01) > 0 ? 1 : 0));
                    }
                }

                if (dPort == 0 && dAddr == 0x10)
                {
                    int tl = fmRegisterYM2608[chipID][0][0x11] & 0x3f;
                    for (int i = 0; i < 6; i++)
                    {
                        if ((dData & (0x1 << i)) > 0)
                        {
                            int il = fmRegisterYM2608[chipID][0][0x18 + i] & 0x1f;
                            int pan = (fmRegisterYM2608[chipID][0][0x18 + i] & 0xc0) >> 6;
                            fmVolYM2608Rhythm[chipID][i][0] = (int)(256 * 6 * ((tl * il) >> 4) / 127.0) * ((pan & 2) > 0 ? 1 : 0);
                            fmVolYM2608Rhythm[chipID][i][1] = (int)(256 * 6 * ((tl * il) >> 4) / 127.0) * ((pan & 1) > 0 ? 1 : 0);
                        }
                    }
                }

            }


            if ((dAddr & 0xf0) == 0x40)//TL
            {
                int ch = (dAddr & 0x3);
                int al = fmRegisterYM2608[chipID][dPort][0xb0 + ch] & 0x07;//AL
                int slot = (dAddr & 0xc) >> 2;
                dData &= 0x7f;

                if ((algM[al] & (1 << slot)) > 0)
                {
                    if (ch != 3)
                    {
                        dData = Math.Min(dData + nowYM2608FadeoutVol[chipID], 127);
                        dData = maskFMChYM2608[chipID][dPort * 3 + ch] ? 127 : dData;
                    }
                }
            }

            if ((dAddr & 0xf0) == 0xb0)//AL
            {
                int ch = (dAddr & 0x3);
                int al = dData & 0x07;//AL

                if (ch != 3 && maskFMChYM2608[chipID][ch])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int slot = (i == 0) ? 0 : ((i == 1) ? 2 : ((i == 2) ? 1 : 3));
                        if ((algM[al] & (1 << slot)) > 0)
                        {
                            setYM2608Register(chipID, dPort, 0x40 + ch + slot * 4, fmRegisterYM2608[chipID][dPort][0x40 + ch], model);
                        }
                    }
                }
            }

            //ssg level
            if (dPort == 0 && (dAddr == 0x08 || dAddr == 0x09 || dAddr == 0x0a))
            {
                int d = nowYM2608FadeoutVol[chipID] >> 3;
                dData = Math.Max(dData - d, 0);
                dData = maskFMChYM2608[chipID][dAddr - 0x08 + 6] ? 0 : dData;
            }

            //rhythm level
            if (dPort == 0 && dAddr == 0x11)
            {
                int d = nowYM2608FadeoutVol[chipID] >> 1;
                dData = Math.Max(dData - d, 0);
            }

            //adpcm level
            if (dPort == 1 && dAddr == 0x0b)
            {
                int d = nowYM2608FadeoutVol[chipID] * 2;
                dData = Math.Max(dData - d, 0);
                dData = maskFMChYM2608[chipID][12] ? 0 : dData;
            }

            //adpcm start
            if (dPort == 1 && dAddr == 0x00)
            {
                if ((dData & 0x80) != 0 && maskFMChYM2608[chipID][12])
                {
                    dData &= 0x7f;
                }
            }

            //Ryhthm
            if (dPort == 0 && dAddr == 0x10)
            {
                if (maskFMChYM2608[chipID][13])
                {
                    dData = 0;
                }
            }

            if (model == vgm.enmModel.VirtualModel)
            {
                if (!ctYM2608[chipID].UseScci && ctYM2608[chipID].UseEmu)
                {
                    mds.WriteYM2608((byte)chipID, (byte)dPort, (byte)dAddr, (byte)dData);
                }
            }
            else
            {
                if (scYM2608[chipID] == null) return;

                scYM2608[chipID].setRegister(dPort * 0x100 + dAddr, dData);
            }

        }

        public void setYM2610Register(int chipID, int dPort, int dAddr, int dData, vgm.enmModel model)
        {
            if (ctYM2610 == null) return;

            if (chipID == 0) ChipPriOPNB = 2;
            else ChipSecOPNB = 2;

            if (model == vgm.enmModel.VirtualModel) fmRegisterYM2610[chipID][dPort][dAddr] = dData;

            if ((model == vgm.enmModel.RealModel && ctYM2610[chipID].UseScci) || (model == vgm.enmModel.VirtualModel && !ctYM2610[chipID].UseScci))
            {
                //fmRegisterYM2610[dPort][dAddr] = dData;
                if (dPort == 0 && dAddr == 0x28)
                {
                    int ch = (dData & 0x3) + ((dData & 0x4) > 0 ? 3 : 0);
                    if (ch >= 0 && ch < 6)// && (dData & 0xf0) > 0)
                    {
                        if (ch != 2 || (fmRegisterYM2610[chipID][0][0x27] & 0xc0) != 0x40)
                        {
                            fmKeyOnYM2610[chipID][ch] = dData & 0xf0;
                            int p = (ch > 2) ? 1 : 0;
                            int c = (ch > 2) ? (ch - 3) : ch;
                            fmVolYM2610[chipID][ch][0] = (int)(256 * 6 * ((fmRegisterYM2610[chipID][p][0xb4 + c] & 0x80) > 0 ? 1 : 0) * ((127 - (fmRegisterYM2610[chipID][p][0x4c + c] & 0x7f)) / 127.0));
                            fmVolYM2610[chipID][ch][1] = (int)(256 * 6 * ((fmRegisterYM2610[chipID][p][0xb4 + c] & 0x40) > 0 ? 1 : 0) * ((127 - (fmRegisterYM2610[chipID][p][0x4c + c] & 0x7f)) / 127.0));
                        }
                        else
                        {
                            fmKeyOnYM2610[chipID][2] = dData & 0xf0;
                            if ((dData & 0x10) > 0) fmCh3SlotVolYM2610[chipID][0] = (int)(256 * 6 * ((127 - (fmRegisterYM2610[chipID][0][0x40 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x20) > 0) fmCh3SlotVolYM2610[chipID][2] = (int)(256 * 6 * ((127 - (fmRegisterYM2610[chipID][0][0x44 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x40) > 0) fmCh3SlotVolYM2610[chipID][1] = (int)(256 * 6 * ((127 - (fmRegisterYM2610[chipID][0][0x48 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x80) > 0) fmCh3SlotVolYM2610[chipID][3] = (int)(256 * 6 * ((127 - (fmRegisterYM2610[chipID][0][0x4c + 2] & 0x7f)) / 127.0));
                        }
                    }
                }

                // ADPCM B KEYON
                if (dPort == 0 && dAddr == 0x10)
                {
                    if ((dData & 0x80) != 0)
                    {
                        int p = (fmRegisterYM2610[chipID][0][0x11] & 0xc0) >> 6;
                        p = p == 0 ? 3 : p;
                        if (fmVolYM2610AdpcmPan[chipID] != p)
                            fmVolYM2610AdpcmPan[chipID] = p;

                        //if (fmVolYM2610AdpcmPan > 0)
                        //{
                        fmVolYM2610Adpcm[chipID][0] = (int)((256 * 6.0 * fmRegisterYM2610[chipID][0][0x1b] / 64.0) * ((fmVolYM2610AdpcmPan[chipID] & 0x02) > 0 ? 1 : 0));
                        fmVolYM2610Adpcm[chipID][1] = (int)((256 * 6.0 * fmRegisterYM2610[chipID][0][0x1b] / 64.0) * ((fmVolYM2610AdpcmPan[chipID] & 0x01) > 0 ? 1 : 0));
                        //                        System.Console.WriteLine("{0:X2}:{1:X2}", 0x09, fmRegisterYM2610[1][0x09]);
                        //                        System.Console.WriteLine("{0:X2}:{1:X2}", 0x0A, fmRegisterYM2610[1][0x0A]);
                        //}
                    }
                }

                // ADPCM A KEYON
                if (dPort == 1 && dAddr == 0x00)
                {
                    if ((dData & 0x80) == 0)
                    {
                        int tl = fmRegisterYM2610[chipID][1][0x01] & 0x3f;
                        for (int i = 0; i < 6; i++)
                        {
                            if ((dData & (0x1 << i)) > 0)
                            {
                                int il = fmRegisterYM2610[chipID][1][0x08 + i] & 0x1f;
                                int pan = (fmRegisterYM2610[chipID][1][0x08 + i] & 0xc0) >> 6;
                                fmVolYM2610Rhythm[chipID][i][0] = (int)(256 * 6 * ((tl * il) >> 4) / 127.0) * ((pan & 2) > 0 ? 1 : 0);
                                fmVolYM2610Rhythm[chipID][i][1] = (int)(256 * 6 * ((tl * il) >> 4) / 127.0) * ((pan & 1) > 0 ? 1 : 0);
                            }
                        }
                    }
                }

            }


            if ((dAddr & 0xf0) == 0x40)//TL
            {
                int ch = (dAddr & 0x3);
                int al = fmRegisterYM2610[chipID][dPort][0xb0 + ch] & 0x07;//AL
                int slot = (dAddr & 0xc) >> 2;
                dData &= 0x7f;

                //if ((algM[al] & (1 << slot)) > 0)
                //{
                if (ch != 3)
                {
                    dData = Math.Min(dData + nowYM2610FadeoutVol[chipID], 127);
                    dData = maskFMChYM2610[chipID][dPort * 3 + ch] ? 127 : dData;
                }
                //}
            }

            if ((dAddr & 0xf0) == 0xb0)//AL
            {
                int ch = (dAddr & 0x3);
                int al = dData & 0x07;//AL

                if (ch != 3 && maskFMChYM2610[chipID][ch])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int slot = (i == 0) ? 0 : ((i == 1) ? 2 : ((i == 2) ? 1 : 3));
                        if ((algM[al] & (1 << slot)) > 0)
                        {
                            setYM2610Register(chipID, dPort, 0x40 + ch + slot * 4, fmRegisterYM2610[chipID][dPort][0x40 + ch], model);
                        }
                    }
                }
            }

            //ssg level
            if (dPort == 0 && (dAddr == 0x08 || dAddr == 0x09 || dAddr == 0x0a))
            {
                int d = nowYM2610FadeoutVol[chipID] >> 3;
                dData = Math.Max(dData - d, 0);
                dData = maskFMChYM2610[chipID][dAddr - 0x08 + 6] ? 0 : dData;
            }

            //rhythm level
            if (dPort == 1 && dAddr == 0x01)
            {
                int d = nowYM2610FadeoutVol[chipID] >> 1;
                dData = Math.Max(dData - d, 0);
                dData = maskFMChYM2610[chipID][12] ? 0 : dData;
            }

            //Rhythm
            if (dPort == 1 && dAddr == 0x00)
            {
                if (maskFMChYM2610[chipID][12])
                {
                    dData = 0;
                }
            }

            //adpcm level
            if (dPort == 0 && dAddr == 0x1b)
            {
                int d = nowYM2610FadeoutVol[chipID] * 2;
                dData = Math.Max(dData - d, 0);
                dData = maskFMChYM2610[chipID][13] ? 0 : dData;
            }

            //adpcm start
            if (dPort == 0 && dAddr == 0x10)
            {
                if ((dData & 0x80) != 0 && maskFMChYM2610[chipID][13])
                {
                    dData &= 0x7f;
                }
            }

            if (model == vgm.enmModel.VirtualModel)
            {
                if (!ctYM2610[chipID].UseScci)
                {
                    mds.WriteYM2610((byte)chipID, (byte)dPort, (byte)dAddr, (byte)dData);
                }
            }
            else
            {
                if (scYM2610[chipID] == null) return;
                scYM2610[chipID].setRegister(dPort * 0x100 + dAddr, dData);
            }

        }

        public void setYM2612Register(int chipID, int dPort, int dAddr, int dData, vgm.enmModel model, long vgmFrameCounter)
        {
            if (ctYM2612 == null) return;

            if (chipID == 0) ChipPriOPN2 = 2;
            else ChipSecOPN2 = 2;

            if (model == vgm.enmModel.VirtualModel)
            {
                fmRegisterYM2612[chipID][dPort][dAddr] = dData;
                outMIDIData(enmChip.YM2612, chipID, dPort, dAddr, dData, vgmFrameCounter);
            }

            if ((model == vgm.enmModel.RealModel && ctYM2612[chipID].UseScci) || (model == vgm.enmModel.VirtualModel && !ctYM2612[chipID].UseScci))
            {
                //fmRegister[dPort][dAddr] = dData;
                if (dPort == 0 && dAddr == 0x28)
                {
                    int ch = (dData & 0x3) + ((dData & 0x4) > 0 ? 3 : 0);
                    if (ch >= 0 && ch < 6)// && (dData & 0xf0)>0)
                    {
                        if (ch != 2 || (fmRegisterYM2612[chipID][0][0x27] & 0xc0) != 0x40)
                        {
                            if (ch != 5 || (fmRegisterYM2612[chipID][0][0x2b] & 0x80) == 0)
                            {
                                fmKeyOnYM2612[chipID][ch] = dData & 0xf0;
                                int p = (ch > 2) ? 1 : 0;
                                int c = (ch > 2) ? (ch - 3) : ch;
                                fmVolYM2612[chipID][ch][0] = (int)(256 * 6 * ((fmRegisterYM2612[chipID][p][0xb4 + c] & 0x80) > 0 ? 1 : 0) * ((127 - (fmRegisterYM2612[chipID][p][0x4c + c] & 0x7f)) / 127.0));
                                fmVolYM2612[chipID][ch][1] = (int)(256 * 6 * ((fmRegisterYM2612[chipID][p][0xb4 + c] & 0x40) > 0 ? 1 : 0) * ((127 - (fmRegisterYM2612[chipID][p][0x4c + c] & 0x7f)) / 127.0));
                            }
                        }
                        else
                        {
                            fmKeyOnYM2612[chipID][2] = dData & 0xf0;
                            if ((dData & 0x10) > 0) fmCh3SlotVolYM2612[chipID][0] = (int)(256 * 6 * ((127 - (fmRegisterYM2612[chipID][0][0x40 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x20) > 0) fmCh3SlotVolYM2612[chipID][2] = (int)(256 * 6 * ((127 - (fmRegisterYM2612[chipID][0][0x44 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x40) > 0) fmCh3SlotVolYM2612[chipID][1] = (int)(256 * 6 * ((127 - (fmRegisterYM2612[chipID][0][0x48 + 2] & 0x7f)) / 127.0));
                            if ((dData & 0x80) > 0) fmCh3SlotVolYM2612[chipID][3] = (int)(256 * 6 * ((127 - (fmRegisterYM2612[chipID][0][0x4c + 2] & 0x7f)) / 127.0));
                        }
                    }
                }

                if ((fmRegisterYM2612[chipID][0][0x2b] & 0x80) > 0)
                {
                    if (fmRegisterYM2612[chipID][0][0x2a] > 0)
                    {
                        fmVolYM2612[chipID][5][0] = fmRegisterYM2612[chipID][0][0x2a] * 10 * ((fmRegisterYM2612[chipID][1][0xb4 + 2] & 0x80) > 0 ? 1 : 0);
                        fmVolYM2612[chipID][5][1] = fmRegisterYM2612[chipID][0][0x2a] * 10 * ((fmRegisterYM2612[chipID][1][0xb4 + 2] & 0x40) > 0 ? 1 : 0);
                    }
                }
            }

            if ((dAddr & 0xf0) == 0x40)//TL
            {
                int ch = (dAddr & 0x3);
                dData &= 0x7f;

                if (ch != 3)
                {
                    dData = Math.Min(dData + nowYM2612FadeoutVol[chipID], 127);
                    dData = maskFMChYM2612[chipID][dPort * 3 + ch] ? 127 : dData;
                }
            }

            if ((dAddr & 0xf0) == 0xb0)//AL
            {
                int ch = (dAddr & 0x3);
                int al = dData & 0x07;//AL

                if (ch != 3 && maskFMChYM2612[chipID][ch])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int slot = (i == 0) ? 0 : ((i == 1) ? 2 : ((i == 2) ? 1 : 3));
                        if ((algM[al] & (1 << slot)) > 0)
                        {
                            setYM2612Register(chipID, dPort, 0x40 + ch + slot * 4, fmRegisterYM2612[chipID][dPort][0x40 + ch], model, vgmFrameCounter);
                        }
                    }
                }
            }

            if (dAddr == 0x2a)
            {
                if (maskFMChYM2612[chipID][5]) dData = 0x00;
            }

            if (model == vgm.enmModel.VirtualModel)
            {
                if (ctYM2612[chipID].UseScci)
                {
                    if (ctYM2612[chipID].OnlyPCMEmulation)
                    {
                        if (dPort == 0 && dAddr == 0x2b)
                        {
                            //if (ctYM2612.UseEmu)
                            mds.WriteYM2612((byte)chipID, (byte)dPort, (byte)dAddr, (byte)dData);
                        }
                        else if (dPort == 0 && dAddr == 0x2a)
                        {
                            //if (ctYM2612.UseEmu)
                            mds.WriteYM2612((byte)chipID, (byte)dPort, (byte)dAddr, (byte)dData);
                        }
                        else if (dPort == 1 && dAddr == 0xb6)
                        {
                            //if (ctYM2612.UseEmu)
                            mds.WriteYM2612((byte)chipID, (byte)dPort, (byte)dAddr, (byte)dData);
                        }
                    }
                }
                else
                {
                    if (ctYM2612[chipID].UseEmu)
                        mds.WriteYM2612((byte)chipID, (byte)dPort, (byte)dAddr, (byte)dData);
                }
            }
            else
            {
                if (scYM2612[chipID] == null) return;

                if (ctYM2612[chipID].OnlyPCMEmulation)
                {
                    if (dPort == 0 && dAddr == 0x2b)
                    {
                        scYM2612[chipID].setRegister(dPort * 0x100 + dAddr, dData);
                    }
                    else if (dPort == 0 && dAddr == 0x2a)
                    {
                    }
                    else
                    {
                        scYM2612[chipID].setRegister(dPort * 0x100 + dAddr, dData);
                    }
                }
                else
                {
                    scYM2612[chipID].setRegister(dPort * 0x100 + dAddr, dData);
                }
            }

        }

        internal void setMaskSN76489(int chipID, int ch, bool mask)
        {
            maskChSN76489[chipID][ch] = mask;
        }

        public void setMaskYM2151(int chipID, int ch, bool mask)
        {
            maskFMChYM2151[chipID][ch] = mask;

            setYM2151Register((byte)chipID, 0, 0x60 + ch, fmRegisterYM2151[chipID][0x60 + ch], vgm.enmModel.VirtualModel, 0);
            setYM2151Register((byte)chipID, 0, 0x68 + ch, fmRegisterYM2151[chipID][0x68 + ch], vgm.enmModel.VirtualModel, 0);
            setYM2151Register((byte)chipID, 0, 0x70 + ch, fmRegisterYM2151[chipID][0x70 + ch], vgm.enmModel.VirtualModel, 0);
            setYM2151Register((byte)chipID, 0, 0x78 + ch, fmRegisterYM2151[chipID][0x78 + ch], vgm.enmModel.VirtualModel, 0);

            setYM2151Register((byte)chipID, 0, 0x60 + ch, fmRegisterYM2151[chipID][0x60 + ch], vgm.enmModel.RealModel, 0);
            setYM2151Register((byte)chipID, 0, 0x68 + ch, fmRegisterYM2151[chipID][0x68 + ch], vgm.enmModel.RealModel, 0);
            setYM2151Register((byte)chipID, 0, 0x70 + ch, fmRegisterYM2151[chipID][0x70 + ch], vgm.enmModel.RealModel, 0);
            setYM2151Register((byte)chipID, 0, 0x78 + ch, fmRegisterYM2151[chipID][0x78 + ch], vgm.enmModel.RealModel, 0);
        }

        public void setMaskYM2203(int chipID, int ch, bool mask)
        {
            maskFMChYM2203[chipID][ch] = mask;

            int c = ch;
            if (ch < 3)
            {
                setYM2203Register((byte)chipID, 0x40 + c, fmRegisterYM2203[chipID][0x40 + c], vgm.enmModel.VirtualModel);
                setYM2203Register((byte)chipID, 0x44 + c, fmRegisterYM2203[chipID][0x44 + c], vgm.enmModel.VirtualModel);
                setYM2203Register((byte)chipID, 0x48 + c, fmRegisterYM2203[chipID][0x48 + c], vgm.enmModel.VirtualModel);
                setYM2203Register((byte)chipID, 0x4c + c, fmRegisterYM2203[chipID][0x4c + c], vgm.enmModel.VirtualModel);

                setYM2203Register((byte)chipID, 0x40 + c, fmRegisterYM2203[chipID][0x40 + c], vgm.enmModel.RealModel);
                setYM2203Register((byte)chipID, 0x44 + c, fmRegisterYM2203[chipID][0x44 + c], vgm.enmModel.RealModel);
                setYM2203Register((byte)chipID, 0x48 + c, fmRegisterYM2203[chipID][0x48 + c], vgm.enmModel.RealModel);
                setYM2203Register((byte)chipID, 0x4c + c, fmRegisterYM2203[chipID][0x4c + c], vgm.enmModel.RealModel);
            }
            else
            {
                setYM2203Register((byte)chipID, 0x08 + c - 3, fmRegisterYM2203[chipID][0x08 + c - 3], vgm.enmModel.VirtualModel);
                setYM2203Register((byte)chipID, 0x08 + c - 3, fmRegisterYM2203[chipID][0x08 + c - 3], vgm.enmModel.RealModel);
            }
        }

        public void setMaskYM2608(int chipID, int ch, bool mask)
        {
            maskFMChYM2608[chipID][ch] = mask;
            if (ch >= 9 && ch < 12)
            {
                maskFMChYM2608[chipID][2] = mask;
                maskFMChYM2608[chipID][9] = mask;
                maskFMChYM2608[chipID][10] = mask;
                maskFMChYM2608[chipID][11] = mask;
            }

            int c = (ch < 3) ? ch : (ch - 3);
            int p = (ch < 3) ? 0 : 1;

            if (ch < 6)
            {
                setYM2608Register((byte)chipID, p, 0x40 + c, fmRegisterYM2608[chipID][p][0x40 + c], vgm.enmModel.VirtualModel);
                setYM2608Register((byte)chipID, p, 0x44 + c, fmRegisterYM2608[chipID][p][0x44 + c], vgm.enmModel.VirtualModel);
                setYM2608Register((byte)chipID, p, 0x48 + c, fmRegisterYM2608[chipID][p][0x48 + c], vgm.enmModel.VirtualModel);
                setYM2608Register((byte)chipID, p, 0x4c + c, fmRegisterYM2608[chipID][p][0x4c + c], vgm.enmModel.VirtualModel);

                setYM2608Register((byte)chipID, p, 0x40 + c, fmRegisterYM2608[chipID][p][0x40 + c], vgm.enmModel.RealModel);
                setYM2608Register((byte)chipID, p, 0x44 + c, fmRegisterYM2608[chipID][p][0x44 + c], vgm.enmModel.RealModel);
                setYM2608Register((byte)chipID, p, 0x48 + c, fmRegisterYM2608[chipID][p][0x48 + c], vgm.enmModel.RealModel);
                setYM2608Register((byte)chipID, p, 0x4c + c, fmRegisterYM2608[chipID][p][0x4c + c], vgm.enmModel.RealModel);
            }
            else if (ch < 9)
            {
                setYM2608Register((byte)chipID, 0, 0x08 + ch - 6, fmRegisterYM2608[chipID][0][0x08 + ch - 6], vgm.enmModel.VirtualModel);
                setYM2608Register((byte)chipID, 0, 0x08 + ch - 6, fmRegisterYM2608[chipID][0][0x08 + ch - 6], vgm.enmModel.RealModel);
            }
            else if (ch < 12)
            {
                setYM2608Register((byte)chipID, 0, 0x40 + 2, fmRegisterYM2608[chipID][0][0x40 + 2], vgm.enmModel.VirtualModel);
                setYM2608Register((byte)chipID, 0, 0x44 + 2, fmRegisterYM2608[chipID][0][0x44 + 2], vgm.enmModel.VirtualModel);
                setYM2608Register((byte)chipID, 0, 0x48 + 2, fmRegisterYM2608[chipID][0][0x48 + 2], vgm.enmModel.VirtualModel);
                setYM2608Register((byte)chipID, 0, 0x4c + 2, fmRegisterYM2608[chipID][0][0x4c + 2], vgm.enmModel.VirtualModel);

                setYM2608Register((byte)chipID, 0, 0x40 + 2, fmRegisterYM2608[chipID][0][0x40 + 2], vgm.enmModel.RealModel);
                setYM2608Register((byte)chipID, 0, 0x44 + 2, fmRegisterYM2608[chipID][0][0x44 + 2], vgm.enmModel.RealModel);
                setYM2608Register((byte)chipID, 0, 0x48 + 2, fmRegisterYM2608[chipID][0][0x48 + 2], vgm.enmModel.RealModel);
                setYM2608Register((byte)chipID, 0, 0x4c + 2, fmRegisterYM2608[chipID][0][0x4c + 2], vgm.enmModel.RealModel);
            }
        }

        public void setMaskYM2610(int chipID, int ch, bool mask)
        {
            maskFMChYM2610[chipID][ch] = mask;
            if (ch >= 9 && ch < 12)
            {
                maskFMChYM2610[chipID][2] = mask;
                maskFMChYM2610[chipID][9] = mask;
                maskFMChYM2610[chipID][10] = mask;
                maskFMChYM2610[chipID][11] = mask;
            }

            int c = (ch < 3) ? ch : (ch - 3);
            int p = (ch < 3) ? 0 : 1;

            if (ch < 6)
            {
                setYM2610Register((byte)chipID, p, 0x40 + c, fmRegisterYM2610[chipID][p][0x40 + c], vgm.enmModel.VirtualModel);
                setYM2610Register((byte)chipID, p, 0x44 + c, fmRegisterYM2610[chipID][p][0x44 + c], vgm.enmModel.VirtualModel);
                setYM2610Register((byte)chipID, p, 0x48 + c, fmRegisterYM2610[chipID][p][0x48 + c], vgm.enmModel.VirtualModel);
                setYM2610Register((byte)chipID, p, 0x4c + c, fmRegisterYM2610[chipID][p][0x4c + c], vgm.enmModel.VirtualModel);

                setYM2610Register((byte)chipID, p, 0x40 + c, fmRegisterYM2610[chipID][p][0x40 + c], vgm.enmModel.RealModel);
                setYM2610Register((byte)chipID, p, 0x44 + c, fmRegisterYM2610[chipID][p][0x44 + c], vgm.enmModel.RealModel);
                setYM2610Register((byte)chipID, p, 0x48 + c, fmRegisterYM2610[chipID][p][0x48 + c], vgm.enmModel.RealModel);
                setYM2610Register((byte)chipID, p, 0x4c + c, fmRegisterYM2610[chipID][p][0x4c + c], vgm.enmModel.RealModel);
            }
            else if (ch < 9)
            {
                setYM2610Register((byte)chipID, 0, 0x08 + ch - 6, fmRegisterYM2610[chipID][0][0x08 + ch - 6], vgm.enmModel.VirtualModel);
                setYM2610Register((byte)chipID, 0, 0x08 + ch - 6, fmRegisterYM2610[chipID][0][0x08 + ch - 6], vgm.enmModel.RealModel);
            }
            else if (ch < 12)
            {
                setYM2610Register((byte)chipID, 0, 0x40 + 2, fmRegisterYM2610[chipID][0][0x40 + 2], vgm.enmModel.VirtualModel);
                setYM2610Register((byte)chipID, 0, 0x44 + 2, fmRegisterYM2610[chipID][0][0x44 + 2], vgm.enmModel.VirtualModel);
                setYM2610Register((byte)chipID, 0, 0x48 + 2, fmRegisterYM2610[chipID][0][0x48 + 2], vgm.enmModel.VirtualModel);
                setYM2610Register((byte)chipID, 0, 0x4c + 2, fmRegisterYM2610[chipID][0][0x4c + 2], vgm.enmModel.VirtualModel);

                setYM2610Register((byte)chipID, 0, 0x40 + 2, fmRegisterYM2610[chipID][0][0x40 + 2], vgm.enmModel.RealModel);
                setYM2610Register((byte)chipID, 0, 0x44 + 2, fmRegisterYM2610[chipID][0][0x44 + 2], vgm.enmModel.RealModel);
                setYM2610Register((byte)chipID, 0, 0x48 + 2, fmRegisterYM2610[chipID][0][0x48 + 2], vgm.enmModel.RealModel);
                setYM2610Register((byte)chipID, 0, 0x4c + 2, fmRegisterYM2610[chipID][0][0x4c + 2], vgm.enmModel.RealModel);
            }
        }

        public void setMaskYM2612(int chipID, int ch, bool mask)
        {
            maskFMChYM2612[chipID][ch] = mask;

            int c = (ch < 3) ? ch : (ch - 3);
            int p = (ch < 3) ? 0 : 1;

            setYM2612Register((byte)chipID, p, 0x40 + c, fmRegisterYM2612[chipID][p][0x40 + c], vgm.enmModel.VirtualModel, -1);
            setYM2612Register((byte)chipID, p, 0x44 + c, fmRegisterYM2612[chipID][p][0x44 + c], vgm.enmModel.VirtualModel, -1);
            setYM2612Register((byte)chipID, p, 0x48 + c, fmRegisterYM2612[chipID][p][0x48 + c], vgm.enmModel.VirtualModel, -1);
            setYM2612Register((byte)chipID, p, 0x4c + c, fmRegisterYM2612[chipID][p][0x4c + c], vgm.enmModel.VirtualModel, -1);

            setYM2612Register((byte)chipID, p, 0x40 + c, fmRegisterYM2612[chipID][p][0x40 + c], vgm.enmModel.RealModel, -1);
            setYM2612Register((byte)chipID, p, 0x44 + c, fmRegisterYM2612[chipID][p][0x44 + c], vgm.enmModel.RealModel, -1);
            setYM2612Register((byte)chipID, p, 0x48 + c, fmRegisterYM2612[chipID][p][0x48 + c], vgm.enmModel.RealModel, -1);
            setYM2612Register((byte)chipID, p, 0x4c + c, fmRegisterYM2612[chipID][p][0x4c + c], vgm.enmModel.RealModel, -1);
        }


        public void setFadeoutVolYM2151(int chipID, int v)
        {
            nowYM2151FadeoutVol[chipID] = v;
            for (int c = 0; c < 8; c++)
            {
                setYM2151Register((byte)chipID, 0, 0x60 + c, fmRegisterYM2151[chipID][0x60 + c], vgm.enmModel.RealModel, 0);
                setYM2151Register((byte)chipID, 0, 0x68 + c, fmRegisterYM2151[chipID][0x68 + c], vgm.enmModel.RealModel, 0);
                setYM2151Register((byte)chipID, 0, 0x70 + c, fmRegisterYM2151[chipID][0x70 + c], vgm.enmModel.RealModel, 0);
                setYM2151Register((byte)chipID, 0, 0x78 + c, fmRegisterYM2151[chipID][0x78 + c], vgm.enmModel.RealModel, 0);
            }
        }

        public void setFadeoutVolYM2203(int chipID, int v)
        {
            nowYM2203FadeoutVol[chipID] = v;
            for (int c = 0; c < 3; c++)
            {
                setYM2203Register((byte)chipID, 0x40 + c, fmRegisterYM2203[chipID][0x40 + c], vgm.enmModel.RealModel);
                setYM2203Register((byte)chipID, 0x44 + c, fmRegisterYM2203[chipID][0x44 + c], vgm.enmModel.RealModel);
                setYM2203Register((byte)chipID, 0x48 + c, fmRegisterYM2203[chipID][0x48 + c], vgm.enmModel.RealModel);
                setYM2203Register((byte)chipID, 0x4c + c, fmRegisterYM2203[chipID][0x4c + c], vgm.enmModel.RealModel);
            }
        }

        public void setFadeoutVolYM2608(int chipID, int v)
        {

            nowYM2608FadeoutVol[chipID] = v;

            for (int p = 0; p < 2; p++)
            {
                for (int c = 0; c < 3; c++)
                {
                    setYM2608Register((byte)chipID, p, 0x40 + c, fmRegisterYM2608[chipID][p][0x40 + c], vgm.enmModel.RealModel);
                    setYM2608Register((byte)chipID, p, 0x44 + c, fmRegisterYM2608[chipID][p][0x44 + c], vgm.enmModel.RealModel);
                    setYM2608Register((byte)chipID, p, 0x48 + c, fmRegisterYM2608[chipID][p][0x48 + c], vgm.enmModel.RealModel);
                    setYM2608Register((byte)chipID, p, 0x4c + c, fmRegisterYM2608[chipID][p][0x4c + c], vgm.enmModel.RealModel);
                }
            }

            //ssg
            setYM2608Register((byte)chipID, 0, 0x08, fmRegisterYM2608[chipID][0][0x08], vgm.enmModel.RealModel);
            setYM2608Register((byte)chipID, 0, 0x09, fmRegisterYM2608[chipID][0][0x09], vgm.enmModel.RealModel);
            setYM2608Register((byte)chipID, 0, 0x0a, fmRegisterYM2608[chipID][0][0x0a], vgm.enmModel.RealModel);

            //rhythm
            setYM2608Register((byte)chipID, 0, 0x11, fmRegisterYM2608[chipID][0][0x11], vgm.enmModel.RealModel);

            //adpcm
            setYM2608Register((byte)chipID, 1, 0x0b, fmRegisterYM2608[chipID][1][0x0b], vgm.enmModel.RealModel);
        }

        public void setFadeoutVolYM2610(int chipID, int v)
        {
            nowYM2610FadeoutVol[chipID] = v;
            for (int p = 0; p < 2; p++)
            {
                for (int c = 0; c < 3; c++)
                {
                    setYM2610Register((byte)chipID, p, 0x40 + c, fmRegisterYM2610[chipID][p][0x40 + c], vgm.enmModel.RealModel);
                    setYM2610Register((byte)chipID, p, 0x44 + c, fmRegisterYM2610[chipID][p][0x44 + c], vgm.enmModel.RealModel);
                    setYM2610Register((byte)chipID, p, 0x48 + c, fmRegisterYM2610[chipID][p][0x48 + c], vgm.enmModel.RealModel);
                    setYM2610Register((byte)chipID, p, 0x4c + c, fmRegisterYM2610[chipID][p][0x4c + c], vgm.enmModel.RealModel);
                }
            }

            //ssg
            setYM2610Register((byte)chipID, 0, 0x08, fmRegisterYM2610[chipID][0][0x08], vgm.enmModel.RealModel);
            setYM2610Register((byte)chipID, 0, 0x09, fmRegisterYM2610[chipID][0][0x09], vgm.enmModel.RealModel);
            setYM2610Register((byte)chipID, 0, 0x0a, fmRegisterYM2610[chipID][0][0x0a], vgm.enmModel.RealModel);

            //rhythm
            setYM2610Register((byte)chipID, 0, 0x11, fmRegisterYM2610[chipID][0][0x11], vgm.enmModel.RealModel);

            //adpcm
            setYM2610Register((byte)chipID, 1, 0x0b, fmRegisterYM2610[chipID][1][0x0b], vgm.enmModel.RealModel);
        }

        public void setFadeoutVolYM2612(int chipID, int v)
        {
            nowYM2612FadeoutVol[chipID] = v;
            for (int p = 0; p < 2; p++)
            {
                for (int c = 0; c < 3; c++)
                {
                    setYM2612Register((byte)chipID, p, 0x40 + c, fmRegisterYM2612[chipID][p][0x40 + c], vgm.enmModel.RealModel, -1);
                    setYM2612Register((byte)chipID, p, 0x44 + c, fmRegisterYM2612[chipID][p][0x44 + c], vgm.enmModel.RealModel, -1);
                    setYM2612Register((byte)chipID, p, 0x48 + c, fmRegisterYM2612[chipID][p][0x48 + c], vgm.enmModel.RealModel, -1);
                    setYM2612Register((byte)chipID, p, 0x4c + c, fmRegisterYM2612[chipID][p][0x4c + c], vgm.enmModel.RealModel, -1);
                }
            }
        }


        public void setYM2151SyncWait(byte chipID, int wait)
        {
            if (scYM2151[chipID] != null && ctYM2151[chipID].UseWait)
            {
                scYM2151[chipID].setRegister(-1, (int)(wait * (ctYM2151[chipID].UseWaitBoost ? 2.0 : 1.0)));
            }
        }

        public void setYM2608SyncWait(byte chipID, int wait)
        {
            if (scYM2608[chipID] != null && ctYM2608[chipID].UseWait)
            {
                scYM2608[chipID].setRegister(-1, (int)(wait * (ctYM2608[chipID].UseWaitBoost ? 2.0 : 1.0)));
            }
        }

        public void setYM2612SyncWait(byte chipID, int wait)
        {
            if (scYM2612[chipID] != null && ctYM2612[chipID].UseWait)
            {
                scYM2612[chipID].setRegister(-1, (int)(wait * (ctYM2612[chipID].UseWaitBoost ? 2.0 : 1.0)));
            }
        }


        public void sendDataYM2151(byte chipID, vgm.enmModel model)
        {
            if (model == vgm.enmModel.VirtualModel) return;

            if (scYM2151[chipID] != null && ctYM2151[chipID].UseWait)
            {
                scYM2151[chipID].parentSoundInterface.parentNScci.sendData();
                while (!scYM2151[chipID].parentSoundInterface.parentNScci.isBufferEmpty()) { }
            }
        }

        public void sendDataYM2608(byte chipID, vgm.enmModel model)
        {
            if (model == vgm.enmModel.VirtualModel) return;

            if (scYM2608[chipID] != null && ctYM2608[chipID].UseWait)
            {
                scYM2608[chipID].parentSoundInterface.parentNScci.sendData();
                while (!scYM2608[chipID].parentSoundInterface.parentNScci.isBufferEmpty()) { }
            }
        }


        public void WriteYM2610_SetAdpcmA(int chipID, byte[] ym2610AdpcmA, vgm.enmModel model)
        {
            if (model == vgm.enmModel.VirtualModel)
            {
                mds.WriteYM2610_SetAdpcmA((byte)chipID, ym2610AdpcmA);
            }
        }

        public void WriteYM2610_SetAdpcmB(int chipID, byte[] ym2610AdpcmB, vgm.enmModel model)
        {
            if (model == vgm.enmModel.VirtualModel)
            {
                mds.WriteYM2610_SetAdpcmB((byte)chipID, ym2610AdpcmB);
            }
        }


        public int getYM2151Clock(byte chipID)
        {
            if (scYM2151[chipID] == null) return -1;

            return scYM2151[chipID].getSoundChipInfo().getdClock();
        }


        public void setSN76489Register(int chipID, int dData, vgm.enmModel model)
        {
            if (ctSN76489 == null) return;

            if (chipID == 0) ChipPriDCSG = 2;
            else ChipSecDCSG = 2;

            SN76489_Write(chipID, dData);

            if ((dData & 0x90) == 0x90)
            {
                sn76489Vol[chipID][(dData & 0x60) >> 5][0] = 15 - (dData & 0xf);
                sn76489Vol[chipID][(dData & 0x60) >> 5][1] = 15 - (dData & 0xf);

                int v = dData & 0xf;
                v = v + nowSN76489FadeoutVol[chipID];
                v += maskChSN76489[chipID][(dData & 0x60) >> 5] ? 15 : 0;
                v = Math.Min(v, 15);
                dData = (dData & 0xf0) | v;
            }

            if (model == vgm.enmModel.RealModel)
            {
                if (ctSN76489[chipID].UseScci)
                {
                    if (scSN76489[chipID] == null) return;
                    scSN76489[chipID].setRegister(0, dData);
                }
            }
            else
            {
                if (!ctSN76489[chipID].UseScci && ctSN76489[chipID].UseEmu)
                {
                    mds.WriteSN76489((byte)chipID, (byte)dData);
                }
            }
        }

        public void setSN76489SyncWait(byte chipID, int wait)
        {
            if (scSN76489 != null && ctSN76489[chipID].UseWait)
            {
                scSN76489[chipID].setRegister(-1, (int)(wait * (ctSN76489[chipID].UseWaitBoost ? 2.0 : 1.0)));
            }
        }

        public void setFadeoutVolSN76489(byte chipID, int v)
        {
            nowSN76489FadeoutVol[chipID] = (v & 0x78) >> 3;
            for (int c = 0; c < 4; c++)
            {

                setSN76489Register(chipID, 0x90 + (c << 5) + sn76489Register[chipID][1 + (c << 1)], vgm.enmModel.RealModel);
            }
        }

        public void resetChips()
        {
            for (int chipID = 0; chipID < 2; chipID++)
            {
                for (int p = 0; p < 2; p++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        setYM2612Register((byte)chipID, p, 0x40 + c, 127, vgm.enmModel.RealModel, -1);
                        setYM2612Register((byte)chipID, p, 0x44 + c, 127, vgm.enmModel.RealModel, -1);
                        setYM2612Register((byte)chipID, p, 0x48 + c, 127, vgm.enmModel.RealModel, -1);
                        setYM2612Register((byte)chipID, p, 0x4c + c, 127, vgm.enmModel.RealModel, -1);
                    }
                }


                for (int c = 0; c < 4; c++)
                {
                    setSN76489Register(chipID, 0x90 + (c << 5) + 0xf, vgm.enmModel.RealModel);
                }

                for (int p = 0; p < 2; p++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        setYM2608Register((byte)chipID, p, 0x40 + c, 127, vgm.enmModel.RealModel);
                        setYM2608Register((byte)chipID, p, 0x44 + c, 127, vgm.enmModel.RealModel);
                        setYM2608Register((byte)chipID, p, 0x48 + c, 127, vgm.enmModel.RealModel);
                        setYM2608Register((byte)chipID, p, 0x4c + c, 127, vgm.enmModel.RealModel);
                    }
                }

                //ssg
                setYM2608Register((byte)chipID, 0, 0x08, 0, vgm.enmModel.RealModel);
                setYM2608Register((byte)chipID, 0, 0x09, 0, vgm.enmModel.RealModel);
                setYM2608Register((byte)chipID, 0, 0x0a, 0, vgm.enmModel.RealModel);

                //rhythm
                setYM2608Register((byte)chipID, 0, 0x11, 0, vgm.enmModel.RealModel);

                //adpcm
                setYM2608Register((byte)chipID, 1, 0x0b, 0, vgm.enmModel.RealModel);


                for (int p = 0; p < 2; p++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        setYM2610Register((byte)chipID, p, 0x40 + c, 127, vgm.enmModel.RealModel);
                        setYM2610Register((byte)chipID, p, 0x44 + c, 127, vgm.enmModel.RealModel);
                        setYM2610Register((byte)chipID, p, 0x48 + c, 127, vgm.enmModel.RealModel);
                        setYM2610Register((byte)chipID, p, 0x4c + c, 127, vgm.enmModel.RealModel);
                    }
                }

                //ssg
                setYM2610Register((byte)chipID, 0, 0x08, 0, vgm.enmModel.RealModel);
                setYM2610Register((byte)chipID, 0, 0x09, 0, vgm.enmModel.RealModel);
                setYM2610Register((byte)chipID, 0, 0x0a, 0, vgm.enmModel.RealModel);

                //rhythm
                setYM2610Register((byte)chipID, 0, 0x11, 0, vgm.enmModel.RealModel);

                //adpcm
                setYM2610Register((byte)chipID, 1, 0x0b, 0, vgm.enmModel.RealModel);


                for (int c = 0; c < 8; c++)
                {
                    setYM2151Register((byte)chipID, 0, 0x60 + c, 127, vgm.enmModel.RealModel, 0);
                    setYM2151Register((byte)chipID, 0, 0x68 + c, 127, vgm.enmModel.RealModel, 0);
                    setYM2151Register((byte)chipID, 0, 0x70 + c, 127, vgm.enmModel.RealModel, 0);
                    setYM2151Register((byte)chipID, 0, 0x78 + c, 127, vgm.enmModel.RealModel, 0);
                }
            }

        }

        internal void SetFileName(string fn)
        {
            PlayingFileName = fn;
        }

        public void writeRF5C164PCMData(byte chipid, uint stAdr, uint dataSize, byte[] vgmBuf, uint vgmAdr, vgm.enmModel model)
        {
            if (chipid == 0) ChipPriRF5C = 2;
            else ChipSecRF5C = 2;

            if (model == vgm.enmModel.VirtualModel)
                mds.WriteRF5C164PCMData(chipid, stAdr, dataSize, vgmBuf, vgmAdr);
        }

        public void writeRF5C164(byte chipid, byte adr, byte data, vgm.enmModel model)
        {
            if (chipid == 0) ChipPriRF5C = 2;
            else ChipSecRF5C = 2;

            if (model == vgm.enmModel.VirtualModel)
                mds.WriteRF5C164(chipid, adr, data);
        }

        public void writeRF5C164MemW(byte chipid, uint offset, byte data, vgm.enmModel model)
        {
            if (chipid == 0) ChipPriRF5C = 2;
            else ChipSecRF5C = 2;

            if (model == vgm.enmModel.VirtualModel)
                mds.WriteRF5C164MemW(chipid, offset, data);
        }

        public void writePWM(byte chipid, byte adr, uint data, vgm.enmModel model)
        {
            if (chipid == 0) ChipPriPWM = 2;
            else ChipSecPWM = 2;

            if (model == vgm.enmModel.VirtualModel)
                mds.WritePWM(chipid, adr, data);
        }

        public void writeC140(byte chipid, uint adr, byte data, vgm.enmModel model)
        {
            if (chipid == 0) ChipPriC140 = 2;
            else ChipSecC140 = 2;

            if (model == vgm.enmModel.VirtualModel)
                mds.WriteC140(chipid, adr, data);
        }

        public void writeC140PCMData(byte chipid, uint ROMSize, uint DataStart, uint DataLength, byte[] romdata, uint SrcStartAdr, vgm.enmModel model)
        {
            if (chipid == 0) ChipPriC140 = 2;
            else ChipSecC140 = 2;

            if (model == vgm.enmModel.VirtualModel)
                mds.WriteC140PCMData(chipid, ROMSize, DataStart, DataLength, romdata, SrcStartAdr);
        }

        public void writeOKIM6258(byte ChipID, byte Port, byte Data, vgm.enmModel model)
        {
            if (ChipID == 0) ChipPriOKI5 = 2;
            else ChipSecOKI5 = 2;

            if (model == vgm.enmModel.VirtualModel)
                mds.WriteOKIM6258(ChipID, Port, Data);
        }

        public void writeOKIM6295(byte ChipID, byte Port, byte Data, vgm.enmModel model)
        {
            if (ChipID == 0) ChipPriOKI9 = 2;
            else ChipSecOKI9 = 2;

            if (model == vgm.enmModel.VirtualModel)
            {
                mds.WriteOKIM6295(ChipID, Port, Data);
                //System.Console.WriteLine("ChipID={0} Port={1:X} Data={2:X} ",ChipID,Port,Data);
            }
        }

        public void writeOKIM6295PCMData(byte chipid, uint ROMSize, uint DataStart, uint DataLength, byte[] romdata, uint SrcStartAdr, vgm.enmModel model)
        {
            if (chipid == 0) ChipPriOKI9 = 2;
            else ChipSecOKI9 = 2;

            if (model == vgm.enmModel.VirtualModel)
                mds.WriteOKIM6295PCMData(chipid, ROMSize, DataStart, DataLength, romdata, SrcStartAdr);
        }

        public void writeSEGAPCM(byte ChipID, int Offset, byte Data, vgm.enmModel model)
        {
            if (ChipID == 0) ChipPriSPCM = 2;
            else ChipSecSPCM = 2;

            if (model == vgm.enmModel.VirtualModel)
            {
                mds.WriteSEGAPCM(ChipID, Offset, Data);
                //System.Console.WriteLine("ChipID={0} Offset={1:X} Data={2:X} ", ChipID, Offset, Data);
            }
        }

        public void writeSEGAPCMPCMData(byte chipid, uint ROMSize, uint DataStart, uint DataLength, byte[] romdata, uint SrcStartAdr, vgm.enmModel model)
        {
            if (chipid == 0) ChipPriSPCM = 2;
            else ChipSecSPCM = 2;

            if (model == vgm.enmModel.VirtualModel)
            {
                mds.WriteSEGAPCMPCMData(chipid, ROMSize, DataStart, DataLength, romdata, SrcStartAdr);
            }
        }


        public void updateVol()
        {
            volF--;
            if (volF > 0) return;

            volF = 1;

            for (int chipID = 0; chipID < 2; chipID++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (fmVolYM2612[chipID][i][0] > 0) { fmVolYM2612[chipID][i][0] -= 50; if (fmVolYM2612[chipID][i][0] < 0) fmVolYM2612[chipID][i][0] = 0; }
                    if (fmVolYM2612[chipID][i][1] > 0) { fmVolYM2612[chipID][i][1] -= 50; if (fmVolYM2612[chipID][i][1] < 0) fmVolYM2612[chipID][i][1] = 0; }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (fmCh3SlotVolYM2612[chipID][i] > 0) { fmCh3SlotVolYM2612[chipID][i] -= 50; if (fmCh3SlotVolYM2612[chipID][i] < 0) fmCh3SlotVolYM2612[chipID][i] = 0; }
                }
                for (int i = 0; i < 8; i++)
                {
                    if (fmVolYM2151[chipID][i][0] > 0) { fmVolYM2151[chipID][i][0] -= 50; if (fmVolYM2151[chipID][i][0] < 0) fmVolYM2151[chipID][i][0] = 0; }
                    if (fmVolYM2151[chipID][i][1] > 0) { fmVolYM2151[chipID][i][1] -= 50; if (fmVolYM2151[chipID][i][1] < 0) fmVolYM2151[chipID][i][1] = 0; }
                }
                for (int i = 0; i < 9; i++)
                {
                    if (fmVolYM2608[chipID][i][0] > 0) { fmVolYM2608[chipID][i][0] -= 50; if (fmVolYM2608[chipID][i][0] < 0) fmVolYM2608[chipID][i][0] = 0; }
                    if (fmVolYM2608[chipID][i][1] > 0) { fmVolYM2608[chipID][i][1] -= 50; if (fmVolYM2608[chipID][i][1] < 0) fmVolYM2608[chipID][i][1] = 0; }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (fmCh3SlotVolYM2608[chipID][i] > 0) { fmCh3SlotVolYM2608[chipID][i] -= 50; if (fmCh3SlotVolYM2608[chipID][i] < 0) fmCh3SlotVolYM2608[chipID][i] = 0; }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (fmVolYM2608Rhythm[chipID][i][0] > 0) { fmVolYM2608Rhythm[chipID][i][0] -= 50; if (fmVolYM2608Rhythm[chipID][i][0] < 0) fmVolYM2608Rhythm[chipID][i][0] = 0; }
                    if (fmVolYM2608Rhythm[chipID][i][1] > 0) { fmVolYM2608Rhythm[chipID][i][1] -= 50; if (fmVolYM2608Rhythm[chipID][i][1] < 0) fmVolYM2608Rhythm[chipID][i][1] = 0; }
                }

                if (fmVolYM2608Adpcm[chipID][0] > 0) { fmVolYM2608Adpcm[chipID][0] -= 50; if (fmVolYM2608Adpcm[chipID][0] < 0) fmVolYM2608Adpcm[chipID][0] = 0; }
                if (fmVolYM2608Adpcm[chipID][1] > 0) { fmVolYM2608Adpcm[chipID][1] -= 50; if (fmVolYM2608Adpcm[chipID][1] < 0) fmVolYM2608Adpcm[chipID][1] = 0; }

                for (int i = 0; i < 9; i++)
                {
                    if (fmVolYM2610[chipID][i][0] > 0) { fmVolYM2610[chipID][i][0] -= 50; if (fmVolYM2610[chipID][i][0] < 0) fmVolYM2610[chipID][i][0] = 0; }
                    if (fmVolYM2610[chipID][i][1] > 0) { fmVolYM2610[chipID][i][1] -= 50; if (fmVolYM2610[chipID][i][1] < 0) fmVolYM2610[chipID][i][1] = 0; }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (fmCh3SlotVolYM2610[chipID][i] > 0) { fmCh3SlotVolYM2610[chipID][i] -= 50; if (fmCh3SlotVolYM2610[chipID][i] < 0) fmCh3SlotVolYM2610[chipID][i] = 0; }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (fmVolYM2610Rhythm[chipID][i][0] > 0) { fmVolYM2610Rhythm[chipID][i][0] -= 50; if (fmVolYM2610Rhythm[chipID][i][0] < 0) fmVolYM2610Rhythm[chipID][i][0] = 0; }
                    if (fmVolYM2610Rhythm[chipID][i][1] > 0) { fmVolYM2610Rhythm[chipID][i][1] -= 50; if (fmVolYM2610Rhythm[chipID][i][1] < 0) fmVolYM2610Rhythm[chipID][i][1] = 0; }
                }

                if (fmVolYM2610Adpcm[chipID][0] > 0) { fmVolYM2610Adpcm[chipID][0] -= 50; if (fmVolYM2610Adpcm[chipID][0] < 0) fmVolYM2610Adpcm[chipID][0] = 0; }
                if (fmVolYM2610Adpcm[chipID][1] > 0) { fmVolYM2610Adpcm[chipID][1] -= 50; if (fmVolYM2610Adpcm[chipID][1] < 0) fmVolYM2610Adpcm[chipID][1] = 0; }

                for (int i = 0; i < 6; i++)
                {
                    if (fmVolYM2203[chipID][i] > 0) { fmVolYM2203[chipID][i] -= 50; if (fmVolYM2203[chipID][i] < 0) fmVolYM2203[chipID][i] = 0; }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (fmCh3SlotVolYM2203[chipID][i] > 0) { fmCh3SlotVolYM2203[chipID][i] -= 50; if (fmCh3SlotVolYM2203[chipID][i] < 0) fmCh3SlotVolYM2203[chipID][i] = 0; }
                }
            }

        }


        public int[][] GetYM2151Volume(int chipID)
        {
            return fmVolYM2151[chipID];
        }

        public int[] GetYM2203Volume(int chipID)
        {
            return fmVolYM2203[chipID];
        }

        public int[][] GetYM2608Volume(int chipID)
        {
            return fmVolYM2608[chipID];
        }

        public int[][] GetYM2610Volume(int chipID)
        {
            return fmVolYM2610[chipID];
        }

        public int[][] GetYM2612Volume(int chipID)
        {
            //if (ctYM2612.UseScci)
            //{
            return fmVolYM2612[chipID];
            //}
            //return mds.ReadFMVolume();
        }


        public int[] GetYM2203Ch3SlotVolume(int chipID)
        {
            //if (ctYM2612.UseScci)
            //{
            return fmCh3SlotVolYM2203[chipID];
            //}
            //return mds.ReadFMCh3SlotVolume();
        }

        public int[] GetYM2608Ch3SlotVolume(int chipID)
        {
            //if (ctYM2612.UseScci)
            //{
            return fmCh3SlotVolYM2608[chipID];
            //}
            //return mds.ReadFMCh3SlotVolume();
        }

        public int[] GetYM2610Ch3SlotVolume(int chipID)
        {
            //if (ctYM2612.UseScci)
            //{
            return fmCh3SlotVolYM2610[chipID];
            //}
            //return mds.ReadFMCh3SlotVolume();
        }

        public int[] GetYM2612Ch3SlotVolume(int chipID)
        {
            //if (ctYM2612.UseScci)
            //{
            return fmCh3SlotVolYM2612[chipID];
            //}
            //return mds.ReadFMCh3SlotVolume();
        }


        public int[][] GetYM2608RhythmVolume(int chipID)
        {
            return fmVolYM2608Rhythm[chipID];
        }

        public int[][] GetYM2610RhythmVolume(int chipID)
        {
            return fmVolYM2610Rhythm[chipID];
        }


        public int[] GetYM2608AdpcmVolume(int chipID)
        {
            return fmVolYM2608Adpcm[chipID];
        }

        public int[] GetYM2610AdpcmVolume(int chipID)
        {
            return fmVolYM2610Adpcm[chipID];
        }


        public int[][] GetPSGVolume(int chipID)
        {

            return sn76489Vol[chipID];

        }


        private void SN76489_Write(int chipID, int data)
        {
            if ((data & 0x80) > 0)
            {
                /* Latch/data byte  %1 cc t dddd */
                LatchedRegister[chipID] = (data >> 4) & 0x07;
                sn76489Register[chipID][LatchedRegister[chipID]] =
                    (sn76489Register[chipID][LatchedRegister[chipID]] & 0x3f0) /* zero low 4 bits */
                    | (data & 0xf);                            /* and replace with data */
            }
            else
            {
                /* Data byte        %0 - dddddd */
                if ((LatchedRegister[chipID] % 2) == 0 && (LatchedRegister[chipID] < 5))
                    /* Tone register */
                    sn76489Register[chipID][LatchedRegister[chipID]] =
                        (sn76489Register[chipID][LatchedRegister[chipID]] & 0x00f) /* zero high 6 bits */
                        | ((data & 0x3f) << 4);                 /* and replace with data */
                else
                    /* Other register */
                    sn76489Register[chipID][LatchedRegister[chipID]] = data & 0x0f; /* Replace with data */
            }
            switch (LatchedRegister[chipID])
            {
                case 0:
                case 2:
                case 4: /* Tone channels */
                    if (sn76489Register[chipID][LatchedRegister[chipID]] == 0)
                        sn76489Register[chipID][LatchedRegister[chipID]] = 1; /* Zero frequency changed to 1 to avoid div/0 */
                    break;
                case 6: /* Noise */
                    NoiseFreq[chipID] = 0x10 << (sn76489Register[chipID][6] & 0x3); /* set noise signal generator frequency */
                    break;
            }
        }



        public enum enmChip
        {
            YM2612
        }

        private List<byte>[] midiData = null;
        private long[] midiData_OldFrameCounter = null;
        private int[] midiData_OldCode = null;
        private int[] midiData_OldFreq = null;

        private string PlayingFileName = "";

        public void outMIDIData(enmChip chip, int chipID, int dPort, int dAddr, int dData, long vgmFrameCounter)
        {
            if (!setting.midiExport.UseMIDIExport) return;
            if (setting.midiExport.ExportPath == "") return;
            if (vgmFrameCounter < 0) return;
            if (chip != enmChip.YM2612) return;
            if (chipID != 0) return;

            if (midiData == null)
            {
                outMIDIData_MakeHeader();
            }

            if (dPort == 0 && dAddr == 0x28)
            {
                byte ch = (byte)(dData & 0x7);
                ch = (byte)(ch > 2 ? ch - 1 : ch);
                byte cmd = (byte)((dData & 0xf0) != 0 ? 0x90 : 0x80);

                int p = ch > 2 ? 1 : 0;
                int vch = ch > 2 ? (ch - 3) : ch;
                midiData_OldFreq[ch+1] = fmRegisterYM2612[chipID][p][0xa0 + vch] + (fmRegisterYM2612[chipID][p][0xa4 + vch] & 0x3f) * 0x100;
                int freq = midiData_OldFreq[ch+1] & 0x7ff;
                if (freq == 0) return;
                int octav = (midiData_OldFreq[ch+1] & 0x3800) >> 11;
                int note = searchFMNote(freq);
                byte code = (byte)(octav * 12 + note);

                byte vel = (byte)(127 - fmRegisterYM2612[chipID][p][0x4c + vch]);

                if (midiData_OldCode[ch+1] < 0 && cmd == 0x80) return;

                outMIDIData_SetDelta(ch, vgmFrameCounter);

                if (midiData_OldCode[ch+1] >= 0 || cmd == 0x80)
                {
                    midiData[ch + 1].Add((byte)(0x80 | ch));
                    midiData[ch + 1].Add((byte)midiData_OldCode[ch+1]);
                    midiData[ch + 1].Add(0x00);

                    midiData_OldCode[ch+1] = -1;
                    if (cmd != 0x80) midiData[ch + 1].Add(0);//NextDeltaTime
                }

                if (cmd == 0x90)
                {
                    midiData[ch + 1].Add((byte)(0x90 | ch));
                    midiData[ch + 1].Add(code);
                    if (setting.midiExport.UseVOPMex)
                    {
                        midiData[ch + 1].Add(127);
                    }
                    else
                    {
                        midiData[ch + 1].Add(vel);
                    }

                    midiData_OldCode[ch + 1] = code;
                }

                return;
            }

            if (dAddr >= 0xa0 && dAddr < 0xa8)
            {
                byte ch = (byte)((dAddr & 0x3) + dPort * 3);
                int freq = midiData_OldFreq[ch+1];
                int vch = ch > 2 ? (ch - 3) : ch;
                if (freq == -1) return;
                if (dAddr < 0xa4)
                {
                    freq = (freq & 0x3f00) | dData;
                }
                else
                {
                    freq = (freq & 0xff) | ((dData & 0x3f) << 8);
                }

                if (freq != midiData_OldFreq[ch+1])
                {
                    int freq2nd = freq & 0x07ff;
                    if (freq2nd == 0) return;
                    int octav = (freq & 0x3800) >> 11;
                    int note = searchFMNote(freq2nd);
                    byte code = (byte)(octav * 12 + note);
                    if (midiData_OldCode[ch+1] != -1 && midiData_OldCode[ch+1] != code)
                    {
                        outMIDIData_SetDelta(ch,vgmFrameCounter);
                        midiData[ch + 1].Add((byte)(0x80 | ch));
                        midiData[ch + 1].Add((byte)midiData_OldCode[ch+1]);
                        midiData[ch + 1].Add(0x00);

                        midiData[ch + 1].Add(0);//delta0
                        midiData[ch + 1].Add((byte)(0x90 | ch));
                        midiData[ch + 1].Add(code);
                        if (setting.midiExport.UseVOPMex)
                        {
                            midiData[ch + 1].Add(127);
                        }
                        else
                        {
                            byte vel = (byte)(127 - fmRegisterYM2612[chipID][dPort][0x4c + vch]);
                            midiData[ch + 1].Add(vel);
                        }

                        midiData_OldFreq[ch+1] = freq;
                        midiData_OldCode[ch+1] = code;
                    }
                }

                return;
            }

            ////
            //VOPMex向け
            ////
            if (!setting.midiExport.UseVOPMex) return;

            //DT/ML
            if ((dAddr & 0xf0) == 0x30)
            {
                int ch = (dAddr & 0x3) + dPort * 3;
                int op = (dAddr & 0xc) >> 2;
                op = (op == 1) ? 2 : ((op == 2) ? 1 : op);

                outMIDIData_SetDelta(ch,vgmFrameCounter);

                midiData[ch + 1].Add((byte)(0xb0 | ch)); // DT
                midiData[ch + 1].Add((byte)(24 + op));
                midiData[ch + 1].Add((byte)((dData & 0x70) >> 4));

                midiData[ch + 1].Add(0);//Delta 0

                midiData[ch + 1].Add((byte)(0xb0 | ch)); //ML
                midiData[ch + 1].Add((byte)(20 + op));
                midiData[ch + 1].Add((byte)((dData & 0x0f) >> 0));

                return;
            }

            //TL
            if ((dAddr & 0xf0) == 0x40)
            {
                int ch = (dAddr & 0x3) + dPort * 3;
                int op = (dAddr & 0xc) >> 2;
                op = (op == 1) ? 2 : ((op == 2) ? 1 : op);

                outMIDIData_SetDelta(ch,vgmFrameCounter);

                midiData[ch + 1].Add((byte)(0xb0 | ch)); // TL
                midiData[ch + 1].Add((byte)(16 + op));
                midiData[ch + 1].Add((byte)((dData & 0x7f) >> 0));

                return;
            }

            //KS/AR
            if ((dAddr & 0xf0) == 0x50)
            {
                int ch = (dAddr & 0x3) + dPort * 3;
                int op = (dAddr & 0xc) >> 2;
                op = (op == 1) ? 2 : ((op == 2) ? 1 : op);

                outMIDIData_SetDelta(ch,vgmFrameCounter);

                midiData[ch + 1].Add((byte)(0xb0 | ch)); // KS
                midiData[ch + 1].Add((byte)(39 + op));
                midiData[ch + 1].Add((byte)((dData & 0xc0) >> 6));

                midiData[ch + 1].Add(0);//Delta 0

                midiData[ch + 1].Add((byte)(0xb0 | ch)); //AR
                midiData[ch + 1].Add((byte)(43 + op));
                midiData[ch + 1].Add((byte)((dData & 0x1f) >> 0));

                return;
            }

            //AMS/DR
            if ((dAddr & 0xf0) == 0x60)
            {
                int ch = (dAddr & 0x3) + dPort * 3;
                int op = (dAddr & 0xc) >> 2;
                op = (op == 1) ? 2 : ((op == 2) ? 1 : op);

                outMIDIData_SetDelta(ch,vgmFrameCounter);

                midiData[ch + 1].Add((byte)(0xb0 | ch)); // AMS
                midiData[ch + 1].Add((byte)(70 + op));
                midiData[ch + 1].Add((byte)((dData & 0x80) >> 7));

                midiData[ch + 1].Add(0);//Delta 0

                midiData[ch + 1].Add((byte)(0xb0 | ch)); //DR
                midiData[ch + 1].Add((byte)(47 + op));
                midiData[ch + 1].Add((byte)((dData & 0x1f) >> 0));

                return;
            }

            //SR
            if ((dAddr & 0xf0) == 0x70)
            {
                int ch = (dAddr & 0x3) + dPort * 3;
                int op = (dAddr & 0xc) >> 2;
                op = (op == 1) ? 2 : ((op == 2) ? 1 : op);

                outMIDIData_SetDelta(ch,vgmFrameCounter);

                midiData[ch + 1].Add((byte)(0xb0 | ch)); //SR
                midiData[ch + 1].Add((byte)(51 + op));
                midiData[ch + 1].Add((byte)((dData & 0x1f) >> 0));

                return;
            }

            //DL/RR
            if ((dAddr & 0xf0) == 0x80)
            {
                int ch = (dAddr & 0x3) + dPort * 3;
                int op = (dAddr & 0xc) >> 2;
                op = (op == 1) ? 2 : ((op == 2) ? 1 : op);

                outMIDIData_SetDelta(ch,vgmFrameCounter);

                midiData[ch + 1].Add((byte)(0xb0 | ch)); // DL
                midiData[ch + 1].Add((byte)(55 + op));
                midiData[ch + 1].Add((byte)((dData & 0xf0) >> 4));

                midiData[ch + 1].Add(0);//Delta 0

                midiData[ch + 1].Add((byte)(0xb0 | ch)); //RR
                midiData[ch + 1].Add((byte)(59 + op));
                midiData[ch + 1].Add((byte)((dData & 0x0f) >> 0));

                return;
            }

            //FB/ALG
            if (dAddr >= 0xB0 && dAddr < 0xB4)
            {
                int ch = (dAddr & 0x3) + dPort * 3;

                outMIDIData_SetDelta(ch,vgmFrameCounter);

                midiData[ch + 1].Add((byte)(0xb0 | ch)); // FB
                midiData[ch + 1].Add((byte)(15));
                midiData[ch + 1].Add((byte)((dData & 0x38) >> 3));

                midiData[ch + 1].Add(0);//Delta 0

                midiData[ch + 1].Add((byte)(0xb0 | ch)); //ALG
                midiData[ch + 1].Add((byte)(14));
                midiData[ch + 1].Add((byte)((dData & 0x07) >> 0));

                return;
            }

            //PAN/AMS/FMS
            if (dAddr >= 0xB4 && dAddr < 0xB8)
            {
                int ch = (dAddr & 0x3) + dPort * 3;

                outMIDIData_SetDelta(ch,vgmFrameCounter);

                midiData[ch + 1].Add((byte)(0xb0 | ch)); // PAN
                midiData[ch + 1].Add((byte)(10));
                int pan = (dData & 0xc0) >> 6;
                midiData[ch + 1].Add((byte)(pan == 0 ? 64 : ((pan == 1) ? 127 : ((pan == 2) ? 1 : 64))));

                midiData[ch + 1].Add(0);//Delta 0

                midiData[ch + 1].Add((byte)(0xb0 | ch)); //AMS
                midiData[ch + 1].Add((byte)(76));
                midiData[ch + 1].Add((byte)((dData & 0x38) >> 3));

                midiData[ch + 1].Add(0);//Delta 0

                midiData[ch + 1].Add((byte)(0xb0 | ch)); //FMS
                midiData[ch + 1].Add((byte)(75));
                midiData[ch + 1].Add((byte)((dData & 0x03) >> 0));

                return;
            }

        }

        public void outMIDIData_Close()
        {
            if (!setting.midiExport.UseMIDIExport) return;
            if (setting.midiExport.ExportPath == "") return;
            if (midiData == null) return;
            //if (midiData.Count < 23) return;


            for (int ch = 1; ch < 1+6; ch++)
            {
                outMIDIData_SetDelta(ch - 1, midiData_OldFrameCounter[ch]);

                if (midiData_OldCode[ch] >= 0)
                {

                    midiData[ch].Add((byte)(0x80 | (ch-1)));
                    midiData[ch].Add((byte)midiData_OldCode[ch]);
                    midiData[ch].Add(0x00);

                    midiData_OldCode[ch] = -1;
                    midiData[ch].Add(0x00);//Delta 0
                }

                midiData[ch].Add(0xff); //メタイベント
                midiData[ch].Add(0x2f);
                midiData[ch].Add(0x00);

                int MTrkLengthAdr = 0x04;
                midiData[ch][MTrkLengthAdr + 0] = (byte)(((midiData[ch].Count - (MTrkLengthAdr + 4)) & 0xff000000) >> 24);
                midiData[ch][MTrkLengthAdr + 1] = (byte)(((midiData[ch].Count - (MTrkLengthAdr + 4)) & 0x00ff0000) >> 16);
                midiData[ch][MTrkLengthAdr + 2] = (byte)(((midiData[ch].Count - (MTrkLengthAdr + 4)) & 0x0000ff00) >> 8);
                midiData[ch][MTrkLengthAdr + 3] = (byte)(((midiData[ch].Count - (MTrkLengthAdr + 4)) & 0x000000ff) >> 0);
            }


            try
            {
                string fn = PlayingFileName == "" ? "Temp.mid" : PlayingFileName;
                List<byte> buf = new List<byte>();
                for (int i = 0; i < 1 + 6; i++)
                {
                    foreach (byte d in midiData[i]) buf.Add(d);
                }
                File.WriteAllBytes(Path.Combine(setting.midiExport.ExportPath, Path.ChangeExtension(Path.GetFileName(fn), ".mid")), buf.ToArray());
            }
            catch
            {
            }

            midiData = null;
        }

        private int searchFMNote(int freq)
        {
            int m = int.MaxValue;
            int n = 0;
            for (int i = 0; i < 12 * 5; i++)
            {
                int a = Math.Abs(freq - Tables.FmFNum[i]);
                if (m > a)
                {
                    m = a;
                    n = i;
                }
            }
            return n - 12 * 3;
        }

        private void outMIDIData_SetDelta(int ch,long NewFrameCounter)
        {

            long sub = NewFrameCounter - midiData_OldFrameCounter[ch + 1];
            long step = (long)(sub / 44100.0 * 960.0);
            midiData_OldFrameCounter[ch + 1] += (long)(step * 44100.0 / 960.0);

            //byte[] a = new byte[4];
            //a[0] = (byte)((step & 0x0fe00000) >> 21);
            //a[1] = (byte)((step & 0x001fc000) >> 14);
            //a[2] = (byte)((step & 0x00003f80) >>  7);
            //a[3] = (byte)((step & 0x0000007f) >>  0);
            bool flg = true;
            for (int i = 0; i < 4; i++)
            {
                byte d = (byte)((step & (0x0fe00000 >> (7 * i))) >> (21 - 7 * i));
                if (flg && d == 0 && i < 3) continue;
                flg = false;
                d |= (byte)((i != 3) ? 0x80 : 0x00);
                midiData[ch + 1].Add(d);
            }

        }

        private void outMIDIData_MakeHeader()
        {
            int maxTrk = 1 + 6;

            midiData_OldCode = new int[maxTrk];
            midiData_OldFreq = new int[maxTrk];
            midiData = new List<byte>[maxTrk];
            midiData_OldFrameCounter = new long[maxTrk];

            for (int i = 0; i < maxTrk; i++)
            {
                midiData_OldCode[i] = -1;
                midiData_OldFreq[i] = -1;
                midiData[i] = new List<byte>();
                midiData_OldFrameCounter[i] = 0L;
            }

            midiData[0].Add(0x4d); //チャンクタイプ'MThd'
            midiData[0].Add(0x54);
            midiData[0].Add(0x68);
            midiData[0].Add(0x64);

            midiData[0].Add(0x00); //データ長
            midiData[0].Add(0x00);
            midiData[0].Add(0x00);
            midiData[0].Add(0x06);

            midiData[0].Add(0x00); //フォーマット
            midiData[0].Add(0x01);

            midiData[0].Add(0x00); //トラック数
            midiData[0].Add(0x07);

            midiData[0].Add(0x01); //分解能
            midiData[0].Add(0xe0);

            // Conductor Track

            midiData[0].Add(0x4d); //チャンクタイプ'MTrk'
            midiData[0].Add(0x54);
            midiData[0].Add(0x72);
            midiData[0].Add(0x6b);

            midiData[0].Add(0x00); //データ長 0x17
            midiData[0].Add(0x00);
            midiData[0].Add(0x00);
            midiData[0].Add(0x17);

            midiData[0].Add(0x00); //Delta 0

            midiData[0].Add(0xff); //メタイベント
            midiData[0].Add(0x03);
            midiData[0].Add(0x00);

            midiData[0].Add(0x00); //Delta 0

            midiData[0].Add(0xff); //メタイベント　拍子 4/4(固定)
            midiData[0].Add(0x58);
            midiData[0].Add(0x04);
            midiData[0].Add(0x04);
            midiData[0].Add(0x02);
            midiData[0].Add(0x18);
            midiData[0].Add(0x08);

            midiData[0].Add(0x00); //Delta 0

            midiData[0].Add(0xff); //メタイベント　テンポ設定 BPM = 120
            midiData[0].Add(0x51);
            midiData[0].Add(0x03);
            midiData[0].Add(0x07);
            midiData[0].Add(0xa1);
            midiData[0].Add(0x20);

            midiData[0].Add(0x00); //Delta 0

            midiData[0].Add(0xff); //メタイベント　終端
            midiData[0].Add(0x2f);
            midiData[0].Add(0x00);

            // 実 Track

            for (int i = 1; i < maxTrk; i++)
            {
                midiData[i].Add(0x4d); //チャンクタイプ'MTrk'
                midiData[i].Add(0x54);
                midiData[i].Add(0x72);
                midiData[i].Add(0x6b);

                midiData[i].Add(0x00); //データ長 この時点では不明のためとりあえず0
                midiData[i].Add(0x00);
                midiData[i].Add(0x00);
                midiData[i].Add(0x00);

                midiData[i].Add(0x00); //delta0
                midiData[i].Add(0xff); // メタイベント　トラック名
                midiData[i].Add(0x03);
                midiData[i].Add(0x00);

                midiData[i].Add(0x00); //delta0
                midiData[i].Add(0xff); // メタイベントポート指定
                midiData[i].Add(0x21);
                midiData[i].Add(0x01);
                midiData[i].Add(0x00); //Port1

            }


            if (!setting.midiExport.UseVOPMex) return;

            //VOPMex向け

            for (int i = 1; i < maxTrk; i++)
            {
                //音色コントロールの動作を変更(全MIDIチャンネル)
                midiData[i].Add(0x00); //Delta 0
                midiData[i].Add((byte)(0xb0 + (i - 1))); // CC 98 127
                midiData[i].Add(121);
                midiData[i].Add(127);
                midiData[i].Add(0x00); //Delta 0
                midiData[i].Add((byte)(0xb0 + (i - 1))); // CC 98 127
                midiData[i].Add(98);
                midiData[i].Add(127);
                midiData[i].Add(0x00); //Delta 0
                midiData[i].Add((byte)(0xb0 + (i - 1))); // CC 99 126
                midiData[i].Add(99);
                midiData[i].Add(126);
                midiData[i].Add(0x00); //Delta 0
                midiData[i].Add((byte)(0xb0 + (i - 1))); // CC 6 127
                midiData[i].Add(6);
                midiData[i].Add(127);
            }
        }

    }
}
