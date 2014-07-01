using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Duty_Schedule
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //ExportToDoc d = new ExportToDoc();
            //d.ExportToExcel();


            //CalendarMaker cal = new CalendarMaker();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Page1());
            //Application.Run(new PageExampleFiles());
        }
    }
}
