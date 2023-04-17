using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.IO.UI.Site.Migrations { 
    /// <summary>
    /// Classe com o nome que foi dado no comando migration
    /// representa as ações do migration
    /// </summary>
    public partial class Inicial : Migration
    {
        // Método para aplicar o Migration e  Cria a tabela no db conforme a model Aluno e
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });
        }
        //Método para desfazer a migration e deletar a tabela
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
