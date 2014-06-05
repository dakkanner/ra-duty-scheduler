using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duty_Schedule
{
    class DatesAndAssignments
    {
        public struct PersonAndGroup
        {
            public Person person;
            public string group;
        };


        public List<DateTime> mDateList;
        public List<List<PersonAndGroup>> mPeopleList;

        public DatesAndAssignments()
        {
            mDateList = new List<DateTime>();
            mPeopleList = new List<List<PersonAndGroup>>();
        }

        public void AddDayAndAssignment(DateTime dt, Person prs, string grp)
        {
            int index = mDateList.IndexOf(dt);

            if (index == -1)
            {
                mDateList.Add(dt);

                // Not going to be an entry for this date either
                PersonAndGroup pg = new PersonAndGroup();
                pg.person = prs;
                pg.group = grp;

                List<PersonAndGroup> pgl = new List<PersonAndGroup>();

                pgl.Add(pg);

                mPeopleList.Add(pgl);
            }
            else
            {

                PersonAndGroup pg = new PersonAndGroup();
                pg.person = prs;
                pg.group = grp;
                
                if( !mPeopleList[index].Contains(pg) )
                    mPeopleList[index].Add(pg);
            }
        }





    }
}
