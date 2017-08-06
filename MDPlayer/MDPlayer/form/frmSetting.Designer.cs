﻿namespace MDPlayer
{
    partial class frmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbWaveOut = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWaveOutDevice = new System.Windows.Forms.ComboBox();
            this.rbWaveOut = new System.Windows.Forms.RadioButton();
            this.rbAsioOut = new System.Windows.Forms.RadioButton();
            this.rbWasapiOut = new System.Windows.Forms.RadioButton();
            this.gbAsioOut = new System.Windows.Forms.GroupBox();
            this.btnASIOControlPanel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAsioDevice = new System.Windows.Forms.ComboBox();
            this.rbDirectSoundOut = new System.Windows.Forms.RadioButton();
            this.gbWasapiOut = new System.Windows.Forms.GroupBox();
            this.rbExclusive = new System.Windows.Forms.RadioButton();
            this.rbShare = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbWasapiDevice = new System.Windows.Forms.ComboBox();
            this.gbDirectSound = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDirectSoundDevice = new System.Windows.Forms.ComboBox();
            this.tcSetting = new System.Windows.Forms.TabControl();
            this.tpOutput = new System.Windows.Forms.TabPage();
            this.lblLatencyUnit = new System.Windows.Forms.Label();
            this.lblLatency = new System.Windows.Forms.Label();
            this.cmbLatency = new System.Windows.Forms.ComboBox();
            this.tpModule = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucSI = new MDPlayer.ucSettingInstruments();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbHiyorimiMode = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLatencyEmu = new System.Windows.Forms.TextBox();
            this.tbLatencySCCI = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabMIDIExp = new System.Windows.Forms.TabPage();
            this.cbUseMIDIExport = new System.Windows.Forms.CheckBox();
            this.gbMIDIExport = new System.Windows.Forms.GroupBox();
            this.cbMIDIUseVOPM = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbMIDIYM2612 = new System.Windows.Forms.CheckBox();
            this.cbMIDISN76489Sec = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2612Sec = new System.Windows.Forms.CheckBox();
            this.cbMIDISN76489 = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2151 = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2610BSec = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2151Sec = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2610B = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2203 = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2608Sec = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2203Sec = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2608 = new System.Windows.Forms.CheckBox();
            this.cbMIDIPlayless = new System.Windows.Forms.CheckBox();
            this.btnMIDIOutputPath = new System.Windows.Forms.Button();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.tbMIDIOutputPath = new System.Windows.Forms.TextBox();
            this.tpMIDIKBD = new System.Windows.Forms.TabPage();
            this.cbUseMIDIKeyboard = new System.Windows.Forms.CheckBox();
            this.gbMIDIKeyboard = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbCCFadeout = new System.Windows.Forms.TextBox();
            this.tbCCPause = new System.Windows.Forms.TextBox();
            this.tbCCSlow = new System.Windows.Forms.TextBox();
            this.tbCCPrevious = new System.Windows.Forms.TextBox();
            this.tbCCNext = new System.Windows.Forms.TextBox();
            this.tbCCFast = new System.Windows.Forms.TextBox();
            this.tbCCStop = new System.Windows.Forms.TextBox();
            this.tbCCPlay = new System.Windows.Forms.TextBox();
            this.tbCCCopyLog = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbCCDelLog = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbCCChCopy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbUseChannel = new System.Windows.Forms.GroupBox();
            this.rbMONO = new System.Windows.Forms.RadioButton();
            this.rbPOLY = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbFM6 = new System.Windows.Forms.RadioButton();
            this.rbFM3 = new System.Windows.Forms.RadioButton();
            this.rbFM5 = new System.Windows.Forms.RadioButton();
            this.rbFM2 = new System.Windows.Forms.RadioButton();
            this.rbFM4 = new System.Windows.Forms.RadioButton();
            this.rbFM1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbFM1 = new System.Windows.Forms.CheckBox();
            this.cbFM6 = new System.Windows.Forms.CheckBox();
            this.cbFM2 = new System.Windows.Forms.CheckBox();
            this.cbFM5 = new System.Windows.Forms.CheckBox();
            this.cbFM3 = new System.Windows.Forms.CheckBox();
            this.cbFM4 = new System.Windows.Forms.CheckBox();
            this.cmbMIDIIN = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tpMIDIOut = new System.Windows.Forms.TabPage();
            this.btnUP = new System.Windows.Forms.Button();
            this.btnSubMIDIout = new System.Windows.Forms.Button();
            this.btnDOWN = new System.Windows.Forms.Button();
            this.btnAddMIDIout = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvMIDIoutList = new System.Windows.Forms.DataGridView();
            this.dgvMIDIoutPallet = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.tpOther = new System.Windows.Forms.TabPage();
            this.cbUseGetInst = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbInstFormat = new System.Windows.Forms.ComboBox();
            this.lblInstFormat = new System.Windows.Forms.Label();
            this.cbWavSwitch = new System.Windows.Forms.CheckBox();
            this.cbDumpSwitch = new System.Windows.Forms.CheckBox();
            this.gbWav = new System.Windows.Forms.GroupBox();
            this.btnWavPath = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbWavPath = new System.Windows.Forms.TextBox();
            this.gbDump = new System.Windows.Forms.GroupBox();
            this.btnDumpPath = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDumpPath = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbScreenFrameRate = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.lblLoopTimes = new System.Windows.Forms.Label();
            this.btnDataPath = new System.Windows.Forms.Button();
            this.tbLoopTimes = new System.Windows.Forms.TextBox();
            this.tbDataPath = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnResetPosition = new System.Windows.Forms.Button();
            this.btnOpenSettingFolder = new System.Windows.Forms.Button();
            this.cbAutoOpen = new System.Windows.Forms.CheckBox();
            this.cbUseLoopTimes = new System.Windows.Forms.CheckBox();
            this.tpOmake = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.btVST = new System.Windows.Forms.Button();
            this.tbVST = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbDispFrameCounter = new System.Windows.Forms.CheckBox();
            this.tpAbout = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.bs9 = new System.Windows.Forms.BindingSource(this.components);
            this.bs5 = new System.Windows.Forms.BindingSource(this.components);
            this.bs8 = new System.Windows.Forms.BindingSource(this.components);
            this.bs12 = new System.Windows.Forms.BindingSource(this.components);
            this.bs1 = new System.Windows.Forms.BindingSource(this.components);
            this.bs7 = new System.Windows.Forms.BindingSource(this.components);
            this.bs3 = new System.Windows.Forms.BindingSource(this.components);
            this.bs6 = new System.Windows.Forms.BindingSource(this.components);
            this.bs2 = new System.Windows.Forms.BindingSource(this.components);
            this.bs10 = new System.Windows.Forms.BindingSource(this.components);
            this.bs11 = new System.Windows.Forms.BindingSource(this.components);
            this.bs4 = new System.Windows.Forms.BindingSource(this.components);
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSpacer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbWaveOut.SuspendLayout();
            this.gbAsioOut.SuspendLayout();
            this.gbWasapiOut.SuspendLayout();
            this.gbDirectSound.SuspendLayout();
            this.tcSetting.SuspendLayout();
            this.tpOutput.SuspendLayout();
            this.tpModule.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabMIDIExp.SuspendLayout();
            this.gbMIDIExport.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tpMIDIKBD.SuspendLayout();
            this.gbMIDIKeyboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbUseChannel.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpMIDIOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutPallet)).BeginInit();
            this.tpOther.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbWav.SuspendLayout();
            this.gbDump.SuspendLayout();
            this.tpOmake.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tpAbout.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(216, 326);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(297, 326);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbWaveOut
            // 
            this.gbWaveOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWaveOut.Controls.Add(this.label1);
            this.gbWaveOut.Controls.Add(this.cmbWaveOutDevice);
            this.gbWaveOut.Location = new System.Drawing.Point(7, 6);
            this.gbWaveOut.Name = "gbWaveOut";
            this.gbWaveOut.Size = new System.Drawing.Size(360, 48);
            this.gbWaveOut.TabIndex = 1;
            this.gbWaveOut.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "出力デバイス";
            // 
            // cmbWaveOutDevice
            // 
            this.cmbWaveOutDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWaveOutDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaveOutDevice.FormattingEnabled = true;
            this.cmbWaveOutDevice.Location = new System.Drawing.Point(79, 18);
            this.cmbWaveOutDevice.Name = "cmbWaveOutDevice";
            this.cmbWaveOutDevice.Size = new System.Drawing.Size(275, 20);
            this.cmbWaveOutDevice.TabIndex = 0;
            // 
            // rbWaveOut
            // 
            this.rbWaveOut.AutoSize = true;
            this.rbWaveOut.Checked = true;
            this.rbWaveOut.Location = new System.Drawing.Point(13, 3);
            this.rbWaveOut.Name = "rbWaveOut";
            this.rbWaveOut.Size = new System.Drawing.Size(68, 16);
            this.rbWaveOut.TabIndex = 0;
            this.rbWaveOut.TabStop = true;
            this.rbWaveOut.Text = "WaveOut";
            this.rbWaveOut.UseVisualStyleBackColor = true;
            this.rbWaveOut.CheckedChanged += new System.EventHandler(this.rbWaveOut_CheckedChanged);
            // 
            // rbAsioOut
            // 
            this.rbAsioOut.AutoSize = true;
            this.rbAsioOut.Location = new System.Drawing.Point(13, 185);
            this.rbAsioOut.Name = "rbAsioOut";
            this.rbAsioOut.Size = new System.Drawing.Size(64, 16);
            this.rbAsioOut.TabIndex = 6;
            this.rbAsioOut.Text = "AsioOut";
            this.rbAsioOut.UseVisualStyleBackColor = true;
            this.rbAsioOut.CheckedChanged += new System.EventHandler(this.rbAsioOut_CheckedChanged);
            // 
            // rbWasapiOut
            // 
            this.rbWasapiOut.AutoSize = true;
            this.rbWasapiOut.Location = new System.Drawing.Point(13, 111);
            this.rbWasapiOut.Name = "rbWasapiOut";
            this.rbWasapiOut.Size = new System.Drawing.Size(77, 16);
            this.rbWasapiOut.TabIndex = 4;
            this.rbWasapiOut.Text = "WasapiOut";
            this.rbWasapiOut.UseVisualStyleBackColor = true;
            this.rbWasapiOut.CheckedChanged += new System.EventHandler(this.rbWasapiOut_CheckedChanged);
            // 
            // gbAsioOut
            // 
            this.gbAsioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAsioOut.Controls.Add(this.btnASIOControlPanel);
            this.gbAsioOut.Controls.Add(this.label4);
            this.gbAsioOut.Controls.Add(this.cmbAsioDevice);
            this.gbAsioOut.Location = new System.Drawing.Point(7, 188);
            this.gbAsioOut.Name = "gbAsioOut";
            this.gbAsioOut.Size = new System.Drawing.Size(360, 71);
            this.gbAsioOut.TabIndex = 7;
            this.gbAsioOut.TabStop = false;
            // 
            // btnASIOControlPanel
            // 
            this.btnASIOControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnASIOControlPanel.Location = new System.Drawing.Point(210, 42);
            this.btnASIOControlPanel.Name = "btnASIOControlPanel";
            this.btnASIOControlPanel.Size = new System.Drawing.Size(144, 23);
            this.btnASIOControlPanel.TabIndex = 8;
            this.btnASIOControlPanel.Text = "ASIO Control Panel";
            this.btnASIOControlPanel.UseVisualStyleBackColor = true;
            this.btnASIOControlPanel.Click += new System.EventHandler(this.btnASIOControlPanel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "出力デバイス";
            // 
            // cmbAsioDevice
            // 
            this.cmbAsioDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAsioDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsioDevice.FormattingEnabled = true;
            this.cmbAsioDevice.Location = new System.Drawing.Point(79, 18);
            this.cmbAsioDevice.Name = "cmbAsioDevice";
            this.cmbAsioDevice.Size = new System.Drawing.Size(275, 20);
            this.cmbAsioDevice.TabIndex = 6;
            // 
            // rbDirectSoundOut
            // 
            this.rbDirectSoundOut.AutoSize = true;
            this.rbDirectSoundOut.Location = new System.Drawing.Point(13, 57);
            this.rbDirectSoundOut.Name = "rbDirectSoundOut";
            this.rbDirectSoundOut.Size = new System.Drawing.Size(85, 16);
            this.rbDirectSoundOut.TabIndex = 2;
            this.rbDirectSoundOut.Text = "DirectSound";
            this.rbDirectSoundOut.UseVisualStyleBackColor = true;
            this.rbDirectSoundOut.CheckedChanged += new System.EventHandler(this.rbDirectSoundOut_CheckedChanged);
            // 
            // gbWasapiOut
            // 
            this.gbWasapiOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWasapiOut.Controls.Add(this.rbExclusive);
            this.gbWasapiOut.Controls.Add(this.rbShare);
            this.gbWasapiOut.Controls.Add(this.label3);
            this.gbWasapiOut.Controls.Add(this.cmbWasapiDevice);
            this.gbWasapiOut.Location = new System.Drawing.Point(7, 114);
            this.gbWasapiOut.Name = "gbWasapiOut";
            this.gbWasapiOut.Size = new System.Drawing.Size(360, 68);
            this.gbWasapiOut.TabIndex = 5;
            this.gbWasapiOut.TabStop = false;
            // 
            // rbExclusive
            // 
            this.rbExclusive.AutoSize = true;
            this.rbExclusive.Location = new System.Drawing.Point(307, 45);
            this.rbExclusive.Name = "rbExclusive";
            this.rbExclusive.Size = new System.Drawing.Size(47, 16);
            this.rbExclusive.TabIndex = 7;
            this.rbExclusive.TabStop = true;
            this.rbExclusive.Text = "排他";
            this.rbExclusive.UseVisualStyleBackColor = true;
            // 
            // rbShare
            // 
            this.rbShare.AutoSize = true;
            this.rbShare.Location = new System.Drawing.Point(254, 45);
            this.rbShare.Name = "rbShare";
            this.rbShare.Size = new System.Drawing.Size(47, 16);
            this.rbShare.TabIndex = 6;
            this.rbShare.TabStop = true;
            this.rbShare.Text = "共有";
            this.rbShare.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "出力デバイス";
            // 
            // cmbWasapiDevice
            // 
            this.cmbWasapiDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWasapiDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWasapiDevice.FormattingEnabled = true;
            this.cmbWasapiDevice.Location = new System.Drawing.Point(79, 19);
            this.cmbWasapiDevice.Name = "cmbWasapiDevice";
            this.cmbWasapiDevice.Size = new System.Drawing.Size(275, 20);
            this.cmbWasapiDevice.TabIndex = 4;
            // 
            // gbDirectSound
            // 
            this.gbDirectSound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDirectSound.Controls.Add(this.label2);
            this.gbDirectSound.Controls.Add(this.cmbDirectSoundDevice);
            this.gbDirectSound.Location = new System.Drawing.Point(7, 60);
            this.gbDirectSound.Name = "gbDirectSound";
            this.gbDirectSound.Size = new System.Drawing.Size(360, 48);
            this.gbDirectSound.TabIndex = 3;
            this.gbDirectSound.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "出力デバイス";
            // 
            // cmbDirectSoundDevice
            // 
            this.cmbDirectSoundDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDirectSoundDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirectSoundDevice.FormattingEnabled = true;
            this.cmbDirectSoundDevice.Location = new System.Drawing.Point(79, 19);
            this.cmbDirectSoundDevice.Name = "cmbDirectSoundDevice";
            this.cmbDirectSoundDevice.Size = new System.Drawing.Size(275, 20);
            this.cmbDirectSoundDevice.TabIndex = 2;
            // 
            // tcSetting
            // 
            this.tcSetting.Controls.Add(this.tpOutput);
            this.tcSetting.Controls.Add(this.tpModule);
            this.tcSetting.Controls.Add(this.tabMIDIExp);
            this.tcSetting.Controls.Add(this.tpMIDIKBD);
            this.tcSetting.Controls.Add(this.tpMIDIOut);
            this.tcSetting.Controls.Add(this.tpOther);
            this.tcSetting.Controls.Add(this.tpOmake);
            this.tcSetting.Controls.Add(this.tpAbout);
            this.tcSetting.Location = new System.Drawing.Point(1, 3);
            this.tcSetting.Name = "tcSetting";
            this.tcSetting.SelectedIndex = 0;
            this.tcSetting.Size = new System.Drawing.Size(382, 317);
            this.tcSetting.TabIndex = 2;
            // 
            // tpOutput
            // 
            this.tpOutput.Controls.Add(this.lblLatencyUnit);
            this.tpOutput.Controls.Add(this.lblLatency);
            this.tpOutput.Controls.Add(this.cmbLatency);
            this.tpOutput.Controls.Add(this.rbDirectSoundOut);
            this.tpOutput.Controls.Add(this.rbWaveOut);
            this.tpOutput.Controls.Add(this.rbAsioOut);
            this.tpOutput.Controls.Add(this.gbWaveOut);
            this.tpOutput.Controls.Add(this.rbWasapiOut);
            this.tpOutput.Controls.Add(this.gbAsioOut);
            this.tpOutput.Controls.Add(this.gbDirectSound);
            this.tpOutput.Controls.Add(this.gbWasapiOut);
            this.tpOutput.Location = new System.Drawing.Point(4, 22);
            this.tpOutput.Name = "tpOutput";
            this.tpOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutput.Size = new System.Drawing.Size(374, 291);
            this.tpOutput.TabIndex = 0;
            this.tpOutput.Text = "出力";
            this.tpOutput.UseVisualStyleBackColor = true;
            // 
            // lblLatencyUnit
            // 
            this.lblLatencyUnit.AutoSize = true;
            this.lblLatencyUnit.Location = new System.Drawing.Point(213, 268);
            this.lblLatencyUnit.Name = "lblLatencyUnit";
            this.lblLatencyUnit.Size = new System.Drawing.Size(20, 12);
            this.lblLatencyUnit.TabIndex = 9;
            this.lblLatencyUnit.Text = "ms";
            // 
            // lblLatency
            // 
            this.lblLatency.AutoSize = true;
            this.lblLatency.Location = new System.Drawing.Point(11, 268);
            this.lblLatency.Name = "lblLatency";
            this.lblLatency.Size = new System.Drawing.Size(53, 12);
            this.lblLatency.TabIndex = 9;
            this.lblLatency.Text = "遅延時間";
            // 
            // cmbLatency
            // 
            this.cmbLatency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLatency.FormattingEnabled = true;
            this.cmbLatency.Items.AddRange(new object[] {
            "25",
            "50",
            "100",
            "150",
            "200",
            "300",
            "400",
            "500"});
            this.cmbLatency.Location = new System.Drawing.Point(86, 265);
            this.cmbLatency.Name = "cmbLatency";
            this.cmbLatency.Size = new System.Drawing.Size(121, 20);
            this.cmbLatency.TabIndex = 8;
            // 
            // tpModule
            // 
            this.tpModule.Controls.Add(this.groupBox1);
            this.tpModule.Controls.Add(this.groupBox3);
            this.tpModule.Location = new System.Drawing.Point(4, 22);
            this.tpModule.Name = "tpModule";
            this.tpModule.Size = new System.Drawing.Size(374, 291);
            this.tpModule.TabIndex = 3;
            this.tpModule.Text = "音源";
            this.tpModule.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucSI);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 200);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "音源の割り当て";
            // 
            // ucSI
            // 
            this.ucSI.AutoScroll = true;
            this.ucSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSI.Location = new System.Drawing.Point(3, 15);
            this.ucSI.Name = "ucSI";
            this.ucSI.Size = new System.Drawing.Size(358, 182);
            this.ucSI.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbHiyorimiMode);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.tbLatencyEmu);
            this.groupBox3.Controls.Add(this.tbLatencySCCI);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(3, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 79);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "遅延演奏";
            // 
            // cbHiyorimiMode
            // 
            this.cbHiyorimiMode.AutoSize = true;
            this.cbHiyorimiMode.Location = new System.Drawing.Point(8, 59);
            this.cbHiyorimiMode.Name = "cbHiyorimiMode";
            this.cbHiyorimiMode.Size = new System.Drawing.Size(88, 16);
            this.cbHiyorimiMode.TabIndex = 6;
            this.cbHiyorimiMode.Text = "日和見モード";
            this.cbHiyorimiMode.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "エミュレーション";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "SCCI";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(144, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "ms";
            // 
            // tbLatencyEmu
            // 
            this.tbLatencyEmu.Location = new System.Drawing.Point(85, 15);
            this.tbLatencyEmu.Name = "tbLatencyEmu";
            this.tbLatencyEmu.Size = new System.Drawing.Size(53, 19);
            this.tbLatencyEmu.TabIndex = 1;
            // 
            // tbLatencySCCI
            // 
            this.tbLatencySCCI.Location = new System.Drawing.Point(85, 37);
            this.tbLatencySCCI.Name = "tbLatencySCCI";
            this.tbLatencySCCI.Size = new System.Drawing.Size(53, 19);
            this.tbLatencySCCI.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(144, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "ms";
            // 
            // tabMIDIExp
            // 
            this.tabMIDIExp.Controls.Add(this.cbUseMIDIExport);
            this.tabMIDIExp.Controls.Add(this.gbMIDIExport);
            this.tabMIDIExp.Location = new System.Drawing.Point(4, 22);
            this.tabMIDIExp.Name = "tabMIDIExp";
            this.tabMIDIExp.Size = new System.Drawing.Size(374, 291);
            this.tabMIDIExp.TabIndex = 6;
            this.tabMIDIExp.Text = "MIDIExport";
            this.tabMIDIExp.UseVisualStyleBackColor = true;
            // 
            // cbUseMIDIExport
            // 
            this.cbUseMIDIExport.AutoSize = true;
            this.cbUseMIDIExport.Location = new System.Drawing.Point(15, 3);
            this.cbUseMIDIExport.Name = "cbUseMIDIExport";
            this.cbUseMIDIExport.Size = new System.Drawing.Size(177, 16);
            this.cbUseMIDIExport.TabIndex = 1;
            this.cbUseMIDIExport.Text = "演奏時MIDIファイルをexportする";
            this.cbUseMIDIExport.UseVisualStyleBackColor = true;
            this.cbUseMIDIExport.CheckedChanged += new System.EventHandler(this.cbUseMIDIExport_CheckedChanged);
            // 
            // gbMIDIExport
            // 
            this.gbMIDIExport.Controls.Add(this.cbMIDIUseVOPM);
            this.gbMIDIExport.Controls.Add(this.groupBox6);
            this.gbMIDIExport.Controls.Add(this.cbMIDIPlayless);
            this.gbMIDIExport.Controls.Add(this.btnMIDIOutputPath);
            this.gbMIDIExport.Controls.Add(this.lblOutputPath);
            this.gbMIDIExport.Controls.Add(this.tbMIDIOutputPath);
            this.gbMIDIExport.Location = new System.Drawing.Point(7, 3);
            this.gbMIDIExport.Name = "gbMIDIExport";
            this.gbMIDIExport.Size = new System.Drawing.Size(360, 285);
            this.gbMIDIExport.TabIndex = 0;
            this.gbMIDIExport.TabStop = false;
            // 
            // cbMIDIUseVOPM
            // 
            this.cbMIDIUseVOPM.AutoSize = true;
            this.cbMIDIUseVOPM.Location = new System.Drawing.Point(21, 44);
            this.cbMIDIUseVOPM.Name = "cbMIDIUseVOPM";
            this.cbMIDIUseVOPM.Size = new System.Drawing.Size(196, 16);
            this.cbMIDIUseVOPM.TabIndex = 23;
            this.cbMIDIUseVOPM.Text = "VOPMex向けコントロールを出力する";
            this.cbMIDIUseVOPM.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbMIDIYM2612);
            this.groupBox6.Controls.Add(this.cbMIDISN76489Sec);
            this.groupBox6.Controls.Add(this.cbMIDIYM2612Sec);
            this.groupBox6.Controls.Add(this.cbMIDISN76489);
            this.groupBox6.Controls.Add(this.cbMIDIYM2151);
            this.groupBox6.Controls.Add(this.cbMIDIYM2610BSec);
            this.groupBox6.Controls.Add(this.cbMIDIYM2151Sec);
            this.groupBox6.Controls.Add(this.cbMIDIYM2610B);
            this.groupBox6.Controls.Add(this.cbMIDIYM2203);
            this.groupBox6.Controls.Add(this.cbMIDIYM2608Sec);
            this.groupBox6.Controls.Add(this.cbMIDIYM2203Sec);
            this.groupBox6.Controls.Add(this.cbMIDIYM2608);
            this.groupBox6.Location = new System.Drawing.Point(21, 91);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(188, 152);
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "出力対象音源";
            // 
            // cbMIDIYM2612
            // 
            this.cbMIDIYM2612.AutoSize = true;
            this.cbMIDIYM2612.Checked = true;
            this.cbMIDIYM2612.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMIDIYM2612.Location = new System.Drawing.Point(6, 18);
            this.cbMIDIYM2612.Name = "cbMIDIYM2612";
            this.cbMIDIYM2612.Size = new System.Drawing.Size(64, 16);
            this.cbMIDIYM2612.TabIndex = 21;
            this.cbMIDIYM2612.Text = "YM2612";
            this.cbMIDIYM2612.UseVisualStyleBackColor = true;
            // 
            // cbMIDISN76489Sec
            // 
            this.cbMIDISN76489Sec.AutoSize = true;
            this.cbMIDISN76489Sec.Enabled = false;
            this.cbMIDISN76489Sec.Location = new System.Drawing.Point(84, 128);
            this.cbMIDISN76489Sec.Name = "cbMIDISN76489Sec";
            this.cbMIDISN76489Sec.Size = new System.Drawing.Size(96, 16);
            this.cbMIDISN76489Sec.TabIndex = 21;
            this.cbMIDISN76489Sec.Text = "SN76489(Sec)";
            this.cbMIDISN76489Sec.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2612Sec
            // 
            this.cbMIDIYM2612Sec.AutoSize = true;
            this.cbMIDIYM2612Sec.Enabled = false;
            this.cbMIDIYM2612Sec.Location = new System.Drawing.Point(84, 18);
            this.cbMIDIYM2612Sec.Name = "cbMIDIYM2612Sec";
            this.cbMIDIYM2612Sec.Size = new System.Drawing.Size(91, 16);
            this.cbMIDIYM2612Sec.TabIndex = 21;
            this.cbMIDIYM2612Sec.Text = "YM2612(Sec)";
            this.cbMIDIYM2612Sec.UseVisualStyleBackColor = true;
            // 
            // cbMIDISN76489
            // 
            this.cbMIDISN76489.AutoSize = true;
            this.cbMIDISN76489.Enabled = false;
            this.cbMIDISN76489.Location = new System.Drawing.Point(6, 128);
            this.cbMIDISN76489.Name = "cbMIDISN76489";
            this.cbMIDISN76489.Size = new System.Drawing.Size(69, 16);
            this.cbMIDISN76489.TabIndex = 21;
            this.cbMIDISN76489.Text = "SN76489";
            this.cbMIDISN76489.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2151
            // 
            this.cbMIDIYM2151.AutoSize = true;
            this.cbMIDIYM2151.Location = new System.Drawing.Point(6, 40);
            this.cbMIDIYM2151.Name = "cbMIDIYM2151";
            this.cbMIDIYM2151.Size = new System.Drawing.Size(64, 16);
            this.cbMIDIYM2151.TabIndex = 21;
            this.cbMIDIYM2151.Text = "YM2151";
            this.cbMIDIYM2151.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2610BSec
            // 
            this.cbMIDIYM2610BSec.AutoSize = true;
            this.cbMIDIYM2610BSec.Enabled = false;
            this.cbMIDIYM2610BSec.Location = new System.Drawing.Point(84, 106);
            this.cbMIDIYM2610BSec.Name = "cbMIDIYM2610BSec";
            this.cbMIDIYM2610BSec.Size = new System.Drawing.Size(99, 16);
            this.cbMIDIYM2610BSec.TabIndex = 21;
            this.cbMIDIYM2610BSec.Text = "YM2610B(Sec)";
            this.cbMIDIYM2610BSec.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2151Sec
            // 
            this.cbMIDIYM2151Sec.AutoSize = true;
            this.cbMIDIYM2151Sec.Enabled = false;
            this.cbMIDIYM2151Sec.Location = new System.Drawing.Point(84, 40);
            this.cbMIDIYM2151Sec.Name = "cbMIDIYM2151Sec";
            this.cbMIDIYM2151Sec.Size = new System.Drawing.Size(91, 16);
            this.cbMIDIYM2151Sec.TabIndex = 21;
            this.cbMIDIYM2151Sec.Text = "YM2151(Sec)";
            this.cbMIDIYM2151Sec.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2610B
            // 
            this.cbMIDIYM2610B.AutoSize = true;
            this.cbMIDIYM2610B.Enabled = false;
            this.cbMIDIYM2610B.Location = new System.Drawing.Point(6, 106);
            this.cbMIDIYM2610B.Name = "cbMIDIYM2610B";
            this.cbMIDIYM2610B.Size = new System.Drawing.Size(72, 16);
            this.cbMIDIYM2610B.TabIndex = 21;
            this.cbMIDIYM2610B.Text = "YM2610B";
            this.cbMIDIYM2610B.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2203
            // 
            this.cbMIDIYM2203.AutoSize = true;
            this.cbMIDIYM2203.Enabled = false;
            this.cbMIDIYM2203.Location = new System.Drawing.Point(6, 62);
            this.cbMIDIYM2203.Name = "cbMIDIYM2203";
            this.cbMIDIYM2203.Size = new System.Drawing.Size(64, 16);
            this.cbMIDIYM2203.TabIndex = 21;
            this.cbMIDIYM2203.Text = "YM2203";
            this.cbMIDIYM2203.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2608Sec
            // 
            this.cbMIDIYM2608Sec.AutoSize = true;
            this.cbMIDIYM2608Sec.Enabled = false;
            this.cbMIDIYM2608Sec.Location = new System.Drawing.Point(84, 84);
            this.cbMIDIYM2608Sec.Name = "cbMIDIYM2608Sec";
            this.cbMIDIYM2608Sec.Size = new System.Drawing.Size(91, 16);
            this.cbMIDIYM2608Sec.TabIndex = 21;
            this.cbMIDIYM2608Sec.Text = "YM2608(Sec)";
            this.cbMIDIYM2608Sec.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2203Sec
            // 
            this.cbMIDIYM2203Sec.AutoSize = true;
            this.cbMIDIYM2203Sec.Enabled = false;
            this.cbMIDIYM2203Sec.Location = new System.Drawing.Point(84, 62);
            this.cbMIDIYM2203Sec.Name = "cbMIDIYM2203Sec";
            this.cbMIDIYM2203Sec.Size = new System.Drawing.Size(91, 16);
            this.cbMIDIYM2203Sec.TabIndex = 21;
            this.cbMIDIYM2203Sec.Text = "YM2203(Sec)";
            this.cbMIDIYM2203Sec.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2608
            // 
            this.cbMIDIYM2608.AutoSize = true;
            this.cbMIDIYM2608.Enabled = false;
            this.cbMIDIYM2608.Location = new System.Drawing.Point(6, 84);
            this.cbMIDIYM2608.Name = "cbMIDIYM2608";
            this.cbMIDIYM2608.Size = new System.Drawing.Size(64, 16);
            this.cbMIDIYM2608.TabIndex = 21;
            this.cbMIDIYM2608.Text = "YM2608";
            this.cbMIDIYM2608.UseVisualStyleBackColor = true;
            // 
            // cbMIDIPlayless
            // 
            this.cbMIDIPlayless.AutoSize = true;
            this.cbMIDIPlayless.Enabled = false;
            this.cbMIDIPlayless.Location = new System.Drawing.Point(21, 22);
            this.cbMIDIPlayless.Name = "cbMIDIPlayless";
            this.cbMIDIPlayless.Size = new System.Drawing.Size(141, 16);
            this.cbMIDIPlayless.TabIndex = 20;
            this.cbMIDIPlayless.Text = "演奏を行わずに出力する";
            this.cbMIDIPlayless.UseVisualStyleBackColor = true;
            // 
            // btnMIDIOutputPath
            // 
            this.btnMIDIOutputPath.Location = new System.Drawing.Point(332, 64);
            this.btnMIDIOutputPath.Name = "btnMIDIOutputPath";
            this.btnMIDIOutputPath.Size = new System.Drawing.Size(23, 23);
            this.btnMIDIOutputPath.TabIndex = 19;
            this.btnMIDIOutputPath.Text = "...";
            this.btnMIDIOutputPath.UseVisualStyleBackColor = true;
            this.btnMIDIOutputPath.Click += new System.EventHandler(this.btnMIDIOutputPath_Click);
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Location = new System.Drawing.Point(20, 69);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(52, 12);
            this.lblOutputPath.TabIndex = 17;
            this.lblOutputPath.Text = "出力Path";
            // 
            // tbMIDIOutputPath
            // 
            this.tbMIDIOutputPath.Location = new System.Drawing.Point(78, 66);
            this.tbMIDIOutputPath.Name = "tbMIDIOutputPath";
            this.tbMIDIOutputPath.Size = new System.Drawing.Size(248, 19);
            this.tbMIDIOutputPath.TabIndex = 18;
            // 
            // tpMIDIKBD
            // 
            this.tpMIDIKBD.Controls.Add(this.cbUseMIDIKeyboard);
            this.tpMIDIKBD.Controls.Add(this.gbMIDIKeyboard);
            this.tpMIDIKBD.Location = new System.Drawing.Point(4, 22);
            this.tpMIDIKBD.Name = "tpMIDIKBD";
            this.tpMIDIKBD.Size = new System.Drawing.Size(374, 291);
            this.tpMIDIKBD.TabIndex = 5;
            this.tpMIDIKBD.Text = "MIDI鍵盤";
            this.tpMIDIKBD.UseVisualStyleBackColor = true;
            // 
            // cbUseMIDIKeyboard
            // 
            this.cbUseMIDIKeyboard.AutoSize = true;
            this.cbUseMIDIKeyboard.Location = new System.Drawing.Point(11, 4);
            this.cbUseMIDIKeyboard.Name = "cbUseMIDIKeyboard";
            this.cbUseMIDIKeyboard.Size = new System.Drawing.Size(124, 16);
            this.cbUseMIDIKeyboard.TabIndex = 1;
            this.cbUseMIDIKeyboard.Text = "MIDIキーボードを使う";
            this.cbUseMIDIKeyboard.UseVisualStyleBackColor = true;
            this.cbUseMIDIKeyboard.CheckedChanged += new System.EventHandler(this.cbUseMIDIKeyboard_CheckedChanged);
            // 
            // gbMIDIKeyboard
            // 
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox8);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox7);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox6);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox5);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox4);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox3);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox2);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox1);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCFadeout);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCPause);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCSlow);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCPrevious);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCNext);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCFast);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCStop);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCPlay);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCCopyLog);
            this.gbMIDIKeyboard.Controls.Add(this.label17);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCDelLog);
            this.gbMIDIKeyboard.Controls.Add(this.label15);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCChCopy);
            this.gbMIDIKeyboard.Controls.Add(this.label8);
            this.gbMIDIKeyboard.Controls.Add(this.label9);
            this.gbMIDIKeyboard.Controls.Add(this.gbUseChannel);
            this.gbMIDIKeyboard.Controls.Add(this.cmbMIDIIN);
            this.gbMIDIKeyboard.Controls.Add(this.label5);
            this.gbMIDIKeyboard.Enabled = false;
            this.gbMIDIKeyboard.Location = new System.Drawing.Point(3, 6);
            this.gbMIDIKeyboard.Name = "gbMIDIKeyboard";
            this.gbMIDIKeyboard.Size = new System.Drawing.Size(368, 282);
            this.gbMIDIKeyboard.TabIndex = 0;
            this.gbMIDIKeyboard.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::MDPlayer.Properties.Resources.ccNext;
            this.pictureBox8.Location = new System.Drawing.Point(323, 257);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(16, 16);
            this.pictureBox8.TabIndex = 4;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::MDPlayer.Properties.Resources.ccFast;
            this.pictureBox7.Location = new System.Drawing.Point(229, 257);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 16);
            this.pictureBox7.TabIndex = 4;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::MDPlayer.Properties.Resources.ccPlay;
            this.pictureBox6.Location = new System.Drawing.Point(136, 258);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.TabIndex = 4;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::MDPlayer.Properties.Resources.ccSlow;
            this.pictureBox5.Location = new System.Drawing.Point(42, 258);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::MDPlayer.Properties.Resources.ccStop;
            this.pictureBox4.Location = new System.Drawing.Point(42, 234);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MDPlayer.Properties.Resources.ccPause;
            this.pictureBox3.Location = new System.Drawing.Point(136, 234);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MDPlayer.Properties.Resources.ccPrevious;
            this.pictureBox2.Location = new System.Drawing.Point(323, 234);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MDPlayer.Properties.Resources.ccFadeout;
            this.pictureBox1.Location = new System.Drawing.Point(229, 234);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tbCCFadeout
            // 
            this.tbCCFadeout.Location = new System.Drawing.Point(193, 232);
            this.tbCCFadeout.MaxLength = 3;
            this.tbCCFadeout.Name = "tbCCFadeout";
            this.tbCCFadeout.Size = new System.Drawing.Size(30, 19);
            this.tbCCFadeout.TabIndex = 12;
            // 
            // tbCCPause
            // 
            this.tbCCPause.Location = new System.Drawing.Point(100, 232);
            this.tbCCPause.MaxLength = 3;
            this.tbCCPause.Name = "tbCCPause";
            this.tbCCPause.Size = new System.Drawing.Size(30, 19);
            this.tbCCPause.TabIndex = 11;
            // 
            // tbCCSlow
            // 
            this.tbCCSlow.Location = new System.Drawing.Point(6, 257);
            this.tbCCSlow.MaxLength = 3;
            this.tbCCSlow.Name = "tbCCSlow";
            this.tbCCSlow.Size = new System.Drawing.Size(30, 19);
            this.tbCCSlow.TabIndex = 14;
            // 
            // tbCCPrevious
            // 
            this.tbCCPrevious.Location = new System.Drawing.Point(287, 232);
            this.tbCCPrevious.MaxLength = 3;
            this.tbCCPrevious.Name = "tbCCPrevious";
            this.tbCCPrevious.Size = new System.Drawing.Size(30, 19);
            this.tbCCPrevious.TabIndex = 13;
            // 
            // tbCCNext
            // 
            this.tbCCNext.Location = new System.Drawing.Point(287, 257);
            this.tbCCNext.MaxLength = 3;
            this.tbCCNext.Name = "tbCCNext";
            this.tbCCNext.Size = new System.Drawing.Size(30, 19);
            this.tbCCNext.TabIndex = 17;
            // 
            // tbCCFast
            // 
            this.tbCCFast.Location = new System.Drawing.Point(193, 257);
            this.tbCCFast.MaxLength = 3;
            this.tbCCFast.Name = "tbCCFast";
            this.tbCCFast.Size = new System.Drawing.Size(30, 19);
            this.tbCCFast.TabIndex = 16;
            // 
            // tbCCStop
            // 
            this.tbCCStop.Location = new System.Drawing.Point(6, 232);
            this.tbCCStop.MaxLength = 3;
            this.tbCCStop.Name = "tbCCStop";
            this.tbCCStop.Size = new System.Drawing.Size(30, 19);
            this.tbCCStop.TabIndex = 10;
            // 
            // tbCCPlay
            // 
            this.tbCCPlay.Location = new System.Drawing.Point(100, 257);
            this.tbCCPlay.MaxLength = 3;
            this.tbCCPlay.Name = "tbCCPlay";
            this.tbCCPlay.Size = new System.Drawing.Size(30, 19);
            this.tbCCPlay.TabIndex = 15;
            // 
            // tbCCCopyLog
            // 
            this.tbCCCopyLog.Location = new System.Drawing.Point(6, 207);
            this.tbCCCopyLog.MaxLength = 3;
            this.tbCCCopyLog.Name = "tbCCCopyLog";
            this.tbCCCopyLog.Size = new System.Drawing.Size(30, 19);
            this.tbCCCopyLog.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(42, 210);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(230, 12);
            this.label17.TabIndex = 9;
            this.label17.Text = "MONOモード時、選択ログをクリップボードに設定";
            // 
            // tbCCDelLog
            // 
            this.tbCCDelLog.Location = new System.Drawing.Point(6, 182);
            this.tbCCDelLog.MaxLength = 3;
            this.tbCCDelLog.Name = "tbCCDelLog";
            this.tbCCDelLog.Size = new System.Drawing.Size(30, 19);
            this.tbCCDelLog.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(42, 185);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 12);
            this.label15.TabIndex = 7;
            this.label15.Text = "直近のログをひとつ削除";
            // 
            // tbCCChCopy
            // 
            this.tbCCChCopy.Location = new System.Drawing.Point(6, 157);
            this.tbCCChCopy.MaxLength = 3;
            this.tbCCChCopy.Name = "tbCCChCopy";
            this.tbCCChCopy.Size = new System.Drawing.Size(30, 19);
            this.tbCCChCopy.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "CC(Control Change)による操作";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(261, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "1Chの音色を全てのチャンネルにコピー(選択状況無視)";
            // 
            // gbUseChannel
            // 
            this.gbUseChannel.Controls.Add(this.rbMONO);
            this.gbUseChannel.Controls.Add(this.rbPOLY);
            this.gbUseChannel.Controls.Add(this.groupBox7);
            this.gbUseChannel.Controls.Add(this.groupBox2);
            this.gbUseChannel.Location = new System.Drawing.Point(6, 44);
            this.gbUseChannel.Name = "gbUseChannel";
            this.gbUseChannel.Size = new System.Drawing.Size(356, 86);
            this.gbUseChannel.TabIndex = 2;
            this.gbUseChannel.TabStop = false;
            this.gbUseChannel.Text = "use channel";
            // 
            // rbMONO
            // 
            this.rbMONO.AutoSize = true;
            this.rbMONO.Checked = true;
            this.rbMONO.Location = new System.Drawing.Point(12, 17);
            this.rbMONO.Name = "rbMONO";
            this.rbMONO.Size = new System.Drawing.Size(56, 16);
            this.rbMONO.TabIndex = 1;
            this.rbMONO.TabStop = true;
            this.rbMONO.Text = "MONO";
            this.rbMONO.UseVisualStyleBackColor = true;
            // 
            // rbPOLY
            // 
            this.rbPOLY.AutoSize = true;
            this.rbPOLY.Location = new System.Drawing.Point(187, 17);
            this.rbPOLY.Name = "rbPOLY";
            this.rbPOLY.Size = new System.Drawing.Size(51, 16);
            this.rbPOLY.TabIndex = 3;
            this.rbPOLY.Text = "POLY";
            this.rbPOLY.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbFM6);
            this.groupBox7.Controls.Add(this.rbFM3);
            this.groupBox7.Controls.Add(this.rbFM5);
            this.groupBox7.Controls.Add(this.rbFM2);
            this.groupBox7.Controls.Add(this.rbFM4);
            this.groupBox7.Controls.Add(this.rbFM1);
            this.groupBox7.Location = new System.Drawing.Point(6, 18);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(170, 62);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            // 
            // rbFM6
            // 
            this.rbFM6.AutoSize = true;
            this.rbFM6.Location = new System.Drawing.Point(108, 40);
            this.rbFM6.Name = "rbFM6";
            this.rbFM6.Size = new System.Drawing.Size(45, 16);
            this.rbFM6.TabIndex = 5;
            this.rbFM6.Text = "FM6";
            this.rbFM6.UseVisualStyleBackColor = true;
            // 
            // rbFM3
            // 
            this.rbFM3.AutoSize = true;
            this.rbFM3.Location = new System.Drawing.Point(108, 18);
            this.rbFM3.Name = "rbFM3";
            this.rbFM3.Size = new System.Drawing.Size(45, 16);
            this.rbFM3.TabIndex = 2;
            this.rbFM3.Text = "FM3";
            this.rbFM3.UseVisualStyleBackColor = true;
            // 
            // rbFM5
            // 
            this.rbFM5.AutoSize = true;
            this.rbFM5.Location = new System.Drawing.Point(57, 40);
            this.rbFM5.Name = "rbFM5";
            this.rbFM5.Size = new System.Drawing.Size(45, 16);
            this.rbFM5.TabIndex = 4;
            this.rbFM5.Text = "FM5";
            this.rbFM5.UseVisualStyleBackColor = true;
            // 
            // rbFM2
            // 
            this.rbFM2.AutoSize = true;
            this.rbFM2.Location = new System.Drawing.Point(57, 18);
            this.rbFM2.Name = "rbFM2";
            this.rbFM2.Size = new System.Drawing.Size(45, 16);
            this.rbFM2.TabIndex = 1;
            this.rbFM2.Text = "FM2";
            this.rbFM2.UseVisualStyleBackColor = true;
            // 
            // rbFM4
            // 
            this.rbFM4.AutoSize = true;
            this.rbFM4.Location = new System.Drawing.Point(6, 40);
            this.rbFM4.Name = "rbFM4";
            this.rbFM4.Size = new System.Drawing.Size(45, 16);
            this.rbFM4.TabIndex = 3;
            this.rbFM4.Text = "FM4";
            this.rbFM4.UseVisualStyleBackColor = true;
            // 
            // rbFM1
            // 
            this.rbFM1.AutoSize = true;
            this.rbFM1.Checked = true;
            this.rbFM1.Location = new System.Drawing.Point(6, 18);
            this.rbFM1.Name = "rbFM1";
            this.rbFM1.Size = new System.Drawing.Size(45, 16);
            this.rbFM1.TabIndex = 0;
            this.rbFM1.TabStop = true;
            this.rbFM1.Text = "FM1";
            this.rbFM1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbFM1);
            this.groupBox2.Controls.Add(this.cbFM6);
            this.groupBox2.Controls.Add(this.cbFM2);
            this.groupBox2.Controls.Add(this.cbFM5);
            this.groupBox2.Controls.Add(this.cbFM3);
            this.groupBox2.Controls.Add(this.cbFM4);
            this.groupBox2.Location = new System.Drawing.Point(181, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 62);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // cbFM1
            // 
            this.cbFM1.AutoSize = true;
            this.cbFM1.Checked = true;
            this.cbFM1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM1.Location = new System.Drawing.Point(6, 18);
            this.cbFM1.Name = "cbFM1";
            this.cbFM1.Size = new System.Drawing.Size(46, 16);
            this.cbFM1.TabIndex = 0;
            this.cbFM1.Text = "FM1";
            this.cbFM1.UseVisualStyleBackColor = true;
            // 
            // cbFM6
            // 
            this.cbFM6.AutoSize = true;
            this.cbFM6.Checked = true;
            this.cbFM6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM6.Location = new System.Drawing.Point(110, 40);
            this.cbFM6.Name = "cbFM6";
            this.cbFM6.Size = new System.Drawing.Size(46, 16);
            this.cbFM6.TabIndex = 5;
            this.cbFM6.Text = "FM6";
            this.cbFM6.UseVisualStyleBackColor = true;
            // 
            // cbFM2
            // 
            this.cbFM2.AutoSize = true;
            this.cbFM2.Checked = true;
            this.cbFM2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM2.Location = new System.Drawing.Point(58, 18);
            this.cbFM2.Name = "cbFM2";
            this.cbFM2.Size = new System.Drawing.Size(46, 16);
            this.cbFM2.TabIndex = 1;
            this.cbFM2.Text = "FM2";
            this.cbFM2.UseVisualStyleBackColor = true;
            // 
            // cbFM5
            // 
            this.cbFM5.AutoSize = true;
            this.cbFM5.Checked = true;
            this.cbFM5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM5.Location = new System.Drawing.Point(58, 40);
            this.cbFM5.Name = "cbFM5";
            this.cbFM5.Size = new System.Drawing.Size(46, 16);
            this.cbFM5.TabIndex = 4;
            this.cbFM5.Text = "FM5";
            this.cbFM5.UseVisualStyleBackColor = true;
            // 
            // cbFM3
            // 
            this.cbFM3.AutoSize = true;
            this.cbFM3.Checked = true;
            this.cbFM3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM3.Location = new System.Drawing.Point(110, 18);
            this.cbFM3.Name = "cbFM3";
            this.cbFM3.Size = new System.Drawing.Size(46, 16);
            this.cbFM3.TabIndex = 2;
            this.cbFM3.Text = "FM3";
            this.cbFM3.UseVisualStyleBackColor = true;
            // 
            // cbFM4
            // 
            this.cbFM4.AutoSize = true;
            this.cbFM4.Checked = true;
            this.cbFM4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM4.Location = new System.Drawing.Point(6, 40);
            this.cbFM4.Name = "cbFM4";
            this.cbFM4.Size = new System.Drawing.Size(46, 16);
            this.cbFM4.TabIndex = 3;
            this.cbFM4.Text = "FM4";
            this.cbFM4.UseVisualStyleBackColor = true;
            // 
            // cmbMIDIIN
            // 
            this.cmbMIDIIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMIDIIN.FormattingEnabled = true;
            this.cmbMIDIIN.Location = new System.Drawing.Point(72, 18);
            this.cmbMIDIIN.Name = "cmbMIDIIN";
            this.cmbMIDIIN.Size = new System.Drawing.Size(290, 20);
            this.cmbMIDIIN.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "MIDI IN";
            // 
            // tpMIDIOut
            // 
            this.tpMIDIOut.Controls.Add(this.btnUP);
            this.tpMIDIOut.Controls.Add(this.btnSubMIDIout);
            this.tpMIDIOut.Controls.Add(this.btnDOWN);
            this.tpMIDIOut.Controls.Add(this.btnAddMIDIout);
            this.tpMIDIOut.Controls.Add(this.label18);
            this.tpMIDIOut.Controls.Add(this.dgvMIDIoutList);
            this.tpMIDIOut.Controls.Add(this.dgvMIDIoutPallet);
            this.tpMIDIOut.Controls.Add(this.label16);
            this.tpMIDIOut.Location = new System.Drawing.Point(4, 22);
            this.tpMIDIOut.Name = "tpMIDIOut";
            this.tpMIDIOut.Size = new System.Drawing.Size(374, 291);
            this.tpMIDIOut.TabIndex = 8;
            this.tpMIDIOut.Text = "MIDI out";
            this.tpMIDIOut.UseVisualStyleBackColor = true;
            // 
            // btnUP
            // 
            this.btnUP.Location = new System.Drawing.Point(342, 162);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(25, 60);
            this.btnUP.TabIndex = 3;
            this.btnUP.Text = "↑";
            this.btnUP.UseVisualStyleBackColor = true;
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnSubMIDIout
            // 
            this.btnSubMIDIout.Location = new System.Drawing.Point(190, 132);
            this.btnSubMIDIout.Name = "btnSubMIDIout";
            this.btnSubMIDIout.Size = new System.Drawing.Size(30, 24);
            this.btnSubMIDIout.TabIndex = 3;
            this.btnSubMIDIout.Text = "↑";
            this.btnSubMIDIout.UseVisualStyleBackColor = true;
            this.btnSubMIDIout.Click += new System.EventHandler(this.btnSubMIDIout_Click);
            // 
            // btnDOWN
            // 
            this.btnDOWN.Location = new System.Drawing.Point(342, 228);
            this.btnDOWN.Name = "btnDOWN";
            this.btnDOWN.Size = new System.Drawing.Size(25, 60);
            this.btnDOWN.TabIndex = 3;
            this.btnDOWN.Text = "↓";
            this.btnDOWN.UseVisualStyleBackColor = true;
            this.btnDOWN.Click += new System.EventHandler(this.btnDOWN_Click);
            // 
            // btnAddMIDIout
            // 
            this.btnAddMIDIout.Location = new System.Drawing.Point(154, 132);
            this.btnAddMIDIout.Name = "btnAddMIDIout";
            this.btnAddMIDIout.Size = new System.Drawing.Size(30, 24);
            this.btnAddMIDIout.TabIndex = 3;
            this.btnAddMIDIout.Text = "↓";
            this.btnAddMIDIout.UseVisualStyleBackColor = true;
            this.btnAddMIDIout.Click += new System.EventHandler(this.btnAddMIDIout_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 147);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 12);
            this.label18.TabIndex = 2;
            this.label18.Text = "MIDI Outリスト";
            // 
            // dgvMIDIoutList
            // 
            this.dgvMIDIoutList.AllowUserToAddRows = false;
            this.dgvMIDIoutList.AllowUserToDeleteRows = false;
            this.dgvMIDIoutList.AllowUserToResizeRows = false;
            this.dgvMIDIoutList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMIDIoutList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvMIDIoutList.Location = new System.Drawing.Point(7, 162);
            this.dgvMIDIoutList.MultiSelect = false;
            this.dgvMIDIoutList.Name = "dgvMIDIoutList";
            this.dgvMIDIoutList.RowHeadersVisible = false;
            this.dgvMIDIoutList.RowTemplate.Height = 21;
            this.dgvMIDIoutList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMIDIoutList.Size = new System.Drawing.Size(329, 126);
            this.dgvMIDIoutList.TabIndex = 1;
            // 
            // dgvMIDIoutPallet
            // 
            this.dgvMIDIoutPallet.AllowUserToAddRows = false;
            this.dgvMIDIoutPallet.AllowUserToDeleteRows = false;
            this.dgvMIDIoutPallet.AllowUserToResizeRows = false;
            this.dgvMIDIoutPallet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMIDIoutPallet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID,
            this.clmDeviceName,
            this.clmManufacturer,
            this.clmSpacer});
            this.dgvMIDIoutPallet.Location = new System.Drawing.Point(7, 20);
            this.dgvMIDIoutPallet.MultiSelect = false;
            this.dgvMIDIoutPallet.Name = "dgvMIDIoutPallet";
            this.dgvMIDIoutPallet.RowHeadersVisible = false;
            this.dgvMIDIoutPallet.RowTemplate.Height = 21;
            this.dgvMIDIoutPallet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMIDIoutPallet.Size = new System.Drawing.Size(360, 106);
            this.dgvMIDIoutPallet.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "MIDI Outデバイス パレット";
            // 
            // tpOther
            // 
            this.tpOther.Controls.Add(this.cbUseGetInst);
            this.tpOther.Controls.Add(this.groupBox4);
            this.tpOther.Controls.Add(this.cbWavSwitch);
            this.tpOther.Controls.Add(this.cbDumpSwitch);
            this.tpOther.Controls.Add(this.gbWav);
            this.tpOther.Controls.Add(this.gbDump);
            this.tpOther.Controls.Add(this.label30);
            this.tpOther.Controls.Add(this.tbScreenFrameRate);
            this.tpOther.Controls.Add(this.label29);
            this.tpOther.Controls.Add(this.lblLoopTimes);
            this.tpOther.Controls.Add(this.btnDataPath);
            this.tpOther.Controls.Add(this.tbLoopTimes);
            this.tpOther.Controls.Add(this.tbDataPath);
            this.tpOther.Controls.Add(this.label19);
            this.tpOther.Controls.Add(this.btnResetPosition);
            this.tpOther.Controls.Add(this.btnOpenSettingFolder);
            this.tpOther.Controls.Add(this.cbAutoOpen);
            this.tpOther.Controls.Add(this.cbUseLoopTimes);
            this.tpOther.Location = new System.Drawing.Point(4, 22);
            this.tpOther.Name = "tpOther";
            this.tpOther.Size = new System.Drawing.Size(374, 291);
            this.tpOther.TabIndex = 2;
            this.tpOther.Text = "Other";
            this.tpOther.UseVisualStyleBackColor = true;
            // 
            // cbUseGetInst
            // 
            this.cbUseGetInst.AutoSize = true;
            this.cbUseGetInst.Location = new System.Drawing.Point(14, 31);
            this.cbUseGetInst.Name = "cbUseGetInst";
            this.cbUseGetInst.Size = new System.Drawing.Size(286, 16);
            this.cbUseGetInst.TabIndex = 12;
            this.cbUseGetInst.Text = "音色欄をクリック時、その音色をクリップボードにコピーする";
            this.cbUseGetInst.UseVisualStyleBackColor = true;
            this.cbUseGetInst.CheckedChanged += new System.EventHandler(this.cbUseGetInst_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbInstFormat);
            this.groupBox4.Controls.Add(this.lblInstFormat);
            this.groupBox4.Location = new System.Drawing.Point(7, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(358, 45);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            // 
            // cmbInstFormat
            // 
            this.cmbInstFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstFormat.FormattingEnabled = true;
            this.cmbInstFormat.Items.AddRange(new object[] {
            "FMP7",
            "MDX",
            ".TFI(ファイル出力)",
            "MUSIC LALF #1",
            "MUSIC LALF #2",
            "MML2VGM",
            "NRTDRV",
            "HuSIC"});
            this.cmbInstFormat.Location = new System.Drawing.Point(223, 19);
            this.cmbInstFormat.Name = "cmbInstFormat";
            this.cmbInstFormat.Size = new System.Drawing.Size(129, 20);
            this.cmbInstFormat.TabIndex = 18;
            // 
            // lblInstFormat
            // 
            this.lblInstFormat.AutoSize = true;
            this.lblInstFormat.Location = new System.Drawing.Point(162, 22);
            this.lblInstFormat.Name = "lblInstFormat";
            this.lblInstFormat.Size = new System.Drawing.Size(55, 12);
            this.lblInstFormat.TabIndex = 17;
            this.lblInstFormat.Text = "フォーマット";
            // 
            // cbWavSwitch
            // 
            this.cbWavSwitch.AutoSize = true;
            this.cbWavSwitch.Location = new System.Drawing.Point(14, 203);
            this.cbWavSwitch.Name = "cbWavSwitch";
            this.cbWavSwitch.Size = new System.Drawing.Size(177, 16);
            this.cbWavSwitch.TabIndex = 0;
            this.cbWavSwitch.Text = "演奏時に.wavファイルを出力する";
            this.cbWavSwitch.UseVisualStyleBackColor = true;
            this.cbWavSwitch.CheckedChanged += new System.EventHandler(this.cbWavSwitch_CheckedChanged);
            // 
            // cbDumpSwitch
            // 
            this.cbDumpSwitch.AutoSize = true;
            this.cbDumpSwitch.Location = new System.Drawing.Point(14, 152);
            this.cbDumpSwitch.Name = "cbDumpSwitch";
            this.cbDumpSwitch.Size = new System.Drawing.Size(220, 16);
            this.cbDumpSwitch.TabIndex = 0;
            this.cbDumpSwitch.Text = "DataBlock処理時にその内容をダンプする";
            this.cbDumpSwitch.UseVisualStyleBackColor = true;
            this.cbDumpSwitch.CheckedChanged += new System.EventHandler(this.cbDumpSwitch_CheckedChanged);
            // 
            // gbWav
            // 
            this.gbWav.Controls.Add(this.btnWavPath);
            this.gbWav.Controls.Add(this.label7);
            this.gbWav.Controls.Add(this.tbWavPath);
            this.gbWav.Location = new System.Drawing.Point(7, 205);
            this.gbWav.Name = "gbWav";
            this.gbWav.Size = new System.Drawing.Size(358, 45);
            this.gbWav.TabIndex = 22;
            this.gbWav.TabStop = false;
            // 
            // btnWavPath
            // 
            this.btnWavPath.Location = new System.Drawing.Point(329, 16);
            this.btnWavPath.Name = "btnWavPath";
            this.btnWavPath.Size = new System.Drawing.Size(23, 23);
            this.btnWavPath.TabIndex = 16;
            this.btnWavPath.Text = "...";
            this.btnWavPath.UseVisualStyleBackColor = true;
            this.btnWavPath.Click += new System.EventHandler(this.btnWavPath_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "出力Path";
            // 
            // tbWavPath
            // 
            this.tbWavPath.Location = new System.Drawing.Point(73, 18);
            this.tbWavPath.Name = "tbWavPath";
            this.tbWavPath.Size = new System.Drawing.Size(250, 19);
            this.tbWavPath.TabIndex = 15;
            // 
            // gbDump
            // 
            this.gbDump.Controls.Add(this.btnDumpPath);
            this.gbDump.Controls.Add(this.label6);
            this.gbDump.Controls.Add(this.tbDumpPath);
            this.gbDump.Location = new System.Drawing.Point(7, 154);
            this.gbDump.Name = "gbDump";
            this.gbDump.Size = new System.Drawing.Size(358, 45);
            this.gbDump.TabIndex = 22;
            this.gbDump.TabStop = false;
            // 
            // btnDumpPath
            // 
            this.btnDumpPath.Location = new System.Drawing.Point(329, 16);
            this.btnDumpPath.Name = "btnDumpPath";
            this.btnDumpPath.Size = new System.Drawing.Size(23, 23);
            this.btnDumpPath.TabIndex = 16;
            this.btnDumpPath.Text = "...";
            this.btnDumpPath.UseVisualStyleBackColor = true;
            this.btnDumpPath.Click += new System.EventHandler(this.btnDumpPath_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "出力Path";
            // 
            // tbDumpPath
            // 
            this.tbDumpPath.Location = new System.Drawing.Point(73, 18);
            this.tbDumpPath.Name = "tbDumpPath";
            this.tbDumpPath.Size = new System.Drawing.Size(250, 19);
            this.tbDumpPath.TabIndex = 15;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(136, 132);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(30, 12);
            this.label30.TabIndex = 21;
            this.label30.Text = "Hz/s";
            // 
            // tbScreenFrameRate
            // 
            this.tbScreenFrameRate.Location = new System.Drawing.Point(80, 129);
            this.tbScreenFrameRate.Name = "tbScreenFrameRate";
            this.tbScreenFrameRate.Size = new System.Drawing.Size(50, 19);
            this.tbScreenFrameRate.TabIndex = 20;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(5, 132);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(69, 12);
            this.label29.TabIndex = 19;
            this.label29.Text = "フレームレート";
            // 
            // lblLoopTimes
            // 
            this.lblLoopTimes.AutoSize = true;
            this.lblLoopTimes.Location = new System.Drawing.Point(340, 8);
            this.lblLoopTimes.Name = "lblLoopTimes";
            this.lblLoopTimes.Size = new System.Drawing.Size(17, 12);
            this.lblLoopTimes.TabIndex = 1;
            this.lblLoopTimes.Text = "回";
            // 
            // btnDataPath
            // 
            this.btnDataPath.Location = new System.Drawing.Point(336, 102);
            this.btnDataPath.Name = "btnDataPath";
            this.btnDataPath.Size = new System.Drawing.Size(23, 23);
            this.btnDataPath.TabIndex = 16;
            this.btnDataPath.Text = "...";
            this.btnDataPath.UseVisualStyleBackColor = true;
            this.btnDataPath.Click += new System.EventHandler(this.btnDataPath_Click);
            // 
            // tbLoopTimes
            // 
            this.tbLoopTimes.Location = new System.Drawing.Point(282, 5);
            this.tbLoopTimes.Name = "tbLoopTimes";
            this.tbLoopTimes.Size = new System.Drawing.Size(52, 19);
            this.tbLoopTimes.TabIndex = 0;
            // 
            // tbDataPath
            // 
            this.tbDataPath.Location = new System.Drawing.Point(80, 104);
            this.tbDataPath.Name = "tbDataPath";
            this.tbDataPath.Size = new System.Drawing.Size(250, 19);
            this.tbDataPath.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 107);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 12);
            this.label19.TabIndex = 14;
            this.label19.Text = "データPath";
            // 
            // btnResetPosition
            // 
            this.btnResetPosition.Location = new System.Drawing.Point(94, 265);
            this.btnResetPosition.Name = "btnResetPosition";
            this.btnResetPosition.Size = new System.Drawing.Size(142, 23);
            this.btnResetPosition.TabIndex = 13;
            this.btnResetPosition.Text = "ウィンドウ位置をリセット";
            this.btnResetPosition.UseVisualStyleBackColor = true;
            this.btnResetPosition.Click += new System.EventHandler(this.btnResetPosition_Click);
            // 
            // btnOpenSettingFolder
            // 
            this.btnOpenSettingFolder.Location = new System.Drawing.Point(242, 265);
            this.btnOpenSettingFolder.Name = "btnOpenSettingFolder";
            this.btnOpenSettingFolder.Size = new System.Drawing.Size(125, 23);
            this.btnOpenSettingFolder.TabIndex = 13;
            this.btnOpenSettingFolder.Text = "設定フォルダーを開く";
            this.btnOpenSettingFolder.UseVisualStyleBackColor = true;
            this.btnOpenSettingFolder.Click += new System.EventHandler(this.btnOpenSettingFolder_Click);
            // 
            // cbAutoOpen
            // 
            this.cbAutoOpen.AutoSize = true;
            this.cbAutoOpen.Location = new System.Drawing.Point(7, 82);
            this.cbAutoOpen.Name = "cbAutoOpen";
            this.cbAutoOpen.Size = new System.Drawing.Size(167, 16);
            this.cbAutoOpen.TabIndex = 0;
            this.cbAutoOpen.Text = "使用音源の画面を自動で開く";
            this.cbAutoOpen.UseVisualStyleBackColor = true;
            this.cbAutoOpen.CheckedChanged += new System.EventHandler(this.cbUseLoopTimes_CheckedChanged);
            // 
            // cbUseLoopTimes
            // 
            this.cbUseLoopTimes.AutoSize = true;
            this.cbUseLoopTimes.Location = new System.Drawing.Point(7, 7);
            this.cbUseLoopTimes.Name = "cbUseLoopTimes";
            this.cbUseLoopTimes.Size = new System.Drawing.Size(216, 16);
            this.cbUseLoopTimes.TabIndex = 0;
            this.cbUseLoopTimes.Text = "無限ループ時、指定の回数だけ繰り返す";
            this.cbUseLoopTimes.UseVisualStyleBackColor = true;
            this.cbUseLoopTimes.CheckedChanged += new System.EventHandler(this.cbUseLoopTimes_CheckedChanged);
            // 
            // tpOmake
            // 
            this.tpOmake.Controls.Add(this.label14);
            this.tpOmake.Controls.Add(this.btVST);
            this.tpOmake.Controls.Add(this.tbVST);
            this.tpOmake.Controls.Add(this.groupBox5);
            this.tpOmake.Location = new System.Drawing.Point(4, 22);
            this.tpOmake.Name = "tpOmake";
            this.tpOmake.Size = new System.Drawing.Size(374, 291);
            this.tpOmake.TabIndex = 7;
            this.tpOmake.Text = "おまけ";
            this.tpOmake.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 12);
            this.label14.TabIndex = 19;
            this.label14.Text = "VST effect";
            this.label14.Visible = false;
            // 
            // btVST
            // 
            this.btVST.Location = new System.Drawing.Point(344, 54);
            this.btVST.Name = "btVST";
            this.btVST.Size = new System.Drawing.Size(23, 23);
            this.btVST.TabIndex = 18;
            this.btVST.Text = "...";
            this.btVST.UseVisualStyleBackColor = true;
            this.btVST.Visible = false;
            this.btVST.Click += new System.EventHandler(this.btVST_Click);
            // 
            // tbVST
            // 
            this.tbVST.Location = new System.Drawing.Point(88, 56);
            this.tbVST.Name = "tbVST";
            this.tbVST.Size = new System.Drawing.Size(250, 19);
            this.tbVST.TabIndex = 17;
            this.tbVST.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbDispFrameCounter);
            this.groupBox5.Location = new System.Drawing.Point(7, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(184, 37);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Debug Mode";
            // 
            // cbDispFrameCounter
            // 
            this.cbDispFrameCounter.AutoSize = true;
            this.cbDispFrameCounter.Location = new System.Drawing.Point(6, 17);
            this.cbDispFrameCounter.Name = "cbDispFrameCounter";
            this.cbDispFrameCounter.Size = new System.Drawing.Size(120, 16);
            this.cbDispFrameCounter.TabIndex = 2;
            this.cbDispFrameCounter.Text = "FrameCounter表示";
            this.cbDispFrameCounter.UseVisualStyleBackColor = true;
            // 
            // tpAbout
            // 
            this.tpAbout.Controls.Add(this.tableLayoutPanel);
            this.tpAbout.Location = new System.Drawing.Point(4, 22);
            this.tpAbout.Name = "tpAbout";
            this.tpAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tpAbout.Size = new System.Drawing.Size(374, 291);
            this.tpAbout.TabIndex = 1;
            this.tpAbout.Text = "About";
            this.tpAbout.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.070175F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.421053F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(368, 285);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = global::MDPlayer.Properties.Resources.フェーリAndMD2;
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(115, 279);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(127, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(238, 16);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "製品名";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point(127, 28);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(238, 16);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "バージョン";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.Location = new System.Drawing.Point(127, 56);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(238, 16);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "著作権";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCompanyName.Location = new System.Drawing.Point(127, 84);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(238, 16);
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.Text = "会社名";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(127, 110);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(238, 146);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "説明";
            // 
            // clmID
            // 
            this.clmID.Frozen = true;
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            this.clmID.ReadOnly = true;
            this.clmID.Visible = false;
            this.clmID.Width = 40;
            // 
            // clmDeviceName
            // 
            this.clmDeviceName.Frozen = true;
            this.clmDeviceName.HeaderText = "Device Name";
            this.clmDeviceName.Name = "clmDeviceName";
            this.clmDeviceName.ReadOnly = true;
            this.clmDeviceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDeviceName.Width = 200;
            // 
            // clmManufacturer
            // 
            this.clmManufacturer.Frozen = true;
            this.clmManufacturer.HeaderText = "Manufacturer";
            this.clmManufacturer.Name = "clmManufacturer";
            this.clmManufacturer.ReadOnly = true;
            this.clmManufacturer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmSpacer
            // 
            this.clmSpacer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmSpacer.HeaderText = "";
            this.clmSpacer.Name = "clmSpacer";
            this.clmSpacer.ReadOnly = true;
            this.clmSpacer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Device Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Manufacturer";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.tcSetting);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "オプション";
            this.gbWaveOut.ResumeLayout(false);
            this.gbWaveOut.PerformLayout();
            this.gbAsioOut.ResumeLayout(false);
            this.gbAsioOut.PerformLayout();
            this.gbWasapiOut.ResumeLayout(false);
            this.gbWasapiOut.PerformLayout();
            this.gbDirectSound.ResumeLayout(false);
            this.gbDirectSound.PerformLayout();
            this.tcSetting.ResumeLayout(false);
            this.tpOutput.ResumeLayout(false);
            this.tpOutput.PerformLayout();
            this.tpModule.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabMIDIExp.ResumeLayout(false);
            this.tabMIDIExp.PerformLayout();
            this.gbMIDIExport.ResumeLayout(false);
            this.gbMIDIExport.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tpMIDIKBD.ResumeLayout(false);
            this.tpMIDIKBD.PerformLayout();
            this.gbMIDIKeyboard.ResumeLayout(false);
            this.gbMIDIKeyboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbUseChannel.ResumeLayout(false);
            this.gbUseChannel.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpMIDIOut.ResumeLayout(false);
            this.tpMIDIOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutPallet)).EndInit();
            this.tpOther.ResumeLayout(false);
            this.tpOther.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbWav.ResumeLayout(false);
            this.gbWav.PerformLayout();
            this.gbDump.ResumeLayout(false);
            this.gbDump.PerformLayout();
            this.tpOmake.ResumeLayout(false);
            this.tpOmake.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tpAbout.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbWaveOut;
        private System.Windows.Forms.RadioButton rbWaveOut;
        private System.Windows.Forms.RadioButton rbAsioOut;
        private System.Windows.Forms.RadioButton rbWasapiOut;
        private System.Windows.Forms.GroupBox gbAsioOut;
        private System.Windows.Forms.RadioButton rbDirectSoundOut;
        private System.Windows.Forms.GroupBox gbWasapiOut;
        private System.Windows.Forms.GroupBox gbDirectSound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWaveOutDevice;
        private System.Windows.Forms.Button btnASIOControlPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAsioDevice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbWasapiDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDirectSoundDevice;
        private System.Windows.Forms.TabControl tcSetting;
        private System.Windows.Forms.TabPage tpOutput;
        private System.Windows.Forms.TabPage tpAbout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TabPage tpOther;
        private System.Windows.Forms.GroupBox gbMIDIKeyboard;
        private System.Windows.Forms.GroupBox gbUseChannel;
        private System.Windows.Forms.CheckBox cbFM1;
        private System.Windows.Forms.CheckBox cbFM2;
        private System.Windows.Forms.CheckBox cbFM3;
        private System.Windows.Forms.CheckBox cbUseMIDIKeyboard;
        private System.Windows.Forms.CheckBox cbFM4;
        private System.Windows.Forms.CheckBox cbFM5;
        private System.Windows.Forms.CheckBox cbFM6;
        private System.Windows.Forms.ComboBox cmbMIDIIN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbExclusive;
        private System.Windows.Forms.RadioButton rbShare;
        private System.Windows.Forms.Label lblLatencyUnit;
        private System.Windows.Forms.Label lblLatency;
        private System.Windows.Forms.ComboBox cmbLatency;
        private System.Windows.Forms.TabPage tpModule;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbLatencyEmu;
        private System.Windows.Forms.TextBox tbLatencySCCI;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource bs1;
        private System.Windows.Forms.BindingSource bs3;
        private System.Windows.Forms.BindingSource bs2;
        private System.Windows.Forms.BindingSource bs4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbDispFrameCounter;
        private System.Windows.Forms.CheckBox cbHiyorimiMode;
        private System.Windows.Forms.CheckBox cbUseLoopTimes;
        private System.Windows.Forms.Label lblLoopTimes;
        private System.Windows.Forms.TextBox tbLoopTimes;
        private System.Windows.Forms.Button btnOpenSettingFolder;
        private System.Windows.Forms.CheckBox cbUseGetInst;
        private System.Windows.Forms.Button btnDataPath;
        private System.Windows.Forms.TextBox tbDataPath;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tpMIDIKBD;
        private System.Windows.Forms.BindingSource bs5;
        private System.Windows.Forms.BindingSource bs6;
        private System.Windows.Forms.BindingSource bs7;
        private System.Windows.Forms.BindingSource bs8;
        private System.Windows.Forms.ComboBox cmbInstFormat;
        private System.Windows.Forms.Label lblInstFormat;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbScreenFrameRate;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.BindingSource bs9;
        private System.Windows.Forms.BindingSource bs10;
        private System.Windows.Forms.BindingSource bs11;
        private System.Windows.Forms.BindingSource bs12;
        private System.Windows.Forms.CheckBox cbAutoOpen;
        private ucSettingInstruments ucSI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbDumpSwitch;
        private System.Windows.Forms.GroupBox gbDump;
        private System.Windows.Forms.Button btnDumpPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDumpPath;
        private System.Windows.Forms.Button btnResetPosition;
        private System.Windows.Forms.TabPage tabMIDIExp;
        private System.Windows.Forms.CheckBox cbUseMIDIExport;
        private System.Windows.Forms.GroupBox gbMIDIExport;
        private System.Windows.Forms.CheckBox cbMIDIUseVOPM;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cbMIDIYM2612;
        private System.Windows.Forms.CheckBox cbMIDISN76489Sec;
        private System.Windows.Forms.CheckBox cbMIDIYM2612Sec;
        private System.Windows.Forms.CheckBox cbMIDISN76489;
        private System.Windows.Forms.CheckBox cbMIDIYM2151;
        private System.Windows.Forms.CheckBox cbMIDIYM2610BSec;
        private System.Windows.Forms.CheckBox cbMIDIYM2151Sec;
        private System.Windows.Forms.CheckBox cbMIDIYM2610B;
        private System.Windows.Forms.CheckBox cbMIDIYM2203;
        private System.Windows.Forms.CheckBox cbMIDIYM2608Sec;
        private System.Windows.Forms.CheckBox cbMIDIYM2203Sec;
        private System.Windows.Forms.CheckBox cbMIDIYM2608;
        private System.Windows.Forms.CheckBox cbMIDIPlayless;
        private System.Windows.Forms.Button btnMIDIOutputPath;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.TextBox tbMIDIOutputPath;
        private System.Windows.Forms.CheckBox cbWavSwitch;
        private System.Windows.Forms.GroupBox gbWav;
        private System.Windows.Forms.Button btnWavPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbWavPath;
        private System.Windows.Forms.RadioButton rbMONO;
        private System.Windows.Forms.RadioButton rbPOLY;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rbFM6;
        private System.Windows.Forms.RadioButton rbFM3;
        private System.Windows.Forms.RadioButton rbFM5;
        private System.Windows.Forms.RadioButton rbFM2;
        private System.Windows.Forms.RadioButton rbFM4;
        private System.Windows.Forms.RadioButton rbFM1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tpOmake;
        private System.Windows.Forms.TextBox tbCCFadeout;
        private System.Windows.Forms.TextBox tbCCPause;
        private System.Windows.Forms.TextBox tbCCSlow;
        private System.Windows.Forms.TextBox tbCCPrevious;
        private System.Windows.Forms.TextBox tbCCNext;
        private System.Windows.Forms.TextBox tbCCFast;
        private System.Windows.Forms.TextBox tbCCStop;
        private System.Windows.Forms.TextBox tbCCPlay;
        private System.Windows.Forms.TextBox tbCCCopyLog;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbCCDelLog;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbCCChCopy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btVST;
        private System.Windows.Forms.TextBox tbVST;
        private System.Windows.Forms.TabPage tpMIDIOut;
        private System.Windows.Forms.Button btnUP;
        private System.Windows.Forms.Button btnSubMIDIout;
        private System.Windows.Forms.Button btnDOWN;
        private System.Windows.Forms.Button btnAddMIDIout;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dgvMIDIoutList;
        private System.Windows.Forms.DataGridView dgvMIDIoutPallet;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSpacer;
    }
}