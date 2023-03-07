using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.BaseModel
{
   public class CategoryAddModel
    {
        
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string MenuIcon { get; set; }
        public string Slug { get; set; }
        public int? ParentID { get; set; }
    }
}
