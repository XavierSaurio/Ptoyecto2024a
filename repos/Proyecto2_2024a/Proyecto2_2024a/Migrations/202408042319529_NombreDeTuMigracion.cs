namespace Proyecto2_2024a.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreDeTuMigracion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketHistorials", "TiqueteraID", "dbo.Tiqueteras");
            DropIndex("dbo.TicketHistorials", new[] { "TiqueteraID" });
            RenameColumn(table: "dbo.TicketHistorials", name: "TiqueteraID", newName: "Tiquetera_ID");
            AddColumn("dbo.TicketHistorials", "UsuarioID", c => c.Int(nullable: false));
            AddColumn("dbo.TicketHistorials", "Valor", c => c.Int(nullable: false));
            AddColumn("dbo.TicketHistorials", "Compras", c => c.String(nullable: false));
            AlterColumn("dbo.TicketHistorials", "Tiquetera_ID", c => c.Int());
            CreateIndex("dbo.TicketHistorials", "Tiquetera_ID");
            AddForeignKey("dbo.TicketHistorials", "Tiquetera_ID", "dbo.Tiqueteras", "ID");
            DropColumn("dbo.TicketHistorials", "Operacion");
            DropColumn("dbo.TicketHistorials", "Cantidad");
            DropColumn("dbo.Tiqueteras", "UsuarioID");
            DropColumn("dbo.Tiqueteras", "NumeroDeTickets");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tiqueteras", "NumeroDeTickets", c => c.Int(nullable: false));
            AddColumn("dbo.Tiqueteras", "UsuarioID", c => c.Int(nullable: false));
            AddColumn("dbo.TicketHistorials", "Cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.TicketHistorials", "Operacion", c => c.String(nullable: false));
            DropForeignKey("dbo.TicketHistorials", "Tiquetera_ID", "dbo.Tiqueteras");
            DropIndex("dbo.TicketHistorials", new[] { "Tiquetera_ID" });
            AlterColumn("dbo.TicketHistorials", "Tiquetera_ID", c => c.Int(nullable: false));
            DropColumn("dbo.TicketHistorials", "Compras");
            DropColumn("dbo.TicketHistorials", "Valor");
            DropColumn("dbo.TicketHistorials", "UsuarioID");
            RenameColumn(table: "dbo.TicketHistorials", name: "Tiquetera_ID", newName: "TiqueteraID");
            CreateIndex("dbo.TicketHistorials", "TiqueteraID");
            AddForeignKey("dbo.TicketHistorials", "TiqueteraID", "dbo.Tiqueteras", "ID", cascadeDelete: true);
        }
    }
}
