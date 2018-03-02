using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MusicChart.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimiliarMaps",
                columns: table => new
                {
                    SimiliarMapId = table.Column<string>(nullable: false),
                    SimiliarSingerId = table.Column<string>(nullable: true),
                    SingerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimiliarMaps", x => x.SimiliarMapId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimiliarMaps");
        }
    }
}
