
using System.Net;
using System.Threading;

namespace Server
{
    public class HTTPListener
    {
        public HttpListener Listener { get; }
        private RequestBuffer _requestBuffer;
        private bool _status;

        public HTTPListener()
        {
            Listener = new HttpListener();
            _requestBuffer=RequestBuffer.GetRequestBuffer();
            _status = false;
        }

        public void StartListening()
        {
            AddPrefixes();
            Listener.Start();
            _status = true;
            while (_status)
            {
                var httpContext = Listener.GetContext();
                _requestBuffer.AddRequest(httpContext);
                if (!_requestBuffer.IsEmpty())
                {
                    Dispatcher dispatcher = new Dispatcher(this);
                    Thread thread = new Thread(()=>dispatcher.DispatchRequest());
                    thread.Start();
                }
            }
        }

        public void AddPrefixes()
        {
            foreach(var webApp in WebAppList.GetWebAppList())
            {
                Listener.Prefixes.Add(webApp);
            }
        }
        public void StopListening()
        {
            Listener.Stop();
            _status = false;
        }
    }
}
