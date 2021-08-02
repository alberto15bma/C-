namespace BDConfiguracion.Migrations
{
    using BDConfiguracion.Modelos;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BDConfiguracion.BDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BDConfiguracion.BDContext context)
        {
            // AGREGAR ESTADO
            context.Estado.AddOrUpdate(x => x.Descripcion,
                new Estado { Descripcion = "ACTIVO" },
                new Estado { Descripcion = "INACTIVO" },
                new Estado { Descripcion = "ELIMINADO" }
                );
            // AGREGAR PERFILES
            context.Perfil.AddOrUpdate(x => x.Descripcion,
                new Perfil { Descripcion = "USUARIO", EstadoId= 1 },
                new Perfil { Descripcion = "ADMINISTRADOR", EstadoId = 1 },
                new Perfil { Descripcion = "SISTEMAS", EstadoId = 1 }
                );
        }
    }
}
