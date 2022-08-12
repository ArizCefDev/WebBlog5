using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migAdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "Work");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Admins",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "Work",
                table: "Admins",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Admins",
                newName: "Image");
        }
    }
}
