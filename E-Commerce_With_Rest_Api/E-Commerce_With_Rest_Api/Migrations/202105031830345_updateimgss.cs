namespace E_Commerce_With_Rest_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateimgss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ImageFile", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ImageFile");
        }
    }
}
