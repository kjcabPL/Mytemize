﻿
namespace Mytemize
{
    partial class MZViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MZViewer));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colTickbox = new System.Windows.Forms.DataGridViewImageColumn();
            this.colItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btClose = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblDemoOnly = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.trayIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btMini = new System.Windows.Forms.Button();
            this.btSettings = new System.Windows.Forms.Button();
            this.btTrackList = new System.Windows.Forms.Button();
            this.toolTipForm = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(44)))), ((int)(((byte)(43)))));
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.ColumnHeadersVisible = false;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTickbox,
            this.colItems});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(44)))), ((int)(((byte)(43)))));
            this.dgvList.Location = new System.Drawing.Point(13, 149);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft PhagsPa", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(3, 10, 3, 10);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(44)))), ((int)(((byte)(43)))));
            this.dgvList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvList.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvList.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.dgvList.ShowCellErrors = false;
            this.dgvList.ShowCellToolTips = false;
            this.dgvList.ShowEditingIcon = false;
            this.dgvList.ShowRowErrors = false;
            this.dgvList.Size = new System.Drawing.Size(575, 627);
            this.dgvList.TabIndex = 6;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellContent_mouseclick);
            this.dgvList.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellContent_mouseenter);
            this.dgvList.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellContent_mouseleave);
            // 
            // colTickbox
            // 
            this.colTickbox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTickbox.FillWeight = 50.76142F;
            this.colTickbox.HeaderText = "";
            this.colTickbox.Image = global::Mytemize.Properties.Resources.clickbox_empty;
            this.colTickbox.MinimumWidth = 70;
            this.colTickbox.Name = "colTickbox";
            this.colTickbox.ReadOnly = true;
            this.colTickbox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTickbox.Width = 70;
            // 
            // colItems
            // 
            this.colItems.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItems.FillWeight = 149.2386F;
            this.colItems.HeaderText = "";
            this.colItems.MaxInputLength = 200;
            this.colItems.Name = "colItems";
            this.colItems.ReadOnly = true;
            this.colItems.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colItems.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btClose.BackgroundImage = global::Mytemize.Properties.Resources.close_button;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.ForeColor = System.Drawing.Color.Transparent;
            this.btClose.Location = new System.Drawing.Point(574, 5);
            this.btClose.Margin = new System.Windows.Forms.Padding(0);
            this.btClose.MinimumSize = new System.Drawing.Size(20, 20);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(20, 20);
            this.btClose.TabIndex = 7;
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.button_click);
            this.btClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_mousedown);
            this.btClose.MouseEnter += new System.EventHandler(this.button_mouseover);
            this.btClose.MouseLeave += new System.EventHandler(this.button_mouseout);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.PaleGreen;
            this.lbTitle.Location = new System.Drawing.Point(2, 3);
            this.lbTitle.MinimumSize = new System.Drawing.Size(575, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(575, 37);
            this.lbTitle.TabIndex = 8;
            this.lbTitle.Text = "Mytemize Checklist Title";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblProgress);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Location = new System.Drawing.Point(11, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 71);
            this.panel1.TabIndex = 9;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblProgress.Location = new System.Drawing.Point(2, 43);
            this.lblProgress.MinimumSize = new System.Drawing.Size(575, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(575, 19);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "0 out of 0";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDemoOnly
            // 
            this.lblDemoOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDemoOnly.AutoSize = true;
            this.lblDemoOnly.BackColor = System.Drawing.Color.Transparent;
            this.lblDemoOnly.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDemoOnly.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblDemoOnly.Location = new System.Drawing.Point(8, 9);
            this.lblDemoOnly.Margin = new System.Windows.Forms.Padding(0);
            this.lblDemoOnly.Name = "lblDemoOnly";
            this.lblDemoOnly.Size = new System.Drawing.Size(192, 14);
            this.lblDemoOnly.TabIndex = 9;
            this.lblDemoOnly.Text = "Sample List Viewer - Read Only Mode";
            this.lblDemoOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDemoOnly.Visible = false;
            // 
            // pbProgress
            // 
            this.pbProgress.ForeColor = System.Drawing.Color.Yellow;
            this.pbProgress.Location = new System.Drawing.Point(12, 119);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(578, 10);
            this.pbProgress.TabIndex = 10;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.FillWeight = 50.76142F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Mytemize.Properties.Resources.clickbox_empty;
            this.dataGridViewImageColumn1.MinimumWidth = 70;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // trayIcon1
            // 
            this.trayIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon1.Icon")));
            this.trayIcon1.Text = "Mytemize List";
            this.trayIcon1.DoubleClick += new System.EventHandler(this.trayIcon_showWindowFromTray);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.Transparent;
            this.panelFooter.Controls.Add(this.lblFooter);
            this.panelFooter.Location = new System.Drawing.Point(13, 782);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(575, 18);
            this.panelFooter.TabIndex = 11;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblFooter.Location = new System.Drawing.Point(229, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(117, 13);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "Bitknvs Studio © 2024 ";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btMini
            // 
            this.btMini.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btMini.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMini.BackgroundImage")));
            this.btMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btMini.FlatAppearance.BorderSize = 0;
            this.btMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMini.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMini.ForeColor = System.Drawing.Color.Transparent;
            this.btMini.Location = new System.Drawing.Point(549, 5);
            this.btMini.Margin = new System.Windows.Forms.Padding(0);
            this.btMini.MinimumSize = new System.Drawing.Size(20, 20);
            this.btMini.Name = "btMini";
            this.btMini.Size = new System.Drawing.Size(20, 20);
            this.btMini.TabIndex = 12;
            this.btMini.UseVisualStyleBackColor = false;
            this.btMini.Click += new System.EventHandler(this.button_click);
            this.btMini.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_mousedown);
            this.btMini.MouseEnter += new System.EventHandler(this.button_mouseover);
            this.btMini.MouseLeave += new System.EventHandler(this.button_mouseout);
            // 
            // btSettings
            // 
            this.btSettings.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btSettings.BackgroundImage = global::Mytemize.Properties.Resources.setting_button;
            this.btSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSettings.FlatAppearance.BorderSize = 0;
            this.btSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSettings.ForeColor = System.Drawing.Color.Transparent;
            this.btSettings.Location = new System.Drawing.Point(522, 5);
            this.btSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btSettings.MinimumSize = new System.Drawing.Size(20, 20);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(20, 20);
            this.btSettings.TabIndex = 13;
            this.btSettings.UseVisualStyleBackColor = false;
            this.btSettings.Click += new System.EventHandler(this.button_click);
            this.btSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_mousedown);
            this.btSettings.MouseEnter += new System.EventHandler(this.button_mouseover);
            this.btSettings.MouseLeave += new System.EventHandler(this.button_mouseout);
            // 
            // btTrackList
            // 
            this.btTrackList.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btTrackList.BackgroundImage = global::Mytemize.Properties.Resources.tracked_button_inactive;
            this.btTrackList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btTrackList.FlatAppearance.BorderSize = 0;
            this.btTrackList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTrackList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTrackList.ForeColor = System.Drawing.Color.Transparent;
            this.btTrackList.Location = new System.Drawing.Point(493, 5);
            this.btTrackList.Margin = new System.Windows.Forms.Padding(0);
            this.btTrackList.MinimumSize = new System.Drawing.Size(20, 20);
            this.btTrackList.Name = "btTrackList";
            this.btTrackList.Size = new System.Drawing.Size(20, 20);
            this.btTrackList.TabIndex = 14;
            this.btTrackList.UseVisualStyleBackColor = false;
            this.btTrackList.Click += new System.EventHandler(this.button_click);
            this.btTrackList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_mousedown);
            this.btTrackList.MouseEnter += new System.EventHandler(this.button_mouseover);
            this.btTrackList.MouseLeave += new System.EventHandler(this.button_mouseout);
            // 
            // MZViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::Mytemize.Properties.Resources.myzViewerBG;
            this.ClientSize = new System.Drawing.Size(600, 800);
            this.Controls.Add(this.btTrackList);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.btMini);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDemoOnly);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 800);
            this.MinimumSize = new System.Drawing.Size(600, 800);
            this.Name = "MZViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mytemize";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewer_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.viewer_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.viewer_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        protected System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblDemoOnly;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn colTickbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.NotifyIcon trayIcon1;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Button btMini;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btSettings;
        private System.Windows.Forms.Button btTrackList;
        private System.Windows.Forms.ToolTip toolTipForm;
    }
}