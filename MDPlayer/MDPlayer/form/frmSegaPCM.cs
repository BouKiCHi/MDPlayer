﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDPlayer
{
    public partial class frmSegaPCM : Form
    {
        public bool isClosed = false;
        public int x = -1;
        public int y = -1;
        public frmMain parent = null;
        private int frameSizeW = 0;
        private int frameSizeH = 0;
        private int chipID = 0;
        private int zoom = 1;

        private MDChipParams.SegaPcm newParam = null;
        private MDChipParams.SegaPcm oldParam = new MDChipParams.SegaPcm();
        private FrameBuffer frameBuffer = new FrameBuffer();

        public frmSegaPCM(frmMain frm, int chipID, int zoom, MDChipParams.SegaPcm newParam)
        {
            parent = frm;
            this.chipID = chipID;
            this.zoom = zoom;

            InitializeComponent();

            this.newParam = newParam;
            frameBuffer.Add(pbScreen, Properties.Resources.planeSEGAPCM, null, zoom);
            DrawBuff.screenInitSegaPCM(frameBuffer);
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

        private void frmSegaPCM_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.setting.location.PosSegaPCM[chipID] = Location;
            isClosed = true;
        }

        private void frmSegaPCM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x, y);

            frameSizeW = this.Width - this.ClientSize.Width;
            frameSizeH = this.Height - this.ClientSize.Height;

            changeZoom();
        }

        public void changeZoom()
        {
            this.MaximumSize = new System.Drawing.Size(frameSizeW + Properties.Resources.planeSEGAPCM.Width * zoom, frameSizeH + Properties.Resources.planeSEGAPCM.Height * zoom);
            this.MinimumSize = new System.Drawing.Size(frameSizeW + Properties.Resources.planeSEGAPCM.Width * zoom, frameSizeH + Properties.Resources.planeSEGAPCM.Height * zoom);
            this.Size = new System.Drawing.Size(frameSizeW + Properties.Resources.planeSEGAPCM.Width * zoom, frameSizeH + Properties.Resources.planeSEGAPCM.Height * zoom);
            frmSegaPCM_Resize(null, null);

        }

        private void frmSegaPCM_Resize(object sender, EventArgs e)
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
            MDSound.segapcm.segapcm_state segapcmState = Audio.GetSegaPCMRegister(chipID);
            if (segapcmState != null && segapcmState.ram != null && segapcmState.rom != null)
            {
                for (int ch = 0; ch < 16; ch++)
                {
                    int l = segapcmState.ram[ch * 8 + 2] & 0x7f;
                    int r = segapcmState.ram[ch * 8 + 3] & 0x7f;
                    int dt = segapcmState.ram[ch * 8 + 7];
                    double ml = dt / 256.0;

                    int ptrRom = segapcmState.ptrRom + ((segapcmState.ram[ch * 8 + 0x86] & segapcmState.bankmask) << segapcmState.bankshift);
                    uint addr = (uint)((segapcmState.ram[ch * 8 + 0x85] << 16) | (segapcmState.ram[ch * 8 + 0x84] << 8) | segapcmState.low[ch]);
                    int vdt = 0;
                    if (ptrRom + ((addr >> 8) & segapcmState.rgnmask) < segapcmState.rom.Length)
                    {
                        vdt = Math.Abs((sbyte)(segapcmState.rom[ptrRom + ((addr >> 8) & segapcmState.rgnmask)]) - 0x80);
                    }
                    byte end = (byte)(segapcmState.ram[ch * 8 + 6] + 1);
                    if ((segapcmState.ram[ch * 8 + 0x86] & 1) != 0) vdt = 0;
                    if ((addr >> 16) == end)
                    {
                        if ((segapcmState.ram[ch * 8 + 0x86] & 2) == 0)
                            ml = 0;
                    }

                    newParam.channels[ch].volumeL = Math.Min(Math.Max((l * vdt) >> 8, 0), 19);
                    newParam.channels[ch].volumeR = Math.Min(Math.Max((r * vdt) >> 8, 0), 19);
                    if (newParam.channels[ch].volumeL == 0 && newParam.channels[ch].volumeR == 0)
                    {
                        ml = 0;
                    }
                    newParam.channels[ch].note = (ml == 0 || vdt == 0) ? -1 : (common.searchSegaPCMNote(ml));
                    newParam.channels[ch].pan = (r >> 3) * 0x10 + (l >> 3);
                }
            }
        }


        public void screenDrawParams()
        {
            for (int c = 0; c < 16; c++)
            {

                MDChipParams.Channel orc = oldParam.channels[c];
                MDChipParams.Channel nrc = newParam.channels[c];

                DrawBuff.Volume(frameBuffer, c, 1, ref orc.volumeL, nrc.volumeL, 0);
                DrawBuff.Volume(frameBuffer, c, 2, ref orc.volumeR, nrc.volumeR, 0);
                DrawBuff.KeyBoard(frameBuffer, c, ref orc.note, nrc.note, 0);
                DrawBuff.PanType2(frameBuffer, c, ref orc.pan, nrc.pan);

                DrawBuff.ChSegaPCM(frameBuffer, c, ref orc.mask, nrc.mask, 0);
            }
        }


        private void pbScreen_MouseClick(object sender, MouseEventArgs e)
        {
            //int px = e.Location.X / zoom;
            int py = e.Location.Y / zoom;

            int ch = (py / 8) - 1;
            if (ch < 0) return;

            if (ch < 16)
            {
                if (e.Button == MouseButtons.Left)
                {
                    parent.SetChannelMask(enmUseChip.SEGAPCM, chipID, ch);
                    return;
                }

                for (ch = 0; ch < 16; ch++) parent.ResetChannelMask(enmUseChip.SEGAPCM, chipID, ch);
                return;

            }

        }


    }
}
