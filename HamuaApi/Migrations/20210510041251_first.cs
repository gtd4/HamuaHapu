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
                    Hapu = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialtySkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTeReoFirstLanguage = table.Column<bool>(type: "bit", nullable: false),
                    CanYouSpeakTeReo = table.Column<bool>(type: "bit", nullable: false),
                    TeReoProficiency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnToRuatokiToLive = table.Column<bool>(type: "bit", nullable: false),
                    ReturnComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "MaraeId", "Area", "Hapu", "Name" },
                values: new object[,]
                {
                    { 1, "Rūātoki", "Ngāti Tāwhaki", "Ngāhina" },
                    { 22, "Waikaremoana", "Ngāti Ruapani ki Waikaremoana Ngāti Hinekura", "Te Kūhā Tārewa" },
                    { 23, "Waikaremoana", "Te Whānau Pani", "Waimako" },
                    { 24, "Waiōhau", "Ngāti Haka Patuheuheu", "Waiōhau" },
                    { 25, "Waimana", "Ngāti Kōura", "Kahikatea" },
                    { 26, "Waimana", "Tūranga Pikitoi", "Kutarere" },
                    { 27, "Waimana", "Ngāi Tamatea", "Maromahue" },
                    { 28, "Waimana", "Ngāi Tamatuhirae", "Matahī" },
                    { 29, "Waimana", "Ngāi Tātua Tamakaimoana", "Piripari" },
                    { 30, "Waimana", "Ngāti Rere", "Rāhiri" },
                    { 31, "Waimana", "Tamaruarangi", "Rāroa" },
                    { 32, "Waimana", "Ngāti Rere", "Tanatana" },
                    { 33, "Waimana", "Ngāti Raka", "Tātaiāhape" },
                    { 34, "Waimana", "Te Whakatāne", "Tauanui" },
                    { 35, "Waimana", "Tūranga Pikitoi')", "Te Pou a Hīnau" },
                    { 36, "Waimana", "Tamakaimoana", "Tuapō" },
                    { 21, "Te Whāiti", "Te Karaha Warahoe", "Waikotikoti" },
                    { 20, "Ruatāhuna", "Ngāi Te Paena", "Uwhiārae" },
                    { 19, "Ruatāhuna", "Kākahu Tāpiki", "Tīpapa" },
                    { 18, "Ruatāhuna", "Ngāti Kurīkino", "Te Wai-iti" },
                    { 2, "Rūātoki", "Te Whānau Pani", "Ōhotu" },
                    { 3, "Rūātoki", "Ngāti Kōura", "Ōtenuku" },
                    { 4, "Rūātoki", "Ngāti Rongo", "Ōwhakatoro" },
                    { 5, "Rūātoki", "Ngāti Rongo", "Paneteure" },
                    { 6, "Rūātok", "Ngāti Kōura", "Papakāinga" },
                    { 7, "Rūātoki", "Te Māhurehure", "Te Rewarewa" },
                    { 8, "Rūātoki", "Ngāti Rongo", "Tauarau" },
                    { 37, "Waimana", "Te Whakatāne", "Whakara" },
                    { 9, "Rūātoki", "Ngāti Mura", "Te Poho o Te Rangimōnoa" },
                    { 11, "Ruatāhuna", "Te Urewera", "Mātatua" },
                    { 12, "Ruatāhuna", "Ngāti Rongo", "Ōhāua" },
                    { 13, "Ruatāhuna", "Ngāti Tāwhaki", "Ōpūtao" },
                    { 14, "Ruatāhuna", "Tamakaimoana", "Ōtekura" },
                    { 15, "Ruatāhuna", "Ngāti Tāwhaki", "Pāpueru" },
                    { 16, "Ruatāhuna", "Ngāi Te Riu", "Tātāhoata" },
                    { 17, "Ruatāhuna", "Ngāti Manunui", "Te Umuroa" },
                    { 10, "Rūātoki", "Te Urewera", "Te Tōtara" },
                    { 38, "Maungapōhatu", "Tamakaimoana Ngāti Huri", "ManungapōhatuT" }
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
