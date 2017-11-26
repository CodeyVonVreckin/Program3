// Program 2
// CIS 199-01
// Due: 4/5/2016
// By: Codey Von Vreckin
// this program uses parrallel arrays and range matching to determine which time the students could be able to register for classes.



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prog2
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }
        //Precondition:requires the user to input their # of completed credit hours and their last name
        //Postcondition: displays the day and time the student is able to register based on the input from the user
        private void findRegTimeBtn_Click(object sender, EventArgs e)
        {
            const float SENIOR_HOURS = 90;    // Min hours for Senior
            const float JUNIOR_HOURS = 60;    // Min hours for Junior
            const float SOPHOMORE_HOURS = 30; // Min hours for Soph.

            const string DAY1 = "March 30";  // 1st day of registration
            const string DAY2 = "March 31";  // 2nd day of registration
            const string DAY3 = "April 1";   // 3rd day of registration
            const string DAY4 = "April 4";   // 4th day of registration
            const string DAY5 = "April 5";   // 5th day of registration
            const string DAY6 = "April 6";   // 6th day of registration

            char[] lastNameJrSen = { 'A', 'E', 'J', 'P', 'T' }; // array of first letters of last names for junior and seniors
            string[] timesJrSen = { "4:00 PM", "8:30 AM", "10:00 AM", "11:30 AM", "2:00 PM" }; // list of times for juniors and seniors
            char[] lastNameSoFr1 = { 'E', 'G', 'J', 'M', 'P' };// first letters of the last names from E- Q
            string[] timesSoFr1 = { "8:30 AM", "10:00 AM", "11:30 AM", "2:00 PM", "4:000 PM" };// list of times for sophomores and freshman with last names starting with E-Q
            char[] lastNameSoFr2 = { 'A', 'C', 'R', 'T', 'W' };// first letters of the last names from A-D and R-Z
            string[] timesSoFr2 = { "2:00 PM", "4:00PM", "8:30 AM", "10:00 AM", "11:30 AM" };// list of times for the sophomores and freshman with last names starting with A-D or R-Z
            int i = lastNameJrSen.Length - 1; // declared a variable to hold the integer of lastNameJrSen.Lengeth -1           
     
            string lastNameStr;       // Entered last name
            char lastNameLetterCh;    // First letter of last name, as char
            string dateStr = "Error"; // Holds date of registration
            string timeStr = "Error"; // Holds time of registration
            float creditHours;        // Entered credit hours

            if (float.TryParse(creditHrTxt.Text, out creditHours) && creditHours >= 0) // Valid hours
            {
                lastNameStr = lastNameTxt.Text;
                if (lastNameStr.Length > 0) // Empty string?
                {
                    lastNameStr = lastNameStr.ToUpper(); // Ensure upper case
                    lastNameLetterCh = lastNameStr[0];   // First char of last name

                    if (char.IsLetter(lastNameLetterCh)) // Is it a letter?
                    {
                        // Juniors and Seniors share same schedule but different days
                        if (creditHours >= JUNIOR_HOURS)
                        {
                            if (creditHours >= SENIOR_HOURS)
                                dateStr = DAY1;
                            else // Must be juniors
                                dateStr = DAY2;
                            while (i >= 0 && lastNameLetterCh < lastNameJrSen[i]) --i; // while loop to match the letters with the times
                            {
                                timeStr = timesJrSen[i];// takes the time from the array and assigns its value to timestr
                                dateTimeLbl.Text = timeStr;// displays the time 
                            }
                        }
                        // Sophomores and Freshmen
                        else // Must be soph/fresh
                        {
                            if (creditHours >= SOPHOMORE_HOURS)
                            {
                                // E-Q on one day
                                if ((lastNameLetterCh >= 'E') && // >= E and
                                    (lastNameLetterCh <= 'Q'))   // <= Q
                                {
                                    dateStr = DAY3;
                                    while (i >= 0 && lastNameLetterCh < lastNameSoFr1[i]) --i;// while loop to match the letters with the times
                                    {
                                        timeStr = timesSoFr1[i];// takes the time from the array and assigns its value to timestr
                                        dateTimeLbl.Text = timeStr;// displays the time 
                                    }
                                }
                                else // All other letters on next day                                
                                {
                                    dateStr = DAY4;
                                    while (i >= 0 && lastNameLetterCh < lastNameSoFr2[i]) --i;// while loop to match the letters with the times
                                    {
                                        timeStr = timesSoFr2[i];// takes the time from the array and assigns its value to timestr
                                        dateTimeLbl.Text = timeStr;// displays the time 
                                    }
                                }
                            }
                            else // must be freshman
                            {
                                // E-Q on one day
                                if ((lastNameLetterCh >= 'E') && // >= E and
                                    (lastNameLetterCh <= 'Q'))   // <= Q
                                {
                                    dateStr = DAY5;
                                    while (i >= 0 && lastNameLetterCh < lastNameSoFr1[i]) --i;// while loop to match the letters with the times
                                    {
                                        timeStr = timesSoFr1[i];// takes the time from the array and assigns its value to timestr
                                        dateTimeLbl.Text = timeStr;// displays the time 
                                    }
                                }
                                else // All other letters on next day
                                {
                                    dateStr = DAY6;
                                    while (i >= 0 && lastNameLetterCh < lastNameSoFr2[i]) --i;// while loop to match the letters with the times
                                    {
                                        timeStr = timesSoFr2[i];// takes the time from the array and assigns its value to timestr
                                        dateTimeLbl.Text = timeStr;// displays the time 
                                    }
                                }
                            }                                                                                                      
                        }

                        // Output results
                        dateTimeLbl.Text = dateStr + " at " + timeStr;
                    }
                    else // First char not a letter
                        MessageBox.Show("Enter valid last name!");
                }
                else // Empty textbox
                    MessageBox.Show("Enter a last name!");
            }
            else // Can't parse credit hours
                MessageBox.Show("Please enter valid credit hours earned!");
        }
    }
}
