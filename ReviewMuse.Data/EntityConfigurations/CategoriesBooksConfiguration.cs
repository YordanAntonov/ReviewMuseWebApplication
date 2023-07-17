namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models.MappingTables;

    public class CategoriesBooksConfiguration : IEntityTypeConfiguration<CategoriesBooks>
    {
        public void Configure(EntityTypeBuilder<CategoriesBooks> builder)
        {
            builder.HasData(this.GenerateCategoriesBooks());

            //Table composite key
            builder
                .HasKey(e => new { e.CategoryId, e.BookId });

            builder
                .HasOne(b => b.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.BooksCategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }

        private CategoriesBooks[] GenerateCategoriesBooks()
        {
            ICollection<CategoriesBooks> categoriesBooks = new HashSet<CategoriesBooks>();

            CategoriesBooks categoryBooks;

            //1984
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("CD20DF78-3771-44B3-84CB-1FAB11C820BD"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("CD20DF78-3771-44B3-84CB-1FAB11C820BD"),
                CategoryId = 19
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("CD20DF78-3771-44B3-84CB-1FAB11C820BD"),
                CategoryId = 2
            };
            categoriesBooks.Add(categoryBooks);

            //The Green Mile
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("8E233224-1CAC-458B-A93D-22976E9621DF"),
                CategoryId = 1
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("8E233224-1CAC-458B-A93D-22976E9621DF"),
                CategoryId = 5
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("8E233224-1CAC-458B-A93D-22976E9621DF"),
                CategoryId = 13
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("8E233224-1CAC-458B-A93D-22976E9621DF"),
                CategoryId = 9
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("8E233224-1CAC-458B-A93D-22976E9621DF"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            //The Raven
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("9D83A3A7-44AB-49BB-AB7E-6D1610C57079"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("9D83A3A7-44AB-49BB-AB7E-6D1610C57079"),
                CategoryId = 1
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("9D83A3A7-44AB-49BB-AB7E-6D1610C57079"),
                CategoryId = 8
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("9D83A3A7-44AB-49BB-AB7E-6D1610C57079"),
                CategoryId = 6
            };
            categoriesBooks.Add(categoryBooks);

            //Murder on the Orient Express
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("A9EC87AE-49AC-4C8A-B132-70C1450E7B04"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("A9EC87AE-49AC-4C8A-B132-70C1450E7B04"),
                CategoryId = 9
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("A9EC87AE-49AC-4C8A-B132-70C1450E7B04"),
                CategoryId = 36
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("A9EC87AE-49AC-4C8A-B132-70C1450E7B04"),
                CategoryId = 13
            };
            categoriesBooks.Add(categoryBooks);

            //Under the Yoke
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("6AF48184-D368-4ED1-8E95-8628ACCE7FCB"),
                CategoryId = 52
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("6AF48184-D368-4ED1-8E95-8628ACCE7FCB"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("6AF48184-D368-4ED1-8E95-8628ACCE7FCB"),
                CategoryId = 19
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("6AF48184-D368-4ED1-8E95-8628ACCE7FCB"),
                CategoryId = 14
            };
            categoriesBooks.Add(categoryBooks);

            //Monstrous Regiment
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("EF478645-3611-4395-BC9C-8D133EB47DB4"),
                CategoryId = 5
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("EF478645-3611-4395-BC9C-8D133EB47DB4"),
                CategoryId = 37
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("EF478645-3611-4395-BC9C-8D133EB47DB4"),
                CategoryId = 24
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("EF478645-3611-4395-BC9C-8D133EB47DB4"),
                CategoryId = 2
            };
            categoriesBooks.Add(categoryBooks);

            //Making Money
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("9C466385-2F0F-45E1-A3E8-974018D091CF"),
                CategoryId = 5
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("9C466385-2F0F-45E1-A3E8-974018D091CF"),
                CategoryId = 37
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("9C466385-2F0F-45E1-A3E8-974018D091CF"),
                CategoryId = 24
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("9C466385-2F0F-45E1-A3E8-974018D091CF"),
                CategoryId = 2
            };
            categoriesBooks.Add(categoryBooks);

            //Dagon
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("CC506971-44F0-4C9D-BFED-A49DFEEBE97F"),
                CategoryId = 1
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("CC506971-44F0-4C9D-BFED-A49DFEEBE97F"),
                CategoryId = 4
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("CC506971-44F0-4C9D-BFED-A49DFEEBE97F"),
                CategoryId = 8
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("CC506971-44F0-4C9D-BFED-A49DFEEBE97F"),
                CategoryId = 5
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("CC506971-44F0-4C9D-BFED-A49DFEEBE97F"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("CC506971-44F0-4C9D-BFED-A49DFEEBE97F"),
                CategoryId = 3
            };
            categoriesBooks.Add(categoryBooks);

            //It
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("27A14DB5-EE4C-4D07-9DEC-A6F2A8347FF1"),
                CategoryId = 1
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("27A14DB5-EE4C-4D07-9DEC-A6F2A8347FF1"),
                CategoryId = 9
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("27A14DB5-EE4C-4D07-9DEC-A6F2A8347FF1"),
                CategoryId = 5
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("27A14DB5-EE4C-4D07-9DEC-A6F2A8347FF1"),
                CategoryId = 13
            };
            categoriesBooks.Add(categoryBooks);

            //The Call of Cthulhu
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("88E662A2-0077-4F72-B79C-B3B3CCEAA6CD"),
                CategoryId = 1
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("88E662A2-0077-4F72-B79C-B3B3CCEAA6CD"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("88E662A2-0077-4F72-B79C-B3B3CCEAA6CD"),
                CategoryId = 8
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("88E662A2-0077-4F72-B79C-B3B3CCEAA6CD"),
                CategoryId = 5
            };
            categoriesBooks.Add(categoryBooks);

            //The Sun also Rises
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("15CEB205-5C7F-47BC-BC7A-CC4513BF69A6"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("15CEB205-5C7F-47BC-BC7A-CC4513BF69A6"),
                CategoryId = 19
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("15CEB205-5C7F-47BC-BC7A-CC4513BF69A6"),
                CategoryId = 14
            };
            categoriesBooks.Add(categoryBooks);

            //The Shining
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("1E004174-0070-40B5-AFA5-CDA5E2958929"),
                CategoryId = 1
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("1E004174-0070-40B5-AFA5-CDA5E2958929"),
                CategoryId = 13
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("1E004174-0070-40B5-AFA5-CDA5E2958929"),
                CategoryId = 5
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("1E004174-0070-40B5-AFA5-CDA5E2958929"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("1E004174-0070-40B5-AFA5-CDA5E2958929"),
                CategoryId = 9
            };
            categoriesBooks.Add(categoryBooks);

            //The Old Man and the Sea
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("58403CCA-47B4-4413-B71D-D0376027591B"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("58403CCA-47B4-4413-B71D-D0376027591B"),
                CategoryId = 19
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("58403CCA-47B4-4413-B71D-D0376027591B"),
                CategoryId = 12
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("58403CCA-47B4-4413-B71D-D0376027591B"),
                CategoryId = 50
            };
            categoriesBooks.Add(categoryBooks);

            //Thief of Time
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("43867201-ADA9-48D0-992A-E892D0DCD1B3"),
                CategoryId = 5
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("43867201-ADA9-48D0-992A-E892D0DCD1B3"),
                CategoryId = 37
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("43867201-ADA9-48D0-992A-E892D0DCD1B3"),
                CategoryId = 24
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("43867201-ADA9-48D0-992A-E892D0DCD1B3"),
                CategoryId = 2
            };
            categoriesBooks.Add(categoryBooks);

            //The Shadow over Innsmouth
            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("1049B652-3E53-4D71-AC09-ECA3D9D9F7F6"),
                CategoryId = 1
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("1049B652-3E53-4D71-AC09-ECA3D9D9F7F6"),
                CategoryId = 3
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("1049B652-3E53-4D71-AC09-ECA3D9D9F7F6"),
                CategoryId = 7
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("1049B652-3E53-4D71-AC09-ECA3D9D9F7F6"),
                CategoryId = 2
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("94480496-B29D-43E7-AD97-F8CF3B5DF297"),
                CategoryId = 14
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("94480496-B29D-43E7-AD97-F8CF3B5DF297"),
                CategoryId = 26
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("94480496-B29D-43E7-AD97-F8CF3B5DF297"),
                CategoryId = 50
            };
            categoriesBooks.Add(categoryBooks);

            categoryBooks = new CategoriesBooks()
            {
                BookId = Guid.Parse("94480496-B29D-43E7-AD97-F8CF3B5DF297"),
                CategoryId = 19
            };
            categoriesBooks.Add(categoryBooks);

            return categoriesBooks.ToArray();
        }
    }
}
