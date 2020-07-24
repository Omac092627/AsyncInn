using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class FixedRoutesForSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmenityForRoom_Amenities_AmenityId",
                table: "AmenityForRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_AmenityForRoom_Rooms_RoomId",
                table: "AmenityForRoom");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmenityForRoom",
                table: "AmenityForRoom");

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
                name: "HotelRoomRoomNumber",
                table: "Hotels");

            migrationBuilder.RenameTable(
                name: "HotelRoom",
                newName: "HotelRooms");

            migrationBuilder.RenameTable(
                name: "AmenityForRoom",
                newName: "RoomAmenities");

            migrationBuilder.RenameIndex(
                name: "IX_AmenityForRoom_RoomId",
                table: "RoomAmenities",
                newName: "IX_RoomAmenities_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_AmenityForRoom_AmenityId",
                table: "RoomAmenities",
                newName: "IX_RoomAmenities_AmenityId");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelRooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PetFriendly",
                table: "HotelRooms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities",
                columns: new[] { "AmenitiesId", "RoomId" });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomNumber", "Id", "PetFriendly", "Rate", "RoomId" },
                values: new object[] { 1, 100, 0, true, 10.00m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomId",
                table: "HotelRooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Hotels_HotelId",
                table: "HotelRooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Rooms_RoomId",
                table: "HotelRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenityId",
                table: "RoomAmenities",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomId",
                table: "RoomAmenities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Hotels_HotelId",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Rooms_RoomId",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenityId",
                table: "RoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomId",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_RoomId",
                table: "HotelRooms");

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 100 });

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "PetFriendly",
                table: "HotelRooms");

            migrationBuilder.RenameTable(
                name: "RoomAmenities",
                newName: "AmenityForRoom");

            migrationBuilder.RenameTable(
                name: "HotelRooms",
                newName: "HotelRoom");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenities_RoomId",
                table: "AmenityForRoom",
                newName: "IX_AmenityForRoom_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenities_AmenityId",
                table: "AmenityForRoom",
                newName: "IX_AmenityForRoom_AmenityId");

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomRoomNumber",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomRoomNumber",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmenityForRoom",
                table: "AmenityForRoom",
                columns: new[] { "AmenitiesId", "RoomId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom",
                columns: new[] { "Id", "RoomNumber" });

            migrationBuilder.InsertData(
                table: "AmenityForRoom",
                columns: new[] { "AmenitiesId", "RoomId", "AmenityId" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 2, null },
                    { 3, 3, null }
                });

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "Id", "RoomNumber", "Rate", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, 0m, 0 },
                    { 2, 2, 0m, 0 },
                    { 3, 3, 0m, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelRoomId_HotelRoomRoomNumber",
                table: "Rooms",
                columns: new[] { "HotelRoomId", "HotelRoomRoomNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelRoomId_HotelRoomRoomNumber",
                table: "Hotels",
                columns: new[] { "HotelRoomId", "HotelRoomRoomNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_AmenityForRoom_Amenities_AmenityId",
                table: "AmenityForRoom",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AmenityForRoom_Rooms_RoomId",
                table: "AmenityForRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
