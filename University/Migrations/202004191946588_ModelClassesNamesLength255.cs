namespace University.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelClassesNamesLength255 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "Description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Courses", "Description", c => c.String(maxLength: 50));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
