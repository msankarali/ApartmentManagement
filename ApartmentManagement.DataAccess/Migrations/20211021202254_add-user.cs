using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentManagement.DataAccess.Migrations
{
    public partial class adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "FullName", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "Kenân", new byte[] { 188, 157, 223, 146, 228, 212, 57, 210, 58, 46, 72, 148, 55, 62, 147, 70, 182, 136, 194, 160, 94, 240, 87, 79, 176, 140, 68, 111, 144, 109, 105, 53, 209, 86, 228, 196, 171, 5, 132, 31, 204, 238, 170, 158, 3, 137, 5, 151, 232, 23, 88, 60, 145, 131, 36, 174, 248, 181, 173, 26, 51, 252, 22, 85 }, new byte[] { 80, 136, 226, 28, 66, 179, 211, 114, 63, 42, 129, 248, 40, 53, 81, 215, 75, 248, 23, 125, 217, 110, 91, 179, 103, 60, 11, 206, 174, 113, 103, 245, 26, 238, 188, 215, 12, 137, 194, 227, 97, 183, 165, 252, 88, 101, 72, 25, 112, 59, 55, 203, 227, 231, 137, 244, 123, 133, 21, 120, 232, 111, 13, 107, 235, 173, 209, 219, 114, 23, 227, 105, 216, 9, 68, 89, 85, 211, 229, 17, 72, 196, 52, 60, 106, 146, 7, 114, 182, 164, 13, 42, 102, 106, 80, 129, 11, 180, 91, 232, 206, 249, 11, 159, 247, 53, 144, 30, 192, 51, 52, 174, 95, 255, 186, 172, 9, 32, 242, 44, 5, 61, 113, 75, 106, 194, 183, 62 } });

            migrationBuilder.InsertData(
                table: "Occupants",
                columns: new[] { "Id", "CarPlate", "FullName", "IdentityNumber", "IsCarOwner", "IsDeleted", "Mail", "PasswordHash", "PasswordSalt", "PhoneNumber" },
                values: new object[] { 1, "EY 146", "Servet", "48704870487", true, false, "mservetankarali@gmail.com", new byte[] { 174, 23, 0, 164, 10, 248, 54, 59, 209, 71, 231, 151, 74, 174, 17, 177, 100, 72, 82, 206, 43, 17, 119, 199, 20, 213, 99, 146, 5, 32, 1, 27, 20, 45, 90, 55, 10, 7, 180, 233, 74, 104, 192, 183, 60, 218, 36, 26, 18, 204, 35, 154, 243, 116, 58, 174, 81, 99, 101, 171, 54, 117, 207, 199 }, new byte[] { 242, 240, 35, 238, 166, 53, 24, 228, 63, 240, 55, 249, 215, 40, 59, 197, 99, 65, 143, 99, 57, 161, 184, 30, 123, 151, 163, 53, 56, 33, 24, 238, 146, 223, 164, 110, 192, 182, 195, 119, 154, 41, 144, 153, 205, 22, 233, 246, 205, 66, 85, 135, 57, 107, 81, 14, 203, 62, 79, 219, 233, 137, 176, 161, 102, 97, 161, 1, 9, 100, 247, 24, 1, 55, 116, 133, 186, 54, 115, 151, 195, 100, 168, 213, 129, 123, 58, 44, 28, 171, 240, 28, 140, 183, 43, 93, 166, 145, 23, 220, 245, 148, 123, 11, 243, 254, 50, 82, 54, 145, 163, 94, 82, 72, 225, 234, 191, 201, 254, 80, 11, 102, 91, 75, 44, 226, 45, 175 }, "541 969 2951" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Occupants",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
