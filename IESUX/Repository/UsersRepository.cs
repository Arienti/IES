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
   public class UsersRepository
    {
        public UsersDTO Load()
        {
            if (File.Exists("UsersDto.Json"))
            {
                return JsonConvert.DeserializeObject<UsersDTO>(File.ReadAllText("UsersDto.Json"));
            }
            else
            {
                UsersDTO result = new UsersDTO();
                result.Clients = new List<UserDTO>();
                return result;
            }
        }
        public bool Save(UsersDTO usersDTO)
        {
            string result = JsonConvert.SerializeObject(usersDTO);
            File.WriteAllText("UsersDto.Json", result);
            return true;
        }
        public UserDTO Get()
        {
            string result = File.ReadAllText("UserDTO");
            UserDTO userDTO = JsonConvert.DeserializeObject<UserDTO>(result) ;
            return userDTO;
        }
    }
}
