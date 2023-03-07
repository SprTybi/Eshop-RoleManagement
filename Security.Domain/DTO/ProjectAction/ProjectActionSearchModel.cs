using Security.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.ProjectAction
{
    public class ProjectActionSearchModel : PageModel
    {
        public string ProjectActionName { get; set; }
        public string PersianTitle { get; set; }
        public int? ProjectControllerID { get; set; }
    }
}

