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
    public class ModifyCheckViewModel : BindableBase
    {
        public DateTime selectedDate { get; set; }
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                OnPropertyChanged("SelectedDate");
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

        public Window Window { get; set; }
        public MyICommand ModifyCheck { get; set; }
        public Check SelectedCheck { get; set; }

        public ModifyCheckViewModel(Check selectedCheck)
        {
            SelectedCheck = selectedCheck;
            SelectedDate = selectedCheck.Datetime.Date;
            ModifyCheck = new MyICommand(OnModifyCheckExecute, OnModifyCheckUnexecute);
        }

        public void OnModifyCheckExecute(object parameter)
        {
            MyLogger.Instance().Log("Modify Check -- CALLED", CurrentUser.Instance.Username, "INFO");
            if(parameter == null)
            {
                if (SelectedDate != null)
                {
                    if (!Channel.Instance.GateServiceProxy.ValidateCheckChange(SelectedCheck))
                    {
                        if (MessageBox.Show("This check is already changed. Do you want to overwrite that change?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            Channel.Instance.GateServiceProxy.ModifyCheck(SelectedDate, SelectedCheck);
                            Check commandCheck = new Check() {
                                Datetime = SelectedCheck.Datetime,
                                GateID = SelectedCheck.GateID,
                                Id = SelectedCheck.Id,
                                Token = SelectedCheck.Token,
                                TokenId = SelectedCheck.TokenId,
                                Type = SelectedCheck.Type
                            };
                            CommandHandler.Instance.AddAndExecute(ModifyCheck, commandCheck);
                            SelectedCheck.Datetime = SelectedDate;                            
                        }                            
                        else
                            Window.Close();
                    }
                    else
                    {
                        Check commandCheck = new Check()
                        {
                            Datetime = SelectedCheck.Datetime,
                            GateID = SelectedCheck.GateID,
                            Id = SelectedCheck.Id,
                            Token = SelectedCheck.Token,
                            TokenId = SelectedCheck.TokenId,
                            Type = SelectedCheck.Type
                        };
                        Channel.Instance.GateServiceProxy.ModifyCheck(SelectedDate, SelectedCheck);
                        CommandHandler.Instance.AddAndExecute(ModifyCheck, commandCheck);
                        SelectedCheck.Datetime = SelectedDate;
                    }


                    Window.Close();
                }
                else
                {
                    ErrorLabel = "Select date first";
                }
            }
            else
            { 
                Check oldCheck = Channel.Instance.GateServiceProxy.FindCheckByID(((Check)parameter).Id);
                CommandHandler.Instance.undoObjects[CommandHandler.Instance.undoObjects.Count - 1] = oldCheck;

                Channel.Instance.GateServiceProxy.ModifyCheck(((Check)parameter).Datetime, (Check)parameter);
                
                MainViewModel.Change.Execute(null);
            }
            
        }

        public void OnModifyCheckUnexecute(object parameter)
        {
            Check oldCheck = Channel.Instance.GateServiceProxy.FindCheckByID(((Check)parameter).Id);
            CommandHandler.Instance.redoObjects[CommandHandler.Instance.redoObjects.Count - 1] = oldCheck;

            Channel.Instance.GateServiceProxy.ModifyCheck(((Check)parameter).Datetime, (Check)parameter);

            MainViewModel.Change.Execute(null);
        }

    }
}
