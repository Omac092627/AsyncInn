using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addedHotelRoomAmenityBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AmenityForRoom",
                columns: new[] { "AmenitiesId", "RoomId", "AmenityId" },
                values: new object[] { 1, 1, null });

            migrationBuilder.InsertData(
                table: "AmenityForRoom",
                columns: new[] { "AmenitiesId", "RoomId", "AmenityId" },
                values: new object[] { 2, 2, null });

            migrationBuilder.InsertData(
                table: "AmenityForRoom",
                columns: new[] { "AmenitiesId", "RoomId", "AmenityId" },
                values: new object[] { 3, 3, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AmenityForRoom",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AmenityForRoom",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AmenityForRoom",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
