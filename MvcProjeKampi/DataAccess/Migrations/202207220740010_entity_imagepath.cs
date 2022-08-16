namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entity_imagepath : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ImageFiles", "ImagePath", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImageFiles", "ImagePath", c => c.String(maxLength: 500));
        }
    }
}
