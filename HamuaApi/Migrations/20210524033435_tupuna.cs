using Microsoft.EntityFrameworkCore.Migrations;

namespace HamuaRegistrationApi.Migrations
{
    public partial class tupuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tupuna",
                columns: table => new
                {
                    TupunaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UriTangataId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryIwi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryHapu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tupuna", x => x.TupunaId);
                    table.ForeignKey(
                        name: "FK_Tupuna_NgaTangata_UriTangataId",
                        column: x => x.UriTangataId,
                        principalTable: "NgaTangata",
                        principalColumn: "TangataId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "NgaMarae",
                keyColumn: "MaraeId",
                keyValue: 38,
                column: "Name",
                value: "Maungapōhatu");

            migrationBuilder.CreateIndex(
                name: "IX_Tupuna_UriTangataId",
                table: "Tupuna",
                column: "UriTangataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tupuna");

            migrationBuilder.UpdateData(
                table: "NgaMarae",
                keyColumn: "MaraeId",
                keyValue: 38,
                column: "Name",
                value: "ManungapōhatuT");
        }
    }
}
