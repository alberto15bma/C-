﻿// <auto-generated />
using System;
using ApiSistema.Modelos.Configuracion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiSistema.Migrations
{
    [DbContext(typeof(BDContext))]
    partial class BDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiSistema.Modelos.Configuracion.Tablas.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Estado");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "ACTIVO"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "INACTIVO"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "ELIMINADO"
                        });
                });

            modelBuilder.Entity("ApiSistema.Modelos.Configuracion.Tablas.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(60);

                    b.Property<int>("EstadoId");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Perfil");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "USUARIO",
                            EstadoId = 1
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "ADMINISTRADOR",
                            EstadoId = 1
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "SISTEMAS",
                            EstadoId = 1
                        });
                });

            modelBuilder.Entity("ApiSistema.Modelos.Configuracion.Tablas.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Apellidos")
                        .HasMaxLength(100);

                    b.Property<bool>("Bloqueado");

                    b.Property<string>("Cedula")
                        .HasMaxLength(13);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<byte[]>("Foto");

                    b.Property<bool>("InicioSesion");

                    b.Property<int>("LoginIntentos");

                    b.Property<string>("Nombres")
                        .HasMaxLength(100);

                    b.Property<bool>("Notificacion");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("PasswordDias");

                    b.Property<DateTime?>("PasswordFecha");

                    b.Property<int>("PerfilId");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Apellidos = "ADMIN",
                            Bloqueado = false,
                            Cedula = "123456789",
                            Email = "sistemas@sistemas.com",
                            FechaCreacion = new DateTime(2021, 8, 1, 23, 16, 19, 858, DateTimeKind.Local).AddTicks(3842),
                            FechaModificacion = new DateTime(2021, 8, 1, 23, 16, 19, 859, DateTimeKind.Local).AddTicks(9335),
                            InicioSesion = true,
                            LoginIntentos = 0,
                            Nombres = "ADMIN",
                            Notificacion = true,
                            Password = "UABAAHMAcwB3ADAAcgBkAA==",
                            PasswordDias = 0,
                            PerfilId = 3,
                            Usuario = "sistemas"
                        });
                });

            modelBuilder.Entity("ApiSistema.Modelos.Configuracion.Tablas.Perfil", b =>
                {
                    b.HasOne("ApiSistema.Modelos.Configuracion.Tablas.Estado", "estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiSistema.Modelos.Configuracion.Tablas.Usuarios", b =>
                {
                    b.HasOne("ApiSistema.Modelos.Configuracion.Tablas.Perfil", "perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
