namespace BondIssuance.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccessKeys", "UrlKey", c => c.String());
            DropColumn("dbo.AccessKeys", "Key");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccessKeys", "Key", c => c.String());
            DropColumn("dbo.AccessKeys", "UrlKey");
        }
    }
}
