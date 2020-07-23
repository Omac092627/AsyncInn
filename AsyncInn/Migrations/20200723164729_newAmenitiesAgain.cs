using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class newAmenitiesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmenityForRoom",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    AmenityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityForRoom", x => new { x.AmenitiesId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_AmenityForRoom_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AmenityForRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenityForRoom_AmenityId",
                table: "AmenityForRoom",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_AmenityForRoom_RoomId",
                table: "AmenityForRoom",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenityForRoom");
        }
    }
}
