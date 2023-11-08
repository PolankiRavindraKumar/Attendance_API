namespace Attendance_API.Repository
{
    public class Utility
    {
        public static IConfiguration configuration { get; set; }
        public static string GetConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configuration = builder.Build();
            string? connection = configuration.GetConnectionString("StudentAttendance");
            return connection;
        }
    }
}
