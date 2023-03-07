using System.Collections.Generic;

namespace Shopping.DomainModel.Models
{
  public  class Category
    {
        public int CategoryID { get; set; }
        public int? ParentID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string MenuIcon { get; set; }
        public string Slug { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> Children { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<CategoryFeature> CategoryFeatures { get; set; }

        public Category()
        {
            this.Children = new List<Category>();
            this.Products = new List<Product>();
            this.CategoryFeatures = new List<CategoryFeature>();

        }

    }
}
