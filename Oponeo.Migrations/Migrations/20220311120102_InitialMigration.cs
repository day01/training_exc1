using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oponeo.Migrations.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExampleObjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StringValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IntValue = table.Column<int>(type: "int", precision: 19, scale: 2, nullable: false),
                    DecimalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExampleStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubExampleObject",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ExampleObjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubExampleObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubExampleObject_ExampleObjects_ExampleObjectId",
                        column: x => x.ExampleObjectId,
                        principalTable: "ExampleObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubExampleObject_ExampleObjectId",
                table: "SubExampleObject",
                column: "ExampleObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubExampleObject");

            migrationBuilder.DropTable(
                name: "ExampleObjects");
        }
    }
}
