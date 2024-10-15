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
    public partial class MZRecordSettings : Form
    {
        public int entryID;
        public string description;
        public DateTime schedule;
        public bool allowPartial = false, isScheduled = false;

        public MZRecordSettings(int id, string desc, bool isPartial, bool hasSchedule = false, DateTime? date = null)
        {
            InitializeComponent();
            entryID = id;
            description = desc;
            allowPartial = isPartial;
            isScheduled = hasSchedule;

            if (date.HasValue) schedule = date.Value;
            else schedule = DateTime.Now;
            
            setUpQuestions();
            setupToolTips();
        }

        // button and control events
        private void btOK_click(Object sender, EventArgs e)
        {
            allowPartial = cbIncludePartial.Checked;
            isScheduled = cbScheduled.Checked;
            if (isScheduled) schedule = dpDatePicker.SelectionStart;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_click(Object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbScheduled_click(Object sender, EventArgs e)
        {
            if (cbScheduled.Checked)
            {
                dpDatePicker.Visible = true;
                dpDatePicker.Enabled = true;
            }
            else
            {
                dpDatePicker.Visible = false;
                dpDatePicker.Enabled = false;
            }
        }

        /*
         * Misc Operations
         */
        private void setUpQuestions()
        {
            this.Text = "Options for " + description + " ";
            lblRecordName.Text = description + " Settings:";
            cbIncludePartial.Checked = allowPartial;
            cbScheduled.Checked = isScheduled;
            if (isScheduled)
            {
                dpDatePicker.Enabled = true;
                dpDatePicker.Visible = true;
                dpDatePicker.SetDate(schedule);
                dpDatePicker.SelectionStart = schedule;
                dpDatePicker.SelectionEnd = schedule;
            }
            
        }
        private void setupToolTips()
        {
            ttHovertext.SetToolTip(cbIncludePartial, "Enable this setting to allow the item to have a partial/in progress state, marking the item yellow in the viewer");   
            ttHovertext.SetToolTip(cbScheduled, "Enable this setting to set an expiration date for the item. When the current date is past the item's date, this will mark the item as Red in the viewer");

        }

    }
}
