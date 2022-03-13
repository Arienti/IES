using IESUX.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IESRESTfulClient
{
    public class ProductBussines
    {
        static readonly HttpClient client = new HttpClient();
        public async Task< ProductsDTO> Get()
        {
                // Call asynchronous network methods in a try/catch block to handle exceptions.
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://127.0.0.1:8888/products");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                ProductsDTO productsDTO = JsonConvert.DeserializeObject<ProductsDTO>(responseBody);
                return productsDTO;
                }
                catch (HttpRequestException e)
                {
                    
                }
            return null;
            }
        }
    }

