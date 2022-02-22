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
    public class CategoriesRepository
    {
        public List<CategoryDTO> Load()
        {
            if (File.Exists("CategoriesDto.Json"))
            {
                return JsonConvert.DeserializeObject<List<CategoryDTO>>(File.ReadAllText("CategoriesDto.Json"));
            }
            else
            {
                List<CategoryDTO> result = new List<CategoryDTO>();
                return result;
            }
        }
        public ResultDTO Save(List<CategoryDTO> categories)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                string categoriesJson = JsonConvert.SerializeObject(categories);
                File.WriteAllText("CategoriesDto.Json", categoriesJson);
            }
            catch (Exception e)
            {
                result.Error = true;
                result.Message = e.Message;
            }
            return result;
        }
    }
}
