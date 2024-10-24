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
        public bool isDemo = false, isDisplayPB = true, isMinToTray = false, isPinToDesktop = false, isTracked = false;

        public MZViewerSettings(bool isdemo, bool displayPB, bool minToTray, bool pinToDesktop = false, bool trackList = false)
        {
            isDemo = isdemo;
            isDisplayPB = displayPB;
            isMinToTray = minToTray;
            isTracked = trackList;
            
            // If minimize to tray is enabled, disable pinToDesktop by default
            if (!isMinToTray) isPinToDesktop = pinToDesktop;

            InitializeComponent();
            setupOptions();
        }

        private void cb_Click(Object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == cbMinToTray)
            {
                // disable pin to desktop by default if minimize to tray is enabled
                if (cb.Checked) {
                    cbPinToDesktop.Checked = false;
                    cbPinToDesktop.Enabled = false;
                }
                else
                {
                    cbPinToDesktop.Enabled = true;
                }
            }
        }

        private void setupOptions()
        {
            cbEnablePBar.Checked = isDisplayPB;
            cbMinToTray.Checked = isMinToTray;
            cbPinToDesktop.Checked = isPinToDesktop;
            cbAddToTracker.Checked = isTracked;

            // if (isDemo) cbAddToTracker.Enabled = false;
            if (isMinToTray) cbPinToDesktop.Enabled = false;
        }

        private void button_clicked(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt == btOK)
            {
                isDisplayPB = cbEnablePBar.Checked;
                isMinToTray = cbMinToTray.Checked;
                isPinToDesktop = cbPinToDesktop.Checked;
                isTracked = cbAddToTracker.Checked;
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
