using IESInterfaces;
using IESUX.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IESRESTfulClient
{
    public class ProductBussines : IProductBusiness
    {
        private static readonly HttpClient client = new HttpClient();

        public ResultDTO Add(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public ResultDTO Delete(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public ResultDTO DeleteAll()
        {
            throw new NotImplementedException();
        }

        public ResultDTO Edit(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductsDTO> Get()
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
            catch (HttpRequestException)
            {

            }
            return null;
        }

        public ProductsDTO GetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ProductsDTO GetById(int Id)
        {
            throw new NotImplementedException();
        }

        ProductsDTO IProductBusiness.Get()
        {
            throw new NotImplementedException();
        }
    }
}

