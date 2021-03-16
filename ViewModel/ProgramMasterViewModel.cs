using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Common;

namespace WpfApp.ViewModel
{
    public class ProgramMasterViewModel : INotifyPropertyChanged
    {
        private readonly DataContext context;
        public ProgramMasterViewModel()
        {
            context = new DataContext();
        }

        public ICommand WindowLoaded
        {
            get
            {
                return new ActionCommand(p => windowLoaded(),
                                  p => true);
            }
        }


        private void windowLoaded() 
        {
           IEnumerable< tb_ProgramMaster> asfd= context.Program.ToList();

           data = new ObservableCollection<tb_ProgramMaster>(asfd);


        }

        private ObservableCollection<tb_ProgramMaster> data = new ObservableCollection<tb_ProgramMaster>();
        public ObservableCollection<tb_ProgramMaster> ProgramData
        {
            get { return data; }
            set
            {
                data = value;
                NotifyPropertyChanged();
            }
        }


        private int n_ProgramID;

        public int ProgramId
        {
            get { return n_ProgramID; }
            set
            {
                n_ProgramID = value;
                NotifyPropertyChanged();
            }
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion


    }
}
