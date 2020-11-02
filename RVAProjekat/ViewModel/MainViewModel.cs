using Common.Helpers;
using Common.Models;
using GalaSoft.MvvmLight;
using RVAProjekat.Views;
using Server.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace RVAProjekat.ViewModel
{
    
    public class MainViewModel : BindableBase
    {
        #region Commands
        public MyICommand AddUserCommand { get; set; }
        public MyICommand LogoutCommand { get; set; }
        public MyICommand ChangeInfoCommand { get; set; }
        public MyICommand DeleteUserCommand { get; set; }
        public MyICommand BanUserCommand { get; set; }
        public MyICommand IssueTokenCommand { get; set; }
        public MyICommand AddGateCommand { get; set; }
        public MyICommand ChangeGateCommand { get; set; }
        public MyICommand DeleteGateCommand { get; set; }
        public MyICommand RecallTokenCommand { get; set; }
        public MyICommand EnterGateCommand { get; set; }
        public MyICommand ExitGateCommand { get; set; }
        public MyICommand ModifyCheckCommand { get; set; }
        public MyICommand DeleteCheckCommand { get; set; }
        public MyICommand RefreshCommand { get; set; }
        public MyICommand CloneCheckCommand { get; set; }
        public MyICommand UndoCommand { get; set; }
        public MyICommand RedoCommand { get; set; }
        public static MyICommand Change { get; set; }
        public MyICommand SearchCommand { get; set; }
        #endregion

        #region PropetiesForDataBinding
        public User loggedIn { get; set; }
        public User LoggedInUser {
            get { return loggedIn; }
            set
            {
                loggedIn = value;
                OnPropertyChanged("LoggedInUser");
            }
        }
        public Window Window { get; set; }
        public string VisibleAdd { get; set; }
        public User SelectedUser { get; set; }
        public Gate SelectedGate { get; set; }
        public Check SelectedCheck { get; set; }

        List<User> users { get; set; }
        public List<User> Users {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        List<Check> checks { get; set; }
        public List<Check> Checks {
            get { return checks; }
            set
            {
                checks = value;
                OnPropertyChanged("Checks");
            }
        }

        List<Gate> gates { get; set; }
        public List<Gate> Gates
        {
            get { return gates; }
            set
            {
                gates = value;
                OnPropertyChanged("Gates");
            }
        }

        public bool BeforeChecked { get; set; }
        public bool AfterChecked { get; set; }
        public bool OnChecked { get; set; }
        public DateTime searchDate { get; set; }
        public DateTime SearchDate {
            get { return searchDate; }
            set
            {
                searchDate = value;
                OnPropertyChanged("SearchDate");
            }
        }

        public string IsAdmin { get; set; }



        // //////////////////////////// ZA LOG  

        private ObservableCollection<LogModel> log = new ObservableCollection<LogModel>();
        public ObservableCollection<LogModel> Log { get => log; set { log = value; OnPropertyChanged("Log"); } }

        private static object x = new object();

        // ///////////////////////////////////

        #endregion

        public MainViewModel()
        {
            if (CurrentUser.Instance.Type == USER_TYPE.ADMIN)
            {
                VisibleAdd = "Visible";
                IsAdmin = "Visible";
                Users = Channel.Instance.UserProxy.GetAllUsers();
            }
            else
            {
                VisibleAdd = "Hidden";
                IsAdmin = "Hidden";
            }

            SearchDate = DateTime.Today;
            OnChecked = true;
            
            Gates = Channel.Instance.GateServiceProxy.GetAllGates();
            Checks = Channel.Instance.GateServiceProxy.GetChecks();

            LoggedInUser = new User() { Username = CurrentUser.Instance.Username, Name = CurrentUser.Instance.Name, LastName = CurrentUser.Instance.LastName, Type = CurrentUser.Instance.Type };

            AddUserCommand = new MyICommand(OnAddUserExecute);
            LogoutCommand = new MyICommand(OnLogout);
            ChangeInfoCommand = new MyICommand(OnChangeInfoExecute);
            DeleteUserCommand = new MyICommand(OnDeleteUserExecute);
            BanUserCommand = new MyICommand(OnBanUserExecute);
            IssueTokenCommand = new MyICommand(OnIssueToken);
            AddGateCommand = new MyICommand(OnAddGateExecute);
            ChangeGateCommand = new MyICommand(OnChangeGateExecute);
            DeleteGateCommand = new MyICommand(OnDeleteGateExecute);
            RecallTokenCommand = new MyICommand(OnRecallTokenExecute);
            EnterGateCommand = new MyICommand(OnEnterGateExecute);
            ExitGateCommand = new MyICommand(OnExitGateExecute);
            ModifyCheckCommand = new MyICommand(OnModifyCheckExecute);
            DeleteCheckCommand = new MyICommand(OnDeleteCheckExecute,OnDeleteCheckUnexecute);
            RefreshCommand = new MyICommand(OnChange);
            CloneCheckCommand = new MyICommand(OnCloneCheck, OnEnterGateUnexecute);

            UndoCommand = new MyICommand(Undo);
            RedoCommand = new MyICommand(Redo);
            Change = new MyICommand(OnChange);
            SearchCommand = new MyICommand(OnSearch);
        }

        public void OnAddUserExecute(object parameter)
        {
            MyLogger.Instance().Log("Add user -- initiated", CurrentUser.Instance.Username, "INFO");
            new AddUserWindow(false).ShowDialog();
            OnChange(null);
        }

        public void OnLogout(object parameter)
        {
            MyLogger.Instance().Log("Logout -- CALLED", "Login", "INFO");
            new LoginWindow().Show();
            CurrentUser.Instance = null;
            Window.Close();
        }

        public void OnChangeInfoExecute(object parameter)
        {
            MyLogger.Instance().Log("Change user -- initiated", CurrentUser.Instance.Username, "INFO");
            new AddUserWindow(true).ShowDialog();
            OnChange(null);
        }


        
        public void OnBanUserExecute(object parameter)
        {
            MyLogger.Instance().Log("Ban user -- initiated", CurrentUser.Instance.Username, "INFO");
            new BanUserWindow().ShowDialog();
            OnChange(null);
        }

        public void OnDeleteUserExecute(object parameter)
        {
            if (parameter == null)
            {
                if (SelectedUser != null && SelectedUser.Username == CurrentUser.Instance.Username)
                {
                    if(MessageBox.Show("Are you sure you want to delete yourself?  If you do that you will automatically be logged out of the system!","Question",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Channel.Instance.UserProxy.DeleteUser(SelectedUser);
                        OnLogout(null);
                    }
                    else
                    {
                        
                    }
                    
                }else if(SelectedUser!=null && SelectedUser.Username != CurrentUser.Instance.Username)
                {
                    MyLogger.Instance().Log("Delete user -- initiated", CurrentUser.Instance.Username, "INFO");
                    if (Channel.Instance.UserProxy.DeleteUser(SelectedUser))
                    {
                        OnChange(null);
                    }
                }
                else
                    MessageBox.Show("Select user first!");
            }
        }

        public void OnIssueToken(object parameter)
        {
            if (parameter == null)
            {
                if (SelectedUser != null)
                {
                    MyLogger.Instance().Log("Issue Token -- initiated", CurrentUser.Instance.Username, "INFO");
                    new IssueTokenWindow(SelectedUser).ShowDialog();
                    OnChange(null);
                }
                else
                    MessageBox.Show("Select user first!");
            }
        }

        // Refresh informacija
        public void OnChange(object parameter)
        {
            MyLogger.Instance().Log("Refresh -- CALLED", CurrentUser.Instance.Username, "INFO");
            LoggedInUser = CurrentUser.Instance;
            Users = Channel.Instance.UserProxy.GetAllUsers();
            Gates = Channel.Instance.GateServiceProxy.GetAllGates();
            Checks = Channel.Instance.GateServiceProxy.GetChecks();
            Parse($"../../{CurrentUser.Instance.Username}.txt");
        }

        //Parser za Logger
        private void Parse(string path)
        {
            lock (x)
            {
                try
                {
                    string[] lines = File.ReadAllLines(path);
                    foreach (var item in lines)
                    {
                        if (item.Contains(CurrentUser.Instance.Username))
                        {
                            string[] args = item.Split('-');
                            string[] time = args[2].Split(' ', ':', ',');
                            LogModel logModel = new LogModel()
                            {
                                TimeStamp = new TimeSpan(Int32.Parse(time[1]), Int32.Parse(time[2]), Int32.Parse(time[3])),
                                Level = args[4],
                                Message = args[7].Split(' ')[1],
                                Status = args[7].Split(' ')[2]
                            };

                            Log.Add(logModel);

                        }

                    }
                }
                catch (Exception) { }

            }
        }
        public void OnAddGateExecute(object parameter)
        {
            MyLogger.Instance().Log("Add Gate -- initiated", CurrentUser.Instance.Username, "INFO");
            new AddGateWindow(false, SelectedGate).ShowDialog();
            OnChange(null);
        }

        public void OnChangeGateExecute(object parameter)
        {
            if(parameter == null)
            {
                if(SelectedGate != null)
                {
                    MyLogger.Instance().Log("Change Gate -- CALLED", CurrentUser.Instance.Username, "INFO");
                    new AddGateWindow(true, SelectedGate).ShowDialog();
                    OnChange(null);
                }
                else
                {
                    MessageBox.Show("Select gate first!");
                }
            }
        }

        public void OnDeleteGateExecute(object parameter)
        {
            if(parameter == null)
            {
                if (SelectedGate != null)
                {
                    MyLogger.Instance().Log("Delete Gate -- CALLED", CurrentUser.Instance.Username, "INFO");
                    Channel.Instance.GateServiceProxy.DeleteGate(SelectedGate);
                    OnChange(null);
                }
                else
                {
                    MessageBox.Show("Select gate first!");
                }
            }
            
        }

        public void OnRecallTokenExecute(object parameter)
        {
            if(parameter == null)
            {
                if(SelectedUser != null)
                {
                    MyLogger.Instance().Log("Recall Token -- CALLED", CurrentUser.Instance.Username, "INFO");
                    Channel.Instance.TokenServiceProxy.RecallToken(SelectedUser.Id);
                    OnChange(null);
                }
                else
                {
                    MessageBox.Show("Select user first!");
                }
            }
        }

        public void OnEnterGateExecute(object parameter)
        {
            if (SelectedGate != null)
            {
                MyLogger.Instance().Log("Enter Gate -- CALLED", CurrentUser.Instance.Username, "INFO");
                MessageBox.Show(Channel.Instance.GateHandlerProxy.IssueCheck(CurrentUser.Instance, SelectedGate, CheckType.IN));
                CommandHandler.Instance.AddAndExecute(CloneCheckCommand, Channel.Instance.GateServiceProxy.FindLastCheck());
                OnChange(null);
            }
            else
            {
                MessageBox.Show("Select gate first!");
            }
            
        }

        public void OnEnterGateUnexecute(object parameter)
        {
            Channel.Instance.GateServiceProxy.DeleteCheck((Check)parameter);
            CommandHandler.Instance.redoObjects[CommandHandler.Instance.redoObjects.Count - 1] = (Check)parameter;
            OnChange(null);
        }

        public void OnExitGateExecute(object parameter)
        {
            if(SelectedGate != null)
            {
                MyLogger.Instance().Log("Enter Gate -- CALLED", CurrentUser.Instance.Username, "INFO");
                MessageBox.Show(Channel.Instance.GateHandlerProxy.IssueCheck(CurrentUser.Instance, SelectedGate, CheckType.OUT));
                CommandHandler.Instance.AddAndExecute(CloneCheckCommand, Channel.Instance.GateServiceProxy.FindLastCheck());
                OnChange(null);
            }
            else
            {
                MessageBox.Show("Select gate first!");
            }
        }

        public void OnModifyCheckExecute(object parameter)
        {
            if(SelectedCheck != null)
            {
                MyLogger.Instance().Log("Modify Check -- initiated", CurrentUser.Instance.Username, "INFO");
                new ModifyCheckWindow(SelectedCheck).ShowDialog();
                OnChange(null);
            }
            else
            {
                MessageBox.Show("Select check first!");
            }
        }

        public void OnDeleteCheckExecute(object parameter)
        {
            if(parameter == null)
            {
                if (SelectedCheck != null)
                {
                    MyLogger.Instance().Log("Delete check -- CALLED", CurrentUser.Instance.Username, "INFO");
                    if (Channel.Instance.GateServiceProxy.ValidateCheckDeletion(SelectedCheck))
                    {
                        MyLogger.Instance().Log("Delete check -- SUCCESS", CurrentUser.Instance.Username, "INFO");
                        Channel.Instance.GateServiceProxy.DeleteCheck(SelectedCheck);
                        CommandHandler.Instance.AddAndExecute(DeleteCheckCommand, SelectedCheck);
                    }
                    else
                    {
                        MyLogger.Instance().Log("Delete check -- ERROR", CurrentUser.Instance.Username, "ERROR");
                        MessageBox.Show("Selected check has already been deleted.", "Inofmartion.", MessageBoxButton.OK);
                    }   
                    OnChange(null);
                }
                else
                {
                    MessageBox.Show("Select check first!");
                }
            }
            else
            {
                Channel.Instance.GateServiceProxy.DeleteCheck((Check)parameter);
                CommandHandler.Instance.undoObjects[CommandHandler.Instance.undoObjects.Count - 1] = (Check)parameter;
                OnChange(null);
            }
            
        }
        
        public void OnDeleteCheckUnexecute(object parameter)
        {
            
            Channel.Instance.GateServiceProxy.CloneCheck((Check)parameter);
            Check redo = (Check)parameter;
            CommandHandler.Instance.redoObjects[CommandHandler.Instance.redoObjects.Count - 1] = redo;
            if(Channel.Instance.GateServiceProxy.FindLastCheckID() == -1)
            {
                MyLogger.Instance().Log("Delete check -- ERROR [Contact your system administrator]", CurrentUser.Instance.Username, "FATAL");
            }
            else
            {
                CommandHandler.Instance.UpdateCheckIDS(redo.Id, Channel.Instance.GateServiceProxy.FindLastCheckID());
                OnChange(null);
            }
            
        }

        public void OnCloneCheck(object parameter)
        {
            if(parameter == null)
            {

                if (SelectedCheck != null)
                {
                    MyLogger.Instance().Log("Clone check -- CALLED", CurrentUser.Instance.Username, "INFO");
                    Channel.Instance.GateServiceProxy.CloneCheck(SelectedCheck);
                    if (Channel.Instance.GateServiceProxy.FindLastCheck() != null)
                    {
                        MyLogger.Instance().Log("Clone check -- SUCCESS", CurrentUser.Instance.Username, "INFO");
                        CommandHandler.Instance.AddAndExecute(CloneCheckCommand, Channel.Instance.GateServiceProxy.FindLastCheck());
                        OnChange(null);
                    }
                    else
                    {
                        MyLogger.Instance().Log("Delete check -- ERROR [Contact your system administrator]", CurrentUser.Instance.Username, "FATAL");
                    }
                }
                else
                {
                    MessageBox.Show("Select check first!");
                }
            }
            else
            {
                Channel.Instance.GateServiceProxy.CloneCheck((Check)parameter);
                Check undo = (Check)parameter;
                CommandHandler.Instance.undoObjects[CommandHandler.Instance.undoObjects.Count - 1] = undo;
                if (Channel.Instance.GateServiceProxy.FindLastCheckID() == -1)
                {
                    MyLogger.Instance().Log("Clone check -- ERROR [Contact your system administrator]", CurrentUser.Instance.Username, "FATAL");
                }
                else
                {
                    CommandHandler.Instance.UpdateCheckIDS(undo.Id, Channel.Instance.GateServiceProxy.FindLastCheckID());
                    OnChange(null);
                }
            }
        }


        public void OnSearch(object parameter)
        {
            MyLogger.Instance().Log("Search -- CALLED", CurrentUser.Instance.Username, "INFO");
            string searchParam = "";
            if (OnChecked == true)
                searchParam = "ON";
            else if (BeforeChecked == true)
                searchParam = "BEFORE";
            else if (AfterChecked == true)
                searchParam = "AFTER";
            else
                searchParam = "ALL";
            Checks = Channel.Instance.GateServiceProxy.SearchedChecks(searchParam, SearchDate);
        }


        #region UNDO/REDO
        public bool CanUndo
        {
            get
            {
                if (CommandHandler.Instance.undoCommands.Count != 0)
                    return true;
                else
                    return false;
            }
        }

        public void Undo(object parameter)
        {
            MyLogger.Instance().Log("Undo -- CALLED", CurrentUser.Instance.Username, "INFO");
            if (CanUndo)
            {
                CommandHandler.Instance.Undo();
            }
        }

        public bool CanRedo
        {
            get
            {
                if (CommandHandler.Instance.redoCommands.Count != 0)
                    return true;
                else
                    return false;
            }
        }

        public void Redo(object parameter)
        {
            MyLogger.Instance().Log("Redo -- CALLED", CurrentUser.Instance.Username, "INFO");
            if (CanRedo)
            {
                CommandHandler.Instance.Redo();
            }
        }
        #endregion

    }
}