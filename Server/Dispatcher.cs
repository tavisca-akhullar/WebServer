using System.Threading;
namespace Server
{
        public class Dispatcher
        {
            private HTTPListener _listener;
            private RequestBuffer _requestBuffer;
            private Api _api;
            public  Dispatcher (HTTPListener listener)
            {
                _requestBuffer = RequestBuffer.GetRequestBuffer();
                _listener = listener;
                
            }

            public void DispatchRequest()
            {
            SendResponse();
            }

            public void SendResponse()
            {
                 var context = _requestBuffer.GetRequest();
                 if (context != null)
                 {
                   _api = new Api(context);
                   var domainName = context.Request.Url.ToString() ;
                    if (domainName.Contains("Api"))
                    {
                    _api.routeRequest();
                    }
                    else
                    {
                    var webApp = WebAppList.GetWebApp(domainName);
                    webApp.RenderWebPage(context, webApp.FileSystem.RootPath);
                    }
                 }
            }
        }
    }