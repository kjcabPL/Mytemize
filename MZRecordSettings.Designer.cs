
namespace Mytemize
{
    partial class MZRecordSettings
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
            this.btOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbIncludePartial = new System.Windows.Forms.CheckBox();
            this.lblRecordName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dpDatePicker = new System.Windows.Forms.MonthCalendar();
            this.cbScheduled = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ttHovertext = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(34, 309);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btCancel_click);
            // 
            // cbIncludePartial
            // 
            this.cbIncludePartial.AutoSize = true;
            this.cbIncludePartial.Location = new System.Drawing.Point(22, 16);
            this.cbIncludePartial.Name = "cbIncludePartial";
            this.cbIncludePartial.Size = new System.Drawing.Size(121, 17);
            this.cbIncludePartial.TabIndex = 2;
            this.cbIncludePartial.Text = "Include Partial State";
            this.cbIncludePartial.UseVisualStyleBackColor = true;
            // 
            // lblRecordName
            // 
            this.lblRecordName.AutoSize = true;
            this.lblRecordName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordName.Location = new System.Drawing.Point(0, 9);
            this.lblRecordName.MinimumSize = new System.Drawing.Size(269, 0);
            this.lblRecordName.Name = "lblRecordName";
            this.lblRecordName.Size = new System.Drawing.Size(269, 16);
            this.lblRecordName.TabIndex = 3;
            this.lblRecordName.Text = "-";
            this.lblRecordName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.dpDatePicker);
            this.panel1.Controls.Add(this.cbScheduled);
            this.panel1.Controls.Add(this.cbIncludePartial);
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 251);
            this.panel1.TabIndex = 4;
            // 
            // dpDatePicker
            // 
            this.dpDatePicker.Enabled = false;
            this.dpDatePicker.Location = new System.Drawing.Point(22, 69);
            this.dpDatePicker.MaxSelectionCount = 1;
            this.dpDatePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dpDatePicker.Name = "dpDatePicker";
            this.dpDatePicker.ShowTodayCircle = false;
            this.dpDatePicker.TabIndex = 4;
            this.dpDatePicker.TrailingForeColor = System.Drawing.SystemColors.HotTrack;
            this.dpDatePicker.Visible = false;
            // 
            // cbScheduled
            // 
            this.cbScheduled.AutoSize = true;
            this.cbScheduled.Location = new System.Drawing.Point(22, 40);
            this.cbScheduled.Name = "cbScheduled";
            this.cbScheduled.Size = new System.Drawing.Size(108, 17);
            this.cbScheduled.TabIndex = 3;
            this.cbScheduled.Text = "Item is scheduled";
            this.cbScheduled.UseVisualStyleBackColor = true;
            this.cbScheduled.Click += new System.EventHandler(this.cbScheduled_click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.lblRecordName);
            this.panel2.Location = new System.Drawing.Point(12, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 33);
            this.panel2.TabIndex = 5;
            // 
            // MZRecordSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(294, 341);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btOK);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 380);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 380);
            this.Name = "MZRecordSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Options";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbIncludePartial;
        private System.Windows.Forms.Label lblRecordName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MonthCalendar dpDatePicker;
        private System.Windows.Forms.CheckBox cbScheduled;
        private System.Windows.Forms.ToolTip ttHovertext;
    }
}