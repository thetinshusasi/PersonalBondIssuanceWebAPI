using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BondIssuance.DLL.DataModels
{
    public class UserAccount
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string Address { get; set; }


    }
}
