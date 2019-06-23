using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BondIssuance.DLL.DataModels
{
    public class Contract
    {
        public int Id { get; set; }
        public int NodeId { get; set; }
        public int UserId { get; set; }
        public int UserAccountId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
