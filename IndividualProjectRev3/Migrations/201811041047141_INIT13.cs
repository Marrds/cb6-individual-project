namespace IndividualProjectRev3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SenderId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "SenderName", c => c.String());
            DropColumn("dbo.Messages", "Sender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Sender", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "SenderName");
            DropColumn("dbo.Messages", "SenderId");
        }
    }
}
