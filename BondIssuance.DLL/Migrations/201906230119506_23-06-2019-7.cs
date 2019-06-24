namespace BondIssuance.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _230620197 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NodeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserAccountId = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contracts");
        }
    }
}
