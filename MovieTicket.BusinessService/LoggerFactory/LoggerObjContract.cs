using Microsoft.Extensions.Configuration;
using MovieTicket.BusinessService.Services.Interface;

namespace MovieTicket.BusinessService.LoggerFactory
{
    public class ConsoleLoggerFactory : ILoggerObjContract
    {
        public void InformationLog(string logData)
        {
            Console.WriteLine($"{DateTime.Now} - Info: {logData}");
        }
        public void ErrorLog(string logData)
        {
            Console.WriteLine($"{DateTime.Now} - Error: {logData}");
        }
    }

    public class FileLoggerFactory : ILoggerObjContract
    {
        private readonly IConfiguration _config;
        private readonly string _filePath;
        private readonly IAppSettings _appSettings;

        public FileLoggerFactory(IConfiguration config, IAppSettings appSettings)
        {
            _config = config;
            _appSettings = appSettings;
            //_filePath = _config.GetValue<string>("FileLoggerPath:Path") ?? "";
            _filePath = _appSettings._file_path;

            //if the filepath is default or no filepath provided generate the log at the root
            if (_filePath.Trim().Length == 0 || _filePath.Equals("\\"))
                _filePath = $"MovieTicketLogs_{DateTime.Now.ToString("MMddyyyy")}.log";
            else
                _filePath = string.Concat(_filePath, $"MovieTicketLogs_{DateTime.Now.ToString("MMddyyyy")}.log");

        }

        public void InformationLog(string logData)
        {
            using (StreamWriter w = File.AppendText(_filePath))
                w.WriteLine($"{DateTime.Now} - Info: {logData}");
        }
        public void ErrorLog(string logData)
        {
            using (StreamWriter w = File.AppendText(_filePath))
                w.WriteLine($"{DateTime.Now} - Error: {logData}");
        }
    }

    public class DbLoggerFactory : ILoggerObjContract
    {
        public void InformationLog(string logData)
        {
            //TBD
        }
        public void ErrorLog(string logData)
        {
            //TBD
        }
    }

    public class AppInsightsLoggerFactory : ILoggerObjContract
    {
        public void InformationLog(string logData)
        {
            //TBD
        }
        public void ErrorLog(string logData)
        {
            //TBD
        }
    }
}
