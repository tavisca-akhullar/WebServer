using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Server;

namespace Server.Tests
{

    public class ListenerTest
    {
        [Fact]
        public void Listening_Test()
        {
            IFileSystem google = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Google\\index.html");
            IFileSystem facebook = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Facebook\\index.html");
            WebApp googleApp = new WebApp("http://localhost:8080/mygoogle.com/", google);
            WebApp facebookApp = new WebApp("http://localhost:8080/myfacebook.com/", facebook);
            HTTPListener listener = new HTTPListener();
            listener.StartListening();
            Assert.Equal(true,listener.Listener.IsListening);
        }

        [Fact]
        public void Stop_Listening_Test()
        {
            IFileSystem google = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Google\\index.html");
            IFileSystem facebook = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Facebook\\index.html");
            WebApp googleApp = new WebApp("http://localhost:8080/mygoogle.com/", google);
            WebApp facebookApp = new WebApp("http://localhost:8080/myfacebook.com/", facebook);
            HTTPListener listener = new HTTPListener();
            listener.StartListening();
            listener.StopListening();
            Assert.Equal(false, listener.Listener.IsListening);
        }
    }
}
