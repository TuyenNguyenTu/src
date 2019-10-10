namespace Project.SoftwareArchitecture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateTuyen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AssignedPersonId = c.Int(),
                        Decription = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.AssignedPersonId)
                .Index(t => t.AssignedPersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "AssignedPersonId", "dbo.People");
            DropIndex("dbo.Employees", new[] { "AssignedPersonId" });
            DropTable("dbo.People");
            DropTable("dbo.Employees");
        }
    }
}
