using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.ProjectAction
{
    public class ProjectActionListItem
    {
        public int ProjectActionID { get; set; }
        public string ProjectActionName { get; set; }
        public string PersianTitle { get; set; }        
        public string ProjectControllerName { get; set; }        
    }
}

