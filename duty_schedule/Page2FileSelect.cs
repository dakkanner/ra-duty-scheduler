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

            this.WeekendsSamePersonCheckBox.Checked = true;
            this.ShuffleCheckBox.Checked = true;
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
            mCalendarMaker = new CalendarMaker(this.dateTextBox.Text, this.groupTextBox.Text, 
                this.WeekendsSamePersonCheckBox.Checked, this.ShuffleCheckBox.Checked);
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
            mCalendarMaker = new CalendarMaker(this.csvTextBox.Text, this.WeekendsSamePersonCheckBox.Checked,
                this.ShuffleCheckBox.Checked);
            mCsvFilePath = this.csvTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonWeekend_Click(object sender, EventArgs e)
        {
            if (this.WeekendsSamePersonCheckBox.Checked)
            {
                this.ShuffleCheckBox.Enabled = true;
            }
            else
            {
                this.ShuffleCheckBox.Enabled = false;
            }

        }
    }
}
