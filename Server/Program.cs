using System.Net.Sockets;
using System.Linq;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWebServer webServer = new MyWebServer();
            webServer.StartServer();
        }
    }
}
