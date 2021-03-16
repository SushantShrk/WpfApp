namespace WpfApp.Model
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    public class Customer1 : INotifyPropertyChanged, IDataErrorInfo
    {

        private enum enumAlog
        {
            Algo = 0,
            NonAlog = 1,
            Select = 2

        }




        private string _appname;

        public string AppName
        {
            get { return AppName; }
            set
            {
                _appname = value;
                OnPropertyChanged();
            }
        }




        public Customer1()
        {
            this._name = "name";
        }


        private string _name;

        private string _lastName;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);


                //if(columnName == nameof(Name))
                //{
                //    if(string.IsNullOrEmpty(Name))
                //    {
                //       this.Error = "name can not be null or  empty";
                //    }
                //    else
                //    {
                //        Error = null;
                //    }

                //}
                //return Error;
            }
        }

        static readonly string[] ValidateProperties =
        {
             nameof(Name),
             nameof(LastName)
        };

        public bool IsValid
        {
            get
            {
                foreach (string s in ValidateProperties)
                {
                    if (GetValidationError(s) != null)
                        return false;
                }
                return true;
            }
        }

        string GetValidationError(string proertyNaame)
        {
            string error = null;

            switch (proertyNaame)
            {
                case nameof(Name):
                    error = validateCustomerName();
                    break;

                case nameof(LastName):
                    error = ValidateLastName();
                    break;
                        


            }

            return error;
        }
        private string validateCustomerName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return "Customer name cannnon be blank";
            }
            return null;
        }


        private string ValidateLastName()
        {
            if (string.IsNullOrWhiteSpace(LastName))
            {
                return "Last name cannnon be blank";
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                // PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }


    }
}
