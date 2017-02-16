namespace XFWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TravelExpense",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TravelDate = c.DateTime(nullable: false),
                        Category = c.String(),
                        Title = c.String(),
                        Location = c.String(),
                        Expense = c.Double(nullable: false),
                        Memo = c.String(),
                        Domestic = c.Boolean(nullable: false),
                        HasDocument = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TravelExpensesCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Account = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.TravelExpensesCategory");
            DropTable("dbo.TravelExpense");
        }
    }
}
