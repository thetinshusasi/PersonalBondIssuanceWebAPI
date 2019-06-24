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
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ContractRepository(DbContext context) : base(context)
        {
        }
    }
}
