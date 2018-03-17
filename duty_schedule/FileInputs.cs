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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Duty_Schedule
{
    /// <summary>
    /// The class for reading in all the files
    /// </summary>
    public class FileInputs
    {
        /// <summary>
        /// The present working directory
        /// </summary>
        private string mDirectory;

        /// <summary>
        /// The default ctor. Gets the directory of the .exe
        /// </summary>
        public FileInputs()
        {
            mDirectory = Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Ctor with manual directory input
        /// </summary>
        /// <param name="directory"></param>
        public FileInputs(string directory)
        {
            mDirectory = directory;
        }

        /// <summary>
        /// Gets the start and end days along with holidays and breaks
        /// </summary>
        /// <param name="dateFileName">The name of the file to read from</param>
        /// <returns></returns>
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
                                try
                                {
                                    startDate = DateTime.Parse(lnStr);
                                }
                                catch
                                {
                                    MessageBox.Show("Unable to parse date in 'Start' section of date file: " + lnStr, "Calendar Input",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        // End date = 'e'
                        else if (lnStr.ToLower()[0] == 'e')
                        {
                            int sepIndex = lnStr.IndexOf('-');
                            if (sepIndex >= 0)
                            {
                                lnStr = lnStr.Substring(sepIndex + 1).Trim();

                                try
                                {
                                    endDate = DateTime.Parse(lnStr);
                                }
                                catch
                                {
                                    MessageBox.Show("Unable to parse date in 'End' section of date file: " + lnStr, "Calendar Input",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
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
                                    {
                                        try
                                        {
                                            holidayList.Add(DateTime.Parse(tempDateStr));
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Unable to parse date in 'Holiday' section of date file: " + tempDateStr, "Calendar Input",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }

                                    commaIndex = lnStr.IndexOf(',');
                                }
                                // Handle the last date in the string
                                if (lnStr.Length > 0)
                                {
                                    try
                                    {
                                        holidayList.Add(DateTime.Parse(lnStr));
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Unable to parse date in 'Holiday' section of date file: " + lnStr, "Calendar Input",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        // Break = 'b'
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
                                    {
                                        try
                                        {
                                            breakList.Add(DateTime.Parse(tempDateStr));
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Unable to parse date in 'Break' section of date file: " + tempDateStr, "Calendar Input",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }

                                    commaIndex = lnStr.IndexOf(',');
                                }
                                // Handle the last date in the string
                                if (lnStr.Length > 0)
                                {
                                    try
                                    {
                                        breakList.Add(DateTime.Parse(lnStr));
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Unable to parse date in 'Break' section of date file: " + lnStr, "Calendar Input",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
                strRead.Close();
            }

            // Display errors is there wasn't a start or end date
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

        /// <summary>
        /// Gets the all the groups and names from a file
        /// </summary>
        /// <param name="groupsFileName">The name of the file containing people and groups</param>
        /// <param name="dates">The DatesStruct that should be made immediately before this from Dates.txt</param>
        /// <returns></returns>
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

                        //TODO: Add optional email address in here

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

                                        if ((slashCt == 4 && dashCt == 1))// || (slashCt == 0 && dashCt == 5))
                                        {
                                            // Date is probably a range in form of "mm/dd/yy[yy] - mm/dd/yy[yy]"
                                            // TODO: Either remove xx-xx[-xxxx] format from being valid or add it to the range capability

                                            int dashIndex = tempDateStr.IndexOf('-');

                                            //Get the two dates
                                            string tempDateStr1 = tempDateStr.Substring(0, dashIndex).Trim('-').Trim();
                                            string tempDateStr2 = tempDateStr.Substring(dashIndex).Trim('-').Trim();

                                            // Attempt to parse the start and end dates
                                            DateTime dStart = new DateTime();
                                            DateTime dEnd = new DateTime();
                                            try
                                            {
                                                dStart = DateTime.Parse(tempDateStr1);
                                            }
                                            catch (Exception e)
                                            {
                                                MessageBox.Show(e.Message
                                                    + Environment.NewLine + "Person: " + personName
                                                    + Environment.NewLine + "Found problem with date: " + tempDateStr1,
                                                    "Error in groups file");
                                            }

                                            try
                                            {
                                                dEnd = DateTime.Parse(tempDateStr2);
                                            }
                                            catch (Exception e)
                                            {
                                                MessageBox.Show(e.Message
                                                    + Environment.NewLine + "Person: " + personName
                                                    + Environment.NewLine + "Found problem with date: " + tempDateStr2,
                                                    "Error in groups file");
                                            }

                                            // Add the range to a temp list
                                            List<DateTime> tempDateList = new List<DateTime>();
                                            for (DateTime d = dStart; d <= dEnd; d = d.AddDays(1))
                                            {
                                                tempDateList.Add(d);
                                            }

                                            // If the day count seems reasonable, add to the real list.
                                            if (tempDateList.Count > 1 && tempDateList.Count < 50)    // 50 seems like a reasonable max number of days off, right?
                                            {
                                                dateList.AddRange(tempDateList);
                                            }
                                        }
                                        else if (slashCt == 2 && dashCt == 1)
                                        {
                                            // Date is probably a range in form of "mm/dd - mm/dd"
                                            // TODO: Either remove xx-xx[-xxxx] format from being valid or add it to the range capability

                                            int dashIndex = tempDateStr.IndexOf('-');

                                            //Get the two dates
                                            string tempDateStr1 = tempDateStr.Substring(0, dashIndex).Trim('-').Trim();
                                            string tempDateStr2 = tempDateStr.Substring(dashIndex).Trim('-').Trim();
                                            // Add the year
                                            tempDateStr1 += "/" + dates.startDate.Year.ToString();
                                            tempDateStr2 += "/" + dates.startDate.Year.ToString();

                                            // Attempt to parse the start and end dates
                                            DateTime dStart = new DateTime();
                                            DateTime dEnd = new DateTime();
                                            try
                                            {
                                                dStart = DateTime.Parse(tempDateStr1);
                                            }
                                            catch (Exception e)
                                            {
                                                MessageBox.Show(e.Message
                                                    + Environment.NewLine + "Person: " + personName
                                                    + Environment.NewLine + "Found problem with date: " + tempDateStr1,
                                                    "Error in groups file");
                                            }

                                            try
                                            {
                                                dEnd = DateTime.Parse(tempDateStr2);
                                            }
                                            catch (Exception e)
                                            {
                                                MessageBox.Show(e.Message
                                                    + Environment.NewLine + "Person: " + personName
                                                    + Environment.NewLine + "Found problem with date: " + tempDateStr2,
                                                    "Error in groups file");
                                            }

                                            // Add the range to a temp list
                                            List<DateTime> tempDateList = new List<DateTime>();
                                            for (DateTime d = dStart; d <= dEnd; d = d.AddDays(1))
                                            {
                                                tempDateList.Add(d);
                                            }

                                            // If the day count seems reasonable, add to the real list.
                                            if (tempDateList.Count > 1 && tempDateList.Count < 50)    // 50 seems like a reasonable max number of days off, right?
                                            {
                                                dateList.AddRange(tempDateList);
                                            }
                                        }
                                        else if ((slashCt == 2 && dashCt == 0) || (slashCt == 0 && dashCt == 2))
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

        /// <summary>
        /// This
        /// </summary>
        /// <param name="csvFileName">The name of the file to be imported from.</param>
        /// <returns>A tuple. The first part is a DatesStruct filled with the start and
        /// end dates. The second is a list of people and their associated duty days.</returns>
        public Tuple<DatesStruct, List<Person>> GetImportFromCsv(string csvFileName)
        {
            // A list of groups. Should be the first line of the CSV.
            List<string> groupsLst = new List<string>();

            // The list of people. Filled as more people are found. Will be returned.
            List<Person> pplLst = new List<Person>();

            // The dates of duty. Will be returned.
            DatesStruct dates = new DatesStruct();
            dates.holidayList = new List<DateTime>();
            dates.breakList = new List<DateTime>();

            //string fullFileLoc = mDirectory + "\\" + groupsFileName;

            if (File.Exists(csvFileName))
            {
                StreamReader strRead = File.OpenText(csvFileName);

                string lnStr = "";

                //The first line should be the list of groups
                if ((lnStr = strRead.ReadLine()) != null)
                {
                    // Remove outside whitespace just in case
                    lnStr = lnStr.Trim();
                    //lnStr = lnStr.Trim(',');
                    string tempGroupName = "";

                    // Peel away each group then add it to the group list
                    while (lnStr.Length > 0)
                    {
                        // Get the first index of a comma
                        int commaIndex = lnStr.IndexOf(',');

                        if (commaIndex > -1)
                        {
                            // Get the name of the group
                            tempGroupName = lnStr.Substring(0, commaIndex);
                            tempGroupName = tempGroupName.Trim();
                            tempGroupName = tempGroupName.Trim(',');

                            if (tempGroupName.Length > 0)
                            {
                                groupsLst.Add(tempGroupName);
                            }

                            lnStr = lnStr.Substring(commaIndex + 1, lnStr.Length - commaIndex - 1);
                        }
                        else
                        {
                            // Else to prevent infinite looping if there's no end comma of the line
                            tempGroupName = lnStr;
                            tempGroupName = tempGroupName.Trim();

                            if (tempGroupName.Length > 0)
                            {
                                groupsLst.Add(tempGroupName);
                            }
                            lnStr = "";
                        }
                    }
                }

                // The date to be used
                string currentDateStr = "";
                DateTime currentDate = new DateTime();

                while ((lnStr = strRead.ReadLine()) != null)
                {
                    lnStr = lnStr.Trim();
                    if (lnStr.Length > 0)
                    {
                        // A list of each person scheduled for this day.
                        // Must equal the number of groups at the top of the page.
                        List<string> personNames = new List<string>();

                        // First get the date for this line
                        if (lnStr.Length > 0)
                        {
                            // Get the first index of a comma
                            int commaIndex = lnStr.IndexOf(',');

                            if (commaIndex > -1)
                            {
                                currentDateStr = lnStr.Substring(0, commaIndex);
                                currentDateStr = currentDateStr.Trim();
                                currentDateStr = currentDateStr.Trim(',');

                                if (currentDateStr.Length > 0)
                                {
                                    try
                                    {
                                        // TODO: Test this part more
                                        //
                                        DateTime tempDate = DateTime.Parse(currentDateStr);
                                        // I really hope that this isn't used for too far in the past because
                                        // this is how I'm going to check if this is the first line of the file
                                        if (dates.startDate.Year < 1000)
                                        {
                                            dates.startDate = tempDate;
                                        }
                                        // This part checks if there are any non-scheduled days (breaks)
                                        else if (tempDate != currentDate.AddDays(1))
                                        {
                                            DateTime breakDate = currentDate.AddDays(1);
                                            while (breakDate != tempDate)
                                            {
                                                dates.breakList.Add(breakDate);
                                                breakDate = breakDate.AddDays(1);
                                            }
                                        }

                                        // Actually set the current line's date
                                        currentDate = tempDate;

                                        // Also set the end date to the farthest date found
                                        if (currentDate > dates.endDate)
                                            dates.endDate = currentDate;
                                    }
                                    catch (Exception e)
                                    {
                                        DialogResult result = MessageBox.Show(e.Message, "Error reading date: " + currentDateStr,
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                lnStr = lnStr.Substring(commaIndex + 1, lnStr.Length - commaIndex - 1);
                            }
                        }

                        // Then get each of the people for this line
                        while (lnStr.Length > 0)
                        {
                            // Get the first index of a comma
                            int commaIndex = lnStr.IndexOf(',');
                            string currentNameStr = "";

                            if (commaIndex > -1)
                            {
                                // Get the date for this line
                                currentNameStr = lnStr.Substring(0, commaIndex);
                                currentNameStr = currentNameStr.Trim();
                                currentNameStr = currentNameStr.Trim(',');

                                if (currentNameStr.Length > 0)
                                {
                                    personNames.Add(currentNameStr);
                                }

                                lnStr = lnStr.Substring(commaIndex + 1, lnStr.Length - commaIndex - 1);
                            }
                            else
                            {
                                // Else to prevent infinite looping if there's no end comma in the line
                                currentNameStr = lnStr;
                                currentNameStr = currentNameStr.Trim();

                                if (currentNameStr.Length > 0)
                                {
                                    personNames.Add(currentNameStr);
                                }
                                lnStr = "";
                            }
                        }

                        for (int i = 0; i < personNames.Count; i++)
                        {
                            bool wasFound = false;
                            foreach (Person per in pplLst)
                            {
                                if (per.mName == personNames[i])
                                {
                                    //Add the group if they don't already belong in that group
                                    if (!per.mGroups.Contains(groupsLst[i]))
                                        per.mGroups.Add(groupsLst[i]);

                                    // Actually add the date to the existing Person
                                    per.mDutyDays.AddDate(currentDate, groupsLst[i]);
                                    wasFound = true;
                                }
                            }

                            if (!wasFound)
                            {
                                // No Person found with this name
                                // Create a new person with these details
                                Person newPerson = new Person();
                                newPerson.mName = personNames[i];
                                newPerson.mGroups.Add(groupsLst[i]);
                                newPerson.mDutyDays.AddDate(currentDate, groupsLst[i]);

                                pplLst.Add(newPerson);
                            }
                        }

                        //TODO: Add optional email address reading
                    }
                }
                strRead.Close();
            }

            if (pplLst.Count <= 0)
            {
                MessageBox.Show("No people in file " + csvFileName, "Calendar Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return new Tuple<DatesStruct, List<Person>>(dates, pplLst);
        }   // End GetImportFromCsv(string csvFileName)

        /// <summary>
        /// Gets all specified days-of-the-week within a date range (e.g. all Mondays)
        /// </summary>
        /// <param name="startDate">The day to start the list of days (inclusive)</param>
        /// <param name="endDate">The day to end the list of days (inclusive)</param>
        /// <param name="dayToMatch">The day-of-the-week to find</param>
        /// <returns>A list of all days that are dayToMatch (e.g. all Mondays)</returns>
        private List<DateTime> GetDatesForDayOfWeek(DateTime startDate, DateTime endDate, DayOfWeek dayToMatch)
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