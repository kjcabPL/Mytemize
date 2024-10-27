using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CsvHelper;
using CsvHelper.Configuration;
using ExcelDataReader;


namespace Mytemize
{

    public partial class mzEditor : Form
    {
        const string PLACEHOLDER_TITLE = "Checklist Title", PLACEHOLDER_ITEM = "New List Item", ENVLISTPATH = "MYZTRACKER", STUDIONAME = "Bitknvs Studio", APPNAME = "Mytemize";
        const string COL_REMOVE = "colRemove", COL_OPTIONS = "colOptions", COL_DESCRIPTION = "colDescription";
        const string FILETYPE_CSV = "CSV", FILETYPE_XLS = "XLS", FILETYPE_TXT = "TXT", EMPTYCELL = "$$_EMPTY_$$", LISTFILE = "lists.txt";

        // only have one file opened at a time to prevent complications
        internal MZList activeFile;

        public string currentFilePath = null, listFile = LISTFILE;
        public int recordCount;
        public bool isDirty = false, trackerActive = false;

        public mzEditor(string action = null, string filePath = "", string type = "")
        {
            InitializeComponent();
            createListFile();

            // check if any arguments were passed into the program
            if (!string.IsNullOrEmpty(action))
            {
                if (action == "import")
                {
                    ImportSettings setting = new ImportSettings(type, "ALL");
                    importFile(filePath, setting);
                }
            }
            else startNewFile();
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
                    if (string.IsNullOrEmpty(tbTitle.Text)) tbTitle.Text = PLACEHOLDER_TITLE;
                    else isDirty = true;
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
                tbNewItem.Focus();
            }
        }

        // Button & menu operations
        private void btAddRecord(object sender, EventArgs e)
        {
            if (activeFile == null) return;
            
            string desc = tbNewItem.Text;
            if (activeFile.addRecord(desc))
            {
                updateFileTable();
                tbNewItem.Text = PLACEHOLDER_ITEM;
            }
            else MessageBox.Show("Error adding new record.", "ERROR");
        }

        private void btRecordSetup(object sender, EventArgs e)
        {
            if (activeFile == null) return;

            Button btSetting = sender as Button;
            if (btSetting == null) return;

            ButtonTagData tagData = btSetting.Tag as ButtonTagData;         
        }

        /*
         *  DataGridView and DGV cell content events here
         */
        private void dgvCellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;
            if (e.RowIndex < 0) return;

            ButtonTagData tagData;

