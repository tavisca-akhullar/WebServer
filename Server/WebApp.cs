using System.Net;
using System;
using System.IO;
using System.Text;

namespace Server
{
    public class WebApp
    {
        public String Domain { get; }
        public IFileSystem FileSystem { get; }
      public WebApp(String domain,IFileSystem fileSystem)
        {
            Domain = domain;
            FileSystem = fileSystem;
            WebAppList.AddWebApp(domain,this);
        }

        public void RenderWebPage(HttpListenerContext context, string filePath)
        {
                Stream stream = context.Response.OutputStream;
                string contents = FileSystem.TryGetFile(filePath);
                HttpListenerResponse response = context.Response;
                byte[] buffer = Encoding.UTF8.GetBytes(contents);
                response.ContentLength64 = buffer.Length; 
                stream = response.OutputStream;  
                stream.Write(buffer, 0, buffer.Length);
                response.Close();
            }
        }
    }