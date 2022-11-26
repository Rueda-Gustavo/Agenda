using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CodigoCorEvento = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
            /*
            migrationBuilder.CreateTable(
                name: "UsuarioTeste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTeste", x => x.Id);
                });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "UsuarioTeste");
        }
    }
}
