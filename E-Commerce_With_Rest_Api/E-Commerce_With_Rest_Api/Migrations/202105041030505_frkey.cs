namespace E_Commerce_With_Rest_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frkey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TempOrderProducts", name: "TempOrder_TempOrderId", newName: "TempOrderId");
            RenameIndex(table: "dbo.TempOrderProducts", name: "IX_TempOrder_TempOrderId", newName: "IX_TempOrderId");
            DropColumn("dbo.TempOrderProducts", "OrderID");
            DropColumn("dbo.TempOrderProducts", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TempOrderProducts", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.TempOrderProducts", "OrderID", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.TempOrderProducts", name: "IX_TempOrderId", newName: "IX_TempOrder_TempOrderId");
            RenameColumn(table: "dbo.TempOrderProducts", name: "TempOrderId", newName: "TempOrder_TempOrderId");
        }
    }
}
