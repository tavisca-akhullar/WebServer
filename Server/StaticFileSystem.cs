using System;
using System.IO;

namespace Server
{
    public class StaticFileSystem : IFileSystem
    {

        public String RootPath { get; }
        public StaticFileSystem(String rootPath)
        {
            RootPath = rootPath;
        }


        public string TryGetFile(string filePath)
        {
            string data;
            try
            {
                data = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                data = "<HTML><BODY><h1>404 Not Found</h1><p>Web Page not found!!!!!!!!!!!</p></BODY></HTML>";
            }
            return data;
        }
    }
}
