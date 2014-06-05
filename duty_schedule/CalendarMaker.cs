using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Google.Apis.Auth;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System.Threading;

namespace Duty_Schedule
{
    class CalendarMaker
    {
        private DateTime mStartDay;
        private DateTime mEndDay;
        private List<DateTime> mBreaks;
        private List<DateTime> mHolidays;
        private List<List<DateTime>> mWeekends;
        private List<DateTime> mWeekdays;
        private List<Person> mPeople;
        private List<string> mGroups;

        private DatesAndAssignments mCalendar;


        public CalendarMaker()
        {
            mStartDay = new DateTime(2012, 9, 22);
            mEndDay = new DateTime(2012, 12, 7);

            mBreaks = new List<DateTime>();
            mHolidays = new List<DateTime>();
            mWeekends = new List<List<DateTime>>();
            mWeekdays = new List<DateTime>();
            mCalendar = new DatesAndAssignments();

            mHolidays.Add(new DateTime(2012, 11, 12));

            mBreaks.Add(new DateTime(2012, 11, 22));
            mBreaks.Add(new DateTime(2012, 11, 23));
            mBreaks.Add(new DateTime(2012, 11, 24));
            mBreaks.Add(new DateTime(2012, 11, 25));

            mPeople = new List<Person>();
            List<DateTime> tempDaysOff = new List<DateTime>();
            tempDaysOff.Add(new DateTime(2012, 11, 1));
            tempDaysOff.Add(new DateTime(2012, 11, 2));
            tempDaysOff.Add(new DateTime(2012, 11, 3));

            mGroups = new List<string>();
            mGroups.Add("group 1");
            mGroups.Add("group 2");
            mGroups.Add("group 3");

            List<string> dualGroup = new List<string>();
            dualGroup.Add("group 1");
            dualGroup.Add("group 2");

            for (int i = 0; i < 6; i++)
            {
                mPeople.Add(new Person(("Person " + mPeople.Count.ToString()), dualGroup, tempDaysOff));
            }
            for (int i = 0; i < 7; i++)
            {
                mPeople.Add(new Person(("Person " + mPeople.Count.ToString()), dualGroup, tempDaysOff));
            }
            for (int i = 0; i < 5; i++)
            {
                mPeople.Add(new Person(("Person " + mPeople.Count.ToString()), "group 3", tempDaysOff));
            }



            Initalize();
            FirstScheduleRun();
            FillCalendar();
            //MakeCSVFile();
            //MakeGoogleCalendar();
            MakeExcelFile();
        }


        public void Initalize()
        {
            DateTime currentDay = mStartDay;
            List<DateTime> tempHolidays = new List<DateTime>(mHolidays);
            int dayCount = 0;
            int weekendCount = 0;
            int breakCount = 0;

            // This section loads each day into mWeekends or mWeekdays
            while (currentDay <= mEndDay)
            {
                //Standard weekday
                if (currentDay.DayOfWeek >= DayOfWeek.Monday
                    && currentDay.DayOfWeek <= DayOfWeek.Thursday
                    && !tempHolidays.Contains(currentDay)
                    && !mBreaks.Contains(currentDay))
                {
                    mWeekdays.Add(currentDay);
                    currentDay = currentDay.AddDays(1);
                    dayCount++;
                }
                //Standard weekend
                else if ( ( currentDay.DayOfWeek >= DayOfWeek.Friday
                    || currentDay.DayOfWeek <= DayOfWeek.Sunday )
                    && !tempHolidays.Contains(currentDay)
                    && !mBreaks.Contains(currentDay))
                {
                    mWeekends.Add(new List<DateTime>());

                    while (currentDay.DayOfWeek != DayOfWeek.Monday)
                    {
                        mWeekends[weekendCount].Add(currentDay);
                        currentDay = currentDay.AddDays(1);
                    }

                    if (tempHolidays.Count > 0)
                    {

                        //Handle any end-of-week holidays
                        if (tempHolidays.Count > 0 && tempHolidays.First<DateTime>() < currentDay)
                        {
                            while (tempHolidays.First<DateTime>() < currentDay)
                            {
                                mWeekends[weekendCount].Insert(0, tempHolidays[0]);
                                tempHolidays.Remove(tempHolidays.First<DateTime>());
                            }
                        }

                        //Handle Monday (and after) holidays
                        if (tempHolidays.First<DateTime>() == currentDay)
                        {
                            mWeekends[weekendCount].Add(tempHolidays.First<DateTime>());
                            currentDay = currentDay.AddDays(1);
                            tempHolidays.Remove(tempHolidays.First<DateTime>());
                        }
                    }

                    weekendCount++;
                }
                //Should only be breaks here
                else
                {
                    if (!mBreaks.Contains(currentDay))
                        throw new Exception("Found invalid date - Should be break, but not listed: " + currentDay.ToShortDateString());
                    breakCount++;
                    currentDay = currentDay.AddDays(1);
                }
            }


        }   // End Initalize()

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
            foreach (List<DateTime> wknd in mWeekends)
            {
                foreach (string group in mGroups)
                {
                    List<Person> lowestDutyDaysList = WhoHasFewestDays();
                    List<Person> groupList = WhoIsInGroup(group);

                    //List<Person> commonList = groupList.Intersect(lowestDutyDaysList);

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
                    if(!datePlaced)     //Nobody available without the date requested off
                    {
                        for (int i = 0; i < lowestDutyDaysList.Count && !datePlaced; i++)
                        {
                            if (groupList.Contains(lowestDutyDaysList[i])
                                && !lowestDutyDaysList[i].mDutyDays.ContainsDates(wknd)
                                && !datePlaced)
                            {
                                lowestDutyDaysList[i].AddDutyWeekend(wknd, group);
                                datePlaced = true;
                            }
                        }
                    }
                }
            }

