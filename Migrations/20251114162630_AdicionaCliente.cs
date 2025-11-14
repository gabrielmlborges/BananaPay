using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BananaPay.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contas_CpfDono",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "CpfDono",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "NomeDono",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Contas");

            migrationBuilder.AddColumn<int>(
                name: "ClienteID",
                table: "Contas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDono = table.Column<string>(type: "TEXT", nullable: true),
                    CpfDono = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_ClienteID",
                table: "Contas",
                column: "ClienteID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_ClienteID",
                table: "Contas",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_ClienteID",
                table: "Contas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Contas_ClienteID",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "ClienteID",
                table: "Contas");

            migrationBuilder.AddColumn<string>(
                name: "CpfDono",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeDono",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_CpfDono",
                table: "Contas",
                column: "CpfDono",
                unique: true);
        }
    }
}
