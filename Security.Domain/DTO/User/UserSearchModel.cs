using Security.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.User
{
    public class UserSearchModel : PageModel
    {
        public string UserName { get; set; }
        public bool IsEmailActivated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleID { get; set; }
        public string Mobile { get; set; }
    }
}
