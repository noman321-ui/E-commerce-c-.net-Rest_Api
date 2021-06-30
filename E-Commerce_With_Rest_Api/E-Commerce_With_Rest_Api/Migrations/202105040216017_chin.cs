namespace E_Commerce_With_Rest_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chin : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "ImageFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ImageFile", c => c.Binary());
        }
    }
}
