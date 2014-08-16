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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Duty_Schedule
{
    public partial class Page3FileOutput : Form
    {
        public CalendarMaker mCalendar { get; set; }
        public List<string> mCcEmail { get; set; }
        public string mSenderEmail { get; set; }

        public Page3FileOutput(CalendarMaker cmIn)
        {
            mCalendar = cmIn;
            mCcEmail = new List<string>();
            InitializeComponent(cmIn.GetGroups().Count, cmIn.GetPeople().Count, cmIn.GetCalendar().mDateList.Count);
            //InitializeComponent();
        }

        public DatesAndAssignments GetCalendar()
        {
            return this.mCalendar.GetCalendar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void excelOutputBtn_Click(object sender, EventArgs e)
        {
            try
            {
                mCalendar.MakeExcelFile();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,
                    "Error in Excel Output",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void csvOutputBtn_Click(object sender, EventArgs e)
        {
            try
            {
                mCalendar.MakeCSVFile();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,
                    "Error in CSV Output",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }
        private void iCalOutputBtn_Click(object sender, EventArgs e)
        {
            Page4GetEventInfo p4 = new Page4GetEventInfo(mCalendar, mCcEmail, mSenderEmail);
            var results = p4.ShowDialog();

            if (results == DialogResult.OK)
            {
                mCcEmail = p4.mCcEmailList;
                mSenderEmail = p4.mSenderEmail;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    mCalendar.MakeOutlookEvents(p4.mStartHour, p4.mStartMinute, p4.mCcEmailList);
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("It looks like all invitations were created.");
                }
                catch (Exception exc)
                {
                    Cursor.Current = Cursors.Default;

                    MessageBox.Show(exc.Message,
                        "Error in Calendar Invitation creation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void rerunBtn_Click(object sender, EventArgs e)
        {
            try
            {
                mCalendar.ClearCalendar();
                mCalendar.FirstScheduleRun();
                mCalendar.FillCalendar();

                MessageBox.Show("The schedule has been remade.",
                    "Done rescheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,
                    "Error while rescheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

    }
}
