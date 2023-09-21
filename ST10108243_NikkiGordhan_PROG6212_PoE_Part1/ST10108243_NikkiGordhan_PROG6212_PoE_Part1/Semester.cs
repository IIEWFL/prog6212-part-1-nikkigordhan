using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10108243_NikkiGordhan_PROG6212_PoE_Part1
{
    class Semester
    {
        public string sSemester_Name;
        // creates a variable that can be accessed anywhere within the project called sSemester_Name that stores the Name of the semester and its data type which is string.
        public string Semester_Name
        {
            get { return sSemester_Name; }
            set { sSemester_Name = value; }
        }
        //getters and setters using automatic properties for Semester Name.

        public DateOnly dStart_Date;
        // creates a variable that can be accessed anywhere within the project called dStart_Date that stores the starting date of the semester and its data type which is date.
        public DateOnly Start_Date
        {
            get { return dStart_Date; }
            set { dStart_Date = value; }
        }
        //getters and setters using automatic properties for Start Date.

        public int iNo_Weeks;
        // creates a variable that can be accessed anywhere within the project called iNo_Weeks that stores the number of weeks and its data type which is int.
        public int No_Weeks
        {
            get { return iNo_Weeks; }
            set { iNo_Weeks = value; }
        }
        //getters and setters using automatic properties for Number of Weeks.
    }
    // class that stores the information for a semester.
}

