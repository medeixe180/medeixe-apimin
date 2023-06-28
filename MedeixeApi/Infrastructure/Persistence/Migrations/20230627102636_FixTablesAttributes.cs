using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedeixeApi.Infrastructure.Persistence.Migrations
{
    public partial class FixTablesAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHoraAtendimento",
                table: "Ocorrencias");

            migrationBuilder.DropColumn(
                name: "DataHoraFinalizacao",
                table: "Ocorrencias");

            migrationBuilder.DropColumn(
                name: "DescricaoCaso",
                table: "Ocorrencias");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Vitimas",
                newName: "IdentidadeGenero");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Movimentacoes",
                newName: "StatusId");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusInicial = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_StatusId",
                table: "Movimentacoes",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Status_StatusId",
                table: "Movimentacoes",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Status_StatusId",
                table: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacoes_StatusId",
                table: "Movimentacoes");

            migrationBuilder.RenameColumn(
                name: "IdentidadeGenero",
                table: "Vitimas",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Movimentacoes",
                newName: "Status");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAtendimento",
                table: "Ocorrencias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraFinalizacao",
                table: "Ocorrencias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoCaso",
                table: "Ocorrencias",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
