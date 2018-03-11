//Copyright (C) 2014-2018 Dakota Kanner
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duty_Schedule
{
    /// <summary>
    /// A person is an object with the following attributes:
    /// Name,
    /// Email,
    /// List of groups they belong to,
    /// Count of weekends and duty days they're on for (for convenience),
    /// List of days they request off,
    /// And a DatesAndGroups, which is the days they're scheduled for duty.
    /// </summary>
    public class Person
    {
        // Public members because I'm lazy
        public string mName;

        public string mEmailAddress;
        public List<string> mGroups;
        public int mWeekendCount;
        public int mWeekdayCount;
        public List<DateTime> mDaysOffRequested;
        public DatesAndGroups mDutyDays;

        /// <summary>
        /// Default ctor. All vars initialize to 0, empty, etc.
        /// </summary>
        public Person()
        {
            mName = "";
            mEmailAddress = "";
            mGroups = new List<string>();
            mWeekendCount = 0;
            mWeekdayCount = 0;
            mDaysOffRequested = new List<DateTime>();
            mDutyDays = new DatesAndGroups();
        }   //End Person()

        /// <summary>
        /// Ctor that sets some of the values. This one takes a single group string.
        /// </summary>
        /// <param name="name">The person's name</param>
        /// <param name="group">The group (singular) that this person belongs in</param>
        /// <param name="daysOff">The requested days off from the person</param>
        public Person(string name, string group, List<DateTime> daysOff)
        {
            mName = name;
            mEmailAddress = "";
            mGroups = new List<string>();
            mGroups.Add(group);
            mWeekendCount = 0;
            mWeekdayCount = 0;
            mDaysOffRequested = new List<DateTime>(daysOff);
            mDutyDays = new DatesAndGroups();
        }   //End Person(string name, string group, List<DateTime> daysOff)

        /// <summary>
        /// Ctor that sets some of the values. This one takes a list of group strings if they belong to multiple groups.
        /// </summary>
        /// <param name="name">The person's name</param>
        /// <param name="groups">The groups that this person belongs in</param>
        /// <param name="daysOff">The requested days off from the person</param>
        public Person(string name, List<string> groups, List<DateTime> daysOff)
        {
            mName = name;
            mEmailAddress = "";
            mGroups = new List<string>(groups);
            mWeekendCount = 0;
            mWeekdayCount = 0;
            mDaysOffRequested = new List<DateTime>(daysOff);
            mDutyDays = new DatesAndGroups();
        }   //End Person(string name, string group, List<DateTime> daysOff)

        /// <summary>
        /// Adds a single group that this person belongs in
        /// </summary>
        /// <param name="group"></param>
        public void AddGroup(string group)
        {
            mGroups.Add(group);
        }   //End AddGroup(string group)

        /// <summary>
        /// Adds a single day that this person would like off.
        /// </summary>
        /// <param name="DayOff">A DateTime that this person would like off. Time does not matter, just the day.</param>
        public void AddDayOffRequested(DateTime DayOff)
        {
            mDaysOffRequested.Add(DayOff);
        }   //End AddDayOffRequested(DateTime DayOff)

        /// <summary>
        /// Assigns this person a duty day for a passed-in date and group.
        /// </summary>
        /// <param name="newDutyDay">The day that this person will be scheduled</param>
        /// <param name="group">The group/location that this person will be for that day</param>
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

        /// <summary>
        /// Assigns this person a duty date cluster for a passed-in date list and group.
        /// Note: If they belong to multiple groups, this gets swapped later.
        /// </summary>
        /// <param name="newDutyDays"></param>
        /// <param name="group"></param>
        public void AddDutyDays(List<DateTime> newDutyDays, string group)
        {
            try
            {
                List<string> groupList = new List<string>();
                for (int i = 0; i < newDutyDays.Count; i++)
                {
                    groupList.Add(group);
                }

                mDutyDays.AddDates(newDutyDays, groupList);
                mWeekendCount++;    //Doesn't increment if exception thrown
            }
            catch (Exception E)
            {
                throw new Exception("Error: " + this.mName + ": " + E.ToString());
            }
        }   //End AddDutyDays(List<DateTime> newDutyDay)

        /// <summary>
        /// Remove a previously scheduled duty day from a person
        /// </summary>
        /// <param name="dutyDay">DateTime to remove</param>
        public void RemoveDutyDay(DateTime dutyDay)
        {
            if (mDutyDays.mDates.Contains(dutyDay))
            {
                mDutyDays.RemoveDate(dutyDay);
                mWeekdayCount--;
            }
        }   //End RemoveDutyDay(DateTime dutyDay)

        /// <summary>
        /// Remove a previously scheduled duty weekend from a person
        /// </summary>
        /// <param name="dutyDays">List of DateTimes to remove</param>
        public void RemoveDutyDays(List<DateTime> dutyDays)
        {
            bool weekendFound = false;

            foreach (DateTime dt in dutyDays)
            {
                if (mDutyDays.mDates.Contains(dt))
                {
                    mDutyDays.RemoveDate(dt);
                    weekendFound = true;
                }
            }
            if (weekendFound)
                mWeekendCount--;
        }   //End RemoveDutyDays(List<DateTime> dutyDays)

        /// <summary>
        /// Returns true if this person is scheduled for a specific date
        /// </summary>
        /// <param name="dutyDay">The day to check for</param>
        /// <returns></returns>
        public bool IsScheduledForDate(DateTime dutyDay)
        {
            int index = mDutyDays.mDates.IndexOf(dutyDay);

            if (index >= 0)
                return true;

            return false;
        }   //End IsScheduledForDate(DateTime dutyDay)

        /// <summary>
        /// Returns true if this person is scheduled for any day in a list of DateTimes
        /// </summary>
        /// <param name="dutyDays">List of dates that the weekend contains</param>
        /// <returns></returns>
        public bool IsScheduledForDates(List<DateTime> dutyWeekend)
        {
            foreach (DateTime d in dutyWeekend)
            {
                if (mDaysOffRequested.IndexOf(d) >= 0)
                    return true;
            }

            return false;
        }   //End IsScheduledForDates(List<DateTime> dutyDays)

        /// <summary>
        /// Returns true if this person requested the day off
        /// </summary>
        /// <param name="dutyDay">The day to check against</param>
        /// <returns></returns>
        public bool IsDateRequestedOff(DateTime dutyDay)
        {
            int index = mDaysOffRequested.IndexOf(dutyDay);

            if (index >= 0)
                return true;

            return false;
        }   //End IsDateRequestedOff(DateTime dutyDay)

        /// <summary>
        /// Returns true if this person requested any day in a list of DateTimes off
        /// </summary>
        /// <param name="dutyDays">The list of days to check against</param>
        /// <returns></returns>
        public bool AreDatesRequestedOff(List<DateTime> dutyWeekend)
        {
            foreach (DateTime d in dutyWeekend)
            {
                if (mDaysOffRequested.IndexOf(d) >= 0)
                    return true;
            }

            return false;
        }   //End AreDatesRequestedOff(List<DateTime> dutyDays)
    }
}