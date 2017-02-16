namespace XFWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUsertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TravelExpense", "Account", c => c.String());
            AddColumn("dbo.TravelExpense", "Updatetime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TravelExpense", "Updatetime");
            DropColumn("dbo.TravelExpense", "Account");
        }
    }
}
