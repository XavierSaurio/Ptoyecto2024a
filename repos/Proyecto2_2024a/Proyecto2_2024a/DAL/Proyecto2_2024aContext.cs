using System.Data.Entity;
using Proyecto2_2024a.Models;

namespace Proyecto2_2024a.DAL
{
    public class Proyecto2_2024aContext : DbContext
    {
        public Proyecto2_2024aContext() : base("Proyecto2_2024aContext")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tiquetera> Tiqueteras { get; set; }
        public DbSet<TicketHistorial> TicketHistorial { get; set; }
        public DbSet<Menu> Menus { get; set; }  // Agrega esta línea


    }
}