            // Schedule all the weekdays
            foreach (DateTime wkday in mWeekdays)
            {
                foreach (string group in mGroups)
                {
                    List<Person> lowestDutyDaysList = WhoHasFewestDays();
                    List<Person> groupList = WhoIsInGroup(group);

                    //List<Person> commonList = groupList.Intersect(lowestDutyDaysList);

                    bool datePlaced = false;

                    for (int i = 0; i < lowestDutyDaysList.Count && !datePlaced; i++)
                    {
                        // Give it whoever has the least number of duty days (if possible)

                        bool wkd = lowestDutyDaysList[i].IsDateRequestedOff(wkday);
                        bool grp = groupList.Contains(mPeople[i]);

                        if (!lowestDutyDaysList[i].IsDateRequestedOff(wkday)
                            && groupList.Contains(lowestDutyDaysList[i])
                            && !lowestDutyDaysList[i].mDutyDays.mDates.Contains(wkday)
                            && !datePlaced)
                        {
                            lowestDutyDaysList[i].AddDutyDay(wkday, group);
                            datePlaced = true;
                        }
                    }
                    if (!datePlaced)     //Nobody available without the date requested off
                    {
                        for (int i = 0; i < lowestDutyDaysList.Count && !datePlaced; i++)
                        {
                            if (groupList.Contains(lowestDutyDaysList[i]) 
                                && !lowestDutyDaysList[i].mDutyDays.mDates.Contains(wkday)
                                && !datePlaced)
                            {
                                lowestDutyDaysList[i].AddDutyDay(wkday, group);
                                datePlaced = true;
                            }
                        }
                    }

                }
            }
        }   // End FirstScheduleRun()


