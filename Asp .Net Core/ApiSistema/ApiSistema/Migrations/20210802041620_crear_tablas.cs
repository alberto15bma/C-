using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSistema.Migrations
{
    public partial class crear_tablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 60, nullable: true),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfil_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cedula = table.Column<string>(maxLength: 13, nullable: true),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: true),
                    Nombres = table.Column<string>(maxLength: 100, nullable: true),
                    Usuario = table.Column<string>(maxLength: 40, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    PasswordDias = table.Column<int>(nullable: false),
                    PasswordFecha = table.Column<DateTime>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Foto = table.Column<byte[]>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Bloqueado = table.Column<bool>(nullable: false),
                    Notificacion = table.Column<bool>(nullable: false),
                    InicioSesion = table.Column<bool>(nullable: false),
                    LoginIntentos = table.Column<int>(nullable: false),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 1, "ACTIVO" });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 2, "INACTIVO" });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 3, "ELIMINADO" });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "Descripcion", "EstadoId" },
                values: new object[] { 1, "USUARIO", 1 });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "Descripcion", "EstadoId" },
                values: new object[] { 2, "ADMINISTRADOR", 1 });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "Descripcion", "EstadoId" },
                values: new object[] { 3, "SISTEMAS", 1 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Activo", "Apellidos", "Bloqueado", "Cedula", "Email", "FechaCreacion", "FechaModificacion", "Foto", "InicioSesion", "LoginIntentos", "Nombres", "Notificacion", "Password", "PasswordDias", "PasswordFecha", "PerfilId", "Usuario" },
                values: new object[] { 1, true, "ADMIN", false, "123456789", "sistemas@sistemas.com", new DateTime(2021, 8, 1, 23, 16, 19, 858, DateTimeKind.Local).AddTicks(3842), new DateTime(2021, 8, 1, 23, 16, 19, 859, DateTimeKind.Local).AddTicks(9335), null, true, 0, "ADMIN", true, "UABAAHMAcwB3ADAAcgBkAA==", 0, null, 3, "sistemas" });

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_EstadoId",
                table: "Perfil",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
