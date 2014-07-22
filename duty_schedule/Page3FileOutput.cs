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

        public Page3FileOutput(CalendarMaker cmIn)
        {
            mCalendar = cmIn;
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
            mCalendar.MakeExcelFile();
        }

        private void csvOutputBtn_Click(object sender, EventArgs e)
        {
            mCalendar.MakeCSVFile();
        }

    }
}
