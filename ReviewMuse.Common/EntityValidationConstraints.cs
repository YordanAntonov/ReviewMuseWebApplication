namespace ReviewMuse.Common
{
    public static class EntityValidationConstraints
    {
        public static class Category
        {
            public const int NameMaxLength = 70;
            public const int NameMinLength = 1;
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
    }
}
