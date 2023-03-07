using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.Role
{
    public class RoleListItem
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int UserCount { get; set; }
    }
}

