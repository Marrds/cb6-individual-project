namespace IndividualProjectRev3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Receiver", c => c.String());
            AddColumn("dbo.Messages", "Sender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Sender");
            DropColumn("dbo.Messages", "Receiver");
        }
    }
}
