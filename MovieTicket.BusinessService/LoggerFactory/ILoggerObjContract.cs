﻿namespace MovieTicket.BusinessService.LoggerFactory
{
    public interface ILoggerObjContract
    {
        void InformationLog(string resp);
        void ErrorLog(string resp);
    }
}
