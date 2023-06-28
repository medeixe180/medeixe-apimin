using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedeixeApi.Infrastructure.Persistence.Migrations
{
    public partial class AlterTableMovimentacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Usuarios_UsuarioId",
                table: "Movimentacoes");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Movimentacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Usuarios_UsuarioId",
                table: "Movimentacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Usuarios_UsuarioId",
                table: "Movimentacoes");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Movimentacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Usuarios_UsuarioId",
                table: "Movimentacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
