using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfBoardManager.Migrations
{
    public partial class FixNonNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Equipment",
                table: "Post",
                type: "NVarChar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVarChar(255)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Equipment",
                table: "Post",
                type: "NVarChar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVarChar(255)",
                oldNullable: true);
        }
    }
}
