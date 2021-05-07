using Microsoft.EntityFrameworkCore.Migrations;

namespace HamuaRegistrationApi.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NgaMarae",
                columns: table => new
                {
                    MaraeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hapu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TangataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgaMarae", x => x.MaraeId);
                });

            migrationBuilder.CreateTable(
                name: "NgaTangata",
                columns: table => new
                {
                    TangataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hapu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaraeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgaTangata", x => x.TangataId);
                });

            migrationBuilder.CreateTable(
                name: "MaraeTangata",
                columns: table => new
                {
                    NgaMaraeMaraeId = table.Column<int>(type: "int", nullable: false),
                    NgaTangataTangataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaraeTangata", x => new { x.NgaMaraeMaraeId, x.NgaTangataTangataId });
                    table.ForeignKey(
                        name: "FK_MaraeTangata_NgaMarae_NgaMaraeMaraeId",
                        column: x => x.NgaMaraeMaraeId,
                        principalTable: "NgaMarae",
                        principalColumn: "MaraeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaraeTangata_NgaTangata_NgaTangataTangataId",
                        column: x => x.NgaTangataTangataId,
                        principalTable: "NgaTangata",
                        principalColumn: "TangataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NgaMarae",
                columns: new[] { "MaraeId", "Area", "Hapu", "Name", "TangataId" },
                values: new object[,]
                {
                    { 1, "Rūātoki", "Ngāti Tāwhaki", "Ngāhina", 0 },
                    { 22, "Waikaremoana", "Ngāti Ruapani ki Waikaremoana Ngāti Hinekura", "Te Kūhā Tārewa", 0 },
                    { 23, "Waikaremoana", "Te Whānau Pani", "Waimako", 0 },
                    { 24, "Waiōhau", "Ngāti Haka Patuheuheu", "Waiōhau", 0 },
                    { 25, "Waimana", "Ngāti Kōura", "Kahikatea", 0 },
                    { 26, "Waimana", "Tūranga Pikitoi", "Kutarere", 0 },
                    { 27, "Waimana", "Ngāi Tamatea", "Maromahue", 0 },
                    { 28, "Waimana", "Ngāi Tamatuhirae", "Matahī", 0 },
                    { 29, "Waimana", "Ngāi Tātua Tamakaimoana", "Piripari", 0 },
                    { 30, "Waimana", "Ngāti Rere", "Rāhiri", 0 },
                    { 31, "Waimana", "Tamaruarangi", "Rāroa", 0 },
                    { 32, "Waimana", "Ngāti Rere", "Tanatana", 0 },
                    { 33, "Waimana", "Ngāti Raka", "Tātaiāhape", 0 },
                    { 34, "Waimana", "Te Whakatāne", "Tauanui", 0 },
                    { 35, "Waimana", "Tūranga Pikitoi')", "Te Pou a Hīnau", 0 },
                    { 36, "Waimana", "Tamakaimoana", "Tuapō", 0 },
                    { 21, "Te Whāiti", "Te Karaha Warahoe", "Waikotikoti", 0 },
                    { 20, "Ruatāhuna", "Ngāi Te Paena", "Uwhiārae", 0 },
                    { 19, "Ruatāhuna", "Kākahu Tāpiki", "Tīpapa", 0 },
                    { 18, "Ruatāhuna", "Ngāti Kurīkino", "Te Wai-iti", 0 },
                    { 2, "Rūātoki", "Te Whānau Pani", "Ōhotu", 0 },
                    { 3, "Rūātoki", "Ngāti Kōura", "Ōtenuku", 0 },
                    { 4, "Rūātoki", "Ngāti Rongo", "Ōwhakatoro", 0 },
                    { 5, "Rūātoki", "Ngāti Rongo", "Paneteure", 0 },
                    { 6, "Rūātok", "Ngāti Kōura", "Papakāinga", 0 },
                    { 7, "Rūātoki", "Te Māhurehure", "Te Rewarewa", 0 },
                    { 8, "Rūātoki", "Ngāti Rongo", "Tauarau", 0 },
                    { 37, "Waimana", "Te Whakatāne", "Whakara", 0 },
                    { 9, "Rūātoki", "Ngāti Mura", "Te Poho o Te Rangimōnoa", 0 },
                    { 11, "Ruatāhuna", "Te Urewera", "Mātatua", 0 },
                    { 12, "Ruatāhuna", "Ngāti Rongo", "Ōhāua", 0 },
                    { 13, "Ruatāhuna", "Ngāti Tāwhaki", "Ōpūtao", 0 },
                    { 14, "Ruatāhuna", "Tamakaimoana", "Ōtekura", 0 },
                    { 15, "Ruatāhuna", "Ngāti Tāwhaki", "Pāpueru", 0 },
                    { 16, "Ruatāhuna", "Ngāi Te Riu", "Tātāhoata", 0 },
                    { 17, "Ruatāhuna", "Ngāti Manunui", "Te Umuroa", 0 },
                    { 10, "Rūātoki", "Te Urewera", "Te Tōtara", 0 },
                    { 38, "Maungapōhatu", "Tamakaimoana Ngāti Huri", "ManungapōhatuT", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaraeTangata_NgaTangataTangataId",
                table: "MaraeTangata",
                column: "NgaTangataTangataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaraeTangata");

            migrationBuilder.DropTable(
                name: "NgaMarae");

            migrationBuilder.DropTable(
                name: "NgaTangata");
        }
    }
}
