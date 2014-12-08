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
using System.IO;
using System.Windows.Forms;

namespace Duty_Schedule
{
    public class FileInputs
    {
        private string mDirectory;


        public FileInputs() 
        {
            mDirectory = Directory.GetCurrentDirectory();
        }

        public FileInputs(string directory)
        {
            mDirectory = directory;
        }

        // Gets the all the groups and names from a file
        public DatesStruct GetDates(string dateFileName = "Dates.txt")
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            List<DateTime> holidayList = new List<DateTime>();
            List<DateTime> breakList = new List<DateTime>();

            //string fullFileLoc = mDirectory + "\\" + dateFileName;

            if (File.Exists(dateFileName))
            {
                StreamReader strRead = File.OpenText(dateFileName);

                string lnStr = "";

                while ((lnStr = strRead.ReadLine()) != null)
                {
                    lnStr = lnStr.Trim();

                    if (lnStr.Length > 0 && lnStr[0] != '#')
                    {
                        // Start date = 's'
                        if (lnStr.ToLower()[0] == 's')
                        {
                            int sepIndex = lnStr.IndexOf('-');
                            if (sepIndex >= 0)
                            {
                                lnStr = lnStr.Substring(sepIndex + 1).Trim();
                                startDate = DateTime.Parse(lnStr);
                            }
                        }
                        // End date = 'e'
                        else if (lnStr.ToLower()[0] == 'e')
                        {
                            int sepIndex = lnStr.IndexOf('-');
                            if (sepIndex >= 0)
                            {
                                lnStr = lnStr.Substring(sepIndex + 1).Trim();
                                endDate = DateTime.Parse(lnStr);
                            }
                        }
                        // Holiday = 'h'
                        else if (lnStr.ToLower()[0] == 'h')
                        {
                            int sepIndex = lnStr.IndexOf('-');
                            if (sepIndex >= 0)
                            {
                                lnStr = lnStr.Substring(sepIndex + 1).Trim();

                                int commaIndex = lnStr.IndexOf(',');
                                while (commaIndex > -1)
                                {
                                    // Peel away the first date in the string and add it to the DateTime list
                                    string tempDateStr = lnStr.Substring(0, commaIndex).Trim(',').Trim();
                                    lnStr = lnStr.Substring(commaIndex).Trim(',').Trim();

                                    if (tempDateStr.Length > 0)
                                        holidayList.Add(DateTime.Parse(tempDateStr));

                                    commaIndex = lnStr.IndexOf(',');
                                }
                                // Handle the last date in the string
                                if (lnStr.Length > 0)
                                    holidayList.Add(DateTime.Parse(lnStr));
                            }
                        }
                        else if (lnStr.ToLower()[0] == 'b')
                        {
                            int sepIndex = lnStr.IndexOf('-');
                            if (sepIndex >= 0)
                            {
                                lnStr = lnStr.Substring(sepIndex + 1).Trim();

                                int commaIndex = lnStr.IndexOf(',');
                                while (commaIndex > -1)
                                {
                                    // Peel away the first date in the string and add it to the DateTime list
                                    string tempDateStr = lnStr.Substring(0, commaIndex).Trim(',').Trim();
                                    lnStr = lnStr.Substring(commaIndex).Trim(',').Trim();

                                    if (tempDateStr.Length > 0)
                                        breakList.Add(DateTime.Parse(tempDateStr));

                                    commaIndex = lnStr.IndexOf(',');
                                }
                                // Handle the last date in the string
                                if (lnStr.Length > 0)
                                    breakList.Add(DateTime.Parse(lnStr));
                            }
                        }
                    }
                }
                strRead.Close();
            }

