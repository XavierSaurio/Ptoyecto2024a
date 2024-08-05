namespace Proyecto2_2024a.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AñadirAutoincrementoAIds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Categoria = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.TicketHistorials", "Operacion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TicketHistorials", "Operacion", c => c.String());
            DropTable("dbo.Menus");
        }
    }
}
