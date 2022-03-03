using IESUX.Business;
using Newtonsoft.Json;
using System;
using System.Net;

namespace DemoSimpleHTTPServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            
            
            listener.Prefixes.Add("http://127.0.0.1:8888/");
        
                listener.Start();
                Console.WriteLine("Listening...");
      
                CategoriesBusiness categoriesBusiness = new CategoriesBusiness();
                ProductsBusiness productsBusiness = new ProductsBusiness(categoriesBusiness);


            while (true)
            {

                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.

                string responseString = "<HTML><BODY>Not found</BODY></HTML>";
                //GET POST PUT DELETE 
                
                if (request.RawUrl.Equals("/products"))
                {
                    responseString = JsonConvert.SerializeObject(productsBusiness.Get());
                }
                else
                if (request.RawUrl.Equals("/categories"))
                {
                    responseString = JsonConvert.SerializeObject(categoriesBusiness.Get());
                }
                
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
                //  }
            }
              listener.Stop();
        }
    }
}

