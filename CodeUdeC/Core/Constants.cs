namespace CodeUdeC.Core
{
    public static class Constants
    {
        //static method roles
        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Moderator = "Moderator";
            public const string User = "User";

        }

        //policies admin, moderator
        public static class Policies
        {
            public const string RequireAdmin = "RequireAdmin";
            public const string RequireModerator = "RequireModerator";
        }
    }
}
