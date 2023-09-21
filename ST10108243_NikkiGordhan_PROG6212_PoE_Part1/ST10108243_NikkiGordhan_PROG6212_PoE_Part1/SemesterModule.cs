using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Self_Study_Hours;

namespace ST10108243_NikkiGordhan_PROG6212_PoE_Part1
{
    class SemesterModule
    {
        public string sModule_Code;
        // creates a variable that can be accessed anywhere within the project called sModule_Code that stores the value for Module Code and its data type which is string.
        public string Module_Code
        {
            get { return sModule_Code; }
            set { sModule_Code = value; }
        }
        //getters and setters using automatic properties for Module Code.

        public string sSemester_Name;
        // creates a variable that can be accessed anywhere within the project called sSemester_Name that stores the Name of the semester and its data type which is string.
        public string Semester_Name
        {
            get { return sSemester_Name; }
            set { sSemester_Name = value; }
        }
        //getters and setters using automatic properties for Semester Name.

        public int iSelf_Study_Hours;
        // creates a variable that can be accessed anywhere within the project called iSelf_Study_Hours that stores the value for Self Study Hours and its data type which is int.
        public int Self_Study_Hours
        {
            get { return iSelf_Study_Hours; }
            set { iSelf_Study_Hours = value; }
        }
        //getters and setters using automatic properties for Self Study Hours.
    }
    // calss that stores all the modules in a semester.
}
