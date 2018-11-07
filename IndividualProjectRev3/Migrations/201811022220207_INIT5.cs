namespace IndividualProjectRev3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Loggers", "LoggedUser", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Loggers", "LoggedUser", c => c.Int(nullable: false));
        }
    }
}
