using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class updatedDatabaseseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Rooms_RoomId",
                table: "HotelRoom");

            migrationBuilder.DropIndex(
                name: "IX_HotelRoom_RoomId",
                table: "HotelRoom");

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "HotelId", "RoomNumber", "Rate", "RoomId" },
                values: new object[] { 1, 1, 0m, 0 });

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "HotelId", "RoomNumber", "Rate", "RoomId" },
                values: new object[] { 2, 2, 0m, 0 });

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "HotelId", "RoomNumber", "Rate", "RoomId" },
                values: new object[] { 3, 3, 0m, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomId",
                table: "HotelRoom",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Rooms_RoomId",
                table: "HotelRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
