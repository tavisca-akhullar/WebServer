using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class MyWebServer
    {
       private  HTTPListener _listener;

        public MyWebServer()
        {
            _listener = new HTTPListener();
        }
        public void StartServer()
        {
            IFileSystem google = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Google\\index.html");
            IFileSystem facebook = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Facebook\\index.html");
            IFileSystem linkedIn = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Linkedin\\index.html");
            IFileSystem snapChat = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Snapchat\\index.html");
            WebApp googleApp = new WebApp("http://localhost:8080/mygoogle.com/", google);
            WebApp facebookApp = new WebApp("http://localhost:8080/myfacebook.com/", facebook);
            WebApp linkedInApp = new WebApp("http://localhost:8080/mylinkedin.com/", linkedIn);
            WebApp snapChatApp = new WebApp("http://localhost:8080/mysnapchat1.com/", snapChat);
            _listener.StartListening();
        }
    }
}