using Microsoft.Extensions.Configuration;

namespace InsuranceWithDatabase.Utility
{
    static class DbConnUtil
    {
        static IConfiguration _iConfigration;

        static DbConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
            _iConfigration = builder.Build();
        }
        public static string GetConnectionString()
        {
            return _iConfigration.GetConnectionString("LocalConnectionString");
        }
    }
}
