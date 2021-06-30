namespace E_Commerce_With_Rest_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chinh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ImageFile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ImageFile");
        }
    }
}
