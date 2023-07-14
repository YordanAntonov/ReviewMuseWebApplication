using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewMuse.Data.Migrations
{
    public partial class SeedingSecondaryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookCovers",
                columns: new[] { "Id", "CoverType" },
                values: new object[,]
                {
                    { 1, "E-book" },
                    { 2, "Paperback" },
                    { 3, "Hardcover" },
                    { 4, "Audiobook" }
                });

            migrationBuilder.InsertData(
                table: "BooksStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Reading" },
                    { 2, "Read" },
                    { 3, "Want to Read" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Description" },
                values: new object[] { 52, "Bulgarian Literature", "Discover the captivating world of Bulgarian literature, where the rich heritage, culture, and spirit of Bulgaria come alive through the written word. Bulgarian literature encompasses a diverse range of genres, from poetry and novels to short stories and plays. It reflects the unique Bulgarian identity, exploring themes of love, longing, resilience, and the complexities of human nature. Through vivid descriptions, evocative storytelling, and a deep connection to the country's history and folklore, Bulgarian literature offers a glimpse into the soul of Bulgaria. Whether delving into the timeless works of classic Bulgarian authors or exploring the vibrant contemporary literary scene, Bulgarian literature invites readers on a journey of discovery, where tradition, passion, and the beauty of the Bulgarian language converge. So immerse yourself in the pages of Bulgarian literature and let the words transport you to the enchanting landscapes, intriguing characters, and profound emotions that define this rich literary tradition." });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageName" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Bulgarian" },
                    { 3, "Spanish" },
                    { 4, "Hungarian" },
                    { 5, "Russian" },
                    { 6, "Portugese" },
                    { 7, "French" },
                    { 8, "Dutch" },
                    { 9, "Deutsche" },
                    { 10, "Norwegian" },
                    { 11, "Chinese" },
                    { 12, "Japanese" },
                    { 13, "Hindi" },
                    { 14, "Serbian" },
                    { 15, "Romanian" },
                    { 16, "Korean" },
                    { 17, "Croatian" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookCovers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookCovers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookCovers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookCovers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BooksStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BooksStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BooksStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 17);
        }
    }
}
