using System.Collections.Generic;
using System.Net;

namespace Server
{
    public class RequestBuffer
    {
        public static Queue<HttpListenerContext> requests = new Queue<HttpListenerContext>();
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
            return requests.Dequeue();
        }

        public static RequestBuffer GetRequestBuffer()
        {
            if (_requestBuffer == null)
                return new RequestBuffer();
            else
                return _requestBuffer;
            }
    }
}
