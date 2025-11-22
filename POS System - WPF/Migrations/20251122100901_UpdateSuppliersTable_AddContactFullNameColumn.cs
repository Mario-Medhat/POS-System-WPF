using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_System___WPF.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSuppliersTable_AddContactFullNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactFullName",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactFullName",
                table: "Suppliers");
        }
    }
}
