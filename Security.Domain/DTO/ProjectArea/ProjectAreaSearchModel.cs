using Security.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.ProjectArea
{
    public class ProjectAreaSearchModel: PageModel
    {
        public string AreaName { get; set; }
        public string PersianTitle { get; set; }        
    }
}
