using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Shopping.DomainModel.DTO.Supplier
{
    public class SupplierListItem
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public double Grade { get; set; }
        public string Tel { get; set; }
        public int ProductCount { get; set; }
    }
}
