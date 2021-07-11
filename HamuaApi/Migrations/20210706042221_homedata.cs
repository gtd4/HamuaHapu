using Microsoft.EntityFrameworkCore.Migrations;

namespace HamuaRegistrationApi.Migrations
{
    public partial class homedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReturnToRuatokiToLive",
                table: "NgaTangata",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "HighestEducation",
                table: "NgaTangata",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberInHome",
                table: "NgaTangata",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "OwnHome",
                table: "NgaTangata",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestEducation",
                table: "NgaTangata");

            migrationBuilder.DropColumn(
                name: "NumberInHome",
                table: "NgaTangata");

            migrationBuilder.DropColumn(
                name: "OwnHome",
                table: "NgaTangata");

            migrationBuilder.AlterColumn<bool>(
                name: "ReturnToRuatokiToLive",
                table: "NgaTangata",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
