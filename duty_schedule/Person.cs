using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duty_Schedule
{
    public class Person
    {
        // Public members because I'm lazy
        public string mName;
        public List<string> mGroups;
        public int mWeekendCount;
        public int mWeekdayCount;
        public List<DateTime> mDaysOffRequested;
        public DatesAndGroups mDutyDays;

        public Person()
        {
            mName = "";
            mGroups = new List<string>();
            mWeekendCount = 0;
            mWeekdayCount = 0;
            mDaysOffRequested = new List<DateTime>();
            mDutyDays = new DatesAndGroups();
        }   //End Person()
        public Person(string name, string group, List<DateTime> daysOff)
        {
            mName = name;
            mGroups = new List<string>();
            mGroups.Add(group);
            mWeekendCount = 0;
            mWeekdayCount = 0;
            mDaysOffRequested = new List<DateTime>(daysOff);
            mDutyDays = new DatesAndGroups();
        }   //End Person(string name, string group, List<DateTime> daysOff)
        public Person(string name, List<string> groups, List<DateTime> daysOff)
        {
            mName = name;
            mGroups = new List<string>(groups) ;
            mWeekendCount = 0;
            mWeekdayCount = 0;
            mDaysOffRequested = new List<DateTime>(daysOff);
            mDutyDays = new DatesAndGroups();
        }   //End Person(string name, string group, List<DateTime> daysOff)


        public void AddGroup(string group)
        {
            mGroups.Add(group);
        }   //End AddGroup(string group)
        public void AddDayOffRequested(DateTime DayOff)
        {
            mDaysOffRequested.Add(DayOff);
        }   //End AddDayOffRequested(DateTime DayOff)

        public void AddDutyDay(DateTime newDutyDay, string group)
        {
            if (mDutyDays.mDates.Contains(newDutyDay))
                throw new Exception("Error: " + this.mName + "Is already scheduled for (day) " + newDutyDay.ToShortDateString());

            try
            {
                mDutyDays.AddDate(newDutyDay, group);
                mWeekdayCount++;
            }
            catch (Exception E)
            {
                throw new Exception("Error: " + this.mName + ": " + E.ToString());
            }

        }   //End AddDutyDay(DateTime newDutyDay)

        public void AddDutyWeekend(List<DateTime> newDutyWeekend, string group)
        {
            try
            {
                List<string> groupList = new List<string>();
                for(int i = 0; i < newDutyWeekend.Count; i++)
                {
                    groupList.Add(group);
                }

                mDutyDays.AddDates(newDutyWeekend, groupList);
                mWeekendCount++;    //Doesn't increment if exception thrown
            }
            catch(Exception E)
            {
                throw new Exception("Error: " + this.mName + ": " + E.ToString());
            }

        }   //End AddDutyWeekend(List<DateTime> newDutyDay)


        public void RemoveDutyDay(DateTime dutyDay)
        {
            if (mDutyDays.mDates.Contains(dutyDay))
            {
                mDutyDays.RemoveDate(dutyDay);
                mWeekdayCount--;
            }
        }   //End RemoveDutyDay(DateTime dutyDay)

        public void RemoveDutyWeekend(List<DateTime> dutyWeekend)
        {
            bool weekendFound = false;

            foreach (DateTime dt in dutyWeekend)
            {
                if (mDutyDays.mDates.Contains(dt))
                {
                    mDutyDays.RemoveDate(dt);
                    weekendFound = true;
                }
            }
            if(weekendFound)
                mWeekendCount--;

        }   //End RemoveDutyWeekend(List<DateTime> dutyWeekend)


        public bool IsScheduledForDate(DateTime dutyDay)
        {
            bool dateFound = false;

            int index = mDutyDays.mDates.IndexOf(dutyDay);

            if (index >= 0)
                dateFound = true;

            return dateFound;
        }   //End IsScheduledForDate(DateTime dutyDay)

        public bool IsScheduledForWeekend(List<DateTime> dutyWeekend)
        {
            bool dateFound = false;

            foreach (DateTime d in dutyWeekend)
            {
                if (mDaysOffRequested.IndexOf(d) >= 0)
                    dateFound = true;
            }

            return dateFound;
        }   //End IsScheduledForWeekend(List<DateTime> dutyWeekend)

        public bool IsDateRequestedOff(DateTime dutyDay)
        {
            bool dateFound = false;

            int index = mDaysOffRequested.IndexOf(dutyDay);

            if (index >= 0)
                dateFound = true;

            return dateFound;
        }   //End IsDateRequestedOff(DateTime dutyDay)

        public bool IsWeekendRequestedOff(List<DateTime> dutyWeekend)
        {
            bool dateFound = false;

            foreach(DateTime d in dutyWeekend)
            {
                if (mDaysOffRequested.IndexOf(d) >= 0)
                    dateFound = true;
            }

            return dateFound;
        }   //End IsWeekendRequestedOff(List<DateTime> dutyWeekend)

    }
}
