namespace IndividualProjectRev3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "userId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "userId" });
            DropTable("dbo.Messages");
        }
    }
}
