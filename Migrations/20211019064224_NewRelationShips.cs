using Microsoft.EntityFrameworkCore.Migrations;

namespace DB_College_Management.Migrations
{
    public partial class NewRelationShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Students",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Courses",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentName",
                table: "Students",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentName",
                table: "Courses",
                column: "DepartmentName");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentName",
                table: "Courses",
                column: "DepartmentName",
                principalTable: "Departments",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentName",
                table: "Students",
                column: "DepartmentName",
                principalTable: "Departments",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentName",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentName",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentName",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentName",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Courses");
        }
    }
}
