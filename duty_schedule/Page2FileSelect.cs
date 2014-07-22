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
    public partial class Page2FileSelect : Form
    {
        public string mDateFilePath { get; set; }
        public string mGroupFilePath { get; set; }
        public CalendarMaker mCalendar { get; set; }

        public Page2FileSelect()
        {
            InitializeComponent();
        }

        public DatesAndAssignments GetCalendar()
        {
            return this.mCalendar.GetCalendar();
        }

        public string GetDateFilePath()
        {
            return this.mDateFilePath;
        }

        public string GetGroupFilePath()
        {
            return this.mGroupFilePath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

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

        private void DateFileSelBtn_Click(object sender, EventArgs e)
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
            mCalendar = new CalendarMaker(this.dateTextBox.Text, this.groupTextBox.Text);
            mGroupFilePath = this.groupTextBox.Text;
            mDateFilePath = this.dateTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
