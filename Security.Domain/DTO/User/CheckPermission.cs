using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.User
{
    public class CheckPermission
    {
        public string ActionName { get; set; }
        public string Controller { get; set; }
        public string UserName { get; set; }
    }
}

