﻿using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NAudio.Midi;
using System.Collections.Generic;

namespace MDPlayer
{
    public partial class frmMain : Form
    {
        private PictureBox pbRf5c164Screen;
        private DoubleBuffer screen;
        private int pWidth = 0;
        private int pHeight = 0;

        private frmInfo frmInfo = null;
        private frmMegaCD frmMCD = null;
        private frmC140 frmC140 = null;
        private frmYM2608 frmYM2608 = null;
        private frmYM2151 frmYM2151 = null;
        private frmPlayList frmPlayList = null;

        private MDChipParams oldParam = new MDChipParams();
        private MDChipParams newParam = new MDChipParams();

        private int[] oldButton = new int[16];
        private int[] newButton = new int[16];
        private int[] oldButtonMode = new int[16];
        private int[] newButtonMode = new int[16];

        private bool isRunning = false;
        private bool stopped = false;

        private bool IsInitialOpenFolder = true;

        private static int SamplingRate = 44100;
        private byte[] srcBuf;

        public Setting setting = Setting.Load();

        private int frameSizeW = 0;
        private int frameSizeH = 0;


        //private MidiIn midiin = null;


        public frmMain()
        {
            log.ForcedWrite("起動処理開始");
            log.ForcedWrite("frmMain(コンストラクタ):STEP 00");

            InitializeComponent();

            log.ForcedWrite("frmMain(コンストラクタ):STEP 01");
            //引数が指定されている場合のみプロセスチェックを行い、自分と同じアプリケーションが実行中ならばそちらに引数を渡し終了する
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                Process prc = GetPreviousProcess();
                if (prc != null)
                {
                    SendString(prc.MainWindowHandle, Environment.GetCommandLineArgs()[1]);
                    this.Close();
                }
            }

            log.ForcedWrite("frmMain(コンストラクタ):STEP 02");

            pbScreen.AllowDrop = true;

            log.ForcedWrite("frmMain(コンストラクタ):STEP 03");
            if (setting == null)
            {
                log.ForcedWrite("frmMain(コンストラクタ):setting is null");
            }

            log.ForcedWrite("起動時のAudio初期化処理開始");

            Audio.Init(setting);

            log.ForcedWrite("起動時のAudio初期化処理完了");

            StartMIDIInMonitoring();

            log.ForcedWrite("frmMain(コンストラクタ):STEP 04");

            log.debug = setting.Debug_DispFrameCounter;

        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            log.ForcedWrite("frmMain_Load:STEP 05");

            if (setting.location.PMain != System.Drawing.Point.Empty)
                this.Location = setting.location.PMain;

            // DoubleBufferオブジェクトの作成

            pbRf5c164Screen = new PictureBox();
            pbRf5c164Screen.Width = 320;
            pbRf5c164Screen.Height = 72;

            log.ForcedWrite("frmMain_Load:STEP 06");

            screen = new DoubleBuffer(pbScreen, Properties.Resources.plane, Properties.Resources.font, 1);
            screen.setting = setting;
            //oldParam = new MDChipParams();
            //newParam = new MDChipParams();
            screen.screenInitAll();

            log.ForcedWrite("frmMain_Load:STEP 07");

            pWidth = pbScreen.Width;
            pHeight = pbScreen.Height;

            frmPlayList = new frmPlayList();
            frmPlayList.frmMain = this;
            frmPlayList.Show();
            frmPlayList.Visible = false;
            frmPlayList.Opacity = 1.0;
            frmPlayList.Location = new System.Drawing.Point(this.Location.X + 328, this.Location.Y + 264);
            frmPlayList.Refresh();

            if (setting.location.OPlayList) dispPlayList();
            if (setting.location.ORf5c164) openMegaCD();
            if (setting.location.OInfo) openInfo();
            if (setting.location.OC140) tsmiC140_Click(null, null);
            if (setting.location.OYm2151) tsmiOPM_Click(null, null);
            if (setting.location.OYm2608) tsmiOPNA_Click(null, null);

            log.ForcedWrite("frmMain_Load:STEP 08");

            frameSizeW = this.Width - this.ClientSize.Width;
            frameSizeH = this.Height - this.ClientSize.Height;

            changeZoom();
        }

        private void changeZoom()
        {
            this.MaximumSize = new System.Drawing.Size(frameSizeW+Properties.Resources.plane.Width* setting.other.Zoom, frameSizeH+Properties.Resources.plane.Height* setting.other.Zoom);
            this.MinimumSize = new System.Drawing.Size(frameSizeW + Properties.Resources.plane.Width * setting.other.Zoom, frameSizeH + Properties.Resources.plane.Height * setting.other.Zoom);
            this.Size = new System.Drawing.Size(frameSizeW + Properties.Resources.plane.Width * setting.other.Zoom, frameSizeH + Properties.Resources.plane.Height * setting.other.Zoom);
            frmMain_Resize(null, null);

            if (frmMCD != null && !frmMCD.isClosed)
            {
                openMegaCD();
                openMegaCD();
            }

            if (frmC140 != null && !frmC140.isClosed)
            {
                tsmiC140_Click(null, null);
                tsmiC140_Click(null, null);
            }

            if (frmYM2608 != null && !frmYM2608.isClosed)
            {
                tsmiOPNA_Click(null, null);
                tsmiOPNA_Click(null, null);
            }

            if (frmYM2151 != null && !frmYM2151.isClosed)
            {
                tsmiOPM_Click(null, null);
                tsmiOPM_Click(null, null);
            }

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            log.ForcedWrite("frmMain_Shown:STEP 09");

            System.Threading.Thread trd = new System.Threading.Thread(screenMainLoop);
            trd.Start();
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length < 2)
            {
                return;
            }

            log.ForcedWrite("frmMain_Shown:STEP 10");

            try
            {

                frmPlayList.Stop();

                PlayList pl = frmPlayList.getPlayList();
                if (pl.lstMusic.Count < 1 || pl.lstMusic[pl.lstMusic.Count - 1].fileName != args[1])
                {
                    frmPlayList.AddList(args[1]);
                }

                if (!loadAndPlay(args[1],""))
                {
                    frmPlayList.Stop();
                    Audio.Stop();
                    return;
                }

                frmPlayList.setStart(-1);

                frmPlayList.Play();

            }
            catch (Exception ex)
            {
                log.ForcedWrite(ex);
                MessageBox.Show("ファイルの読み込みに失敗しました。");
            }

            log.ForcedWrite("frmMain_Shown:STEP 11");
            log.ForcedWrite("起動処理完了");
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            // リサイズ時は再確保

            if (screen != null) screen.Dispose();

            screen = new DoubleBuffer(pbScreen, Properties.Resources.plane, Properties.Resources.font, setting.other.Zoom);
            screen.setting = setting;
            //oldParam = new MDChipParams();
            //newParam = new MDChipParams();
            screen.screenInitAll();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            log.ForcedWrite("終了処理開始");
            log.ForcedWrite("frmMain_FormClosing:STEP 00");

            frmPlayList.Stop();
            frmPlayList.Save();

            log.ForcedWrite("frmMain_FormClosing:STEP 01");

            StopMIDIInMonitoring();
            Audio.Close();

            log.ForcedWrite("frmMain_FormClosing:STEP 02");

