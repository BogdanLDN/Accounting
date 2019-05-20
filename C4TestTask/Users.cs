using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace C4TestTask
{
    class Users
    {
        //decalre properties 
        public string Username { get; set; }
        public string Userpassword { get; set; }

        //intialise  
        public Users(string user, string pass)
        {
            this.Username = user;
            this.Userpassword = pass;
        }
        //validate string 
        private bool StringValidator(string input)
        {
            string pattern = "[^a-zA-Z]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //validate integer 
        private bool IntegerValidator(string input)
        {
            string pattern = "[^0-9]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //clear user inputs 
        private void ClearTexts(string user, string pass)
        {
            user = String.Empty;
            pass = String.Empty;
        }
        //method to check if eligible to be logged in 
        internal bool IsLoggedIn(string user, string pass)
        {
            //check user name empty 
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Введите имя пользователя!");
                return false;

            }
            else
            //check user name is valid type 
            //else if (StringValidator(user) == true)
            //{
            //    MessageBox.Show("Enter only text here");
            //    ClearTexts(user, pass);
            //    return false;
            //}
            //check user name is correct
            //else
            {
                if (Username != user)
                {
                    MessageBox.Show("Имя пользователя не верно!");
                    ClearTexts(user, pass);
                    return false;
                }
                //check password is empty 
                else
                {
                    if (string.IsNullOrEmpty(pass))
                    {
                        MessageBox.Show("Введите пароль!");
                        return false;
                    }
                    else
                    //check password is valid 
                    //else if (IntegerValidator(pass) == true)
                    //{
                    //    MessageBox.Show("Enter only integer here");
                    //    return false;
                    //}
                    ////check password is correct 
                    //else
                    if (Userpassword != pass)
                    {
                        MessageBox.Show("Не верный пароль");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
    }
}
