using System.Collections.Generic;

namespace Shopping.DomainModel.Models
{
   public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public double Grade { get; set; }
        public string Tel { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
