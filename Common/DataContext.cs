using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp.Common
{
    class DataContext : DbContext
    {
        public DataContext() : base("GymManagementEntities")
        {

        }

        public DbSet<tb_ProgramMaster> Program {get;set;}
    }
}
