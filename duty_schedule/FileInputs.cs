using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Duty_Schedule
{
    class FileInputs
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

        public List<Person> GetGroups(string groupsFileName = "Groups.txt") // Need to add GroupList and NameList to this
        {
            List<Person> pplLst = new List<Person>();

            string fullFileLoc = mDirectory + "\\" + groupsFileName;

            if (File.Exists(fullFileLoc))
            {
                StreamReader strRead = File.OpenText(fullFileLoc);

                string lnStr = "";
                string currGroup = "";

                while ((lnStr = strRead.ReadLine()) != null)
                {
                    if (lnStr.Trim().Length > 0 && !char.IsWhiteSpace(lnStr[0]))
                    {
                        // If it isn't whitespace, it should be a group name

                        // Ignore comments in the file
                        if (lnStr[0] != '/' || lnStr[1] != '/')
                        {
                            currGroup = lnStr.Trim();
                        }

                        // TODO: Search through all groups and add people as needed
                    }
                    else if(lnStr.Trim().Length > 0)
                    {
                        string datesRequestedOff = "";
                        // This should be a person so remove leading/ending whitespace and find where the name ends
                        string personName = lnStr.Trim();
                        int sepIndex = personName.IndexOf('-');

                        // Ignore comments in the file
                        if (personName[0] != '/' || personName[1] != '/') 
                        {
                            // If there is a range of dates requested off
                            if ( sepIndex > -1)
                            {
                                datesRequestedOff = personName.Substring(sepIndex);
                                personName = personName.Substring(0, sepIndex).Trim();

                                // Clean up the dates string
                                datesRequestedOff = datesRequestedOff.Trim('-').Trim();
                                List<DateTime> dateList = new List<DateTime>();

                                int commaIndex = datesRequestedOff.IndexOf(',');
                                while(commaIndex > -1)
                                {
                                    // Peel away the first date in the string and add it to the DateTime list
                                    string tempDateStr = datesRequestedOff.Substring(0, commaIndex).Trim(',').Trim();
                                    datesRequestedOff = datesRequestedOff.Substring(commaIndex).Trim(',').Trim(); 
                                    
                                    if (tempDateStr.Length > 0)
                                        dateList.Add(DateTime.Parse(tempDateStr));

                                    commaIndex = datesRequestedOff.IndexOf(',');
                                }
                                // Handle the last date in the string
                                if (datesRequestedOff.Length > 0)
                                    dateList.Add(DateTime.Parse(datesRequestedOff));
                                
                                // Actually add the person
                                bool foundPerson = false;
                                foreach (Person per in pplLst)
                                {
                                    if (per.mName == personName)
                                    {
                                        foundPerson = true;
                                        //If they aren't in this group already
                                        if(!per.mGroups.Contains(currGroup))
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
                                    pplLst.Add(new Person(personName, currGroup, new List<DateTime>() ) );
                            }

                        }

                    }



                }

                //DateTime dt = dt.

            }

            return pplLst;
        }

    }
}
