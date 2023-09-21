using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10108243_NikkiGordhan_PROG6212_PoE_Part1
{
    class StudentModuleProgress
    {
        public string sStudent_Number;
        // creates a variable that can be accessed anywhere within the project called sStudent_Number that stores the Number of the student and its data type which is string.
        public string Student_Number
        {
            get { return sStudent_Number; }
            set { sStudent_Number = value; }
        }
        //getters and setters using automatic properties for Student Number.

        public string sSemester_Name;
        // creates a variable that can be accessed anywhere within the project called sSemester_Name that stores the Name of the semester and its data type which is string.
        public string Semester_Name
        {
            get { return sSemester_Name; }
            set { sSemester_Name = value; }
        }
        //getters and setters using automatic properties for Semester Name.

        public string sModule_Code;
        // creates a variable that can be accessed anywhere within the project called sModule_Code that stores the value for Module Code and its data type which is string.
        public string Module_Code
        {
            get { return sModule_Code; }
            set { sModule_Code = value; }
        }
        //getters and setters using automatic properties for Module Code.

        public int iSelf_Study_Hours;
        // creates a variable that can be accessed anywhere within the project called iSelf_Study_Hours that stores the value for Self Study Hours and its data type which is int.
        public int Self_Study_Hours
        {
            get { return iSelf_Study_Hours; }
            set { iSelf_Study_Hours = value; }
        }
        //getters and setters using automatic properties for Self Study Hours.


        public int iRemaining_Hours;
        // creates a variable that can be accessed anywhere within the project called iRemaining_Hours that stores Remaining Hours and its data type which is int.
        public int Remaining_Hours
        {
            get { return iRemaining_Hours; }
            set { iRemaining_Hours = value; }
        }
        //getters and setters using automatic properties for Remaining Hours.

        public int iTotal_Study_Hours;
        // creates a variable that can be accessed anywhere within the project called iTotal_Study_Hours that stores the value for the total study hours and its data type which is int.
        public int Total_Study_Hours
        {
            get { return iTotal_Study_Hours; }
            set { iTotal_Study_Hours = value; }
        }
        //getters and setters using automatic properties for Total Study Hours.

    }
    // class that stores each module a student does and shows them the study progress.
}
