using Microsoft.Extensions.Configuration;
using MovieTicket.BusinessService.Services.Interface;
using MovieTicket.ModelHelper.Models;

namespace MovieTicket.BusinessService.LoggerFactory
{
    public class CustomLoggerFactory : ICustomLoggerFactory
    {
        private readonly IConfiguration _config;
        private readonly IAppSettings _appSettings;

        public CustomLoggerFactory(IConfiguration config, IAppSettings appSettings)
        {
            _config = config;
            _appSettings = appSettings;
        }

        public ILoggerObjContract CreateLogger(LoggerType type)
        {
            ILoggerObjContract logger;
            switch (type)
            {
                case LoggerType.ConsoleLog:
                    logger = new ConsoleLoggerFactory();
                    break;
                case LoggerType.FileLog:
                    logger = new FileLoggerFactory(_config, _appSettings);
                    break;
                case LoggerType.DbLog:
                    logger = new DbLoggerFactory();
                    break;
                default:
                    logger = new ConsoleLoggerFactory();
                    break;
            }

            return logger;
        }
    }

    public static class LogHelper
    {
        public static void Info_Log(this ILoggerObjContract logger, string result)
        {
            logger.InformationLog(result);
        }
        public static void Error_Log(this ILoggerObjContract logger, string result)
        {
            logger.ErrorLog(result);
        }
    }
}
