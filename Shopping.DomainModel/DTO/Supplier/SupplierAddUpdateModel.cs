using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.Supplier
{
    public class SupplierAddUpdateModel
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public double Grade { get; set; }
        public string Tel { get; set; }
    }
}
