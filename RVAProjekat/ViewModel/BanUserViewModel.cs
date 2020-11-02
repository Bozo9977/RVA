using Common.Helpers;
using Common.Models;
using Server.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RVAProjekat.ViewModel
{
    class BanUserViewModel: BindableBase
    {
        public Window Window { get; set; }
        public MyICommand BanUser { get; set; }
        public User SelectedUser { get; set; }
        public Gate SelectedGate { get; set; }

        List<User> users { get; set; }
        public List<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
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

        public string errorLabel { get; set; }
        public string ErrorLabel
        {
            get { return errorLabel; }
            set
            {
                errorLabel = value;
                OnPropertyChanged("ErrorLabel");
            }
        }
        public BanUserViewModel()
        {
            Users = Channel.Instance.UserProxy.GetAllUsers();
            Gates = Channel.Instance.GateServiceProxy.GetAllGates();
            BanUser = new MyICommand(OnBanUserExecute);
        }

        public void OnBanUserExecute(object parameter)
        {
            MyLogger.Instance().Log("Ban user -- CALLED", CurrentUser.Instance.Username, "INFO");
            if(SelectedGate != null && SelectedUser != null)
            {
                Channel.Instance.GateServiceProxy.BanUser(SelectedUser.Username, SelectedGate.GateID);
                Window.Close();
            }else if(SelectedUser == null)
            {
                ErrorLabel = "Select user first!";
            }else if(SelectedGate == null)
            {
                ErrorLabel = "Select gate first!";
            }
            
        }
    }
}
