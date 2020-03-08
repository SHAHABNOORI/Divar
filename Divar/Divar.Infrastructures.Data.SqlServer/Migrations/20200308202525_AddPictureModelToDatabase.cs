using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divar.Infrastructures.Data.SqlServer.Migrations
{
    public partial class AddPictureModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Size_Height = table.Column<int>(nullable: true),
                    Size_Width = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    AdvertisementId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Picture_AdvertisementId",
                table: "Picture",
                column: "AdvertisementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picture");
        }
    }
}