            // a button in the remove column was clicked
            if (e.ColumnIndex == 0)
            {
                tagData = dgv.Rows[e.RowIndex].Cells[COL_REMOVE].Tag as ButtonTagData;
                if (tagData != null) removeRow(dgRecordsView, e.RowIndex, tagData.entryID);
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
                    if (activeFile != null) activeFile.getRecordById(tagData.entryID).description = dgv.Rows[e.RowIndex].Cells[COL_DESCRIPTION].Value.ToString();
                }
            }
        }

        // If a file is dragged over the datagridview
        private void dgvArea_DragEnter(object sender, DragEventArgs e)
        {
            panelDragDropLabel.Visible = true;
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
            
        }

        // Once a file is dropped the datagridview 
        private void dgvArea_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Dropped file data will ALWAYS be in an array, even if it's just one file. We only take the first one here.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    checkIfDirty(sender); // check first if document is dirty and prompt user to save changes if so
                    string file = files[0];
                    if (Path.GetExtension(file).Equals(".myz", StringComparison.OrdinalIgnoreCase)) openFile(file);
                    else if (Path.GetExtension(file).Equals(".csv", StringComparison.OrdinalIgnoreCase)) preImportChecks(FILETYPE_CSV, file);
                    else if (Path.GetExtension(file).Equals(".txt", StringComparison.OrdinalIgnoreCase)) preImportChecks(FILETYPE_TXT, file);
                    else if (Path.GetExtension(file).Equals(".xls", StringComparison.OrdinalIgnoreCase) || Path.GetExtension(file).Equals(".xlsx", StringComparison.OrdinalIgnoreCase)) preImportChecks(FILETYPE_XLS, file);
                    else MessageBox.Show("Unable to import file as list: File type not supported.", "Import Error");
                }
            }
            panelDragDropLabel.Visible = false;
        }

        // Once a the dragdrop event leaves
        private void dgvArea_DragLeave(object sender, EventArgs e)
        {
            panelDragDropLabel.Visible = false;
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
                if (MessageBox.Show("Save Changes to the current list?", "Save Changes", MessageBoxButtons.YesNo) == DialogResult.Yes) menuSaveFile(sender, e);
                else startNewFile();
            }
            else startNewFile();
        }

        // Do on menu "open list" is clicked
        private void menuOpenFile(object sender, EventArgs e)
        {
            checkIfDirty(sender);

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
            saveFileDialog();
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

        // Import menu
        private void menuImportFile(object sender, EventArgs e)
        {
            checkIfDirty(sender);
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            // first, open a dialog to the CSV to import
            OpenFileDialog openFileDG = new OpenFileDialog();

            if (menuItem == TXTToolStripMenuItem) preImportChecks(FILETYPE_TXT);
            else if (menuItem == CSVToolStripMenuItem) preImportChecks(FILETYPE_CSV);
            else if (menuItem == XLSToolStripMenuItem) preImportChecks(FILETYPE_XLS);

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

        // Start/Stop the tracker
        private void menuStartTracker(object sender, EventArgs e)
        {
            // start the tracker via another process to make it independent of this form
            Process.Start("Mytemize.exe", "-t -start");
        }

        // Open the About form
        private void menuAbout(object sender, EventArgs e)
        {
            MZAbout aboutWindow = new MZAbout();
            aboutWindow.ShowDialog();
        }

        // keypress detection such as ctrl+S keyword
        private void form_keyDown(Object sender, KeyEventArgs e)
        {
            // ctrl + S action
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (isDirty && !string.IsNullOrEmpty(currentFilePath)) saveFile(currentFilePath);
                else saveFileDialog();
                e.SuppressKeyPress = true; // prevent from bubbling into other controls
            }
        }

        // keypress detection specific for tbNewItem
        private void tbNewItem_keyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(tbNewItem.Text))
                {
                    if (activeFile.addRecord(tbNewItem.Text))
                    {
                        updateFileTable();
                        tbNewItem.Text = PLACEHOLDER_ITEM;
                    }
                }
            }
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

        // Open a file for editing
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
                            if (record != null) addRow(dgRecordsView, activeFile.getRecordById(i));
                        }
                        recordCount = activeFile.Count;
                        currentFilePath = filePath;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error has occurred while reading the list: " + filePath + ":\n " + err.Message, "ERROR");
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
                MessageBox.Show("Error adding new record", "ERROR");
            }
        }

        private void saveFileDialog()
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

        private void saveFile(string filePath)
        {
            if (activeFile != null)
            {
                activeFile.Title = tbTitle.Text;
                string json = JsonConvert.SerializeObject(activeFile, Formatting.Indented);
                File.WriteAllText(filePath, json);
                currentFilePath = filePath;
                isDirty = false;
            }
        }

        // Import different file types into Lists here

        private void preImportChecks(string fileType, string fileName = null)
        {
            MZImportDialog importDialog;
            string file = "";
            OpenFileDialog openFileDG = new OpenFileDialog();

            if (string.IsNullOrEmpty(fileName))
            {
                if (fileType == FILETYPE_TXT)
                {
                    //   file = FILETYPE_TXT;
                    openFileDG.Filter = "Text files (*.txt) | *.txt";
                    openFileDG.Title = "Import Text File as List";
                }
                else if (fileType == FILETYPE_CSV)
                {
                    //   file = FILETYPE_CSV;
                    openFileDG.Filter = "Comma-separated Value Files (*.csv) | *.csv";
                    openFileDG.Title = "Import CSV as List";
                }
                else if (fileType == FILETYPE_XLS)
                {
                    //   file = FILETYPE_XLS;
                    openFileDG.Filter = "Excel files (*.xlsx;*.xls) | *.xlsx;*.xls";
                    openFileDG.Title = "Import Excel Sheet as List";
                }

                // first, open a dialog to the CSV to import
                if (openFileDG.ShowDialog() == DialogResult.OK)
                {
                    file = openFileDG.FileName;

                    // Check first if the selected file is not busy or opened in a different program
                    if (checkFileIsAvailable(file))
                    {
                        importDialog = new MZImportDialog(fileType);
                        if (importDialog.ShowDialog() == DialogResult.OK)
                        {
                            ImportSettings settings = importDialog.settings;
                            importFile(file, settings);
                        }
                    }
                    else MessageBox.Show("Unable to import file as list: File is open in another program.", "Import Error");

                }
            }
            // preimportchecks was initiated by drag and drop
            else
            {
                if (checkFileIsAvailable(fileName))
                {
                    importDialog = new MZImportDialog(fileType);
                    if (importDialog.ShowDialog() == DialogResult.OK)
                    {
                        ImportSettings settings = importDialog.settings;
                        importFile(fileName, settings);
                    }
                }
                else MessageBox.Show("Unable to import file as list: File is open in another program.", "Import Error");
            }
            
        }

        private void importFile(string filePath, ImportSettings settings)
        {
            string fileType = settings.fileType;
            if (fileType != FILETYPE_CSV &&
                fileType != FILETYPE_XLS &&
                fileType != FILETYPE_TXT) return;

            string action = settings.importType;
            int rowID = 0, colID = 0;
            bool fileStarted = false, recordItem = false;

            if (fileType == FILETYPE_CSV) 
            {
                // Open a stream to the filepath
                // To-do - check if the file is currently opened by another program
                using (var fs = new StreamReader(filePath))
                using (var csv = new CsvReader(fs, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    
                    var records = new List<dynamic>();
                    while (csv.Read())
                    {
                        // traverse each row and get a dictionary entry per cell
                        var row = new Dictionary<int, string>();
                        for (int i = 0; csv.TryGetField<string>(i, out string field); i++)
                        {
                            if (string.IsNullOrEmpty(field)) field = EMPTYCELL;
                            row[i] = field;
                        }
                        records.Add(row);
                    }

                    // We got some records, time to build that list
                    if (records.Count > 0)
                    {
                        foreach (var record in records)
                        {
                            // only set recordItem to true if action type is ALL
                            recordItem = (action == "ALL") ? true : false;
                            if (action == "ROW") recordItem = (rowID == (settings.targetRow - 1)) ? true : false;
                            foreach (var item in record)
                            {
                                // check if target column matches the current column ID
                                if (action == "COLUMN") recordItem = (colID == (settings.targetColumn - 1)) ? true : false;
                                if (action == "GROUP")
                                {
                                    recordItem = (rowID >= (settings.grpStartCell.Item1 - 1) && rowID < settings.grpEndCell.Item1) ? true : false;
                                    if (recordItem) recordItem = (colID >= (settings.grpStartCell.Item2 - 1) && colID < settings.grpEndCell.Item2) ? true : false;
                                }
                                if (!string.Equals(item.Value,EMPTYCELL))
                                {
                                    // A non-empty cell is found, Now restart the current file since we are now sure that we imported at least ONE data from the CSV
                                    if (recordItem)
                                    {
                                        if (!fileStarted)
                                        {
                                            startNewFile();
                                            fileStarted = true;
                                        }
                                        activeFile.addRecord(item.Value);
                                        updateFileTable();
                                    }
                                }
                                colID++;
                            }
                            colID = 0;
                            rowID++;
                        }
                    }
                } 
            }
            else if (fileType == FILETYPE_XLS)
            {
                using (var fs = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    // read the opened filestream as an excelReaderFactory
                    using (var xls = ExcelReaderFactory.CreateReader(fs))
                    {
                        // get the data set from the excel file. Each sheet corresponds to a table in the Tables array
                        var result = xls.AsDataSet();
                        var table = result.Tables[0];
                        foreach (DataRow row in table.Rows)
                        {
                            // only set recordItem to true if action type is ALL
                            recordItem = (action == "ALL") ? true : false;
                            if (action == "ROW") recordItem = (rowID == (settings.targetRow)) ? true : false;
                            foreach (var item in row.ItemArray)
                            {
                                // check if target column matches the current column ID
                                if (action == "COLUMN") recordItem = (colID == (settings.targetColumn)) ? true : false;
                                if (action == "GROUP")
                                {
                                    recordItem = (rowID >= (settings.grpStartCell.Item1) && rowID <= settings.grpEndCell.Item1) ? true : false;
                                    if (recordItem) recordItem = (colID >= (settings.grpStartCell.Item2) && colID <= settings.grpEndCell.Item2) ? true : false;
                                }
                                if (!string.IsNullOrEmpty(item.ToString()))
                                {
                                    if (recordItem)
                                    {
                                        if (!fileStarted)
                                        {
                                            startNewFile();
                                            fileStarted = true;
                                        }
                                        activeFile.addRecord(item.ToString());
                                        updateFileTable();
                                    }
                                }
                                colID++;
                            }
                            colID = 0;
                            rowID++;
                        }
                    }
                }
            }
            else if (fileType == FILETYPE_TXT)
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var contents = new StreamReader(fs))
                {
                    string line;
                    rowID = 1;
                    while ((line = contents.ReadLine()) != null)
                    {
                        recordItem = (action == "ALL") ? true : false;
                        if (action == "GROUP") recordItem = (rowID >= (settings.grpStartCell.Item1) && rowID <= settings.grpEndCell.Item1) ? true : false;
                        if (!string.IsNullOrEmpty(line))
                        {
                            if (recordItem)
                            {
                                if (!fileStarted)
                                {
                                    startNewFile();
                                    fileStarted = true;
                                }
                                activeFile.addRecord(line);
                                updateFileTable();
                            }
                        }
                        rowID++;
                    }
                }
            }
        }

        private bool checkFileIsAvailable(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath)) return false;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }

        // Window operations start here
        private void updateFileTable()
        {
            // Update table with the new row
            MZRecord temp = activeFile.getRecordLatest();
            if (temp != null) addRow(dgRecordsView, temp);
            recordCount = activeFile.Count;
            if (!isDirty) isDirty = true;
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

        // method to check if file is dirty and prompt user if so
        private void checkIfDirty(Object sender)
        {
            if (isDirty)
            {
                if (MessageBox.Show("Save Changes to the current list?", "Save Changes", MessageBoxButtons.YesNo) == DialogResult.Yes) saveFileDialog();
            }
        }

        // Create a list file for the tracker if it's not present yet
        private void createListFile()
        {
            // write to appdata instead of program files due to elevated privilege issues
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), STUDIONAME, APPNAME, LISTFILE);
            string listDir = Path.GetDirectoryName(appDataPath);
            listFile = appDataPath;
            if (!Directory.Exists(listDir)) Directory.CreateDirectory(listDir);
            if (!File.Exists(listFile)) File.WriteAllText(listFile, "");
        }
    }

    // class used to include entry data into a "removeEntry" button, to be referenced when removing a tag

    internal class ButtonTagData
    {
        public int entryID, rowID;
        public RecordState recordState;

        public ButtonTagData (int entry = 0, int row = 0, RecordState state = RecordState.INCOMPLETE)
        {
            entryID = entry;
            rowID = row;
            recordState = state;            
        }
    }
}
