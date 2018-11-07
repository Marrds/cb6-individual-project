namespace IndividualProjectRev3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "DateAndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DateAndTime");
        }
    }
}
