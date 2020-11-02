using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RVAProjekat.ViewModel
{
    public class IssueTokenViewModel : BindableBase
    {

        public Window Window { get; set; }
        public MyICommand IssueTokenExecute { get; set; }

        //public User SelectedUser { get; set; }

        public int level { get; set; }
        public int GrantedLevel {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged("GrantedLevel");
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

        private User selectedUser;

        public IssueTokenViewModel(User SelectedUser)
        {
            IssueTokenExecute = new MyICommand(OnIssueToken);
            selectedUser = SelectedUser;
        }

        public void OnIssueToken(object parameter)
        {
            
            if(GrantedLevel >= 0)
            {
                MyLogger.Instance().Log("Issue Token -- CALLED", CurrentUser.Instance.Username, "INFO");
                Channel.Instance.TokenServiceProxy.GenerateToken(selectedUser.Id, GrantedLevel);
                Window.Close();
            }
            else
            {
                ErrorLabel = "Level of access can't be lesser than 0";
            }
                
        }



    }
}
