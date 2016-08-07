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
    public partial class frmYM2608 : Form
    {
        public bool isClosed = false;
        public int x = -1;
        public int y = -1;
        public frmMain parent = null;

        public frmYM2608(frmMain frm)
        {
            parent = frm;
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

        private void frmYM2608_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.setting.location.PYm2608 = Location;
            isClosed = true;
        }

        private void frmYM2608_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x, y);
        }

        private void frmYM2608_Resize(object sender, EventArgs e)
        {

        }

        protected override void WndProc(ref Message m)
        {
            if (parent != null)
            {
                parent.windowsMessage(ref m);
            }

            try { base.WndProc(ref m); }
            catch
            { }
        }

        public void screenChangeParams()
        {
        }

        public void screenDrawParams()
        {
        }

    }
}
