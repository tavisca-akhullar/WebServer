using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Server;
namespace Server.Tests
{
    public class AddWebApp
    {
        [Fact]
        public void Add_WebApp_Test()
        {
            IFileSystem google = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Google\\index.html");
            IFileSystem facebook = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Facebook\\index.html");
            WebApp googleApp = new WebApp("http://localhost:8080/mygoogle.com/", google);
            WebApp facebookApp = new WebApp("http://localhost:8080/myfacebook.com/", facebook);
            Assert.Same(googleApp,WebAppList.GetWebApp("http://localhost:8080/mygoogle.com/"));
        }
    }
}
