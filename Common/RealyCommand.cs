using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.ViewModel;

namespace WpfApp.Common
{
    public class RealyCommand : ICommand
    {

        private CustomerViewModel viewmodel;

        public RealyCommand(CustomerViewModel vm)
        {
            viewmodel = vm;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        

        public bool CanExecute(object parameter)
        {
            return true;// string.IsNullOrEmpty(viewmodel.Customer.Error);
        }

        public void Execute(object parameter)
        {
            viewmodel.SaceChanges();
        }
    }
}
