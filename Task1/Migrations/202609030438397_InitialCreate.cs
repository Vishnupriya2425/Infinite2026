namespace Task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClaimsReprocessings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Requester = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                        DepartmentName = c.String(),
                        LocationName = c.String(),
                        Team = c.String(),
                        AssignedTo = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        Summary = c.String(nullable: false),
                        SystemName = c.String(nullable: false),
                        Priority = c.String(nullable: false),
                        LineOfBusiness = c.String(nullable: false),
                        ReprocessingType = c.String(nullable: false),
                        ReprocessingReason = c.String(nullable: false),
                        ProviderName = c.String(nullable: false),
                        ParOrNonPar = c.String(),
                        TypeOfService = c.String(nullable: false),
                        ClaimsCount = c.Int(nullable: false),
                        TimelyFilingApprovalObtained = c.String(nullable: false),
                        ProjectedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InterestApplies = c.String(nullable: false),
                        VendorType = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        InternalNotes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClaimsReprocessings");
        }
    }
}
