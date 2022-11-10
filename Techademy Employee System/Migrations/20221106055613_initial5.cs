using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techademy_Employee_System.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_designation",
                table: "designation");

            migrationBuilder.DropColumn(
                name: "experience",
                table: "payments");

            migrationBuilder.AlterColumn<string>(
                name: "DesignationName",
                table: "designation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "designation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_designation",
                table: "designation",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_designation",
                table: "designation");

            migrationBuilder.DropColumn(
                name: "id",
                table: "designation");

            migrationBuilder.AddColumn<int>(
                name: "experience",
                table: "payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DesignationName",
                table: "designation",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_designation",
                table: "designation",
                column: "DesignationName");
        }
    }
}
