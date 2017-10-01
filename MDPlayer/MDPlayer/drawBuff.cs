﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPlayer
{
    public static class DrawBuff
    {


        private static byte[][] rChipName;
        private static byte[][] rFont1;
        private static byte[][] rFont2;
        private static byte[][] rFont3;
        private static byte[][] rKBD;
        private static byte[][] rMenuButtons;
        private static byte[][] rPan;
        private static byte[][] rPan2;
        private static byte[] rPSGEnv;
        private static byte[][] rPSGMode;
        private static byte[][] rType;
        private static byte[][] rVol;
        private static byte[] rWavGraph;
        private static byte[] rFader;
        private static byte[][] rMIDILCD_Fader;
        private static byte[] rMIDILCD_KBD;
        private static byte[][] rMIDILCD_Vol;
        public static byte[][] rMIDILCD;
        private static byte[][] rMIDILCD_Font;
        public static byte[][] rPlane_MIDI;
        private static Bitmap[] bitmapMIDILyric = null;
        private static Graphics[] gMIDILyric = null;
        private static Font[] fntMIDILyric = null;

        private static int[] kbl = new int[] { 0, 0, 2, 1, 4, 2, 6, 1, 8, 3, 12, 0, 14, 1, 16, 2, 18, 1, 20, 2, 22, 1, 24, 3 };
        private static string[] kbn = new string[] { "C ", "C#", "D ", "D#", "E ", "F ", "F#", "G ", "G#", "A ", "A#", "B " };
        public static string[] kbns = new string[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        private static string[] kbnp = new string[] { "C ", "C+", "D ", "D+", "E ", "F ", "F+", "G ", "G+", "A ", "A+", "B " };
        private static string[] kbo = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };
        private static int[] kbl2 = new int[] { 0, 12, 4, 12, 8, 0, 12, 4, 12, 4, 12, 8 };
        private static int[] kbdl = new int[] { 0, 2, 4, 6, 8, 12, 14, 16, 18, 20, 22, 24 };

        private static string[][] tblMIDIEffectGS = new string[4][] {
            new string[] { "Room 1         " , "Room 2         " , "Room 3         " , "Hall 1         "
                         , "Hall 2         " , "Plate          " , "Delay          " , "Panning Delay  " },
            new string[] { "Chorus 1       " , "Chorus 2       " , "Chorus 3       " , "Chorus 4       "
                         , "Feedback Chorus" , "Flanger        " , "Short Delay    " , "ShortDelay(FB) " },
            new string[] { "Delay 1        " , "Delay 2        " , "Delay 3        " , "Delay 4        "
                         , "Pan Delay 1    " , "Pan Delay 2    " , "Pan Delay 3    " , "Pan Delay 4    "
                         , "Delay to Reverb" , "Pan Repeat     " },
            new string[] { "Thru           " , "Stereo-EQ      " , "Spectrum       " , "Enhancer       "
                         , "Humanizer      " , "Overdrive      " , "Distortion     " , "Phaser         "
                         , "Auto Wah       " , "Rotary         " , "Stereo Flanger " , "Step Flanger   "
                         , "Tremolo        " , "Auto Pan       " , "Compressor     " , "Limiter        "
                         , "Hexa Chorus    " , "Tremolo Chorus " , "Stereo Chorus  " , "Space D        "
                         , "3D Chorus      " , "Stereo Delay   " , "Mod Delay      " , "3 Tap Delay    "
                         , "4 Tap Delay    " , "Tm Ctrl Delay  " , "Reverb         " , "Gate Reverb    "
                         , "3D Delay       " , "2 Pitch Shifter" , "Fb P.Shifter   " , "3D Auto        "
                         , "3D Manual      " , "Lo-Fi 1        " , "Lo-Fi 2        " , "OD>Chorus      "
                         , "OD>Flanger     " , "OD>Delay       " , "DS>Chorus      " , "DS>Flanger     "
                         , "DS>Delay       " , "EH>Chorus      " , "EH>Flanger     " , "EH>Delay       "
                         , "Cho>Delay      " , "FL>Delay       " , "Cho>Flanger    " , "Rotary Multi   "
                         , "GTR Multi 1    " , "GTR Multi 2    " , "GTR Multi 3    " , "Clean GtMulti 1"
                         , "Clean GtMulti 2" , "Bass Multi     " , "Rhodes Multi   " , "Keyboard Multi "
                         , "Cho/Delay      " , "FL/Dealy       " , "Cho/Flanger    " , "OD1/OD2        "
                         , "OD/Rotary      " , "OD/Phaser      " , "OD/AutoWah     " , "PH/Rotary      "
                         , "PH/AutoWah     "
            }
        };

        private static string[][] tblMIDIEffectXG = new string[3][] {
            new string[] {
                           "NO EFFECT                 " , "HALL 1                    " , "HALL 2                    " , "HALL M                    "
                         , "HALL L                    " , "ROOM 1                    " , "ROOM 2                    " , "ROOM 3                    "
                         , "ROOM S                    " , "ROOM M                    " , "ROOM L                    " , "STAGE1                    "
                         , "STAGE2                    " , "PLATE                     " , "GMPLATE                   " , "WHITEROOM                 "
                         , "TUNNEL                    " , "CANYON                    " , "BASEMENT                  "
            } ,
            new string[] {
                           "NO EFFECT                 " , "CHORUS1                   " , "CHORUS2                   " , "CHORUS3                   "
                         , "CHORUS4                   " , "GMCHORUS 1                " , "GMCHORUS 2                " , "GMCHORUS 3                "
                         , "GMCHORUS 4                " , "FB CHORUS                 " , "CELESTE1                  " , "CELESTE2                  "
                         , "CELESTE3                  " , "CELESTE4                  " , "FLANGER 1                 " , "FLANGER 2                 "
                         , "FLANGER 3                 " , "GMFLANGER                 " , "SYMPHONIC                 " , "PHASER 1                  "
                         , "ENSEMBLEDETUNE            "
            } ,
            new string[] {
                           "NO EFFECT                 " , "HALL1                     " , "HALL2                     " , "HALL M                    "
                         , "HALL L                    " , "ROOM1                     " , "ROOM2                     " , "ROOM3                     "
                         , "ROOM S                    " , "ROOM M                    " , "ROOM L                    " , "STAGE1                    "
                         , "STAGE2                    " , "PLATE                     " , "GM PLATE                  " , "DELAY L,C,R               "
                         , "DELAY L,R                 " , "ECHO                      " , "CROSSDELAY                " , "ER1                       "
                         , "ER2                       " , "GATE REVERB               " , "REVERSE GATE              " , "WHITE ROOM                "
                         , "TUNNEL                    " , "CANYON                    " , "BASEMENT                  " , "KARAOKE1                  "
                         , "KARAOKE2                  " , "KARAOKE3                  " , "CHORUS1                   " , "CHORUS2                   "
                         , "CHORUS3                   " , "CHORUS4                   " , "GMCHORUS 1                " , "GMCHORUS 2                "
                         , "GMCHORUS 3                " , "GMCHORUS 4                " , "FB CHORUS                 " , "CELESTE1                  "
                         , "CELESTE2                  " , "CELESTE3                  " , "CELESTE4                  " , "FLANGER 1                 "
                         , "FLANGER 2                 " , "FLANGER 3                 " , "GMFLANGER                 " , "SYMPHONIC                 "
                         , "ROTARYSP.                 " , "DIST+ROTARYSP.            " , "OVERDRIVE+ROTARYSP.       " , "AMPSIM.+ROTARY            "
                         , "TREMOLO                   " , "AUTO PAN                  " , "PHASER1                   " , "PHASER2                   "
                         , "DISTORTION                " , "COMP+DISTORTION           " , "STEREODISTORTION          " , "OVERDRIVE                 "
                         , "STEREOOVERDRIVE           " , "AMPSIM.                   " , "STEREOAMPSIM.             " , "3BANDEQ                   "
                         , "2BANDEQ                   " , "AUTO WAH                  " , "AUTO WAH+DIST             " , "AUTO WAH+OVERDRIVE        "
                         , "PITCH CHANGE              " , "PITCH CHANGE2             " , "HARMONIC ENHANCER         " , "TOUCHWAH 1                "
                         , "TOUCHWAH 2                " , "TOUCHWAH+DIST             " , "TOUCHWAH+OVERDRIVE        " , "COMPRESSOR                "
                         , "NOISEGATE                 " , "VOICECANCEL               " , "2WAY ROTARY SP            " , "DIST. + 2WAYROTARY SP.    "
                         , "OVERDRIVE + 2WAY ROTARYSP." , "AMPSIM. + 2WAY ROTARYSP.  " , "ENSEMBLE DETUNE           " , "AMBIENCE                  "
                         , "TALKING MODULATION        " , "LO-FI                     " , "DIST+DELAY                " , "OVERDRIVE+DELAY           "
                         , "COMP+DIST+DELAY           " , "COMP+OVERDRIVE+DELAY      " , "WAH+DIST+DELAY            " , "WAH+OVERDRIVE+DELAY       "
                         , "V DISTORTION HARD         " , "V DISTORTION HARD+DELAY   " , "V DISTORTION SOFT         " , "V DISTORTION SOFT+DELAY   "
                         , "DUAL ROTOR SPEAKER1       " , "DUAL ROTOR SPEAKER2       " , "THRU                      "
            }
        };

        private static string[] tblMIDIInstrumentGM = new string[] {
                         "G.Piano  ","B.Piano  ","E.Piano  ","Honkytonk"
                        ,"E.Piano1 ","E.Piano2 ","Harpschrd","Clavi    "
                        ,"Celesta  ","Glocken  ","Music Box","Vibraphon"
                        ,"Marimba  ","Xylophone","Tblarbell","Dulcimer "
                        ,"D.Organ  ","P.Organ  ","R.Organ  ","ChrchOrgn"
                        ,"Reed Orgn","Accordion","Harmonica","T.Accrdon"
                        ,"NylonGt. ","SteelGt. ","JazzGt.  ","CleanGt. "
                        ,"MutedGt. ","Overd.Gt.","Dist.Gt. ","Harmo.Gt."
                        ,"A.Bass   ","FingrBass","PickBass ","FrtlBass "
                        ,"SlapBass1","SlapBass2","Syn.Bass1","Syn.Bass2"
                        ,"Violin   ","Viola    ","Cello    ","Cntrabass"
                        ,"TremlStr.","PizzStr. ","Harp     ","Timpani  "
                        ,"Strings1 ","Strings2 ","Syn.Str1 ","Syn.Str2 "
                        ,"ChoirAahs","VoiceOohs","SynVoice ","OrchHit  "
                        ,"Trumpet  ","Trombone ","Tuba     ","MtTrumpet"
                        ,"Fr. Horn ","BrassSec.","Syn.Brs1 ","Syn.Brs2 "
                        ,"SoprnoSax","AltoSax  ","TenorSax ","BartnSax "
                        ,"Oboe     ","Eng.Horn ","Bassoon  ","Clarinet "
                        ,"Piccolo  ","Flute    ","Recorder ","PanFlute "
                        ,"BlowBttle","Shakuhach","Whistle  ","Ocarina  "
                        ,"Square   ","Saw      ","Calliope ","Chiff    "
                        ,"Charang  ","Voice    ","5thSaw   ","Bassoon  "
                        ,"NewAge   ","Warm     ","Polysynth","Choir    "
                        ,"BowedGlss","MetalPad ","Halo     ","Sweep    "
                        ,"IceRain  ","Soundtrk ","Crystal  ","Atmsphere"
                        ,"Brightnes","Goblins  ","Echoes   ","Sci-fi   "
                        ,"Sitar    ","Banjo    ","Shamisen ","Koto     "
                        ,"Kalimba  ","BagPipe  ","Fiddle   ","Shanai   "
                        ,"TinkleBll","Agogo    ","SteelDrum","Woodblock"
                        ,"Taiko    ","Melo.Tom ","Syn.Drum ","Rev.Cym  "
                        ,"Gt.FretNz","BrthNoise","Seashore ","BirdTweet"
                        ,"Telephone","Helicoptr","Applause ","Gunshot  "
        };

        private static byte[] spc = new byte[] {
              0x20, 0x3c, 0x3c, 0x20, 0x4d, 0x44, 0x50, 0x6c
            , 0x61, 0x79, 0x65, 0x72, 0x20, 0x3e, 0x3e, 0x20
            , 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20
            , 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };





        public static void Init()
        {
            rChipName = new byte[3][];
            rChipName[0] = getByteArray(Properties.Resources.rChipName_01);
            rChipName[1] = getByteArray(Properties.Resources.rChipName_02);
            rChipName[2] = getByteArray(Properties.Resources.rChipName_03);

            rFont1 = new byte[2][];
            rFont1[0] = getByteArray(Properties.Resources.rFont_01);
            rFont1[1] = getByteArray(Properties.Resources.rFont_02);
            rFont2 = new byte[5][];
            rFont2[0] = getByteArray(Properties.Resources.rFont_03);
            rFont2[1] = getByteArray(Properties.Resources.rFont_04);
            rFont2[2] = getByteArray(Properties.Resources.rMIDILCD_Font_04);
            rFont2[3] = getByteArray(Properties.Resources.rMIDILCD_Font_05);
            rFont2[4] = getByteArray(Properties.Resources.rMIDILCD_Font_06);
            rFont3 = new byte[2][];
            rFont3[0] = getByteArray(Properties.Resources.rFont_05);
            rFont3[1] = getByteArray(Properties.Resources.rFont_06);

            rKBD = new byte[2][];
            rKBD[0] = getByteArray(Properties.Resources.rKBD_01);
            rKBD[1] = getByteArray(Properties.Resources.rKBD_02);

            rMenuButtons = new byte[2][];
            rMenuButtons[0] = getByteArray(Properties.Resources.rMenuButtons_01);
            rMenuButtons[1] = getByteArray(Properties.Resources.rMenuButtons_02);

            rPan = new byte[2][];
            rPan[0] = getByteArray(Properties.Resources.rPan_01);
            rPan[1] = getByteArray(Properties.Resources.rPan_02);

            rPan2 = new byte[2][];
            rPan2[0] = getByteArray(Properties.Resources.rPan2_01);
            rPan2[1] = getByteArray(Properties.Resources.rPan2_02);

            rPSGEnv = getByteArray(Properties.Resources.rPSGEnv);

            rPSGMode = new byte[4][];
            rPSGMode[0] = getByteArray(Properties.Resources.rPSGMode_01);
            rPSGMode[1] = getByteArray(Properties.Resources.rPSGMode_02);
            rPSGMode[2] = getByteArray(Properties.Resources.rPSGMode_03);
            rPSGMode[3] = getByteArray(Properties.Resources.rPSGMode_04);

            rType = new byte[4][];
            rType[0] = getByteArray(Properties.Resources.rType_01);
            rType[1] = getByteArray(Properties.Resources.rType_02);
            rType[2] = getByteArray(Properties.Resources.rType_03);
            rType[3] = getByteArray(Properties.Resources.rType_04);

            rVol = new byte[2][];
            rVol[0] = getByteArray(Properties.Resources.rVol_01);
            rVol[1] = getByteArray(Properties.Resources.rVol_02);

            rWavGraph = getByteArray(Properties.Resources.rWavGraph);
            rFader = getByteArray(Properties.Resources.rFader);

            rMIDILCD_Fader = new byte[3][];
            rMIDILCD_Fader[0] = getByteArray(Properties.Resources.rMIDILCD_Fader_01);
            rMIDILCD_Fader[1] = getByteArray(Properties.Resources.rMIDILCD_Fader_02);
            rMIDILCD_Fader[2] = getByteArray(Properties.Resources.rMIDILCD_Fader_03);

            rMIDILCD_KBD = getByteArray(Properties.Resources.rMIDILCD_KBD_01);

            rMIDILCD_Vol = new byte[3][];
            rMIDILCD_Vol[0] = getByteArray(Properties.Resources.rMIDILCD_Vol_01);
            rMIDILCD_Vol[1] = getByteArray(Properties.Resources.rMIDILCD_Vol_02);
            rMIDILCD_Vol[2] = getByteArray(Properties.Resources.rMIDILCD_Vol_03);

            rMIDILCD = new byte[3][];
            rMIDILCD[0] = getByteArray(Properties.Resources.rMIDILCD_01);
            rMIDILCD[1] = getByteArray(Properties.Resources.rMIDILCD_02);
            rMIDILCD[2] = getByteArray(Properties.Resources.rMIDILCD_03);

            rMIDILCD_Font = new byte[3][];
            rMIDILCD_Font[0] = getByteArray(Properties.Resources.rMIDILCD_Font_01);
            rMIDILCD_Font[1] = getByteArray(Properties.Resources.rMIDILCD_Font_02);
            rMIDILCD_Font[2] = getByteArray(Properties.Resources.rMIDILCD_Font_03);

            rPlane_MIDI = new byte[3][];
            rPlane_MIDI[0] = getByteArray(Properties.Resources.planeMIDI_GM);
            rPlane_MIDI[1] = getByteArray(Properties.Resources.planeMIDI_XG);
            rPlane_MIDI[2] = getByteArray(Properties.Resources.planeMIDI_GS);

            bitmapMIDILyric = new Bitmap[2];
            bitmapMIDILyric[0] = new Bitmap(232, 24);
            bitmapMIDILyric[1] = new Bitmap(232, 24);
            gMIDILyric = new Graphics[2];
            gMIDILyric[0] = Graphics.FromImage(bitmapMIDILyric[0]);
            gMIDILyric[1] = Graphics.FromImage(bitmapMIDILyric[1]);
            fntMIDILyric = new Font[2];
            fntMIDILyric[0] = new Font("MS UI Gothic", 8);//, FontStyle.Bold);
            fntMIDILyric[1] = new Font("MS UI Gothic", 8);//, FontStyle.Bold);
        }


        public static void screenInitAY8910(FrameBuffer screen)
        {
            for (int ch = 0; ch < 3; ch++)
            {
                for (int ot = 0; ot < 12 * 8; ot++)
                {
                    int kx = kbl[(ot % 12) * 2] + ot / 12 * 28;
                    int kt = kbl[(ot % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, ch * 8 + 8, kt, 0);
                }
                drawFont8(screen, 296, ch * 8 + 8, 1, "   ");
            }
        }

        public static void screenInitC140(FrameBuffer screen)
        {
            //C140
            for (int ch = 0; ch < 24; ch++)
            {
                for (int ot = 0; ot < 12 * 8; ot++)
                {
                    int kx = kbl[(ot % 12) * 2] + ot / 12 * 28;
                    int kt = kbl[(ot % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, ch * 8 + 8, kt, 0);
                }
                drawFont8(screen, 296, ch * 8 + 8, 1, "   ");
                drawPanType2P(screen, 24, ch * 8 + 8, 0);
                ChC140_P(screen, 0, 8 + ch * 8, ch, false, 0);
            }
        }

        public static void screenInitHuC6280(FrameBuffer screen)
        {
            for (int ch = 0; ch < 6; ch++)
            {
                for (int ot = 0; ot < 12 * 8; ot++)
                {
                    int kx = kbl[(ot % 12) * 2] + ot / 12 * 28;
                    int kt = kbl[(ot % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, ch * 8 + 8, kt, 0);
                }
                drawFont8(screen, 296, ch * 8 + 8, 1, "   ");
            }
        }

        public static void screenInitRF5C164(FrameBuffer screen)
        {
            //RF5C164
            for (int ch = 0; ch < 8; ch++)
            {
                for (int ot = 0; ot < 12 * 8; ot++)
                {
                    int kx = kbl[(ot % 12) * 2] + ot / 12 * 28;
                    int kt = kbl[(ot % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, ch * 8 + 8, kt, 0);
                }
                drawFont8(screen, 296, ch * 8 + 8, 1, "   ");
                drawPanType2P(screen, 24, ch * 8 + 8, 0);
            }
        }

        public static void screenInitMIDI(FrameBuffer screen)
        {
        }

        public static void screenInitMixer(FrameBuffer screen)
        {
        }

        public static void screenInitOKIM6258(FrameBuffer screen)
        {
            int o;
            int n;

            o = 0; n = 3;
            PanToOKIM6258(screen, ref o, n, ref o, 0);

            drawFont4(screen, 12 * 4, 8, 0, string.Format("{0:d5}", 0));
            drawFont4(screen, 19 * 4, 8, 0, string.Format("{0:d5}", 0));
            drawFont4(screen, 26 * 4, 8, 0, string.Format("{0:d5}", 0));

            o = 0; n = 38;
            Volume(screen, 0, 1, ref o, n / 2, 0);
            o = 0; n = 38;
            Volume(screen, 0, 2, ref o, n / 2, 0);

        }

        public static void screenInitOKIM6295(FrameBuffer screen)
        {
        }

        public static void screenInitSegaPCM(FrameBuffer screen)
        {
            for (int ch = 0; ch < 16; ch++)
            {
                for (int ot = 0; ot < 12 * 8; ot++)
                {
                    int kx = kbl[(ot % 12) * 2] + ot / 12 * 28;
                    int kt = kbl[(ot % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, ch * 8 + 8, kt, 0);
                }
                drawFont8(screen, 296, ch * 8 + 8, 1, "   ");
                drawPanType2P(screen, 24, ch * 8 + 8, 0);
                ChSegaPCM_P(screen, 0, 8 + ch * 8, ch, false, 0);
            }
        }

        public static void screenInitSN76489(FrameBuffer screen,int tp)
        {

            for (int ch = 0; ch < 4; ch++)
            {
                if (ch != 3)
                {
                    for (int ot = 0; ot < 12 * 8; ot++)
                    {
                        int kx = kbl[(ot % 12) * 2] + ot / 12 * 28;
                        int kt = kbl[(ot % 12) * 2 + 1];
                        drawKbn(screen, 32 + kx, ch * 8 + 8, kt, tp);
                    }
                }
                else
                {
                }

                DrawBuff.drawFont8(screen, 296, ch * 8 + 8, 1, "   ");
                DrawBuff.ChSN76489_P(screen, 0, ch * 8 + 8, ch, false, tp);

                int d = 99;
                DrawBuff.Volume(screen, ch, 0, ref d, 0, tp);
            }
        }

        public static void screenInitYM2151(FrameBuffer screen, int tp)
        {
            //YM2151
            for (int ch = 0; ch < 8; ch++)
            {

                drawFont8(screen, 296, ch * 8 + 8, 1, "   ");

                for (int ot = 0; ot < 12 * 8; ot++)
                {
                    int kx = kbl[(ot % 12) * 2] + ot / 12 * 28;
                    int kt = kbl[(ot % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, ch * 8 + 8, kt, tp);
                }

                ChYM2151_P(screen, 0, ch * 8 + 8, ch, false, tp);
                drawPanP(screen, 24, ch * 8 + 8, 3, tp);
                int d = 99;
                Volume(screen, ch, 1, ref d, 0, tp);
                d = 99;
                Volume(screen, ch, 2, ref d, 0, tp);

            }
        }

        public static void screenInitYM2203(FrameBuffer screen, int tp)
        {
            //YM2203
            for (int y = 0; y < 3 + 3 + 3; y++)
            {

                drawFont8(screen, 296, y * 8 + 8, 1, "   ");
                for (int i = 0; i < 96; i++)
                {
                    int kx = kbl[(i % 12) * 2] + i / 12 * 28;
                    int kt = kbl[(i % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, y * 8 + 8, kt, tp);
                }

                int d = 99;
                Volume(screen, y, 0, ref d, 0, tp);
            }

        }

        public static void screenInitYM2413(FrameBuffer screen, int tp)
        {
            for (int y = 0; y < 9; y++)
            {
                //Note
                drawFont8(screen, 296, y * 8 + 8, 1, "   ");

                //Keyboard
                for (int i = 0; i < 96; i++)
                {
                    int kx = kbl[(i % 12) * 2] + i / 12 * 28;
                    int kt = kbl[(i % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, y * 8 + 8, kt, tp);
                }

                //Volume
                int d = 99;
                Volume(screen, y, 0, ref d, 0, tp);
            }

        }

        public static void screenInitYM2608(FrameBuffer screen, int tp)
        {
            //YM2608
            for (int y = 0; y < 6 + 3 + 3 + 1; y++)
            {

                drawFont8(screen, 296, y * 8 + 8, 1, "   ");
                for (int i = 0; i < 96; i++)
                {
                    int kx = kbl[(i % 12) * 2] + i / 12 * 28;
                    int kt = kbl[(i % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, y * 8 + 8, kt, tp);
                }

                if (y < 13)
                {
                    ChYM2608_P(screen, 0, y * 8 + 8, y, false, tp);
                }

                if (y < 6 || y == 12)
                {
                    drawPanP(screen, 24, y * 8 + 8, 3, tp);
                }

                int d = 99;
                if (y > 5 && y < 9)
                {
                    Volume(screen, y, 0, ref d, 0, tp);
                }
                else
                {
                    Volume(screen, y, 1, ref d, 0, tp);
                    d = 99;
                    Volume(screen, y, 2, ref d, 0, tp);
                }
            }

            for (int y = 0; y < 6; y++)
            {
                int d = 99;
                PanYM2608Rhythm(screen, y, ref d, 3, ref d, tp);
                d = 99;
                VolumeYM2608Rhythm(screen, y, 1, ref d, 0, tp);
                d = 99;
                VolumeYM2608Rhythm(screen, y, 2, ref d, 0, tp);
            }
        }

        public static void screenInitYM2610(FrameBuffer screen, int tp)
        {
            //YM2610
            for (int y = 0; y < 14; y++)
            {
                drawFont8(screen, 296, y * 8 + 8, 1, "   ");
                for (int i = 0; i < 96; i++)
                {
                    int kx = kbl[(i % 12) * 2] + i / 12 * 28;
                    int kt = kbl[(i % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, y * 8 + 8, kt, tp);
                }

                if (y < 13)
                {
                    ChYM2610_P(screen, 0, y * 8 + 8, y, false, tp);
                }

                if (y < 6 || y == 13)
                {
                    drawPanP(screen, 24, y * 8 + 8, 3, tp);
                }

                int d = 99;
                if (y > 5 && y < 9)
                {
                    Volume(screen, y, 0, ref d, 0, tp);
                }
                else
                {
                    Volume(screen, y, 1, ref d, 0, tp);
                    d = 99;
                    Volume(screen, y, 2, ref d, 0, tp);
                }
            }

            for (int y = 0; y < 6; y++)
            {
                int d = 99;
                PanYM2610Rhythm(screen, y, ref d, 3, ref d, tp);
                d = 99;
                DrawBuff.VolumeYM2610Rhythm(screen, y, 1, ref d, 0, tp);
                d = 99;
                DrawBuff.VolumeYM2610Rhythm(screen, y, 2, ref d, 0, tp);
            }
            bool f = true;
            ChYM2610Rhythm(screen, 0, ref f, false, tp);
        }

        public static void screenInitYM2612(FrameBuffer screen, int tp, bool onlyPCM,bool isXGM)
        {
            if (screen == null) return;

            for (int y = 0; y < 9; y++)
            {

                int d = 99;
//                bool YM2612type = chipID==0 ? parent.setting.YM2612Type.UseScci : setting.YM2612SType.UseScci;
                int tp6 = tp;
                if (tp6 == 1 && onlyPCM)
                {
                    //tp6 = 0;
                }

                //note
                drawFont8(screen, 296, y * 8 + 8, 1, "   ");

                //keyboard
                for (int i = 0; i < 96; i++)
                {
                    int kx = kbl[(i % 12) * 2] + i / 12 * 28;
                    int kt = kbl[(i % 12) * 2 + 1];
                    if (y != 5)
                    {
                        drawKbn(screen, 32 + kx, y * 8 + 8, kt, tp);
                    }
                    else
                    {
                        if(!isXGM) drawKbn(screen, 32 + kx, y * 8 + 8, kt, tp6);
                    }
                }

                if (isXGM)
                {
                    Ch6YM2612XGM_P(screen, 0, 48, 0, false, tp6);
                }

                if (y != 5)
                {
                    d = -1;
                    Volume(screen, y, 0, ref d, 0, tp);
                }

                if (y < 6)
                {
                    d = 99;
                    DrawBuff.Pan(screen, y, ref d, 3, ref d, tp);
                }

                if (y != 5)
                {
                    ChYM2612_P(screen, 0, y * 8 + 8, y, false, tp);
                }
                else
                {
                    Ch6YM2612_P(screen, 0, y * 8 + 8, 0, false, tp6);
                    d = -1;
                    Volume(screen, y, 0, ref d, 0, tp6);
                    d = -1;
                    DrawBuff.Pan(screen, y, ref d, 3, ref d, tp6);
                }

            }
        }

        public static void screenInitYM2612MIDI(FrameBuffer screen)
        {
            if (screen == null) return;

            for (int c = 0; c < 6; c++)
            {
                for (int n = 0; n < 10; n++)
                {
                    drawFont4V(screen, (c % 3) * 13 * 8 + 2 * 8 + n * 8, (c / 3) * 18 * 4 + 24 * 4, 0, "   ");
                }
            }
        }



        public static void Inst(FrameBuffer screen, int x, int y, int c, int[] oi, int[] ni)
        {
            int sx = (c % 3) * 8 * 13 + x * 8;
            int sy = (c / 3) * 8 * 6 + 8 * y;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 11; i++)
                {
                    if (oi[i + j * 11] != ni[i + j * 11])
                    {
                        drawFont4Int(screen, sx + i * 8 + (i > 5 ? 4 : 0), sy + j * 8, 0, (i == 5) ? 3 : 2, ni[i + j * 11]);
                        oi[i + j * 11] = ni[i + j * 11];
                    }
                }
            }

            if (oi[44] != ni[44])
            {
                drawFont4Int(screen, sx + 8 * 4, sy - 16, 0, 2, ni[44]);
                oi[44] = ni[44];
            }
            if (oi[45] != ni[45])
            {
                drawFont4Int(screen, sx + 8 * 6, sy - 16, 0, 2, ni[45]);
                oi[45] = ni[45];
            }
            if (oi[46] != ni[46])
            {
                drawFont4Int(screen, sx + 8 * 8 + 4, sy - 16, 0, 2, ni[46]);
                oi[46] = ni[46];
            }
            if (oi[47] != ni[47])
            {
                drawFont4Int(screen, sx + 8 * 11, sy - 16, 0, 2, ni[47]);
                oi[47] = ni[47];
            }
        }

        public static void Inst(FrameBuffer screen, int x, int y, int c, int[] oi, int[] ni, int[] ot, int[] nt)
        {
            int sx = (c % 3) * 8 * 13 + x * 8;
            int sy = (c / 3) * 8 * 6 + 8 * y;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 11; i++)
                {
                    if (oi[i + j * 11] != ni[i + j * 11] || ot[i + j * 11] != nt[i + j * 11])
                    {
                        drawFont4Int(screen, sx + i * 8 + (i > 5 ? 4 : 0), sy + j * 8, nt[i + j * 11], (i == 5) ? 3 : 2, ni[i + j * 11]);
                        oi[i + j * 11] = ni[i + j * 11];
                        ot[i + j * 11] = nt[i + j * 11];
                    }
                }
            }

            if (oi[44] != ni[44] || ot[44] != nt[44])
            {
                drawFont4Int(screen, sx + 8 * 4, sy - 16, nt[44], 2, ni[44]);
                oi[44] = ni[44];
                ot[44] = nt[44];
            }
            if (oi[45] != ni[45] || ot[45] != nt[45])
            {
                drawFont4Int(screen, sx + 8 * 6, sy - 16, nt[45], 2, ni[45]);
                oi[45] = ni[45];
                ot[45] = nt[45];
            }
            if (oi[46] != ni[46] || ot[46] != nt[46])
            {
                drawFont4Int(screen, sx + 8 * 8 + 4, sy - 16, nt[46], 2, ni[46]);
                oi[46] = ni[46];
                ot[46] = nt[46];
            }
            if (oi[47] != ni[47] || ot[47] != nt[47])
            {
                drawFont4Int(screen, sx + 8 * 11, sy - 16, nt[47], 2, ni[47]);
                oi[47] = ni[47];
                ot[47] = nt[47];
            }
        }

        public static void drawInstNumber(FrameBuffer screen, int x, int y, ref int oi, int ni)
        {
            if (oi != ni)
            {
                drawFont4Int(screen, x * 4, y * 4, 0, 2, ni);
                oi = ni;
            }
        }

        public static void Volume(FrameBuffer screen, int y, int c, ref int ov, int nv, int tp)
        {
            if (ov == nv) return;

            int t = 0;
            int sy = 0;
            if (c == 1 || c == 2) { t = 4; }
            if (c == 2) { sy = 4; }
            y = (y + 1) * 8;

            for (int i = 0; i <= 19; i++)
            {
                VolumeP(screen, 256 + i * 2, y + sy, (1 + t), tp);
            }

            for (int i = 0; i <= nv; i++)
            {
                VolumeP(screen, 256 + i * 2, y + sy, i > 17 ? (2 + t) : (0 + t), tp);
            }

            ov = nv;

        }

        public static void VolumeToC140(FrameBuffer screen, int y, int c, ref int ov, int nv)
        {
            if (ov == nv) return;

            int t = 0;
            int sy = 0;
            if (c == 1 || c == 2) { t = 4; }
            if (c == 2) { sy = 4; }
            y = (y + 1) * 8;

            for (int i = 0; i <= 19; i++)
            {
                VolumeP(screen, 256 + i * 2, y + sy, (1 + t), 0);
            }

            for (int i = 0; i <= nv; i++)
            {
                VolumeP(screen, 256 + i * 2, y + sy, i > 17 ? (2 + t) : (0 + t), 0);
            }

            ov = nv;

        }

        public static void VolumeToHuC6280(FrameBuffer screen, int y, int c, ref int ov, int nv)
        {
            if (ov == nv) return;

            int t = 0;
            int sy = 0;
            if (c == 1 || c == 2) { t = 4; }
            if (c == 2) { sy = 4; }
            y = (y + 1) * 8;

            for (int i = 0; i <= 19; i++)
            {
                VolumeP(screen, 256 + i * 2, y + sy, (1 + t), 0);
            }

            for (int i = 0; i <= nv; i++)
            {
                VolumeP(screen, 256 + i * 2, y + sy, i > 17 ? (2 + t) : (0 + t), 0);
            }

            ov = nv;

        }

        public static void VolumeLCDToMIDILCD(FrameBuffer screen, int MIDImodule, int x, int y, ref int oldValue1, int value1, ref int oldValue2, int value2)
        {
            if (oldValue1 == value1 && oldValue2 == value2) return;

            int s = 0;
            //for (int n = (Math.Min(oldValue1, value1) / 8); n < 16; n++)
            for (int n = 0; n < 16; n++)
            {
                s = (value1 / 8) < n ? 8 : 0;
                screen.drawByteArray(x, y - (n * 3), rMIDILCD[MIDImodule], 136, 8 * 16, s, 8, 2);
            }

            screen.drawByteArray(x, y - (value2 / 8 * 3), rMIDILCD[MIDImodule], 136, 8 * 16, 0, 8, 2);

            oldValue1 = value1;
            oldValue2 = value2;
        }

        public static void VolumeToMIDILCD(FrameBuffer screen, int MIDImodule, int x, int y, ref int oldValue, int value)
        {
            if (oldValue == value) return;

            int s = 0;
            for (int n = (Math.Min(oldValue, value) / 5); n < (Math.Max(oldValue, value) / 5) + 1; n++)
            {
                s = (value / 5) < n ? 2 : 0;
                screen.drawByteArray(n * 2 + x, y, rMIDILCD_Vol[MIDImodule], 32, 0 + (n > 23 ? 4 : 0) + s, 0, 2, 8);
            }

            oldValue = value;
        }

        public static void VolumeXY(FrameBuffer screen, int x, int y, int c, ref int ov, int nv, int tp)
        {
            if (ov == nv) return;

            int t = 0;
            int sy = 0;
            if (c == 1 || c == 2) { t = 4; }
            if (c == 2) { sy = 4; }

            y *= 4;
            x *= 4;

            for (int i = 0; i <= 19; i++)
            {
                VolumeP(screen, x + i * 2, y + sy, (1 + t), tp);
            }

            for (int i = 0; i <= nv; i++)
            {
                VolumeP(screen, x + i * 2, y + sy, i > 17 ? (2 + t) : (0 + t), tp);
            }

            ov = nv;

        }

        public static void VolumeYM2608Rhythm(FrameBuffer screen, int x, int c, ref int ov, int nv, int tp)
        {
            if (ov == nv) return;

            int t = 0;
            int sy = 0;
            if (c == 1 || c == 2) { t = 4; }
            if (c == 2) { sy = 4; }
            x = x * 4 * 13 + 8 * 2;

            for (int i = 0; i <= 19; i++)
            {
                VolumeP(screen, x + i * 2, sy + 8 * 14, (1 + t), tp);
            }

            for (int i = 0; i <= nv; i++)
            {
                VolumeP(screen, x + i * 2, sy + 8 * 14, i > 17 ? (2 + t) : (0 + t), tp);
            }

            ov = nv;

        }

        public static void VolumeYM2610Rhythm(FrameBuffer screen, int x, int c, ref int ov, int nv, int tp)
        {

            if (ov == nv) return;

            int t = 0;
            int sy = 0;
            if (c == 1 || c == 2) { t = 4; }
            if (c == 2) { sy = 4; }
            x = x * 4 * 13 + 8 * 2;

            for (int i = 0; i <= 19; i++)
            {
                VolumeP(screen, x + i * 2, sy + 8 * 13, (1 + t), tp);
            }

            for (int i = 0; i <= nv; i++)
            {
                VolumeP(screen, x + i * 2, sy + 8 * 13, i > 17 ? (2 + t) : (0 + t), tp);
            }

            ov = nv;

        }

        public static void KeyBoard(FrameBuffer screen, int y, ref int ot, int nt, int tp)
        {
            if (ot == nt) return;

            int kx = 0;
            int kt = 0;

            y = (y + 1) * 8;

            if (ot >= 0)
            {
                kx = kbl[(ot % 12) * 2] + ot / 12 * 28;
                kt = kbl[(ot % 12) * 2 + 1];
                drawKbn(screen, 32 + kx, y, kt, tp);
            }

            if (nt >= 0)
            {
                kx = kbl[(nt % 12) * 2] + nt / 12 * 28;
                kt = kbl[(nt % 12) * 2 + 1] + 4;
                drawKbn(screen, 32 + kx, y, kt, tp);
                drawFont8(screen, 296, y, 1, kbn[nt % 12]);
                if (nt / 12 < 8)
                {
                    drawFont8(screen, 312, y, 1, kbo[nt / 12]);
                }
            }
            else
            {
                drawFont8(screen, 296, y, 1, "   ");
            }

            ot = nt;
        }

        public static void KeyBoardToC140(FrameBuffer screen, int y, ref int ot, int nt)
        {
            if (ot == nt) return;

            int kx = 0;
            int kt = 0;

            y = (y + 1) * 8;

            if (ot >= 0)
            {
                kx = kbl[(ot % 12) * 2] + ot / 12 * 28;
                kt = kbl[(ot % 12) * 2 + 1];
                drawKbn(screen, 32 + kx, y, kt, 0);
            }

            if (nt >= 0)
            {
                kx = kbl[(nt % 12) * 2] + nt / 12 * 28;
                kt = kbl[(nt % 12) * 2 + 1] + 4;
                drawKbn(screen, 32 + kx, y, kt, 0);
                drawFont8(screen, 296, y, 1, kbn[nt % 12]);
                if (nt / 12 < 8)
                {
                    drawFont8(screen, 312, y, 1, kbo[nt / 12]);
                }
            }
            else
            {
                drawFont8(screen, 296, y, 1, "   ");
            }

            ot = nt;
        }

        public static void Pan(FrameBuffer screen, int c, ref int ot, int nt, ref int otp, int ntp)
        {

            if (ot == nt && otp == ntp)
            {
                return;
            }

            drawPanP(screen, 24, 8 + c * 8, nt, ntp);
            ot = nt;
            otp = ntp;
        }

        public static void PanType2(FrameBuffer screen, int c, ref int ot, int nt)
        {

            if (ot == nt)
            {
                return;
            }

            drawPanType2P(screen, 24, 8 + c * 8, nt);
            ot = nt;
        }

        public static void PanToOKIM6258(FrameBuffer screen, ref int ot, int nt, ref int otp, int ntp)
        {

            if (ot == nt && otp == ntp)
            {
                return;
            }

            drawPanP(screen, 24, 8, nt, ntp);
            ot = nt;
            otp = ntp;
        }

        public static void PanYM2608Rhythm(FrameBuffer screen, int c, ref int ot, int nt, ref int otp, int ntp)
        {

            if (ot == nt && otp == ntp)
            {
                return;
            }

            drawPanP(screen, c * 4 * 13 + 8, 8 * 14, nt, ntp);
            ot = nt;
            otp = ntp;
        }

        public static void PanYM2610Rhythm(FrameBuffer screen, int c, ref int ot, int nt, ref int otp, int ntp)
        {

            if (ot == nt && otp == ntp)
            {
                return;
            }

            drawPanP(screen, c * 4 * 13 + 8, 8 * 13, nt, ntp);
            ot = nt;
            otp = ntp;
        }



        public static void ChAY8910(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChAY8910_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void ChC140(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChC140_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void ChHuC6280(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChHuC6280_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void ChRF5C164(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChRF5C164_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void ChOKIM6258(FrameBuffer screen, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChOKIM6258_P(screen, 0, 8 + 0 * 8, nm, tp);
            om = nm;
        }

        public static void ChSegaPCM(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChSegaPCM_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void ChSN76489(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChSN76489_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void ChSN76489Noise(FrameBuffer screen, ref MDChipParams.Channel osc, MDChipParams.Channel nsc, int tp)
        {
            if (osc.note == nsc.note) return;

            drawFont4(screen, 56, 32, tp, (nsc.note & 0x4) != 0 ? "WHITE   " : "PERIODIC");
            drawFont4(screen, 120, 32, tp, (nsc.note & 0x3) == 0 ? "0  " : ((nsc.note & 0x3) == 1 ? "1  " : ((nsc.note & 0x3) == 2 ? "2  " : "CH3")));

            osc.note = nsc.note;
        }

        public static void ChYM2151(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChYM2151_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void ChYM2203(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChYM2203_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void ChYM2413(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChYM2413_P(screen, 0, ch < 9 ? (8 + ch * 8) : (8 + 9 * 8), ch, nm, tp);
            om = nm;
        }

        public static void ChYM2608(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChYM2608_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void ChYM2608Rhythm(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChYM2608Rhythm_P(screen, 0, 8 * 14, ch, nm, tp);
            om = nm;
        }

        public static void ChYM2610(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChYM2610_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void ChYM2610Rhythm(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChYM2610Rhythm_P(screen, 0, 8 * 13, ch, nm, tp);
            om = nm;
        }

        public static void ChYM2612(FrameBuffer screen, int ch, ref bool om, bool nm, int tp)
        {

            if (om == nm)
            {
                return;
            }

            ChYM2612_P(screen, 0, 8 + ch * 8, ch, nm, tp);
            om = nm;
        }

        public static void Ch6YM2612(FrameBuffer screen, ref int ot, int nt, ref bool om, bool nm, ref int otp, int ntp)
        {

            if (ot == nt && om == nm && otp == ntp)
            {
                return;
            }

            Ch6YM2612_P(screen, 0, 48, nt, nm, ntp);
            ot = nt;
            om = nm;
            otp = ntp;
        }

        public static void Ch6YM2612XGM(FrameBuffer screen,int buff, ref int ot, int nt, ref bool om, bool nm, ref int otp, int ntp)
        {
            if (buff == 0)
            {
                if (ot == nt && om == nm && otp == ntp)
                {
                    return;
                }
            }

            Ch6YM2612XGM_P(screen, 0, 48, nt, nm, ntp);
            ot = nt;
            om = nm;
            otp = ntp;
        }




        public static void ToneNoise(FrameBuffer screen, int x, int y, int c, ref int ot, int nt, ref int otp, int ntp)
        {

            if (ot == nt && otp == ntp)
            {
                return;
            }

            ToneNoiseP(screen, x * 4, y * 4 + c * 8, nt, ntp);
            ot = nt;
            otp = ntp;
        }

        public static void Nfrq(FrameBuffer screen, int x, int y, ref int onfrq, int nnfrq)
        {
            if (onfrq == nnfrq)
            {
                return;
            }

            x *= 4;
            y *= 4;
            drawFont4Int(screen, x, y, 0, 2, nnfrq);

            onfrq = nnfrq;
        }

        public static void Efrq(FrameBuffer screen, int x, int y, ref int oefrq, int nefrq)
        {
            if (oefrq == nefrq)
            {
                return;
            }

            x *= 4;
            y *= 4;
            drawFont4(screen, x, y, 0, string.Format("{0:D5}", nefrq));

            oefrq = nefrq;
        }

        public static void Etype(FrameBuffer screen, int x, int y, ref int oetype, int netype)
        {
            if (oetype == netype)
            {
                return;
            }

            x *= 4;
            y *= 4;

            drawEtypeP(screen, x, y, netype);
            oetype = netype;
        }

        public static void WaveFormToHuC6280(FrameBuffer screen, int c, ref int[] oi, int[] ni)
        {
            for (int i = 0; i < 32; i++)
            {
                if (oi[i] == ni[i]) continue;

                int n = (17 - ni[i]);
                int x = i + (((c > 2) ? c - 3 : c) * 8 * 13) + 4 * 7;
                int y = (((c > 2) ? 1 : 0) * 8 * 5) + 4 * 22;

                int m = 0;
                m = (n > 7) ? 8 : n;
                screen.drawByteArray(x, y, rWavGraph, 64, m, 0, 1, 8);
                m = (n > 15) ? 8 : ((n - 8) < 0 ? 0 : (n - 8));
                screen.drawByteArray(x, y - 8, rWavGraph, 64, m, 0, 1, 8);
                m = (n > 23) ? 8 : ((n - 16) < 0 ? 0 : (n - 16));
                screen.drawByteArray(x, y - 16, rWavGraph, 64, m, 0, 1, 8);
                m = (n > 31) ? 8 : ((n - 24) < 0 ? 0 : (n - 24));
                screen.drawByteArray(x, y - 23, rWavGraph, 64, m + 1, 0, 1, 7);

                oi[i] = ni[i];
            }
        }

        public static void DDAToHuC6280(FrameBuffer screen, int c, ref bool od, bool nd)
        {
            if (od == nd) return;

            int x = (((c > 2) ? c - 3 : c) * 8 * 13) + 4 * 22;
            int y = (((c > 2) ? 1 : 0) * 8 * 5) + 4 * 18;

            drawFont4(screen, x, y, 0, nd ? "ON " : "OFF");
            od = nd;
        }

        public static void NoiseToHuC6280(FrameBuffer screen, int c, ref bool od, bool nd)
        {
            if (od == nd) return;

            int x = (((c > 2) ? c - 3 : c) * 8 * 13) + 4 * 22;
            int y = (((c > 2) ? 1 : 0) * 8 * 5) + 4 * 20;

            drawFont4(screen, x, y, 0, nd ? "ON " : "OFF");
            od = nd;
        }

        public static void NoiseFrqToHuC6280(FrameBuffer screen, int c, ref int od, int nd)
        {
            if (od == nd) return;

            int x = (((c > 2) ? c - 3 : c) * 8 * 13) + 4 * 22;
            int y = (((c > 2) ? 1 : 0) * 8 * 5) + 4 * 22;

            drawFont4(screen, x, y, 0, string.Format("{0:d2}", nd));
            od = nd;
        }

        public static void MainVolumeToHuC6280(FrameBuffer screen, int c, ref int od, int nd)
        {
            if (od == nd) return;

            int x = 8 * 9;
            int y = c * 8 + 8 * 17;

            drawFont4(screen, x, y, 0, string.Format("{0:d2}", nd));
            od = nd;
        }

        public static void LfoCtrlToHuC6280(FrameBuffer screen, ref int od, int nd)
        {
            if (od == nd) return;

            int x = 8 * 17;
            int y = 8 * 17;

            drawFont4(screen, x, y, 0, string.Format("{0:d1}", nd));
            od = nd;
        }

        public static void LfoFrqToHuC6280(FrameBuffer screen, ref int od, int nd)
        {
            if (od == nd) return;

            int x = 8 * 16;
            int y = 8 * 18;

            drawFont4(screen, x, y, 0, string.Format("{0:d3}", nd));
            od = nd;
        }

        public static void drawMIDILCD_Fader(FrameBuffer screen, int MIDImodule, int faderType, int x, int y, ref byte oldValue, byte value)
        {
            if (oldValue == value) return;
            oldValue = value;

            int v;
            switch (faderType)
            {
                case 0:
                    v = Math.Max(value - 8, 0) / 8;
                    drawMIDILCD_FaderP(screen, MIDImodule, 0, x, y, v);
                    break;
                case 1:
                    v = value / 8;
                    drawMIDILCD_FaderP(screen, MIDImodule, 1, x, y, v);
                    break;
            }

        }

        public static void drawMIDILCD_Fader(FrameBuffer screen, int MIDImodule, int faderType, int x, int y, ref short oldValue, short value)
        {
            if (oldValue == value) return;
            oldValue = value;

            int v;
            switch (faderType)
            {
                case 0:
                    v = Math.Max(value - 0x1ff, 0) / 0x3ff;
                    drawMIDILCD_FaderP(screen, MIDImodule, 0, x, y, v);
                    break;
                case 1:
                    break;
            }
        }

        public static void drawMIDILCD_Kbd(FrameBuffer screen, int x, int y, int note, ref byte oldVel, byte vel)
        {
            if (oldVel == vel) return;
            oldVel = vel;

            drawMIDILCD_KbdP(screen, x, y, note, vel);
        }

        public static void drawFont4MIDINotes(FrameBuffer screen, int x, int y, int t, ref string oldnotes, string notes)
        {
            if (oldnotes == notes) return;
            oldnotes = notes;

            if (screen == null) return;

            drawFont4(screen, x, y, t, notes);

            return;
        }

        public static void drawMIDI_Lyric(FrameBuffer screen,int chipID, int x, int y, ref string oldValue1, string value1)
        {
            //if (oldValue1 == value1) return;

            gMIDILyric[chipID].Clear(Color.Black);
            System.Windows.Forms.TextRenderer.DrawText(gMIDILyric[chipID], value1, fntMIDILyric[chipID], new Point(0, 0), Color.White);
            byte[] bit = getByteArray(bitmapMIDILyric[chipID]);
            screen.drawByteArray(x, y, bit, 232, 0, 0, 232, 24);

            oldValue1 = value1;
        }

        public static void drawMIDI_MacroXG(FrameBuffer screen, int MIDImodule, int macroType, int x, int y, ref int oldValue1, int value1)
        {
            //if (oldValue1 == value1) return;

            drawFont4(screen, x, y, 2 + MIDImodule, tblMIDIEffectXG[macroType][value1]);

            oldValue1 = value1;
        }

        public static void drawMIDI_MacroGS(FrameBuffer screen, int MIDImodule, int macroType, int x, int y, ref int oldValue1, int value1)
        {
            //if (oldValue1 == value1) return;

            drawFont4(screen, x, y, 2 + MIDImodule, tblMIDIEffectGS[macroType][value1]);

            oldValue1 = value1;
        }

        public static void drawMIDILCD_Letter(FrameBuffer screen, int MIDImodule, int x, int y, ref byte[] oldValue, int len)
        {
            for (int i = 0; i < 16; i++)
            {
                if (oldValue[i] == spc[i]) continue;
                oldValue[i] = spc[i];

                if (screen == null) return;

                int cd = 0;
                //if (i < len) 
                cd = spc[i] - ' ';

                screen.drawByteArray(x + i * 8, y, rMIDILCD_Font[MIDImodule], 128, (cd % 16) * 8, (cd / 16) * 8, 8, 8);
            }

        }

        public static void drawMIDILCD_Letter(FrameBuffer screen, int MIDImodule, int x, int y, ref byte[] oldValue, byte[] value, int len)
        {
            for (int i = 0; i < 16; i++)
            {
                if (oldValue[i] == value[i]) continue;
                oldValue[i] = value[i];

                if (screen == null) return;

                int cd = 0;
                //if (i < len) 
                cd = value[i] - ' ';

                screen.drawByteArray(x + i * 8, y, rMIDILCD_Font[MIDImodule], 128, (cd % 16) * 8, (cd / 16) * 8, 8, 8);
            }

        }

        public static void drawFont4IntMIDI(FrameBuffer screen, int x, int y, int t, ref byte oldnum, byte num)
        {
            if (oldnum == num) return;
            oldnum = num;

            if (screen == null) return;

            int n;

            n = num / 100;
            num -= (byte)(n * 100);
            //n = (n > 9) ? 0 : n;
            screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);

            n = num / 10;
            num -= (byte)(n * 10);
            x += 4;
            screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);

            n = num / 1;
            x += 4;
            screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);

            return;
        }

        public static void drawFont4IntMIDIInstrument(FrameBuffer screen, int x, int y, int t, ref byte oldnum, byte num)
        {
            if (oldnum == num) return;
            oldnum = num;

            if (screen == null) return;

            drawFont4(screen, x, y + 8, t, tblMIDIInstrumentGM[num]);

            int n;

            n = num / 100;
            num -= (byte)(n * 100);
            //n = (n > 9) ? 0 : n;
            screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);

            n = num / 10;
            num -= (byte)(n * 10);
            x += 4;
            screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);

            n = num / 1;
            x += 4;
            screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);

            return;
        }

        public static void drawFader(FrameBuffer screen, int x, int y, int t, ref int od, int nd)
        {
            if (od == nd) return;

            drawFaderSlitP(screen, x, y - 8);
            drawFont4IntM(screen, x, y + 48, 3, nd);

            int n = 0;

            if (nd >= 0)
            {
                n = -(int)(nd / 20.0 * 8.0);
            }
            else
            {
                n = -(int)(nd / 192.0 * 35.0);
            }

            y += n;

            drawFaderP(screen, x, y, t);

            od = nd;
        }

        public static void MixerVolume(FrameBuffer screen, int x, int y, ref int od, int nd, ref int ov, int nv)
        {
            if (od == nd && ov == nv) return;

            for (int i = 0; i < 44; i++)
            {
                int t = i < 8 ? 0 : 1;
                if (i % 2 != 0) t = 2;
                else if (44 - i > nd) t = 2;

                drawMixerVolumeP(screen, x, y + i, t);
            }

            drawMixerVolumeP(screen, x, y + (44 - nv), nv > 36 ? 0 : 1);

            od = nd;
            ov = nv;
        }

        public static void KfYM2151(FrameBuffer screen, int ch, ref int ok, int nk)
        {
            if (ok == nk)
            {
                return;
            }

            int x = (ch % 4) * 4 * 3 + 4 * 67;
            int y = (ch / 4) * 8 + 8 * 22;
            drawFont4Int(screen, x, y, 0, 2, nk);
            ok = nk;
        }

        public static void NeYM2151(FrameBuffer screen, ref int one, int nne)
        {
            if (one == nne)
            {
                return;
            }

            int x = 4 * 60;
            int y = 8 * 22;
            drawFont4Int(screen, x, y, 0, 1, nne);

            one = nne;
        }

        public static void NfrqYM2151(FrameBuffer screen, ref int onfrq, int nnfrq)
        {
            if (onfrq == nnfrq)
            {
                return;
            }

            int x = 4 * 60;
            int y = 8 * 23;
            drawFont4Int(screen, x, y, 0, 2, nnfrq);

            onfrq = nnfrq;
        }

        public static void LfrqYM2151(FrameBuffer screen, ref int olfrq, int nlfrq)
        {
            if (olfrq == nlfrq)
            {
                return;
            }

            int x = 4 * 59;
            int y = 8 * 24;
            drawFont4Int(screen, x, y, 0, 3, nlfrq);

            olfrq = nlfrq;
        }

        public static void AmdYM2151(FrameBuffer screen, ref int oamd, int namd)
        {
            if (oamd == namd)
            {
                return;
            }

            int x = 4 * 59;
            int y = 8 * 26;
            drawFont4Int(screen, x, y, 0, 3, namd);

            oamd = namd;
        }

        public static void PmdYM2151(FrameBuffer screen, ref int opmd, int npmd)
        {
            if (opmd == npmd)
            {
                return;
            }

            int x = 4 * 59;
            int y = 8 * 25;
            drawFont4Int(screen, x, y, 0, 3, npmd);

            opmd = npmd;
        }

        public static void WaveFormYM2151(FrameBuffer screen, ref int owaveform, int nwaveform)
        {
            if (owaveform == nwaveform)
            {
                return;
            }

            int x = 4 * 68;
            int y = 8 * 24;
            drawFont4Int(screen, x, y, 0, 1, nwaveform);

            owaveform = nwaveform;
        }

        public static void LfoSyncYM2151(FrameBuffer screen, ref int olfosync, int nlfosync)
        {
            if (olfosync == nlfosync)
            {
                return;
            }

            int x = 4 * 68;
            int y = 8 * 25;
            drawFont4Int(screen, x, y, 0, 1, nlfosync);

            olfosync = nlfosync;
        }

        public static void Tn(FrameBuffer screen, int x, int y, int c, ref int ot, int nt, ref int otp, int ntp)
        {

            if (ot == nt && otp == ntp)
            {
                return;
            }

            drawTnP(screen, x * 4, y * 4 + c * 8, nt, ntp);
            ot = nt;
            otp = ntp;
        }

        public static void SUSFlag(FrameBuffer screen, int x, int y, ref int oi, int ni)
        {
            if (oi != ni)
            {
                drawFont4(screen, x * 4, y * 4, 0, ni == 0 ? "-" : "*");
                oi = ni;
            }
        }

        public static void LfoSw(FrameBuffer screen, int x, int y, ref bool olfosw, bool nlfosw)
        {
            if (olfosw == nlfosw)
            {
                return;
            }

            x *= 4;
            y *= 4;
            drawFont4(screen, x, y, 0, nlfosw ? "ON " : "OFF");

            olfosw = nlfosw;
        }

        public static void LfoFrq(FrameBuffer screen, int x, int y, ref int olfofrq, int nlfofrq)
        {
            if (olfofrq == nlfofrq)
            {
                return;
            }

            x *= 4;
            y *= 4;
            drawFont4Int(screen, x, y, 0, 1, nlfofrq);

            olfofrq = nlfofrq;
        }

        public static void NoteLogYM2612MIDI(FrameBuffer screen, int x, int y, ref int oln, int nln)
        {
            if (oln == nln) return;
            if (nln == -1)
            {
                drawFont4V(screen, x, y, 0, "   ");
            }
            else
            {
                drawFont4V(screen, x, y, 0, kbnp[nln % 12]);
                drawFont4V(screen, x, y - 2 * 4, 0, kbo[nln / 12]);
            }
            oln = nln;
        }

        public static void UseChannelYM2612MIDI(FrameBuffer screen, int x, int y, ref bool olm, bool nlm)
        {
            //if (olm == nlm) return;

            drawFont8(screen, x, y, 1, nlm ? "^" : "-");

            olm = nlm;
        }

        public static void MONOPOLYYM2612MIDI(FrameBuffer screen, ref bool olm, bool nlm)
        {
            if (olm == nlm) return;

            drawFont8(screen, 8, 16, 1, nlm ? "^" : "-");
            drawFont8(screen, 8, 24, 1, nlm ? "-" : "^");

            olm = nlm;
        }

        public static void ToneFormat(FrameBuffer screen, int x, int y, ref int oToneFormat, int nToneFormat)
        {
            if (oToneFormat == nToneFormat)
            {
                return;
            }

            x *= 4;
            y *= 4;

            drawToneFormatP(screen, x, y, nToneFormat);

            oToneFormat = nToneFormat;
        }

        public static void drawChipName(FrameBuffer screen, int x, int y, int t, ref byte oc, byte nc)
        {
            if (oc == nc) return;

            drawChipNameP(screen, x, y, t, nc);

            oc = nc;
        }

        public static void drawTimer(FrameBuffer screen, int c, ref int ot1, ref int ot2, ref int ot3, int nt1, int nt2, int nt3)
        {
            if (ot1 != nt1)
            {
                //drawFont4Int2(mainScreen, 4 * 30 + c * 4 * 11, 0, 0, 3, nt1);
                DrawBuff.drawFont8Int2(screen, 8 * 3 + c * 8 * 11, 16, 0, 3, nt1);
                ot1 = nt1;
            }
            if (ot2 != nt2)
            {
                DrawBuff.drawFont8Int2(screen, 8 * 7 + c * 8 * 11, 16, 0, 2, nt2);
                //drawFont4Int2(mainScreen, 4 * 34 + c * 4 * 11, 0, 0, 2, nt2);
                ot2 = nt2;
            }
            if (ot3 != nt3)
            {
                DrawBuff.drawFont8Int2(screen, 8 * 10 + c * 8 * 11, 16, 0, 2, nt3);
                //drawFont4Int2(mainScreen, 4 * 37 + c * 4 * 11, 0, 0, 2, nt3);
                ot3 = nt3;
            }
        }

        public static void drawButtonP(FrameBuffer mainScreen, int x, int y, int t, int m)
        {
            if (mainScreen == null) return;

            int n = t % 18;
            t /= 18;
            switch (n)
            {
                case 0:
                    //setting
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 5 * 16, 1 * 16, 16, 16);
                    break;
                case 1:
                    //stop
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 0 * 16, 0 * 16, 16, 16);
                    break;
                case 2:
                    //pause
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 1 * 16, 0 * 16, 16, 16);
                    break;
                case 3:
                    //fadeout
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 4 * 16, 1 * 16, 16, 16);
                    break;
                case 4:
                    //PREV
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 6 * 16, 1 * 16, 16, 16);
                    break;
                case 5:
                    //slow
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 2 * 16, 0 * 16, 16, 16);
                    break;
                case 6:
                    //play
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 3 * 16, 0 * 16, 16, 16);
                    break;
                case 7:
                    //fast
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 4 * 16, 0 * 16, 16, 16);
                    break;
                case 8:
                    //NEXT
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 7 * 16, 1 * 16, 16, 16);
                    break;
                case 9:
                    //loopmode
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 1 * 16 + m * 16, 2 * 16, 16, 16);
                    break;
                case 10:
                    //folder
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 5 * 16, 0 * 16, 16, 16);
                    break;
                case 11:
                    //List
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 0 * 16, 2 * 16, 16, 16);
                    break;
                case 12:
                    //info
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 0 * 16, 1 * 16, 16, 16);
                    break;
                case 13:
                    //mixer
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 2 * 16, 1 * 16, 16, 16);
                    break;
                case 14:
                    //panel
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 5 * 16, 2 * 16, 16, 16);
                    break;
                case 15:
                    //VST List
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 7 * 16, 0 * 16, 16, 16);
                    break;
                case 16:
                    //MIDI Keyboard
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 3 * 16, 1 * 16, 16, 16);
                    break;
                case 17:
                    //zoom
                    mainScreen.drawByteArray(x, y, rMenuButtons[t], 128, 6 * 16, 2 * 16, 16, 16);
                    break;
            }
        }

        public static void drawButton(FrameBuffer mainScreen,int c, ref int ot, int nt, ref int om, int nm)
        {
            if (ot == nt && om == nm)
            {
                return;
            }

            drawFont8(mainScreen, 32 + c * 16, 24, 0, "  ");
            drawFont8(mainScreen, 32 + c * 16, 32, 0, "  ");
            drawButtonP(mainScreen,32 + c * 16, 24, nt * 18 + c, nm);

            ot = nt;
            om = nm;
        }

        public static void drawButtons(FrameBuffer mainScreen, int[] oldButton, int[] newButton, int[] oldButtonMode, int[] newButtonMode)
        {

            for (int i = 0; i < newButton.Length; i++)
            {
                drawButton(mainScreen, i, ref oldButton[i], newButton[i], ref oldButtonMode[i], newButtonMode[i]);
            }

        }







        private static byte[] getByteArray(Image img)
        {
            Bitmap bitmap = new Bitmap(img);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            byte[] byteArray = new byte[bitmapData.Stride * bitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, byteArray, 0, byteArray.Length);
            bitmap.UnlockBits(bitmapData);
            bitmap.Dispose();

            return byteArray;
        }

        private static void VolumeP(FrameBuffer screen, int x, int y, int t, int tp)
        {
            if (screen == null) return;
            screen.drawByteArray(x, y, rVol[tp], 32, 2 * t, 0, 2, 8 - (t / 4) * 4);
        }

        private static void drawKbn(FrameBuffer screen, int x, int y, int t, int tp)
        {
            if (screen == null)
            {
                return;
            }

            switch (t)
            {
                case 0:
                    screen.drawByteArray(x, y, rKBD[tp], 32, 0, 0, 4, 8);
                    break;
                case 1:
                    screen.drawByteArray(x, y, rKBD[tp], 32, 4, 0, 3, 8);
                    break;
                case 2:
                    screen.drawByteArray(x, y, rKBD[tp], 32, 8, 0, 4, 8);
                    break;
                case 3:
                    screen.drawByteArray(x, y, rKBD[tp], 32, 12, 0, 4, 8);
                    break;
                case 4:
                    screen.drawByteArray(x, y, rKBD[tp], 32, 0 + 16, 0, 4, 8);
                    break;
                case 5:
                    screen.drawByteArray(x, y, rKBD[tp], 32, 4 + 16, 0, 3, 8);
                    break;
                case 6:
                    screen.drawByteArray(x, y, rKBD[tp], 32, 8 + 16, 0, 4, 8);
                    break;
                case 7:
                    screen.drawByteArray(x, y, rKBD[tp], 32, 12 + 16, 0, 4, 8);
                    break;
            }
        }

        private static void ToneNoiseP(FrameBuffer screen, int x, int y, int t, int tp)
        {
            if (screen == null) return;
            screen.drawByteArray(x, y, rPSGMode[tp], 32, 8 * t, 0, 8, 8);
        }

        public static void drawFont8(FrameBuffer screen, int x, int y, int t, string msg)
        {
            if (screen == null)
            {
                return;
            }

            foreach (char c in msg)
            {
                int cd = c - 'A' + 0x20 + 1;
                screen.drawByteArray(x, y, rFont1[t], 128, (cd % 16) * 8, (cd / 16) * 8, 8, 8);
                x += 8;
            }
        }

        public static void drawFont8Int(FrameBuffer screen, int x, int y, int t, int k, int num)
        {
            if (screen == null) return;

            int n;
            if (k == 3)
            {
                bool f = false;
                n = num / 100;
                num -= n * 100;
                n = (n > 9) ? 0 : n;
                if (n != 0)
                {
                    screen.drawByteArray(x, y, rFont1[t], 128, n * 8, 8, 8, 8);
                    if (n != 0) { f = true; }
                }
                else
                {
                    screen.drawByteArray(x, y, rFont1[t], 128, 0, 0, 8, 8);
                }

                n = num / 10;
                num -= n * 10;
                x += 8;
                if (n != 0 || f)
                {
                    screen.drawByteArray(x, y, rFont1[t], 128, n * 8, 8, 8, 8);
                    if (n != 0) { f = true; }
                }
                else
                {
                    screen.drawByteArray(x, y, rFont1[t], 128, 0, 0, 8, 8);
                }

                n = num / 1;
                num -= n * 1;
                x += 8;
                screen.drawByteArray(x, y, rFont1[t], 128, n * 8, 8, 8, 8);
                return;
            }

            n = num / 10;
            num -= n * 10;
            n = (n > 9) ? 0 : n;
            if (n != 0)
            {
                screen.drawByteArray(x, y, rFont1[t], 128, n * 8, 8, 8, 8);
            }
            else
            {
                screen.drawByteArray(x, y, rFont1[t], 128, 0, 0, 8, 8);
            }

            n = num / 1;
            num -= n * 1;
            x += 8;
            screen.drawByteArray(x, y, rFont1[t], 128, n * 8, 8, 8, 8);
        }

        public static void drawFont8Int2(FrameBuffer screen, int x, int y, int t, int k, int num)
        {
            if (screen == null) return;

            int n;
            if (k == 3)
            {
                n = num / 100;
                num -= n * 100;

                n = (n > 9) ? 0 : n;
                if (n == 0) screen.drawByteArray(x, y, rFont1[t], 128, 0, 0, 8, 8);
                else screen.drawByteArray(x, y, rFont1[t], 128, 0, 8, 8, 8);

                n = num / 10;
                num -= n * 10;
                x += 8;
                screen.drawByteArray(x, y, rFont1[t], 128, n * 8, 8, 8, 8);

                n = num / 1;
                x += 8;
                screen.drawByteArray(x, y, rFont1[t], 128, n * 8, 8, 8, 8);
                return;
            }

            n = num / 10;
            num -= n * 10;
            n = (n > 9) ? 0 : n;
            screen.drawByteArray(x, y, rFont1[t], 128, n * 8, 8, 8, 8);

            n = num / 1;
            x += 8;
            screen.drawByteArray(x, y, rFont1[t], 128, n * 8, 8, 8, 8);
        }

        public static void drawFont4(FrameBuffer screen, int x, int y, int t, string msg)
        {
            if (screen == null) return;

            foreach (char c in msg)
            {
                int cd = c - 'A' + 0x20 + 1;
                screen.drawByteArray(x, y, rFont2[t], 128, (cd % 32) * 4, (cd / 32) * 8, 4, 8);
                x += 4;
            }
        }

        private static void drawFont4Int(FrameBuffer screen, int x, int y, int t, int k, int num)
        {
            if (screen == null) return;

            int n;
            if (k == 3)
            {
                bool f = false;
                n = num / 100;
                num -= n * 100;
                n = (n > 9) ? 0 : n;
                if (n != 0)
                {
                    screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);
                    if (n != 0) { f = true; }
                }
                else
                {
                    screen.drawByteArray(x, y, rFont2[t], 128, 0, 0, 4, 8);
                }

                n = num / 10;
                num -= n * 10;
                x += 4;
                if (n != 0 || f)
                {
                    screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);
                    if (n != 0) { f = true; }
                }
                else
                {
                    screen.drawByteArray(x, y, rFont2[t], 128, 0, 0, 4, 8);
                }

                n = num / 1;
                x += 4;
                screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);
                return;
            }

            n = num / 10;
            num -= n * 10;
            n = (n > 9) ? 0 : n;
            if (n != 0)
            {
                screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);
            }
            else
            {
                screen.drawByteArray(x, y, rFont2[t], 128, 0, 0, 4, 8);
            }

            n = num / 1;
            x += 4;
            screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);
        }

        private static void drawFont4IntM(FrameBuffer screen, int x, int y, int k, int num)
        {
            if (screen == null) return;

            int t = 0;
            int n;

            if (num < 0)
            {
                num = -num;
                screen.drawByteArray(x - 4, y, rFont2[t], 128, 52, 1, 4, 7);
            }
            else
            {
                if (num != 0) t = 1;
                screen.drawByteArray(x - 4, y, rFont2[t], 128, 24, 1, 4, 7);
            }

            if (k == 3)
            {
                bool f = false;
                n = num / 100;
                num -= n * 100;
                n = (n > 9) ? 0 : n;
                if (n != 0)
                {
                    screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 1, 4, 7);
                    if (n != 0) { f = true; }
                }
                else
                {
                    screen.drawByteArray(x, y, rFont2[t], 128, 0, 1, 4, 7);
                }

                n = num / 10;
                num -= n * 10;
                x += 4;
                if (n != 0 || f)
                {
                    screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 1, 4, 7);
                    if (n != 0) { f = true; }
                }
                else
                {
                    screen.drawByteArray(x, y, rFont2[t], 128, 0, 1, 4, 7);
                }

                n = num / 1;
                x += 4;
                screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 1, 4, 7);
                return;
            }

            n = num / 10;
            num -= n * 10;
            n = (n > 9) ? 0 : n;
            if (n != 0)
            {
                screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 1, 4, 7);
            }
            else
            {
                screen.drawByteArray(x, y, rFont2[t], 128, 0, 1, 4, 7);
            }

            n = num / 1;
            x += 4;
            screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 1, 4, 7);
        }

        public static void drawFont4Int2(FrameBuffer screen, int x, int y, int t, int k, int num)
        {
            if (screen == null) return;

            int n;
            if (k == 3)
            {
                n = num / 100;
                num -= n * 100;
                n = (n > 9) ? 0 : n;
                screen.drawByteArray(x, y, rFont2[t], 128, 0, 0, 4, 8);

                n = num / 10;
                num -= n * 10;
                x += 4;
                screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);

                n = num / 1;
                x += 4;
                screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);
                return;
            }

            n = num / 10;
            num -= n * 10;
            n = (n > 9) ? 0 : n;
            screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);

            n = num / 1;
            x += 4;
            screen.drawByteArray(x, y, rFont2[t], 128, n * 4 + 64, 0, 4, 8);
        }

        private static void drawFont4V(FrameBuffer screen, int x, int y, int t, string msg)
        {
            if (screen == null) return;

            foreach (char c in msg)
            {
                int cd = c - 'A' + 0x20 + 1;
                screen.drawByteArray(x, y, rFont3[t], 128, (cd % 16) * 8, (cd / 16) * 4, 8, 4);
                y -= 4;
            }
        }

        private static void drawEtypeP(FrameBuffer screen, int x, int y, int t)
        {
            if (screen == null) return;
            screen.drawByteArray(x, y, rPSGEnv, 64, 8 * t, 0, 8, 8);
        }

        private static void drawPanP(FrameBuffer screen, int x, int y, int t, int tp)
        {
            if (screen == null) return;
            screen.drawByteArray(x, y, rPan[tp], 32, 8 * t, 0, 8, 8);
        }

        private static void drawPanType2P(FrameBuffer screen, int x, int y, int t)
        {
            if (screen == null)
            {
                return;
            }

            int p = (t & 0x0f);
            p = p == 0 ? 0 : (1 + p / 4);
            screen.drawByteArray(x, y, rPan2[0], 32, p * 4, 0, 4, 8);
            p = ((t & 0xf0) >> 4);
            p = p == 0 ? 0 : (1 + p / 4);
            screen.drawByteArray(x + 4, y, rPan2[0], 32, p * 4, 0, 4, 8);

        }

        private static void drawMIDILCD_FaderP(FrameBuffer screen, int MIDImodule, int faderType, int x, int y, int value)
        {
            screen.drawByteArray(x, y, rMIDILCD_Fader[MIDImodule], 64, value * 4, faderType * 16, 4, 16);
        }

        private static void drawMIDILCD_KbdP(FrameBuffer screen, int x, int y, int note, int vel)
        {
            screen.drawByteArrayTransp(x + kbdl[note % 12] + note / 12 * 28, y, rMIDILCD_KBD, 16, kbl2[note % 12], vel / 16 * 8, 4, 8);
        }

        private static void ChAY8910_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 32, 0, 16, 8);
            drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
        }

        private static void ChC140_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 16, 0, 16, 8);
            if (ch < 9) drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
            else drawFont4(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
        }

        private static void ChHuC6280_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 0, 14 * 8, 16, 8);
            drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
        }

        private static void ChRF5C164_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 16, 0, 16, 8);
            drawFont8(screen, x + 16, y, mask ? 1 : 0, (ch + 1).ToString());
        }

        private static void ChOKIM6258_P(FrameBuffer screen, int x, int y, bool mask, int tp)
        {
            if (screen == null) return;

            screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 8 * 8, 0, 24, 8);
        }

        private static void ChSegaPCM_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 16, 0, 16, 8);
            if (ch < 9) drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
            else drawFont4(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
        }

        private static void ChSN76489_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 32, 0, 16, 8);
            drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
        }

        private static void ChYM2151_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 0, 0, 16, 8);
            drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
        }

        private static void ChYM2203_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            if (ch < 3)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 0, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
            }
            else if (ch < 6)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 32, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch - 3).ToString());
            }
            else if (ch < 9)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 48, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch - 6).ToString());
            }
            else
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 0, 0, 24, 8);
            }
        }

        private static void ChYM2413_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            if (ch < 9)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 0, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
            }
            else
            {
                switch (ch)
                {
                    case 9:
                        drawFont4(screen, (ch - 9) * 4 * 15 + 4 * 4, y, mask ? 1 : 0, "BD");
                        break;
                    case 10:
                        drawFont4(screen, (ch - 9) * 4 * 15 + 4 * 4, y, mask ? 1 : 0, "SD");
                        break;
                    case 11:
                        drawFont4(screen, (ch - 9) * 4 * 15 + 4 * 4, y, mask ? 1 : 0, "TM");
                        break;
                    case 12:
                        drawFont4(screen, (ch - 9) * 4 * 15 + 3 * 4, y, mask ? 1 : 0, "CYM");// 3 character
                        break;
                    case 13:
                        drawFont4(screen, (ch - 9) * 4 * 15 + 4 * 4, y, mask ? 1 : 0, "HH");
                        break;
                }
            }
        }

        private static void ChYM2608_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            if (ch < 6)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 0, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
            }
            else if (ch < 9)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 32, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch - 6).ToString());
            }
            else if (ch < 12)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 48, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch - 9).ToString());
            }
            else
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 64, 0, 24, 8);
            }
        }

        private static void ChYM2608Rhythm_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            drawFont4(screen, x + 1 * 4, y, mask ? 1 : 0, "B");
            drawFont4(screen, x + 14 * 4, y, mask ? 1 : 0, "S");
            drawFont4(screen, x + 27 * 4, y, mask ? 1 : 0, "C");
            drawFont4(screen, x + 40 * 4, y, mask ? 1 : 0, "H");
            drawFont4(screen, x + 53 * 4, y, mask ? 1 : 0, "T");
            drawFont4(screen, x + 66 * 4, y, mask ? 1 : 0, "R");
        }

        private static void ChYM2610_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            if (ch < 6)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 0, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch).ToString());
            }
            else if (ch < 9)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 32, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch - 6).ToString());
            }
            else if (ch < 12)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 48, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (1 + ch - 9).ToString());
            }
            else
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 64, 32, 24, 8);
            }
        }

        private static void ChYM2610Rhythm_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (screen == null) return;

            drawFont4(screen, x + 0 * 4, y, mask ? 1 : 0, "A1");
            drawFont4(screen, x + 14 * 4, y, mask ? 1 : 0, "2");
            drawFont4(screen, x + 27 * 4, y, mask ? 1 : 0, "3");
            drawFont4(screen, x + 40 * 4, y, mask ? 1 : 0, "4");
            drawFont4(screen, x + 53 * 4, y, mask ? 1 : 0, "5");
            drawFont4(screen, x + 66 * 4, y, mask ? 1 : 0, "6");
        }

        private static void Ch6YM2612_P(FrameBuffer screen, int x, int y, int m, bool mask, int tp)
        {
            if (m == 0)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 0, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, "6");
            }
            else
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 16, 0, 16, 8);
                drawFont8(screen, x + 16, y, 0, " ");
            }
        }

        private static void ChYM2612_P(FrameBuffer screen, int x, int y, int ch, bool mask, int tp)
        {
            if (ch == 5)
            {
                return;
            }

            if (ch < 5)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 0, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (ch + 1).ToString());
            }
            else if (ch < 10)
            {
                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 48, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, (ch - 5).ToString());
            }
        }

        private static void Ch6YM2612XGM_P(FrameBuffer screen, int x, int y, int m, bool mask, int tp)
        {
            if (m == 0)
            {
                //FM mode

                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 0, 0, 16, 8);
                drawFont8(screen, x + 16, y, mask ? 1 : 0, "6");
                for (int i = 0; i < 96; i++)
                {
                    int kx = kbl[(i % 12) * 2] + i / 12 * 28;
                    int kt = kbl[(i % 12) * 2 + 1];
                    drawKbn(screen, 32 + kx, y, kt, tp);
                }
            }
            else
            {
                //PCM mode

                screen.drawByteArray(x, y, rType[tp * 2 + (mask ? 1 : 0)], 128, 16, 0, 16, 8);
                drawFont8(screen, x + 16, y, 0, " ");
                drawFont4(screen, x + 32, y, 0, " 1C00             2C00             3C00             4C00                ");
            }
        }



        private static void drawFaderSlitP(FrameBuffer screen, int x, int y)
        {
            screen.drawByteArray(x, y, rFader, 32, 16, 0, 8, 8);
            screen.drawByteArray(x, y + 8, rFader, 32, 16, 8, 8, 8);
            screen.drawByteArray(x, y + 16, rFader, 32, 16, 8, 8, 8);
            screen.drawByteArray(x, y + 24, rFader, 32, 16, 8, 8, 8);
            screen.drawByteArray(x, y + 32, rFader, 32, 16, 8, 8, 8);
            screen.drawByteArray(x, y + 40, rFader, 32, 16, 8, 8, 8);
            screen.drawByteArray(x, y + 48, rFader, 32, 24, 0, 8, 8);
        }

        private static void drawFaderP(FrameBuffer screen, int x, int y, int t)
        {
            screen.drawByteArray(x, y, rFader, 32, t == 0 ? 0 : 8, 0, 8, 13);
        }

        private static void drawMixerVolumeP(FrameBuffer screen, int x, int y, int t)
        {
            screen.drawByteArray(x, y, rFader, 32, 24, 8 + t, 2, 1);
        }

        private static void drawTnP(FrameBuffer screen, int x, int y, int t, int tp)
        {
            if (screen == null) return;
            screen.drawByteArray(x, y, rPSGMode[tp], 32, 8 * t, 0, 8, 8);
        }

        private static void drawToneFormatP(FrameBuffer screen, int x, int y, int toneFormat)
        {
            screen.drawByteArray(x, y, rMenuButtons[1], 128, (toneFormat % 3) * 5 * 8, (6 + toneFormat / 3) * 8, 40, 8);
        }

        private static void drawChipNameP(FrameBuffer screen, int x, int y, int t, int c)
        {
            if (screen == null)
            {
                return;
            }

            screen.drawByteArray(x, y, rChipName[c], 128
                , (t % 8) * 16
                , (t / 8) * 8
                , 8 * 2
                , 8);

        }




    }
}
