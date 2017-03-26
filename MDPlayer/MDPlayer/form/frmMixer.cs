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
    public partial class frmMixer : Form
    {
        public bool isClosed = false;
        public int x = -1;
        public int y = -1;
        public frmMain frmMain = null;
        public Setting setting = null;

        public Setting.Balance balance = null;

        public frmMixer(Setting setting)
        {
            InitializeComponent();
            this.Visible = false;

            bsMaster.DataSource = new BindData();
            bsYM2151.DataSource = new BindData();
            bsYM2203.DataSource = new BindData();
            bsYM2203FM.DataSource = new BindData();
            bsYM2203PSG.DataSource = new BindData();
            bsYM2608.DataSource = new BindData();
            bsYM2608FM.DataSource = new BindData();
            bsYM2608PSG.DataSource = new BindData();
            bsYM2608Rhythm.DataSource = new BindData();
            bsYM2608Adpcm.DataSource = new BindData();
            bsYM2610.DataSource = new BindData();
            bsYM2610FM.DataSource = new BindData();
            bsYM2610PSG.DataSource = new BindData();
            bsYM2610AdpcmA.DataSource = new BindData();
            bsYM2610AdpcmB.DataSource = new BindData();
            bsYM2612.DataSource = new BindData();
            bsSN76489.DataSource = new BindData();
            bsRF5C164.DataSource = new BindData();
            bsPWM.DataSource = new BindData();
            bsOKIM6258.DataSource = new BindData();
            bsOKIM6295.DataSource = new BindData();
            bsC140.DataSource = new BindData();
            bsSegaPCM.DataSource = new BindData();
            bsYM2413.DataSource = new BindData();
            bsAY8910.DataSource = new BindData();
            bsHuC6280.DataSource = new BindData();

            this.balance = setting.balance;
            this.setting = setting;

            ((BindData)(bsMaster.DataSource)).Value = balance.MasterVolume;
            ((BindData)(bsYM2151.DataSource)).Value = balance.YM2151Volume;
            ((BindData)(bsYM2203.DataSource)).Value = balance.YM2203Volume;
            ((BindData)(bsYM2203FM.DataSource)).Value = balance.YM2203FMVolume;
            ((BindData)(bsYM2203PSG.DataSource)).Value = balance.YM2203PSGVolume;
            ((BindData)(bsYM2608.DataSource)).Value = balance.YM2608Volume;
            ((BindData)(bsYM2608FM.DataSource)).Value = balance.YM2608FMVolume;
            ((BindData)(bsYM2608PSG.DataSource)).Value = balance.YM2608PSGVolume;
            ((BindData)(bsYM2608Rhythm.DataSource)).Value = balance.YM2608RhythmVolume;
            ((BindData)(bsYM2608Adpcm.DataSource)).Value = balance.YM2608AdpcmVolume;
            ((BindData)(bsYM2610.DataSource)).Value = balance.YM2610Volume;
            ((BindData)(bsYM2610FM.DataSource)).Value = balance.YM2610FMVolume;
            ((BindData)(bsYM2610PSG.DataSource)).Value = balance.YM2610PSGVolume;
            ((BindData)(bsYM2610AdpcmA.DataSource)).Value = balance.YM2610AdpcmAVolume;
            ((BindData)(bsYM2610AdpcmB.DataSource)).Value = balance.YM2610AdpcmBVolume;
            ((BindData)(bsYM2612.DataSource)).Value = balance.YM2612Volume;
            ((BindData)(bsSN76489.DataSource)).Value = balance.SN76489Volume;
            ((BindData)(bsRF5C164.DataSource)).Value = balance.RF5C164Volume;
            ((BindData)(bsPWM.DataSource)).Value = balance.PWMVolume;
            ((BindData)(bsOKIM6258.DataSource)).Value = balance.OKIM6258Volume;
            ((BindData)(bsOKIM6295.DataSource)).Value = balance.OKIM6295Volume;
            ((BindData)(bsC140.DataSource)).Value = balance.C140Volume;
            ((BindData)(bsSegaPCM.DataSource)).Value = balance.SEGAPCMVolume;
            ((BindData)(bsYM2413.DataSource)).Value = balance.YM2413Volume;
            ((BindData)(bsAY8910.DataSource)).Value = balance.AY8910Volume;
            ((BindData)(bsHuC6280.DataSource)).Value = balance.HuC6280Volume;

        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        private void frmMixer_Shown(object sender, EventArgs e)
        {
            getValues();
        }

        private void frmMixer_Load(object sender, EventArgs e)
        {
            this.Location = new Point(setting.location.PMixer.X, setting.location.PMixer.Y);
            this.Size = new Size(setting.location.PMixerWH.X, setting.location.PMixerWH.Y);
        }

        private void frmMixer_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosed = true;
            setting.location.PMixer = this.Location;
            setting.location.PMixerWH = new Point(this.Width, this.Height);
            this.Visible = false;
            e.Cancel = true;
        }

        private void frmMixer_FormClosed(object sender, FormClosedEventArgs e)
        {
            getValues();
        }

        private void getValues()
        {
            balance.MasterVolume = trkMaster.Value;
            balance.YM2151Volume = trkYM2151.Value;
            balance.YM2203Volume = trkYM2203.Value;
            balance.YM2203FMVolume = trkYM2203FM.Value;
            balance.YM2203PSGVolume = trkYM2203PSG.Value;
            balance.YM2608Volume = trkYM2608.Value;
            balance.YM2608FMVolume = trkYM2608FM.Value;
            balance.YM2608PSGVolume = trkYM2608PSG.Value;
            balance.YM2608RhythmVolume = trkYM2608Rhythm.Value;
            balance.YM2608AdpcmVolume = trkYM2608Adpcm.Value;
            balance.YM2610Volume = trkYM2610.Value;
            balance.YM2610FMVolume = trkYM2610FM.Value;
            balance.YM2610PSGVolume = trkYM2610PSG.Value;
            balance.YM2610AdpcmAVolume = trkYM2610AdpcmA.Value;
            balance.YM2610AdpcmBVolume = trkYM2610AdpcmB.Value;
            balance.YM2612Volume = trkYM2612.Value;
            balance.SN76489Volume = trkSN76489.Value;
            balance.RF5C164Volume = trkRF5C164.Value;
            balance.PWMVolume = trkPWM.Value;
            balance.OKIM6258Volume = trkOKIM6258.Value;
            balance.OKIM6295Volume = trkOKIM6295.Value;
            balance.C140Volume = trkC140.Value;
            balance.SEGAPCMVolume = trkSegaPCM.Value;
            balance.YM2413Volume = trkYM2413.Value;
            balance.AY8910Volume = trkAY8910.Value;
            balance.HuC6280Volume = trkHuC6280.Value;
        }

        private void splitContainer1_Panel2_Layout(object sender, LayoutEventArgs e)
        {
            ((SplitterPanel)sender).VerticalScroll.Enabled=false;
        }


        private void bsMaster_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.MasterVolume = trkMaster.Value;
            Audio.SetMasterVolume(trkMaster.Value);
        }

        private void bsYM2151_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2151Volume = trkYM2151.Value;
            Audio.SetYM2151Volume(trkYM2151.Value);
        }

        private void bsYM2203_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2203Volume = trkYM2203.Value;
            Audio.SetYM2203Volume(trkYM2203.Value);
        }

        private void bsYM2203FM_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2203FMVolume = trkYM2203FM.Value;
            int v = trkYM2203FM.Value;
            Audio.SetYM2203FMVolume(v);

        }

        private void bsYM2203PSG_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2203PSGVolume = trkYM2203PSG.Value;
            int v = trkYM2203PSG.Value;
            Audio.SetYM2203PSGVolume(v);

        }

        private void bsYM2608_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2608Volume = trkYM2608.Value;
            Audio.SetYM2608Volume(trkYM2608.Value);
        }

        private void bsYM2608FM_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2608FMVolume = trkYM2608FM.Value;
            int v = trkYM2608FM.Value;
            Audio.SetYM2608FMVolume(v);

        }

        private void bsYM2608PSG_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2608PSGVolume = trkYM2608PSG.Value;
            int v = trkYM2608PSG.Value;
            Audio.SetYM2608PSGVolume(v);
        }

        private void bsYM2608Rhythm_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2608RhythmVolume = trkYM2608Rhythm.Value;
            int v = trkYM2608Rhythm.Value;
            Audio.SetYM2608RhythmVolume(v);
        }

        private void bsYM2608Adpcm_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2608AdpcmVolume = trkYM2608Adpcm.Value;
            int v = trkYM2608Adpcm.Value;
            Audio.SetYM2608AdpcmVolume(v);
        }

        private void bsYM2610_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2610Volume = trkYM2610.Value;
            Audio.SetYM2610Volume(trkYM2610.Value);
        }

        private void bsYM2610FM_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2610FMVolume = trkYM2610FM.Value;
            int v = trkYM2610FM.Value;
            Audio.SetYM2610FMVolume(v);

        }

        private void bsYM2610PSG_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2610PSGVolume = trkYM2610PSG.Value;
            int v = trkYM2610PSG.Value;
            Audio.SetYM2610PSGVolume(v);

        }

        private void bsYM2610AdpcmA_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2610AdpcmAVolume = trkYM2610AdpcmA.Value;
            int v = trkYM2610AdpcmA.Value;
            Audio.SetYM2610AdpcmAVolume(v);
        }

        private void bsYM2610AdpcmB_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2610AdpcmBVolume = trkYM2610AdpcmB.Value;
            int v = trkYM2610AdpcmB.Value;
            Audio.SetYM2610AdpcmBVolume(v);
        }

        private void bsYM2612_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2612Volume = trkYM2612.Value;
            Audio.SetYM2612Volume(trkYM2612.Value);
        }

        private void bsSN76489_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.SN76489Volume = trkSN76489.Value;
            Audio.SetSN76489Volume(trkSN76489.Value);
        }

        private void bsRF5C164_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.RF5C164Volume = trkRF5C164.Value;
            Audio.SetRF5C164Volume(trkRF5C164.Value);
        }

        private void bsPWM_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.PWMVolume = trkPWM.Value;
            Audio.SetPWMVolume(trkPWM.Value);
        }

        private void bsOKIM6258_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.OKIM6258Volume = trkOKIM6258.Value;
            Audio.SetOKIM6258Volume(trkOKIM6258.Value);
        }

        private void bsOKIM6295_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.OKIM6295Volume = trkOKIM6295.Value;
            Audio.SetOKIM6295Volume(trkOKIM6295.Value);
        }

        private void bsC140_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.C140Volume = trkC140.Value;
            Audio.SetC140Volume(trkC140.Value);
        }

        private void bsSegaPCM_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.SEGAPCMVolume = trkSegaPCM.Value;
            Audio.SetSegaPCMVolume(trkSegaPCM.Value);
        }

        private void bsAY8910_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.AY8910Volume = trkAY8910.Value;
            Audio.SetAY8910Volume(trkAY8910.Value);
        }

        private void bsYM2413_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.YM2413Volume = trkYM2413.Value;
            Audio.SetYM2413Volume(trkYM2413.Value);
        }

        private void bsHuC6280_CurrentItemChanged(object sender, EventArgs e)
        {
            if (balance == null) return;
            balance.HuC6280Volume = trkHuC6280.Value;
            Audio.SetHuC6280Volume(trkHuC6280.Value);
        }

        private void tbMaster_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbMaster.Text, out n)) trkMaster.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2151_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2151.Text, out n)) trkYM2151.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2203_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2203.Text, out n)) trkYM2203.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2203FM_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2203FM.Text, out n)) trkYM2203FM.Value = Math.Max(Math.Min(n, 20),-192);
        }

        private void tbYM2203PSG_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2203PSG.Text, out n)) trkYM2203PSG.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2608_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2608.Text, out n)) trkYM2608.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2608FM_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2608FM.Text, out n)) trkYM2608FM.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2608PSG_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2608PSG.Text, out n)) trkYM2608PSG.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2608Rhythm_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2608Rhythm.Text, out n)) trkYM2608Rhythm.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2608Adpcm_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2608Adpcm.Text, out n)) trkYM2608Adpcm.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2610_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2610.Text, out n)) trkYM2610.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2610FM_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2610FM.Text, out n)) trkYM2610FM.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2610PSG_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2610PSG.Text, out n)) trkYM2610PSG.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2610AdpcmA_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2610AdpcmA.Text, out n)) trkYM2610AdpcmA.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2610AdpcmB_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2610AdpcmB.Text, out n)) trkYM2610AdpcmB.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2612_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2612.Text, out n)) trkYM2612.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbSN76489_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbSN76489.Text, out n)) trkSN76489.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbRF5C164_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbRF5C164.Text, out n)) trkRF5C164.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbPWM_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbPWM.Text, out n)) trkPWM.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbOKIM6258_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbOKIM6258.Text, out n)) trkOKIM6258.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbOKIM6295_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbOKIM6295.Text, out n)) trkOKIM6295.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbC140_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbC140.Text, out n)) trkC140.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbSegaPCM_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbSegaPCM.Text, out n)) trkSegaPCM.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbYM2413_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbYM2413.Text, out n)) trkYM2413.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbAY8910_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbAY8910.Text, out n)) trkAY8910.Value = Math.Max(Math.Min(n, 20), -192);
        }

        private void tbHuC6280_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(tbHuC6280.Text, out n)) trkHuC6280.Value = Math.Max(Math.Min(n, 20), -192);
        }


        private void btnMaster_Click(object sender, EventArgs e)
        {
            trkMaster.Value = 0;
        }

        private void btnYM2151_Click(object sender, EventArgs e)
        {
            trkYM2151.Value = 0;
        }

        private void btnYM2203_Click(object sender, EventArgs e)
        {
            trkYM2203.Value = 0;
        }

        private void btnYM2203FM_Click(object sender, EventArgs e)
        {
            trkYM2203FM.Value = 0;
        }

        private void btnYM2203PSG_Click(object sender, EventArgs e)
        {
            trkYM2203PSG.Value = 0;
        }

        private void btnYM2608_Click(object sender, EventArgs e)
        {
            trkYM2608.Value = 0;
        }

        private void btnYM2608FM_Click(object sender, EventArgs e)
        {
            trkYM2608FM.Value = 0;
        }

        private void btnYM2608PSG_Click(object sender, EventArgs e)
        {
            trkYM2608PSG.Value = 0;
        }

        private void btnYM2608Rhythm_Click(object sender, EventArgs e)
        {
            trkYM2608Rhythm.Value = 0;
        }

        private void bynYM2608Adpcm_Click(object sender, EventArgs e)
        {
            trkYM2608Adpcm.Value = 0;
        }

        private void btnYM2610_Click(object sender, EventArgs e)
        {
            trkYM2610.Value = 0;
        }

        private void btnYM2610FM_Click(object sender, EventArgs e)
        {
            trkYM2610FM.Value = 0;
        }

        private void btnYM2610PSG_Click(object sender, EventArgs e)
        {
            trkYM2610PSG.Value = 0;
        }

        private void btnYM2610AdpcmA_Click(object sender, EventArgs e)
        {
            trkYM2610AdpcmA.Value = 0;
        }

        private void btnYM2610AdpcmB_Click(object sender, EventArgs e)
        {
            trkYM2610AdpcmB.Value = 0;
        }

        private void btnYM2612_Click(object sender, EventArgs e)
        {
            trkYM2612.Value = 0;
        }

        private void btnSN76489_Click(object sender, EventArgs e)
        {
            trkSN76489.Value = 0;
        }

        private void btnRF5C164_Click(object sender, EventArgs e)
        {
            trkRF5C164.Value = 0;
        }

        private void btnPWM_Click(object sender, EventArgs e)
        {
            trkPWM.Value = 0;
        }

        private void btnOKIM6258_Click(object sender, EventArgs e)
        {
            trkOKIM6258.Value = 0;
        }

        private void btnOKIM6295_Click(object sender, EventArgs e)
        {
            trkOKIM6295.Value = 0;
        }

        private void btnC140_Click(object sender, EventArgs e)
        {
            trkC140.Value = 0;
        }

        private void btnSegaPCM_Click(object sender, EventArgs e)
        {
            trkSegaPCM.Value = 0;
        }

        private void btnYM2413_Click(object sender, EventArgs e)
        {
            trkYM2413.Value = 0;
        }

        private void btnAY8910_Click(object sender, EventArgs e)
        {
            trkAY8910.Value = 0;
        }

        private void btnHuC6280_Click(object sender, EventArgs e)
        {
            trkHuC6280.Value = 0;
        }

    }
}
