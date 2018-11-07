namespace IndividualProjectRev3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loggers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoggedUser = c.Int(nullable: false),
                        LoggerTime = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Loggers");
        }
    }
}
