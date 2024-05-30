using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticManagement.Migrations
{
    /// <inheritdoc />
    public partial class permit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermitRemaining",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermitRemaining",
                table: "Users");
        }
    }
}
