using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techademy_Employee_System.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_workinghours",
                table: "workinghours");

            migrationBuilder.AlterColumn<double>(
                name: "EmployeeWorkingHours",
                table: "workinghours",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CompanyWorkingHours",
                table: "workinghours",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "workinghours",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workinghours",
                table: "workinghours",
                column: "id");

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workinghours",
                table: "workinghours");

            migrationBuilder.DropColumn(
                name: "id",
                table: "workinghours");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeWorkingHours",
                table: "workinghours",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyWorkingHours",
                table: "workinghours",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workinghours",
                table: "workinghours",
                column: "CompanyWorkingHours");
        }
    }
}
