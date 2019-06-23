namespace BondIssuance.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _230620195 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "NodeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "NodeId");
        }
    }
}