        // Once all the people have been scheduled, it creates a calendar containing all people
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
        }   // End FillCalendar()

        //Output to a CSV file
        public void MakeCSVFile()
        {
            int numMonths = mEndDay.Month - mStartDay.Month;

            // Delete any old file if it's there
            System.IO.File.Delete("CalendarOutput.csv");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"CalendarOutput.csv", true))
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
                        file.WriteLine( mfi.GetMonthName(mCalendar.mDateList[i].Month).ToString() );
                        file.WriteLine("Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday");
                        currentMonth = mCalendar.mDateList[i].Month;

                        if (i > 0)
                            i--;
                    }
                    string weekStr = "";

                    // Pad space to offset in calendar
                    for(int j = 0; j < (int)mCalendar.mDateList[i].DayOfWeek; j++)
                    {
                        int asdkfja = (int)mCalendar.mDateList[i].DayOfWeek;
                        weekStr += ",";
                    }
                    breakFromLoop = false;
                    while (i < mCalendar.mDateList.Count
                        && breakFromLoop == false
                        //&& ((int)mCalendar.mDateList[i].DayOfWeek > 0) 
                        && (mCalendar.mDateList[i].Month == currentMonth) )
                    {
                        int asdkfja = (int)mCalendar.mDateList[i].DayOfWeek;
                        weekStr += mCalendar.mDateList[i].Date.ToShortDateString() + " ";

                        foreach(DatesAndAssignments.PersonAndGroup p in mCalendar.mPeopleList[i])
                        {
                            weekStr += " " + p.person.mName;
                        }

                        weekStr += ",";

                        if (i < mCalendar.mDateList.Count
                            && ( (int)mCalendar.mDateList[i].DayOfWeek >= 6
                            || mCalendar.mDateList[i] != mCalendar.mDateList[i-1].AddDays(1)) )
                        {
                            breakFromLoop = true;
                            i--;
                        }
                        i++;
                    }
                    file.WriteLine(weekStr);


                    i++;
                }
            }


        }   // End MakeCSVFile()

        public void MakeExcelFile()
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();

            // Make the object visible.
            excelApp.Visible = true;

            // Create a new, empty workbook and add it to the collection returned  
            // by property Workbooks. The new workbook becomes the active workbook. 
            // Add has an optional parameter for specifying a praticular template.  
            // Because no argument is sent in this example, Add creates a new workbook. 
            excelApp.Workbooks.Add();

            // This example uses a single workSheet. The explicit type casting is 
            // removed in a later procedure.
            Microsoft.Office.Interop.Excel._Worksheet workSheet 
                = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.ActiveSheet;


            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();

            int currentMonth = 0;
            bool breakFromLoop = false;
            int i = 0;

            int cRow = 0;
            char cCol = 'A';

            workSheet.Cells[1, "A"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            while (i < mCalendar.mDateList.Count)
            {
                if (currentMonth != mCalendar.mDateList[i].Month)
                {
                    // New month header
                    cRow++;
                    cCol = 'A';

                    workSheet.Cells[cRow, "A"] = mfi.GetMonthName(mCalendar.mDateList[i].Month).ToString();

                    workSheet.Range[workSheet.Cells[cRow, "A"], workSheet.Cells[cRow, "G"]].Merge();
                    workSheet.Cells[cRow, "A"].Font.Bold = true;

                    cRow++;
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

                    cRow++;
                    if (i > 0)
                        i--;
                }

                cCol = 'A';
                string dayStr = "";

                // Pad space to offset in calendar
                for (int j = 0; j < (int)mCalendar.mDateList[i].DayOfWeek; j++)
                {
                    cCol++;
                }

                breakFromLoop = false;

                while (i < mCalendar.mDateList.Count
                    && breakFromLoop == false
                    //&& ((int)mCalendar.mDateList[i].DayOfWeek > 0) 
                    && (mCalendar.mDateList[i].Month == currentMonth))
                {
                    //dayStr += mCalendar.mDateList[i].Date.ToShortDateString(); //+ "\n";
                    dayStr += mCalendar.mDateList[i].Day.ToString();

                    foreach (DatesAndAssignments.PersonAndGroup p in mCalendar.mPeopleList[i])
                    {
                        dayStr += "\n" + p.person.mName;
                    }
                    workSheet.Cells[cRow, cCol.ToString()] = dayStr;
                    cCol++;

                    //weekStr += ",";

                    if (i < mCalendar.mDateList.Count
                        && ((int)mCalendar.mDateList[i].DayOfWeek >= 6
                        //|| mCalendar.mDateList[i] != mCalendar.mDateList[i - 1].AddDays(1)
                        || i < mCalendar.mDateList.Count - 1
                        && mCalendar.mDateList[i].AddDays(1) != mCalendar.mDateList[i + 1]))
                    {
                        breakFromLoop = true;
                        i--;
                    }
                    i++;
                    dayStr = "";
                }
//                    file.WriteLine(weekStr);
                cRow++;
                cCol = 'A';
                i++;

            }



//            // Establish column headings in cells A1 and B1.
//            workSheet.Cells[1, "A"] = "ID Number";
//            workSheet.Cells[1, "B"] = "Current Balance";
//
//            var row = 1;
//            for (int i = 0; i < 20; i++)
//            {
//                row++;
//                workSheet.Cells[row, "A"] = i;
//                workSheet.Cells[row, "B"] = i * 2;
//            }

            for (int z = 1; z <= 7; z++)
            {
                workSheet.Columns[z].ColumnWidth = 35;
                workSheet.Columns[z].AutoFit();
            }
            for (int z = 1; z <= cRow; z++)
            {
                workSheet.Rows[z].AutoFit();
            }
        }   // End MakeExcelFile()





        //Output to a Google Calendar
        public void MakeGoogleCalendar()
        {
            string calendarName = "jaj0tvgail7mu0bukmn3mcec3s@group.calendar.google.com";

            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = "dak",
                    ClientSecret = "pw",
                },
                new[] { CalendarService.Scope.Calendar },
                "dak",
                CancellationToken.None).Result;

            // Create the service.
            var g = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Calendar API Sample",
            });


            try
            {
                //Google.Apis.Calendar.v3.CalendarService g = new Google.Apis.Calendar.v3.CalendarService();

                Event ev = new Event();

                EventDateTime start = new EventDateTime();
                start.Date = mCalendar.mDateList[0].Date.ToString();

                ev.AnyoneCanAddSelf = true;
                ev.EndTimeUnspecified = true;
                ev.GuestsCanSeeOtherGuests = true;
                ev.Start = start;
                ev.Description = "Test Description...";

                g.Events.Insert(ev, calendarName);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"CalendarOutput.csv", true))
            //{
            //    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            //
            //    int currentMonth = 0;
            //    bool breakFromLoop = false;
            //    int i = 0;
            //    while (i < mCalendar.mDateList.Count)
            //    {
            //        if (currentMonth != mCalendar.mDateList[i].Month)
            //        {
            //            // New month header
            //            file.WriteLine("\n");
            //            file.WriteLine(mfi.GetMonthName(mCalendar.mDateList[i].Month).ToString());
            //            file.WriteLine("Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday");
            //            currentMonth = mCalendar.mDateList[i].Month;
            //
            //            if (i > 0)
            //                i--;
            //        }
            //        string weekStr = "";
            //
            //        // Pad space to offset in calendar
            //        for (int j = 0; j < (int)mCalendar.mDateList[i].DayOfWeek; j++)
            //        {
            //            int asdkfja = (int)mCalendar.mDateList[i].DayOfWeek;
            //            weekStr += ",";
            //        }
            //        breakFromLoop = false;
            //        while (i < mCalendar.mDateList.Count
            //            && breakFromLoop == false
            //            //&& ((int)mCalendar.mDateList[i].DayOfWeek > 0) 
            //            && (mCalendar.mDateList[i].Month == currentMonth))
            //        {
            //            int asdkfja = (int)mCalendar.mDateList[i].DayOfWeek;
            //            weekStr += mCalendar.mDateList[i].Date.ToShortDateString() + " ";
            //
            //            foreach (DatesAndAssignments.PersonAndGroup p in mCalendar.mPeopleList[i])
            //            {
            //                weekStr += " " + p.person.mName;
            //            }
            //
            //            weekStr += ",";
            //
            //            if (i < mCalendar.mDateList.Count
            //                && ((int)mCalendar.mDateList[i].DayOfWeek >= 6
            //                || mCalendar.mDateList[i] != mCalendar.mDateList[i - 1].AddDays(1)))
            //            {
            //                breakFromLoop = true;
            //                i--;
            //            }
            //            i++;
            //        }
            //        file.WriteLine(weekStr);
            //
            //
            //        i++;
            //    }
            //}


        }   // End MakeGoogleCalendar()



        // Returns the index of the person with the fewest days scheduled.
        public List<Person> WhoHasFewestDays()
        {
            //int index = -1;
            //int currentVal = 99999999;

            List<Person> sortedList = new List<Person>(mPeople);
            sortedList = sortedList.OrderBy(o => o.mDutyDays.mDates.Count).ToList();

            //Randomly swap any pairs that have equal scheduled days
            Random rnd = new Random();
            for (int i = 0; i < sortedList.Count - 1; i++ )
            {
                rnd.Next();

                if(sortedList[i].mDutyDays.mDates.Count == sortedList[i+1].mDutyDays.mDates.Count 
                    && (rnd.Next() % 2) == 0)
                {
                    Person tempPerson = sortedList[i];
                    sortedList[i] = sortedList[i + 1];
                    sortedList[i + 1] = tempPerson;
                }
            }
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

            return sortedList;
        }   // End WhoHasFewestDays()

        // Returns the index of the person with the most days scheduled. 
        // If there's a tie, returns the first in the list.
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

        // Returns the index of the person with the most days scheduled. 
        // If there's a tie, returns the first in the list.
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

    }   // End class
}
