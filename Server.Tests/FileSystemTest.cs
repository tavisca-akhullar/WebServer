using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Server;


namespace Server.Tests
{
  public class FileSystemTest
    {
        [Fact]
        public void Get_File_Test()
        {
            IFileSystem google = new StaticFileSystem("C:\\Users\\akhullar\\source\\repos\\Location\\Google\\index.html");
            string webPage=google.TryGetFile(google.RootPath);
            Assert.Equal( "<html><head><title> HttpListener Example </ title ></ head > < body >< B3 > Hello World!</ B3 >< br > < B3 > Welcome To Google!</ B3 ></ body > </ html >",webPage);
        }
    }
}
