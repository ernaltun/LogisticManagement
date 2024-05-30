using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticManagement.Migrations
{
    /// <inheritdoc />
    public partial class permit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permits",
                columns: table => new
                {
                    PermitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsApproval = table.Column<bool>(type: "bit", nullable: false),
                    PermitStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermitFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permits", x => x.PermitId);
                    table.ForeignKey(
                        name: "FK_Permits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permits_UserId",
                table: "Permits",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permits");
        }
    }
}
