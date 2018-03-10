//Copyright (C) 2014-2018 Dakota Kanner
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Duty_Schedule
{
    public partial class Page2FileSelect : Form
    {
        public string mDateFilePath { get; set; }
        public string mGroupFilePath { get; set; }
        public string mCsvFilePath { get; set; }
        public CalendarMaker mCalendarMaker { get; set; }

        public Page2FileSelect()
        {
            InitializeComponent();

            mDateFilePath = "";
            mGroupFilePath = "";
            mCsvFilePath = "";

            this.checkBoxWeekendsSamePeople.Checked = true;
            this.checkBoxWeekendsShuffle.Checked = true;
            this.weekendRadioButton1.Checked = true;
        }

        public DatesAndAssignments GetCalendar()
        {
            return this.mCalendarMaker.mCalendar;
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PageExampleFiles pef = new PageExampleFiles();
            pef.Show();
        }

        private string button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                return openFileDialog1.FileName;
            else
                return "";
        }

        private void dateFileSelBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = this.mDateFilePath;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                this.mDateFilePath = openFileDialog1.FileName;

            this.dateTextBox.Text = this.mDateFilePath;
        }

        private void groupFileSelBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = this.mGroupFilePath;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                this.mGroupFilePath = openFileDialog1.FileName;

            this.groupTextBox.Text = this.mGroupFilePath;
        }

        private void buttonP1Next_Click(object sender, EventArgs e)
        {
            List<DayOfWeek> weekdaysList = new List<DayOfWeek>();
            weekdaysList.Add(DayOfWeek.Monday);
            weekdaysList.Add(DayOfWeek.Tuesday);
            weekdaysList.Add(DayOfWeek.Wednesday);
            weekdaysList.Add(DayOfWeek.Thursday);

            List<DayOfWeek> weekendsList = new List<DayOfWeek>();
            if (this.weekendRadioButton1.Checked)
            {
                weekendsList.Add(DayOfWeek.Friday);
                weekendsList.Add(DayOfWeek.Saturday);
                weekendsList.Add(DayOfWeek.Sunday);
            }
            else if (this.weekendRadioButton2.Checked)
            {
                weekdaysList.Add(DayOfWeek.Sunday);

                weekendsList.Add(DayOfWeek.Friday);
                weekendsList.Add(DayOfWeek.Saturday);
            }
            else
            {
                weekdaysList.Add(DayOfWeek.Friday);

                weekendsList.Add(DayOfWeek.Saturday);
                weekendsList.Add(DayOfWeek.Sunday);
            }

            mCalendarMaker = new CalendarMaker(dateTextBox.Text, groupTextBox.Text,
                checkBoxWeekdaysSamePeople.Checked, checkBoxWeekdaysShuffle.Checked,
                checkBoxWeekendsSamePeople.Checked, checkBoxWeekendsShuffle.Checked,
                weekdaysList, weekendsList);
            mGroupFilePath = this.groupTextBox.Text;
            mDateFilePath = this.dateTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void aboutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PageAbout pa = new PageAbout();
            pa.ShowDialog();
        }

        private void csvFileSelBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = this.mCsvFilePath;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                this.mCsvFilePath = openFileDialog1.FileName;

            this.csvTextBox.Text = this.mCsvFilePath;
        }

        private void buttonP2Next_Click(object sender, EventArgs e)
        {
            mCalendarMaker = new CalendarMaker(this.csvTextBox.Text);
            mCsvFilePath = this.csvTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void checkBoxWeekendsSamePeople_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxWeekendsShuffle.Enabled = this.checkBoxWeekendsSamePeople.Checked;

            if (!this.checkBoxWeekendsSamePeople.Checked)
            {
                this.checkBoxWeekendsShuffle.Checked = false;
            }
        }

        private void checkBoxWeekdaysSamePeople_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxWeekdaysShuffle.Enabled = this.checkBoxWeekdaysSamePeople.Checked;

            if (!this.checkBoxWeekdaysSamePeople.Checked)
            {
                this.checkBoxWeekdaysShuffle.Checked = false;
            }
        }

        private void checkBoxWeekendsEnableScheduling_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxWeekendsSamePeople.Enabled = this.checkBoxWeekendsEnableScheduling.Checked;
            this.checkBoxWeekendsShuffle.Enabled = this.checkBoxWeekendsSamePeople.Checked;

            if (!this.checkBoxWeekendsEnableScheduling.Checked)
            {
                this.checkBoxWeekendsSamePeople.Checked = false;
                this.checkBoxWeekendsShuffle.Checked = false;
            }
        }

        private void checkBoxWeekdaysEnableScheduling_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxWeekdaysSamePeople.Enabled = this.checkBoxWeekdaysEnableScheduling.Checked;
            this.checkBoxWeekdaysShuffle.Enabled = this.checkBoxWeekdaysSamePeople.Checked;

            if (!this.checkBoxWeekdaysEnableScheduling.Checked)
            {
                this.checkBoxWeekdaysSamePeople.Checked = false;
                this.checkBoxWeekdaysShuffle.Checked = false;
            }
        }
    }
}