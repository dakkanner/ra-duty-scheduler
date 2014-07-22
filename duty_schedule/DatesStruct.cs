using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duty_Schedule
{
    public class DatesStruct
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<DateTime> holidayList { get; set; }
        public List<DateTime> breakList { get; set; }
    }
}
