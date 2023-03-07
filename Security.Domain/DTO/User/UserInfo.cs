using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.User
{
    public class UserInfo
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}

