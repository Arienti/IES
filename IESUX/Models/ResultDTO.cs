using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IESUX.Models
{
   public class ResultDTO
    {
        public bool Error { get; set; } = false; // By default is not error
        public string Message { get; set; }
    }
}
