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
                if (category.Id == Id)
                {
                    return category;
                }
            }

            return null;
        }

        public ResultDTO Add(CategoryDTO categoryDTO)
        {
            ResultDTO resultDTO = new ResultDTO();
            categories.Add(categoryDTO);
            return categoriesRepository.Save(categories);
        }

        public ResultDTO Edit(CategoryDTO categoryDTO)
        {
            ResultDTO resultDTO = new ResultDTO();
            //TODO: Edit exist category 
            return categoriesRepository.Save(categories);

        }

        public ResultDTO Delete(CategoryDTO categoryDTO)
        {
            ResultDTO resultDTO = new ResultDTO();
            //TODO: Delete exist category 
            return categoriesRepository.Save(categories);
        }
    }
}
