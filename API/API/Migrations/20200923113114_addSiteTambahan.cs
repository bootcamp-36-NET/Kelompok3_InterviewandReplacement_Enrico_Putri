using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addSiteTambahan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TB_M_Site",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "TB_M_Site",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "TB_M_Site");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "TB_M_Site");
        }
    }
}
