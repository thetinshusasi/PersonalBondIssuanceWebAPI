using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BondIssuance.DLL.DataModels
{
    public class Node
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IList<AccessKey> AccessKeys { get; set; }

        public string Password { get; set; }
    }
}
