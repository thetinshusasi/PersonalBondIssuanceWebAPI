namespace BondIssuance.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _230620194 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccessKeys", "NodeId", "dbo.Nodes");
            DropIndex("dbo.AccessKeys", new[] { "NodeId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AccessKeys", "NodeId");
            AddForeignKey("dbo.AccessKeys", "NodeId", "dbo.Nodes", "Id", cascadeDelete: true);
        }
    }
}
