namespace E_Commerce_With_Rest_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(),
                        PhoneNum = c.String(),
                        ImageFile = c.String(),
                        Address = c.String(),
                        DateOfBirth = c.String(),
                        Gender = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Usertype = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        ImageFile = c.String(),
                        Gender = c.String(),
                        Username = c.String(),
                        password = c.String(),
                        usertype = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderProductId = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductHistoryId = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderProductId)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.ProductHistories", t => t.ProductHistoryId, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductHistoryId)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        totalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.String(),
                        Quantity = c.Int(nullable: false),
                        PayMentMethod = c.String(),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.ProductHistories",
                c => new
                    {
                        ProductHistoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CategoryID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageFile = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleID = c.Int(),
                        FinalSubCategoryID = c.Int(),
                        Product_name = c.String(),
                        SubCategoryID = c.Int(),
                        SizeCategory = c.String(),
                        AddedDate = c.DateTime(),
                        OnHand = c.Int(),
                        MainCategory_MainCategoryId = c.Int(),
                        SaleHistory_SaleHistoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductHistoryId)
                .ForeignKey("dbo.FinalSubCategories", t => t.FinalSubCategoryID)
                .ForeignKey("dbo.MainCategories", t => t.MainCategory_MainCategoryId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryID)
                .ForeignKey("dbo.Sales", t => t.SaleID)
                .ForeignKey("dbo.SaleHistories", t => t.SaleHistory_SaleHistoryID)
                .Index(t => t.SaleID)
                .Index(t => t.FinalSubCategoryID)
                .Index(t => t.SubCategoryID)
                .Index(t => t.MainCategory_MainCategoryId)
                .Index(t => t.SaleHistory_SaleHistoryID);
            
            CreateTable(
                "dbo.FinalSubCategories",
                c => new
                    {
                        FinalSubCategoryId = c.Int(nullable: false, identity: true),
                        FinalSubCate_name = c.String(),
                        SubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinalSubCategoryId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CategoryID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageFile = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleID = c.Int(),
                        FinalSubCategoryID = c.Int(),
                        Product_name = c.String(),
                        SubCategoryID = c.Int(),
                        SizeCategory = c.String(),
                        AddedDate = c.DateTime(),
                        OnHand = c.Int(),
                        MainCategory_MainCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.FinalSubCategories", t => t.FinalSubCategoryID)
                .ForeignKey("dbo.MainCategories", t => t.MainCategory_MainCategoryId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryID)
                .ForeignKey("dbo.Sales", t => t.SaleID)
                .Index(t => t.SaleID)
                .Index(t => t.FinalSubCategoryID)
                .Index(t => t.SubCategoryID)
                .Index(t => t.MainCategory_MainCategoryId);
            
            CreateTable(
                "dbo.MainCategories",
                c => new
                    {
                        MainCategoryId = c.Int(nullable: false, identity: true),
                        Category_name = c.String(),
                    })
                .PrimaryKey(t => t.MainCategoryId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        SubCategory_name = c.String(),
                        MainCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.MainCategories", t => t.MainCategoryId, cascadeDelete: true)
                .Index(t => t.MainCategoryId);
            
            CreateTable(
                "dbo.ProductSizes",
                c => new
                    {
                        ProductSizeID = c.Int(nullable: false, identity: true),
                        SizeName = c.String(),
                        ProductID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSizeID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        ReviewTitle = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        Amount = c.String(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SaleID);
            
            CreateTable(
                "dbo.ProductSizeHistories",
                c => new
                    {
                        ProductSizeHistoryID = c.Int(nullable: false, identity: true),
                        SizeName = c.String(),
                        ProductHistoryId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSizeHistoryID)
                .ForeignKey("dbo.ProductHistories", t => t.ProductHistoryId, cascadeDelete: true)
                .Index(t => t.ProductHistoryId);
            
            CreateTable(
                "dbo.SaleHistories",
                c => new
                    {
                        SaleHistoryID = c.Int(nullable: false, identity: true),
                        Amount = c.String(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SaleHistoryID);
            
            CreateTable(
                "dbo.TempOrderProducts",
                c => new
                    {
                        TempOrderProductID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        ProductHistory_ProductHistoryId = c.Int(),
                        TempOrder_TempOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.TempOrderProductID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.ProductHistories", t => t.ProductHistory_ProductHistoryId)
                .ForeignKey("dbo.TempOrders", t => t.TempOrder_TempOrderId)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductHistory_ProductHistoryId)
                .Index(t => t.TempOrder_TempOrderId);
            
            CreateTable(
                "dbo.TempOrders",
                c => new
                    {
                        TempOrderId = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        totalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.String(),
                        Quantity = c.Int(nullable: false),
                        PayMentMethod = c.String(),
                    })
                .PrimaryKey(t => t.TempOrderId);
            
            CreateTable(
                "dbo.Profits",
                c => new
                    {
                        ProfitID = c.Int(nullable: false, identity: true),
                        OrderProductId = c.Int(nullable: false),
                        ProfitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProfitID)
                .ForeignKey("dbo.OrderProducts", t => t.OrderProductId, cascadeDelete: true)
                .Index(t => t.OrderProductId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        ImageFIle = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Username = c.String(),
                        password = c.String(),
                        Usertype = c.String(),
                    })
                .PrimaryKey(t => t.ManagerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Profits", "OrderProductId", "dbo.OrderProducts");
            DropForeignKey("dbo.TempOrderProducts", "TempOrder_TempOrderId", "dbo.TempOrders");
            DropForeignKey("dbo.TempOrderProducts", "ProductHistory_ProductHistoryId", "dbo.ProductHistories");
            DropForeignKey("dbo.TempOrderProducts", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.ProductHistories", "SaleHistory_SaleHistoryID", "dbo.SaleHistories");
            DropForeignKey("dbo.ProductSizeHistories", "ProductHistoryId", "dbo.ProductHistories");
            DropForeignKey("dbo.OrderProducts", "ProductHistoryId", "dbo.ProductHistories");
            DropForeignKey("dbo.Products", "SaleID", "dbo.Sales");
            DropForeignKey("dbo.ProductHistories", "SaleID", "dbo.Sales");
            DropForeignKey("dbo.Reviews", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Reviews", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.ProductSizes", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "SubCategoryID", "dbo.SubCategories");
            DropForeignKey("dbo.ProductHistories", "SubCategoryID", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.FinalSubCategories", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Products", "MainCategory_MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.ProductHistories", "MainCategory_MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.Products", "FinalSubCategoryID", "dbo.FinalSubCategories");
            DropForeignKey("dbo.ProductHistories", "FinalSubCategoryID", "dbo.FinalSubCategories");
            DropForeignKey("dbo.OrderProducts", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderProducts", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Reports", new[] { "CustomerID" });
            DropIndex("dbo.Profits", new[] { "OrderProductId" });
            DropIndex("dbo.TempOrderProducts", new[] { "TempOrder_TempOrderId" });
            DropIndex("dbo.TempOrderProducts", new[] { "ProductHistory_ProductHistoryId" });
            DropIndex("dbo.TempOrderProducts", new[] { "CustomerID" });
            DropIndex("dbo.ProductSizeHistories", new[] { "ProductHistoryId" });
            DropIndex("dbo.Reviews", new[] { "CustomerID" });
            DropIndex("dbo.Reviews", new[] { "ProductID" });
            DropIndex("dbo.ProductSizes", new[] { "ProductID" });
            DropIndex("dbo.SubCategories", new[] { "MainCategoryId" });
            DropIndex("dbo.Products", new[] { "MainCategory_MainCategoryId" });
            DropIndex("dbo.Products", new[] { "SubCategoryID" });
            DropIndex("dbo.Products", new[] { "FinalSubCategoryID" });
            DropIndex("dbo.Products", new[] { "SaleID" });
            DropIndex("dbo.FinalSubCategories", new[] { "SubCategoryId" });
            DropIndex("dbo.ProductHistories", new[] { "SaleHistory_SaleHistoryID" });
            DropIndex("dbo.ProductHistories", new[] { "MainCategory_MainCategoryId" });
            DropIndex("dbo.ProductHistories", new[] { "SubCategoryID" });
            DropIndex("dbo.ProductHistories", new[] { "FinalSubCategoryID" });
            DropIndex("dbo.ProductHistories", new[] { "SaleID" });
            DropIndex("dbo.OrderProducts", new[] { "CustomerID" });
            DropIndex("dbo.OrderProducts", new[] { "ProductHistoryId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderID" });
            DropTable("dbo.Managers");
            DropTable("dbo.Reports");
            DropTable("dbo.Profits");
            DropTable("dbo.TempOrders");
            DropTable("dbo.TempOrderProducts");
            DropTable("dbo.SaleHistories");
            DropTable("dbo.ProductSizeHistories");
            DropTable("dbo.Sales");
            DropTable("dbo.Reviews");
            DropTable("dbo.ProductSizes");
            DropTable("dbo.SubCategories");
            DropTable("dbo.MainCategories");
            DropTable("dbo.Products");
            DropTable("dbo.FinalSubCategories");
            DropTable("dbo.ProductHistories");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Customers");
            DropTable("dbo.Admins");
        }
    }
}
