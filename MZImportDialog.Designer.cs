
namespace Mytemize
{
    partial class MZImportDialog
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
            this.rbImportAll = new System.Windows.Forms.RadioButton();
            this.rbImportCols = new System.Windows.Forms.RadioButton();
            this.tbColumns = new System.Windows.Forms.TextBox();
            this.rbImportRows = new System.Windows.Forms.RadioButton();
            this.tbRows = new System.Windows.Forms.TextBox();
            this.rbImportGrp = new System.Windows.Forms.RadioButton();
            this.tbOptionGroup = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbToCol = new System.Windows.Forms.TextBox();
            this.tbToRow = new System.Windows.Forms.TextBox();
            this.tbFromCol = new System.Windows.Forms.TextBox();
            this.tbFromRow = new System.Windows.Forms.TextBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tbOptionGroup.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbImportAll
            // 
            this.rbImportAll.AutoSize = true;
            this.rbImportAll.Checked = true;
            this.rbImportAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rbImportAll.Location = new System.Drawing.Point(15, 18);
            this.rbImportAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbImportAll.Name = "rbImportAll";
            this.rbImportAll.Size = new System.Drawing.Size(114, 20);
            this.rbImportAll.TabIndex = 0;
            this.rbImportAll.TabStop = true;
            this.rbImportAll.Text = "Import All Cells";
            this.rbImportAll.UseVisualStyleBackColor = true;
            this.rbImportAll.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbImportCols
            // 
            this.rbImportCols.AutoSize = true;
            this.rbImportCols.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rbImportCols.Location = new System.Drawing.Point(15, 52);
            this.rbImportCols.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbImportCols.Name = "rbImportCols";
            this.rbImportCols.Size = new System.Drawing.Size(118, 20);
            this.rbImportCols.TabIndex = 1;
            this.rbImportCols.Text = "Import Columns";
            this.rbImportCols.UseVisualStyleBackColor = true;
            this.rbImportCols.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // tbColumns
            // 
            this.tbColumns.Enabled = false;
            this.tbColumns.Location = new System.Drawing.Point(177, 50);
            this.tbColumns.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbColumns.Name = "tbColumns";
            this.tbColumns.Size = new System.Drawing.Size(140, 22);
            this.tbColumns.TabIndex = 2;
            this.tbColumns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // rbImportRows
            // 
            this.rbImportRows.AutoSize = true;
            this.rbImportRows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rbImportRows.Location = new System.Drawing.Point(15, 86);
            this.rbImportRows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbImportRows.Name = "rbImportRows";
            this.rbImportRows.Size = new System.Drawing.Size(100, 20);
            this.rbImportRows.TabIndex = 3;
            this.rbImportRows.Text = "Import Rows";
            this.rbImportRows.UseVisualStyleBackColor = true;
            this.rbImportRows.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // tbRows
            // 
            this.tbRows.Enabled = false;
            this.tbRows.Location = new System.Drawing.Point(177, 86);
            this.tbRows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbRows.Name = "tbRows";
            this.tbRows.Size = new System.Drawing.Size(140, 22);
            this.tbRows.TabIndex = 4;
            this.tbRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // rbImportGrp
            // 
            this.rbImportGrp.AutoSize = true;
            this.rbImportGrp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rbImportGrp.Location = new System.Drawing.Point(15, 122);
            this.rbImportGrp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbImportGrp.Name = "rbImportGrp";
            this.rbImportGrp.Size = new System.Drawing.Size(153, 20);
            this.rbImportGrp.TabIndex = 5;
            this.rbImportGrp.Text = "Import Selected Cells";
            this.rbImportGrp.UseVisualStyleBackColor = true;
            this.rbImportGrp.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // tbOptionGroup
            // 
            this.tbOptionGroup.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tbOptionGroup.ColumnCount = 1;
            this.tbOptionGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbOptionGroup.Controls.Add(this.panel2, 0, 0);
            this.tbOptionGroup.Location = new System.Drawing.Point(16, 15);
            this.tbOptionGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOptionGroup.Name = "tbOptionGroup";
            this.tbOptionGroup.RowCount = 1;
            this.tbOptionGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 369F));
            this.tbOptionGroup.Size = new System.Drawing.Size(347, 332);
            this.tbOptionGroup.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbRows);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.tbColumns);
            this.panel2.Controls.Add(this.rbImportCols);
            this.panel2.Controls.Add(this.rbImportRows);
            this.panel2.Controls.Add(this.rbImportAll);
            this.panel2.Controls.Add(this.rbImportGrp);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 329);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.tbToCol);
            this.panel4.Controls.Add(this.tbToRow);
            this.panel4.Controls.Add(this.tbFromCol);
            this.panel4.Controls.Add(this.tbFromRow);
            this.panel4.Location = new System.Drawing.Point(4, 172);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(331, 153);
            this.panel4.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "From:";
            // 
            // tbToCol
            // 
            this.tbToCol.Enabled = false;
            this.tbToCol.Location = new System.Drawing.Point(173, 110);
            this.tbToCol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbToCol.Name = "tbToCol";
            this.tbToCol.Size = new System.Drawing.Size(140, 22);
            this.tbToCol.TabIndex = 7;
            this.tbToCol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // tbToRow
            // 
            this.tbToRow.Enabled = false;
            this.tbToRow.Location = new System.Drawing.Point(20, 110);
            this.tbToRow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbToRow.Name = "tbToRow";
            this.tbToRow.Size = new System.Drawing.Size(140, 22);
            this.tbToRow.TabIndex = 6;
            this.tbToRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // tbFromCol
            // 
            this.tbFromCol.Enabled = false;
            this.tbFromCol.Location = new System.Drawing.Point(173, 39);
            this.tbFromCol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFromCol.Name = "tbFromCol";
            this.tbFromCol.Size = new System.Drawing.Size(140, 22);
            this.tbFromCol.TabIndex = 5;
            this.tbFromCol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // tbFromRow
            // 
            this.tbFromRow.Enabled = false;
            this.tbFromRow.Location = new System.Drawing.Point(20, 39);
            this.tbFromRow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFromRow.Name = "tbFromRow";
            this.tbFromRow.Size = new System.Drawing.Size(140, 22);
            this.tbFromRow.TabIndex = 3;
            this.tbFromRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(140)))));
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOK.Location = new System.Drawing.Point(40, 364);
            this.btOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(100, 28);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.bt_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(140)))));
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCancel.Location = new System.Drawing.Point(239, 364);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.bt_Click);
            // 
            // MZImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(379, 417);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.tbOptionGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MZImportDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Settings";
            this.tbOptionGroup.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbImportCols;
        private System.Windows.Forms.TextBox tbColumns;
        private System.Windows.Forms.RadioButton rbImportRows;
        private System.Windows.Forms.TextBox tbRows;
        private System.Windows.Forms.RadioButton rbImportGrp;
        private System.Windows.Forms.TableLayoutPanel tbOptionGroup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbToCol;
        private System.Windows.Forms.TextBox tbToRow;
        private System.Windows.Forms.TextBox tbFromCol;
        private System.Windows.Forms.TextBox tbFromRow;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.RadioButton rbImportAll;
    }
}