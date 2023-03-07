using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models

{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<RoleAction> RoleActions { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
            RoleActions = new List<RoleAction>();
        }
    }
}
