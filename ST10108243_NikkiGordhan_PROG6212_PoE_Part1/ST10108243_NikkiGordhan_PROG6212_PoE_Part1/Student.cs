using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10108243_NikkiGordhan_PROG6212_PoE_Part1
{
    class Student
    {
        public string sStudenet_Number;
        // creates a variable that can be accessed anywhere within the project called sStudenet_Number that stores the student number and its data type which is string.
        public string Student_Number
        {
            get { return sStudenet_Number; }
            set { sStudenet_Number = value; }
        }
        //getters and setters using automatic properties for Student Number.

        public string sStudenet_Name;
        // creates a variable that can be accessed anywhere within the project called sStudenet_Name that stores the Name of the student and its data type which is string.
        public string Student_Name
        {
            get { return sStudenet_Number; }
            set { sStudenet_Number = value; }
        }
        //getters and setters using automatic properties for Student Name.

        public string sSemester_Name;
        // creates a variable that can be accessed anywhere within the project called sSemester_Name that stores the Name of the semester and its data type which is string.
        public string Semester_Name
        {
            get { return sSemester_Name; }
            set { sSemester_Name = value; }
        }
        //getters and setters using automatic properties for Semester Name.

    }
    // class that stores the student details
}
