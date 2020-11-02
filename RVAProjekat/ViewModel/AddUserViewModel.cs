using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common.Helpers;
using Common.Models;
using RVAProjekat.Views;
using Server.DatabaseAccess;

namespace RVAProjekat.ViewModel
{
    class AddUserViewModel: BindableBase
    {
        #region Fields
        private string title { get; set; }
        private string visible { get; set; }
        private string visible2 { get; set; }
        private bool isChange { get; set; }
        bool admin;
        User newUser = new User();
        #endregion

        public string errorName { get; set; }
        public string ErrorName {
            get { return errorName; }
            set
            {
                errorName = value;
                OnPropertyChanged("ErrorName");
            }
        }

        public string errorLastname { get; set; }
        public string ErrorLastname
        {
            get { return errorLastname; }
            set
            {
                errorLastname = value;
                OnPropertyChanged("ErrorLastname");
            }
        }

        public string errorUsername { get; set; }
        public string ErrorUsername
        {
            get { return errorUsername; }
            set
            {
                errorUsername = value;
                OnPropertyChanged("ErrorUsername");
            }
        }

        public string errorPassword { get; set; }
        public string ErrorPassword
        {
            get { return errorPassword; }
            set
            {
                errorPassword = value;
                OnPropertyChanged("ErrorPassword");
            }
        }

        public Window Window { get; set; }
        public bool IsChange
        {
            get { return isChange; }
            set
            {
                isChange = value;
                OnPropertyChanged("IsChange");
            }
        }
        public User NewUser
        {
            get { return newUser; }
            set
            {
                newUser = value;
                OnPropertyChanged("NewUser");
            }
        }
        public string Title { get { return title; } set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                OnPropertyChanged("Visible");
            }
        }

        public string Visible2
        {
            get { return visible2; }
            set
            {
                visible2 = value;
                OnPropertyChanged("Visible2");
            }
        }
      

        public bool Admin
        {
            get { return admin; }
            set
            {
                admin = value;
                OnPropertyChanged("Admin");
            }
        }

        #region Commands
        public MyICommand AddUserCommand { get; set; }
        public MyICommand ChangeInfoCommand { get; set; }
        #endregion
        public AddUserViewModel(bool changing)
        {
            IsChange = changing;
            if (changing)
            {
                NewUser = new User(CurrentUser.Instance);
                Title = "Change Info";
                Visible = "Hidden";
                Visible2 = "Visible";
                MyLogger.Instance().Log("Change user -- CALLED", CurrentUser.Instance.Username, "INFO");
            }
            else
            {
                Title = "Add User";
                Visible = "Visible";
                Visible2 = "Hidden";
                MyLogger.Instance().Log("Add user -- CALLED", CurrentUser.Instance.Username, "INFO");
            }

            AddUserCommand = new MyICommand(OnAddUserExecute);
            ChangeInfoCommand = new MyICommand(OnChangeInfoExecute);
        }


        public void OnChangeInfoExecute(object parameter)
        {
            ErrorName = ErrorLastname = ErrorUsername = ErrorPassword = "";

            if (String.IsNullOrEmpty(NewUser.Name))
            {
                ErrorName = "Name can't be empty";
            }else if (String.IsNullOrEmpty(NewUser.LastName))
            {
                ErrorLastname = "Last name can't be empty";
            }
            else if (String.IsNullOrEmpty(NewUser.Username))
            {
                ErrorUsername = "Username can't be empty";
            }
            else if (String.IsNullOrEmpty(NewUser.Password))
            {
                ErrorPassword = "Password can't be empty";
            }
            else
            {
                if (Channel.Instance.UserProxy.ChangeInfo(newUser))
                {
                    MyLogger.Instance().Log("Change user -- SUCCESS!", CurrentUser.Instance.Username, "INFO");
                    CurrentUser.Instance.Name = newUser.Name;
                    CurrentUser.Instance.LastName = newUser.LastName;
                    CurrentUser.Instance.Username = newUser.Username;
                    CurrentUser.Instance.Password = newUser.Password;

                    Window.Close();
                }
                else
                {
                    MyLogger.Instance().Log("Change user -- FAIL!", CurrentUser.Instance.Username, "ERROR");
                    ErrorUsername = "Username already exists";
                }
            }
            
        }
        
        public void OnAddUserExecute(object parameter)
        {
            ErrorName = ErrorLastname = ErrorUsername = ErrorPassword = "";

            if (String.IsNullOrEmpty(NewUser.Name))
            {
                ErrorName = "Name can't be empty";
            }
            else if (String.IsNullOrEmpty(NewUser.LastName))
            {
                ErrorLastname = "Last name can't be empty";
            }
            else if (String.IsNullOrEmpty(NewUser.Username))
            {
                ErrorUsername = "Username can't be empty";
            }
            else if (String.IsNullOrEmpty(NewUser.Password))
            {
                ErrorPassword = "Password can't be empty";
            }
            else
            {
                if (ValidateCreatedUser(NewUser))
                {
                    MyLogger.Instance().Log("Created user VALIDATED!", CurrentUser.Instance.Username, "INFO");
                    if (Admin)
                        NewUser.Type = USER_TYPE.ADMIN;
                    else
                        NewUser.Type = USER_TYPE.USER;


                    if (Channel.Instance.UserProxy.AddUser(newUser))
                    {
                        MyLogger.Instance().Log("Add user -- SUCCESS!", CurrentUser.Instance.Username, "INFO");
                        Window.Close();
                    }
                    else
                    {
                        MyLogger.Instance().Log("Add user -- Error!", CurrentUser.Instance.Username, "INFO");
                        ErrorUsername = "Username alredy exists.";
                    }
                }
                else
                {
                    MyLogger.Instance().Log("Created user -- NOT VALIDATED!", CurrentUser.Instance.Username, "INFO");
                    ErrorUsername = "Username alredy exists.";
                }
            }
        }

        private bool ValidateCreatedUser(User user)
        {
            MyLogger.Instance().Log("Validate user -- initiated!", CurrentUser.Instance.Username, "INFO");
            return Channel.Instance.UserProxy.ValidateUser(user);
        }
    }
}
