using Microsoft.EntityFrameworkCore.Migrations;

namespace RehberApi.Migrations
{
    public partial class EditTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_People_PersonID",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "ContactInfos");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_PersonID",
                table: "ContactInfos",
                newName: "IX_ContactInfos_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInfos",
                table: "ContactInfos",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_People_PersonID",
                table: "ContactInfos",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfos_People_PersonID",
                table: "ContactInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInfos",
                table: "ContactInfos");

            migrationBuilder.RenameTable(
                name: "ContactInfos",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_ContactInfos_PersonID",
                table: "Contacts",
                newName: "IX_Contacts_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_People_PersonID",
                table: "Contacts",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
