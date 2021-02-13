using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RehberApi.Migrations
{
    public partial class EditTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "People",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "ContactInfos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "People");

            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "ContactInfos");
        }
    }
}
