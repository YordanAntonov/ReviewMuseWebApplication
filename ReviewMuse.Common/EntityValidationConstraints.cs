namespace ReviewMuse.Common
{
    public static class EntityValidationConstraints
    {
        public static class Category
        {
            public const int NameMaxLength = 70;
            public const int NameMinLength = 1;

            public const int DescriptionMinLength = 50;
        }

        public static class BookCoverType
        {
            public const int TypeNameMaxLength = 30;
            public const int TypeNameMinLength = 30;
        }

        public static class Language
        {
            public const int LanguageNameMaxLength = 60;
            public const int LanguageNameMinLength = 1;
        }

        public static class Book
        {
            public const int TitleMaxLength = 150;
            public const int TitleMinLength = 1;

            public const int DescriptionMinLength = 40;

            public const int PagesCountMax = 10000;
            public const int PagesCountMin = 1;

            public const int BookIsbnSize = 13;
        }

        public static class Status
        {
            public const int StatusMaxLength = 30;
            public const int StatusMinLength = 1;
        }

        public static class Editor
        {
            public const int PhoneMaxLength = 15;
            public const int PhoneMinLength = 7;
        }

        public static class Author
        {
            public const int NameMaxLength = 300;
            public const int NameMinLength = 1;

            public const int DescriptionMinLength = 50;

            public const int CityNameMaxLength = 300;
            public const int CityNameMinLength = 2;

            public const int CountryNameMaxLength = 300;
            public const int CountryNameMinLength = 2;

            public const int AuthorPseudonimMaxLength = 300;
            public const int AuthorPseudonimMinLength = 1;
        }

        public static class Review
        {
            public const int ReviewCommentMinLength = 50;
            public const int ReviewCommentMaxLength = 5000;

            public const int ReviewRatingMaxRate = 5;
            public const int ReviewRatingMinRate = 1;
        }
    }
}
