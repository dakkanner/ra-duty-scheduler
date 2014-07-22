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
            string filePath = "";
            CalendarMaker calMaker = new CalendarMaker();
            DatesAndAssignments cal = new DatesAndAssignments();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Page2FileSelect pg2 = new Page2FileSelect();
            var pageResult = System.Windows.Forms.DialogResult.Cancel;

            // Show the file select page, run until it has enough inputs
            while (cal.mPeopleList.Count  <= 0 && cal.mDateList.Count <= 0)
            {
                pageResult = pg2.ShowDialog();

                if (pageResult == DialogResult.OK)
                {
                    cal = pg2.GetCalendar();
                    calMaker = pg2.mCalendar;
                    filePath = pg2.GetDateFilePath();
                    int loc = filePath.LastIndexOf("\\");
                    int loc2 = filePath.LastIndexOf("/");
                    if (loc2 > loc)
                        loc = loc2;
                    if (loc != -1)
                        filePath = filePath.Remove(loc);
                } 
                else if (pageResult == DialogResult.Cancel)
                {
                    break;
                }
            }
            // Display the output dialog
            if (pageResult == DialogResult.OK 
                && cal.mPeopleList.Count > 0
                && cal.mDateList.Count > 0)
            {
                Page3FileOutput pg3 = new Page3FileOutput(calMaker);
                pageResult = pg3.ShowDialog();
            }

        }
    }
}
