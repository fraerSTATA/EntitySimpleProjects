using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Accounts> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-L20L48I\SQLEXPRESS;Database=MyDb;Trusted_Connection=True; Trust Server Certificate=true;");
        }
    }
}
