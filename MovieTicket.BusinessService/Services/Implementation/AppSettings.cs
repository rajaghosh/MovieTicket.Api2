using Microsoft.Extensions.Configuration;
using MovieTicket.BusinessService.Services.Interface;

namespace MovieTicket.BusinessService.Services.Implementation
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _config;
        public AppSettings(IConfiguration config)
        {
            _config = config;
        }

        public string _jwt_key => _config["Jwt:jwt_key"] ?? "";

        public string _jwt_id => _config["Jwt:jwt_id"] ?? "";

        public string _jwt_secret => _config["Jwt:jwt_secret"] ?? "";

        public string _jwt_audience => _config["Jwt:jwt_audience"] ?? "";

        public string _jwt_issuer => _config["Jwt:jwt_issuer"] ?? "";

        public string _file_path => _config["FileLoggerPath:Path"] ?? "";
    }
}
