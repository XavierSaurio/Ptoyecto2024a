namespace Proyecto2_2024a.Migrations
{
    using Proyecto2_2024a.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Proyecto2_2024a.DAL.Proyecto2_2024aContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Proyecto2_2024a.DAL.Proyecto2_2024aContext context)
        {
            //voy instancial los usuarios en el archivo configuraciones necesito 5 usuarios, 5 menus y  1 administrados para que se instancien en la base de datos 
            var usuarios = new[]
            {
                new Usuario { NombreUsuario = "Usuario1", Contraseña = "password1", Rol = "Cliente" },
                new Usuario { NombreUsuario = "Usuario2", Contraseña = "password2", Rol = "Cliente" },
                new Usuario { NombreUsuario = "Usuario3", Contraseña = "password3", Rol = "Cliente" },
                new Usuario { NombreUsuario = "Usuario4", Contraseña = "password4", Rol = "Cliente" },
                new Usuario { NombreUsuario = "Usuario5", Contraseña = "password5", Rol = "Cliente" }
            };

            context.Usuarios.AddOrUpdate(u => u.NombreUsuario, usuarios);

            // Crear 5 menús
            var menus = new[]
            {
                new Menu { Nombre = "Menu1", Descripcion = "Descripción del Menu1" },
                new Menu { Nombre = "Menu2", Descripcion = "Descripción del Menu2" },
                new Menu { Nombre = "Menu3", Descripcion = "Descripción del Menu3" },
                new Menu { Nombre = "Menu4", Descripcion = "Descripción del Menu4" },
                new Menu { Nombre = "Menu5", Descripcion = "Descripción del Menu5" }
            };

            context.Menus.AddOrUpdate(m => m.Nombre, menus);
            // Crear 1 administrador
            var administrador = new Usuario { NombreUsuario = "Admin", Contraseña = "adminpassword", Rol = "Administrador" };

            context.Usuarios.AddOrUpdate(u => u.NombreUsuario, administrador);

            // Guardar cambios
            context.SaveChanges();
        }
    }
}
