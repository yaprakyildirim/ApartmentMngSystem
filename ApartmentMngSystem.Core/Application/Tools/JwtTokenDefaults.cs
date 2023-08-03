namespace ApartmentMngSystem.Business.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "www.test.com";
        public const string ValidIssuer = "www.test.com";
        public static string JwtKey { get; set; } = string.Empty;  // Bu statik bir property olacak.
        public const int Expire = 2;
    }
}
