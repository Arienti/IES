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
        private CategoriesBusiness categories = null;

        public ProductsBusiness(CategoriesBusiness categories)
        {
            this.categories = categories;
            productsDTO = productsRepository.Load();
        }
        public ResultDTO Add(ProductDTO productDTO)
        {
            ResultDTO result = new ResultDTO();
            if (string.IsNullOrEmpty(productDTO.Description))
            {
                result.Error = true;
                result.Message = "Description must be not empty";
                return result;
            }
            /*
            foreach (ProductDTO currentProduct in productsDTO.Items)
            {
                if (currentProduct.Id == productDTO.Id)
                {
                    result.Error = true;
                    result.Message = "ID is existing";
                    return result;
                }
            }
            */

            int tempId = productsDTO.Items.Count + 1;

            while (true)
            {
                if (GetById(tempId).Items.Count == 0)
                {
                    break;
                }
                tempId++;
            }

            productDTO.Id = tempId;

            CategoryDTO category = categories.GetById(productDTO.CategoryId);
            if (category == null)
            {
                result.Error = true;
                result.Message = "Category is not exists";
                return result;
            }
            productsDTO.Items.Add(productDTO);
            return productsRepository.Save(productsDTO);
        }
        public ResultDTO Edit(ProductDTO productDTO)
        {
            //TODO: Checkers here 
            for (int i = 0; i < productsDTO.Items.Count; i++)
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

        public ProductsDTO GetByCategoryId(int categoryId)
        {
            ProductsDTO result = new ProductsDTO();
            result.Items = new List<ProductDTO>();
            foreach (ProductDTO product in productsDTO.Items)
            {
                if (product.CategoryId == categoryId)
                {
                    result.Items.Add(product);
                }
            }
            return result;
        }

        public ProductsDTO GetById(int Id)
        {
            ProductsDTO result = new ProductsDTO();
            result.Items = new List<ProductDTO>();
            foreach (ProductDTO product in productsDTO.Items)
            {
                if (product.Id == Id)
                {
                    result.Items.Add(product);
                }
            }
            return result;
        }


        public ResultDTO Delete(ProductDTO productDTO)
        {
            ProductsRepository categoriesRepository = new ProductsRepository();
            productsDTO.Items.Remove(productDTO);
            return categoriesRepository.Save(productsDTO);
        }
    }
}
