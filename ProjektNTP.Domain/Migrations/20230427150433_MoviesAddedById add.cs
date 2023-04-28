using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektNTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoviesAddedByIdadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddedById",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Movies");
        }
    }
}
