﻿namespace MDPlayer.form
{
    partial class frmMixer2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMixer2));
            this.pbScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbScreen
            // 
            this.pbScreen.Image = global::MDPlayer.Properties.Resources.planeMixer;
            this.pbScreen.Location = new System.Drawing.Point(0, 0);
            this.pbScreen.Name = "pbScreen";
            this.pbScreen.Size = new System.Drawing.Size(320, 216);
            this.pbScreen.TabIndex = 0;
            this.pbScreen.TabStop = false;
            this.pbScreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbScreen_MouseClick);
            this.pbScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMixer2_MouseDown);
            this.pbScreen.MouseEnter += new System.EventHandler(this.pbScreen_MouseEnter);
            this.pbScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMixer2_MouseMove);
            // 
            // frmMixer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 216);
            this.Controls.Add(this.pbScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMixer2";
            this.Text = "Mixer2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMixer2_FormClosed);
            this.Load += new System.EventHandler(this.frmMixer2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMixer2_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMixer2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMixer2_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbScreen;
    }
}