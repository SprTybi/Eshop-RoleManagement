using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.RoleAction
{
    public class RoleActionListItem
    {
        public int RoleActionID { get; set; }
        public string RoleName { get; set; }
        public string ProjectActionName { get; set; }
        public string ProjectControllerName { get; set; }
        public bool HasPermission { get; set; }
    }
}
