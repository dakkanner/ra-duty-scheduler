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
    public class DatesAndAssignments
    {
        public struct PersonAndGroup
        {
            public Person person;
            public string group;
        };

        // Public members because I'm lazy. 
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
