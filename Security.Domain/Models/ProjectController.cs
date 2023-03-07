using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models
{
    public class ProjectController
    {
        public int ProjectControllerID { get; set; }
        public string ProjectControllerName { get; set; }
        public string PersianTitle { get; set; }
        public int ProjectAreaID { get; set; }
        public ProjectArea ProjectArea { get; set; }
        public ICollection<ProjectAction> ProjectActions { get; set; }

        public ProjectController()
        {
            ProjectActions = new List<ProjectAction>();

        }

    }
}
