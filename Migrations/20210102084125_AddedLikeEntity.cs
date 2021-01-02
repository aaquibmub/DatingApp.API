using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class AddedLikeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbLikes",
                columns: table => new
                {
                    LikerId = table.Column<int>(type: "INTEGER", nullable: false),
                    LikeeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbLikes", x => new { x.LikerId, x.LikeeId });
                    table.ForeignKey(
                        name: "FK_DbLikes_DbUsers_LikeeId",
                        column: x => x.LikeeId,
                        principalTable: "DbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbLikes_DbUsers_LikerId",
                        column: x => x.LikerId,
                        principalTable: "DbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbLikes_LikeeId",
                table: "DbLikes",
                column: "LikeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbLikes");
        }
    }
}
