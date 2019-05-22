namespace BondIssuance.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NodeId = c.String(maxLength: 128),
                        Key = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nodes", t => t.NodeId)
                .Index(t => t.NodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccessKeys", "NodeId", "dbo.Nodes");
            DropIndex("dbo.AccessKeys", new[] { "NodeId" });
            DropTable("dbo.AccessKeys");
        }
    }
}
