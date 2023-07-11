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
    }
}
