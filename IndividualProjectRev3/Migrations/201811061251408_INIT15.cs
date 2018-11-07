namespace IndividualProjectRev3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LevelOfAccess", c => c.Int(nullable: false));
        }
        
        public override void Down()

        {
            DropColumn("dbo.Users", "LevelOfAccess");
        }
    }
}
