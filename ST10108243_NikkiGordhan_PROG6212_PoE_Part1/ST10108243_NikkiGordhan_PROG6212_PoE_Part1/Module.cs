using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10108243_NikkiGordhan_PROG6212_PoE_Part1
{
    class Module
    {
        public string sModule_Code;
        // creates a variable that can be accessed anywhere within the project called sModule_Code that stores the value for Module Code and its data type which is string.
        public string Module_Code
        {
            get { return sModule_Code; }
            set { sModule_Code = value; }
        }
        //getters and setters using automatic properties for Module Code.

        public string sModule_Name;
        // creates a variable that can be accessed anywhere within the project called sModule_Name that stores the value for Module Name and its data type which is string.
        public string Module_Name
        {
            get { return sModule_Name; }
            set { sModule_Name = value; }
        }
        //getters and setters using automatic properties for Module Name.

        public int iNumber_Credits;
        // creates a variable that can be accessed anywhere within the project called iNumber_Creditss that stores the value for the number of Credits and its data type which is int.
        public int Number_Credits
        {
            get { return iNumber_Credits; }
            set { iNumber_Credits = value; }
        }
        //getters and setters using automatic properties for the Number of Credits.

        public int iClass_Hours;
        // creates a variable that can be accessed anywhere within the project called iClass_Hours that stores the value for the amount of Class Hours and its data type which is int.
        public int Class_Hours
        {
            get { return iClass_Hours; }
            set { iClass_Hours = value; }
        }
        //getters and setters using automatic properties for the amount of Class Hours.
    }
    // class that stores information for the Module.
}
