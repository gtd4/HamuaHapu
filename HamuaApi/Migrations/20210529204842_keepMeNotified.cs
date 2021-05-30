using Microsoft.EntityFrameworkCore.Migrations;

namespace HamuaRegistrationApi.Migrations
{
    public partial class keepMeNotified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KeepMeNotified",
                table: "NgaTangata",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeepMeNotified",
                table: "NgaTangata");
        }
    }
}
