//Copyright (C) 2014  Dakota Kanner
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

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
            try
            {
                string filePath = "";
                CalendarMaker calMaker = new CalendarMaker();
                DatesAndAssignments cal = new DatesAndAssignments();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Page2FileSelect pg2 = new Page2FileSelect();
                var pageResult = System.Windows.Forms.DialogResult.Cancel;

                // Show the file select page, run until it has enough inputs
                while (cal.mPeopleList.Count <= 0 && cal.mDateList.Count <= 0)
                {
                    pageResult = pg2.ShowDialog();

                    if (pageResult == DialogResult.OK)
                    {
                        cal = pg2.GetCalendar();
                        calMaker = pg2.mCalendarMaker;
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

                    bool redoDaysOff = calMaker.CheckDaysOff();
                    if (redoDaysOff)
                    {
                        cal.mDateList.Clear();
                        cal.mPeopleList.Clear();
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
            catch(Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message, "Error in scheduling app",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
