namespace DataAnnotations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToCourseTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Courses", name: "Author_Id", newName: "AuthprId");
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Courses", "AuthprId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "AuthprId");
            AddForeignKey("dbo.Courses", "AuthprId", "dbo.Authors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "AuthprId", "dbo.Authors");
            DropIndex("dbo.Courses", new[] { "AuthprId" });
            AlterColumn("dbo.Courses", "AuthprId", c => c.Int());
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            RenameColumn(table: "dbo.Courses", name: "AuthprId", newName: "Author_Id");
            CreateIndex("dbo.Courses", "Author_Id");
            AddForeignKey("dbo.Courses", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
