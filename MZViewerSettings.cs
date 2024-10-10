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
    public partial class MZViewerSettings : Form
    {
        public bool isDisplayPB = true, isMinToTray = false;

        public MZViewerSettings(bool displayPB, bool minToTray)
        {
            isDisplayPB = displayPB;
            isMinToTray = minToTray;
            InitializeComponent();
            setupOptions();
        }

        private void setupOptions()
        {
            cbEnablePBar.Checked = isDisplayPB;
            cbMinToTray.Checked = isMinToTray;
        }

        private void button_clicked(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt == btOK)
            {
                isDisplayPB = cbEnablePBar.Checked;
                isMinToTray = cbMinToTray.Checked;
                this.DialogResult = DialogResult.OK;
                
            }
            else if (bt == btCancel)
            {
                this.DialogResult = DialogResult.Cancel;
            }

            this.Close();
        }
    }
}
