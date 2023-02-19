using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dota2_Shop.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artifacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtifactImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtifactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtifactBonus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtifactCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArtifactDisription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artifacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroRole = table.Column<int>(type: "int", nullable: false),
                    StreghtAttributes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgilityAttributes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntelligenceAttributes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstAbility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondAbility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdAbility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltimateAbility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroBio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    PartOfSet = table.Column<int>(type: "int", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Heros_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_HeroId",
                table: "Items",
                column: "HeroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artifacts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Heros");
        }
    }
}
