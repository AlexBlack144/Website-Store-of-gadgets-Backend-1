using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessEF.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkAspNetUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FkGadgetsId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_FkAspNetUsersId",
                        column: x => x.FkAspNetUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Gadgets_FkGadgetsId",
                        column: x => x.FkGadgetsId,
                        principalTable: "Gadgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_FkAspNetUsersId",
                table: "Purchases",
                column: "FkAspNetUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_FkGadgetsId",
                table: "Purchases",
                column: "FkGadgetsId");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}
