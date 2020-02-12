using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("MSSQL")
        {

        }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<YasakliKelime> YasakliKelimeler { get; set; }
    }
}
