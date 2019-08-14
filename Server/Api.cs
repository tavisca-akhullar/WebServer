using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Api
    {
        private HttpListenerContext _context;
        private ApiHandler _apiHandler;

        public Api(HttpListenerContext context)
        {
            _context = context;
            _apiHandler = new ApiHandler(context);
        }

        public void routeRequest()
        {
            if (_context.Request.HttpMethod == "GET")
            {
                var domainName = _context.Request.Url.ToString();
                string[] domains = domainName.Split('=');
                _apiHandler.GetResponse(int.Parse(domains[1].Split('/')[0]));  
            }
        }
    }
}
