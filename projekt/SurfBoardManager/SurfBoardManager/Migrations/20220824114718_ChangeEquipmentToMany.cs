using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfBoardManager.Migrations
{
    public partial class ChangeEquipmentToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Board_BoardId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "BoardType",
                table: "Board");

            migrationBuilder.AlterColumn<int>(
                name: "BoardId",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BoardTypeId",
                table: "Board",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoardType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Board_BoardTypeId",
                table: "Board",
                column: "BoardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_PostId",
                table: "Equipment",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Board_BoardType_BoardTypeId",
                table: "Board",
                column: "BoardTypeId",
                principalTable: "BoardType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Board_BoardId",
                table: "Post",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_BoardType_BoardTypeId",
                table: "Board");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Board_BoardId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "BoardType");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Board_BoardTypeId",
                table: "Board");

            migrationBuilder.DropColumn(
                name: "BoardTypeId",
                table: "Board");

            migrationBuilder.AlterColumn<int>(
                name: "BoardId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Equipment",
                table: "Post",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoardType",
                table: "Board",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Board_BoardId",
                table: "Post",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
