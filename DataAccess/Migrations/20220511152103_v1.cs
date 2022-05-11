using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yonetmenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Odul = table.Column<int>(type: "int", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yonetmenler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Aciklamasi = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Hasilat = table.Column<double>(type: "float", nullable: false),
                    Odul = table.Column<int>(type: "int", nullable: true),
                    GosterimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    YonetmenId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmler_Yonetmenler_YonetmenId",
                        column: x => x.YonetmenId,
                        principalTable: "Yonetmenler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmler_YonetmenId",
                table: "Filmler",
                column: "YonetmenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmler");

            migrationBuilder.DropTable(
                name: "Yonetmenler");
        }
    }
}
