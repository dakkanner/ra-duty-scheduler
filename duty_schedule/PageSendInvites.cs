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
    public partial class PageSendInvites : Form
    {
        public PageSendInvites()
        {
            InitializeComponent();
        }

        public void SetLoadingBarPercent(int per)
        {

            //if (per > 0 && per <= 100)
            //{
            //    this.progressBar1.Value = per;
            //}
        }

        public void SetTimeRemaining(int secs)
        {
            if (secs >= 0)
            {
                if (secs >= 3600) // Divisible by hours
                {
                    int hrs = secs / 3600;
                    int mins = (secs - (hrs*3600)) / 60;

                    this.label4.Text = hrs.ToString() + " hours & ";
                    this.label4.Text += mins.ToString() + " minutes";
                }
                if (secs >= 60) // Divisible by minutes
                {
                    int mins = secs / 60;
                    int tempSec = secs % 60;

                    this.label4.Text = mins.ToString() + " minutes & ";
                    this.label4.Text += tempSec.ToString() + " seconds";
                }
                else  // Divisible by seconds only
                {
                    this.label4.Text = secs.ToString() + " seconds";
                }
            }
            this.label4.Update();
        }
    }
}
