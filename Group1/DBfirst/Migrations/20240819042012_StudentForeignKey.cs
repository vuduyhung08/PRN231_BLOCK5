using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBfirst.Migrations
{
    public partial class StudentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "Student",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_AccountId",
                table: "Student",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AspNetUsers_AccountId",
                table: "Student",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_AspNetUsers_AccountId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_AccountId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
