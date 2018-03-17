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
    public partial class Page4GetEventInfo : Form
    {
        public CalendarMaker mCalendar { get; set; }
        public List<string> mCcEmailList { get; set; }
        public string mSenderEmail { get; set; }
        public string mSubject { get; set; }
        public int mStartHour { get; set; }
        public int mStartMinute { get; set; }
        public bool mAllDayEvents { get; set; }
        public bool mReminderEnable { get; set; }
        public bool mMergeDays { get; set; }
        public bool mSendEmails { get; set; }

        public Page4GetEventInfo(CalendarMaker cmIn, List<string> ccEmailListIn = null, string senderEmailIn = "")
        {
            InitializeComponent();

            this.mCalendar = cmIn;
            if (ccEmailListIn != null)
                this.mCcEmailList = ccEmailListIn;
            if (!string.IsNullOrEmpty(senderEmailIn))
                this.mSenderEmail = senderEmailIn;

            var peopleList = mCalendar.mPeople;
            foreach (Person per in peopleList)
            {
                object[] perinfo = { per.mName, per.mEmailAddress };
                this.dataGridView1.Rows.Add(perinfo);
            }

            foreach (string str in ccEmailListIn)
                this.textBoxCcList.Text += str + " ";
            this.textBoxSenderEmail.Text = mSenderEmail;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            List<Person> people = this.mCalendar.mPeople;
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
                    try
                    {
                        people[index].mEmailAddress = row.Cells[1].Value.ToString();
                    }
                    catch
                    {
                        people[index].mEmailAddress = "";
                    }
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
                this.mSubject = this.textBoxEventTitle.Text;
                this.mStartHour = this.dateTimePicker1.Value.Hour;
                this.mStartMinute = this.dateTimePicker1.Value.Minute;
                this.mAllDayEvents = this.checkBoxAllDay.Checked;
                this.mReminderEnable = this.checkBoxEnableReminder.Checked;
                this.mMergeDays = this.checkBoxMergeDays.Checked;
                this.mSendEmails = !this.checkBoxDontSendEmails.Checked;

                char[] charSeparators = new char[] { ' ', ',' };
                string[] ccEmailStrings = this.textBoxCcList.Text.Split(charSeparators);
                foreach (string ccEml in ccEmailStrings)
                    mCcEmailList.Add(ccEml);
                mSenderEmail = this.textBoxSenderEmail.Text;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void checkBoxWeekdaysEnableScheduling_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBoxAllDay_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1.Enabled = !this.checkBoxAllDay.Checked;
        }

        private void checkBoxEnableReminder_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}