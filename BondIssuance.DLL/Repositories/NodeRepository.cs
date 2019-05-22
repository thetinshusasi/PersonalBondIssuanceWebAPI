using BondIssuance.DLL.DataModels;
using BondIssuance.DLL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BondIssuance.DLL.Repositories
{
    public class NodeRepository : Repository<Node>, INodeRepository
    {
        public NodeRepository(DbContext context) : base(context)
        {
        }
    }
}
