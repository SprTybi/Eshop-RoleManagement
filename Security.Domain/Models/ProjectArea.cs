using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models
{
    public class ProjectArea
    {
        public int ProjectAreaID { get; set; }
        public string AreaName { get; set; }
        public string PersianTitle { get; set; }
        public ICollection<ProjectController> ProjctControllers { get; set; }

        public ProjectArea()
        {
            ProjctControllers = new List<ProjectController>();
        }
    }
}
