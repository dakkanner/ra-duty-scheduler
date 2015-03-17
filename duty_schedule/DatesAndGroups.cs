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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duty_Schedule
{
    /// <summary>
    /// A list of dates and groups. Used in Person to create a list of the 
    /// days they have scheduled and for which group.
    /// </summary>
    public class DatesAndGroups
    {
        // Public members because I'm lazy. 
        public List<DateTime> mDates;
        public List<string> mGroups;

        /// <summary>
        /// Default ctor
        /// </summary>
        public DatesAndGroups()
        {
            mDates = new List<DateTime>();
            mGroups = new List<string>();
        }

        /// <summary>
        /// Ctor with a date and a group.
        /// </summary>
        /// <param name="date">DateTime that the person is scheduled for</param>
        /// <param name="group">Group that the person will be in for that day</param>
        public DatesAndGroups(DateTime date, string group)
        {
            mDates = new List<DateTime>();
            mDates.Add(date);
            mGroups = new List<string>();
            mGroups.Add(group);
        }

        /// <summary>
        /// Ctor with lists of dates and groups.
        /// </summary>
        /// <param name="dates">List of DateTimes that the person is scheduled for</param>
        /// <param name="groups">List of groups that the person will be in for those days</param>
        public DatesAndGroups(List<DateTime> dates, List<string> groups)
        {
            mDates = new List<DateTime>(dates);
            mGroups = new List<string>(groups);
        }

        /// <summary>
        /// Adds a single scheduled day and group
        /// </summary>
        /// <param name="date">DateTime that the person is scheduled for</param>
        /// <param name="group">Group that the person will be in for that day</param>
        public void AddDate(DateTime date, string group)
        {
            mDates.Add(date);
            mGroups.Add(group);
        }

        /// <summary>
        /// Adds a list of dates and groups.
        /// </summary>
        /// <param name="dates">List of DateTimes that the person is scheduled for</param>
        /// <param name="groups">List of groups that the person will be in for those days</param>
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

        /// <summary>
        /// Removes a previously scheduled date from the list and the corresponding group.
        /// </summary>
        /// <param name="date">The date to remove from this person</param>
        public void RemoveDate(DateTime date)
        {
            int index = mDates.IndexOf(date);

            if(index >= 0)
            {
                mDates.RemoveAt(index);
                mGroups.RemoveAt(index);
            }
        }

        /// <summary>
        /// Returns true if the list contains any of the passed-in dates
        /// </summary>
        /// <param name="dates">List of dates to see if they are in mDates</param>
        /// <returns>Returns true if the list contains the date</returns>
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
