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
    public partial class frmYM2151 : Form
    {
        public bool isClosed = false;
        public int x = -1;
        public int y = -1;
        public frmMain parent = null;
        private int frameSizeW = 0;
        private int frameSizeH = 0;
        private int zoom = 1;

        public frmYM2151(frmMain frm, int zoom)
        {
            parent = frm;
            this.zoom = zoom;
            InitializeComponent();

            update();
        }

        public void update()
        {
        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        private void frmYM2151_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.setting.location.PYm2151 = Location;
            isClosed = true;
        }

        private void frmYM2151_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x, y);
            frameSizeW = this.Width - this.ClientSize.Width;
            frameSizeH = this.Height - this.ClientSize.Height;

            changeZoom();
        }

        public void changeZoom()
        {
            this.MaximumSize = new System.Drawing.Size(frameSizeW + Properties.Resources.planeE.Width * zoom, frameSizeH + Properties.Resources.planeE.Height * zoom);
            this.MinimumSize = new System.Drawing.Size(frameSizeW + Properties.Resources.planeE.Width * zoom, frameSizeH + Properties.Resources.planeE.Height * zoom);
            this.Size = new System.Drawing.Size(frameSizeW + Properties.Resources.planeE.Width * zoom, frameSizeH + Properties.Resources.planeE.Height * zoom);
            frmYM2151_Resize(null, null);
        }


        private void frmYM2151_Resize(object sender, EventArgs e)
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
        }

        public void screenDrawParams()
        {
        }

        private void pbScreen_MouseClick(object sender, MouseEventArgs e)
        {
            int ch = (e.Location.Y / 8) - 1;
            if (ch < 0) return;

            if (ch < 8)
            {
                if (e.Button == MouseButtons.Left)
                {
                    parent.SetChannelMask(vgm.enmUseChip.YM2151, ch);
                    return;
                }

                for (ch = 0; ch < 8; ch++) parent.ResetChannelMask(vgm.enmUseChip.YM2151, ch);
                return;

            }

            // 音色表示欄の判定

            int h = (e.Location.Y - 9 * 8) / (6 * 8);
            int w = Math.Min(e.Location.X / (13 * 8), 2);
            int instCh = h * 3 + w;

            if (instCh < 8)
            {
                //クリップボードに音色をコピーする
                parent.getInstCh(vgm.enmUseChip.YM2151, instCh);
            }
        }
    }
}
