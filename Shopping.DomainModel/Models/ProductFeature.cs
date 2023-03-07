namespace Shopping.DomainModel.Models
{
  public  class ProductFeature
    {
        public int ProductFeatureID { get; set; }
        public int FeatureID { get; set; }
        public int ProductID { get; set; }
        public string ProductFeatureValue { get; set; }
        public Product Product { get; set; }
        public Feature Feature { get; set; }
        public bool IsFastFeature { get; set; }

    }
}
