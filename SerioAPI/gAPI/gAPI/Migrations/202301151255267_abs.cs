namespace gAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        lat = c.Double(nullable: false),
                        lon = c.Double(nullable: false),
                        Question = c.String(),
                        Answer = c.Boolean(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        Correct = c.Boolean(nullable: false),
                        range = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuestItems");
        }
    }
}
