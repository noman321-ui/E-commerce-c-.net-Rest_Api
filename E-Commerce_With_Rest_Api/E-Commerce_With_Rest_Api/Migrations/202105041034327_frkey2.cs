namespace E_Commerce_With_Rest_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frkey2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TempOrderProducts", "ProductHistory_ProductHistoryId", "dbo.ProductHistories");
            DropIndex("dbo.TempOrderProducts", new[] { "ProductHistory_ProductHistoryId" });
            AddColumn("dbo.TempOrderProducts", "ProductID", c => c.Int());
            CreateIndex("dbo.TempOrderProducts", "ProductID");
            AddForeignKey("dbo.TempOrderProducts", "ProductID", "dbo.Products", "ProductId");
            DropColumn("dbo.TempOrderProducts", "ProductHistory_ProductHistoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TempOrderProducts", "ProductHistory_ProductHistoryId", c => c.Int());
            DropForeignKey("dbo.TempOrderProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.TempOrderProducts", new[] { "ProductID" });
            DropColumn("dbo.TempOrderProducts", "ProductID");
            CreateIndex("dbo.TempOrderProducts", "ProductHistory_ProductHistoryId");
            AddForeignKey("dbo.TempOrderProducts", "ProductHistory_ProductHistoryId", "dbo.ProductHistories", "ProductHistoryId");
        }
    }
}
