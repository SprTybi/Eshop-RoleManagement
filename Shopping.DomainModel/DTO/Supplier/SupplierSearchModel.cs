using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.Supplier
{
    public class SupplierSearchModel:BaseModel.PageModel
    {
        public string SupplierName { get; set; }
        public string Tel { get; set; }
    }
}
