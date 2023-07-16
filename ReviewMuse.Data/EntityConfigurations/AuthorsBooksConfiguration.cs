namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models.MappingTables;

    public class AuthorsBooksConfiguration : IEntityTypeConfiguration<AuthorsBooks>
    {
        public void Configure(EntityTypeBuilder<AuthorsBooks> builder)
        {
            builder.HasData(this.GenerateAuthorsBooks());

            builder
                .HasKey(e => new { e.AuthorId, e.BookId });

            builder
                .HasOne(a => a.Author)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private AuthorsBooks[] GenerateAuthorsBooks()
        {
            ICollection<AuthorsBooks> authorsBooks = new HashSet<AuthorsBooks>();
            AuthorsBooks authorBooks;

            //The Shadow over Innsmouth
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("B8D67A4C-B7AC-4F6F-84D4-D0A6760AEB16"),
                BookId = Guid.Parse("1049B652-3E53-4D71-AC09-ECA3D9D9F7F6")
            };
            authorsBooks.Add(authorBooks);

            //The Call of Cthulu
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("B8D67A4C-B7AC-4F6F-84D4-D0A6760AEB16"),
                BookId = Guid.Parse("88E662A2-0077-4F72-B79C-B3B3CCEAA6CD")
            };
            authorsBooks.Add(authorBooks);

            //Dagon
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("B8D67A4C-B7AC-4F6F-84D4-D0A6760AEB16"),
                BookId = Guid.Parse("CC506971-44F0-4C9D-BFED-A49DFEEBE97F")
            };
            authorsBooks.Add(authorBooks);

            //It
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("7BA32A34-FC77-4F50-8894-A306C5B42238"),
                BookId = Guid.Parse("27A14DB5-EE4C-4D07-9DEC-A6F2A8347FF1")
            };
            authorsBooks.Add(authorBooks);

            //The Green Mile
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("7BA32A34-FC77-4F50-8894-A306C5B42238"),
                BookId = Guid.Parse("8E233224-1CAC-458B-A93D-22976E9621DF")
            };
            authorsBooks.Add(authorBooks);

            //The Shining
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("7BA32A34-FC77-4F50-8894-A306C5B42238"),
                BookId = Guid.Parse("1E004174-0070-40B5-AFA5-CDA5E2958929")
            };
            authorsBooks.Add(authorBooks);

            //Murder on the Orient Express
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("38548843-5141-4578-9B50-C9EF413F24BC"),
                BookId = Guid.Parse("A9EC87AE-49AC-4C8A-B132-70C1450E7B04")
            };
            authorsBooks.Add(authorBooks);

            //The Raven
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("920499CE-F57B-49D6-A6BF-3539C9FE092F"),
                BookId = Guid.Parse("9D83A3A7-44AB-49BB-AB7E-6D1610C57079")
            };
            authorsBooks.Add(authorBooks);

            //Making Money
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("27C84413-3E20-43A2-8206-3BCD5130AE5C"),
                BookId = Guid.Parse("9C466385-2F0F-45E1-A3E8-974018D091CF")
            };
            authorsBooks.Add(authorBooks);

            //Monstrous Regiment
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("27C84413-3E20-43A2-8206-3BCD5130AE5C"),
                BookId = Guid.Parse("EF478645-3611-4395-BC9C-8D133EB47DB4"),
            };
            authorsBooks.Add(authorBooks);

            //Thief of Time
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("27C84413-3E20-43A2-8206-3BCD5130AE5C"),
                BookId = Guid.Parse("43867201-ADA9-48D0-992A-E892D0DCD1B3"),
            };
            authorsBooks.Add(authorBooks);

            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("4A4E6C7B-9FA4-4F63-B016-4834E4D702D3"),
                BookId = Guid.Parse("CD20DF78-3771-44B3-84CB-1FAB11C820BD")
            };
            authorsBooks.Add(authorBooks);

            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("2A710F84-AF6D-422C-A623-87152DDE9E6D"),
                BookId = Guid.Parse("6AF48184-D368-4ED1-8E95-8628ACCE7FCB")
            };
            authorsBooks.Add(authorBooks);

            //The Old Man and the Sea
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("C497E8EA-E4B6-48DD-9342-727151636D54"),
                BookId = Guid.Parse("58403CCA-47B4-4413-B71D-D0376027591B")
            };
            authorsBooks.Add(authorBooks);

            //The Sun Also Rises
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("C497E8EA-E4B6-48DD-9342-727151636D54"),
                BookId = Guid.Parse("15CEB205-5C7F-47BC-BC7A-CC4513BF69A6"),
            };
            authorsBooks.Add(authorBooks);

            //A Farewell to Arms
            authorBooks = new AuthorsBooks()
            {
                AuthorId = Guid.Parse("C497E8EA-E4B6-48DD-9342-727151636D54"),
                BookId = Guid.Parse("94480496-B29D-43E7-AD97-F8CF3B5DF297"),
            };
            authorsBooks.Add(authorBooks);

            return authorsBooks.ToArray();
        }
    }
}
