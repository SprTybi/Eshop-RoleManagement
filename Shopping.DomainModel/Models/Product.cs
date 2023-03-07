using System.Collections.Generic;

namespace Shopping.DomainModel.Models
{
   public class Product
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public long UnitPrice { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public ICollection<RelatedProduct> Products { get; set; }
        public ICollection<RelatedProduct> RelatedProducts { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

        public Product()
        {
            this.RelatedProducts = new List<RelatedProduct>();
            this.RelatedProducts = new List<RelatedProduct>();
            this.ProductFeatures = new List<ProductFeature>();
            this.OrderDetails = new List<OrderDetails>();
        }
    }
}
