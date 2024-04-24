namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class im : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Picpath = c.String(),
                        Date = c.DateTime(nullable: false),
                        TotalEx = c.Int(nullable: false),
                        IsAvaiable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeExes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        YearofEx = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeExes", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.EmployeeExes", new[] { "Employee_Id" });
            DropTable("dbo.EmployeeExes");
            DropTable("dbo.Employees");
        }
    }
}
