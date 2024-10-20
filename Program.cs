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
                    (args[1] == "-csv" || args[1] == "-CSV") ||
                    (args[1] == "-xls" || args[1] == "-XLS") ||
                    (args[1] == "-txt" || args[1] == "-TXT")
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
            else
            {
                // default into the editor form
                Application.Run(new mzEditor());
            }
        }
    }
}