            if (startDate == new DateTime())
            {
                MessageBox.Show("No start date found in file " + dateFileName, "Calendar Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (endDate == new DateTime())
            {
                MessageBox.Show("No end date found in file " + dateFileName, "Calendar Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DatesStruct ds = new DatesStruct();
            ds.startDate = startDate;
            ds.endDate = endDate;
            ds.holidayList = holidayList;
            ds.breakList = breakList;

            return ds;
        }   //End GetGroups(string groupsFileName = "Groups.txt")

        // Gets the all the groups and names from a file
        public List<Person> GetGroups(string groupsFileName, DatesStruct dates)
        {
            List<Person> pplLst = new List<Person>();

            //string fullFileLoc = mDirectory + "\\" + groupsFileName;

            if (File.Exists(groupsFileName))
            {
                StreamReader strRead = File.OpenText(groupsFileName);

                string lnStr = "";
                string currGroup = "";

                while ((lnStr = strRead.ReadLine()) != null)
                {
                    if (lnStr.Trim().Length > 0 && !char.IsWhiteSpace(lnStr[0]))
                    {
                        // If it isn't whitespace, it should be a group name

                        // Ignore comments in the file
                        if (lnStr.Length >= 2 && lnStr[0] != '#')
                        {
                            currGroup = lnStr.Trim();
                        }

                        // TODO: Search through all groups and add people as needed
                    }
                    else if (lnStr.Trim().Length > 0)
                    {
                        string datesRequestedOff = "";
                        // This should be a person so remove leading/ending whitespace and find where the name ends
                        string personName = lnStr.Trim();
                        int sepIndex = personName.IndexOf('-');

                        // Ignore comments in the file
                        if (personName[0] != '#')
                        {
                            // If there is a range of dates requested off
                            if (sepIndex > -1)
                            {
                                datesRequestedOff = personName.Substring(sepIndex);
                                personName = personName.Substring(0, sepIndex).Trim();

                                // Clean up the dates string
                                datesRequestedOff = datesRequestedOff.Trim('-').Trim();
                                List<DateTime> dateList = new List<DateTime>();

                                int commaIndex = datesRequestedOff.IndexOf(',');
                                while (datesRequestedOff.Length > 0)//(commaIndex > -1)
                                {
                                    // TODO: Add support for "Mondays" in addition to explicit dates
                                    // TODO: Add support for date ranges (e.g. "1/15/2015 - 1/18/2015")
                                    // TODO: Add error message if date not in range
                                    string tempDateStr = "";
                                    if (commaIndex > -1)
                                    {
                                        // Peel away the first date in the string and add it to the DateTime list
                                        tempDateStr = datesRequestedOff.Substring(0, commaIndex).Trim(',').Trim();
                                        datesRequestedOff = datesRequestedOff.Substring(commaIndex).Trim(',').Trim();
                                    }
                                    else
                                    {
                                        // No more commas
                                        tempDateStr = datesRequestedOff.Trim();
                                        datesRequestedOff = "";
                                    }

                                    if (tempDateStr.Length > 0)
                                    {
                                        int slashCt = tempDateStr.Split('/').Length - 1;
                                        int dashCt = tempDateStr.Split('-').Length - 1;

                                        if ((slashCt == 2 && dashCt == 0) || (slashCt == 0 && dashCt == 2))
                                        {
                                            // Date is probably in form of "mm/dd/yy[yy]" or "mm-dd-yy[yy]"
                                            try
                                            {
                                                dateList.Add(DateTime.Parse(tempDateStr));
                                            }
                                            catch (Exception e)
                                            {
                                                MessageBox.Show(e.Message
                                                    + Environment.NewLine + "Person: " + personName
                                                    + Environment.NewLine + "Found problem with date: " + tempDateStr,
                                                    "Error in groups file");
                                            }
                                        }
                                        else if ((slashCt == 1 && dashCt == 0) || (slashCt == 0 && dashCt == 1))
                                        {
                                            // Date is probably in form of "mm/dd" or "mm-dd"
                                            // Need to add the year to the end; for now just add start date's year
                                            // TODO: Make year addition more dynamic.
                                            try
                                            {
                                                if (slashCt > 0)
                                                    tempDateStr += "/" + dates.startDate.Year.ToString();
                                                else if (dashCt > 0)
                                                    tempDateStr += "-" + dates.startDate.Year.ToString();

                                                dateList.Add(DateTime.Parse(tempDateStr));
                                            }
                                            catch (Exception e)
                                            {
                                                MessageBox.Show(e.Message
                                                    + Environment.NewLine + "Person: " + personName
                                                    + Environment.NewLine + "Found problem with date: " + tempDateStr,
                                                    "Error in groups file");
                                            }
                                        }
                                        else if (tempDateStr.ToLower().Contains("day"))
                                        {
                                            // This is probably a day of the week.
                                            // Get a list of all applicable dates and add them
                                            try
                                            {
                                                if (tempDateStr.ToLower().Contains("sun"))
                                                {
                                                    dateList.AddRange(
                                                        GetDatesForDayOfWeek(dates.startDate, dates.endDate, DayOfWeek.Sunday));
                                                }
                                                else if (tempDateStr.ToLower().Contains("mon"))
                                                {
                                                    List<DateTime> things = GetDatesForDayOfWeek(dates.startDate, dates.endDate, DayOfWeek.Monday);
                                                    dateList.AddRange(
                                                        GetDatesForDayOfWeek(dates.startDate, dates.endDate, DayOfWeek.Monday));
                                                }
                                                else if (tempDateStr.ToLower().Contains("tue"))
                                                {
                                                    dateList.AddRange(
                                                        GetDatesForDayOfWeek(dates.startDate, dates.endDate, DayOfWeek.Tuesday));
                                                }
                                                else if (tempDateStr.ToLower().Contains("wed"))
                                                {
                                                    dateList.AddRange(
                                                        GetDatesForDayOfWeek(dates.startDate, dates.endDate, DayOfWeek.Wednesday));
                                                }
                                                else if (tempDateStr.ToLower().Contains("thu"))
                                                {
                                                    dateList.AddRange(
                                                        GetDatesForDayOfWeek(dates.startDate, dates.endDate, DayOfWeek.Thursday));
                                                }
                                                else if (tempDateStr.ToLower().Contains("fri"))
                                                {
                                                    dateList.AddRange(
                                                        GetDatesForDayOfWeek(dates.startDate, dates.endDate, DayOfWeek.Friday));
                                                }
                                                else if (tempDateStr.ToLower().Contains("sat"))
                                                {
                                                    dateList.AddRange(
                                                        GetDatesForDayOfWeek(dates.startDate, dates.endDate, DayOfWeek.Saturday));
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Person: " + personName
                                                    + Environment.NewLine + "Can't figure out: " + tempDateStr,
                                                    "Error in groups file");
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                MessageBox.Show(e.Message
                                                    + Environment.NewLine + "Person: " + personName.Substring(0, 10) + "..."
                                                    + Environment.NewLine + "Found problem with date: " + tempDateStr,
                                                    "Error in groups file");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Person: " + personName
                                                    + Environment.NewLine + "Found problem with date: " + tempDateStr,
                                                    "Error in groups file");
                                        }
                                    }

                                    commaIndex = datesRequestedOff.IndexOf(',');
                                }
                                // Handle the last date in the string
                                //if (datesRequestedOff.Length > 0)
                                //    dateList.Add(DateTime.Parse(datesRequestedOff));

                                // Actually add the person
                                bool foundPerson = false;
                                foreach (Person per in pplLst)
                                {
                                    if (per.mName == personName)
                                    {
                                        foundPerson = true;
                                        //If they aren't in this group already
                                        if (!per.mGroups.Contains(currGroup))
                                        {
                                            per.AddGroup(currGroup);
                                        }
                                        // If they don't have each date already
                                        foreach (DateTime dt in dateList)
                                        {
                                            if (!per.mDaysOffRequested.Contains(dt))
                                            {
                                                per.AddDayOffRequested(dt);
                                            }
                                        }
                                    }
                                }
                                if (!foundPerson)
                                    pplLst.Add(new Person(personName, currGroup, dateList));

                            }
                            else
                            {
                                personName = personName.Trim();

                                // Actually add the person
                                bool foundPerson = false;
                                foreach (Person per in pplLst)
                                {
                                    if (per.mName == personName)
                                    {
                                        foundPerson = true;
                                        //If they aren't in this group already
                                        if (!per.mGroups.Contains(currGroup))
                                        {
                                            per.AddGroup(currGroup);
                                        }
                                    }
                                }
                                if (!foundPerson)
                                    pplLst.Add(new Person(personName, currGroup, new List<DateTime>()));
                            }
                        }
                    }
                }
                strRead.Close();
            }


            if (pplLst.Count <= 0)
            {
                MessageBox.Show("No people in file " + groupsFileName, "Calendar Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            return pplLst;
        }   // End GetGroups(string groupsFileName = "Groups.txt")

        // Gets all specified days within a date range
        List<DateTime> GetDatesForDayOfWeek(DateTime startDate, DateTime endDate, DayOfWeek dayToMatch)
        {
            List<DateTime> returnList = new List<DateTime>();
            DateTime selectedDay = new DateTime(startDate.Year, startDate.Month, startDate.Day);

            // Find the first matching day
            while (selectedDay.DayOfWeek != dayToMatch)
            {
                selectedDay = selectedDay.AddDays(1);
            }

            // Add all applicable days to the list
            while (selectedDay <= endDate)
            {
                returnList.Add(selectedDay);
                selectedDay = selectedDay.AddDays(7);
            }

            return returnList;
        }

    }
}
