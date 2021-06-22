using Microsoft.EntityFrameworkCore.Migrations;

namespace HamuaRegistrationApi.Migrations
{
    public partial class salaryRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalaryRange",
                table: "NgaTangata",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryRange",
                table: "NgaTangata");
        }
    }
}
