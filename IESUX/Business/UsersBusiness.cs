using IESUX.Repository;
using IESUX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IESUX.Business
{
   public class UsersBusiness
    {
        private UsersRepository usersRepository  = new UsersRepository();
        private UsersDTO usersDTO = new UsersDTO();

        public UsersBusiness()
        {
            usersDTO = usersRepository.Load();
        }
        public bool Add(UserDTO userDTO)
      {
            if (string.IsNullOrEmpty(userDTO.email))
            {
                return false;
            }
            foreach (UserDTO currentUser in usersDTO.Clients)
            {
                if (currentUser.email == userDTO.email)
                {
                    return false;
                }
            }
            usersDTO.Clients.Add(userDTO);

            return usersRepository.Save(usersDTO);
        }
        public bool Edit(UserDTO userDTO)
        {
            for (int i = 0; i < usersDTO.Clients.Count; i++)
            {
                if (usersDTO.Clients[i].email == userDTO.email)
                {
                    usersDTO.Clients[i] = userDTO;
                    return usersRepository.Save(usersDTO);

                }
            }
            return false;
        }
        public UserDTO Get()
        {
            return usersRepository.Get();
        }
   }
}
