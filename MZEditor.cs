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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Mytemize
{
    public partial class mzEditor : Form
    {
        const string PLACEHOLDER_TITLE = "Mytemize Checklist Title Here";
        const string PLACEHOLDER_ITEM = "New List Item";
        const string COL_REMOVE = "colRemove", COL_OPTIONS = "colOptions", COL_DESCRIPTION = "colDescription";

        // only have one file opened at a time to prevent complications
        internal MZList activeFile;

        public string currentFilePath = null;
        public int recordCount;
        public bool isDirty = false;

        public mzEditor()
        {
            InitializeComponent();
            startNewFile();
        }

        private void tbEnable(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.ReadOnly = false;
                if (tb == tbNewItem || tb == tbTitle)
                {
                    tb.SelectAll();
                }
            }
        }

        private void tbDisable(object sender, EventArgs e)
        {           
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.ReadOnly = true;
                if (tb == tbTitle && activeFile != null)
                {
                    if (tbTitle.Text == "") tbTitle.Text = PLACEHOLDER_TITLE;
                    activeFile.Title = tbTitle.Text;
                }
                else if (tb == tbNewItem)
                {
                    if (tbNewItem.Text == "") tbNewItem.Text = PLACEHOLDER_ITEM;
                }
            }
        }

        private void tbNewItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            // disable the textbox after pressing enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                tbNewItem.ReadOnly = true;
            }
        }

        // Button & menu operations
        private void btAddRecord(object sender, EventArgs e)
        {
            if (activeFile == null) return;
            
            string desc = tbNewItem.Text;
            if (activeFile.addRecord(desc))
            {
                recordCount = activeFile.Count;
                updateFileTable();
                tbNewItem.Text = PLACEHOLDER_ITEM;
                if (!isDirty) isDirty = true;
            }
            else
            {
                MessageBox.Show("Error adding new record.", "ERROR");
            }
        }

        private void btRecordSetup(object sender, EventArgs e)
        {
            if (activeFile == null) return;

            Button btSetting = sender as Button;
            if (btSetting == null) return;

            ButtonTagData tagData = btSetting.Tag as ButtonTagData;
            if (tagData != null)
            {
                MessageBox.Show("Opening item setup for " + tagData.entryID);
            }
            
        }

        // DataGridView cell content events here
        private void dgvCellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;
            if (e.RowIndex < 0) return;

            // MessageBox.Show("Cell Clicked: " + e.RowIndex + " - " + e.ColumnIndex + " - " + e.GetType());
            ButtonTagData tagData;

            // a button in the remove column was clicked
            if (e.ColumnIndex == 0)
            {
                tagData = dgv.Rows[e.RowIndex].Cells[COL_REMOVE].Tag as ButtonTagData;
                if (tagData != null)
                {
                    // MessageBox.Show("Removing Entry At: " + tagData.rowID);
                    removeRow(dgRecordsView, e.RowIndex, tagData.entryID);
                }
                if (!isDirty) isDirty = true;
            }
            // a button in the options column was clicked
            else if (e.ColumnIndex == 1)
            {
                MZRecord record = null;
                tagData = dgv.Rows[e.RowIndex].Cells[COL_OPTIONS].Tag as ButtonTagData;
                if (tagData != null) record = activeFile.getRecordById(tagData.entryID);

                if (record != null)
                {
                    MZRecordSettings dialogOptions = new MZRecordSettings(record.id, record.description, record.allowPartial, record.isScheduled, record.schedule);
                    if (dialogOptions.ShowDialog() == DialogResult.OK)
                    {
                        activeFile.getRecordById(record.id).allowPartial = dialogOptions.allowPartial;
                        activeFile.getRecordById(record.id).isScheduled = dialogOptions.isScheduled;
                        activeFile.getRecordById(record.id).schedule = dialogOptions.schedule;

                        if (!isDirty) isDirty = true;
                    }
                }

            }
        }

        // if a description cell is updated, update its specific entry's description as well
        private void dgvCellContentUpdate(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;
            if (e.RowIndex < 0) return;

            // a description cell was updated
            if (e.ColumnIndex == 2)
            {
                ButtonTagData tagData = dgv.Rows[e.RowIndex].Cells[COL_DESCRIPTION].Tag as ButtonTagData;
                if (tagData != null)
                {
                    // MessageBox.Show("Updating Entry At: " + tagData.rowID);
                    if (activeFile != null)
                    {
                        activeFile.getRecordById(tagData.entryID).description = dgv.Rows[e.RowIndex].Cells[COL_DESCRIPTION].Value.ToString();
                    }
                }
            }
        }

        /*
         * Menu Operations
         */

        // startNewFile 
        private void menuNewFile(object sender, EventArgs e)
        {
            // Ask the user if they want to save changes first
            if (isDirty)
            {
                if (MessageBox.Show("Save Changes to the current list?", "Save Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    menuSaveFile(sender, e);
                }
                else startNewFile();
            }
            else startNewFile();
        }

        // Do on menu "open list" is clicked
        private void menuOpenFile(object sender, EventArgs e)
        {
            if (isDirty)
            {
                if (MessageBox.Show("Save Changes to the current list?", "Save Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    menuSaveFile(sender, e);
                }
            }

            OpenFileDialog openFileDG = new OpenFileDialog();
            openFileDG.Filter = "Mytemize Files (*.myz)|*.myz|All files (*.*)|*.*";
            openFileDG.Title = "Open Mytemize List";

            if (openFileDG.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDG.FileName;
                openFile(filePath);
            }
        }

        // Do when save file is clicked
        private void menuSaveFile(object sender, EventArgs e)
        {
            // Open up a save file dialog to collect the path;
            if (currentFilePath == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Mytemize files (*.myz)|*.myz|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Mytemize List";

                // Proceed to save file
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    saveFile(filePath);
                }
            }
            else
            {
                saveFile(currentFilePath);
            }
        }

        private void menuSaveAsFile(object sender, EventArgs e)
        {
            // Open up a save file dialog to collect the path;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Mytemize files (*.myz)|*.myz|All files (*.*)|*.*";
            saveFileDialog.Title = "Save Mytemize List As...";

            // Proceed to save file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                saveFile(filePath);
            }
            
        }

        // Opens the edited file in the viewer. Does not open if changes weren't made 
        private void menuOpenInViewer(object sender, EventArgs e)
        {
            if (activeFile != null && activeFile.Count > 0)
            {
                MZViewer viewer = new MZViewer(currentFilePath, true);
                if (isDirty)
                {
                    // in case the user opens the file and has made changes to it, show the current file changes
                    viewer.setActiveFile(activeFile);
                }
                viewer.Show();
            }
            else MessageBox.Show("List is empty", "Warning", MessageBoxButtons.OK);
        }

        private void menuAbout(object sender, EventArgs e)
        {
            MZAbout aboutWindow = new MZAbout();
            aboutWindow.ShowDialog();
        }

        /*
         * File operations start here.
         */

        // Refresh and start a new file
        private void startNewFile()
        {
            activeFile = new MZList();
            recordCount = activeFile.Count;
            currentFilePath = null;
            tbTitle.Text = PLACEHOLDER_TITLE;
            tbNewItem.Text = PLACEHOLDER_ITEM;
            removeAllRows(dgRecordsView);
            isDirty = false;
        }

        private void openFile(string filePath)
        {
            currentFilePath = filePath;
            try
            {
                removeAllRows(dgRecordsView);
                using (FileStream fs = File.OpenRead(filePath))
                using (StreamReader fsReader = new StreamReader(fs))
                {
                    string data = fsReader.ReadToEnd();
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.Converters.Add(new StringEnumConverter());
                    activeFile = JsonConvert.DeserializeObject<MZList>(data, settings) as MZList;
                    if (activeFile != null)
                    {
                        // change the title text
                        tbTitle.Text = activeFile.Title;
                        for (int i = 0; i <= activeFile.Count; i++)
                        {
                            MZRecord record = activeFile.getRecordById(i);
                            if (record != null)
                            {
                                addRow(dgRecordsView, activeFile.getRecordById(i));
                            }
                        }

                        recordCount = activeFile.Count;
                        currentFilePath = filePath;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("An error has occurred while reading the list: " + filePath + ":\n " + err.Message);
            }
        }

        private void buildRecord(int id, string desc, bool state)
        {
            if (activeFile.addRecord(desc))
            {
                recordCount = activeFile.Count;
                updateFileTable();
             }
            else
            {
                MessageBox.Show("Error adding new record.", "ERROR");
            }
        }

        private void saveFile(string filePath)
        {
            if (activeFile != null)
            {
                activeFile.Title = tbTitle.Text;
                string json = JsonConvert.SerializeObject(activeFile, Formatting.Indented);
                File.WriteAllText(filePath, json);
                currentFilePath = filePath;
            }
        }

        // Window operations start here
        private void updateFileTable()
        {
            // Update table with the new row
            MZRecord temp = activeFile.getRecordLatest();
            if (temp != null)
            {
                addRow(dgRecordsView, temp);
            }
        }

        private void addRow(DataGridView dgv, MZRecord entry = null)
        {
            if (entry == null) return;
            
            // add new row to the data grid view
            int rowIndex = dgv.Rows.Add();
            DataGridViewRow newRow = dgv.Rows[rowIndex];

            // then add the buttons and the description 
            newRow.Cells[COL_REMOVE].Value = "Remove";
            newRow.Cells[COL_REMOVE].Tag = new ButtonTagData(entry.id, rowIndex, entry.state);

            newRow.Cells[COL_OPTIONS].Value = "Options";
            newRow.Cells[COL_OPTIONS].Tag = new ButtonTagData(entry.id, rowIndex, entry.state);

            newRow.Cells[COL_DESCRIPTION].Value = entry.description;
            newRow.Cells[COL_DESCRIPTION].Tag = new ButtonTagData(entry.id, rowIndex, entry.state);
        }

        private void removeRow(DataGridView dgv, int rowID, int entryID)
        {
            if (dgv != null && rowID >= 0)
            {
                activeFile.removeRecordById(entryID);
                // remove the row from the grid view
                dgv.Rows.RemoveAt(rowID);
            }

            if (!isDirty) isDirty = true;
        }

        // clears the table if a new file is launched or open file is triggered
        private void removeAllRows(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.Rows.Clear();
        }
    }

    // class used to include entry data into a "removeEntry" button, to be referenced when removing a tag

    internal class ButtonTagData
    {
        public int entryID, rowID;
        public RecordState recordState;


        //constructor
        public ButtonTagData (int entry = 0, int row = 0, RecordState state = RecordState.INCOMPLETE)
        {
            entryID = entry;
            rowID = row;
            recordState = state;            
        }
    }
}
