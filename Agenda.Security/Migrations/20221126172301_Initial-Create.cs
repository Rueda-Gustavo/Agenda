using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Security.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioTeste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTeste", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UsuarioTeste",
                columns: new[] { "Id", "NomeCompleto", "NomeUsuario", "Password" },
                values: new object[] { 1, "Gustavo Rueda dos Reis", "gustavo", "1234" });

            migrationBuilder.InsertData(
                table: "UsuarioTeste",
                columns: new[] { "Id", "NomeCompleto", "NomeUsuario", "Password" },
                values: new object[] { 2, "Visitante1", "visit", "4321" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioTeste");
        }
    }
}
