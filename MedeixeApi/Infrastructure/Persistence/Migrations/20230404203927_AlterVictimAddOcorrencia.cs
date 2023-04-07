using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedeixeApi.Infrastructure.Persistence.Migrations
{
    public partial class AlterVictimAddOcorrencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Victims");

            migrationBuilder.CreateTable(
                name: "Vitimas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContatoEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedidaProtetiva = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitimas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OcorrenciasViolenciaDomestica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraFinalizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longititude = table.Column<float>(type: "real", nullable: false),
                    DescricaoCaso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAgressao = table.Column<int>(type: "int", nullable: false),
                    NivelPrioridade = table.Column<int>(type: "int", nullable: false),
                    StatusAtendimento = table.Column<int>(type: "int", nullable: false),
                    VitimaId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcorrenciasViolenciaDomestica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcorrenciasViolenciaDomestica_Vitimas_VitimaId",
                        column: x => x.VitimaId,
                        principalTable: "Vitimas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OcorrenciasViolenciaDomestica_VitimaId",
                table: "OcorrenciasViolenciaDomestica",
                column: "VitimaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OcorrenciasViolenciaDomestica");

            migrationBuilder.DropTable(
                name: "Vitimas");

            migrationBuilder.CreateTable(
                name: "Victims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProtectiveMeasure = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victims", x => x.Id);
                });
        }
    }
}
