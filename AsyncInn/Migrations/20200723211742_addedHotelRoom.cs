using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addedHotelRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelRoomHotelId",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomRoomNumber",
                table: "Hotels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Hotels",
                columns: new[] { "HotelRoomHotelId", "HotelRoomRoomNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_HotelRoom_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Hotels",
                columns: new[] { "HotelRoomHotelId", "HotelRoomRoomNumber" },
                principalTable: "HotelRoom",
                principalColumns: new[] { "HotelId", "RoomNumber" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_HotelRoom_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HotelRoomHotelId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HotelRoomRoomNumber",
                table: "Hotels");
        }
    }
}
