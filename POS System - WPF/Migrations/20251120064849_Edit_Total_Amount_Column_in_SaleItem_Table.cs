using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_System___WPF.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Total_Amount_Column_in_SaleItem_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceAtSaleTime",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceAtSaleTime",
                table: "Sales");
        }
    }
}
