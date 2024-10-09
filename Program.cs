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

            // check for the -v parameter
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
            else
            {
                // default into the editor form
                Application.Run(new mzEditor());
            }
        }
    }
}
