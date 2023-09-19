using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// library that stores the self-study calculation.
// is a class that calculates the self study hours.

namespace Self_Study_Hours
{
    public class Self_Study_Hours
    {
        public int iCredits;
        // creates a variable that can be accessed anywhere within the project called iCredits that stores the value for Credits and its data type which is int.
        public int Credits
        {
            get { return iCredits; }
            set { iCredits = value; }
        }
        //getters and setters using automatic properties for Credits.

        public int iNo_Weeks;
        // creates a variable that can be accessed anywhere within the project called iNo_Weeks that stores the value for the number of weeks and its data type which is int.
        public int No_Weeks
        {
            get { return iNo_Weeks; }
            set { iNo_Weeks = value; }
        }
        //getters and setters using automatic properties for No_Weeks.

        public int iClass_Hours_Per_Week;
        // creates a variable that can be accessed anywhere within the project called iClass_Hours_Per_Week that stores the value for the hours spent studying in class and its data type which is int.
        public int Class_Hours_Per_Week
        {
            get { return iClass_Hours_Per_Week; }
            set { iClass_Hours_Per_Week = value; }
        }
        //getters and setters using automatic properties for Class_Hours_Per_Week.

        public int iHours_Self_Studying;
        // creates a variable that can be accessed anywhere within the project called iSelf_Study_Hours that stores the value of spent self studying and its data type which is int.
        public int Hours_Self_Studying
        {
            get { return iHours_Self_Studying; }
            set { iHours_Self_Studying = value; }
        }
        //getters and setters using automatic properties for Self_Study_Hours.
    
        public int Calculate_Self_Studying_Hours(int iCredits, int iNo_Weeks, int iClass_Hours_Per_Week)
        {
            iHours_Self_Studying = ((iCredits * 10) / iNo_Weeks) - iClass_Hours_Per_Week;
            // calculates the hours spent self studying.
            return iHours_Self_Studying;
            //returns the value of iHours_Self_Studying.
        }
        // method to store the self studying hours.
    }

}




