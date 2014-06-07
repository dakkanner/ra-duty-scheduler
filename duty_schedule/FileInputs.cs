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

        public bool GetGroups(string groupsFileName = "Groups.txt") // Need to add GroupList and NameList to this
        {
            bool foundGroups = true;
            List<Person> pplLst;

            string fullFileLoc = mDirectory + "\\" + groupsFileName;

            if (File.Exists(fullFileLoc))
            {
                StreamReader strRead = File.OpenText(fullFileLoc);

                string lnStr = "";
                string currGroup;

                while ((lnStr = strRead.ReadLine()) != null)
                {
                    // If it isn't whitespace, it should be a groupname
                    if( !char.IsWhiteSpace(lnStr[0]) )
                    {
                        // Ignore comments in the file
                        if (lnStr[0] != '/' || lnStr[1] != '/')
                        {
                            currGroup = lnStr.Trim();
                        }

                        // TODO: Search through all groups and add people as needed
                    }
                    else
                    {
                        if(lnStr[0] != '/' || lnStr[1] != '/')
                        {


                        }

                    }



                }

                //DateTime dt = dt.

            }
            else 
            {
                foundGroups = false;
            }

            return foundGroups;
        }

    }
}
