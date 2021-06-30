namespace E_Commerce_With_Rest_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class haetos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Method = c.String(),
                        Relation = c.String(),
                        Admin_AdminID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admins", t => t.Admin_AdminID)
                .Index(t => t.Admin_AdminID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "Admin_AdminID", "dbo.Admins");
            DropIndex("dbo.Links", new[] { "Admin_AdminID" });
            DropTable("dbo.Links");
        }
    }
}
