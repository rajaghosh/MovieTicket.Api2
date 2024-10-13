using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.BusinessService.Services.Interface
{
    public interface IAppSettings
    {
        public string _jwt_key { get; }
        public string _jwt_id { get; }
        public string _jwt_secret { get; }
        public string _jwt_audience { get; }
        public string _jwt_issuer { get; }
        public string _file_path { get; }

    }
}
