using IESUX.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IESUX.Repository
{
   public class ProductsRepository
    {
        public ProductsDTO Load()
        {
            if ( File.Exists("ProductsDto.Json"))
            {
                return JsonConvert.DeserializeObject<ProductsDTO>(File.ReadAllText("ProductsDto.Json"));
            }
            else
            {
                ProductsDTO result = new ProductsDTO();
                result.Items = new List<ProductDTO>();
                return result;
            }
        }
        public ResultDTO Save(ProductsDTO productsDTO)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                string productsJson = JsonConvert.SerializeObject(productsDTO);
                File.WriteAllText("ProductsDto.Json", productsJson);
            }
            catch(Exception e)
            {
                result.Error = true;
                result.Message = e.Message;
            }
            return result;
        }
        public  ProductDTO Get()
        {
            string result = File.ReadAllText("ProductDTO");
            ProductDTO productDTO = JsonConvert.DeserializeObject<ProductDTO>(result);
            return productDTO;
        }
    }
}
