using IESUX.Models;
using IESUX.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IESUX.Business
{
    public class CategoriesBusiness
    {
        private List<CategoryDTO> categories = new List<CategoryDTO>();

        private CategoriesRepository categoriesRepository = new CategoriesRepository();

        public CategoriesBusiness()
        {
            categories = categoriesRepository.Load();
        }

        public List<CategoryDTO> Get()
        {
            return categories;
        }

        public CategoryDTO GetById(int Id)
        {
            foreach (CategoryDTO category in categories)
            {
                if (category.CategoryId == Id)
                {
                    return category;
                }
            }

            return null;
        }

        public ResultDTO Add(CategoryDTO categoryDTO)
        {
            ResultDTO resultDTO = new ResultDTO();
            foreach (CategoryDTO currentCategory in categories)
            {
                if (currentCategory.CategoryId == categoryDTO.CategoryId)
                {
                    resultDTO.Error = true;
                    resultDTO.Message = "ID is existing";
                    return resultDTO;
                }
            }
            categories.Add(categoryDTO);
            return categoriesRepository.Save(categories);
        }
        public ResultDTO Edit(CategoryDTO categoriesDTO)
        {
            //TODO: Checkers here 
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].CategoryId == categoriesDTO.CategoryId)
                {
                    categories[i] = categoriesDTO;
                    return categoriesRepository.Save(categories);
                }
            }
            ResultDTO resultDTO = new ResultDTO();
            resultDTO.Error = true;
            resultDTO.Message = "Category does not exist";
            return resultDTO;
        }
        /* public List<CategoryDTO> Delete()
         {
             CategoryDTO categoryDTO = new CategoryDTO();
             for (int i= 1; i > categories.Count;i--)
             categories[i] = categoryDTO;

             return categoriesRepository.Save(categoryDTO);
         */
     
    }
}

