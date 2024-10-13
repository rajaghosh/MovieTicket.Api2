using Microsoft.Extensions.Configuration;

namespace MovieTicket.DBHelper.DatabaseContext.ConfigHelper
{
    public class DbAppSettings : IDbAppSettings
    {
        private readonly IConfiguration _config;
        public DbAppSettings(IConfiguration config)
        {
            _config = config;
        }
        public string _connStr => _config["ConnectionStrings:MovieTicketDb"] ?? "";
    }
}
