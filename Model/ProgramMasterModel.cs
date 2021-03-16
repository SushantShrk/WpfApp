using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Common;

namespace WpfApp.Model
{
    public class ProgramMasterModel
    {
        private tb_ProgramMaster program;
     
        public ProgramMasterModel()
        {

            program = new tb_ProgramMaster();
        }


        public tb_ProgramMaster Program
        {
            get
            {
                return program;
            }
            
        }

       

    }
}
