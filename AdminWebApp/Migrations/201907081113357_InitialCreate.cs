namespace AdminWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        Website = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.User", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "ApplicationUser_Id", "dbo.User");
            DropIndex("dbo.Companies", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Companies");
        }
    }
}
