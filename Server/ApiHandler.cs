using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ApiHandler
    {

        private HttpListenerContext _context;

        public ApiHandler(HttpListenerContext context)
        {
            _context = context;
        }

        public void GetResponse(int year)
        {
            Stream stream = _context.Response.OutputStream;
            string contents = null;
            if (LeapYear.IsLeapYear(year))
            {
                contents = $"{year} is leap year";
            }
            else
            {
                 contents = $"{year} is not a leap year";
            }
             HttpListenerResponse response = _context.Response;
            byte[] buffer = Encoding.UTF8.GetBytes(contents);
            response.ContentLength64 = buffer.Length;
            stream = response.OutputStream;
            stream.Write(buffer, 0, buffer.Length);
            response.Close();
        }
    }
}
