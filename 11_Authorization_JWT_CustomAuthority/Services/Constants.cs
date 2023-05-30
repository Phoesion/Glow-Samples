namespace Foompany.Services
{
    //Simple class to keep the configs. (In a real scenario your service should get them in some other 'production-approved' way)
    public static class Constants
    {
        public static string Issuer = "ThisIsMe";
        public static string Audience = "ThisIsYou";
        public static string SecretKey = "thiskeyisveryveryverylargetobreak";
        public static int Timeout = 10;

    }
}
