using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models
{
    public class RoleAction
    {
        public int RoleActionID { get; set; }
        public int RoleID { get; set; }
        public int ProjectActionID { get; set; }
        public ProjectAction ProjectAction { get; set; }
        public Role Role { get; set; }
        public bool HasPermission { get; set; }

        public RoleAction()
        {


        }
    }
}
