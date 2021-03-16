using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Common;
using WpfApp.Model;
using WpfApp.View;

namespace WpfApp.ViewModel
{
   public class CustomerViewModel
    {
        private CustomerInfoViewModel childViewModel;

        
        public CustomerViewModel()
        {
            _customer = new Customer1();
            _customer.Name = "Customer Namedd";
            _customer.LastName = "Last Name";
            _customer.AppName = "Application NAme";
            UpdateCommand = new RealyCommand(this);
            childViewModel = new CustomerInfoViewModel();

         

        }



        private Customer1 _customer;

        public Customer1 Customer
        {
            get
            {
                return _customer;
            }
        }

        public void SaceChanges()
        {
            // Debug.Assert(false, $"{Customer.Name} was updated ");
            CustomerInfoView customerInfo = new CustomerInfoView();
            customerInfo.DataContext = childViewModel;
            childViewModel.Info = $"{Customer.Name} was updated in the database";

            customerInfo.ShowDialog();
        }

        public ICommand UpdateCommand { get; private set; }

        public ICommand ProgramCommnad
        {
            get
            {
                return new ActionCommand(p => OpenProgram(),
                                        p => IsValid);

               
            }
        }

        public EnumLog ELog
        {
            get
            {
                return _enum;
            }
            set
            {
                _enum = value;
            }
        }


        public EnumLog _enum;
        public enum EnumLog
        {
            Algo = 0,
            NonAlog = 1,
            Select = 2
        }

        public IEnumerable<EnumLog> StrategyTypes
        {
            get
            {
                return Enum.GetValues(typeof(EnumLog)).Cast<EnumLog>();
              
            }
        }


        private void OpenProgram()
        {
            Program objProgram = new Program();
            objProgram.DataContext = new ProgramMasterViewModel();
            objProgram.ShowDialog();

        }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_customer.Name) && string.IsNullOrWhiteSpace(_customer.LastName) )
                {
                    return false;
                }
                return true;

                
            }
        }


    }
}
