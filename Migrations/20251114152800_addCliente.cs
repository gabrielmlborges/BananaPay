using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BananaPay.Migrations
{
    /// <inheritdoc />
    public partial class addCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_ContaId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Transacoes");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Transacoes",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ContaDestinoId",
                table: "Transacoes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContaId1",
                table: "Transacoes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaDestinoId",
                table: "Transacoes",
                column: "ContaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaId1",
                table: "Transacoes",
                column: "ContaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_CpfDono",
                table: "Contas",
                column: "CpfDono",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_ContaDestinoId",
                table: "Transacoes",
                column: "ContaDestinoId",
                principalTable: "Contas",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_ContaId",
                table: "Transacoes",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_ContaId1",
                table: "Transacoes",
                column: "ContaId1",
                principalTable: "Contas",
                principalColumn: "ContaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_ContaDestinoId",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_ContaId",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_ContaId1",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ContaDestinoId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ContaId1",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Contas_CpfDono",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "ContaDestinoId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "ContaId1",
                table: "Transacoes");

            migrationBuilder.AlterColumn<int>(
                name: "Tipo",
                table: "Transacoes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 13);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Transacoes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_ContaId",
                table: "Transacoes",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
