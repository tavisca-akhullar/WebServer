using System;
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
            Console.WriteLine("Listening..!!");
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
            Listener.Prefixes.Add("http://localhost:8080/Api/leapyear=1000/");
        }
        public void StopListening()
        {
            Listener.Stop();
            _status = false;
        }
    }
}