using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2
{
    class PeopleContext:DbContext
    {
        public PeopleContext() : base("MyConnectionString")
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}
