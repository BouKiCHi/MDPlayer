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
    public partial class frmVSTeffectList : Form
    {
        private frmMain parent = null;
        public bool isClosed = false;

        public frmVSTeffectList(frmMain parent)
        {
            InitializeComponent();
            this.Visible = false;
            this.parent = parent;
        }

        private void tsbAddVST_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "VST Pluginファイル(*.dll)|*.dll|すべてのファイル(*.*)|*.*";
            ofd.Title = "ファイルを選択してください";
            //ofd.FilterIndex = setting.other.FilterIndex;

            //if (setting.other.DefaultDataPath != "" && Directory.Exists(setting.other.DefaultDataPath) && IsInitialOpenFolder)
            //{
                //ofd.InitialDirectory = setting.other.DefaultDataPath;
            //}
            //else
            //{
                //ofd.RestoreDirectory = true;
            //}
            ofd.CheckPathExists = true;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            parent.stop();
            while (!Audio.trdStopped) { System.Threading.Thread.Sleep(1); }
            Audio.addVSTeffect(ofd.FileName);
            dispPluginList();

        }

        private void frmVSTeffectList_Shown(object sender, EventArgs e)
        {
            dispPluginList();
        }

        private List<vstInfo2> vstInfos = null;

        public void dispPluginList()
        {
            dgvList.Rows.Clear();

            vstInfos =Audio.getVSTInfos();

            foreach (vstInfo vi in vstInfos)
            {
                dgvList.Rows.Add(vi.key, vi.fileName, vi.power ? "ON" : "OFF", vi.editor ? "OPENED" : "CLOSED", vi.name);
                //dgvList.Rows[0].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //if (vstInfos == null) return;

            //if (e.ColumnIndex == 2)
            //{
            //    vstInfos[e.RowIndex].power = !vstInfos[e.RowIndex].power;
            //    vstInfos[e.RowIndex].vstPlugins.PluginCommandStub.SetBypass(!vstInfos[e.RowIndex].power);
            //    dgvList.Rows[e.RowIndex].Cells[2].Value = vstInfos[e.RowIndex].power ? "ON" : "OFF";
            //}

            //if (e.ColumnIndex == 3)
            //{
            //    vstInfos[e.RowIndex].editor = !vstInfos[e.RowIndex].editor;
            //    if (!vstInfos[e.RowIndex].editor)
            //    {
            //        vstInfos[e.RowIndex].vstPluginsForm.Close();
            //    }
            //    else
            //    {
            //        frmVST dlg = new frmVST();
            //        dlg.PluginCommandStub = vstInfos[e.RowIndex].vstPlugins.PluginCommandStub;
            //        dlg.Show();
            //        vstInfos[e.RowIndex].vstPluginsForm = dlg;
            //    }
            //    dgvList.Rows[e.RowIndex].Cells[3].Value = vstInfos[e.RowIndex].editor ? "OPENED" : "CLOSED";
            //}
        }

        private void frmVSTeffectList_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosed = true;
            //setting.location.PPlayList = this.Location;
            //setting.location.PPlayListWH = new Point(this.Width, this.Height);
            this.Visible = false;
            e.Cancel = true;
        }

        private void tsmiDelThis_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count < 0) return;

            parent.stop();
            while (!Audio.trdStopped) { System.Threading.Thread.Sleep(1); }
            Audio.delVSTeffect((string)dgvList.Rows[dgvList.SelectedRows[0].Index].Cells["clmFileName"].Value);
            dispPluginList();

        }

        private void tsmiDelAll_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("VSTリストの全てのVSTが除去されます。よろしいですか。", "PlayList", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res != DialogResult.OK) return;

            parent.stop();
            while (!Audio.trdStopped) { System.Threading.Thread.Sleep(1); }
            Audio.delVSTeffect("");
            dispPluginList();
        }

        private void dgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvList.Rows[e.RowIndex].Selected = true;

            if (e.Button == MouseButtons.Right)
            {
                if (dgvList.SelectedRows.Count > 1)
                {
                    tsmiDelThis.Text = "選択したVSTを除去";
                }
                else
                {
                    tsmiDelThis.Text = "このVSTを除去";
                }
                cmsVSTEffectList.Show();
                Point p = Control.MousePosition;
                cmsVSTEffectList.Top = p.Y;
                cmsVSTEffectList.Left = p.X;
            }
            else
            {
                if (vstInfos == null) return;

                if (e.ColumnIndex == 2)
                {
                    vstInfos[e.RowIndex].power = !vstInfos[e.RowIndex].power;
                    vstInfos[e.RowIndex].vstPlugins.PluginCommandStub.SetBypass(!vstInfos[e.RowIndex].power);
                    dgvList.Rows[e.RowIndex].Cells[2].Value = vstInfos[e.RowIndex].power ? "ON" : "OFF";
                }

                if (e.ColumnIndex == 3)
                {
                    vstInfos[e.RowIndex].editor = !vstInfos[e.RowIndex].editor;
                    if (!vstInfos[e.RowIndex].editor)
                    {
                        vstInfos[e.RowIndex].vstPluginsForm.Close();
                    }
                    else
                    {
                        frmVST dlg = new frmVST();
                        dlg.PluginCommandStub = vstInfos[e.RowIndex].vstPlugins.PluginCommandStub;
                        dlg.Show();
                        vstInfos[e.RowIndex].vstPluginsForm = dlg;
                    }
                    dgvList.Rows[e.RowIndex].Cells[3].Value = vstInfos[e.RowIndex].editor ? "OPENED" : "CLOSED";
                }

            }

        }
    }
}
