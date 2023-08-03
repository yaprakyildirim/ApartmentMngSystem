namespace ApartmentMngSystem.Business.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";
        public static string JwtKey { get; set; } = string.Empty;  // Bu statik bir property olacak.
        public const int Expire = 5;
    }
}
