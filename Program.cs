using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mytemize
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// Defaults to the editor application. 
        /// To use the viewer, include -v parameter and the path to the file to be opened
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MZTracker myTracker = null;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // check for the -v parameter to open in viewer
            if (args.Length > 0 && (args[0] == "-v" || args[0] == "-V"))
            {
                // take the string path from the next parameter
                string fullPath = args[1];
                bool isDemo = false;

                // in case a demo version is included
                if (args.Length >= 3 && args[2] == "-d") isDemo = true;

                // pass the parameters into the viewer
                Application.Run(new MZViewer(fullPath, isDemo));
            }
            // check for the -i parameter to import specific files into viewer
            else if (args.Length > 0 && (args[0] == "-i" || args[0] == "-I"))
            {
                if (args.Length > 1 &&
                    (args[1].ToLower() == "-csv") ||
                    (args[1].ToLower() == "-xls") || 
                    (args[1].ToLower() == "-txt")
                    )
                {
                    string fileType = args[1].ToUpper();
                    fileType = fileType.Substring(1); // trim the dash from the parameter passed
                    
                    if (args.Length > 2 && !string.IsNullOrEmpty(args[2]))
                    {
                        string filePath = args[2];
                        Application.Run(new mzEditor("import", filePath, fileType));
                    }
                    else MessageBox.Show("Application Error: No file specified for import action", "ERROR");
                }
                else MessageBox.Show("Application Error: Invalid parameters for import action", "ERROR");
            }
            // check for the -t parameter to start the tracker tray icon
            else if (args.Length > 0 && (args[0] == "-t" || args[0] == "-T"))
            {
                if (args.Length > 1)
                {
                    if (args[1].ToLower() == "-start")
                    {
                        if (myTracker == null)
                        {
                            // make sure only one tracker icon is running at a time
                            myTracker = new MZTracker();
                            Application.Run(myTracker);
                        }
                        else MessageBox.Show("Application Error: List Tracker is already active ", "ERROR");
                    }
                    else if (args[1].ToLower() == "-stop")
                    {
                        if (myTracker != null)
                        {
                            myTracker.Close();
                            myTracker = null; // force remove the reference to the tracker to properly dispose it
                        }
                    }
                    else MessageBox.Show("Application Error: Invalid tracker action: " + args[1], "ERROR");
                }
                else MessageBox.Show("Application Error: No tracker action specified", "ERROR");
            }
            else
            {
                // default into the editor form
                Application.Run(new mzEditor());
            }
        }
    }
}
