using NUnit.Framework.Internal.Execution;
using ReviewMuse.Data;
using ReviewMuse.Data.Models;

namespace ReviewMuse.Services.Tests
{
    public static class DatabaseSeeder
    {
        public static ApplicationUser UserEditor;

        public static ApplicationUser NormalUser;

        public static ApplicationUser NonActiveEditor;

        public static Editor Editor;

        public static Editor NonEditor;

        public static Book Book1;

        public static Author Author1;

        public static void SeedDatabase(ReviewMuseDbContext dbContext)
        {
            UserEditor = new ApplicationUser()
            {
                UserName = "ZeroXp",
                NormalizedUserName = "ZEROXP",
                Email = "dankata169@gmail.com",
                NormalizedEmail = "DANKATA169@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                TwoFactorEnabled = false
            };

            NormalUser = new ApplicationUser()
            {
                UserName = "Danitoo",
                NormalizedUserName = "DANITOO",
                Email = "danitoo@gmail.com",
                NormalizedEmail = "DANITOO@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "8b51706e-f6e8-4dae-b240-54f856fb3004",
                SecurityStamp = "f6af46f5-74ba-43dc-927b-ad83497d0387",
                TwoFactorEnabled = false,
            };

            NonActiveEditor = new ApplicationUser()
            {
                UserName = "Kaloyan",
                NormalizedUserName = "KALOYAN",
                Email = "kaloyan@gmail.com",
                NormalizedEmail = "KALOYAN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "8d962eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "8b51704e-f6e8-4dae-b240-54f856fb3004",
                SecurityStamp = "f6af26f5-74ba-43dc-927b-ad83497d0387",
                TwoFactorEnabled = false,
            };

            Editor = new Editor()
            {
                Id = new Guid("2b283921-bbd4-49b9-90a4-cf181a4b7011"),
                PhoneNumber = "+359888888888",
                User = UserEditor,
                IsActive = true,
            };

            NonEditor = new Editor()
            {
                Id = new Guid("eb50e9b0-d955-4521-b6b5-2bf7cc8b8deb"),
                PhoneNumber = "+359888888888",
                User = NonActiveEditor,
                IsActive = false,
            };

            Book1 = new Book()
            {
                Id = new Guid("4dec8157-c384-49d0-9114-a4b1c545d373"),
                Title = "Oppenhaimer",
                Description = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasdddddddddddddddddddddddddddddddddddddddddddddddddddssssssssssssdsdsdsdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd",
                PublishingDate = DateTime.Now,
                RecordCreatedOn = DateTime.Now,
                IsActive = true,
                ImageUrl = null,
                NumberOfPages = 100,
                ISBN = "9780452284234",
                TotalRating = 0,
                EditorId = Guid.Parse("2b283921-bbd4-49b9-90a4-cf181a4b7011"),
                BookCoverId = 1,
                LanguageId = 2,
                AmazonUrl = null
            };

            Author1 = new Author()
            {
                Id = new Guid("e8c0f610-5983-47e8-b678-946ad817bfb7"),
                FullName = "Tom Holland",
                Description = "asddddddddddddddddddddddddddddddddddddddddddddddddddd",
                DateOfBirth = DateTime.Now,
                DateOfDeath = null,
                Website = null,
                ImageUrl = null,
                City = "Sofia",
                Country = "Bulgaria",
                IsActive = true,
                Pseudonim = "Tommy"
            };

            dbContext.Users.Add(UserEditor);
            dbContext.Users.Add(NormalUser);
            dbContext.Editors.Add(Editor);
            dbContext.Editors.Add(NonEditor);
            dbContext.Books.Add(Book1);
            dbContext.Authors.Add(Author1);

            dbContext.SaveChanges();
        }
    }
}
