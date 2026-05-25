using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StandUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Top5HardeningPhase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TemplateVersion",
                table: "ProposalDocuments",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Brand_Model",
                table: "Vehicles",
                columns: new[] { "Brand", "Model" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_IsSold_Kilometers",
                table: "Vehicles",
                columns: new[] { "IsSold", "Kilometers" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_IsSold_Price",
                table: "Vehicles",
                columns: new[] { "IsSold", "Price" });

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_TransactionDate",
                table: "SaleTransactions",
                column: "TransactionDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_Brand_Model",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_IsSold_Kilometers",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_IsSold_Price",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_SaleTransactions_TransactionDate",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "TemplateVersion",
                table: "ProposalDocuments");
        }
    }
}
