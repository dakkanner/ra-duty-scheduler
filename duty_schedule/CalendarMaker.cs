//Copyright (C) 2014-2015  Dakota Kanner
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
using System.Threading;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Outlook;

namespace Duty_Schedule
{
    public class CalendarMaker
    {
        private bool mWeekendsSamePeople;
        private bool mShuffleWeekendPeople;
        private List<DayOfWeek> mWeekendDaysOfWeek;

        private DateTime mStartDay;
        private DateTime mEndDay;
        private List<DateTime> mBreaks;
        private List<DateTime> mHolidays;
        private List<List<DateTime>> mWeekends;
        private List<DateTime> mWeekdays;

        public bool isFromImport;

        public List<Person> mPeople;
        public List<string> mGroups;
        public DatesAndAssignments mCalendar;

        public CalendarMaker()
        {
            mWeekendsSamePeople = true;
            mShuffleWeekendPeople = true;
            mWeekendDaysOfWeek = new List<DayOfWeek>();

            mStartDay = new DateTime();
            mEndDay = new DateTime();

            mBreaks = new List<DateTime>();
            mHolidays = new List<DateTime>();
            mWeekends = new List<List<DateTime>>();
            mWeekdays = new List<DateTime>();
            mCalendar = new DatesAndAssignments();

            isFromImport = false;

            mPeople = new List<Person>();
            mGroups = new List<string>();
        }

        /// <summary>
        /// This ctor is used when importing from a previously generated CSV. 
        /// It keeps the 
        /// </summary>
        /// <param name="csvFilePathIn">The path the CSV file.</param>
        /// <param name="weekendsSamePeopleIn">True if Friday, Saturday, and Sunday should be the same people.</param>
        /// <param name="weekendsSamePeopleIn">True if you want people on weekends to be rotated if they can be put into different groups.</param>
        public CalendarMaker(string csvFilePathIn)
        {
            mWeekendsSamePeople = false;
            mShuffleWeekendPeople = false;
            mWeekendDaysOfWeek = new List<DayOfWeek>();

            mStartDay = new DateTime();
            mEndDay = new DateTime();

            mBreaks = new List<DateTime>();
            mHolidays = new List<DateTime>();
            mWeekends = new List<List<DateTime>>();
            mWeekdays = new List<DateTime>();
            mCalendar = new DatesAndAssignments();

            isFromImport = true;

            //mPeople = new List<Person>();
            mGroups = new List<string>();

            FileInputs fileIn = new FileInputs();
            Tuple<DatesStruct, List<Person>> datesAndPeople = fileIn.GetImportFromCsv(csvFilePathIn);

            DatesStruct dates = datesAndPeople.Item1;
            mPeople = datesAndPeople.Item2;

            mStartDay = dates.startDate;
            mEndDay = dates.endDate;
            mHolidays = dates.holidayList;
            mBreaks = dates.breakList;

            // This section finds all the groups
            foreach (Person per in mPeople)
            {
                foreach (string group in per.mGroups)
                {
                    if (!mGroups.Contains(group))
                    {
                        mGroups.Add(group);
                    }
                }
            }

            //Initialize();
            //FirstScheduleRun();
            FillCalendar();
        }

        /// <summary>
        /// This ctor is used when creating a new calendar for creation
        /// </summary>
        /// <param name="dateFilePathIn"></param>
        /// <param name="groupFilePathIn"></param>
        /// <param name="weekendsSamePeopleIn">True if Friday, Saturday, and Sunday should be the same people.</param>
        /// <param name="weekendsSamePeopleIn">True if you want people on weekends to be rotated if they can be put into different groups.</param>
        /// <param name="weekendDaysOfWeek">List of days of the week to use for weekends.</param>
        public CalendarMaker(string dateFilePathIn, string groupFilePathIn, bool weekendsSamePeopleIn, 
            bool shuffleWeekendPeopleIn, List<DayOfWeek> weekendDaysOfWeek)
        {
            mWeekendsSamePeople = weekendsSamePeopleIn;
            mShuffleWeekendPeople = shuffleWeekendPeopleIn;
            mWeekendDaysOfWeek = weekendDaysOfWeek;

            mStartDay = new DateTime();
            mEndDay = new DateTime();

            mBreaks = new List<DateTime>();
            mHolidays = new List<DateTime>();
            mWeekends = new List<List<DateTime>>();
            mWeekdays = new List<DateTime>();
            mCalendar = new DatesAndAssignments();

            isFromImport = false;

            mPeople = new List<Person>();
            mGroups = new List<string>();

            FileInputs fi = new FileInputs();
            var dates = fi.GetDates(dateFilePathIn);
            mPeople = fi.GetGroups(groupFilePathIn, dates);

            mStartDay = dates.startDate;
            mEndDay = dates.endDate;
            mHolidays = dates.holidayList;
            mBreaks = dates.breakList;

            Initialize();
            FirstScheduleRun();
            FillCalendar();
        }

        public DatesAndAssignments GetCalendar()
        {
            return mCalendar;
        }

        public List<Person> GetInvalidEmailList()
        {
            List<Person> emlLst = new List<Person>();

            foreach (Person per in mPeople)
            {
                if (IsEmailValid(per.mEmailAddress) == false)
                {
                    emlLst.Add(per);
                }
            }

            return emlLst;
        }
        public List<String> GetInvalidEmailListStrings()
        {
            List<string> emlLst = new List<string>();

            foreach (Person per in mPeople)
            {
                if (IsEmailValid(per.mEmailAddress) == false)
                {
                    emlLst.Add(per.mName);
                }
            }

            return emlLst;
        }

        public bool IsEmailValid(string emailAddress)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(emailAddress) == true || emailAddress.Length < 5)
            {
                isValid = false;
            }
            else
            {
                // Make sure the email address has an '@' follows by a '.'
                int atIndex = emailAddress.IndexOf('@');
                int dotIndex = -1;
                if (atIndex > 0)
                    dotIndex = emailAddress.IndexOf('.', atIndex);
                else
                    isValid = false;

                if (atIndex == -1 || dotIndex == -1 || atIndex > dotIndex)
                    isValid = false;
            }

