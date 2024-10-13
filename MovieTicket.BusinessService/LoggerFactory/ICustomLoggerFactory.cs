using MovieTicket.ModelHelper.Models;

namespace MovieTicket.BusinessService.LoggerFactory
{
    public interface ICustomLoggerFactory
    {
        ILoggerObjContract CreateLogger(LoggerType type);
    }
}
