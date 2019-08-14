using System.Collections.Generic;
using System;

namespace Server
{
    public class WebAppList
    {
        private static  Dictionary<string, WebApp> _webAppList = new Dictionary<string, WebApp>();
        public static  void AddWebApp(string name,WebApp webApp)
        {
            _webAppList.Add(name,webApp);
        }

        public static List<string> GetWebAppList()
        {
            return new List<string>(_webAppList.Keys);
        }

        public static WebApp GetWebApp(string domainName)
        {
            return _webAppList[domainName];
        }
    }
}
