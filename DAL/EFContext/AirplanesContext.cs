using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class AirplanesContext:DbContext
    {
        public AirplanesContext(string name):base(name) //указывается имя БД или ConnectionString (EF сам решит, что именно)
        {
            
        }
        public DbSet<Airplane> Airplane { get; set; }
        public DbSet<Cargoes> Cargoes { get; set; }

    }
}
