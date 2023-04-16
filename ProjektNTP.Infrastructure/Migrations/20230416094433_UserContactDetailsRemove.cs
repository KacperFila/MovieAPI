using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektNTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserContactDetailsRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersContactDetails_UserContactDetailsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UsersContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserContactDetailsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserContactDetailsId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserContactDetailsId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UsersContactDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersContactDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserContactDetailsId",
                table: "Users",
                column: "UserContactDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersContactDetails_UserContactDetailsId",
                table: "Users",
                column: "UserContactDetailsId",
                principalTable: "UsersContactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
