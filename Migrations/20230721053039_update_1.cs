using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyPhanTu.Migrations
{
    /// <inheritdoc />
    public partial class update_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PhanTu",
                columns: new[] { "phatTuId", "Role", "anhChup", "chuaId", "daHoanTuc", "email", "gioiTinh", "ho", "isActive", "kieuThanhVienId", "ngayCapNhap", "ngayHoanTuc", "ngaySinh", "ngayXuatGia", "password", "phapDanh", "soDienThoai", "ten", "tenDem" },
                values: new object[,]
                {
                    { 2, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 3, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 4, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 5, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 6, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 7, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 8, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 9, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 10, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 11, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 12, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 13, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 14, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 15, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 16, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 17, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 18, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 19, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 19);
        }
    }
}
