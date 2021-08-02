using ApiSistema.Modelos.Configuracion.Tablas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSistema.Modelos.Configuracion
{
    class BDContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=ArSystemConfiguracion;user id=sa;password=12345678;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // AGREGAR ESTADO
            modelBuilder.Entity<Estado>()
                .HasData(
                new Estado { Id = 1, Descripcion = "ACTIVO" },
                new Estado { Id = 2, Descripcion = "INACTIVO" },
                new Estado { Id = 3, Descripcion = "ELIMINADO" });

            // AGREGAR PERFILES
            modelBuilder.Entity<Perfil>()
                .HasData(
                new Perfil { Id = 1, Descripcion = "USUARIO", EstadoId = 1 },
                new Perfil { Id = 2, Descripcion = "ADMINISTRADOR", EstadoId = 1 },
                new Perfil { Id = 3, Descripcion = "SISTEMAS", EstadoId = 1 });

            // INSERTAR USUARIO POR DEFECTO
            modelBuilder.Entity<Usuarios>()
                .HasData(
                new Usuarios
                {
                    Id = 1,
                    Apellidos = "ADMIN",
                    Nombres = "ADMIN",
                    Cedula = "123456789",
                    Email = "sistemas@sistemas.com",
                    Activo = true,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    InicioSesion = true,
                    Notificacion = true,
                    PerfilId = 3,
                    Bloqueado = false,
                    LoginIntentos = 0,
                    PasswordDias = 0,
                    Usuario = "sistemas",
                    Password = "UABAAHMAcwB3ADAAcgBkAA=="
                });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
