
namespace Mytemize
{
    partial class MZViewerSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MZViewerSettings));
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.cbMinToTray = new System.Windows.Forms.CheckBox();
            this.cbEnablePBar = new System.Windows.Forms.CheckBox();
            this.cbPinToDesktop = new System.Windows.Forms.CheckBox();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.LightGreen;
            this.btOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btOK.FlatAppearance.BorderSize = 0;
            this.btOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOK.ForeColor = System.Drawing.Color.DarkGreen;
            this.btOK.Location = new System.Drawing.Point(13, 136);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "Apply";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.button_clicked);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.PaleGreen;
            this.btCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatAppearance.BorderSize = 0;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCancel.ForeColor = System.Drawing.Color.DarkGreen;
            this.btCancel.Location = new System.Drawing.Point(108, 136);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.button_clicked);
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.Transparent;
            this.panelSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSettings.Controls.Add(this.cbPinToDesktop);
            this.panelSettings.Controls.Add(this.cbMinToTray);
            this.panelSettings.Controls.Add(this.cbEnablePBar);
            this.panelSettings.Location = new System.Drawing.Point(13, 13);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Padding = new System.Windows.Forms.Padding(5);
            this.panelSettings.Size = new System.Drawing.Size(170, 112);
            this.panelSettings.TabIndex = 2;
            // 
            // cbMinToTray
            // 
            this.cbMinToTray.AutoSize = true;
            this.cbMinToTray.Location = new System.Drawing.Point(20, 45);
            this.cbMinToTray.Name = "cbMinToTray";
            this.cbMinToTray.Size = new System.Drawing.Size(102, 17);
            this.cbMinToTray.TabIndex = 1;
            this.cbMinToTray.Text = "Minimize to Tray";
            this.cbMinToTray.UseVisualStyleBackColor = true;
            this.cbMinToTray.Click += new System.EventHandler(this.cb_Click);
            // 
            // cbEnablePBar
            // 
            this.cbEnablePBar.AutoSize = true;
            this.cbEnablePBar.Location = new System.Drawing.Point(20, 22);
            this.cbEnablePBar.Name = "cbEnablePBar";
            this.cbEnablePBar.Size = new System.Drawing.Size(116, 17);
            this.cbEnablePBar.TabIndex = 0;
            this.cbEnablePBar.Text = "Show Progress Bar";
            this.cbEnablePBar.UseVisualStyleBackColor = true;
            // 
            // cbPinToDesktop
            // 
            this.cbPinToDesktop.AutoSize = true;
            this.cbPinToDesktop.Location = new System.Drawing.Point(20, 69);
            this.cbPinToDesktop.Name = "cbPinToDesktop";
            this.cbPinToDesktop.Size = new System.Drawing.Size(100, 17);
            this.cbPinToDesktop.TabIndex = 2;
            this.cbPinToDesktop.Text = "Pin To Desktop";
            this.cbPinToDesktop.UseVisualStyleBackColor = true;
            // 
            // MZViewerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mytemize.Properties.Resources.myzViewerBG;
            this.ClientSize = new System.Drawing.Size(194, 171);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.ForeColor = System.Drawing.Color.PaleGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MZViewerSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Settings";
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.CheckBox cbMinToTray;
        private System.Windows.Forms.CheckBox cbEnablePBar;
        private System.Windows.Forms.CheckBox cbPinToDesktop;
    }
}