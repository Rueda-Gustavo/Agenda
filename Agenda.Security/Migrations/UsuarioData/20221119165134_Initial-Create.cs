using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Security.Migrations.UsuarioData
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    RefreshToken = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Roles = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "NomeCompleto", "NomeUsuario", "Password", "RefreshToken", "RefreshTokenExpiryTime", "Roles" },
                values: new object[] { 1, "gustavo@gmail.com", "Gustavo Rueda dos Reis", "gustavo", "1234", null, null, "Professor" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "NomeCompleto", "NomeUsuario", "Password", "RefreshToken", "RefreshTokenExpiryTime", "Roles" },
                values: new object[] { 2, "visit@gmail.com", "Visitante1", "visit", "4321", null, null, "Visitante" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
