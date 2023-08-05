using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhanTu.Migrations
{
    /// <inheritdoc />
    public partial class update_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "truTri",
                table: "Chuas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "truTri",
                table: "Chuas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
