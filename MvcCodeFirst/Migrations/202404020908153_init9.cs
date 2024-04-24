namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeExes", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.EmployeeExes", new[] { "Employee_Id" });
            RenameColumn(table: "dbo.EmployeeExes", name: "Employee_Id", newName: "EmployeeID");
            AlterColumn("dbo.EmployeeExes", "EmployeeID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeExes", "EmployeeID");
            AddForeignKey("dbo.EmployeeExes", "EmployeeID", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeExes", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.EmployeeExes", new[] { "EmployeeID" });
            AlterColumn("dbo.EmployeeExes", "EmployeeID", c => c.Int());
            RenameColumn(table: "dbo.EmployeeExes", name: "EmployeeID", newName: "Employee_Id");
            CreateIndex("dbo.EmployeeExes", "Employee_Id");
            AddForeignKey("dbo.EmployeeExes", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
