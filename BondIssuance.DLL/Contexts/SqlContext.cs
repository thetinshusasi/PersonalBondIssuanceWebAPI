using BondIssuance.DLL.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BondIssuance.DLL.Contexts
{
    public class SqlContext : DbContext
    {
        //public static string conn = "BondIssuanceConnectionString";
        public SqlContext() : base("BondIssuance")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<AccessKey> AccessKeys { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }



    }
}
