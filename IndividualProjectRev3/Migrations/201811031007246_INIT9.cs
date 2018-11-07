namespace IndividualProjectRev3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReceiverId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "Sender", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "Receiver");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Receiver", c => c.String());
            AlterColumn("dbo.Messages", "Sender", c => c.String());
            DropColumn("dbo.Messages", "ReceiverId");
        }
    }
}
