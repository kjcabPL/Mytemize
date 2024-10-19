
namespace Mytemize
{
    partial class mzEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mzEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openListInViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNewItem = new System.Windows.Forms.TextBox();
            this.btAddItem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgRecordsView = new System.Windows.Forms.DataGridView();
            this.colRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colOptions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.recordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mZListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecordsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mZListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(140)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_FileNew,
            this.menuStrip_FileOpen,
            this.menuStrip_FileSave,
            this.menuStrip_FileSaveAs,
            this.toolStripSeparator1,
            this.importToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuStrip_FileNew
            // 
            this.menuStrip_FileNew.Name = "menuStrip_FileNew";
            this.menuStrip_FileNew.Size = new System.Drawing.Size(180, 22);
            this.menuStrip_FileNew.Text = "New List";
            this.menuStrip_FileNew.Click += new System.EventHandler(this.menuNewFile);
            // 
            // menuStrip_FileOpen
            // 
            this.menuStrip_FileOpen.Name = "menuStrip_FileOpen";
            this.menuStrip_FileOpen.Size = new System.Drawing.Size(180, 22);
            this.menuStrip_FileOpen.Text = "Open List";
            this.menuStrip_FileOpen.Click += new System.EventHandler(this.menuOpenFile);
            // 
            // menuStrip_FileSave
            // 
            this.menuStrip_FileSave.Name = "menuStrip_FileSave";
            this.menuStrip_FileSave.Size = new System.Drawing.Size(180, 22);
            this.menuStrip_FileSave.Text = "Save List";
            this.menuStrip_FileSave.Click += new System.EventHandler(this.menuSaveFile);
            // 
            // menuStrip_FileSaveAs
            // 
            this.menuStrip_FileSaveAs.Name = "menuStrip_FileSaveAs";
            this.menuStrip_FileSaveAs.Size = new System.Drawing.Size(180, 22);
            this.menuStrip_FileSaveAs.Text = "Save As...";
            this.menuStrip_FileSaveAs.Click += new System.EventHandler(this.menuSaveAsFile);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CSVToolStripMenuItem,
            this.XLSToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // CSVToolStripMenuItem
            // 
            this.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem";
            this.CSVToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CSVToolStripMenuItem.Text = "CSV";
            this.CSVToolStripMenuItem.Click += new System.EventHandler(this.menuImportFile);
            // 
            // XLSToolStripMenuItem
            // 
            this.XLSToolStripMenuItem.Name = "XLSToolStripMenuItem";
            this.XLSToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.XLSToolStripMenuItem.Text = "XLS";
            this.XLSToolStripMenuItem.Click += new System.EventHandler(this.menuImportFile);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openListInViewerToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // openListInViewerToolStripMenuItem
            // 
            this.openListInViewerToolStripMenuItem.Name = "openListInViewerToolStripMenuItem";
            this.openListInViewerToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openListInViewerToolStripMenuItem.Text = "Open in Viewer";
            this.openListInViewerToolStripMenuItem.Click += new System.EventHandler(this.menuOpenInViewer);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.aboutToolStripMenuItem.Text = "About Mytemize List Editor";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.menuAbout);
            // 
            // tbNewItem
            // 
            this.tbNewItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNewItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewItem.Location = new System.Drawing.Point(53, 3);
            this.tbNewItem.Multiline = true;
            this.tbNewItem.Name = "tbNewItem";
            this.tbNewItem.ReadOnly = true;
            this.tbNewItem.Size = new System.Drawing.Size(711, 45);
            this.tbNewItem.TabIndex = 1;
            this.tbNewItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNewItem.Click += new System.EventHandler(this.tbEnable);
            this.tbNewItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNewItem_KeyPress);
            this.tbNewItem.Leave += new System.EventHandler(this.tbDisable);
            this.tbNewItem.LostFocus += new System.EventHandler(this.tbDisable);
            // 
            // btAddItem
            // 
            this.btAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(140)))));
            this.btAddItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAddItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddItem.Image = global::Mytemize.Properties.Resources.add_button;
            this.btAddItem.Location = new System.Drawing.Point(2, 3);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(45, 45);
            this.btAddItem.TabIndex = 0;
            this.btAddItem.UseVisualStyleBackColor = false;
            this.btAddItem.Click += new System.EventHandler(this.btAddRecord);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btAddItem);
            this.panel1.Controls.Add(this.tbNewItem);
            this.panel1.Location = new System.Drawing.Point(12, 505);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 51);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.panel2.BackgroundImage = global::Mytemize.Properties.Resources.myzEditorBG1;
            this.panel2.Controls.Add(this.dgRecordsView);
            this.panel2.Location = new System.Drawing.Point(12, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 428);
            this.panel2.TabIndex = 3;
            // 
            // dgRecordsView
            // 
            this.dgRecordsView.AllowUserToAddRows = false;
            this.dgRecordsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRecordsView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgRecordsView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgRecordsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgRecordsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRecordsView.ColumnHeadersVisible = false;
            this.dgRecordsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRemove,
            this.colOptions,
            this.colDescription});
            this.dgRecordsView.GridColor = System.Drawing.Color.DarkGreen;
            this.dgRecordsView.Location = new System.Drawing.Point(3, 3);
            this.dgRecordsView.MultiSelect = false;
            this.dgRecordsView.Name = "dgRecordsView";
            this.dgRecordsView.RowHeadersVisible = false;
            this.dgRecordsView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgRecordsView.Size = new System.Drawing.Size(757, 422);
            this.dgRecordsView.TabIndex = 1;
            this.dgRecordsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellContentClick);
            this.dgRecordsView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellContentUpdate);
            // 
            // colRemove
            // 
            this.colRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colRemove.FillWeight = 22.04652F;
            this.colRemove.HeaderText = "";
            this.colRemove.MinimumWidth = 30;
            this.colRemove.Name = "colRemove";
            this.colRemove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRemove.Width = 110;
            // 
            // colOptions
            // 
            this.colOptions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colOptions.FillWeight = 21.3198F;
            this.colOptions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colOptions.HeaderText = "";
            this.colOptions.MinimumWidth = 30;
            this.colOptions.Name = "colOptions";
            this.colOptions.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colOptions.Width = 106;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.tbTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(140)))));
            this.tbTitle.Location = new System.Drawing.Point(0, 24);
            this.tbTitle.MaxLength = 52;
            this.tbTitle.MinimumSize = new System.Drawing.Size(784, 33);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.Size = new System.Drawing.Size(784, 30);
            this.tbTitle.TabIndex = 4;
            this.tbTitle.Text = "Checklist Title";
            this.tbTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTitle.Click += new System.EventHandler(this.tbEnable);
            this.tbTitle.Leave += new System.EventHandler(this.tbDisable);
            // 
            // recordsBindingSource
            // 
            this.recordsBindingSource.DataMember = "Records";
            this.recordsBindingSource.DataSource = this.mZListBindingSource;
            // 
            // mZListBindingSource
            // 
            this.mZListBindingSource.DataSource = typeof(Mytemize.MZList);
            // 
            // mzEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.BackgroundImage = global::Mytemize.Properties.Resources.myzEditorBG1;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "mzEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Mytemize Listbuilder";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRecordsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mZListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_FileNew;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_FileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_FileSave;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_FileSaveAs;
        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.TextBox tbNewItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.DataGridView dgRecordsView;
        private System.Windows.Forms.BindingSource mZListBindingSource;
        private System.Windows.Forms.BindingSource recordsBindingSource;
        private System.Windows.Forms.DataGridViewButtonColumn colRemove;
        private System.Windows.Forms.DataGridViewButtonColumn colOptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openListInViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XLSToolStripMenuItem;
    }
}

