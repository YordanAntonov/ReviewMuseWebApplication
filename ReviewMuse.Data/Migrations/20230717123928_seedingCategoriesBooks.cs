using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewMuse.Data.Migrations
{
    public partial class seedingCategoriesBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.InsertData(
                table: "CategoriesBooks",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("1049b652-3e53-4d71-ac09-eca3d9d9f7f6"), 1 },
                    { new Guid("1e004174-0070-40b5-afa5-cda5e2958929"), 1 },
                    { new Guid("27a14db5-ee4c-4d07-9dec-a6f2a8347ff1"), 1 },
                    { new Guid("88e662a2-0077-4f72-b79c-b3b3cceaa6cd"), 1 },
                    { new Guid("8e233224-1cac-458b-a93d-22976e9621df"), 1 },
                    { new Guid("9d83a3a7-44ab-49bb-ab7e-6d1610c57079"), 1 },
                    { new Guid("cc506971-44f0-4c9d-bfed-a49dfeebe97f"), 1 },
                    { new Guid("1049b652-3e53-4d71-ac09-eca3d9d9f7f6"), 2 },
                    { new Guid("43867201-ada9-48d0-992a-e892d0dcd1b3"), 2 },
                    { new Guid("9c466385-2f0f-45e1-a3e8-974018d091cf"), 2 },
                    { new Guid("cd20df78-3771-44b3-84cb-1fab11c820bd"), 2 },
                    { new Guid("ef478645-3611-4395-bc9c-8d133eb47db4"), 2 },
                    { new Guid("1049b652-3e53-4d71-ac09-eca3d9d9f7f6"), 3 },
                    { new Guid("cc506971-44f0-4c9d-bfed-a49dfeebe97f"), 3 },
                    { new Guid("cc506971-44f0-4c9d-bfed-a49dfeebe97f"), 4 },
                    { new Guid("1e004174-0070-40b5-afa5-cda5e2958929"), 5 },
                    { new Guid("27a14db5-ee4c-4d07-9dec-a6f2a8347ff1"), 5 },
                    { new Guid("43867201-ada9-48d0-992a-e892d0dcd1b3"), 5 },
                    { new Guid("88e662a2-0077-4f72-b79c-b3b3cceaa6cd"), 5 },
                    { new Guid("8e233224-1cac-458b-a93d-22976e9621df"), 5 },
                    { new Guid("9c466385-2f0f-45e1-a3e8-974018d091cf"), 5 },
                    { new Guid("cc506971-44f0-4c9d-bfed-a49dfeebe97f"), 5 },
                    { new Guid("ef478645-3611-4395-bc9c-8d133eb47db4"), 5 },
                    { new Guid("9d83a3a7-44ab-49bb-ab7e-6d1610c57079"), 6 },
                    { new Guid("1049b652-3e53-4d71-ac09-eca3d9d9f7f6"), 7 },
                    { new Guid("15ceb205-5c7f-47bc-bc7a-cc4513bf69a6"), 7 },
                    { new Guid("1e004174-0070-40b5-afa5-cda5e2958929"), 7 },
                    { new Guid("58403cca-47b4-4413-b71d-d0376027591b"), 7 },
                    { new Guid("6af48184-d368-4ed1-8e95-8628acce7fcb"), 7 },
                    { new Guid("88e662a2-0077-4f72-b79c-b3b3cceaa6cd"), 7 },
                    { new Guid("8e233224-1cac-458b-a93d-22976e9621df"), 7 },
                    { new Guid("9d83a3a7-44ab-49bb-ab7e-6d1610c57079"), 7 },
                    { new Guid("a9ec87ae-49ac-4c8a-b132-70c1450e7b04"), 7 },
                    { new Guid("cc506971-44f0-4c9d-bfed-a49dfeebe97f"), 7 },
                    { new Guid("cd20df78-3771-44b3-84cb-1fab11c820bd"), 7 },
                    { new Guid("88e662a2-0077-4f72-b79c-b3b3cceaa6cd"), 8 },
                    { new Guid("9d83a3a7-44ab-49bb-ab7e-6d1610c57079"), 8 },
                    { new Guid("cc506971-44f0-4c9d-bfed-a49dfeebe97f"), 8 },
                    { new Guid("1e004174-0070-40b5-afa5-cda5e2958929"), 9 },
                    { new Guid("27a14db5-ee4c-4d07-9dec-a6f2a8347ff1"), 9 },
                    { new Guid("8e233224-1cac-458b-a93d-22976e9621df"), 9 },
                    { new Guid("a9ec87ae-49ac-4c8a-b132-70c1450e7b04"), 9 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBooks",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("58403cca-47b4-4413-b71d-d0376027591b"), 12 },
                    { new Guid("1e004174-0070-40b5-afa5-cda5e2958929"), 13 },
                    { new Guid("27a14db5-ee4c-4d07-9dec-a6f2a8347ff1"), 13 },
                    { new Guid("8e233224-1cac-458b-a93d-22976e9621df"), 13 },
                    { new Guid("a9ec87ae-49ac-4c8a-b132-70c1450e7b04"), 13 },
                    { new Guid("15ceb205-5c7f-47bc-bc7a-cc4513bf69a6"), 14 },
                    { new Guid("6af48184-d368-4ed1-8e95-8628acce7fcb"), 14 },
                    { new Guid("94480496-b29d-43e7-ad97-f8cf3b5df297"), 14 },
                    { new Guid("15ceb205-5c7f-47bc-bc7a-cc4513bf69a6"), 19 },
                    { new Guid("58403cca-47b4-4413-b71d-d0376027591b"), 19 },
                    { new Guid("6af48184-d368-4ed1-8e95-8628acce7fcb"), 19 },
                    { new Guid("94480496-b29d-43e7-ad97-f8cf3b5df297"), 19 },
                    { new Guid("cd20df78-3771-44b3-84cb-1fab11c820bd"), 19 },
                    { new Guid("43867201-ada9-48d0-992a-e892d0dcd1b3"), 24 },
                    { new Guid("9c466385-2f0f-45e1-a3e8-974018d091cf"), 24 },
                    { new Guid("ef478645-3611-4395-bc9c-8d133eb47db4"), 24 },
                    { new Guid("94480496-b29d-43e7-ad97-f8cf3b5df297"), 26 },
                    { new Guid("a9ec87ae-49ac-4c8a-b132-70c1450e7b04"), 36 },
                    { new Guid("43867201-ada9-48d0-992a-e892d0dcd1b3"), 37 },
                    { new Guid("9c466385-2f0f-45e1-a3e8-974018d091cf"), 37 },
                    { new Guid("ef478645-3611-4395-bc9c-8d133eb47db4"), 37 },
                    { new Guid("58403cca-47b4-4413-b71d-d0376027591b"), 50 },
                    { new Guid("94480496-b29d-43e7-ad97-f8cf3b5df297"), 50 },
                    { new Guid("6af48184-d368-4ed1-8e95-8628acce7fcb"), 52 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "CategoriesAuthors",
                columns: new[] { "AuthorId", "CategoryId" },
                values: new object[] { new Guid("2a710f84-af6d-422c-a623-87152dde9e6d"), 51 });

            migrationBuilder.InsertData(
                table: "CategoriesAuthors",
                columns: new[] { "AuthorId", "CategoryId" },
                values: new object[] { new Guid("7ba32a34-fc77-4f50-8894-a306c5b42238"), 51 });
        }
    }
}
