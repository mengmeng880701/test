using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class 調整備註為空字段 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Major",
                type: "text",
                nullable: true,
                comment: "Description",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Club",
                type: "text",
                nullable: true,
                comment: "Description",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Major",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Description",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Club",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Description",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Description");
        }
    }
}
