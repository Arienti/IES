using IESUX.Models;
using IESUX.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IESUX.Business
{
   public class ProductsBusiness
    {
        private ProductsDTO productsDTO = new ProductsDTO();

        private ProductsRepository productsRepository = new ProductsRepository();     

        public ProductsBusiness()
        {
            productsDTO = productsRepository.Load();
            
        }
        public ResultDTO Add(ProductDTO productDTO)
        {
            ResultDTO result = new ResultDTO();
            if ( string.IsNullOrEmpty(productDTO.Description))
            {
                result.Error = true;
                result.Message = "Description must be not empty";
                return result;
            }
            foreach (ProductDTO currentProduct in productsDTO.Items)
            {
                if (currentProduct.Id == productDTO.Id)
                {
                    result.Error = true;
                    result.Message = "ID is existing";
                    return result;
                }
            }
            productsDTO.Items.Add(productDTO);

            return productsRepository.Save(productsDTO);
        }
        public ResultDTO Edit(ProductDTO productDTO)
        {
            for ( int i = 0; i < productsDTO.Items.Count; i++)
            {
                if (productsDTO.Items[i].Id == productDTO.Id)
                {
                    productsDTO.Items[i] = productDTO;
                    return productsRepository.Save(productsDTO);
                    
                }
            }
            ResultDTO resultDTO = new ResultDTO();
            resultDTO.Error = true;
            resultDTO.Message = "Product does not exist";
            return resultDTO;
        }
        public ProductsDTO Get()
        {
            return productsDTO;
        }
    }
}
