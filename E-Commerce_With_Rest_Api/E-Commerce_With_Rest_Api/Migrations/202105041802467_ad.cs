namespace E_Commerce_With_Rest_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ad : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductHistories", "MainCategory_MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.Products", "MainCategory_MainCategoryId", "dbo.MainCategories");
            DropIndex("dbo.ProductHistories", new[] { "MainCategory_MainCategoryId" });
            DropIndex("dbo.Products", new[] { "MainCategory_MainCategoryId" });
            RenameColumn(table: "dbo.ProductHistories", name: "MainCategory_MainCategoryId", newName: "MainCategoryId");
            RenameColumn(table: "dbo.Products", name: "MainCategory_MainCategoryId", newName: "MainCategoryId");
            AlterColumn("dbo.ProductHistories", "MainCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "MainCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductHistories", "MainCategoryId");
            CreateIndex("dbo.Products", "MainCategoryId");
            AddForeignKey("dbo.ProductHistories", "MainCategoryId", "dbo.MainCategories", "MainCategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "MainCategoryId", "dbo.MainCategories", "MainCategoryId", cascadeDelete: true);
            DropColumn("dbo.ProductHistories", "CategoryID");
            DropColumn("dbo.Products", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.ProductHistories", "CategoryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.ProductHistories", "MainCategoryId", "dbo.MainCategories");
            DropIndex("dbo.Products", new[] { "MainCategoryId" });
            DropIndex("dbo.ProductHistories", new[] { "MainCategoryId" });
            AlterColumn("dbo.Products", "MainCategoryId", c => c.Int());
            AlterColumn("dbo.ProductHistories", "MainCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "MainCategoryId", newName: "MainCategory_MainCategoryId");
            RenameColumn(table: "dbo.ProductHistories", name: "MainCategoryId", newName: "MainCategory_MainCategoryId");
            CreateIndex("dbo.Products", "MainCategory_MainCategoryId");
            CreateIndex("dbo.ProductHistories", "MainCategory_MainCategoryId");
            AddForeignKey("dbo.Products", "MainCategory_MainCategoryId", "dbo.MainCategories", "MainCategoryId");
            AddForeignKey("dbo.ProductHistories", "MainCategory_MainCategoryId", "dbo.MainCategories", "MainCategoryId");
        }
    }
}
