using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class Removedincorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Hotels_HotelId",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_HotelRoom_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom");

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

            migrationBuilder.DropColumn(
                name: "HotelRoomHotelId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelRoom");

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomRoomNumber",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomId",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HotelRoom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom",
                columns: new[] { "Id", "RoomNumber" });

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "Id", "RoomNumber", "Rate", "RoomId" },
                values: new object[] { 1, 1, 0m, 0 });

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "Id", "RoomNumber", "Rate", "RoomId" },
                values: new object[] { 2, 2, 0m, 0 });

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "Id", "RoomNumber", "Rate", "RoomId" },
                values: new object[] { 3, 3, 0m, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelRoomId_HotelRoomRoomNumber",
                table: "Rooms",
                columns: new[] { "HotelRoomId", "HotelRoomRoomNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelRoomId_HotelRoomRoomNumber",
                table: "Hotels",
                columns: new[] { "HotelRoomId", "HotelRoomRoomNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_HotelRoom_HotelRoomId_HotelRoomRoomNumber",
                table: "Hotels",
                columns: new[] { "HotelRoomId", "HotelRoomRoomNumber" },
                principalTable: "HotelRoom",
                principalColumns: new[] { "Id", "RoomNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HotelRoom_HotelRoomId_HotelRoomRoomNumber",
                table: "Rooms",
                columns: new[] { "HotelRoomId", "HotelRoomRoomNumber" },
                principalTable: "HotelRoom",
                principalColumns: new[] { "Id", "RoomNumber" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_HotelRoom_HotelRoomId_HotelRoomRoomNumber",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HotelRoom_HotelRoomId_HotelRoomRoomNumber",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelRoomId_HotelRoomRoomNumber",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_HotelRoomId_HotelRoomRoomNumber",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom");

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "Id", "RoomNumber" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "Id", "RoomNumber" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "Id", "RoomNumber" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DropColumn(
                name: "HotelRoomId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HotelRoomRoomNumber",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HotelRoomId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HotelRoom");

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomHotelId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom",
                columns: new[] { "HotelId", "RoomNumber" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Hotels",
                columns: new[] { "HotelRoomHotelId", "HotelRoomRoomNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Hotels_HotelId",
                table: "HotelRoom",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_HotelRoom_HotelRoomHotelId_HotelRoomRoomNumber",
                table: "Hotels",
                columns: new[] { "HotelRoomHotelId", "HotelRoomRoomNumber" },
                principalTable: "HotelRoom",
                principalColumns: new[] { "HotelId", "RoomNumber" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
