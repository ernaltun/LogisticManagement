using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticManagement.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Invoices",
                newName: "CustomerCusomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                newName: "IX_Invoices_CustomerCusomerId");

            migrationBuilder.AddColumn<int>(
                name: "CusomerId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerCusomerId",
                table: "Invoices",
                column: "CustomerCusomerId",
                principalTable: "Customers",
                principalColumn: "CusomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerCusomerId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CusomerId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "CustomerCusomerId",
                table: "Invoices",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_CustomerCusomerId",
                table: "Invoices",
                newName: "IX_Invoices_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CusomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
