namespace Task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDropdownMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DropdownMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        TextValue = c.String(),
                        ValueField = c.String(),
                        SortOrder = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DropdownMasters");
        }
    }
}
