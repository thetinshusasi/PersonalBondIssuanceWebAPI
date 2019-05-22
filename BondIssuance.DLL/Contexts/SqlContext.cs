using BondIssuance.DLL.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BondIssuance.DLL.Contexts
{
    class SqlContext : DbContext
    {
        public SqlContext() : base("name=BondIssuanceConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<AccessKey> AccessKeys { get; set; }



    }
}
