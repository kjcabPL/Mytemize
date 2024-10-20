using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mytemize
{
    public partial class MZImportDialog : Form
    {
        const string FILETYPE_CSV = "CSV", FILETYPE_XLS = "XLS", EMPTYCELL = "$$_EMPTY_$$", FILETYPE_TXT = "TXT";

        internal ImportSettings settings;
        public string fileType;

        public MZImportDialog(string mode)
        {
            fileType = mode;
            InitializeComponent();
            setupControls();
        }

        // Setup the controls in the form depending on the value of mode
        private void setupControls()
        {
            settings = new ImportSettings(fileType);
            if (fileType == FILETYPE_TXT)
            {
                rbImportCols.Enabled = false;
                rbImportRows.Enabled = false;
                tbFromCol.Enabled = false;
                tbToCol.Enabled = false;
                rbImportGrp.Text = "Import Selected Lines";
            }
        }

        // control behavior here
        private void bt_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt == btOK)
            {
                int item1, item2;
                settings.targetColumn = int.TryParse(tbColumns.Text, out int val) ? val : 0;
                settings.targetRow = int.TryParse(tbRows.Text, out val) ? val : 0;
                
                item1 = int.TryParse(tbFromRow.Text, out val) ? val : 0;
                item2 = int.TryParse(tbFromCol.Text, out val) ? val : 0;
                settings.grpStartCell = new Tuple<int, int>(item1, item2);

                item1 = int.TryParse(tbToRow.Text, out val) ? val : 0;
                item2 = int.TryParse(tbToCol.Text, out val) ? val : 0;
                settings.grpEndCell = new Tuple<int, int>(item1, item2);

                // check if the end cells are not less than the start cells to prevent confusion
                // Technically, nothing happens with the import, but best to inform the user anyway
                if (settings.grpEndCell.Item1 < settings.grpStartCell.Item1 || settings.grpEndCell.Item2 < settings.grpStartCell.Item2)
                {
                    MessageBox.Show("Target Cell values cannot be less than Starting Cell values", "Error");
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            if (bt == btCancel)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        // radiobutton actions
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == rbImportAll && rb.Checked)
            {
                // disable other textboxes
                enableTbGroups(false, 0b0001);
                settings.importType = "ALL";
            }
            else if (rb == rbImportCols && rb.Checked)
            {
                // disable other textboxes
                enableTbGroups(true, 0b0010);
                enableTbGroups(false, 0b1100);
                settings.importType = "COLUMN";
            }
            else if (rb == rbImportRows && rb.Checked)
            {
                // disable other textboxes
                enableTbGroups(true, 0b0100);
                enableTbGroups(false, 0b1010);
                settings.importType = "ROW";
            }
            else if (rb == rbImportGrp && rb.Checked)
            {
                // disable other textboxes
                enableTbGroups(true, 0b1000);
                enableTbGroups(false, 0b0110);
                settings.importType = "GROUP";
            }
        }

        /// <summary>
        /// Enables/disables the textboxes depending on the clicked radiobutton
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="bFlag"></param>
        private void enableTbGroups(bool enable, int bFlag)
        {
            if (bFlag > 15) return;

            // mask the flag and enable/disable the respective textbox groups
            // If Import All is clicked, disable all settings
            if ((bFlag & 0b0001) == 0b0001)
            {
                bFlag = 0b1110;
            }
            // enables/disables the tbColumns
            if ((bFlag & 0b0010) == 0b0010)
            {
                tbColumns.Enabled = enable;
                if (!enable) tbColumns.Clear();
                else tbColumns.Focus();
            }
            // enables/disables the tbRows
            if ((bFlag & 0b0100) == 0b0100)
            {
                tbRows.Enabled = enable;
                if (!enable) tbRows.Clear();
                else tbRows.Focus();
            }
            // enables/disables the tbFroms and tbTos
            if ((bFlag & 0b1000) == 0b1000)
            {
                tbFromRow.Enabled = enable;
                tbToRow.Enabled = enable;
                
                if (fileType != FILETYPE_TXT)
                {
                    tbFromCol.Enabled = enable;
                    tbToCol.Enabled = enable;
                }
                if (!enable)
                {
                    tbFromCol.Clear();
                    tbFromRow.Clear();
                    tbToCol.Clear();
                    tbToRow.Clear();
                }
                else tbFromRow.Focus();
            }

        }

        // misc functions

        // Detect if the key entered in the textbox is a number. Reject if not
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys such as backpress
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;
            e.Handled = true; // bypass the event
        }
    }
}
