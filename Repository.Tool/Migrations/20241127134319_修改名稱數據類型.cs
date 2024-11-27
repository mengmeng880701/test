using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class 修改名稱數據類型 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Student",
                type: "text",
                nullable: false,
                comment: "Name",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Name",
                table: "Student",
                type: "bigint",
                nullable: false,
                comment: "Name",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Name");
        }
    }
}
