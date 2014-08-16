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
using System.Threading;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Outlook;

namespace Duty_Schedule
{
    public class CalendarMaker
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
            mStartDay = new DateTime();
            mEndDay = new DateTime();

            mBreaks = new List<DateTime>();
            mHolidays = new List<DateTime>();
            mWeekends = new List<List<DateTime>>();
            mWeekdays = new List<DateTime>();
            mCalendar = new DatesAndAssignments();

            mPeople = new List<Person>();
            mGroups = new List<string>();
        }


        public CalendarMaker(string dateFilePath, string groupFilePath)
        {
            mStartDay = new DateTime();
            mEndDay = new DateTime();

            mBreaks = new List<DateTime>();
            mHolidays = new List<DateTime>();
            mWeekends = new List<List<DateTime>>();
            mWeekdays = new List<DateTime>();
            mCalendar = new DatesAndAssignments();

            mPeople = new List<Person>();
            mGroups = new List<string>();

            FileInputs fi = new FileInputs();
            mPeople = fi.GetGroups(groupFilePath);
            var dates = fi.GetDates(dateFilePath);

            mStartDay = dates.startDate;
            mEndDay = dates.endDate;
            mHolidays = dates.holidayList;
            mBreaks = dates.breakList;

            Initalize();
            FirstScheduleRun();
            FillCalendar();
        }

        public DatesAndAssignments GetCalendar()
        {
            return mCalendar;
        }

        public List<Person> GetPeople()
        {
            return mPeople;
        }

        public List<string> GetGroups()
        {
            return mGroups;
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

        public void Initalize()
        {
            DateTime currentDay = mStartDay;
            List<DateTime> tempHolidays = new List<DateTime>(mHolidays);
            int dayCount = 0;
            int weekendCount = 0;
            int breakCount = 0;

            // This section finds all the groups
            foreach (Person per in mPeople)
            {
                foreach (string grp in per.mGroups)
                if ( !mGroups.Contains(grp) )
                {
                    mGroups.Add(grp);
                }

            }

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
                //Standard or long weekend
                else if (!mBreaks.Contains(currentDay))
                {
                    mWeekends.Add(new List<DateTime>());

                    while (currentDay.DayOfWeek != DayOfWeek.Monday
                            || tempHolidays.Contains(currentDay))
                    {
                        mWeekends[weekendCount].Add(currentDay);

                        // Remove holidays from list
                        if (tempHolidays.Contains(currentDay))
                        {
                            tempHolidays.Remove(currentDay);
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
                    if(!datePlaced)     //Nobody available without the date requested off. LOL get rekt.
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

        //Clears the scheduled info
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
        }

        //Output to a CSV file
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

                    // Print duty summery for each group
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
                    // Add has an optional parameter for specifying a praticular template.  
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
                            cCol = 'A';

                            if (i > 0)
                                i--;

                            // Show key for first day of month
                            // Will be overwritten if needed for calendar
                            string exString = "Key:";
                            foreach (string grp in mGroups)
                            {
                                exString += "\n" + grp;
                            }

                            workSheet.Cells[cRow, cCol.ToString()] = exString;
                        }

                        //Reset at the beginning of each week
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
                            cCol++;

                            //Handle end-of-week and holidays conditions
                            if (i < mCalendar.mDateList.Count
                                && ((int)mCalendar.mDateList[i].DayOfWeek >= 6
                                || i < mCalendar.mDateList.Count - 1
                                && mCalendar.mDateList[i].AddDays(1) != mCalendar.mDateList[i + 1]))
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

                    // Print duty summery for each group
                    cRow += 3;
                    workSheet.Cells[cRow, cCol.ToString()] = "Group";
                    cCol++;
                    workSheet.Cells[cRow, cCol.ToString()] = "Name";
                    cCol++;
                    workSheet.Cells[cRow, cCol.ToString()] = "Days count";
                    cCol++;
                    foreach (string grp in mGroups)
                    {
                        cRow++;
                        cCol = 'A';
                        workSheet.Cells[cRow, cCol.ToString()] = grp;
                        cRow++;

                        foreach (Person per in mPeople)
                        {
                            if (per.mGroups.Contains(grp))
                            {
                                cCol++;
                                workSheet.Cells[cRow, cCol.ToString()] = per.mName;
                                cCol++;
                                workSheet.Cells[cRow, cCol.ToString()] = per.mDutyDays.mDates.Count.ToString();
                                cCol = 'A';
                                cRow++;
                            }
                        }
                    }

                    // Resize all the cells
                    for (int z = 1; z <= 7; z++)
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
                    excelApp.Visible = true;

                    // Show the "Save As" dialog and get the name/location from the user
                    var sName = excelApp.GetSaveAsFilename("Schedule " + mStartDay.ToString("MM-dd-yyyy") + " to " + mEndDay.ToString("MM-dd-yyyy"));

                    //If the user entered a name/location, save the file
                    if (sName is string && sName.Length > 1)
                    {
                        workSheet.SaveAs(sName + "xlsx");
                    }
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Error in Excel Calendar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }   // End MakeExcelFile()


        //Output to calendar events
        public void MakeOutlookEvents(int startHour, int startMin, List<string> ccEmailList, string senderEmail = "")
        {
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

                        // Add main recipients
                        Microsoft.Office.Interop.Outlook.Recipient recipRequired =
                            appt.Recipients.Add(mCalendar.mPeopleList[i][j].person.mEmailAddress);
                        recipRequired.Type =
                            (int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType.olRequired;
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
                    appt.Send();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            outlookApp.Quit();

        }   // End MakeOutlookEvents()



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
