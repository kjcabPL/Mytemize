using System;
using System.IO;
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
    public partial class MZTracker : Form
    {
        const string LISTFILE = "lists.txt";

        public MZTracker()
        {
            InitializeComponent();
            startTracker();

        }

        // override the display of the form on load - only show the notify icon
        protected override void OnLoad(EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            base.OnLoad(e);
        }

        protected void startTracker()
        {
            checkListFile();
            trayTracker.Visible = true;
        }


        /*
         *  Menu & Tray Actions
         */

        // Show the default tray icon menu upon click
        private void trayIconClicked(Object sender, EventArgs e)
        {
            cMenuTrackedLists.Show();
        }

        private void menuCloseTracker(Object sender, EventArgs e)
        {
            this.Close();
        }

        /*
         *  Misc Operations
         */

        // check if a list file is present, and if not create one
        private void checkListFile()
        {
            try
            {
                using (FileStream fs = new FileStream(LISTFILE, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    MessageBox.Show("List File detected");
                }
            }
            catch (IOException)
            {
                MessageBox.Show("No List File detected. Creating one...");
            }
        }
        

    }
}
