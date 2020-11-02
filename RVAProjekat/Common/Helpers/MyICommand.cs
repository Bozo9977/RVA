using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.Helpers
{
    
    public class MyICommand : ICommand
    {
        Action<object> _TargetExecuteMethod;
        Func<bool> _TargetCanExecuteMethod;

        Action<object> _TargetUnExecuteMethod;
        Func<bool> _TargetCanUnExecuteMethod;

        public MyICommand(Action<object> executeMethod, Action<object> unexecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetUnExecuteMethod = unexecuteMethod;
        }

        public MyICommand(Action<object> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        //public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
        //{
        //    _TargetExecuteMethod = executeMethod;
        //    _TargetCanExecuteMethod = canExecuteMethod;
        //}

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {

            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        bool CanUnExecute(object parameter)
        {

            if (_TargetCanUnExecuteMethod != null)
            {
                return _TargetCanUnExecuteMethod();
            }

            if (_TargetUnExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public event EventHandler CanExecuteChanged = delegate { };
        public event EventHandler CanUnExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod(parameter);
            }
        }

        public void Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod(parameter);
            }
        }

        public void Unexecute(object parameter)
        {
            if (_TargetUnExecuteMethod != null)
            {
                _TargetUnExecuteMethod(parameter);
            }
        }
    }

    public class MyICommand<T> : RelayCommand<T>
    {
        public MyICommand(Action<T> execute, bool keepTargetAlive = false) : base(execute, keepTargetAlive) { }

        public MyICommand(Action<T> execute, Func<T, bool> canExecute, bool keepTargetAlive = false) : base(execute, canExecute, keepTargetAlive) { }
    
        
        public override void Execute(object parameter)
        {
            base.Execute(parameter);
        }
    }
}
