using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContasApi.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorOriginal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDePagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiasDeAtraso = table.Column<int>(type: "int", nullable: false),
                    ValorCorrigido = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    RegraDeAtraso = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "DataDePagamento", "DataDeVencimento", "DiasDeAtraso", "Nome", "RegraDeAtraso", "ValorCorrigido", "ValorOriginal" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Internet", "", 129.90m, 129.90m },
                    { 2, new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Energia", "Multa de 2% + Juros de 0,1% ao dia", 511.00m, 500.00m },
                    { 3, new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Aluguel", "Multa de 3% + Juros de 0,2% ao dia", 1569.00m, 1500.00m },
                    { 4, new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Telefone", "Multa de 5% + Juros de 0,3% ao dia", 166.50m, 150.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
