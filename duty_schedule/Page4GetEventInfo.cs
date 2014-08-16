﻿using System;
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
    public partial class Page4GetEventInfo : Form
    {
        public CalendarMaker mCalendar { get; set; }
        public List<string> mCcEmailList { get; set; }
        public string mSenderEmail { get; set; }
        public int mStartHour { get; set; }
        public int mStartMinute { get; set; }

        public Page4GetEventInfo(CalendarMaker cmIn, List<string> ccEmailListIn = null, string senderEmailIn = "")
        {
            this.mCalendar = cmIn;
            if (ccEmailListIn != null)
                mCcEmailList = ccEmailListIn;
            if (!string.IsNullOrEmpty(senderEmailIn))
                mSenderEmail = senderEmailIn;

            InitializeComponent();

            foreach (string str in ccEmailListIn)
                this.textBoxCcList.Text += str + " ";
            this.textBoxSenderEmail.Text = mSenderEmail;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            List<Person> people = this.mCalendar.GetPeople();
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                int index = -1;

                for (int i = 0; i < people.Count; i++)
                {
                    if (row.Cells[0].Value.ToString() == people[i].mName)
                        index = i;
                }

                if (index != -1)
                {
                    people[index].mEmailAddress = row.Cells[1].Value.ToString();
                }
            }


            DialogResult rslt = DialogResult.No;

            List<string> invalidEmails = this.mCalendar.GetInvalidEmailListStrings();

            if (invalidEmails.Count > 0)
            {
                string msgText = "Warning - The following people do not seem to have valid email addresses:";
                foreach (string name in invalidEmails)
                {
                    msgText += "\n   " + name;
                }
                msgText += "\nDo you want to edit the emails?";

                rslt = MessageBox.Show(msgText, "Invalid Emails", MessageBoxButtons.YesNo);
            }

            if (rslt == DialogResult.No)
            {
                mStartHour = dateTimePicker1.Value.Hour;
                mStartMinute = dateTimePicker1.Value.Minute;

                char[] charSeparators = new char[] {' ', ','};
                string[] ccEmailStrings = textBoxCcList.Text.Split(charSeparators);
                foreach (string ccEml in ccEmailStrings)
                    mCcEmailList.Add(ccEml);
                mSenderEmail = textBoxSenderEmail.Text;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
