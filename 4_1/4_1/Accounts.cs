using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1
{
    public class Accounts
    {

        public int Id { get; set; }
        public string login { get; set; }
         public byte[] passwordHash { get; set; }
    }
}
