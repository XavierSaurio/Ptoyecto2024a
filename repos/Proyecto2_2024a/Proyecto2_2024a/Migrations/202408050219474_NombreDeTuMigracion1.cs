namespace Proyecto2_2024a.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreDeTuMigracion1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketHistorials", "Sesion", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketHistorials", "Sesion");
        }
    }
}
