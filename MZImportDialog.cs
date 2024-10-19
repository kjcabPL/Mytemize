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
        const string FILETYPE_CSV = "CSV", FILETYPE_XLS = "XLS", EMPTYCELL = "$$_EMPTY_$$";
        string fileType;

        public MZImportDialog(string mode)
        {
            fileType = mode;
            InitializeComponent();
            setupControls();
        }

        // Setup the controls in the form depending on the value of mode
        private void setupControls()
        {

        }

        // control behavior here
        private void bt_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt == btOK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
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
            }
            else if (rb == rbImportCols && rb.Checked)
            {
                // disable other textboxes
                enableTbGroups(true, 0b0010);
                enableTbGroups(false, 0b1100);
            }
            else if (rb == rbImportRows && rb.Checked)
            {
                // disable other textboxes
                enableTbGroups(true, 0b0100);
                enableTbGroups(false, 0b1010);
            }
            else if (rb == rbImportGrp && rb.Checked)
            {
                // disable other textboxes
                enableTbGroups(true, 0b1000);
                enableTbGroups(false, 0b0110);
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
                tbFromCol.Enabled = enable;
                tbFromRow.Enabled = enable;
                tbToCol.Enabled = enable;
                tbToRow.Enabled = enable;
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
    }
}
