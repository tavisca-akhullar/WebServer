using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;

namespace Server
{
    public class RequestBuffer
    {
        public static ConcurrentQueue<HttpListenerContext> requests = new ConcurrentQueue<HttpListenerContext>();
        private static RequestBuffer _requestBuffer;
        

        public void AddRequest(HttpListenerContext request)
        {
            requests.Enqueue(request);
        }

        public bool IsEmpty()
        {
            return requests.Count == 0;
        }

        public HttpListenerContext GetRequest()
        {
            HttpListenerContext context = null;
            bool status=requests.TryDequeue(out context);
            if (status)
            {
                return context;
            }
            else
            {
                throw new NoRequestException("No request available");
            }
        }

        public static RequestBuffer GetRequestBuffer()
        {
            if (_requestBuffer == null)
            {
                _requestBuffer = new RequestBuffer();
                return _requestBuffer;
            }
            else
                return _requestBuffer;
            }
    }
}
