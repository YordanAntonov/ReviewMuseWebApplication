namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ReviewMuse.Data.Models;

    public class LanguagesConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            //builder.HasData(this.GenerateLanguages());
        }

        private Language[] GenerateLanguages()
        {
            ICollection<Language> languages = new HashSet<Language>();

            Language language;

            language = new Language()
            {
                Id = 1,
                LanguageName = "English"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 2,
                LanguageName = "Bulgarian"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 3,
                LanguageName = "Spanish"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 4,
                LanguageName = "Hungarian"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 5,
                LanguageName = "Russian"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 6,
                LanguageName = "Portugese"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 7,
                LanguageName = "French"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 8,
                LanguageName = "Dutch"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 9,
                LanguageName = "Deutsche"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 10,
                LanguageName = "Norwegian"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 11,
                LanguageName = "Chinese"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 12,
                LanguageName = "Japanese"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 13,
                LanguageName = "Hindi"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 14,
                LanguageName = "Serbian"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 15,
                LanguageName = "Romanian"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 16,
                LanguageName = "Korean"
            };
            languages.Add(language);

            language = new Language()
            {
                Id = 17,
                LanguageName = "Croatian"
            };
            languages.Add(language);

            return languages.ToArray();
        }
    }
}
