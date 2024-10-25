using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mytemize
{
    public partial class MZViewer : Form
    {
        const string LISTFILE = "lists.txt", ENVLISTPATH = "MYZTRACKER";
        const string COL_ITEM = "colItems", COL_BUTTON = "colTickbox";

        // styles for the DGV cells
        DataGridViewCellStyle cstyleIncomplete, cstyleComplete, cstylePartial, cstyleLate;

        // image resources
        Image imgIncomplete, imgHover, imgPartial, imgComplete, imgLate, prevImage, imgWindowBG;
        Image imgBtClose, imgBtCloseHover, imgBtCloseClicked, imgBtMini, imgBtMiniHover, imgBtMiniClicked;
        Image[] imgBtSettings;

        internal MZList activeFile;
        string currentPath = null, lastKnownPath = null, listFile = LISTFILE;

        bool isDemo = false, isDragging = false, minimizeToTray = false, showProgressBar = true, pinToDesktop = false, isTracked = false, isTrackedBefore = false;
        Point ptDragCursor, ptDragForm;
        
        public MZViewer(string filePath = null, bool demo = false)
        {
            InitializeComponent();
            loadResources();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += MZViewer_BGLoad;

            isDemo = demo;
            if (isDemo) lblDemoOnly.Visible = true;
            if (filePath != null && filePath != "") {
                currentPath = filePath;
                lastKnownPath = currentPath; // lastKnownPath will be used to check what the previously added filePath on the tracker was
                readFilePath();
                updateWindowInfo();
            }
        }

        internal void setActiveFile(MZList file)
        {
            activeFile = file;
            clearAllRows();
            openFile();
            updateWindowInfo();
        }

        // load resources and prepare styles here
        private void loadResources()
        {
            // check tracker file path and update current listFile
            string pathCheck = Environment.GetEnvironmentVariable(ENVLISTPATH);
            if (!string.IsNullOrEmpty(pathCheck)) listFile = pathCheck;

            // load up images
            imgIncomplete = loadEmbeddedImage("Mytemize.Resources.clickbox_empty.bmp");
            imgHover = loadEmbeddedImage("Mytemize.Resources.clickbox_hover.bmp");
            imgPartial = loadEmbeddedImage("Mytemize.Resources.clickbox_partial.bmp");
            imgComplete = loadEmbeddedImage("Mytemize.Resources.clickbox_complete.bmp");
            imgLate = loadEmbeddedImage("Mytemize.Resources.clickbox_late.bmp");
            imgWindowBG = loadEmbeddedImage("Mytemize.Resources.myzViewerBG.png");
            imgBtClose = loadEmbeddedImage("Mytemize.Resources.close_button.bmp");
            imgBtCloseHover = loadEmbeddedImage("Mytemize.Resources.close_button_highlighted.bmp");
            imgBtCloseClicked = loadEmbeddedImage("Mytemize.Resources.close_button_clicked.bmp");
            imgBtMini = loadEmbeddedImage("Mytemize.Resources.min_button.bmp");
            imgBtMiniHover = loadEmbeddedImage("Mytemize.Resources.min_button_hover.bmp");
            imgBtMiniClicked = loadEmbeddedImage("Mytemize.Resources.min_button_clicked.bmp");
            imgBtSettings = new Image[3];
            imgBtSettings[0]= loadEmbeddedImage("Mytemize.Resources.setting_button.bmp");
            imgBtSettings[1] = loadEmbeddedImage("Mytemize.Resources.setting_button_hover.bmp");
            imgBtSettings[2] = loadEmbeddedImage("Mytemize.Resources.setting_button_clicked.bmp");

            // prepare styles
            cstyleIncomplete = new DataGridViewCellStyle();
            // cstyleIncomplete.BackColor = Color.DarkSlateGray;
            cstyleIncomplete.BackColor = Color.FromArgb(34,44,43);
            cstyleIncomplete.ForeColor = Color.White;

            cstyleComplete = new DataGridViewCellStyle();
            cstyleComplete.BackColor = Color.YellowGreen;
            cstyleComplete.ForeColor = Color.Black;

            cstylePartial = new DataGridViewCellStyle();
            cstylePartial.BackColor = Color.Orange;
            cstylePartial.ForeColor = Color.Black;

            cstyleLate = new DataGridViewCellStyle();
            cstyleLate.BackColor = Color.Red;
            cstyleLate.ForeColor = Color.White;

            // set the grid to be unselectable
            dgvList.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        // loads images from the built assembly
        private Image loadEmbeddedImage(string resource)
        {
            // load up the resource based on the passed name
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resource))
            {
                return Image.FromStream(stream);
            }
        }

        /*
         * Button and Control Operations
         */

        // do when user mouseovers on a cell
        private void dgvCellContent_mouseenter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            // check if the mouse is on the button areas
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            prevImage = row.Cells[COL_BUTTON].Value as Image;
            row.Cells[COL_BUTTON].Value = imgHover;

        }

        private void dgvCellContent_mouseleave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            // check if the mouse is on the button areas
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            row.Cells[COL_BUTTON].Value = prevImage;
            
        }

        // If user clicks on the cell, change it to the appropriate image based on the state
        private void dgvCellContent_mouseclick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            // check if the mouse is on the button areas
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                // get the record assigned to the row;
                int id = (int)row.Cells[COL_BUTTON].Tag;
                MZRecord record = activeFile.getRecordById(id);
                RecordState state = record.State;
                

                if (record.allowPartial)
                {
                    // cycle between incomplete, partial and complete statuses
                    if (state == RecordState.INCOMPLETE)
                    {
                        row.Cells[COL_BUTTON].Value = imgPartial;
                        row.Cells[COL_ITEM].Style = cstylePartial;
                        prevImage = imgPartial;
                        activeFile.getRecordById(id).setState = 2;
                    }

                    else if (state == RecordState.PARTIAL)
                    {
                        row.Cells[COL_BUTTON].Value = imgComplete;
                        row.Cells[COL_ITEM].Style = cstyleComplete;
                        prevImage = imgComplete;
                        activeFile.getRecordById(id).setState = 1;
                    }
                    else if (state == RecordState.COMPLETE)
                    {
                        row.Cells[COL_BUTTON].Value = imgIncomplete;
                        row.Cells[COL_ITEM].Style = cstyleIncomplete;
                        prevImage = imgIncomplete;
                        if (record.isScheduled && checkIfLate(record.Schedule))
                        {
                            row.Cells[COL_BUTTON].Value = imgLate;
                            row.Cells[COL_ITEM].Style = cstyleLate;
                            prevImage = imgLate;
                        }
                        activeFile.getRecordById(id).setState = 0;
                    }
                }
                else
                {
                    // just toggle between complete and incomplete, and change the button and cell styles
                    if (state == RecordState.INCOMPLETE)
                    {
                        row.Cells[COL_BUTTON].Value = imgComplete;
                        row.Cells[COL_ITEM].Style = cstyleComplete;
                        prevImage = imgComplete;

                        activeFile.getRecordById(id).setState = 1;
                    }
                    else if (state == RecordState.COMPLETE)
                    {
                        row.Cells[COL_BUTTON].Value = imgIncomplete;
                        row.Cells[COL_ITEM].Style = cstyleIncomplete;
                        prevImage = imgIncomplete;

                        if (record.isScheduled && checkIfLate(record.Schedule))
                        {
                            row.Cells[COL_BUTTON].Value = imgLate;
                            row.Cells[COL_ITEM].Style = cstyleLate;
                            prevImage = imgLate;
                        }
                        activeFile.getRecordById(id).setState = 0;
                    }
                }

                this.Enabled = false;
                saveFile();
            }
        }

        // button animations & behaviors
        private void button_click(Object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt == btClose)
            {
                updateTrackList();
                this.Close();
            }
            if (bt == btMini) {
                this.WindowState = FormWindowState.Minimized;
                if (minimizeToTray && this.WindowState == FormWindowState.Minimized)
                {
                    trayIcon1.Visible = true;
                    this.Hide();
                }
                else
                {
                    trayIcon1.Visible = true;
                }
            }
            if (bt == btSettings) openSettingsWindow();
            
        }

        private void button_mouseover(Object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt == btClose) btClose.BackgroundImage = imgBtCloseHover;
            if (bt == btMini) btMini.BackgroundImage = imgBtMiniHover;
            if (bt == btSettings) btSettings.BackgroundImage = imgBtSettings[1];
        }

        private void button_mouseout(Object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt == btClose) btClose.BackgroundImage = imgBtClose;
            if (bt == btMini) btMini.BackgroundImage = imgBtMini;
            if (bt == btSettings) btSettings.BackgroundImage = imgBtSettings[0];
        }

        private void button_mousedown(Object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            if (bt == btClose) btClose.BackgroundImage = imgBtCloseClicked;
            if (bt == btMini) btMini.BackgroundImage = imgBtMiniClicked;
            if (bt == btSettings) btSettings.BackgroundImage = imgBtSettings[2];
        }

        /*
         * File operations
         */

        // used to read the file via a filepath 
        private void readFilePath()
        {
            if (currentPath == "" || currentPath == null) return;

            try
            {
                using (FileStream fs = File.OpenRead(currentPath))
                using (StreamReader fsReader = new StreamReader(fs))
                {
                    string data = fsReader.ReadToEnd();
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.Converters.Add(new StringEnumConverter());
                    activeFile = JsonConvert.DeserializeObject<MZList>(data, settings) as MZList;
                    if (activeFile != null)
                    {
                        // change the title text
                        lbTitle.Text = activeFile.title;
                        isTracked = activeFile.isTracked;
                        isTrackedBefore = isTracked;

                        for (int i = 0; i <= activeFile.Count; i++)
                        {
                            string fullText = "Record #" + i + ":";
                            MZRecord record = activeFile.getRecordById(i);
                            if (record != null)
                            {
                                addRow(activeFile.getRecordById(i));
                            }
                        }
                        updateProgress();
                        
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("An error has occurred while reading the list: " + currentPath + ":\n " + err.Message);
            }
        }

        private void openFile()
        {
            if (activeFile == null) return;

            lbTitle.Text = activeFile.title;
            for (int i = 0; i <= activeFile.Count; i++)
            {
                MZRecord record = activeFile.getRecordById(i);
                if (record != null)
                {
                    addRow(record);
                }
            }

            updateProgress();
        }
        protected void openFile(string path)
        {
            if (path == "") return;
            currentPath = path;
            readFilePath();
            updateProgress();
        }

        protected void saveFile()
        {
            // prevent saving the file if is in viewer demo mode
            if (!isDemo && currentPath != null)
            {
                string json = JsonConvert.SerializeObject(activeFile, Formatting.Indented);
                File.WriteAllText(currentPath, json);
            }
            this.Enabled = true;
            updateProgress();
        }


        /*
         * misc operations here
         */
        private void addRow(MZRecord entry)
        {
            if (entry == null) return;

            // add new row first
            int rowIndex = dgvList.Rows.Add();
            DataGridViewRow row = dgvList.Rows[rowIndex];

            // Take the description from the entry
            string itemDesc = entry.description;
            if (entry.isScheduled) itemDesc += "\n" + entry.schedule.ToString("D");
            
            // then populate the row;
            row.Cells[COL_ITEM].Value = itemDesc;

            // change the image based on the state
            if (entry.state == RecordState.COMPLETE)
            {
                row.Cells[COL_BUTTON].Value = imgComplete;
                row.Cells[COL_ITEM].Style = cstyleComplete;
            }
            else if (entry.state == RecordState.PARTIAL)
            {
                row.Cells[COL_BUTTON].Value = imgPartial;
                row.Cells[COL_ITEM].Style = cstylePartial;
            }
            else
            {
                // also check first if the entry is late to set the column to a late state
                row.Cells[COL_BUTTON].Value = imgIncomplete;
                row.Cells[COL_ITEM].Style = cstyleIncomplete;

                if (entry.isScheduled && checkIfLate(entry.schedule))
                {
                    row.Cells[COL_BUTTON].Value = imgLate;
                    row.Cells[COL_ITEM].Style = cstyleLate; 
                }
                
            }
            row.Cells[COL_BUTTON].Tag = entry.ID;

        }

        // call if a new file is opened via the viewer
        private void clearAllRows()
        {
            dgvList.Rows.Clear();
        }

        // Update window information
        private void updateWindowInfo()
        {
            lbTitle.Text = activeFile.Title;
            trayIcon1.Text = "Mytemize | " + activeFile.Title;
            
            // update list settings as well
            if (!showProgressBar) pbProgress.Visible = false;
            else pbProgress.Visible = true;

            // disable minimize button if pinToDesktop is enabled and vice versa
            btMini.Enabled = !pinToDesktop;
        }

        // update the progress bar as needed
        private void updateProgress()
        {
            // cast to int because progress bar's value only allows integers. Ensures the cap is 100
            pbProgress.Value = (int) Math.Min(Math.Round(activeFile.checkProgress(), MidpointRounding.AwayFromZero), 100);
            lblProgress.Text = activeFile.checkCompletedEntries().ToString() + " out of " + activeFile.Count.ToString();
        }

        // Opens the settings window
        private void openSettingsWindow()
        {
            MZViewerSettings settings = new MZViewerSettings(isDemo, showProgressBar, minimizeToTray, pinToDesktop, isTracked);

            if (settings.ShowDialog() == DialogResult.OK)
            {
                showProgressBar = settings.isDisplayPB;
                minimizeToTray = settings.isMinToTray;
                pinToDesktop = settings.isPinToDesktop;
                isTracked = settings.isTracked;
                if (isTracked != isTrackedBefore)
                {
                    activeFile.isTracked = isTracked;
                    saveFile();
                }
            }
            updateWindowInfo();
        }

        // Display the window from the tray Icon when minimized
        private void trayIcon_showWindowFromTray(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        // use to check if the entry is already late if it's a scheduled Entry
        private bool checkIfLate(DateTime date)
        {
            bool isLate = false;

            DateTime dateToCheck = date.Date;
            if (dateToCheck < DateTime.Now) isLate = true;

            return isLate;
        }

        // Add dragging to the form body
        private void viewer_MouseDown(object sender, MouseEventArgs e)
        {
            // Start dragging
            isDragging = true;
            ptDragCursor = Cursor.Position;
            ptDragForm = this.Location;
        }

        private void viewer_MouseMove(object sender, MouseEventArgs e)
        {
            // move the form based on where the cursor is
            if (isDragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(ptDragCursor));
                this.Location = Point.Add(ptDragForm, new Size(diff));
            }
        }

        private void viewer_MouseUp(object sender, MouseEventArgs e)
        {
            // stop dragging
            isDragging = false;
        }
        
        // record the file's current location if it is tracked or vice-versa
        private void updateTrackList()
        {
            // if the list was tracked before but isn't now, then remove the file's entry from the tracker
            if (!isTracked && isTrackedBefore)
            {
                // remove the lists' path from the file
                if (File.Exists(listFile))
                {
                    bool isPresent = false;
                    string linesToWrite = "";
                    // Check if the list file has the file path available, then write if not yet
                    using (FileStream fs = new FileStream(listFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var sr = new StreamReader(fs))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {                            
                            line = line.Trim();
                            if (String.Equals(line, currentPath, StringComparison.OrdinalIgnoreCase))
                            {
                                isPresent = true; // found it, now filter it out
                            }
                            else linesToWrite += line + "\n\r";
                        }
                    }

                    // rewrite the list file
                    using (StreamWriter sw = new StreamWriter(listFile))
                    {
                        sw.Write(linesToWrite);
                    }
                }
                else MessageBox.Show("Application Error: Unable to track file - list file not found. ", "ERROR");
            }
            // if is now tracked and was not tracked before
            else if (isTracked && !isTrackedBefore)
            {
                // Look for the list file
                if (File.Exists(listFile))
                {
                    bool isPresent = false;
                    // Check if the list file has the file path available, then write if not yet
                    using (FileStream fs = new FileStream(listFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var sr = new StreamReader(fs))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            line = line.Trim();
                            if (String.Equals(line, currentPath, StringComparison.OrdinalIgnoreCase))
                            {
                                isPresent = true; //it's already here, no need to record
                                break;
                            }
                        }
                    }

                    // We did not find the file yet, better record the file
                    if (!isPresent)
                    {
                        using (StreamWriter sw = File.AppendText(listFile))
                        {
                            sw.WriteLine(currentPath);
                        }       
                    }
                }
                else MessageBox.Show("Application Error: Unable to track file - list file not found. ", "ERROR");
            }
        }

        // Load the background image as a semi-transparent object
        private void MZViewer_BGLoad(object sender, EventArgs e)
        {
            // Load the image with transparency
            // Bitmap bitmap = new Bitmap("Mytemize.Resources.myzViewerBG.png");
            Bitmap bitmap = new Bitmap(imgWindowBG);

            // Set the layered window attribute:
            setLayeredWindow(bitmap);
        }

        private void setLayeredWindow(Bitmap bmp)
        {
            IntPtr screenDC = GetDC(IntPtr.Zero);
            IntPtr memDC = CreateCompatibleDC(screenDC);
            IntPtr hBmp = bmp.GetHbitmap(Color.FromArgb(0));
            IntPtr oldBmp = SelectObject(memDC, hBmp);

            // start constructing the new bitmap here
            Size size = new Size(bmp.Width, bmp.Height);
            Point src = new Point(0, 0);
            Point topPos = new Point(this.Left, this.Top);
            BLENDFUNCTION blend = new BLENDFUNCTION();
            blend.BlendOp = AC_SRC_OVER;
            blend.BlendFlags = 0;
            blend.SourceConstantAlpha = 255;
            blend.AlphaFormat = AC_SRC_ALPHA;

            // change the bitmap of the window here
            UpdateLayeredWindow(this.Handle, screenDC, ref topPos, ref size, memDC, ref src, 0, ref blend, ULW_ALPHA);

            // Apply the bitmap changes into the new bitmap here
            SelectObject(memDC, oldBmp);
            DeleteObject(hBmp);
            DeleteDC(memDC);
            ReleaseDC(IntPtr.Zero, screenDC);
        }

        /*
         * DLL imports and Structs for transparent pixel drawing
         */

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        private const int ULW_ALPHA = 0x00000002;
        private const byte AC_SRC_OVER = 0x00, AC_SRC_ALPHA = 0x01;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UpdateLayeredWindow(
            IntPtr hwnd, 
            IntPtr hdcDst, 
            ref Point pptDst, 
            ref Size psize, 
            IntPtr hdcSrc, 
            ref Point pptSrc, 
            int crKey, 
            ref BLENDFUNCTION pblend, 
            int dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);

    }
}
