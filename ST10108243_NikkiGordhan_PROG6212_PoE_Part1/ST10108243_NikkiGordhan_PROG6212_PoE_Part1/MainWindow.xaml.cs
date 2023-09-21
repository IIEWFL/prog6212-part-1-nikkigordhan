using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Self_Study_Hours;
using System.Xml.Linq;
using Self_Study_Hours;


namespace ST10108243_NikkiGordhan_PROG6212_PoE_Part1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Self_Study_Hours.Self_Study_Hours oSelf_Study_Hours = new Self_Study_Hours.Self_Study_Hours();
        //creates a object that is from the custom libray.

        Validations oValidations = new Validations();
        // creates a validations object.

        List<Semester> loSemester = new List<Semester>();
        // creates a List of type Semester.

        List<Module> loModule = new List<Module>();
        // creates a List of type Module.

        List<Student> loStudent = new List<Student>();
        // creates a List of type Student.

        List<SemesterModule> loSemesterModule = new List<SemesterModule>();
        // creates a List of type SemesterModule.

        List<Study_Sessions> loStudy_Sessions = new List<Study_Sessions>();
        // creates a List of type Study_Seesions.

        List<StudentModuleProgress> loStudentModduleProgress = new List<StudentModuleProgress>();
        // creates a List of type StudentModuleProgress.

        int igTotal_Allocated_Hours = 0;
        int iSelectedTab = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ClearCaptureSemesterTab()
        {
            txtSemester_Name.Clear();
            txtNo_Weeks.Clear();
            // clears the textboxes.

        }
        // clears the Capture Semester Tab.
        public void ClearModuleTab()
        {
            txtModule_Code.Clear();
            txtModule_Name.Clear();
            txtNo_Credits.Clear();
            txtClass_Hours.Clear();
            // clears each of the textboxes.

        }
        // clears the Capture Module Tab.
        public void ClearStudentTab()
        {
            txtStudent_Name.Clear();
            txtStudent_Number.Clear();
            // the code above was taken and adapted from StackOverflow.
            // https://stackoverflow.com/questions/19362911/clear-a-combobox-in-wpf
            // user:2631662
            // https://stackoverflow.com/users/2631662/user2631662
            this.drpSelect_Semester.SelectedItem = null;
            //clears the combobox.
        }
        // clears the New Student Tab.
        public void Populate_Lists_ComboBox(int iTabSelected)
        {
            if (iTabSelected > 0 && iSelectedTab != iTabSelected)
            {
                iSelectedTab = iTabSelected;
                List_Of_Semesters.Items.Clear(); // clears the list
                ClearCaptureSemesterTab(); // clears the Tab.
                for (int i = 0; i < loSemester.Count; i++)
                {
                    List_Of_Semesters.Items.Add(new { Semester_Name = loSemester[i].Semester_Name, No_Weeks = loSemester[i].No_Weeks, Start_Date = loSemester[i].Start_Date });
                    //adds the Semester details to the listbox.
                }

                List_Of_Modules.Items.Clear(); // clears the list
                ClearModuleTab();// clears the Tab.
                for (int i = 0; i < loModule.Count; i++)
                {
                    List_Of_Modules.Items.Add(new { Module_Name = loModule[i].Module_Name, Module_Code = loModule[i].Module_Code, Number_Credits = loModule[i].Number_Credits, Class_Hours = loModule[i].Class_Hours });
                    //adds the Module details to the listbox.
                }

                List_Of_Students.Items.Clear();
                ClearStudentTab();
                Populate_Semester_Combobox_In_Student_Tab();
                for (int i = 0; i < loStudent.Count; i++)
                {
                    List_Of_Students.Items.Add(new { Student_Name = loStudent[i].Student_Name, Student_Number = loStudent[i].Student_Number, Semester_Name = loStudent[i].Semester_Name });
                    //adds the Student details to the listbox.
                }

                //if (iTabSelected == 4)
                //{
                Populate_Semester_Combobox_In_Add_Module_To_Semester_Tab();
                listUnassigned_Modules.Items.Clear(); // clears the listbox when the tab is loaded.
                listAssigned_Modules.Items.Clear();
                drpSelect_a_Semester.SelectedItem = null;
                //for (int i = 0; i < loModule.Count; i++)
                //{
                //    listUnassigned_Modules.Items.Add(new { Module_Code = loModule[i].Module_Code });
                //}
                //}

                if (iTabSelected == 5)
                {
                    Populate_Combobox_In_Study_Session_Tab();
                }
            }


        }
        // clears all the listboxes and textboxes when the system loads.
        public void Populate_Semester_Combobox_In_Student_Tab()
        {
            drpSelect_Semester.Items.Clear();
            for (int i = 0; i < loSemester.Count; i++)
            {
                drpSelect_Semester.Items.Add(loSemester[i].Semester_Name);
            }
        }
        // populates the combobox from the Semester List.
        public void Populate_Semester_Combobox_In_Add_Module_To_Semester_Tab()
        {
            drpSelect_a_Semester.Items.Clear();
            for (int i = 0; i < loSemester.Count; i++)
            {
                drpSelect_a_Semester.Items.Add(loSemester[i].Semester_Name);
            }
        }
        // populates the combobox from the Semester List.
        public void Populate_Combobox_In_Study_Session_Tab()
        {
            igTotal_Allocated_Hours = 0;

            drpName_Of_Semester.Items.Clear();
            for (int i = 0; i < loSemester.Count; i++)
            {
                drpName_Of_Semester.Items.Add(loSemester[i].Semester_Name);
            }
            drpModule_Code.Items.Clear();
            drpStudent_Number.Items.Clear();
            for (int i = 0; i < loStudent.Count;  i++)
            {
                drpStudent_Number.Items.Add(loStudent[i].Student_Number);
            }

        }
        // populates the combobox from the Semester List and Module List.
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        // closes the application.
        private void btnSave_Semester_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tCapture_Semester.IsSelected) // only if the Capture Semester Tab is selcted do the following
                {
                    //get the values from the texbox and validate then populate the class.
                    string sMsg = "";
                    string sSemester_Name = txtSemester_Name.Text;
                    //assigns the value from txtSemester_Name to the variable sSemester_Name.
                    string sNo_Weeks = txtNo_Weeks.Text;
                    //assigns the value from txtNo_Weeks to the variable sNo_Weeks.
                    string sStudy_Date = dtpStarting_Date.Text;
                    //assigns the value from dtpStarting_Date to the variable sStudy_Date.
                    int iNo_Weeks = 0;

                    // the code below was taken and adapted from StackOverflow.
                    // https://stackoverflow.com/questions/6121271/how-to-remove-time-portion-of-date-in-c-sharp-in-datetime-object-only
                    // MehraD
                    // https://stackoverflow.com/users/3048506/mehrad

                    DateOnly dStart_Date = DateOnly.Parse(DateAndTime.Now.Date.ToShortDateString());
                    // sets the dStartDate to the current date.


                    Boolean bValid = false;

                    try
                    {
                        bValid = true;
                        iNo_Weeks = int.Parse(txtNo_Weeks.Text);
                    }
                    catch
                    {
                        bValid = false;
                        sMsg = sMsg + "Please enter a valid number of week." + '\n';
                    }
                    // checks to see that the value is of type int.

                    try
                    {
                        bValid = true;
                        dStart_Date = DateOnly.Parse(dtpStarting_Date.Text);
                    }
                    catch
                    {
                        bValid = false;
                        sMsg = sMsg + "Please enter a valid Study Date" + '\n';
                    }
                    // checks to see that the value is of type DateOnly.

                    sMsg = sMsg + oValidations.Validate_Semester(sSemester_Name, iNo_Weeks);
                    // calls the Validate_Semsester method. 

                    if (sMsg == "" && bValid == true)
                    {
                        loSemester.Add(new Semester() { Semester_Name = sSemester_Name, No_Weeks = iNo_Weeks, Start_Date = dStart_Date });
                        //adds to the Semester List.

                        List_Of_Semesters.Items.Add(new { Semester_Name = sSemester_Name, No_Weeks = iNo_Weeks, Start_Date = dStart_Date });
                        //adds the Semester details to the listbox.
                    }
                    else
                    {
                        MessageBox.Show(sMsg);
                    }

                }

                ClearCaptureSemesterTab();

            }
            catch
            {
                MessageBox.Show("Error occured saving Semester details.");
            }

        }
        // saves the Semester details.
        private void btnCancel_Semester_Click(object sender, RoutedEventArgs e)
        {
            ClearCaptureSemesterTab();
        }
        // cancels the Semester details.
        private void btnCancel_Module_Click(object sender, RoutedEventArgs e)
        {
            ClearModuleTab();
        }
        // cancels the Module details.
        private void btnSave_Module_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tCapture_Module.IsSelected) // only if the Capture Module Tab is selcted do the following
                {
                    //get the values from the textbox and validate then populate the class.

                    string sModule_Code = txtModule_Code.Text;
                    //assigns the value from txtModule_Code to the variable sModule_Code.
                    string sModule_Name = txtModule_Name.Text;
                    //assigns the value from txtModule_Name to the variable sModule_Name.
                    string sNo_Credits = txtNo_Credits.Text;
                    //assigns the value from txtNo_Credits to the variable sNo_Credits.
                    string sClass_Hours = txtClass_Hours.Text;
                    //assigns the value from txtClass_Hours to the variable sClass_Hours.

                    int iNo_Credits = 0;
                    int iClass_Hours = 0;

                    try
                    {
                        iNo_Credits = int.Parse(txtNo_Credits.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Please enter a valid number of credits.");
                    }
                    // checks to see that the value is of type int.
                    try
                    {
                        iClass_Hours = int.Parse(txtClass_Hours.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Please enter a valid number of class hours.");
                    }
                    // checks to see that the value is of type int.

                    string sMsg = oValidations.Validate_Module(sModule_Code, sModule_Name, iNo_Credits, iClass_Hours);
                    // calls the Validate_Module method.

                    if (sMsg == "")
                    {
                        loModule.Add(new Module() { Module_Code = sModule_Code, Module_Name = sModule_Name, Number_Credits = iNo_Credits, Class_Hours = iClass_Hours });
                        // adds to the Module list.

                        List_Of_Modules.Items.Add(new { Module_Code = sModule_Code, Module_Name = sModule_Name, Number_Credits = iNo_Credits, Class_Hours = iClass_Hours });
                        // adds the Module details to the listbox.

                    }
                    else
                    {
                        MessageBox.Show(sMsg);
                    }

                }
                ClearModuleTab();
            }
            catch
            {
                MessageBox.Show("Error occured saving Module details.");
            }
        }
        // saves the Module details.
        private void btnCancel_Student_Click(object sender, RoutedEventArgs e)
        {
            ClearStudentTab();
        }
        // cancels the Student details.
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabMenu != null)
            {
                Populate_Lists_ComboBox(TabMenu.SelectedIndex);

            }
        }
        // populates the lstboxes when the tab is changed.
        private void btnCancel_Student_Click_1(object sender, RoutedEventArgs e)
        {
            ClearStudentTab();
            // the code above was taken and adapted from StackOverflow.
            // https://stackoverflow.com/questions/19362911/clear-a-combobox-in-wpf
            // user:2631662
            // https://stackoverflow.com/users/2631662/user2631662
            this.drpSelect_Semester.SelectedItem = null;
            //clears the combobox.

        }
        // cancels the Student details.
        private void btnSave_Student_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tNew_Student.IsSelected) // only if the New Student Tab is selcted do the following
                {
                    //get the values from the textbox and validate then populate the class.

                    string sStudent_Name = txtStudent_Name.Text;
                    //assigns the value from txtStudent_Name to the variable sStudent_Number.
                    string sStudent_Number = txtStudent_Number.Text;
                    //assigns the value from txtStudent_Number to the variable sStudent_Number.
                    string sSemester_Name = drpSelect_Semester.Text;
                    //assigns the value from drpSelect_Semester to the variable sSemester_Name.

                    string sMsg = oValidations.Validate_Student(sStudent_Name, sStudent_Number);
                    // calls the Validate_Student method.

                    if (sMsg == "")
                    {
                        loStudent.Add(new Student() { Student_Name = sStudent_Name, Student_Number = sStudent_Number, Semester_Name = sSemester_Name });
                        // adds to the Student list.

                        List_Of_Students.Items.Add(new { Student_Name = sStudent_Name, Student_Number = sStudent_Number, Semester_Name = sSemester_Name });
                        // adds the Student details to the listbox.

                    }
                    else
                    {
                        MessageBox.Show(sMsg);
                    }

                }
                ClearStudentTab();

            }
            catch
            {
                MessageBox.Show("Error occured saving Module details.");
            }
        }
        // saves the student details.
        private void btnMove_to_Assigned_Click(object sender, RoutedEventArgs e)
        {
            Move_Selected_Item_To_AssignedModule(listUnassigned_Modules, listAssigned_Modules);
            // calls the method to move the Module to Assigned.
        }
        // moves the Module to Assigned when the button is pressed.
        public void Move_Selected_Item_To_AssignedModule(ListView listUnassigned_Modules, ListView listAssigned_Modules)
        {
            if (listUnassigned_Modules.SelectedItems.Count > 0)
            {

                string sModule;
                string sSemester;

                sSemester = drpSelect_a_Semester.SelectedItem.ToString();
                // brings the Semester.

                sModule = listUnassigned_Modules.SelectedValue.GetType().GetProperty("Module_Code").GetValue(listUnassigned_Modules.SelectedValue, null).ToString();

                // the code below was taken and adapted from StackOverflow.
                // https://stackoverflow.com/questions/6359980/proper-linq-where-clauses
                // A.R.
                // https://stackoverflow.com/users/472614/a-r

                var vNoWeeks = (from s in loSemester where s.Semester_Name == sSemester select s.No_Weeks);
                int iNoWeeks = (int)vNoWeeks.FirstOrDefault();
                // uses linq to get the no of weeks in the selected semester.

                var vClassHour = (from m in loModule where m.Module_Code == sModule select m.Class_Hours);
                int iClassHours = (int)vClassHour.FirstOrDefault();

                var vCredits = (from n in loModule where n.Module_Code == sModule select n.Number_Credits);
                int iCredits = (int)vCredits.FirstOrDefault();

                int iSelf_Study_Hours = oSelf_Study_Hours.Calculate_Self_Studying_Hours(iCredits, iNoWeeks, iClassHours);

                int iSelectedIndex = listUnassigned_Modules.SelectedIndex;
                // the code belove was taken and adapted from StackOverflow.
                // https://stackoverflow.com/questions/57679316/move-selected-items-from-listview-to-another-one
                // Hamza
                // https://stackoverflow.com/users/7702066/hamza
                listAssigned_Modules.Items.Add(new { Module_Code = sModule, Self_Study_Hours = iSelf_Study_Hours.ToString() });
                listUnassigned_Modules.Items.Remove(listUnassigned_Modules.SelectedItem);

            }

        }
        // moves the Module to the Assigned ListView.
        public void Move_Selected_Item_To_UnassignedModule(ListView listUnassigned_Modules, ListView listAssigned_Modules)
        {
            if (listAssigned_Modules.SelectedItems.Count > 0)
            {
                int iSelectedIndex = listAssigned_Modules.SelectedIndex;
                // the code belove was taken and adapted from StackOverflow.
                // https://stackoverflow.com/questions/57679316/move-selected-items-from-listview-to-another-one
                // Hamza
                // https://stackoverflow.com/users/7702066/hamza
                listUnassigned_Modules.Items.Add(listAssigned_Modules.SelectedItem);
                listAssigned_Modules.Items.Remove(listAssigned_Modules.SelectedItem);
            }
        }
        // moves the Module to the Unassigned ListView.
        private void btnMove_to_Unassigned_Click(object sender, RoutedEventArgs e)
        {
            Move_Selected_Item_To_UnassignedModule(listUnassigned_Modules, listAssigned_Modules);
            // calls the method to move the Module to Unassigned.
        }
        //moves the Module to the Unassighned ListView.

        public int Total_Study_Hours(int iStudy_Hours)
        {
            int iTotalHours = 0;

            iTotalHours = iTotalHours + iStudy_Hours;
            return iTotalHours;
        }
        // gets the total hours of studying.

        public int Display_Remaining_Hours(int iSelf_Study_Hours, int iTotal_Study_Hours)
        {
            int iRemaining_hours = 0;
            if (iSelf_Study_Hours > 0 && iTotal_Study_Hours > 0)
            {
                iRemaining_hours = iSelf_Study_Hours - iTotal_Study_Hours;
            }
            return iRemaining_hours;
        }

        private void btnSave_Study_Session_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tStudy_Sessions.IsSelected) // only if the Capture Semester Tab is selcted do the following
                {
                    //get the values from the texbox and validate then populate the class.
                    string sStudent_Number = "";
                    string sSemester_Name = "";
                    string sModule_Code = "";
                    string sAllocated_Study_Hours = txtAllocated_Study_Hours.Text;
                    // assigns the value of txtAllocated_Study_Hours to the variable sAllocated_Study_Hours.
                    int iAllocated_Study_Hours = int.Parse(sAllocated_Study_Hours);
                    int iStudy_Hours = iAllocated_Study_Hours;

                    // the code below was taken and adapted from GeekForGeeks.
                    // https://www.geeksforgeeks.org/how-to-set-text-on-the-label-in-c-sharp/
                    string sSelf_Study_Hours = lHours_of_Self_Study.Content.ToString();
                    int iSelf_Study_Hours = int.Parse(sSelf_Study_Hours);



                    

                    // the code below was taken and adapted from GeekForGeeks.
                    // https://www.geeksforgeeks.org/how-to-set-text-on-the-label-in-c-sharp/
                    string sRemaining_Hours = lHours_Remaining.Content.ToString();
                    int iRemaining_Hours = int.Parse(sRemaining_Hours);

                   // var vRemaining_Hours = (from smp loSemesterModuleProgress where )

                    iRemaining_Hours = Calculate_Remaining_Hours(iSelf_Study_Hours, igTotal_Allocated_Hours);

                    

                    // the code below was taken and adapted from StackOverflow.
                    // https://stackoverflow.com/questions/6121271/how-to-remove-time-portion-of-date-in-c-sharp-in-datetime-object-only
                    // MehraD
                    // https://stackoverflow.com/users/3048506/mehrad

                    DateOnly dStudyDate = DateOnly.Parse(DateAndTime.Now.Date.ToShortDateString());
                    // sets the dStudyDate to the current date.

                    try
                    {
                        // the code below was taken and adapted from  Stackoverflow.
                        //https://stackoverflow.com/questions/5687889/how-to-check-if-item-is-selected-from-a-combobox-in-c-sharp
                        // Joe Carter
                        //https://stackoverflow.com/users/11883965/joe-carter

                        if (drpStudent_Number.SelectedItem != null)
                        {
                            sStudent_Number = drpStudent_Number.Text;
                            //assigns the value from drpStudents_Name to the variable sStudent_Number.
                        }
                        else
                        {
                            MessageBox.Show("Please select a Student Number.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please select a vaild Student Number.");
                    }
                    // checks that the user has selected a Student name.

                    try
                    {
                        // the code below was taken and adapted from  Stackoverflow.
                        //https://stackoverflow.com/questions/5687889/how-to-check-if-item-is-selected-from-a-combobox-in-c-sharp
                        // Joe Carter
                        //https://stackoverflow.com/users/11883965/joe-carter

                        if (drpName_Of_Semester.SelectedItem != null)
                        {
                            sSemester_Name = drpName_Of_Semester.Text;
                            //assigns the value from drpName_Of_Semester to the variable sSemester_Name.
                        }
                        else
                        {
                            MessageBox.Show("Please select a Semester.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please select a vaild Semester name.");
                    }
                    // checks that the user has selected a semester.

                    try
                    {
                        // the code below was taken and adapted from  Stackoverflow.
                        //https://stackoverflow.com/questions/5687889/how-to-check-if-item-is-selected-from-a-combobox-in-c-sharp
                        // Joe Carter
                        //https://stackoverflow.com/users/11883965/joe-carter

                        if (drpModule_Code.SelectedItem != null)
                        {
                            sModule_Code = drpModule_Code.Text;
                            // assigns the value from drpModule_Code to the variable sModule_Code.
                        }
                        else
                        {
                            MessageBox.Show("Please select a Module.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please select a vaild Module Code.");
                    }
                    // checks thta the user has selected a module code.

                    try
                    {
                        if (iAllocated_Study_Hours > 0)
                        {
                            iAllocated_Study_Hours = int.Parse(txtAllocated_Study_Hours.Text);
                        }
                        else
                        {
                            MessageBox.Show("Please enter an Allocated amount of Study Hours.");
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Please enter a valid Number of Allocated Study Hours.");
                    }
                    // checks to see that the value is of type int.

                    try
                    {
                        dStudyDate = DateOnly.Parse(dStudy_Date.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Please enter a valid Study Date.");
                    }
                    // checks to see that the value is of type DateOnly.



                    string sMsg = oValidations.Validate_Study_Session(iAllocated_Study_Hours);
                    //calls the Validate_Study_Session method.

                    int iTotal_Study_Hours = 0;
                    if (sMsg == "")
                    {
                        //***********PART ONE ***********do processing for the Study sessions here 
                        

                        loStudy_Sessions.Add(new Study_Sessions { Semester_Name = sSemester_Name, Module_Code = sModule_Code, Allocated_Study_Hours = iAllocated_Study_Hours, Self_Study_Hours = iSelf_Study_Hours, Study_Hours = iStudy_Hours });
                        //adds to the StudySessions calss.

                        List_Of_Study_Sessions.Items.Add(new { Student_Number = sStudent_Number, Semester_Name = sSemester_Name, Module_Code = sModule_Code, Study_Date = dStudyDate, Self_Study_Hours = iSelf_Study_Hours, Study_Hours = iStudy_Hours });
                        //adds the SemesterModule details to the listbox.



                        //***********PART TWO ***********do processing for the Student Module Progress here 

                        //Check to see if b tist items already exists 

                        

                        if (loStudentModduleProgress.Count == 0)
                        {
                            iTotal_Study_Hours = iTotal_Study_Hours + iStudy_Hours;
                            iRemaining_Hours = iSelf_Study_Hours - iTotal_Study_Hours;
                            loStudentModduleProgress.Add(new StudentModuleProgress { Student_Number = sStudent_Number, Semester_Name = sSemester_Name, Module_Code = sModule_Code, Self_Study_Hours = iSelf_Study_Hours, Remaining_Hours = iRemaining_Hours, Total_Study_Hours = iTotal_Study_Hours });
                        }
                        else
                        {

                     

                            foreach (var itmes in loStudentModduleProgress)
                            {
                                if (itmes != null)
                                {
                                    if (itmes.Student_Number == sStudent_Number && itmes.Semester_Name == sSemester_Name && itmes.Module_Code == sModule_Code)
                                    {
                                        var vSMP_Remaining_Hours = (from smp in loStudentModduleProgress where smp.Student_Number == sStudent_Number && smp.Semester_Name == sSemester_Name && smp.Module_Code == sModule_Code select smp.Remaining_Hours);
                                        iRemaining_Hours = (int)vSMP_Remaining_Hours.FirstOrDefault();

                                        var vSMP_Total_Study_Hours = (from smp in loStudentModduleProgress where smp.Student_Number == sStudent_Number && smp.Semester_Name == sSemester_Name && smp.Module_Code == sModule_Code select smp.Total_Study_Hours);
                                        iTotal_Study_Hours = (int)vSMP_Total_Study_Hours.FirstOrDefault();

                                       

                                        iTotal_Study_Hours = iTotal_Study_Hours + iStudy_Hours;
                                        iRemaining_Hours = iSelf_Study_Hours - iTotal_Study_Hours;

                                        itmes.Total_Study_Hours = iTotal_Study_Hours;
                                        itmes.Remaining_Hours = iRemaining_Hours;
                                        break;
                                        
                                    }
                                    else
                                    {
                                        iTotal_Study_Hours = iTotal_Study_Hours + iStudy_Hours;
                                        iRemaining_Hours = iSelf_Study_Hours - iTotal_Study_Hours;
                                        loStudentModduleProgress.Add(new StudentModuleProgress { Student_Number = sStudent_Number, Semester_Name = sSemester_Name, Module_Code = sModule_Code, Self_Study_Hours = iSelf_Study_Hours, Remaining_Hours = iRemaining_Hours, Total_Study_Hours = iTotal_Study_Hours });
                                        break;
                                    }
                                }
                                
                            }

                        }
                       

                         List_Module_Progress.Items.Clear();
                        foreach (var item in loStudentModduleProgress)
                        {
                            List_Module_Progress.Items.Add(new StudentModuleProgress { Student_Number = item.sStudent_Number, Semester_Name = item.sSemester_Name, Module_Code = item.sModule_Code, Self_Study_Hours = item.iSelf_Study_Hours, Remaining_Hours = item.iRemaining_Hours, Total_Study_Hours = item.iTotal_Study_Hours });
                        }

                       

                    }

                    Clear_Study_Session();

                }
            }
            catch (Exception ex)    
            {
                MessageBox.Show("Error occured saving Study Session details.");
            }
        }
        public int Calculate_Remaining_Hours(int iSelf_Study_Hours, int igTotal_Allocated_Hours)
        {
            int iRemaining_hours = 0;
            if (iSelf_Study_Hours > 0 )
            {
                iRemaining_hours = iSelf_Study_Hours - igTotal_Allocated_Hours;

               
            }
            return iRemaining_hours;
        }
        // calculates the remaining hours.
        public string Populate_Remaining_Hours()
        {
            string sSemester = "";
            string sModule = "";
            

            sSemester = drpName_Of_Semester.Text;
            sModule = drpModule_Code.Text;
            int iRemaining_Hours = 0;
            int iAllocated_Study_Hours = int.Parse(txtAllocated_Study_Hours.Text);
            // the code below was taken and adapted from GeekForGeeks.
            // https://www.geeksforgeeks.org/how-to-set-text-on-the-label-in-c-sharp/
            string sSelf_Study_Hours = lHours_of_Self_Study.Content.ToString();
            int iSelf_Study_Hours = int.Parse(sSelf_Study_Hours);

            if (sSemester != "" && sModule != "")
            {
                
                iRemaining_Hours = Calculate_Remaining_Hours(iSelf_Study_Hours, igTotal_Allocated_Hours);

                // the code below was taken and adapted from GeekForGeeks.
                // https://www.geeksforgeeks.org/how-to-set-text-on-the-label-in-c-sharp/
                lHours_Remaining.Content = igTotal_Allocated_Hours;
                string sRemaining_Hours = iRemaining_Hours.ToString();


                return sRemaining_Hours;


            }
            else
            {
                return "0";
            }
        }
        // method that populates the Remaining Hour label.
        public string Populate_Self_Study()
        {

            string sSemester = "";
            string sModule = "";

            sSemester = drpName_Of_Semester.Text;
            sModule = drpModule_Code.Text;

            if (sSemester != "" && sModule != "")
            {


                var vSelf_Study_Hours = (from sm in loSemesterModule where sm.Module_Code == sModule && sm.Semester_Name == sSemester select sm.iSelf_Study_Hours);
                int iSelf_Study_Hours = (int)vSelf_Study_Hours.FirstOrDefault();

                return iSelf_Study_Hours.ToString();
            }
            else
            {
                return "0";
            }


        }
        // method that populates the Self Study Hours label.



        private void drpModule_Code_LostFocus(object sender, RoutedEventArgs e)
        {
            // the code below was taken and adapted from GeekForGeeks.
            // https://www.geeksforgeeks.org/how-to-set-text-on-the-label-in-c-sharp/
            lHours_of_Self_Study.Content = Populate_Self_Study();
        }
        // populates the label.
        private void txtAllocated_Study_Hours_LostFocus(object sender, RoutedEventArgs e)
        {
            igTotal_Allocated_Hours = igTotal_Allocated_Hours + int.Parse(txtAllocated_Study_Hours.Text);

            // the code below was taken and adapted from GeekForGeeks.
            // https://www.geeksforgeeks.org/how-to-set-text-on-the-label-in-c-sharp/
            lHours_Remaining.Content = Populate_Remaining_Hours();
        }


        public void Clear_Study_Session()
        {
            // the code above was taken and adapted from StackOverflow.
            // https://stackoverflow.com/questions/19362911/clear-a-combobox-in-wpf
            // user:2631662
            // https://stackoverflow.com/users/2631662/user2631662
            this.drpName_Of_Semester.SelectedItem = null;
            this.drpModule_Code.SelectedItem = null;
            this.drpStudent_Number.SelectedItem = null;
            // clears both comboboxes.

            txtAllocated_Study_Hours.Clear();
            //clears the textbox.

            // the code below was taken and adapted from GeekForGeeks.
            // https://www.geeksforgeeks.org/how-to-set-text-on-the-label-in-c-sharp/
            lHours_of_Self_Study.Content = "";
            lHours_Remaining.Content = "";
        }


        private void btnCancel_Study_Session_Click(object sender, RoutedEventArgs e)
        {

            Clear_Study_Session();

        }

        private void btnSave_Module_to_Semester_Click(object sender, RoutedEventArgs e)
        {
            string sSemester_Name = "";
            string sModule = "";
            string sSelf_Study_Hours = "0";

            try
            {
                // the code below was taken and adapted from  Stackoverflow.
                //https://stackoverflow.com/questions/5687889/how-to-check-if-item-is-selected-from-a-combobox-in-c-sharp
                // Joe Carter
                //https://stackoverflow.com/users/11883965/joe-carter

                if (drpSelect_a_Semester.SelectedItem != null)
                {
                    sSemester_Name = drpSelect_a_Semester.Text;
                    //assigns the value from drpName_Of_Semester to the variable sSemester_Name.
                }
                else
                {
                    MessageBox.Show("Please select a Semester.");
                }
            }
            catch
            {
                MessageBox.Show("Please select a vaild Semester name.");
            }

            for (int i = 0; i < listAssigned_Modules.Items.Count; i++)
            {
                sModule = listAssigned_Modules.Items[i].GetType().GetProperty("Module_Code").GetValue(listAssigned_Modules.Items[i], null).ToString();
                sSelf_Study_Hours = listAssigned_Modules.Items[i].GetType().GetProperty("Self_Study_Hours").GetValue(listAssigned_Modules.Items[i], null).ToString();
                // gets the Module Code and self Study Hours.

                loSemesterModule.Add(new SemesterModule() { Semester_Name = sSemester_Name, Module_Code = sModule, Self_Study_Hours = int.Parse(sSelf_Study_Hours) });
                // adds to the SemesterModule class List.

                listUnassigned_Modules.Items.Remove(i);

                MessageBox.Show("Module has been added to Semester.");
                // gives the user a message onecr the module is added.
            }


        }

        private void btnCancel_Module_to_Semester_Click(object sender, RoutedEventArgs e)
        {
            listAssigned_Modules.Items.Clear();
            listUnassigned_Modules.Items.Clear(); // clears the listbox when the tab is loaded.
            for (int i = 0; i < loModule.Count; i++)
            {
                listUnassigned_Modules.Items.Add(new { Module_Code = loModule[i].Module_Code });
            }

            // the code above was taken and adapted from StackOverflow.
            // https://stackoverflow.com/questions/19362911/clear-a-combobox-in-wpf
            // user:2631662
            // https://stackoverflow.com/users/2631662/user2631662
            this.drpSelect_a_Semester.SelectedItem = null;


        }

        private void drpSelect_a_Semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sSemester_Name = "";

            listAssigned_Modules.Items.Clear();
            listUnassigned_Modules.Items.Clear();


            if (drpSelect_a_Semester.SelectedItem != null)
            {
                sSemester_Name = drpSelect_a_Semester.SelectedItem.ToString();
            }

            for (int i = 0; i < loModule.Count; i++)
            {

                listUnassigned_Modules.Items.Add(new { Module_Code = loModule[i].Module_Code });
            }

            for (int i = 0; i < loSemesterModule.Count; i++)
            {
                if (loSemesterModule[i].Semester_Name == sSemester_Name && sSemester_Name != null && sSemester_Name != "")
                {
                    listAssigned_Modules.Items.Add(new { Module_Code = loSemesterModule[i].Module_Code });
                    string sModule = loSemesterModule[i].Module_Code;

                    if (sModule != null)
                    {
                        foreach (var item in listUnassigned_Modules.Items)
                        {
                            // the code below is taken and adapted from TutorialsPoint.
                            // https://www.tutorialspoint.com/How-to-find-the-index-of-an-item-in-a-Chash-list-in-a-single-step#:~:text=To%20get%20the%20index%20of,FindIndex(a%20%3D%3E%20a.
                            // Samual Sam
                            // https://www.tutorialspoint.com/authors/Samual-Sam

                            if (item.ToString().Contains(sModule))
                            {
                                // the code belove was taken and adapted from StackOverflow.
                                // https://stackoverflow.com/questions/57679316/move-selected-items-from-listview-to-another-one
                                // Hamza
                                // https://stackoverflow.com/users/7702066/hamza
                                listUnassigned_Modules.Items.Remove(item);
                                break;

                            }
                        }
                    }
                }
            }
        }

        private void drpName_Of_Semester_SelectionChanged(object sender, SelectionChangedEventArgs e)// in the study session tab
        {
            drpModule_Code.Items.Clear();
            if (drpName_Of_Semester.SelectedItem != null ) 
            {
                string sSemester = drpName_Of_Semester.SelectedItem.ToString();
                foreach (var itmes in loSemesterModule)
                {
                    if (itmes.Semester_Name.Contains(sSemester))
                    {
                         string sModule = itmes.Module_Code.ToString();


                        // the code belove was taken and adapted from StackOverflow.
                        // https://stackoverflow.com/questions/57679316/move-selected-items-from-listview-to-another-one
                        // Hamza
                        // https://stackoverflow.com/users/7702066/hamza

                        drpModule_Code.Items.Add(sModule);
                    }
                }
            }          
        }
    }
}

