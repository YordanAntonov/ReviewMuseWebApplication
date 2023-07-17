namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models.MappingTables;

    public class CategoriesAuthorsConfiguration : IEntityTypeConfiguration<CategoriesAuthors>
    {
        public void Configure(EntityTypeBuilder<CategoriesAuthors> builder)
        {
            //builder.HasData(this.GenerateCategoriesAuthors());

            builder
                .HasKey(entity => new { entity.CategoryId, entity.AuthorId });

            builder
                .HasOne(a => a.Author)
                .WithMany(a => a.AuthorCategories)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.AuthorsCategory)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private CategoriesAuthors[] GenerateCategoriesAuthors()
        {
            ICollection<CategoriesAuthors> categoriesAuthors = new HashSet<CategoriesAuthors>();

            CategoriesAuthors categoryAuthor;

            //Edgar Allan Poe
            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("920499CE-F57B-49D6-A6BF-3539C9FE092F"),
                CategoryId = 1
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("920499CE-F57B-49D6-A6BF-3539C9FE092F"),
                CategoryId = 6
            };
            categoriesAuthors.Add(categoryAuthor);

            //Terry Pratchet
            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("27C84413-3E20-43A2-8206-3BCD5130AE5C"),
                CategoryId = 2
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("27C84413-3E20-43A2-8206-3BCD5130AE5C"),
                CategoryId = 23
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("27C84413-3E20-43A2-8206-3BCD5130AE5C"),
                CategoryId = 49
            };
            categoriesAuthors.Add(categoryAuthor);

            //George Orwell
            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("4A4E6C7B-9FA4-4F63-B016-4834E4D702D3"),
                CategoryId = 10
            };
            categoriesAuthors.Add(categoryAuthor);

            //Ernest Hemingway
            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("C497E8EA-E4B6-48DD-9342-727151636D54"),
                CategoryId = 26
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("C497E8EA-E4B6-48DD-9342-727151636D54"),
                CategoryId = 12
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("C497E8EA-E4B6-48DD-9342-727151636D54"),
                CategoryId = 28
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("C497E8EA-E4B6-48DD-9342-727151636D54"),
                CategoryId = 4
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("C497E8EA-E4B6-48DD-9342-727151636D54"),
                CategoryId = 35
            };
            categoriesAuthors.Add(categoryAuthor);

            //Ivan Vazov
            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("2A710F84-AF6D-422C-A623-87152DDE9E6D"),
                CategoryId = 45
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("2A710F84-AF6D-422C-A623-87152DDE9E6D"),
                CategoryId = 51
            };
            categoriesAuthors.Add(categoryAuthor);

            //Stephen King
            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("7BA32A34-FC77-4F50-8894-A306C5B42238"),
                CategoryId = 1
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("7BA32A34-FC77-4F50-8894-A306C5B42238"),
                CategoryId = 5
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("7BA32A34-FC77-4F50-8894-A306C5B42238"),
                CategoryId = 51
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("7BA32A34-FC77-4F50-8894-A306C5B42238"),
                CategoryId = 6
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("7BA32A34-FC77-4F50-8894-A306C5B42238"),
                CategoryId = 13
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("7BA32A34-FC77-4F50-8894-A306C5B42238"),
                CategoryId = 36
            };
            categoriesAuthors.Add(categoryAuthor);

            //Agatha Christy
            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("38548843-5141-4578-9B50-C9EF413F24BC"),
                CategoryId = 36
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("38548843-5141-4578-9B50-C9EF413F24BC"),
                CategoryId = 15
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("38548843-5141-4578-9B50-C9EF413F24BC"),
                CategoryId = 13
            };
            categoriesAuthors.Add(categoryAuthor);

            //H.P Lovecraft
            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("B8D67A4C-B7AC-4F6F-84D4-D0A6760AEB16"),
                CategoryId = 1
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("B8D67A4C-B7AC-4F6F-84D4-D0A6760AEB16"),
                CategoryId = 2
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("B8D67A4C-B7AC-4F6F-84D4-D0A6760AEB16"),
                CategoryId = 3
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("B8D67A4C-B7AC-4F6F-84D4-D0A6760AEB16"),
                CategoryId = 4
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("B8D67A4C-B7AC-4F6F-84D4-D0A6760AEB16"),
                CategoryId = 5
            };
            categoriesAuthors.Add(categoryAuthor);

            categoryAuthor = new CategoriesAuthors()
            {
                AuthorId = Guid.Parse("B8D67A4C-B7AC-4F6F-84D4-D0A6760AEB16"),
                CategoryId = 6
            };
            categoriesAuthors.Add(categoryAuthor);

            return categoriesAuthors.ToArray();
        }
    }
}
