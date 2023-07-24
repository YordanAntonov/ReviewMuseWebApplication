using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewMuse.Data.Migrations
{
    public partial class addedIsAcgtiveFieldsInMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UsersBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CategoriesBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CategoriesAuthors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AmazonUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AuthorsBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UsersBooks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CategoriesBooks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CategoriesAuthors");

            migrationBuilder.DropColumn(
                name: "AmazonUrl",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AuthorsBooks");
        }
    }
}
