using MvvmHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp.Common
{
    public class ActionCommand : ICommand
    {
        

        Action<object> action;
        Predicate<object> predict;
        public event EventHandler CanExecuteChanged;

        public ActionCommand(Action<object>act, Predicate<object>pr)
        {
            if(act == null)
            {
                throw new ArgumentNullException("Action can not be null");
                
            }
            this.action = act;
            this.predict = pr;
        }
        public bool CanExecute(object parameter)
        {
            if(predict==null)
            {
                throw new ArgumentNullException("Predict, predict can not be null");
            }

            return predict(parameter);
            
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

        public Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
