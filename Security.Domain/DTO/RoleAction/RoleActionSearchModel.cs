using Security.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.RoleAction
{
    public class RoleActionSearchModel: PageModel
    {
        public int? ProjectActionID { get; set; }
        public string? ProjectActionName { get; set; }
        public string? RoleName { get; set; }
        public int? RoleID { get; set; }
        public int? RoleActionID { get; set; }
        
    }
}
