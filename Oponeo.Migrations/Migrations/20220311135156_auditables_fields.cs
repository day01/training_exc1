using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oponeo.Migrations.Migrations
{
    public partial class auditables_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Parameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Parameters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Parameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ExampleObjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ExampleObjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ExampleObjects");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ExampleObjects");
        }
    }
}
