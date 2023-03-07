using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.RoleAction
{
    public class RoleActionUpdateModel
    {
        public int RoleActionID { get; set; }
        public int RoleID { get; set; }
        public int ProjectActionID { get; set; }
        public bool HasPermission { get; set; }        
    }
}
