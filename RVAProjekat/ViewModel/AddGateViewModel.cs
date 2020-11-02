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
    public class AddGateViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddGateExecute { get; set; }
        public Gate SelectedGate { get; set; }

        public string buttonContent { get; set; }
        public string ButtonContent
        {
            get { return buttonContent; }
            set
            {
                buttonContent = value;
                OnPropertyChanged("ButtonContent");
            }
        }

        public string errorLabel { get; set; }
        public string ErrorLabel {
            get { return errorLabel; }
            set
            {
                errorLabel = value;
                OnPropertyChanged("ErrorLabel");
            }
        }

        public string gateName { get; set; }
        public string GateName
        {
            get { return gateName; }
            set
            {
                gateName = value;
                OnPropertyChanged("GateName");
            }
        }
        public int level { get; set; }
        public int LevelOfAccess
        { get { return level; }
            set
            {
                level = value;
                OnPropertyChanged("LevelOfAccess");
            }
        }
        private bool IsChange { get; set; }

        public AddGateViewModel(bool isChange, Gate selectedGate)
        {
            if (isChange)
            {
                ButtonContent = "Change Gate: " + selectedGate.Name;
                GateName = selectedGate.Name;
                LevelOfAccess = selectedGate.LevelOfAccess;
                MyLogger.Instance().Log("Change gate -- CALLED", CurrentUser.Instance.Username, "INFO");
            }
            else
            {
                ButtonContent = "Add new Gate";
                MyLogger.Instance().Log("Add gate -- CALLED", CurrentUser.Instance.Username, "INFO");
            }

            IsChange = isChange;
            SelectedGate = selectedGate;
            AddGateExecute = new MyICommand(OnAddGateExecute);
        }

        public void OnAddGateExecute(object parameter)
        {
            if(!IsChange)
            {
                if (String.IsNullOrEmpty(GateName))
                    ErrorLabel = "Enter gate's name!";
                else if (LevelOfAccess < 0)
                    ErrorLabel = "Level of access can't be lesser than 0";
                else if (String.IsNullOrEmpty(GateName) && String.IsNullOrEmpty(LevelOfAccess.ToString()))
                    ErrorLabel = "Fields can't be empty!";
                else
                {
                    if(Channel.Instance.GateServiceProxy.AddGate(GateName, LevelOfAccess))
                    {
                        MyLogger.Instance().Log("Add gate -- SUCCESS!", CurrentUser.Instance.Username, "INFO");
                    }
                    else
                    {
                        MyLogger.Instance().Log("Add gate -- FAIL!", CurrentUser.Instance.Username, "ERROR");
                    }
                    Window.Close();
                }
                    
            }
            else
            {
                if (String.IsNullOrEmpty(GateName))
                    ErrorLabel = "Enter gate's name!";
                else if (LevelOfAccess < 0)
                    ErrorLabel = "Level of access can't be lesser than 0";
                else if (String.IsNullOrEmpty(GateName) && String.IsNullOrEmpty(LevelOfAccess.ToString()))
                    ErrorLabel = "Fields can't be empty!";
                else
                {
                    if(Channel.Instance.GateServiceProxy.ChangeGate(GateName, LevelOfAccess, SelectedGate))
                    {
                        MyLogger.Instance().Log("Change gate -- SUCCESS", CurrentUser.Instance.Username, "INFO");
                    }
                    else
                    {
                        MyLogger.Instance().Log("Change gate -- FAIL!", CurrentUser.Instance.Username, "INFO");
                    }
                    Window.Close();
                }
            }
        }

    }
}
