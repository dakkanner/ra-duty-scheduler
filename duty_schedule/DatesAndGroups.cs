using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duty_Schedule
{
    class DatesAndGroups
    {
        public List<DateTime> mDates;
        public List<string> mGroups;

        public DatesAndGroups()
        {
            mDates = new List<DateTime>();
            mGroups = new List<string>();
        }
        public DatesAndGroups(DateTime date, string group)
        {
            mDates = new List<DateTime>();
            mDates.Add(date);
            mGroups = new List<string>();
            mGroups.Add(group);
        }
        public DatesAndGroups(List<DateTime> dates, List<string> groups)
        {
            mDates = new List<DateTime>(dates);
            mGroups = new List<string>(groups);
        }

        public void AddDate(DateTime date, string group)
        {
            mDates.Add(date);
            mGroups.Add(group);
        }

        public void AddDates(List<DateTime> dates, List<string> groups)
        {
            if (dates.Count != groups.Count)
                throw new Exception("Date list and group list are not of equal lengths");

            for(int i = 0; i < dates.Count; i++)
            {
                if (mDates.Contains(dates[i]))
                    throw new Exception(dates[i].ToShortDateString() + " already exists in list.");

                mDates.Add(dates[i]);
                mGroups.Add(groups[i]);

            }
        }

        public void RemoveDate(DateTime date)
        {
            int index = mDates.IndexOf(date);

            if(index >= 0)
            {
                mDates.RemoveAt(index);
                mGroups.RemoveAt(index);
            }
        }

        public bool ContainsDates(List<DateTime> dates)
        {
            bool found = false;

            foreach (DateTime dateSch in mDates)
            {
                foreach (DateTime dateIn in dates)
                {
                    if (dateSch == dateIn)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                    break;
            }
            return found;
        }



    }
}