            return isValid;
        }

        public void Initialize()
        {
            DateTime currentDay = mStartDay;
            List<DateTime> tempHolidays = new List<DateTime>(mHolidays);
            int dayCount = 0;
            int weekendCount = 0;
            int breakCount = 0;
            DateTime tempEndDay = mEndDay;

            // This section finds all the groups
            foreach (Person per in mPeople)
            {
                foreach (string grp in per.mGroups)
                if ( !mGroups.Contains(grp) )
                {
                    mGroups.Add(grp);
                }
            }

            // Check if the last day of duty lands on a Fri/Sat
            // Schedule final weekend like normal days if true
            if (mEndDay.DayOfWeek == DayOfWeek.Friday
                || mEndDay.DayOfWeek == DayOfWeek.Saturday)
            {
                if (mEndDay.DayOfWeek == DayOfWeek.Friday)
                    tempEndDay = mEndDay.AddDays(-1);
                else
                    tempEndDay = mEndDay.AddDays(-2);
            }

            // This section loads each day into mWeekends or mWeekdays
            while (currentDay <= tempEndDay)
            {
                //Standard weekday
                if (!mWeekendDaysOfWeek.Contains(currentDay.DayOfWeek)
                    && !tempHolidays.Contains(currentDay)
                    && !mBreaks.Contains(currentDay))
                {
                    mWeekdays.Add(currentDay);
                    currentDay = currentDay.AddDays(1);
                    dayCount++;
                }
                //Standard or long weekend
                else if (!mBreaks.Contains(currentDay))
                {
                    mWeekends.Add(new List<DateTime>());

                    while (mWeekendDaysOfWeek.Contains(currentDay.DayOfWeek)
                        || tempHolidays.Contains(currentDay))
                    {
                        mWeekends[weekendCount].Add(currentDay);

                        // Remove holidays from list
                        if (tempHolidays.Contains(currentDay))
                        {
                            tempHolidays.Remove(currentDay);
                        }

                        // If the weekends have different people, weekends last one day so 
                        // weekend shifts get balanced
                        if (!mWeekendsSamePeople)
                        {
                            mWeekends.Add(new List<DateTime>());
                            weekendCount++;
                        }
                        currentDay = currentDay.AddDays(1);
                    }

                    weekendCount++;
                }
                //Should only be breaks here
                else
                {
                    if (!mBreaks.Contains(currentDay))
                        throw new System.Exception("Found invalid date - Should be break, but " + currentDay.ToShortDateString() + "is not listed as a break.");
                    breakCount++;
                    currentDay = currentDay.AddDays(1);
                }
            }

            // This part only runs if the last day is Fri/Sat so it doesn't get added as a weekend.
            while (currentDay <= mEndDay)
            {
                mWeekdays.Add(currentDay);
                currentDay = currentDay.AddDays(1);
                dayCount++;
            }
        }   // End Initialize()

        public void FirstScheduleRun()
        {
            //Get total number of weekend days
            double totalWeekendDays = 0;

            foreach (List<DateTime> x in mWeekends)
            {
                foreach (DateTime y in x)
                {
                    totalWeekendDays++;
                }
            }

            double weekendDaysPerPerson = totalWeekendDays * mGroups.Count / mPeople.Count;
            double weekendDaysDiff = (totalWeekendDays * mGroups.Count) % mPeople.Count;

            double weekendsPerPerson = System.Convert.ToDouble(mWeekends.Count) * mGroups.Count / mPeople.Count;
            double weekendsDiff = (System.Convert.ToDouble(mWeekends.Count) * mGroups.Count) % mPeople.Count;

            double weekDaysPerPerson = System.Convert.ToDouble(mWeekdays.Count) * mGroups.Count / mPeople.Count;
            double weekDaysDiff = (System.Convert.ToDouble(mWeekdays.Count) * mGroups.Count) % mPeople.Count;

            // Schedule all the weekends first
            // TODO: Put into its own function
            foreach (List<DateTime> wknd in mWeekends)
            {
                foreach (string group in mGroups)
                {
                    List<Person> lowestDutyDaysList = WhoHasFewestDays();
                    List<Person> groupList = WhoIsInGroup(group);

                    bool datePlaced = false;

                    for (int i = 0; i < lowestDutyDaysList.Count && !datePlaced; i++)
                    {
                        // Give it whoever has the least number of duty days (if possible)

                        bool wkd = lowestDutyDaysList[i].IsWeekendRequestedOff(wknd);
                        bool grp = groupList.Contains(mPeople[i]);

                        if (!lowestDutyDaysList[i].IsWeekendRequestedOff(wknd) 
                            && groupList.Contains(lowestDutyDaysList[i])
                            && !lowestDutyDaysList[i].mDutyDays.ContainsDates(wknd)
                            && !datePlaced)
                        {
                            lowestDutyDaysList[i].AddDutyWeekend(wknd, group);
                            datePlaced = true;
                        }
                    }
                    //Nobody available without the date requested off; expand search to more than min number of days
                    if (!datePlaced)     
                    {
                        lowestDutyDaysList = SortByFewestDays();

                        for (int i = 0; i < lowestDutyDaysList.Count && !datePlaced; i++)
                        {
                            // Give it whoever has the next least number of duty days (if possible)

                            bool wkd = lowestDutyDaysList[i].IsWeekendRequestedOff(wknd);
                            bool grp = groupList.Contains(mPeople[i]);

                            if (!lowestDutyDaysList[i].IsWeekendRequestedOff(wknd)
                                && groupList.Contains(lowestDutyDaysList[i])
                                && !lowestDutyDaysList[i].mDutyDays.ContainsDates(wknd)
                                && !datePlaced)
                            {
                                lowestDutyDaysList[i].AddDutyWeekend(wknd, group);
                                datePlaced = true;
                            }
                        }
                    }
                    //Nobody available without the date requested off. Force operation.
                    if(!datePlaced)
                    {
                        for (int i = 0; i < lowestDutyDaysList.Count && !datePlaced; i++)
                        {
                            if (groupList.Contains(lowestDutyDaysList[i])
                                && !lowestDutyDaysList[i].mDutyDays.ContainsDates(wknd)
                                && !datePlaced)
                            {
                                MessageBox.Show("Nobody available for weekend " + wknd[0].ToShortDateString()
                                                    + Environment.NewLine + "Assigning " + lowestDutyDaysList[i].mName
                                                    + " to the " + group + " group because they currently have the fewest days.",
                                                    "Problem Making Calendar");

                                lowestDutyDaysList[i].AddDutyWeekend(wknd, group);
                                datePlaced = true;
                            }
                        }
                    }
                }
            }

            Random rand = new Random();

            // Schedule all the weekdays
            // TODO: Put into its own function
            foreach (DateTime wkday in mWeekdays)
            {
                foreach (string group in mGroups)
                {
                    List<Person> lowestDutyDaysList = WhoHasFewestDays();
                    List<Person> groupList = WhoIsInGroup(group);

                    bool datePlaced = false;
                    Person tempPersonSelected = null;

                    for (int i = 0; i < lowestDutyDaysList.Count && !datePlaced; i++)
                    {
                        // Give it whomever has the least number of duty days (if possible)

                        bool wkd = lowestDutyDaysList[i].IsDateRequestedOff(wkday);
                        bool grp = groupList.Contains(mPeople[i]);

                        if (!lowestDutyDaysList[i].IsDateRequestedOff(wkday)            // Check whether this day is requested off
                            && groupList.Contains(lowestDutyDaysList[i])                // Make sure they belong in the group
                            && !lowestDutyDaysList[i].mDutyDays.mDates.Contains(wkday)  // And that they're not already scheduled
                            && !datePlaced)                                             // Also that nobody was already placed
                        {
                            // Try to not make people work back-to-back
                            if (   !lowestDutyDaysList[i].mDutyDays.mDates.Contains(wkday.AddDays(-1))
                                && !lowestDutyDaysList[i].mDutyDays.mDates.Contains(wkday.AddDays(1)))
                            {
                                lowestDutyDaysList[i].AddDutyDay(wkday, group);
                                datePlaced = true;
                            }
                            else    // ...But keep track just in case
                            {
                                tempPersonSelected = lowestDutyDaysList[i];
                            }
                        }
                    }
                    //Nobody available without the date requested off with min days count; expand search
                    if (!datePlaced) 
                    {
                        lowestDutyDaysList = SortByFewestDays();

                        for (int i = 0; i < lowestDutyDaysList.Count && !datePlaced; i++)
                        {
                            // Give it whomever has the least number of duty days (if possible)

                            bool wkd = lowestDutyDaysList[i].IsDateRequestedOff(wkday);
                            bool grp = groupList.Contains(mPeople[i]);

                            if (!lowestDutyDaysList[i].IsDateRequestedOff(wkday)            // Check whether this day is requested off
                                && groupList.Contains(lowestDutyDaysList[i])                // Make sure they belong in the group
                                && !lowestDutyDaysList[i].mDutyDays.mDates.Contains(wkday)  // And that they're not already scheduled
                                && !datePlaced)                                             // Also that nobody was already placed
                            {
                                // Try to not make people work back-to-back
                                if (!lowestDutyDaysList[i].mDutyDays.mDates.Contains(wkday.AddDays(-1))
                                    && !lowestDutyDaysList[i].mDutyDays.mDates.Contains(wkday.AddDays(1)))
                                {
                                    lowestDutyDaysList[i].AddDutyDay(wkday, group);
                                    datePlaced = true;
                                }
                                else    // ...But keep track just in case
                                {
                                    tempPersonSelected = lowestDutyDaysList[i];
                                }
                            }
                        }
                    }
                    //Nobody available without the date requested off
                    if (!datePlaced)     
                    {
                        // If someone is available, but would work back-to-back, add them.
                        if (tempPersonSelected != null)
                        {
                            if (groupList.Contains(tempPersonSelected)
                                    && !tempPersonSelected.mDutyDays.mDates.Contains(wkday)
                                    && !datePlaced)
                            {
                                tempPersonSelected.AddDutyDay(wkday, group);
                                datePlaced = true;
                            }
                            tempPersonSelected = null;
                        }
                        // If not, force someone 
                            //TODO: Pop up message asking user what to do.
                        else
                        {
                            for (int i = 0; i < lowestDutyDaysList.Count && !datePlaced; i++)
                            {
                                if (groupList.Contains(lowestDutyDaysList[i])
                                    && !lowestDutyDaysList[i].mDutyDays.mDates.Contains(wkday)
                                    && !datePlaced)
                                {
                                    MessageBox.Show("Nobody available for " + wkday.ToShortDateString()
                                                    + Environment.NewLine + "Assigning " + lowestDutyDaysList[i].mName
                                                    + " to the " + group + " group because they currently have the fewest days.",
                                                    "Problem Making Calendar");

                                    lowestDutyDaysList[i].AddDutyDay(wkday, group);
                                    datePlaced = true;
                                }
                            }
                        }
                    }

                }
            }

        }   // End FirstScheduleRun()

        /// <summary>
        /// This function should check that everyone is +/- one duty day of everyone else in their group(s). 
        /// If the person is in multiple groups, it goes by the group with the highest number of duty days per person. 
        /// It will trade people if they don't have it requested off, if it doesn't give them multiple consecutive
        /// days, and try to avoid consecutive weekends (low priority).
        /// </summary>
        public void SecondScheduleRun()
        {
            throw new NotImplementedException("SecondScheduleRun has not been made yet.");
        }   // End SecondScheduleRun()

        /// <summary>
        /// This function should check that anyone in multiple groups is spread out approximately evenly
        /// between the groups. If the person is below the threshold in any one group, this is a 
        /// low-priority problem. Try to trade them, first locally, then with nearby days.
        /// If they can't be traded, that's alright.
        /// </summary>
        public void ThirdScheduleRun()
        {
            throw new NotImplementedException("ThirdScheduleRun has not been made yet.");

            // Threshold for trading is 
            // floor( (avg # days scheduled for people within that group) * ( 1 / (# groups this person is in) ) )
            // 
            // EX: For both groups, each member having 20 duty days.
            // # groups |  threshold percent | threshold days
            //    2     |          33%       |       6
            //    3     |          25%       |       5
            //    4     |          20%       |       4
            //    5     |          17%       |       3

            

        }   // End ThirdScheduleRun()


        /// <summary>
        /// Once all the people have been scheduled, it creates a calendar containing 
        /// all people for each day.
        /// </summary>
        public void FillCalendar()
        {
            DateTime currentDay = mStartDay;

            while (currentDay <= mEndDay)
            {
                foreach (string grp in mGroups)
                {
                    foreach (Person per in mPeople)
                    {
                        if (per.mGroups.Contains(grp))
                        {
                            int perIndex = per.mDutyDays.mDates.IndexOf(currentDay);

                            if (perIndex >= 0)
                            {
                                if (per.mDutyDays.mGroups[perIndex] == grp)
                                {
                                    mCalendar.AddDayAndAssignment(currentDay, per, grp);
                                }
                            }
                        }
                    }
                }
                currentDay = currentDay.AddDays(1);
            }

            // If we are making the calendar from scratch and the settings are correct, rotate Saturdays.
            if (!isFromImport && mWeekendsSamePeople && mShuffleWeekendPeople)
                RotateWeekends();

        }   // End FillCalendar()

        /// <summary>
        /// Rotates anyone in similar groups for weekends
        /// </summary>
        public void RotateWeekends()
        {
            // TODO: At the moment, this only really works if there's two dual-groups.
            //       Fix it so that it actually rotates everyone possible.
            for(int i = 0; i < mCalendar.mDateList.Count(); i++)
            {
                // For Saturdays
                if(mCalendar.mDateList[i].DayOfWeek.ToString().ToLower().Contains("sat"))
                {
                    // For each person each day
                    for (int j = 1; j < mCalendar.mPeopleList[i].Count(); j++)
                    {
                        if(mCalendar.mPeopleList[i][j].person.mGroups.Contains(mCalendar.mPeopleList[i][j - 1].group)
                            && mCalendar.mPeopleList[i][j - 1].person.mGroups.Contains(mCalendar.mPeopleList[i][j].group))
                        {
                            // These two people are able to be swapped
                            var tempPer1 = mCalendar.mPeopleList[i][j];
                            var tempPer2 = mCalendar.mPeopleList[i][j - 1];

                            Person temp = tempPer1.person;
                            tempPer1.person = tempPer2.person;
                            tempPer2.person = temp;

                            mCalendar.mPeopleList[i][j] = tempPer1;
                            mCalendar.mPeopleList[i][j - 1] = tempPer2;
                        }
                    }
                }
                // Twice for Sundays
                if (mCalendar.mDateList[i].DayOfWeek.ToString().ToLower().Contains("sun"))
                {
                    // For each person twice
                    for (int j = 1; j < mCalendar.mPeopleList[i].Count(); j++)
                    {
                        if (mCalendar.mPeopleList[i][j].person.mGroups.Contains(mCalendar.mPeopleList[i][j - 1].group)
                            && mCalendar.mPeopleList[i][j - 1].person.mGroups.Contains(mCalendar.mPeopleList[i][j].group))
                        {
                            // These two people are able to be swapped
                            var tempPer1 = mCalendar.mPeopleList[i][j];
                            var tempPer2 = mCalendar.mPeopleList[i][j - 1];

                            Person temp = tempPer1.person;
                            tempPer1.person = tempPer2.person;
                            tempPer2.person = temp;

                            mCalendar.mPeopleList[i][j] = tempPer1;
                            mCalendar.mPeopleList[i][j - 1] = tempPer2;
                        }
                    }
                    for (int j = 1; j < mCalendar.mPeopleList[i].Count(); j++)
                    {
                        if (mCalendar.mPeopleList[i][j].person.mGroups.Contains(mCalendar.mPeopleList[i][j - 1].group)
                            && mCalendar.mPeopleList[i][j - 1].person.mGroups.Contains(mCalendar.mPeopleList[i][j].group))
                        {
                            // These two people are able to be swapped
                            var tempPer1 = mCalendar.mPeopleList[i][j];
                            var tempPer2 = mCalendar.mPeopleList[i][j - 1];

                            Person temp = tempPer1.person;
                            tempPer1.person = tempPer2.person;
                            tempPer2.person = temp;

                            mCalendar.mPeopleList[i][j] = tempPer1;
                            mCalendar.mPeopleList[i][j - 1] = tempPer2;
                        }
                    }
                }
            }
        }   // End RotateSaturdays()

        /// <summary>
        /// Clears the scheduled info
        /// </summary>
        public void ClearCalendar()
        {
            foreach (Person per in mPeople)
            {
                per.mDutyDays.mDates.Clear();
                per.mDutyDays.mGroups.Clear();
                per.mWeekdayCount = 0;
                per.mWeekendCount = 0;
            }
            mCalendar.mDateList.Clear();
            mCalendar.mPeopleList.Clear();
        }   // End ClearCalendar()

        /// <summary>
        /// Output to a CSV file for human use
        /// </summary>
        public void MakeCSVFile()
        {
            // Show the "Save As" dialog and get the name/location from the user
            var fileName = "Schedule " + mStartDay.ToString("MM-dd-yyyy") + " to " + mEndDay.ToString("MM-dd-yyyy");

            string sName = Path.GetFileName(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents") + "/" + fileName);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = fileName;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Delete any old file if it's there
                System.IO.File.Delete(saveFileDialog1.FileName);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName, true))
                {
                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();

                    int currentMonth = 0;
                    bool breakFromLoop = false;
                    int i = 0;
                    while (i < mCalendar.mDateList.Count)
                    {
                        if (currentMonth != mCalendar.mDateList[i].Month)
                        {
                            // New month header
                            file.WriteLine("\n");
                            file.WriteLine(mfi.GetMonthName(mCalendar.mDateList[i].Month).ToString());
                            file.WriteLine("Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday");
                            currentMonth = mCalendar.mDateList[i].Month;

                            if (i > 0)
                                i--;
                        }
                        string weekStr = "";

                        // Pad space to offset in calendar
                        for (int j = 0; j < (int)mCalendar.mDateList[i].DayOfWeek; j++)
                        {
                            int asdkfja = (int)mCalendar.mDateList[i].DayOfWeek;
                            weekStr += ",";
                        }
                        breakFromLoop = false;
                        while (i < mCalendar.mDateList.Count
                            && breakFromLoop == false
                            //&& ((int)mCalendar.mDateList[i].DayOfWeek > 0) 
                            && (mCalendar.mDateList[i].Month == currentMonth))
                        {
                            int asdkfja = (int)mCalendar.mDateList[i].DayOfWeek;
                            weekStr += mCalendar.mDateList[i].Date.ToShortDateString() + " ";

                            foreach (DatesAndAssignments.PersonAndGroup p in mCalendar.mPeopleList[i])
                            {
                                weekStr += " " + p.person.mName;
                            }

                            weekStr += ",";

                            if (i < mCalendar.mDateList.Count
                                && ((int)mCalendar.mDateList[i].DayOfWeek >= 6
                                    || (i > 0
                                        && mCalendar.mDateList[i] != mCalendar.mDateList[i - 1].AddDays(1))))
                            {
                                breakFromLoop = true;
                                i--;
                            }

                            i++;
                        }
                        file.WriteLine(weekStr);

                        i++;
                    }

                    // Print duty summary for each group
                    file.WriteLine();
                    file.WriteLine();
                    file.WriteLine();
                    file.WriteLine("Group, Name, Days count");
                    foreach (string grp in mGroups)
                    {
                        file.WriteLine(grp);

                        foreach (Person per in mPeople)
                        {
                            if (per.mGroups.Contains(grp))
                            {
                                file.WriteLine( ", " + per.mName + ", " + per.mDutyDays.mDates.Count.ToString());
                            }
                        }
                    }
                }
            }
        }   // End MakeCSVFile()

        /// <summary>
        /// Output to a CSV file to be easily imported again later.
        /// 
        /// TODO: Implement the GUI and back-end to import this back.
        /// </summary>
        public void ExportCSVFile()
        {
            // Show the "Save As" dialog and get the name/location from the user
            var fileName = "DutyScheduleExport_" + mStartDay.ToString("MM-dd-yyyy");

            string sName = Path.GetFileName(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents") + "/" + fileName);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = fileName;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Delete any old file if it's there
                System.IO.File.Delete(saveFileDialog1.FileName);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName, true))
                {
                    // The first line will be the list of groups if there's at least one person
                    if (mCalendar.mPeopleList.Count >= 1)
                    {
                        string groupsStr = "";
                        foreach (DatesAndAssignments.PersonAndGroup pg in mCalendar.mPeopleList[0])
                        {
                            groupsStr += pg.group + ",";
                        }
                        file.WriteLine(groupsStr);
                    }

                    // Then make a new line for each day
                    // [date], [name1], [name2], ...
                    for (int i = 0; i < mCalendar.mDateList.Count; i++)
                    {
                        string dayStr = mCalendar.mDateList[i].Date.ToString("MM-dd-yyyy");
                        dayStr += ",";

                        foreach (DatesAndAssignments.PersonAndGroup pg in mCalendar.mPeopleList[i])
                        {
                            dayStr += pg.person.mName + "," ;
                        }

                        file.WriteLine(dayStr);
                    }
                }
            }
        }   // End ExportCSVFile()

        /// <summary>
        /// Creates an Excel file for the calendar including formatting 
        /// and summary of days worked.
        /// </summary>
        public void MakeExcelFile()
        {
            try
            {
                // Check if Excel is installed
                Type officeType = Type.GetTypeFromProgID("Excel.Application");
                if (officeType != null)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var excelApp = new Microsoft.Office.Interop.Excel.Application();

                    // Create a new, empty workbook and add it to the collection returned  
                    // by property Workbooks. The new workbook becomes the active workbook. 
                    // Add has an optional parameter for specifying a particular template.  
                    // Because no argument is sent in this example, Add creates a new workbook. 
                    excelApp.Workbooks.Add();

                    // This project uses a single workSheet
                    Microsoft.Office.Interop.Excel._Worksheet workSheet
                        = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.ActiveSheet;

                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();

                    int currentMonth = 0;
                    bool breakFromLoop = false;
                    int i = 0;

                    int cRow = 0;
                    char cCol = 'A';

                    // Center the output
                    workSheet.Cells[1, "A"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    while (i < mCalendar.mDateList.Count)
                    {
                        if (currentMonth != mCalendar.mDateList[i].Month)
                        {
                            // New month header
                            cRow++;
                            cCol = 'A';

                            workSheet.Cells[cRow, "A"].NumberFormat = "@";
                            workSheet.Cells[cRow, "A"] = mfi.GetMonthName(mCalendar.mDateList[i].Month).ToString() + " " + mCalendar.mDateList[i].Year.ToString();
                            workSheet.Cells[cRow, "A"].Font.Size = 14;

                            workSheet.Range[workSheet.Cells[cRow, "A"], workSheet.Cells[cRow, "G"]].Merge();
                            workSheet.Cells[cRow, "A"].Font.Bold = true;

                            cRow++;
                            workSheet.Cells[cRow, cCol.ToString()].EntireRow.Font.Bold = true;
                            workSheet.Cells[cRow, cCol.ToString()] = "Sunday";
                            cCol++;
                            workSheet.Cells[cRow, cCol.ToString()] = "Monday";
                            cCol++;
                            workSheet.Cells[cRow, cCol.ToString()] = "Tuesday";
                            cCol++;
                            workSheet.Cells[cRow, cCol.ToString()] = "Wednesday";
                            cCol++;
                            workSheet.Cells[cRow, cCol.ToString()] = "Thursday";
                            cCol++;
                            workSheet.Cells[cRow, cCol.ToString()] = "Friday";
                            cCol++;
                            workSheet.Cells[cRow, cCol.ToString()] = "Saturday";
                            currentMonth = mCalendar.mDateList[i].Month;

                            BorderAround(workSheet.Range["A" + cRow, "G" + cRow], 0);

                            cRow++;
                            cCol = 'A';

                            if (i > 0)
                                i--;

                            // Show key for first day of month
                            // Will be overwritten if needed for calendar
                            string keyString = "Key:";
                            foreach (string grp in mGroups)
                            {
                                keyString += "\n" + grp;
                            }

                            workSheet.Cells[cRow, cCol.ToString()] = keyString;
                            workSheet.Cells[cRow, cCol.ToString()].Font.Bold = true;
                            BorderAround(workSheet.Range["A" + cRow, "G" + cRow], 0);
                            cCol = 'B';
                        }

                        //Reset at the beginning of each week
                        if (cCol != 'A' && (int)mCalendar.mDateList[i].DayOfWeek == 0)
                            cRow++;
                        cCol = 'A';
                        string dayStr = "";

                        // Pad space to offset in calendar if week doesn't start on Sunday
                        for (int j = 0; j < (int)mCalendar.mDateList[i].DayOfWeek; j++)
                        {
                            cCol++;
                        }

                        breakFromLoop = false;

                        //Add all the days and people until the next week/month rolls around
                        while (i < mCalendar.mDateList.Count
                            && mCalendar.mDateList[i].Month == currentMonth
                            && breakFromLoop == false)
                        {
                            dayStr += mCalendar.mDateList[i].Day.ToString();

                            foreach (DatesAndAssignments.PersonAndGroup p in mCalendar.mPeopleList[i])
                            {
                                dayStr += "\n" + p.person.mName;
                            }
                            workSheet.Cells[cRow, cCol.ToString()] = dayStr;
                            BorderAround(workSheet.Range["A" + cRow, "G" + cRow], 0);
                            cCol++;

                            //Handle end-of-week and holidays conditions
                            if (i < mCalendar.mDateList.Count
                                && ((int)mCalendar.mDateList[i].DayOfWeek >= 6
                                || (i < mCalendar.mDateList.Count - 1
                                && mCalendar.mDateList[i].AddDays(1) != mCalendar.mDateList[i + 1])))
                            {
                                breakFromLoop = true;
                                i--;
                            }
                            i++;
                            dayStr = "";
                        }

                        cRow++;
                        cCol = 'A';
                        i++;
                    }



                    /*
                     * Temporarily using the cross-group summary only instead of the full one until I can fairly force more even load balancing
                     */

                    // Print duty summary for each group
                    //cRow += 3;
                    //workSheet.Cells[cRow, cCol.ToString()].EntireRow.Font.Bold = true;
                    //workSheet.Cells[cRow, cCol.ToString()] = "Group";
                    //cCol++;
                    //workSheet.Cells[cRow, cCol.ToString()] = "Name";
                    //cCol++;
                    //workSheet.Cells[cRow, cCol.ToString()] = "Total days";
                    //cCol++;
                    //workSheet.Cells[cRow, cCol.ToString()] = "Wknd days";
                    //cCol++;
                    //workSheet.Cells[cRow, cCol.ToString()] = "Weekdays";
                    //cCol++;
                    //foreach (string grp in mGroups)
                    //{
                    //    cRow++;
                    //    cCol = 'A';
                    //    workSheet.Cells[cRow, cCol.ToString()] = grp;
                    //    cRow++;

                    //    foreach (Person per in mPeople)
                    //    {
                    //        if (per.mGroups.Contains(grp))
                    //        {
                    //            int weekendCount = per.mDutyDays.mDates.Count(x => mWeekendDaysOfWeek.Contains(x.DayOfWeek));

                    //            cCol++;
                    //            workSheet.Cells[cRow, cCol.ToString()] = per.mName;
                    //            cCol++;
                    //            workSheet.Cells[cRow, cCol.ToString()] = per.mDutyDays.mDates.Count.ToString();
                    //            cCol++;
                    //            workSheet.Cells[cRow, cCol.ToString()] = weekendCount.ToString();
                    //            cCol++;
                    //            workSheet.Cells[cRow, cCol.ToString()] = (per.mDutyDays.mDates.Count - weekendCount).ToString();

                    //            cCol = 'A';
                    //            cRow++;
                    //        }
                    //    }
                    //}

                    //// Print duty summary for each group
                    //// TODO: Switch to this version once SecondScheduleRun() and ThirdScheduleRun() are done
                    //cRow += 3;
                    //workSheet.Cells[cRow, cCol.ToString()].EntireRow.Font.Bold = true;
                    //workSheet.Cells[cRow, cCol.ToString()] = "Group";
                    //cCol++;
                    //workSheet.Cells[cRow, cCol.ToString()] = "Name";
                    //cCol++;
                    //workSheet.Cells[cRow, cCol.ToString()] = "Total days";
                    //foreach (string grp in mGroups)
                    //{
                    //    cRow++;
                    //    cCol = 'A';
                    //    workSheet.Cells[cRow, cCol.ToString()] = grp;
                    //    cRow++;

                    //    for(int j = 0; j < mPeople.Count(); j++)
                    //    {
                    //        if (mPeople[j].mGroups.Contains(grp))
                    //        {
                    //            cCol++;
                    //            workSheet.Cells[cRow, cCol.ToString()] = mPeople[j].mName;
                    //            cCol++;
                    //            int dutyCount = 0;
                    //            foreach (string groupCt in mPeople[j].mDutyDays.mGroups)
                    //            {
                    //                if (groupCt == grp)
                    //                    dutyCount++;
                    //            }
                    //            workSheet.Cells[cRow, cCol.ToString()] = dutyCount;
                    //            cCol = 'A';
                    //            cRow++;
                    //        }
                    //    }
                    //}


                    /*
                    * The cross-group summary: Lists each person, how many days working, how many are weekend days, 
                    * and how many are weekdays.
                    */
                    cRow += 2;
                    workSheet.Cells[cRow, cCol.ToString()].EntireRow.Font.Bold = true;
                    workSheet.Cells[cRow, cCol.ToString()] = "Cross-group\nsummary";
                    cCol++;
                    workSheet.Cells[cRow, cCol.ToString()] = "Name";
                    cCol++;
                    workSheet.Cells[cRow, cCol.ToString()] = "Total days";
                    cCol++;
                    workSheet.Cells[cRow, cCol.ToString()] = "Wknd days";
                    cCol++;
                    workSheet.Cells[cRow, cCol.ToString()] = "Weekdays";
                    cRow++;
                    cCol = 'A';

                    foreach (Person per in mPeople)
                    {
                        int weekendCount = per.mDutyDays.mDates.Count(x => mWeekendDaysOfWeek.Contains(x.DayOfWeek));

                        cCol++;
                        workSheet.Cells[cRow, cCol.ToString()] = per.mName;
                        cCol++;
                        workSheet.Cells[cRow, cCol.ToString()] = per.mDutyDays.mDates.Count.ToString();
                        cCol++;
                        workSheet.Cells[cRow, cCol.ToString()] = weekendCount.ToString();
                        cCol++;
                        workSheet.Cells[cRow, cCol.ToString()] = (per.mDutyDays.mDates.Count - weekendCount).ToString();

                        cCol = 'A';
                        cRow++;
                    }

                    /*
                    * The group summary: Lists each group and each member below that
                    */
                    cRow += 2;
                    workSheet.Cells[cRow, cCol.ToString()].EntireRow.Font.Bold = true;
                    workSheet.Cells[cRow, cCol.ToString()] = "Groups";
                    cRow++;

                    cCol = 'A';
                    workSheet.Cells[cRow, cCol.ToString()].EntireRow.Font.Bold = true;
                    foreach (String groupName in mGroups)
                    {
                        workSheet.Cells[cRow, cCol.ToString()] = groupName;
                        cCol++;
                    }
                    cRow++;
                    cCol = 'A';
                    int topRow = cRow;

                    foreach (String groupName in mGroups)
                    {
                        foreach (Person per in mPeople)
                        {
                            if (per.mGroups.Contains(groupName))
                            {
                                workSheet.Cells[cRow, cCol.ToString()] = per.mName;
                                cRow++;
                            }
                        }
                        cCol++;
                        cRow = topRow;
                    }

                    // Set cCol to be used for auto-adjust column size
                    if (cCol < 'g')
                        cCol = 'g';

                    excelApp.Visible = true;
                    // Resize all the cells
                    for (int z = 1; z <= cCol; z++)
                    {
                        workSheet.Columns[z].ColumnWidth = 35;
                        workSheet.Columns[z].AutoFit();
                    }
                    for (int z = 1; z <= cRow; z++)
                    {
                        workSheet.Rows[z].AutoFit();
                    }

                    Cursor.Current = Cursors.Default;
                    // Make the object visible
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Error in Excel Calendar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }   // End MakeExcelFile()

        /// <summary>
        /// Create a border around a range of Excel cells.
        /// </summary>
        /// <param name="range">A range of Excel cells</param>
        /// <param name="color">The color to border the cells</param>
        private void BorderAround(Microsoft.Office.Interop.Excel.Range range, int color)
        {
            Microsoft.Office.Interop.Excel.Borders borders = range.Borders;

            // Create a line outside and between each edge
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            borders.Color = color;

            // No diagonal borders
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
        }


        /// <summary>
        /// Uses Outlook to create calendar events and send them. Has a slight delay between 
        /// each email so Outlook doesn't crash.
        /// </summary>
        /// <param name="startHour">The hour of the day to start the events</param>
        /// <param name="startMin">The minute of the day to start the events</param>
        /// <param name="ccEmailList">A list of people to CC for all events</param>
        /// <param name="senderEmail">An optional email address of the sender (if it doesn't work without it)</param>
        public void MakeOutlookEvents(int startHour, int startMin, List<string> ccEmailList, string senderEmail = "")
        {
            const int delayBetweenEmails = 3;
            const int delayAfterSending = 10;

            Cursor.Current = Cursors.WaitCursor;

            
            PageSendInvites pageSend = new PageSendInvites();

            float percentMult = mCalendar.mDateList.Count / 102;
            int secondsEst = mCalendar.mDateList.Count * 4 + 10;

            pageSend.SetLoadingBarPercent(0);
            pageSend.SetTimeRemaining(secondsEst);

            pageSend.Show();
            
            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
            for (int i = 0; i < mCalendar.mDateList.Count; i++)
            {
                try
                {
                    Microsoft.Office.Interop.Outlook.AppointmentItem appt =
                            (Microsoft.Office.Interop.Outlook.AppointmentItem)
                            outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);

                    appt.Subject = "Duty: " + mCalendar.mDateList[i].ToShortDateString();
                    appt.MeetingStatus = Microsoft.Office.Interop.Outlook.OlMeetingStatus.olMeeting;

                    appt.Start = mCalendar.mDateList[i].AddHours(startHour);
                    appt.Start = appt.Start.AddMinutes(startMin);
                    appt.End = appt.Start.AddHours(1);

                    //Create the string for the body of the event and add each person to the email list
                    string bodyStr = "Duty: " + mCalendar.mDateList[i].ToShortDateString() + "\n";
                    for (int j = 0; j < mCalendar.mPeopleList[i].Count; j++)
                    {
                        bodyStr += mCalendar.mPeopleList[i][j].group
                            + ": "
                            + mCalendar.mPeopleList[i][j].person.mName 
                            + "\n";

                        // Add main recipients (check that the email address exists)
                        if (mCalendar.mPeopleList[i][j].person.mEmailAddress.Length > 3)
                        {
                            Microsoft.Office.Interop.Outlook.Recipient recipRequired =
                                appt.Recipients.Add(mCalendar.mPeopleList[i][j].person.mEmailAddress);
                            recipRequired.Type =
                                (int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType.olRequired;
                        }
                    }
                    appt.Body = bodyStr;

                    //Add all CC people
                    foreach (string ccEmail in ccEmailList)
                    {
                        if (!string.IsNullOrEmpty(ccEmail))
                        {
                            Microsoft.Office.Interop.Outlook.Recipient recipOptional =
                                appt.Recipients.Add(ccEmail);
                            recipOptional.Type =
                                (int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType.olOptional;
                        }
                    }

                    // Current user's email address as the organizer
                    string myEmailAddress = "";
                    if (!string.IsNullOrEmpty(senderEmail))
                    {
                        myEmailAddress = senderEmail;
                    }
                    else
                    {
                        myEmailAddress = outlookApp.Session.CurrentUser.AddressEntry.Address;
                        // Handle global directory name if email is invalid
                        if (IsEmailValid(myEmailAddress) == false)
                            myEmailAddress = outlookApp.Session.CurrentUser.Name;
                    }
                    Microsoft.Office.Interop.Outlook.Recipient recipOrganizer =
                        appt.Recipients.Add(myEmailAddress);
                    recipOrganizer.Type =
                        (int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType.olOrganizer;
                        //(int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType.olRequired;


                    appt.Recipients.ResolveAll();
                    appt.Save();

                    // My computer seems to not like this. Also gives the chance to edit the days before sending.
                    // TODO: Make this a checkmark in the UI
                    appt.Send();

                    // My system can't seem to handle a few hundred Outlook emails in one go.
                    // Wait four seconds between each invite creation.
                    System.Threading.Thread.Sleep(delayBetweenEmails * 500);        // Delay half of the delayBetweenEmails time
                    secondsEst = (mCalendar.mDateList.Count - i) * delayBetweenEmails + delayAfterSending - 2;
                    System.Threading.Thread.Sleep(delayBetweenEmails * 500);        // Delay the other half of the delayBetweenEmails time


                    pageSend.SetLoadingBarPercent( Convert.ToInt32((i+1) * percentMult) );
                    secondsEst = (mCalendar.mDateList.Count - (i + 1)) * delayBetweenEmails + delayAfterSending;
                    pageSend.SetTimeRemaining(secondsEst);

                }
                catch (System.Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }


            }

            // Reset from loading cursor to normal
            Cursor.Current = Cursors.Default;

            // Close Outlook after an additional few seconds (just in case)
            System.Threading.Thread.Sleep(delayAfterSending * 500);         // Delay half of the delayAfterSending time
            pageSend.SetLoadingBarPercent(99);
            pageSend.SetTimeRemaining(delayAfterSending / 2);

            System.Threading.Thread.Sleep(delayAfterSending * 500);         // Delay the other half of the delayAfterSending time
            pageSend.SetLoadingBarPercent(100);
            pageSend.SetTimeRemaining(0);

            outlookApp.Quit();

            pageSend.Close();

        }   // End MakeOutlookEvents()


        /// <summary>
        /// Returns the list of people with the fewest number of days + randomness within (partial list)
        /// </summary>
        /// <returns></returns>
        public List<Person> WhoHasFewestDays()
        {
            List<Person> sortedList = new List<Person>(mPeople);
            sortedList = sortedList.OrderBy(o => o.mDutyDays.mDates.Count).ToList();

            //Find the cutoff point for the lowest number of duty days
            int maxIndex = 0;
            for (int i = 1; i < sortedList.Count; i++)
            {
                if (sortedList[maxIndex].mDutyDays.mDates.Count() == sortedList[i].mDutyDays.mDates.Count())
                    maxIndex = i;
                else
                    break;
            }
            //Remove anyone more than the min number of duty days
            if(maxIndex < sortedList.Count - 1)
                sortedList.RemoveRange(maxIndex + 1, sortedList.Count - maxIndex - 1);

            List<Person> shuffledList = ShuffleList<Person>(sortedList);
            shuffledList = ShuffleList<Person>(sortedList);

            //Reverse the list half of the time
            Random rnd = new Random();
            if(rnd.Next() % 2 == 1)
            {
                sortedList.Reverse();
            }

            shuffledList = ShuffleList<Person>(sortedList);
            shuffledList = ShuffleList<Person>(sortedList);

            return shuffledList;
        }   // End WhoHasFewestDays()

        /// <summary>
        /// Returns the list of people sorted by fewest number of days + randomness within (full list)
        /// </summary>
        /// <returns></returns>
        public List<Person> SortByFewestDays()
        {
            List<Person> sortedList = new List<Person>(mPeople);
            sortedList = sortedList.OrderBy(o => o.mDutyDays.mDates.Count).ToList();

            //Randomly swap any pairs that have equal scheduled days
            Random rnd = new Random();
            for (int j = 0; j < 50; j++)
            {
                for (int i = 0; i < sortedList.Count - 1; i++)
                {
                    rnd.Next();

                    if (sortedList[i].mDutyDays.mDates.Count == sortedList[i + 1].mDutyDays.mDates.Count
                        && (rnd.Next() % 2) == 0)
                    {
                        Person tempPerson = sortedList[i];
                        sortedList[i] = sortedList[i + 1];
                        sortedList[i + 1] = tempPerson;
                    }
                }
            }
                

            return sortedList;
        }   // End WhoHasFewestDays()

        /// <summary>
        /// Shuffles a list
        /// </summary>
        /// <typeparam name="T">Type of list to shuffle</typeparam>
        /// <param name="inputList">The list to be shuffled</param>
        /// <returns></returns>
        private List<T> ShuffleList<T>(List<T> inputList)
        {
            List<T> inList = new List<T>(inputList);
            List<T> randomList = new List<T>();

            Random rand = new Random();
            int randomIndex = 0;
            while (inList.Count > 0)
            {
                randomIndex = rand.Next(0, inList.Count);    // Choose a random object in the list
                randomList.Add(inList[randomIndex]);         // Add it to the new, random list
                inList.RemoveAt(randomIndex);                // Remove to avoid duplicates
            }

            return randomList;  // Return the new random list
        }   //End ShuffleList(...)

        /// <summary>
        /// Returns the index of the person with the most days scheduled.
        /// If there's a tie, returns the first in the list.
        /// </summary>
        /// <returns></returns>
        public int WhoHasMostDays()
        {
            int index = -1;
            int currentVal = 0;

            foreach (Person p in mPeople)
            {
                if (p.mDutyDays.mDates.Count > currentVal)
                {
                    index = mPeople.IndexOf(p);
                    currentVal = p.mDutyDays.mDates.Count;
                }
            }

            return index;
        }   // End WhoHasMostDays()

        /// <summary>
        /// Returns a list of people who are in a certain group.
        /// </summary>
        /// <param name="groupIn">Name of the group to check for.</param>
        /// <returns></returns>
        public List<Person> WhoIsInGroup(string groupIn)
        {
            List<Person> groupList = new List<Person>();

            foreach(Person p in mPeople)
            {
                if (p.mGroups.IndexOf(groupIn) > -1)
                    groupList.Add(p);
            }

            return groupList;
        }   // End WhoIsInGroup(string groupIn)

        /// <summary>
        /// Goes through each person and checks that their requested days 
        /// off are in the range. Just a check to help the user.
        /// Important to check because someone [*cough* Sage] gave me a 
        /// giant list of days off that were for the wrong year.
        /// </summary>
        /// <returns></returns>
        public bool CheckDaysOff()
        {
            List<Tuple<string, DateTime>> sage = new List<Tuple<string, DateTime>>();

            foreach (Person per in mPeople)
            {
                foreach (DateTime dayOff in per.mDaysOffRequested)
                {
                    if (mStartDay > dayOff || dayOff > mEndDay)
                    {
                        sage.Add(new Tuple<string, DateTime>(per.mName, dayOff));
                    }

                }
            }
            
            bool fixThings = false;
            if (sage.Count() > 0)
            {
                string errorDays = "Found the following people with invalid days off:\n";
                foreach (Tuple<string, DateTime> tup in sage)
                {
                    errorDays += tup.Item1 + ": " + tup.Item2 + "\n";
                }
                errorDays += "Do you want to re-write the file and try again?";

            

                DialogResult result = MessageBox.Show(errorDays, "Error in days off",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result != DialogResult.No)
                    fixThings = true;
            }
            return fixThings;
        }   // End CheckDaysOff()
    }   // End class
}
