﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mytemize
{
    public partial class MZTracker : Form
    {
        const string LISTFILE = "lists.txt", ENVLISTPATH = "MYZTRACKER";
        string envListPath = LISTFILE;
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
            addTrackedLists();
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

        // Do when a context menu item except for menuClose is clicked
        private void menuItemClicked(Object sender, EventArgs e)
        {
            ToolStripItem listFile = sender as ToolStripItem;
            String filePath = listFile.Tag as String;
            openMytemizeList(filePath);
        }

        /*
         *  Misc Operations
         */

        // check if a list file is present via the environment path, and if not, create one
        private void checkListFile()
        {
            string pathCheck = Environment.GetEnvironmentVariable(ENVLISTPATH);
            if (!string.IsNullOrEmpty(pathCheck))
            {
                envListPath = pathCheck;
            }

            try
            {
                using (FileStream fs = new FileStream(envListPath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    // MessageBox.Show("List File detected");
                }
            }
            catch (IOException)
            {
                // MessageBox.Show("No List File detected. Creating one...");
            }
        }

        // Add each list read from filepaths from the listfile found
        private void addTrackedLists()
        {
            List<String> filePaths = new List<string>();

            // reset the menu to make sure the "close tracker" appears last on the list
            cMenuTrackedLists.Items.Clear(); 

            using (FileStream fs = new FileStream(envListPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (!String.IsNullOrEmpty(line)) filePaths.Add(line);
                }
            }

            foreach (string filePath in filePaths)
            {
                if (!String.IsNullOrEmpty(filePath))
                {
                    using (FileStream fs = File.OpenRead(filePath))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string data = sr.ReadToEnd();
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.Converters.Add(new StringEnumConverter());
                        MZList file = JsonConvert.DeserializeObject<MZList>(data, settings) as MZList;
                        if (file != null)
                        {
                            ToolStripMenuItem newItem = new ToolStripMenuItem(file.Title);
                            newItem.Tag = filePath as String;
                            newItem.Click += menuItemClicked;
                            cMenuTrackedLists.Items.Add(newItem);
                        }
                    }

                }
            }

            // only add the separator if we DO have any entries in the tracker
            if (cMenuTrackedLists.Items.Count > 1)
            {
                ToolStripSeparator separator = new ToolStripSeparator();
                cMenuTrackedLists.Items.Add(separator);
            }
            ToolStripMenuItem closeList = new ToolStripMenuItem("Close Mytemize Tracker");
            closeList.Click += menuCloseTracker;
            cMenuTrackedLists.Items.Add(closeList);
        }

        // Open a mytemize window for the filepath passed
        private void openMytemizeList(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return;

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    Process.Start("Mytemize.exe", "-v " + filePath);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Application Error: Unable to open list file: " + filePath);
            }
        }
    }
}