            isRunning = false;
            while (!stopped)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }

            log.ForcedWrite("frmMain_FormClosing:STEP 03");

            // 解放
            screen.Dispose();

            setting.location.OInfo = false;
            setting.location.OPlayList = false;
            setting.location.ORf5c164 = false;
            setting.location.OC140 = false;
            setting.location.OYm2151 = false;
            setting.location.OYm2608 = false;

            log.ForcedWrite("frmMain_FormClosing:STEP 04");

            setting.location.PMain = this.Location;
            if (frmInfo != null && !frmInfo.isClosed)
            {
                setting.location.PInfo = frmInfo.Location;
                setting.location.OInfo = true;
            }
            if (frmPlayList != null && !frmPlayList.isClosed)
            {
                setting.location.PPlayList = frmPlayList.Location;
                setting.location.PPlayListWH = new System.Drawing.Point(frmPlayList.Width, frmPlayList.Height);
                setting.location.OPlayList = true;
            }
            if (frmMCD != null && !frmMCD.isClosed)
            {
                setting.location.PRf5c164 = frmMCD.Location;
                setting.location.ORf5c164 = true;
            }
            if (frmC140 != null && !frmC140.isClosed)
            {
                setting.location.PC140 = frmC140.Location;
                setting.location.OC140 = true;
            }
            if (frmYM2151 != null && !frmYM2151.isClosed)
            {
                setting.location.PYm2151 = frmYM2151.Location;
                setting.location.OYm2151 = true;
            }
            if (frmYM2608 != null && !frmYM2608.isClosed)
            {
                setting.location.PYm2608 = frmYM2608.Location;
                setting.location.OYm2608 = true;
            }

            log.ForcedWrite("frmMain_FormClosing:STEP 05");

            setting.Save();

            log.ForcedWrite("frmMain_FormClosing:STEP 06");
            log.ForcedWrite("終了処理完了");
            
        }

        private void pbScreen_MouseMove(object sender, MouseEventArgs e)
        {
            int px = e.Location.X / setting.other.Zoom;
            int py = e.Location.Y / setting.other.Zoom;

            if (py < 208)
            {
                for (int n = 0; n < newButton.Length; n++)
                {
                    newButton[n] = 0;
                }
                return;
            }

            for (int n = 0; n < newButton.Length; n++)
            {
                if (px >= 320 - (16 - n) * 16 && px < 320 - (15 - n) * 16) newButton[n] = 1;
                else newButton[n] = 0;
            }

        }

        private void pbScreen_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < newButton.Length; i++)
                newButton[i] = 0;
        }

        private void pbScreen_MouseClick(object sender, MouseEventArgs e)
        {
            int px = e.Location.X / setting.other.Zoom;
            int py = e.Location.Y / setting.other.Zoom;

            if (py < 14 * 8)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int ch = (py / 8) - 1;
                    if (ch < 0) return;

                    if (ch >= 0 && ch < 6)
                    {
                        SetChannelMask(vgm.enmUseChip.YM2612, ch);
                    }
                    else if (ch < 10)
                    {
                        SetChannelMask(vgm.enmUseChip.SN76489, ch - 6);
                    }
                    else if (ch < 13)
                    {
                        SetChannelMask(vgm.enmUseChip.YM2612, ch - 4);
                    }

                }
                else if (e.Button == MouseButtons.Right)
                {
                    for (int ch = 0; ch < 9; ch++) ResetChannelMask(vgm.enmUseChip.YM2612, ch);
                    for (int ch = 0; ch < 4; ch++) ResetChannelMask(vgm.enmUseChip.SN76489, ch);
                }

                return;
            }


            // 音色表示欄の判定

            if (py < 26 * 8)
            {
                int h = (py - 14 * 8) / (6 * 8);
                int w = Math.Min(px / (13 * 8), 2);
                int instCh = h * 3 + w;

                //クリップボードに音色をコピーする
                getInstCh(vgm.enmUseChip.YM2612, instCh);

                return;
            }


            // ボタンの判定

            if (px >= 320 - 16 * 16 && px < 320 - 15 * 16)
            {
                openSetting();
                return;
            }

            if (px >= 320 - 15 * 16 && px < 320 - 14 * 16)
            {
                frmPlayList.Stop();
                stop();
                return;
            }

            if (px >= 320 - 14 * 16 && px < 320 - 13 * 16)
            {
                pause();
                return;
            }

            if (px >= 320 - 13 * 16 && px < 320 - 12 * 16)
            {
                fadeout();
                frmPlayList.Stop();
                return;
            }

            if (px >= 320 - 12 * 16 && px < 320 - 11 * 16)
            {
                prev();
                return;
            }

            if (px >= 320 - 11 * 16 && px < 320 - 10 * 16)
            {
                slow();
                return;
            }

            if (px >= 320 - 10 * 16 && px < 320 - 9 * 16)
            {
                play();
                return;
            }

            if (px >= 320 - 9 * 16 && px < 320 - 8 * 16)
            {
                ff();
                return;
            }

            if (px >= 320 - 8 * 16 && px < 320 - 7 * 16)
            {
                next();
                return;
            }

            if (px >= 320 - 7 * 16 && px < 320 - 6 * 16)
            {
                playMode();
                return;
            }

            if (px >= 320 - 6 * 16 && px < 320 - 5 * 16)
            {
                string[] fn = fileOpen(true);

                if (fn != null)
                {
                    if (Audio.isPaused)
                    {
                        Audio.Pause();
                    }

                    if (fn.Length == 1)
                    {
                        frmPlayList.Stop();

                        frmPlayList.AddList(fn[0]);

                        loadAndPlay(fn[0],"");
                        frmPlayList.setStart(-1);

                        frmPlayList.Play();
                    }
                    else
                    {
                        frmPlayList.Stop();

                        try
                        {
                            foreach (string f in fn) frmPlayList.AddList(f);
                        }
                        catch (Exception ex)
                        {
                            log.ForcedWrite(ex);
                        }
                    }
                }

                return;
            }

            if (px >= 320 - 5 * 16 && px < 320 - 4 * 16)
            {
                dispPlayList();
                return;
            }

            if (px >= 320 - 4 * 16 && px < 320 - 3 * 16)
            {
                openInfo();
                return;
            }

            if (px >= 320 - 3 * 16 && px < 320 - 2 * 16)
            {
                openMegaCD();
                return;
            }

            if (px >= 320 - 2 * 16 && px < 320 - 1 * 16)
            {
                showContextMenu();
                return;
            }

            if (px >= 320 - 1 * 16 && px < 320 - 0 * 16)
            {
                setting.other.Zoom = (setting.other.Zoom == 3) ? 1 : (setting.other.Zoom + 1);
                changeZoom();
                return;
            }
        }

        private void tsmiC140_Click(object sender, EventArgs e)
        {
            if (frmC140 != null)// && frmInfo.isClosed)
            {
                try
                {
                    screen.RemoveC140();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }

                try
                {
                    frmC140.Close();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }
                try
                {
                    frmC140.Dispose();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }
                frmC140 = null;
                return;
            }

            frmC140 = new frmC140(this,setting.other.Zoom);
            screen.AddC140(frmC140.pbScreen, Properties.Resources.planeF);

            if (setting.location.PC140 == System.Drawing.Point.Empty)
            {
                frmC140.x = this.Location.X;
                frmC140.y = this.Location.Y + 264;
            }
            else
            {
                frmC140.x = setting.location.PC140.X;
                frmC140.y = setting.location.PC140.Y;
            }

            frmC140.Show();
            frmC140.update();
            screen.screenInitC140();
        }

        private void tsmiOPNA_Click(object sender, EventArgs e)
        {
            if (frmYM2608 != null)// && frmInfo.isClosed)
            {
                try
                {
                    screen.RemoveYM2608();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }
                try
                {
                    frmYM2608.Close();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }
                try
                {
                    frmYM2608.Dispose();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }
                frmYM2608 = null;
                return;
            }

            frmYM2608 = new frmYM2608(this,setting.other.Zoom);

            if (setting.location.PYm2608 == System.Drawing.Point.Empty)
            {
                frmYM2608.x = this.Location.X;
                frmYM2608.y = this.Location.Y + 264;
            }
            else
            {
                frmYM2608.x = setting.location.PYm2608.X;
                frmYM2608.y = setting.location.PYm2608.Y;
            }

            screen.AddYM2608(frmYM2608.pbScreen, Properties.Resources.planeD);
            frmYM2608.Show();
            frmYM2608.update();
            screen.screenInitYM2608();
        }

        private void tsmiOPM_Click(object sender, EventArgs e)
        {
            if (frmYM2151 != null)// && frmInfo.isClosed)
            {
                try
                {
                    screen.RemoveYM2151();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }
                try
                {
                    frmYM2151.Close();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }
                try
                {
                    frmYM2151.Dispose();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }
                frmYM2151 = null;
                return;
            }

            frmYM2151 = new frmYM2151(this, setting.other.Zoom);

            if (setting.location.PYm2151 == System.Drawing.Point.Empty)
            {
                frmYM2151.x = this.Location.X;
                frmYM2151.y = this.Location.Y + 264;
            }
            else
            {
                frmYM2151.x = setting.location.PYm2151.X;
                frmYM2151.y = setting.location.PYm2151.Y;
            }

            screen.AddYM2151(frmYM2151.pbScreen, Properties.Resources.planeE);
            frmYM2151.Show();
            frmYM2151.update();
            screen.screenInitYM2151();
        }

        private void pbScreen_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }

        private void pbScreen_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string filename = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                try
                {

                    frmPlayList.Stop();

                    frmPlayList.AddList(filename);

                    loadAndPlay(filename);
                    frmPlayList.setStart(-1);

                    frmPlayList.Play();

                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                    MessageBox.Show("ファイルの読み込みに失敗しました。");
                }
            }
        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }



        private void screenMainLoop()
        {
            double nextFrame = (double)System.Environment.TickCount;
            isRunning = true;
            stopped = false;

            while (isRunning)
            {
                float period = 1000f / (float)setting.other.ScreenFrameRate;
                double tickCount = (double)System.Environment.TickCount;

                if (tickCount < nextFrame)
                {
                    if (nextFrame - tickCount > 1)
                    {
                        System.Threading.Thread.Sleep((int)(nextFrame - tickCount));
                    }
                    continue;
                }

                screenChangeParams();

                if (frmMCD != null && !frmMCD.isClosed) frmMCD.screenChangeParams();
                else frmMCD = null;

                if (frmC140 != null && !frmC140.isClosed) frmC140.screenChangeParams();
                else frmC140 = null;

                if (frmYM2608 != null && !frmYM2608.isClosed) frmYM2608.screenChangeParams();
                else frmYM2608 = null;

                if (frmYM2151 != null && !frmYM2151.isClosed) frmYM2151.screenChangeParams();
                else frmYM2151 = null;

                if ((double)System.Environment.TickCount >= nextFrame + period)
                {
                    nextFrame += period;
                    continue;
                }

                screenDrawParams();

                if (frmMCD != null && !frmMCD.isClosed) frmMCD.screenDrawParams();
                else frmMCD = null;

                if (frmC140 != null && !frmC140.isClosed) frmC140.screenDrawParams();
                else frmC140 = null;

                if (frmYM2608 != null && !frmYM2608.isClosed) frmYM2608.screenDrawParams();
                else frmYM2608 = null;

                if (frmYM2151 != null && !frmYM2151.isClosed) frmYM2151.screenDrawParams();
                else frmYM2151 = null;

                nextFrame += period;

                if (frmPlayList.isPlaying())
                {
                    if ((setting.other.UseLoopTimes && Audio.GetVgmCurLoopCounter() > setting.other.LoopTimes - 1) || Audio.GetVGMStopped())
                    {
                        fadeout();
                    }
                    if (Audio.Stopped && frmPlayList.isPlaying())
                    {
                        nextPlayMode();
                    }
                }

                if (Audio.fatalError)
                {
                    log.ForcedWrite("AudioでFatalErrorが発生。再度Audio初期化処理開始");

                    frmPlayList.Stop();
                    try { Audio.Stop(); }
                    catch (Exception ex)
                    {
                        log.ForcedWrite(ex);
                    }

                    try { Audio.Close(); }
                    catch (Exception ex)
                    {
                        log.ForcedWrite(ex);
                    }

                    Audio.fatalError = false;
                    Audio.Init(setting);

                    log.ForcedWrite("Audio初期化処理完了");
                }
            }

            stopped = true;
        }

        private void screenChangeParams()
        {
            int[][] fmRegister = Audio.GetFMRegister();
            int[][] fmVol = Audio.GetFMVolume();
            int[] fmCh3SlotVol = Audio.GetFMCh3SlotVolume();
            int[] fmKey = Audio.GetFMKeyOn();

            int[][] psgVol = Audio.GetPSGVolume();

            int[] ym2151Register = Audio.GetYM2151Register();
            int[] fmKeyYM2151 = Audio.GetYM2151KeyOn();
            int[][] fmYM2151Vol = Audio.GetYM2151Volume();

            int[][] ym2608Register = Audio.GetYM2608Register();
            int[] fmKeyYM2608 = Audio.GetYM2608KeyOn();
            int[][] ym2608Vol = Audio.GetYM2608Volume();
            int[] ym2608Ch3SlotVol = Audio.GetYM2608Ch3SlotVolume();
            int[][] ym2608Rhythm = Audio.GetYM2608RhythmVolume();
            int[] ym2608AdpcmVol = Audio.GetYM2608AdpcmVolume();

            bool isFmEx = (fmRegister[0][0x27] & 0x40) > 0;

            for (int ch = 0; ch < 6; ch++)
            {
                int p = (ch > 2) ? 1 : 0;
                int c = (ch > 2) ? ch - 3 : ch;
                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 8 : ((i == 2) ? 4 : 12));
                    newParam.ym2612.channels[ch].inst[i * 11 + 0] = fmRegister[p][0x50 + ops + c] & 0x1f; //AR
                    newParam.ym2612.channels[ch].inst[i * 11 + 1] = fmRegister[p][0x60 + ops + c] & 0x1f; //DR
                    newParam.ym2612.channels[ch].inst[i * 11 + 2] = fmRegister[p][0x70 + ops + c] & 0x1f; //SR
                    newParam.ym2612.channels[ch].inst[i * 11 + 3] = fmRegister[p][0x80 + ops + c] & 0x0f; //RR
                    newParam.ym2612.channels[ch].inst[i * 11 + 4] = (fmRegister[p][0x80 + ops + c] & 0xf0) >> 4;//SL
                    newParam.ym2612.channels[ch].inst[i * 11 + 5] = fmRegister[p][0x40 + ops + c] & 0x7f;//TL
                    newParam.ym2612.channels[ch].inst[i * 11 + 6] = (fmRegister[p][0x50 + ops + c] & 0xc0) >> 6;//KS
                    newParam.ym2612.channels[ch].inst[i * 11 + 7] = fmRegister[p][0x30 + ops + c] & 0x0f;//ML
                    newParam.ym2612.channels[ch].inst[i * 11 + 8] = (fmRegister[p][0x30 + ops + c] & 0x70) >> 4;//DT
                    newParam.ym2612.channels[ch].inst[i * 11 + 9] = (fmRegister[p][0x60 + ops + c] & 0x80) >> 7;//AM
                    newParam.ym2612.channels[ch].inst[i * 11 + 10] = fmRegister[p][0x90 + ops + c] & 0x0f;//SG
                }
                newParam.ym2612.channels[ch].inst[44] = fmRegister[p][0xb0 + c] & 0x07;//AL
                newParam.ym2612.channels[ch].inst[45] = (fmRegister[p][0xb0 + c] & 0x38) >> 3;//FB
                newParam.ym2612.channels[ch].inst[46] = (fmRegister[p][0xb4 + c] & 0x38) >> 3;//AMS
                newParam.ym2612.channels[ch].inst[47] = fmRegister[p][0xb4 + c] & 0x03;//FMS

                newParam.ym2612.channels[ch].pan = (fmRegister[p][0xb4 + c] & 0xc0) >> 6;

                int freq = 0;
                int octav = 0;
                int n = -1;
                if (ch != 2 || !isFmEx)
                {
                    freq = fmRegister[p][0xa0 + c] + (fmRegister[p][0xa4 + c] & 0x07) * 0x100;
                    octav = (fmRegister[p][0xa4 + c] & 0x38) >> 3;

                    if (fmKey[ch] > 0) n = Math.Min(Math.Max(octav * 12 + searchFMNote(freq), 0), 95);
                    newParam.ym2612.channels[ch].volumeL = Math.Min(Math.Max(fmVol[ch][0] / 80, 0), 19);
                    newParam.ym2612.channels[ch].volumeR = Math.Min(Math.Max(fmVol[ch][1] / 80, 0), 19);
                }
                else
                {
                    freq = fmRegister[0][0xa9] + (fmRegister[0][0xad] & 0x07) * 0x100;
                    octav = (fmRegister[0][0xad] & 0x38) >> 3;

                    if ((fmKey[2] & 0x10) > 0) n = Math.Min(Math.Max(octav * 12 + searchFMNote(freq), 0), 95);
                    newParam.ym2612.channels[2].volumeL = Math.Min(Math.Max(fmCh3SlotVol[0] / 80, 0), 19);
                    newParam.ym2612.channels[2].volumeR = Math.Min(Math.Max(fmCh3SlotVol[0] / 80, 0), 19);
                }
                newParam.ym2612.channels[ch].note = n;


            }

            for (int ch = 6; ch < 9; ch++)
            {
                int[] exReg = new int[3] { 2, 0, -6 };
                int c = exReg[ch - 6];

                newParam.ym2612.channels[ch].pan = 0;

                if (isFmEx)
                {
                    int freq = fmRegister[0][0xa8 + c] + (fmRegister[0][0xac + c] & 0x07) * 0x100;
                    int octav = (fmRegister[0][0xac + c] & 0x38) >> 3;
                    int n = -1;
                    if ((fmKey[2] & (0x20 << (ch - 6))) > 0) n = Math.Min(Math.Max(octav * 12 + searchFMNote(freq), 0), 95);
                    newParam.ym2612.channels[ch].note = n;
                    newParam.ym2612.channels[ch].volumeL = Math.Min(Math.Max(fmCh3SlotVol[ch - 5] / 80, 0), 19);
                }
                else
                {
                    newParam.ym2612.channels[ch].note = -1;
                    newParam.ym2612.channels[ch].volumeL = 0;
                }
            }

            newParam.ym2612.channels[5].pcmMode = (fmRegister[0][0x2b] & 0x80) >> 7;

            int[] psgRegister = Audio.GetPSGRegister();
            for (int ch = 0; ch < 4; ch++)
            {
                if (psgRegister[ch * 2 + 1] != 15)
                {
                    newParam.sn76489.channels[ch].note = searchPSGNote(psgRegister[ch * 2]);
                }
                else
                {
                    newParam.sn76489.channels[ch].note = -1;
                }

                newParam.sn76489.channels[ch].volume = Math.Min(Math.Max((int)((psgVol[ch][0] + psgVol[ch][1]) / (30.0 / 19.0)), 0), 19);
            }

            MDSound.scd_pcm.pcm_chip_ rf5c164Register = Audio.GetRf5c164Register();
            int[][] rf5c164Vol = Audio.GetRf5c164Volume();
            for (int ch = 0; ch < 8; ch++)
            {
                if (rf5c164Register.Channel[ch].Enable != 0)
                {
                    newParam.rf5c164.channels[ch].note = searchRf5c164Note(rf5c164Register.Channel[ch].Step_B);
                    newParam.rf5c164.channels[ch].volumeL = Math.Min(Math.Max(rf5c164Vol[ch][0] / 400, 0), 19);
                    newParam.rf5c164.channels[ch].volumeR = Math.Min(Math.Max(rf5c164Vol[ch][1] / 400, 0), 19);
                }
                else
                {
                    newParam.rf5c164.channels[ch].note = -1;
                    newParam.rf5c164.channels[ch].volumeL = 0;
                    newParam.rf5c164.channels[ch].volumeR = 0;
                }
                newParam.rf5c164.channels[ch].pan = (int)rf5c164Register.Channel[ch].PAN;
            }

            MDSound.c140.c140_state c140State = Audio.GetC140Register();
            for (int ch = 0; ch < 24; ch++)
            {
                int frequency = c140State.REG[ch * 16 + 2] * 256 + c140State.REG[ch * 16 + 3];
                int l = c140State.REG[ch * 16 + 1];
                int r = c140State.REG[ch * 16 + 0];
                int vdt = Math.Abs((int)c140State.voi[ch].prevdt);

                if (c140State.voi[ch].key == 0) frequency = 0;
                if (frequency == 0)
                {
                    l = 0;
                    r = 0;
                }

                newParam.c140.channels[ch].note = frequency == 0 ? -1 : (searchC140Note(frequency) + 1);
                newParam.c140.channels[ch].pan = ((l >> 2) & 0xf) | (((r >> 2) & 0xf) << 4);
                newParam.c140.channels[ch].volumeL = Math.Min(Math.Max((l * vdt) >> 7, 0), 19);
                newParam.c140.channels[ch].volumeR = Math.Min(Math.Max((r * vdt) >> 7, 0), 19);
            }

            for (int ch = 0; ch < 8; ch++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 16 : ((i == 2) ? 8 : 24));
                    newParam.ym2151.channels[ch].inst[i * 11 + 0] = ym2151Register[0x80 + ops + ch] & 0x1f; //AR
                    newParam.ym2151.channels[ch].inst[i * 11 + 1] = ym2151Register[0xa0 + ops + ch] & 0x1f; //DR
                    newParam.ym2151.channels[ch].inst[i * 11 + 2] = ym2151Register[0xc0 + ops + ch] & 0x1f; //SR
                    newParam.ym2151.channels[ch].inst[i * 11 + 3] = ym2151Register[0xe0 + ops + ch] & 0x0f; //RR
                    newParam.ym2151.channels[ch].inst[i * 11 + 4] = (ym2151Register[0xe0 + ops + ch] & 0xf0) >> 4;//SL
                    newParam.ym2151.channels[ch].inst[i * 11 + 5] = ym2151Register[0x60 + ops + ch] & 0x7f;//TL
                    newParam.ym2151.channels[ch].inst[i * 11 + 6] = (ym2151Register[0x80 + ops + ch] & 0xc0) >> 6;//KS
                    newParam.ym2151.channels[ch].inst[i * 11 + 7] = ym2151Register[0x40 + ops + ch] & 0x0f;//ML
                    newParam.ym2151.channels[ch].inst[i * 11 + 8] = (ym2151Register[0x40 + ops + ch] & 0x70) >> 4;//DT
                    newParam.ym2151.channels[ch].inst[i * 11 + 9] = (ym2151Register[0xc0 + ops + ch] & 0xc0) >> 6;//DT2
                    newParam.ym2151.channels[ch].inst[i * 11 + 10] = (ym2151Register[0xa0 + ops + ch] & 0x80) >> 7;//AM
                }
                newParam.ym2151.channels[ch].inst[44] = ym2151Register[0x20 + ch] & 0x07;//AL
                newParam.ym2151.channels[ch].inst[45] = (ym2151Register[0x20 + ch] & 0x38) >> 3;//FB
                newParam.ym2151.channels[ch].inst[46] = (ym2151Register[0x38 + ch] & 0x3);//AMS
                newParam.ym2151.channels[ch].inst[47] = (ym2151Register[0x38 + ch] & 0x70) >> 4;//PMS

                newParam.ym2151.channels[ch].pan = (ym2151Register[0x20 + ch] & 0xc0) >> 6;
                int note = (ym2151Register[0x28 + ch] & 0x0f);
                note = (note < 3) ? note : (note < 7 ? note - 1 : (note < 11 ? note - 2 : note - 3));
                int oct = (ym2151Register[0x28 + ch] & 0x70) >> 4;
                newParam.ym2151.channels[ch].note = (fmKeyYM2151[ch] > 0) ? (oct * 12 + note + Audio.vgmReal.YM2151Hosei + 1) : -1;

                newParam.ym2151.channels[ch].volumeL = Math.Min(Math.Max(fmYM2151Vol[ch][0] / 80, 0), 19);
                newParam.ym2151.channels[ch].volumeR = Math.Min(Math.Max(fmYM2151Vol[ch][1] / 80, 0), 19);
            }

            isFmEx = (ym2608Register[0][0x27] & 0x40) > 0;
            for (int ch = 0; ch < 6; ch++)
            {
                int p = (ch > 2) ? 1 : 0;
                int c = (ch > 2) ? ch - 3 : ch;
                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 8 : ((i == 2) ? 4 : 12));
                    newParam.ym2608.channels[ch].inst[i * 11 + 0] = ym2608Register[p][0x50 + ops + c] & 0x1f; //AR
                    newParam.ym2608.channels[ch].inst[i * 11 + 1] = ym2608Register[p][0x60 + ops + c] & 0x1f; //DR
                    newParam.ym2608.channels[ch].inst[i * 11 + 2] = ym2608Register[p][0x70 + ops + c] & 0x1f; //SR
                    newParam.ym2608.channels[ch].inst[i * 11 + 3] = ym2608Register[p][0x80 + ops + c] & 0x0f; //RR
                    newParam.ym2608.channels[ch].inst[i * 11 + 4] = (ym2608Register[p][0x80 + ops + c] & 0xf0) >> 4;//SL
                    newParam.ym2608.channels[ch].inst[i * 11 + 5] = ym2608Register[p][0x40 + ops + c] & 0x7f;//TL
                    newParam.ym2608.channels[ch].inst[i * 11 + 6] = (ym2608Register[p][0x50 + ops + c] & 0xc0) >> 6;//KS
                    newParam.ym2608.channels[ch].inst[i * 11 + 7] = ym2608Register[p][0x30 + ops + c] & 0x0f;//ML
                    newParam.ym2608.channels[ch].inst[i * 11 + 8] = (ym2608Register[p][0x30 + ops + c] & 0x70) >> 4;//DT
                    newParam.ym2608.channels[ch].inst[i * 11 + 9] = (ym2608Register[p][0x60 + ops + c] & 0x80) >> 7;//AM
                    newParam.ym2608.channels[ch].inst[i * 11 + 10] = ym2608Register[p][0x90 + ops + c] & 0x0f;//SG
                }
                newParam.ym2608.channels[ch].inst[44] = ym2608Register[p][0xb0 + c] & 0x07;//AL
                newParam.ym2608.channels[ch].inst[45] = (ym2608Register[p][0xb0 + c] & 0x38) >> 3;//FB
                newParam.ym2608.channels[ch].inst[46] = (ym2608Register[p][0xb4 + c] & 0x38) >> 3;//AMS
                newParam.ym2608.channels[ch].inst[47] = ym2608Register[p][0xb4 + c] & 0x03;//FMS

                newParam.ym2608.channels[ch].pan = (ym2608Register[p][0xb4 + c] & 0xc0) >> 6;

                int freq = 0;
                int octav = 0;
                int n = -1;
                if (ch != 2 || !isFmEx)
                {
                    freq = ym2608Register[p][0xa0 + c] + (ym2608Register[p][0xa4 + c] & 0x07) * 0x100;
                    octav = (ym2608Register[p][0xa4 + c] & 0x38) >> 3;

                    if (fmKeyYM2608[ch] > 0) n = Math.Min(Math.Max(octav * 12 + searchFMNote(freq) + 1, 0), 95);
                    newParam.ym2608.channels[ch].volumeL = Math.Min(Math.Max(ym2608Vol[ch][0] / 80, 0), 19);
                    newParam.ym2608.channels[ch].volumeR = Math.Min(Math.Max(ym2608Vol[ch][1] / 80, 0), 19);
                }
                else
                {
                    freq = ym2608Register[0][0xa9] + (ym2608Register[0][0xad] & 0x07) * 0x100;
                    octav = (ym2608Register[0][0xad] & 0x38) >> 3;

                    if ((fmKeyYM2608[2] & 0x10) > 0) n = Math.Min(Math.Max(octav * 12 + searchFMNote(freq) + 1, 0), 95);
                    newParam.ym2608.channels[2].volumeL = Math.Min(Math.Max(ym2608Ch3SlotVol[0] / 80, 0), 19);
                    newParam.ym2608.channels[2].volumeR = Math.Min(Math.Max(ym2608Ch3SlotVol[0] / 80, 0), 19);
                }
                newParam.ym2608.channels[ch].note = n;


            }

            for (int ch = 6; ch < 9; ch++) //FM EX
            {
                int[] exReg = new int[3] { 2, 0, -6 };
                int c = exReg[ch - 6];

                newParam.ym2608.channels[ch].pan = 0;

                if (isFmEx)
                {
                    int freq = ym2608Register[0][0xa8 + c] + (ym2608Register[0][0xac + c] & 0x07) * 0x100;
                    int octav = (ym2608Register[0][0xac + c] & 0x38) >> 3;
                    int n = -1;
                    if ((fmKeyYM2608[2] & (0x20 << (ch - 6))) > 0) n = Math.Min(Math.Max(octav * 12 + searchFMNote(freq), 0), 95);
                    newParam.ym2608.channels[ch].note = n;
                    newParam.ym2608.channels[ch].volumeL = Math.Min(Math.Max(ym2608Ch3SlotVol[ch - 5] / 80, 0), 19);
                }
                else
                {
                    newParam.ym2608.channels[ch].note = -1;
                    newParam.ym2608.channels[ch].volumeL = 0;
                }
            }

            for (int ch = 0; ch < 3; ch++) //SSG
            {
                MDChipParams.Channel channel = newParam.ym2608.channels[ch + 9];

                bool t = (ym2608Register[0][0x07] & (0x1 << ch)) == 0;
                bool n = (ym2608Register[0][0x07] & (0x8 << ch)) == 0;

                channel.volume = (int)(((t || n) ? 1 : 0) * (ym2608Register[0][0x08 + ch] & 0xf) * (20.0 / 16.0));
                if (!t && !n && channel.volume > 0)
                {
                    channel.volume--;
                }

                if (channel.volume == 0)
                {
                    channel.note = -1;
                }
                else
                {
                    int ft = ym2608Register[0][0x00 + ch * 2];
                    int ct = ym2608Register[0][0x01 + ch * 2];
                    int tp = (ct << 8) | ft;
                    if (tp == 0) tp = 1;
                    float ftone = 7987200.0f / (64.0f * (float)tp);// 7987200 = MasterClock
                    channel.note = searchSSGNote(ftone);
                }

            }

            //ADPCM
            newParam.ym2608.channels[12].pan = (ym2608Register[1][0x01] & 0xc0) >> 6;
            newParam.ym2608.channels[12].volumeL = Math.Min(Math.Max(ym2608AdpcmVol[0] / 80, 0), 19);
            newParam.ym2608.channels[12].volumeR = Math.Min(Math.Max(ym2608AdpcmVol[1] / 80, 0), 19);
            int delta = (ym2608Register[1][0x0a] << 8) | ym2608Register[1][0x09];
            float frq = (float)(delta / 9447.0f);
            newParam.ym2608.channels[12].note = searchYM2608Adpcm(frq) + 1;

            for (int ch = 13; ch < 19; ch++) //RHYTHM
            {
                newParam.ym2608.channels[ch].pan = (ym2608Register[0][0x18 + ch - 13] & 0xc0) >> 6;
                newParam.ym2608.channels[ch].volumeL = Math.Min(Math.Max(ym2608Rhythm[ch - 13][0] / 80, 0), 19);
                newParam.ym2608.channels[ch].volumeR = Math.Min(Math.Max(ym2608Rhythm[ch - 13][1] / 80, 0), 19);
            }



            long w = Audio.GetCounter();
            double sec = (double)w / (double)SamplingRate;
            newParam.Cminutes = (int)(sec / 60);
            sec -= newParam.Cminutes * 60;
            newParam.Csecond = (int)sec;
            sec -= newParam.Csecond;
            newParam.Cmillisecond = (int)(sec * 100.0);

            w = Audio.GetTotalCounter();
            sec = (double)w / (double)SamplingRate;
            newParam.TCminutes = (int)(sec / 60);
            sec -= newParam.TCminutes * 60;
            newParam.TCsecond = (int)sec;
            sec -= newParam.TCsecond;
            newParam.TCmillisecond = (int)(sec * 100.0);

            w = Audio.GetLoopCounter();
            sec = (double)w / (double)SamplingRate;
            newParam.LCminutes = (int)(sec / 60);
            sec -= newParam.LCminutes * 60;
            newParam.LCsecond = (int)sec;
            sec -= newParam.LCsecond;
            newParam.LCmillisecond = (int)(sec * 100.0);

        }

        private void screenDrawParams()
        {
            // 描画
            screen.drawParams(oldParam, newParam);

            screen.drawButtons(oldButton, newButton, oldButtonMode, newButtonMode);

            screen.drawTimer(0, ref oldParam.Cminutes, ref oldParam.Csecond, ref oldParam.Cmillisecond, newParam.Cminutes, newParam.Csecond, newParam.Cmillisecond);
            screen.drawTimer(1, ref oldParam.TCminutes, ref oldParam.TCsecond, ref oldParam.TCmillisecond, newParam.TCminutes, newParam.TCsecond, newParam.TCmillisecond);
            screen.drawTimer(2, ref oldParam.LCminutes, ref oldParam.LCsecond, ref oldParam.LCmillisecond, newParam.LCminutes, newParam.LCsecond, newParam.LCmillisecond);

            int tp = setting.YM2612Type.UseScci ? 1 : 0;
            int tp6 = tp;
            if (tp6 == 1 && setting.YM2612Type.OnlyPCMEmulation)
            {
                tp6 = newParam.ym2612.channels[5].pcmMode == 0 ? 1 : 0;
            }
            screen.drawCh6(ref oldParam.ym2612.channels[5].pcmMode, newParam.ym2612.channels[5].pcmMode
                , ref oldParam.ym2612.channels[5].mask, newParam.ym2612.channels[5].mask
                , ref oldParam.ym2612.channels[5].tp, tp6);
            for (int ch = 0; ch < 5; ch++)
            {
                screen.drawCh(ch, ref oldParam.ym2612.channels[ch].mask, newParam.ym2612.channels[ch].mask, tp);
            }
            for (int ch = 6; ch < 10; ch++)
            {
                screen.drawCh(ch, ref oldParam.sn76489.channels[ch - 6].mask, newParam.sn76489.channels[ch - 6].mask, setting.SN76489Type.UseScci ? 1 : 0);
            }
            for (int ch = 0; ch < 3; ch++)
            {
                screen.drawCh(ch + 10, ref oldParam.ym2612.channels[ch + 6].mask, newParam.ym2612.channels[ch + 6].mask, tp);
            }

            if (setting.Debug_DispFrameCounter)
            {
                long v = Audio.getVirtualFrameCounter();
                if (v != -1) screen.drawFont8(screen.mainScreen, 0, 0, 0, string.Format("EMU        : {0:D12} ", v));
                long r = Audio.getRealFrameCounter();
                if (r != -1) screen.drawFont8(screen.mainScreen, 0, 8, 0, string.Format("SCCI       : {0:D12} ", r));
                long d = r - v;
                if (r != -1 && v != -1) screen.drawFont8(screen.mainScreen, 0, 16, 0, string.Format("SCCI - EMU : {0:D12} ", d));

            }

            screen.drawFont4(screen.mainScreen, 0, 208, 1, Audio.GetIsDataBlock(vgm.enmModel.VirtualModel) ? "VD" : "  ");
            screen.drawFont4(screen.mainScreen, 12, 208, 1, Audio.GetIsPcmRAMWrite(vgm.enmModel.VirtualModel) ? "VP" : "  ");
            screen.drawFont4(screen.mainScreen, 0, 216, 1, Audio.GetIsDataBlock(vgm.enmModel.RealModel) ? "RD" : "  ");
            screen.drawFont4(screen.mainScreen, 12, 216, 1, Audio.GetIsPcmRAMWrite(vgm.enmModel.RealModel) ? "RP" : "  ");

            screen.Refresh();

            Audio.updateVol();


        }

        private int searchFMNote(int freq)
        {
            int m = int.MaxValue;
            int n = 0;
            for (int i = 0; i < 12 * 5; i++)
            {
                //if (freq < Tables.FmFNum[i]) break;
                //n = i;
                int a = Math.Abs(freq - Tables.FmFNum[i]);
                if (m > a)
                {
                    m = a;
                    n = i;
                }
            }
            return n - 12 * 3;
        }

        private int searchPSGNote(int freq)
        {
            int m = int.MaxValue;
            int n = 0;
            for (int i = 0; i < 12 * 8; i++)
            {
                int a = Math.Abs(freq - Tables.PsgFNum[i]);
                if (m > a)
                {
                    m = a;
                    n = i;
                }
            }
            return n;
        }

        private int searchSSGNote(float freq)
        {
            float m = float.MaxValue;
            int n = 0;
            for (int i = 0; i < 12 * 8; i++)
            {
                //if (freq < Tables.freqTbl[i]) break;
                //n = i;
                float a = Math.Abs(freq - Tables.freqTbl[i]);
                if (m > a)
                {
                    m = a;
                    n = i;
                }
            }
            return n;
        }

        private int searchRf5c164Note(uint freq)
        {
            double m = double.MaxValue;
            int n = 0;
            for (int i = 0; i < 12 * 8; i++)
            {
                double a = Math.Abs(freq - (0x0800 * Tables.pcmMulTbl[i % 12 + 12] * Math.Pow(2, ((int)(i / 12) - 4))));
                if (m > a)
                {
                    m = a;
                    n = i;
                }
            }
            return n;
        }

        private int searchC140Note(int freq)
        {
            double m = double.MaxValue;
            int n = 0;
            for (int i = 0; i < 12 * 8; i++)
            {
                double a = Math.Abs(freq - ((0x0800 << 2) * Tables.pcmMulTbl[i % 12 + 12] * Math.Pow(2, ((int)(i / 12) - 4))));
                if (m > a)
                {
                    m = a;
                    n = i;
                }
            }
            return n;
        }

        private int searchYM2608Adpcm(float freq)
        {
            float m = float.MaxValue;
            int n = 0;

            for (int i = 0; i < 12 * 8; i++)
            {
                if (freq < Tables.pcmMulTbl[i % 12 + 12] * Math.Pow(2, ((int)(i / 12) - 4))) break;
                n = i;
                float a = Math.Abs(freq - (float)(Tables.pcmMulTbl[i % 12 + 12] * Math.Pow(2, ((int)(i / 12) - 4))));
                if (m > a)
                {
                    m = a;
                    n = i;
                }
            }

            return n;
        }



        private void openSetting()
        {
            frmSetting frm = new frmSetting(setting);
            if (frm.ShowDialog() == DialogResult.OK)
            {

                StopMIDIInMonitoring();
                frmPlayList.Stop();
                Audio.Close();

                setting = frm.setting;
                setting.Save();

                screen.setting = setting;
                //oldParam = new MDChipParams();
                //newParam = new MDChipParams();
                screen.screenInitAll();

                log.ForcedWrite("設定が変更されたため、再度Audio初期化処理開始");

                Audio.Init(setting);

                log.ForcedWrite("Audio初期化処理完了");
                log.debug = setting.Debug_DispFrameCounter;

                StartMIDIInMonitoring();

                IsInitialOpenFolder = true;

            }
        }

        private void stop()
        {
            if (Audio.isPaused)
            {
                Audio.Pause();
            }

            frmPlayList.Stop();
            Audio.Stop();

        }

        private void pause()
        {
            Audio.Pause();
        }

        private void fadeout()
        {
            if (Audio.isPaused)
            {
                Audio.Pause();
            }

            Audio.Fadeout();
        }

        private void prev()
        {
            if (Audio.isPaused)
            {
                Audio.Pause();
            }

            frmPlayList.prevPlay();
        }

        private void play()
        {
            if (Audio.isPaused)
            {
                Audio.Pause();
            }

            string[] fn = null;

            frmPlayList.Stop();

            //if (srcBuf == null && frmPlayList.getMusicCount() < 1)
            if (frmPlayList.getMusicCount() < 1)
            {
                fn = fileOpen(false);
                if (fn == null) return;
                frmPlayList.AddList(fn[0]);
                fn[0] = frmPlayList.setStart(-1); //last
            }
            else
            {
                fn = new string[1] { "" };
                fn[0] = frmPlayList.setStart(-2);//first 
            }

            loadAndPlay(fn[0]);
            frmPlayList.Play();

        }

        private void playdata()
        {

            if (srcBuf == null)
            {
                return;
            }

            if (Audio.isPaused)
            {
                Audio.Pause();
            }
            stop();

            for (int ch = 0; ch < 9; ch++) ResetChannelMask(vgm.enmUseChip.YM2612, ch);
            for (int ch = 0; ch < 4; ch++) ResetChannelMask(vgm.enmUseChip.SN76489, ch);
            for (int ch = 0; ch < 8; ch++) ResetChannelMask(vgm.enmUseChip.RF5C164, ch);
            for (int ch = 0; ch < 8; ch++) ResetChannelMask(vgm.enmUseChip.YM2151, ch);
            for (int ch = 0; ch < 14; ch++) ResetChannelMask(vgm.enmUseChip.YM2608, ch);

            //oldParam = new MDChipParams();
            //newParam = new MDChipParams();
            screen.screenInitAll();

            if (!Audio.Play(setting))
            {
                //MessageBox.Show("再生に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    frmPlayList.Stop();
                    Audio.Stop();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }
                    throw new Exception();
                //return;
            }

            if (frmInfo != null)
            {
                frmInfo.update();
            }
        }

        private void ff()
        {
            if (Audio.isPaused)
            {
                Audio.Pause();
            }

            Audio.FF();
        }

        private void next()
        {
            if (Audio.isPaused)
            {
                Audio.Pause();
            }

            frmPlayList.nextPlay();
        }

        private void nextPlayMode()
        {
            frmPlayList.nextPlayMode(newButtonMode[9]);
        }

        private void slow()
        {
            if (Audio.isPaused)
            {
                Audio.Pause();
            }

            Audio.Slow();
        }

        private void playMode()
        {
            newButtonMode[9]++;
            if (newButtonMode[9] > 3) newButtonMode[9] = 0;

        }

        private string[] fileOpen(bool flg)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "VGMファイル(*.vgm;*.vgz)|*.vgm;*.vgz";
            ofd.Title = "VGM/VGZファイルを選択してください";
            if (setting.other.DefaultDataPath != "" && Directory.Exists(setting.other.DefaultDataPath) && IsInitialOpenFolder)
            {
                ofd.InitialDirectory = setting.other.DefaultDataPath;
            }
            else
            {
                ofd.RestoreDirectory = true;
            }
            ofd.CheckPathExists = true;
            ofd.Multiselect = flg;

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            IsInitialOpenFolder = false;

            return ofd.FileNames;

        }

        private void dispPlayList()
        {
            frmPlayList.setting = setting;
            if (setting.location.PPlayList != System.Drawing.Point.Empty)
            {
                frmPlayList.Location = setting.location.PPlayList;
            }
            if (setting.location.PPlayListWH != System.Drawing.Point.Empty)
            {
                frmPlayList.Width = setting.location.PPlayListWH.X;
                frmPlayList.Height = setting.location.PPlayListWH.Y;
            }
            frmPlayList.Visible = !frmPlayList.Visible;
            frmPlayList.TopMost = true;
            frmPlayList.TopMost = false;
        }

        private void openInfo()
        {
            if (frmInfo != null && !frmInfo.isClosed)
            {
                frmInfo.Close();
                frmInfo.Dispose();
                frmInfo = null;
                return;
            }

            if (frmInfo != null)
            {
                frmInfo.Close();
                frmInfo.Dispose();
                frmInfo = null;
            }

            frmInfo = new frmInfo(this);
            if (setting.location.PInfo == System.Drawing.Point.Empty)
            {
                frmInfo.x = this.Location.X + 328;
                frmInfo.y = this.Location.Y;
            }
            else
            {
                frmInfo.x = setting.location.PInfo.X;
                frmInfo.y = setting.location.PInfo.Y;
            }
            frmInfo.setting = setting;
            frmInfo.Show();
            frmInfo.update();
        }

        private void openMegaCD()
        {
            if (frmMCD != null)// && frmInfo.isClosed)
            {
                try
                {
                    screen.RemoveRf5c164();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }

                try
                {
                    frmMCD.Close();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);

                }
                try
                {
                    frmMCD.Dispose();
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                }
                frmMCD = null;
                return;
            }

            frmMCD = new frmMegaCD(this,setting.other.Zoom);
            if (setting.location.PRf5c164 == System.Drawing.Point.Empty)
            {
                frmMCD.x = this.Location.X;
                frmMCD.y = this.Location.Y + 264;
            }
            else
            {
                frmMCD.x = setting.location.PRf5c164.X;
                frmMCD.y = setting.location.PRf5c164.Y;
            }

            screen.AddRf5c164(frmMCD.pbScreen, Properties.Resources.planeC);
            frmMCD.Show();
            frmMCD.update();
            screen.screenInitRF5C164();
        }

        private void showContextMenu()
        {
            cmsOpenOtherPanel.Show();
            System.Drawing.Point p = Control.MousePosition;
            cmsOpenOtherPanel.Top = p.Y;
            cmsOpenOtherPanel.Left = p.X;
        }


        public const int FCC_VGM = 0x206D6756;	// "Vgm "

        public byte[] getAllBytes(string filename)
        {
            byte[] buf = System.IO.File.ReadAllBytes(filename);
            uint vgm = (UInt32)buf[0] + (UInt32)buf[1] * 0x100 + (UInt32)buf[2] * 0x10000 + (UInt32)buf[3] * 0x1000000;
            if (vgm == FCC_VGM) return buf;


            int num;
            buf = new byte[1024]; // 1Kbytesずつ処理する

            FileStream inStream // 入力ストリーム
              = new FileStream(filename, FileMode.Open, FileAccess.Read);

            GZipStream decompStream // 解凍ストリーム
              = new GZipStream(
                inStream, // 入力元となるストリームを指定
                CompressionMode.Decompress); // 解凍（圧縮解除）を指定

            MemoryStream outStream // 出力ストリーム
              = new MemoryStream();

            using (inStream)
            using (outStream)
            using (decompStream)
            {
                while ((num = decompStream.Read(buf, 0, buf.Length)) > 0)
                {
                    outStream.Write(buf, 0, num);
                }
            }

            return outStream.ToArray();
        }

        public void getInstCh(vgm.enmUseChip chip, int ch)
        {
            if (!setting.other.UseGetInst) return;

            switch (setting.other.InstFormat) {
                case Setting.Other.enmInstFormat.FMP7:
                    getInstChForFMP7(chip, ch);
                    break;
                case Setting.Other.enmInstFormat.MDX:
                    getInstChForMDX(chip, ch);
                    break;
                case Setting.Other.enmInstFormat.MML2VGM:
                    getInstChForMML2VGM(chip, ch);
                    break;
                case Setting.Other.enmInstFormat.MUSICLALF:
                    getInstChForMUSICLALF(chip, ch);
                    break;
                case Setting.Other.enmInstFormat.MUSICLALF2:
                    getInstChForMUSICLALF2(chip, ch);
                    break;
                case Setting.Other.enmInstFormat.TFI:
                    getInstChForTFI(chip, ch);
                    break;
                case Setting.Other.enmInstFormat.NRTDRV:
                    getInstChForNRTDRV(chip, ch);
                    break;
            }
        }

        private void getInstChForFMP7(vgm.enmUseChip chip, int ch)
        {

            string n = "";

            if (chip == vgm.enmUseChip.YM2612 || chip == vgm.enmUseChip.YM2608)
            {
                int p = (ch > 2) ? 1 : 0;
                int c = (ch > 2) ? ch - 3 : ch;
                int[][] fmRegister = (chip == vgm.enmUseChip.YM2612) ? Audio.GetFMRegister() : Audio.GetYM2608Register();

                n = "'@ FA xx\r\n   AR  DR  SR  RR  SL  TL  KS  ML  DT  AM\r\n";

                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 8 : ((i == 2) ? 4 : 12));
                    n += string.Format("'@ {0:D3},{1:D3},{2:D3},{3:D3},{4:D3},{5:D3},{6:D3},{7:D3},{8:D3},{9:D3}\r\n"
                        , fmRegister[p][0x50 + ops + c] & 0x1f //AR
                        , fmRegister[p][0x60 + ops + c] & 0x1f //DR
                        , fmRegister[p][0x70 + ops + c] & 0x1f //SR
                        , fmRegister[p][0x80 + ops + c] & 0x0f //RR
                        , (fmRegister[p][0x80 + ops + c] & 0xf0) >> 4//SL
                        , fmRegister[p][0x40 + ops + c] & 0x7f//TL
                        , (fmRegister[p][0x50 + ops + c] & 0xc0) >> 6//KS
                        , fmRegister[p][0x30 + ops + c] & 0x0f//ML
                        , (fmRegister[p][0x30 + ops + c] & 0x70) >> 4//DT
                        , (fmRegister[p][0x60 + ops + c] & 0x80) >> 7//AM
                    );
                }
                n += "   ALG FB\r\n";
                n += string.Format("'@ {0:D3},{1:D3}\r\n"
                    , fmRegister[p][0xb0 + c] & 0x07//AL
                    , (fmRegister[p][0xb0 + c] & 0x38) >> 3//FB
                );
            }
            else if (chip == vgm.enmUseChip.YM2151)
            {
                int[] ym2151Register = Audio.GetYM2151Register();
                n = "'@ FC xx\r\n   AR  DR  SR  RR  SL  TL  KS  ML  DT1 DT2 AM\r\n";

                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 16 : ((i == 2) ? 8 : 24));
                    n += string.Format("'@ {0:D3},{1:D3},{2:D3},{3:D3},{4:D3},{5:D3},{6:D3},{7:D3},{8:D3},{9:D3},{10:D3}\r\n"
                        , ym2151Register[0x80 + ops + ch] & 0x1f //AR
                        , ym2151Register[0xa0 + ops + ch] & 0x1f //DR
                        , ym2151Register[0xc0 + ops + ch] & 0x1f //SR
                        , ym2151Register[0xe0 + ops + ch] & 0x0f //RR
                        , (ym2151Register[0xe0 + ops + ch] & 0xf0) >> 4 //SL
                        , ym2151Register[0x60 + ops + ch] & 0x7f //TL
                        , (ym2151Register[0x80 + ops + ch] & 0xc0) >> 6 //KS
                        , ym2151Register[0x40 + ops + ch] & 0x0f //ML
                        , (ym2151Register[0x40 + ops + ch] & 0x70) >> 4 //DT
                        , (ym2151Register[0xc0 + ops + ch] & 0xc0) >> 6 //DT2
                        , (ym2151Register[0xa0 + ops + ch] & 0x80) >> 7 //AM
                    );
                }
                n += "   ALG FB\r\n";
                n += string.Format("'@ {0:D3},{1:D3}\r\n"
                    , ym2151Register[0x20 + ch] & 0x07 //AL
                    , (ym2151Register[0x20 + ch] & 0x38) >> 3//FB
                );
            }

            Clipboard.SetText(n);
        }

        private void getInstChForMDX(vgm.enmUseChip chip, int ch)
        {

            string n = "";

            if (chip == vgm.enmUseChip.YM2612 || chip == vgm.enmUseChip.YM2608)
            {
                int p = (ch > 2) ? 1 : 0;
                int c = (ch > 2) ? ch - 3 : ch;
                int[][] fmRegister = (chip == vgm.enmUseChip.YM2612) ? Audio.GetFMRegister() : Audio.GetYM2608Register();

                n = "'@xx = {\r\n/* AR  DR  SR  RR  SL  TL  KS  ML  DT1 DT2 AME\r\n";

                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 8 : ((i == 2) ? 4 : 12));
                    n += string.Format("   {0:D3},{1:D3},{2:D3},{3:D3},{4:D3},{5:D3},{6:D3},{7:D3},{8:D3},{9:D3},{10:D3}\r\n"
                        , fmRegister[p][0x50 + ops + c] & 0x1f //AR
                        , fmRegister[p][0x60 + ops + c] & 0x1f //DR
                        , fmRegister[p][0x70 + ops + c] & 0x1f //SR
                        , fmRegister[p][0x80 + ops + c] & 0x0f //RR
                        , (fmRegister[p][0x80 + ops + c] & 0xf0) >> 4//SL
                        , fmRegister[p][0x40 + ops + c] & 0x7f//TL
                        , (fmRegister[p][0x50 + ops + c] & 0xc0) >> 6//KS
                        , fmRegister[p][0x30 + ops + c] & 0x0f//ML
                        , (fmRegister[p][0x30 + ops + c] & 0x70) >> 4//DT
                        , 0
                        , (fmRegister[p][0x60 + ops + c] & 0x80) >> 7//AM
                    );
                }
                n += "/* ALG FB  OP\r\n";
                n += string.Format("   {0:D3},{1:D3},15\r\n}}\r\n"
                    , fmRegister[p][0xb0 + c] & 0x07//AL
                    , (fmRegister[p][0xb0 + c] & 0x38) >> 3//FB
                );
            }
            else if (chip == vgm.enmUseChip.YM2151)
            {
                int[] ym2151Register = Audio.GetYM2151Register();

                n = "'@xx = {\r\n/* AR  DR  SR  RR  SL  TL  KS  ML  DT1 DT2 AME\r\n";

                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 16 : ((i == 2) ? 8 : 24));
                    n += string.Format("   {0:D3},{1:D3},{2:D3},{3:D3},{4:D3},{5:D3},{6:D3},{7:D3},{8:D3},{9:D3},{10:D3}\r\n"
                        , ym2151Register[0x80 + ops + ch] & 0x1f //AR
                        , ym2151Register[0xa0 + ops + ch] & 0x1f //DR
                        , ym2151Register[0xc0 + ops + ch] & 0x1f //SR
                        , ym2151Register[0xe0 + ops + ch] & 0x0f //RR
                        , (ym2151Register[0xe0 + ops + ch] & 0xf0) >> 4 //SL
                        , ym2151Register[0x60 + ops + ch] & 0x7f //TL
                        , (ym2151Register[0x80 + ops + ch] & 0xc0) >> 6 //KS
                        , ym2151Register[0x40 + ops + ch] & 0x0f //ML
                        , (ym2151Register[0x40 + ops + ch] & 0x70) >> 4 //DT
                        , (ym2151Register[0xc0 + ops + ch] & 0xc0) >> 6 //DT2
                        , (ym2151Register[0xa0 + ops + ch] & 0x80) >> 7 //AM
                    );
                }
                n += "/* ALG FB  OP\r\n";
                n += string.Format("   {0:D3},{1:D3},15\r\n}}\r\n"
                    , ym2151Register[0x20 + ch] & 0x07 //AL
                    , (ym2151Register[0x20 + ch] & 0x38) >> 3//FB
                );
            }

            Clipboard.SetText(n);
        }

        private void getInstChForMML2VGM(vgm.enmUseChip chip, int ch)
        {

            string n = "";

            if (chip == vgm.enmUseChip.YM2612 || chip == vgm.enmUseChip.YM2608)
            {
                int p = (ch > 2) ? 1 : 0;
                int c = (ch > 2) ? ch - 3 : ch;
                int[][] fmRegister = (chip == vgm.enmUseChip.YM2612) ? Audio.GetFMRegister() : Audio.GetYM2608Register();

                n = "'@ M xx\r\n   AR  DR  SR  RR  SL  TL  KS  ML  DT  AM  SSG-EG\r\n";

                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 8 : ((i == 2) ? 4 : 12));
                    n += string.Format("'@ {0:D3},{1:D3},{2:D3},{3:D3},{4:D3},{5:D3},{6:D3},{7:D3},{8:D3},{9:D3},{10:D3}\r\n"
                        , fmRegister[p][0x50 + ops + c] & 0x1f //AR
                        , fmRegister[p][0x60 + ops + c] & 0x1f //DR
                        , fmRegister[p][0x70 + ops + c] & 0x1f //SR
                        , fmRegister[p][0x80 + ops + c] & 0x0f //RR
                        , (fmRegister[p][0x80 + ops + c] & 0xf0) >> 4//SL
                        , fmRegister[p][0x40 + ops + c] & 0x7f//TL
                        , (fmRegister[p][0x50 + ops + c] & 0xc0) >> 6//KS
                        , fmRegister[p][0x30 + ops + c] & 0x0f//ML
                        , (fmRegister[p][0x30 + ops + c] & 0x70) >> 4//DT
                        , (fmRegister[p][0x60 + ops + c] & 0x80) >> 7//AM
                        , fmRegister[p][0x90 + ops + c] & 0x0f//SG
                    );
                }
                n += "   ALG FB\r\n";
                n += string.Format("'@ {0:D3},{1:D3}\r\n"
                    , fmRegister[p][0xb0 + c] & 0x07//AL
                    , (fmRegister[p][0xb0 + c] & 0x38) >> 3//FB
                );
            }
            else if (chip == vgm.enmUseChip.YM2151)
            {
                int[] ym2151Register = Audio.GetYM2151Register();
                n = "'@ M xx\r\n   AR  DR  SR  RR  SL  TL  KS  ML  DT  AM  SSG-EG\r\n";

                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 16 : ((i == 2) ? 8 : 24));
                    n += string.Format("'@ {0:D3},{1:D3},{2:D3},{3:D3},{4:D3},{5:D3},{6:D3},{7:D3},{8:D3},{9:D3},{10:D3}\r\n"
                        , ym2151Register[0x80 + ops + ch] & 0x1f //AR
                        , ym2151Register[0xa0 + ops + ch] & 0x1f //DR
                        , ym2151Register[0xc0 + ops + ch] & 0x1f //SR
                        , ym2151Register[0xe0 + ops + ch] & 0x0f //RR
                        , (ym2151Register[0xe0 + ops + ch] & 0xf0) >> 4 //SL
                        , ym2151Register[0x60 + ops + ch] & 0x7f //TL
                        , (ym2151Register[0x80 + ops + ch] & 0xc0) >> 6 //KS
                        , ym2151Register[0x40 + ops + ch] & 0x0f //ML
                        , (ym2151Register[0x40 + ops + ch] & 0x70) >> 4 //DT
                        , (ym2151Register[0xa0 + ops + ch] & 0x80) >> 7 //AM
                        , 0
                    );
                }
                n += "   ALG FB\r\n";
                n += string.Format("'@ {0:D3},{1:D3}\r\n"
                    , ym2151Register[0x20 + ch] & 0x07 //AL
                    , (ym2151Register[0x20 + ch] & 0x38) >> 3//FB
                );
            }

            Clipboard.SetText(n);
        }

        private void getInstChForMUSICLALF(vgm.enmUseChip chip, int ch)
        {

            string n = "";

            if (chip == vgm.enmUseChip.YM2612 || chip == vgm.enmUseChip.YM2608)
            {
                int p = (ch > 2) ? 1 : 0;
                int c = (ch > 2) ? ch - 3 : ch;
                int[][] fmRegister = (chip == vgm.enmUseChip.YM2612) ? Audio.GetFMRegister() : Audio.GetYM2608Register();

                n = string.Format("@xx:{{\r\n  {0:D3} {1:D3}\r\n"
                    , fmRegister[p][0xb0 + c] & 0x07//AL
                    , (fmRegister[p][0xb0 + c] & 0x38) >> 3//FB
                    );

                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 8 : ((i == 2) ? 4 : 12));
                    n += string.Format("  {0:D3} {1:D3} {2:D3} {3:D3} {4:D3} {5:D3} {6:D3} {7:D3} {8:D3}\r\n"
                        , fmRegister[p][0x50 + ops + c] & 0x1f //AR
                        , fmRegister[p][0x60 + ops + c] & 0x1f //DR
                        , fmRegister[p][0x70 + ops + c] & 0x1f //SR
                        , fmRegister[p][0x80 + ops + c] & 0x0f //RR
                        , (fmRegister[p][0x80 + ops + c] & 0xf0) >> 4//SL
                        , fmRegister[p][0x40 + ops + c] & 0x7f//TL
                        , (fmRegister[p][0x50 + ops + c] & 0xc0) >> 6//KS
                        , fmRegister[p][0x30 + ops + c] & 0x0f//ML
                        , (fmRegister[p][0x30 + ops + c] & 0x70) >> 4//DT
                    );
                }
                n += "}\r\n";
            }
            else if (chip == vgm.enmUseChip.YM2151)
            {
                int[] ym2151Register = Audio.GetYM2151Register();

                n = string.Format("@xx:{{\r\n  {0:D3} {1:D3}\r\n"
                    , ym2151Register[0x20 + ch] & 0x07 //AL
                    , (ym2151Register[0x20 + ch] & 0x38) >> 3//FB
                    );

                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 16 : ((i == 2) ? 8 : 24));
                    n += string.Format("  {0:D3} {1:D3} {2:D3} {3:D3} {4:D3} {5:D3} {6:D3} {7:D3} {8:D3}\r\n"
                        , ym2151Register[0x80 + ops + ch] & 0x1f //AR
                        , ym2151Register[0xa0 + ops + ch] & 0x1f //DR
                        , ym2151Register[0xc0 + ops + ch] & 0x1f //SR
                        , ym2151Register[0xe0 + ops + ch] & 0x0f //RR
                        , (ym2151Register[0xe0 + ops + ch] & 0xf0) >> 4 //SL
                        , ym2151Register[0x60 + ops + ch] & 0x7f //TL
                        , (ym2151Register[0x80 + ops + ch] & 0xc0) >> 6 //KS
                        , ym2151Register[0x40 + ops + ch] & 0x0f //ML
                        , (ym2151Register[0x40 + ops + ch] & 0x70) >> 4 //DT
                    );
                }
                n += "}\r\n";
            }

            Clipboard.SetText(n);
        }

        private void getInstChForMUSICLALF2(vgm.enmUseChip chip, int ch)
        {

            string n = "";

            if (chip == vgm.enmUseChip.YM2612 || chip == vgm.enmUseChip.YM2608)
            {
                int p = (ch > 2) ? 1 : 0;
                int c = (ch > 2) ? ch - 3 : ch;
                int[][] fmRegister = (chip == vgm.enmUseChip.YM2612) ? Audio.GetFMRegister() : Audio.GetYM2608Register();

                n = "@%xxx\r\n";

                for (int i = 0; i < 6; i++)
                {
                    n += string.Format("${0:X3},${1:X3},${2:X3},${3:X3}\r\n"
                        , fmRegister[p][0x30 + 0 + c + i * 0x10] & 0xff
                        , fmRegister[p][0x30 + 8 + c + i * 0x10] & 0xff
                        , fmRegister[p][0x30 + 16 + c + i * 0x10] & 0xff
                        , fmRegister[p][0x30 + 24 + c + i * 0x10] & 0xff
                    );
                }
                n += string.Format("${0:X3}\r\n"
                    , fmRegister[p][0xb0 + c] //FB/AL
                    );
            }
            else if (chip == vgm.enmUseChip.YM2151)
            {
                int[] ym2151Register = Audio.GetYM2151Register();

                n = "@%xxx\r\n";

                n += string.Format("${0:X3},${1:X3},${2:X3},${3:X3}\r\n"
                    , (ym2151Register[0x40 + 0 + ch] & 0x7f) //DT/ML
                    , (ym2151Register[0x40 + 8 + ch] & 0x7f) //DT/ML
                    , (ym2151Register[0x40 + 16 + ch] & 0x7f)//DT/ML
                    , (ym2151Register[0x40 + 24 + ch] & 0x7f)//DT/ML
                );
                n += string.Format("${0:X3},${1:X3},${2:X3},${3:X3}\r\n"
                    , (ym2151Register[0x60 + 0 + ch] & 0x7f) //TL
                    , (ym2151Register[0x60 + 8 + ch] & 0x7f) //TL
                    , (ym2151Register[0x60 + 16 + ch] & 0x7f)//TL
                    , (ym2151Register[0x60 + 24 + ch] & 0x7f)//TL
                );
                n += string.Format("${0:X3},${1:X3},${2:X3},${3:X3}\r\n"
                    , (ym2151Register[0x80 + 0 + ch] & 0xdf) //KS/AR
                    , (ym2151Register[0x80 + 8 + ch] & 0xdf) //KS/AR
                    , (ym2151Register[0x80 + 16 + ch] & 0xdf)//KS/AR
                    , (ym2151Register[0x80 + 24 + ch] & 0xdf)//KS/AR
                );
                n += string.Format("${0:X3},${1:X3},${2:X3},${3:X3}\r\n"
                    , (ym2151Register[0xa0 + 0 + ch] & 0x9f) //AM/DR
                    , (ym2151Register[0xa0 + 8 + ch] & 0x9f) //AM/DR
                    , (ym2151Register[0xa0 + 16 + ch] & 0x9f)//AM/DR
                    , (ym2151Register[0xa0 + 24 + ch] & 0x9f)//AM/DR
                );
                n += string.Format("${0:X3},${1:X3},${2:X3},${3:X3}\r\n"
                    , (ym2151Register[0xc0 + 0 + ch] & 0x1f) //SR
                    , (ym2151Register[0xc0 + 8 + ch] & 0x1f) //SR
                    , (ym2151Register[0xc0 + 16 + ch] & 0x1f)//SR
                    , (ym2151Register[0xc0 + 24 + ch] & 0x1f)//SR
                );
                n += string.Format("${0:X3},${1:X3},${2:X3},${3:X3}\r\n"
                    , (ym2151Register[0xe0 + 0 + ch] & 0xff) //SL/RR
                    , (ym2151Register[0xe0 + 8 + ch] & 0xff) //SL/RR
                    , (ym2151Register[0xe0 + 16 + ch] & 0xff)//SL/RR
                    , (ym2151Register[0xe0 + 24 + ch] & 0xff)//SL/RR
                );

                n += string.Format("${0:X3}\r\n"
                    , ym2151Register[0x20 + ch] //FB/AL
                    );
            }

            Clipboard.SetText(n);
        }

        private void getInstChForNRTDRV(vgm.enmUseChip chip, int ch)
        {

            string n = "";

            if (chip == vgm.enmUseChip.YM2612 || chip == vgm.enmUseChip.YM2608)
            {
                int p = (ch > 2) ? 1 : 0;
                int c = (ch > 2) ? ch - 3 : ch;
                int[][] fmRegister = (chip == vgm.enmUseChip.YM2612) ? Audio.GetFMRegister() : Audio.GetYM2608Register();

                n = "@ xxxx {\r\n";
                n += string.Format("000,{0:D3},{1:D3},015\r\n"
                    , fmRegister[p][0xb0 + c] & 0x07//AL
                    , (fmRegister[p][0xb0 + c] & 0x38) >> 3//FB
                );

                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 8 : ((i == 2) ? 4 : 12));
                    n += string.Format(" {0:D3},{1:D3},{2:D3},{3:D3},{4:D3},{5:D3},{6:D3},{7:D3},{8:D3},{9:D3},{10:D3}\r\n"
                        , fmRegister[p][0x50 + ops + c] & 0x1f //AR
                        , fmRegister[p][0x60 + ops + c] & 0x1f //DR
                        , fmRegister[p][0x70 + ops + c] & 0x1f //SR
                        , fmRegister[p][0x80 + ops + c] & 0x0f //RR
                        , (fmRegister[p][0x80 + ops + c] & 0xf0) >> 4//SL
                        , fmRegister[p][0x40 + ops + c] & 0x7f//TL
                        , (fmRegister[p][0x50 + ops + c] & 0xc0) >> 6//KS
                        , fmRegister[p][0x30 + ops + c] & 0x0f//ML
                        , (fmRegister[p][0x30 + ops + c] & 0x70) >> 4//DT
                        , 0
                        , (fmRegister[p][0x60 + ops + c] & 0x80) >> 7//AM
                    );
                }
                n += "}\r\n";
            }
            else if (chip == vgm.enmUseChip.YM2151)
            {
                int[] ym2151Register = Audio.GetYM2151Register();

                n = "@ xxxx {\r\n";
                n += string.Format("000,{0:D3},{1:D3},015\r\n"
                    , ym2151Register[0x20 + ch] & 0x07 //AL
                    , (ym2151Register[0x20 + ch] & 0x38) >> 3//FB
                );

                for (int i = 0; i < 4; i++)
                {
                    int ops = (i == 0) ? 0 : ((i == 1) ? 16 : ((i == 2) ? 8 : 24));
                    n += string.Format(" {0:D3},{1:D3},{2:D3},{3:D3},{4:D3},{5:D3},{6:D3},{7:D3},{8:D3},{9:D3},{10:D3}\r\n"
                        , ym2151Register[0x80 + ops + ch] & 0x1f //AR
                        , ym2151Register[0xa0 + ops + ch] & 0x1f //DR
                        , ym2151Register[0xc0 + ops + ch] & 0x1f //SR
                        , ym2151Register[0xe0 + ops + ch] & 0x0f //RR
                        , (ym2151Register[0xe0 + ops + ch] & 0xf0) >> 4 //SL
                        , ym2151Register[0x60 + ops + ch] & 0x7f //TL
                        , (ym2151Register[0x80 + ops + ch] & 0xc0) >> 6 //KS
                        , ym2151Register[0x40 + ops + ch] & 0x0f //ML
                        , (ym2151Register[0x40 + ops + ch] & 0x70) >> 4 //DT
                        , (ym2151Register[0xc0 + ops + ch] & 0xc0) >> 6 //DT2
                        , (ym2151Register[0xa0 + ops + ch] & 0x80) >> 7 //AM
                    );
                }
                n += "}\r\n";
            }

            Clipboard.SetText(n);
        }

        private void getInstChForTFI(vgm.enmUseChip chip, int ch)
        {

            byte[] n = new byte[42];

            if (chip == vgm.enmUseChip.YM2612 || chip == vgm.enmUseChip.YM2608)
            {
                int[][] fmRegister = (chip == vgm.enmUseChip.YM2612) ? Audio.GetFMRegister() : Audio.GetYM2608Register();
                int p = (ch > 2) ? 1 : 0;
                int c = (ch > 2) ? ch - 3 : ch;

                n[0] = (byte)(fmRegister[p][0xb0 + c] & 0x07);//AL
                n[1] = (byte)((fmRegister[p][0xb0 + c] & 0x38) >> 3);//FB


                for (int i = 0; i < 4; i++)
                {
                    //int ops = (i == 0) ? 0 : ((i == 1) ? 4 : ((i == 2) ? 8 : 12));
                    int ops = i * 4;

                    n[i * 10 + 2] = (byte)(fmRegister[p][0x30 + ops + c] & 0x0f);//ML
                    int dt = (fmRegister[p][0x30 + ops + c] & 0x70) >> 4;//DT
                    // 0>3  1>4  2>5  3>6  4>3  5>2  6>1  7>0
                    dt = (dt < 4) ? (dt + 3) : (7 - dt);
                    n[i * 10 + 3] = (byte)dt;
                    n[i * 10 + 4] = (byte)(fmRegister[p][0x40 + ops + c] & 0x7f);//TL
                    n[i * 10 + 5] = (byte)((fmRegister[p][0x50 + ops + c] & 0xc0) >> 6);//KS
                    n[i * 10 + 6] = (byte)(fmRegister[p][0x50 + ops + c] & 0x1f); //AR
                    n[i * 10 + 7] = (byte)(fmRegister[p][0x60 + ops + c] & 0x1f); //DR
                    n[i * 10 + 8] = (byte)(fmRegister[p][0x70 + ops + c] & 0x1f); //SR
                    n[i * 10 + 9] = (byte)(fmRegister[p][0x80 + ops + c] & 0x0f); //RR
                    n[i * 10 + 10] = (byte)((fmRegister[p][0x80 + ops + c] & 0xf0) >> 4);//SL
                    n[i * 10 + 11] = (byte)(fmRegister[p][0x90 + ops + c] & 0x0f);//SSG
                }

            }
            else if (chip == vgm.enmUseChip.YM2151)
            {
                int[] ym2151Register = Audio.GetYM2151Register();

                n[0] = (byte)(ym2151Register[0x20 + ch] & 0x07);//AL
                n[1] = (byte)((ym2151Register[0x20 + ch] & 0x38) >> 3);//FB

                for (int i = 0; i < 4; i++)
                {
                    //int ops = (i == 0) ? 0 : ((i == 1) ? 8 : ((i == 2) ? 16 : 24));
                    int ops = i * 8;

                    n[i * 10 + 2] = (byte)(ym2151Register[0x40 + ops + ch] & 0x0f);//ML
                    int dt = ((ym2151Register[0x40 + ops + ch] & 0x70) >> 4);//DT
                    // 0>3  1>4  2>5  3>6  4>3  5>2  6>1  7>0
                    dt = (dt < 4) ? (dt + 3) : (7-dt);
                    n[i * 10 + 3] = (byte)dt;
                    n[i * 10 + 4] = (byte)(ym2151Register[0x60 + ops + ch] & 0x7f);//TL
                    n[i * 10 + 5] = (byte)((ym2151Register[0x80 + ops + ch] & 0xc0) >> 6);//KS
                    n[i * 10 + 6] = (byte)(ym2151Register[0x80 + ops + ch] & 0x1f); //AR
                    n[i * 10 + 7] = (byte)(ym2151Register[0xa0 + ops + ch] & 0x1f); //DR
                    n[i * 10 + 8] = (byte)(ym2151Register[0xc0 + ops + ch] & 0x1f); //SR
                    n[i * 10 + 9] = (byte)(ym2151Register[0xe0 + ops + ch] & 0x0f); //RR
                    n[i * 10 + 10] = (byte)((ym2151Register[0xe0 + ops + ch] & 0xf0) >> 4);//SL
                    n[i * 10 + 11] = 0;
                }

            }

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "音色ファイル.tfi";
            sfd.Filter = "TFIファイル(*.tfi)|*.tfi|すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.Title = "名前を付けて保存";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (System.IO.FileStream fs = new System.IO.FileStream(
                sfd.FileName,
                System.IO.FileMode.Create,
                System.IO.FileAccess.Write))
            {

                fs.Write(n, 0, n.Length);

            }
        }




        //SendMessageで送る構造体（Unicode文字列送信に最適化したパターン）
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpData;
        }

        //SendMessage（データ転送）
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);
        public const int WM_COPYDATA = 0x004A;

        //SendMessageを使ってプロセス間通信で文字列を渡す
        void SendString(IntPtr targetWindowHandle, string str)
        {
            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            cds.dwData = IntPtr.Zero;
            cds.lpData = str;
            cds.cbData = str.Length * sizeof(char);
            //受信側ではlpDataの文字列を(cbData/2)の長さでstring.Substring()する

            IntPtr myWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
            SendMessage(targetWindowHandle, WM_COPYDATA, myWindowHandle, ref cds);
        }

        public void windowsMessage(ref Message m)
        {
            if (m.Msg == WM_COPYDATA)
            {
                string sParam = ReceiveString(m);
                try
                {

                    frmPlayList.Stop();

                    PlayList pl = frmPlayList.getPlayList();
                    if (pl.lstMusic.Count < 1 || pl.lstMusic[pl.lstMusic.Count - 1].fileName != sParam)
                    {
                        frmPlayList.AddList(sParam);
                    }

                    if (!loadAndPlay(sParam))
                    {
                        frmPlayList.Stop();
                        Audio.Stop();
                        return;
                    }

                    frmPlayList.setStart(-1);

                    frmPlayList.Play();

                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                    //メッセージによる読み込み失敗の場合は何も表示しない
                    //                    MessageBox.Show("ファイルの読み込みに失敗しました。");
                }
            }

        }

        //メッセージ処理
        protected override void WndProc(ref Message m)
        {
            windowsMessage(ref m);
            base.WndProc(ref m);
        }

        //SendString()で送信された文字列を取り出す
        string ReceiveString(Message m)
        {
            string str = null;
            try
            {
                COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                str = cds.lpData;
                str = str.Substring(0, cds.cbData / 2);
            }
            catch (Exception ex)
            {
                log.ForcedWrite(ex);
             str = null;
            }
            return str;
        }

        public static Process GetPreviousProcess()
        {
            Process curProcess = Process.GetCurrentProcess();
            Process[] allProcesses = Process.GetProcessesByName(curProcess.ProcessName);

            foreach (Process checkProcess in allProcesses)
            {
                // 自分自身のプロセスIDは無視する
                if (checkProcess.Id != curProcess.Id)
                {
                    // プロセスのフルパス名を比較して同じアプリケーションか検証
                    if (String.Compare(
                        checkProcess.MainModule.FileName,
                        curProcess.MainModule.FileName, true) == 0)
                    {
                        // 同じフルパス名のプロセスを取得
                        return checkProcess;
                    }
                }
            }

            // 同じアプリケーションのプロセスが見つからない！
            return null;
        }



        private void StartMIDIInMonitoring()
        {

            //if (setting.other.MidiInDeviceName == "")
            //{
            //    return;
            //}

            //if (midiin != null)
            //{
            //    try
            //    {
            //        midiin.Stop();
            //        midiin.Dispose();
            //        midiin.MessageReceived -= midiIn_MessageReceived;
            //        midiin.ErrorReceived -= midiIn_ErrorReceived;
            //        midiin = null;
            //    }
            //    catch
            //    {
            //        midiin = null;
            //    }
            //}

            //if (midiin == null)
            //{
            //    for (int i = 0; i < MidiIn.NumberOfDevices; i++)
            //    {
            //        if (setting.other.MidiInDeviceName == MidiIn.DeviceInfo(i).ProductName)
            //        {
            //            try
            //            {
            //                midiin = new MidiIn(i);
            //                midiin.MessageReceived += midiIn_MessageReceived;
            //                midiin.ErrorReceived += midiIn_ErrorReceived;
            //                midiin.Start();
            //            }
            //            catch
            //            {
            //                midiin = null;
            //            }
            //        }
            //    }
            //}

        }

        void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            //            Console.WriteLine(String.Format("Error Time {0} Message 0x{1:X8} Event {2}",
            //                e.Timestamp, e.RawMessage, e.MidiEvent));
        }

        private void StopMIDIInMonitoring()
        {
            //if (midiin != null)
            //{
            //    try
            //    {
            //        midiin.Stop();
            //        midiin.Dispose();
            //        midiin.MessageReceived -= midiIn_MessageReceived;
            //        midiin.ErrorReceived -= midiIn_ErrorReceived;
            //        midiin = null;
            //    }
            //    catch
            //    {
            //        midiin = null;
            //    }
            //}
        }

        void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn || e.MidiEvent.CommandCode == MidiCommandCode.NoteOff)
            {
                //Console.WriteLine(String.Format("Time {0} Message 0x{1:X8} Event {2}",
                //    e.Timestamp, e.RawMessage, e.MidiEvent));
            }
        }

        public bool loadAndPlay(string fn,string zfn=null)
        {
            try
            {
                if (Audio.isPaused)
                {
                    Audio.Pause();
                }

                if (zfn == null || zfn == "")
                {
                    srcBuf = getAllBytes(fn);
                }
                else
                {
                    using (ZipArchive archive = ZipFile.OpenRead(zfn))
                    {
                        ZipArchiveEntry entry = archive.GetEntry(fn);
                        if (entry.FullName.EndsWith(".vgm", StringComparison.OrdinalIgnoreCase) || entry.FullName.EndsWith(".vgz", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine(entry.FullName);
                            using (BinaryReader reader = new BinaryReader(entry.Open()))
                            {
                                srcBuf = reader.ReadBytes((int)entry.Length);
                            }

                            uint vgm = (UInt32)srcBuf[0] + (UInt32)srcBuf[1] * 0x100 + (UInt32)srcBuf[2] * 0x10000 + (UInt32)srcBuf[3] * 0x1000000;
                            if (vgm != FCC_VGM)
                            {
                                int num;
                                srcBuf = new byte[1024]; // 1Kbytesずつ処理する

                                Stream inStream // 入力ストリーム
                                  = entry.Open();

                                GZipStream decompStream // 解凍ストリーム
                                  = new GZipStream(
                                    inStream, // 入力元となるストリームを指定
                                    CompressionMode.Decompress); // 解凍（圧縮解除）を指定

                                MemoryStream outStream // 出力ストリーム
                                  = new MemoryStream();

                                using (inStream)
                                using (outStream)
                                using (decompStream)
                                {
                                    while ((num = decompStream.Read(srcBuf, 0, srcBuf.Length)) > 0)
                                    {
                                        outStream.Write(srcBuf, 0, num);
                                    }
                                }

                                srcBuf = outStream.ToArray();
                            }

                        }
                    }
                }

                Audio.SetVGMBuffer(srcBuf);

                if (srcBuf != null)
                {
                    this.Invoke((Action)playdata);
                }

            }
            catch (Exception ex)
            {
                log.ForcedWrite(ex);
                srcBuf = null;
                MessageBox.Show("ファイルの読み込みに失敗しました。", "MDPlayer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        public void SetChannelMask(vgm.enmUseChip chip, int ch)
        {
            switch (chip)
            {
                case vgm.enmUseChip.YM2612:
                    if (ch >= 0 && ch < 6)
                    {
                        if (!newParam.ym2612.channels[ch].mask)
                        {
                            Audio.setFMMask(ch);

                        }
                        else
                        {
                            Audio.resetFMMask(ch);
                        }
                        newParam.ym2612.channels[ch].mask = !newParam.ym2612.channels[ch].mask;
                        if (ch == 2)
                        {
                            newParam.ym2612.channels[6].mask = newParam.ym2612.channels[2].mask;
                            newParam.ym2612.channels[7].mask = newParam.ym2612.channels[2].mask;
                            newParam.ym2612.channels[8].mask = newParam.ym2612.channels[2].mask;
                        }
                    }
                    else if (ch < 9)
                    {
                        if (!newParam.ym2612.channels[2].mask)
                        {
                            Audio.setFMMask(2);

                        }
                        else
                        {
                            Audio.resetFMMask(2);
                        }
                        newParam.ym2612.channels[2].mask = !newParam.ym2612.channels[2].mask;
                        newParam.ym2612.channels[6].mask = newParam.ym2612.channels[2].mask;
                        newParam.ym2612.channels[7].mask = newParam.ym2612.channels[2].mask;
                        newParam.ym2612.channels[8].mask = newParam.ym2612.channels[2].mask;
                    }
                    break;
                case vgm.enmUseChip.SN76489:
                    if (!newParam.sn76489.channels[ch].mask)
                    {
                        Audio.setPSGMask(ch);

                    }
                    else
                    {
                        Audio.resetPSGMask(ch);
                    }
                    newParam.sn76489.channels[ch].mask = !newParam.sn76489.channels[ch].mask;
                    break;
                case vgm.enmUseChip.RF5C164:
                    if (!newParam.rf5c164.channels[ch].mask)
                    {
                        Audio.setRF5C164Mask(ch);
                    }
                    else
                    {
                        Audio.resetRF5C164Mask(ch);
                    }
                    newParam.rf5c164.channels[ch].mask = !newParam.rf5c164.channels[ch].mask;
                    break;
                case vgm.enmUseChip.YM2151:
                    if (!newParam.ym2151.channels[ch].mask)
                    {
                        Audio.setYM2151Mask(ch);
                    }
                    else
                    {
                        Audio.resetYM2151Mask(ch);
                    }
                    newParam.ym2151.channels[ch].mask = !newParam.ym2151.channels[ch].mask;
                    break;
            }
        }

        public void ResetChannelMask(vgm.enmUseChip chip, int ch)
        {
            switch (chip)
            {
                case vgm.enmUseChip.YM2612:
                    newParam.ym2612.channels[ch].mask = false;
                    if (ch < 6) Audio.resetFMMask(ch);
                    break;
                case vgm.enmUseChip.SN76489:
                    newParam.sn76489.channels[ch].mask = false;
                    Audio.resetPSGMask(ch);
                    break;
                case vgm.enmUseChip.RF5C164:
                    newParam.rf5c164.channels[ch].mask = false;
                    Audio.resetRF5C164Mask(ch);
                    break;
                case vgm.enmUseChip.YM2151:
                    newParam.ym2151.channels[ch].mask = false;
                    Audio.resetYM2151Mask(ch);
                    break;
                case vgm.enmUseChip.YM2608:
                    newParam.ym2608.channels[ch].mask = false;
                    Audio.resetYM2608Mask(ch);
                    break;

            }
        }

    }
}
