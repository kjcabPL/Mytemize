
namespace Mytemize
{
    partial class MZTracker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MZTracker));
            this.trayTracker = new System.Windows.Forms.NotifyIcon(this.components);
            this.cMenuTrackedLists = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCloseList = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuTrackedLists.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayTracker
            // 
            this.trayTracker.ContextMenuStrip = this.cMenuTrackedLists;
            this.trayTracker.Icon = ((System.Drawing.Icon)(resources.GetObject("trayTracker.Icon")));
            this.trayTracker.Text = "notifyIcon1";
            this.trayTracker.Visible = true;
            this.trayTracker.Click += new System.EventHandler(this.trayIconClicked);
            // 
            // cMenuTrackedLists
            // 
            this.cMenuTrackedLists.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCloseList});
            this.cMenuTrackedLists.Name = "cMenuTrackedLists";
            this.cMenuTrackedLists.Size = new System.Drawing.Size(220, 26);
            // 
            // menuCloseList
            // 
            this.menuCloseList.Name = "menuCloseList";
            this.menuCloseList.Size = new System.Drawing.Size(219, 22);
            this.menuCloseList.Text = "Close Mytemize List Tracker";
            this.menuCloseList.Click += new System.EventHandler(this.menuCloseTracker);
            // 
            // MZTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "MZTracker";
            this.Text = "Form1";
            this.cMenuTrackedLists.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayTracker;
        private System.Windows.Forms.ContextMenuStrip cMenuTrackedLists;
        private System.Windows.Forms.ToolStripMenuItem menuCloseList;
    }
}