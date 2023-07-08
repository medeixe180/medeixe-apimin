using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedeixeApi.Infrastructure.Persistence.Migrations
{
    public partial class RenameTablesAndFixAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Usuarios_UsuarioId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencias_Vitimas_VitimaId",
                table: "Ocorrencias");

            migrationBuilder.DropTable(
                name: "Vitimas");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NivelPrioridade",
                table: "Ocorrencias");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "VitimaId",
                table: "Ocorrencias",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocorrencias_VitimaId",
                table: "Ocorrencias",
                newName: "IX_Ocorrencias_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Movimentacoes",
                newName: "AtendenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentacoes_UsuarioId",
                table: "Movimentacoes",
                newName: "IX_Movimentacoes_AtendenteId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MedidaProtetiva",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NumeroTelefone",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Atendentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoAtendente = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendentes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Atendentes_AtendenteId",
                table: "Movimentacoes",
                column: "AtendenteId",
                principalTable: "Atendentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencias_Usuarios_UsuarioId",
                table: "Ocorrencias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Atendentes_AtendenteId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencias_Usuarios_UsuarioId",
                table: "Ocorrencias");

            migrationBuilder.DropTable(
                name: "Atendentes");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MedidaProtetiva",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NumeroTelefone",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Ocorrencias",
                newName: "VitimaId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocorrencias_UsuarioId",
                table: "Ocorrencias",
                newName: "IX_Ocorrencias_VitimaId");

            migrationBuilder.RenameColumn(
                name: "AtendenteId",
                table: "Movimentacoes",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentacoes_AtendenteId",
                table: "Movimentacoes",
                newName: "IX_Movimentacoes_UsuarioId");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NivelPrioridade",
                table: "Ocorrencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vitimas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContatoEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: true),
                    IdentidadeGenero = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedidaProtetiva = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitimas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Usuarios_UsuarioId",
                table: "Movimentacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencias_Vitimas_VitimaId",
                table: "Ocorrencias",
                column: "VitimaId",
                principalTable: "Vitimas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
