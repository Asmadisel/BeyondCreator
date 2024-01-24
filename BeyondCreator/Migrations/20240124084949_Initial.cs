using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeyondCreator.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false),
                    ArmorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmorBonus = table.Column<int>(type: "int", nullable: false),
                    ArmorMaterialLvl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strenght = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Perseption = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false),
                    Intellegence = table.Column<int>(type: "int", nullable: false),
                    Vitality = table.Column<int>(type: "int", nullable: false),
                    Will = table.Column<int>(type: "int", nullable: false),
                    Lvl = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Advantage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Advantage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Advantage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disadvantage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disadvantage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disadvantage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadArmour = table.Column<int>(type: "int", nullable: false),
                    BodyArmour = table.Column<int>(type: "int", nullable: false),
                    ArmsArmour = table.Column<int>(type: "int", nullable: false),
                    LegsArmour = table.Column<int>(type: "int", nullable: false),
                    BonusArmour = table.Column<int>(type: "int", nullable: false),
                    Resistance = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ritual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ritual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hardness = table.Column<int>(type: "int", nullable: false),
                    Durability = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialLvl = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attack_type = table.Column<int>(type: "int", nullable: false),
                    AvailabilityLevel = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<int>(type: "int", nullable: false),
                    BaseCraftDifficulty = table.Column<int>(type: "int", nullable: false),
                    AttackDistance = table.Column<int>(type: "int", nullable: false),
                    AttackDist = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponType", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armor");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Dice");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Ritual");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "Thing");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "WeaponMaterial");

            migrationBuilder.DropTable(
                name: "WeaponProperty");

            migrationBuilder.DropTable(
                name: "WeaponType");
        }
    }
}
