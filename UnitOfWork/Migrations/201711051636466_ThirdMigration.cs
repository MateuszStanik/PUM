namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.expenses", "title", c => c.String(unicode: false));
            AddColumn("dbo.expenses", "description", c => c.String(unicode: false));
            AddColumn("dbo.expenses", "value", c => c.Double(nullable: false));
            AddColumn("dbo.expenses", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.expenses", "repeatValue", c => c.Int(nullable: false));
            AddColumn("dbo.expenses", "category", c => c.Int(nullable: false));
            AddColumn("dbo.expenses", "createdDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.expenses", "updatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.expenses", "sourceId", c => c.Long(nullable: false));
            AddColumn("dbo.incomes", "title", c => c.String(unicode: false));
            AddColumn("dbo.incomes", "description", c => c.String(unicode: false));
            AddColumn("dbo.incomes", "value", c => c.Double(nullable: false));
            AddColumn("dbo.incomes", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.incomes", "repeatValue", c => c.Int(nullable: false));
            AddColumn("dbo.incomes", "type", c => c.Int(nullable: false));
            AddColumn("dbo.incomes", "createdDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.incomes", "updatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.incomes", "sourceId", c => c.Long(nullable: false));
            AddColumn("dbo.savings", "title", c => c.String(unicode: false));
            AddColumn("dbo.savings", "description", c => c.String(unicode: false));
            AddColumn("dbo.savings", "value", c => c.Double(nullable: false));
            AddColumn("dbo.savings", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.savings", "image", c => c.String(unicode: false));
            AddColumn("dbo.savings", "createdDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.savings", "updatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.savings", "updatedDate");
            DropColumn("dbo.savings", "createdDate");
            DropColumn("dbo.savings", "image");
            DropColumn("dbo.savings", "date");
            DropColumn("dbo.savings", "value");
            DropColumn("dbo.savings", "description");
            DropColumn("dbo.savings", "title");
            DropColumn("dbo.incomes", "sourceId");
            DropColumn("dbo.incomes", "updatedDate");
            DropColumn("dbo.incomes", "createdDate");
            DropColumn("dbo.incomes", "type");
            DropColumn("dbo.incomes", "repeatValue");
            DropColumn("dbo.incomes", "date");
            DropColumn("dbo.incomes", "value");
            DropColumn("dbo.incomes", "description");
            DropColumn("dbo.incomes", "title");
            DropColumn("dbo.expenses", "sourceId");
            DropColumn("dbo.expenses", "updatedDate");
            DropColumn("dbo.expenses", "createdDate");
            DropColumn("dbo.expenses", "category");
            DropColumn("dbo.expenses", "repeatValue");
            DropColumn("dbo.expenses", "date");
            DropColumn("dbo.expenses", "value");
            DropColumn("dbo.expenses", "description");
            DropColumn("dbo.expenses", "title");
        }
    }
}
