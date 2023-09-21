using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10108243_NikkiGordhan_PROG6212_PoE_Part1
{
    class Validations
    {
        public string Validate_Semester(string sSemester_Name, int iNo_Weeks)
        {
            
            string sSemesterMsg = "";
            if (sSemester_Name == "")
            {
                sSemesterMsg = sSemesterMsg + "Semester Name is invalid.";
            }
            if (iNo_Weeks < 0)
            {
                sSemesterMsg = sSemesterMsg + "Number of Weeks is invalid.";
            }        
            return sSemesterMsg;
        }
        // method that validates the capturing of the Semester details.
        public string Validate_Module(string sModule_Code, string sModule_Name, int iNo_Credits, int iClass_Hours)
        {
            string sModuleMsg = "";
            if(sModule_Code == "")
            {
                sModuleMsg = sModuleMsg + "Module Code is invalid.";
            }
            if(sModule_Name == "")
            {
                sModuleMsg = sModuleMsg + "Module Name is invalid.";
            }
            if (iNo_Credits < 0)
            {
                sModuleMsg = sModuleMsg + "Number of Credits is invalid.";
            }
            if(iClass_Hours < 0)
            {
                sModuleMsg = sModuleMsg + "Number of Class Hours is invalid.";
            }
            return sModuleMsg;
        }
        // method that validates the capturing of the Module details.
        public string Validate_Student (string sStudent_Name,string sStudent_Number)
        {
            string sStudentMsg = "";
            if(sStudent_Name == "")
            {
                sStudentMsg = sStudentMsg + "Student Name is invalid";
            }
            if (sStudent_Number == "")
            {
                sStudentMsg = sStudentMsg + "Student Number is invalid.";
            }
            return sStudentMsg;
        }
        // method that validates the capturing of the Student details.
        public string Validate_Study_Session(int iAllocated_Study_Hours)
        {
            string sStudyMsg = "";
            if(iAllocated_Study_Hours < 0)
            {
                sStudyMsg = sStudyMsg + "Number of Allocated Study Hours is invalid.";
            }
            return sStudyMsg;  
        }
        // metahod that validates the caputring of the Study Sessions details.
    }
    // class that Validates each of the respective objects when saving the object.
}
