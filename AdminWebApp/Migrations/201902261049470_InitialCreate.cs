namespace AdminWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubMenus", "ApplicationUser_Id", "dbo.User");
            DropIndex("dbo.SubMenus", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.RoleMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(nullable: false),
                        MenuIds = c.String(nullable: false, maxLength: 100),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Menus", "MenuLink", c => c.String(maxLength: 500));
            AddColumn("dbo.Menus", "ParentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Menus", "MenuIcon", c => c.String(maxLength: 100));
            DropTable("dbo.SubMenus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubMenus",
                c => new
                    {
                        SubMenuId = c.Int(nullable: false, identity: true),
                        SubMenuName = c.String(nullable: false, maxLength: 100),
                        SubMenuIcon = c.String(nullable: false, maxLength: 100),
                        MenuId = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SubMenuId);
            
            DropForeignKey("dbo.RoleMenus", "ApplicationUser_Id", "dbo.User");
            DropIndex("dbo.RoleMenus", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Menus", "MenuIcon", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Menus", "ParentId");
            DropColumn("dbo.Menus", "MenuLink");
            DropTable("dbo.RoleMenus");
            CreateIndex("dbo.SubMenus", "ApplicationUser_Id");
            AddForeignKey("dbo.SubMenus", "ApplicationUser_Id", "dbo.User", "Id");
        }
    }
}
