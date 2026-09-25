using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge___5_Pet_Registry_API.Migrations
{
    /// <inheritdoc />
    public partial class StaffTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWorking",
                table: "Staff",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWorking",
                table: "Staff");
        }
    }
}
