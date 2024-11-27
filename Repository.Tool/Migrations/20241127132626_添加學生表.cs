using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class 添加學生表 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "主键标识ID"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    Description = table.Column<string>(type: "text", nullable: false, comment: "Description"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, comment: "是否删除"),
                    DeleteTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "删除时间"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false, comment: "行版本标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                },
                comment: "TClub");

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "主键标识ID"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    Description = table.Column<string>(type: "text", nullable: false, comment: "Description"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, comment: "是否删除"),
                    DeleteTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "删除时间"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false, comment: "行版本标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.Id);
                },
                comment: "TMajor");

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "主键标识ID"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    Phone = table.Column<string>(type: "text", nullable: false, comment: "Phone"),
                    Email = table.Column<string>(type: "text", nullable: false, comment: "Email"),
                    MajorId = table.Column<long>(type: "bigint", nullable: false, comment: "MajorId"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, comment: "是否删除"),
                    DeleteTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "删除时间"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false, comment: "行版本标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "TTeacher");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "主键标识ID"),
                    Name = table.Column<long>(type: "bigint", nullable: false, comment: "Name"),
                    Phone = table.Column<string>(type: "text", nullable: false, comment: "Phone"),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false, comment: "導師信息"),
                    MajorId = table.Column<long>(type: "bigint", nullable: false, comment: "專業信息"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, comment: "是否删除"),
                    DeleteTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "删除时间"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false, comment: "行版本标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "TStudent");

            migrationBuilder.CreateTable(
                name: "ClubStudent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "主键标识ID"),
                    ClubId = table.Column<long>(type: "bigint", nullable: false, comment: "社團信息"),
                    StudentId = table.Column<long>(type: "bigint", nullable: false, comment: "成員信息"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, comment: "是否删除"),
                    DeleteTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "删除时间"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false, comment: "行版本标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubStudent_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClubStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "社團成員信息");

            migrationBuilder.CreateIndex(
                name: "IX_Club_CreateTime",
                table: "Club",
                column: "CreateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Club_DeleteTime",
                table: "Club",
                column: "DeleteTime");

            migrationBuilder.CreateIndex(
                name: "IX_ClubStudent_ClubId",
                table: "ClubStudent",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubStudent_CreateTime",
                table: "ClubStudent",
                column: "CreateTime");

            migrationBuilder.CreateIndex(
                name: "IX_ClubStudent_DeleteTime",
                table: "ClubStudent",
                column: "DeleteTime");

            migrationBuilder.CreateIndex(
                name: "IX_ClubStudent_StudentId",
                table: "ClubStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Major_CreateTime",
                table: "Major",
                column: "CreateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Major_DeleteTime",
                table: "Major",
                column: "DeleteTime");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CreateTime",
                table: "Student",
                column: "CreateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DeleteTime",
                table: "Student",
                column: "DeleteTime");

            migrationBuilder.CreateIndex(
                name: "IX_Student_MajorId",
                table: "Student",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_TeacherId",
                table: "Student",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_CreateTime",
                table: "Teacher",
                column: "CreateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DeleteTime",
                table: "Teacher",
                column: "DeleteTime");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_MajorId",
                table: "Teacher",
                column: "MajorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubStudent");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Major");
        }
    }
}
