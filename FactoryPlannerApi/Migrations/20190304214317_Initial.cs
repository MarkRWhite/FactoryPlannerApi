using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryPlannerApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    SessionId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UpgradeProfiles",
                columns: table => new
                {
                    UpgradeProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfileName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Default = table.Column<bool>(nullable: false),
                    ServerPath = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: false),
                    FactoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpgradeProfiles", x => x.UpgradeProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    FactoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerUserId = table.Column<int>(nullable: false),
                    FactoryName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    UpgradeProfileId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    DisplayPath = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    ServerPath = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.FactoryId);
                    table.ForeignKey(
                        name: "FK_Factories_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factories_UpgradeProfiles_UpgradeProfileId",
                        column: x => x.UpgradeProfileId,
                        principalTable: "UpgradeProfiles",
                        principalColumn: "UpgradeProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factories_OwnerUserId",
                table: "Factories",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Factories_UpgradeProfileId",
                table: "Factories",
                column: "UpgradeProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UpgradeProfiles_FactoryId",
                table: "UpgradeProfiles",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeProfiles_Factories_FactoryId",
                table: "UpgradeProfiles",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "FactoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factories_Users_OwnerUserId",
                table: "Factories");

            migrationBuilder.DropForeignKey(
                name: "FK_Factories_UpgradeProfiles_UpgradeProfileId",
                table: "Factories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UpgradeProfiles");

            migrationBuilder.DropTable(
                name: "Factories");
        }
    }
}
