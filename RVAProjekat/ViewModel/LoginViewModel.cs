using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RVAProjekat.ViewModel
{
    public class LoginViewModel: BindableBase
    {

        public Window Window { get; set; }


        private string username;
        private string password;
        
        private string usernameError;
        private string passwordError;

        public Grid LoginGrid { get; set; }
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        
        public string UsernameError
        {
            get { return usernameError; }
            set
            {
                usernameError = value;
                OnPropertyChanged("UsernameError");
            }
        }

        public string PasswordError
        {
            get { return passwordError; }
            set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }

        public MyICommand LoginCommand { get; set; }


        public LoginViewModel(Grid loginGrid)
        {
            LoginCommand = new MyICommand(OnLogin);
            LoginGrid = loginGrid;
        }

        public void OnLogin(object parameter)
        {
            UsernameError = PasswordError = "";
            Password = (LoginGrid.FindName("PasswordBox") as PasswordBox).Password;
            MyLogger.Instance().Log("Login -- CALLED", "Login", "INFO");

            if (String.IsNullOrWhiteSpace(Username))
                UsernameError = "You need to enter username.";
            else
                UsernameError = "";
            if (String.IsNullOrWhiteSpace(Password))
                PasswordError = "You need to enter password.";
            else
                PasswordError = "";
            if (!String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(Password))
            {
                try
                {

                    CurrentUser.Instance = Channel.Instance.UserProxy.Login(Username, Password);
                    if (!String.IsNullOrWhiteSpace(CurrentUser.Instance.Username))
                    {
                        MyLogger.Instance().Log("Login -- SUCCESS", "Login", "INFO");
                        // MyLogger.Instance().Log("Login -- SUCCESS", CurrentUser.Instance.Username, "INFO");
                        new MainWindow().Show();
                        Window.Close();
                    }
                    else
                    {
                        MyLogger.Instance().Log("Login -- FAIL", "Login", "ERROR");
                        PasswordError = "Username and password doesn't match.";
                        CurrentUser.Instance = null;
                    }
                }
                catch
                {

                }
            }

        }
    }
}
