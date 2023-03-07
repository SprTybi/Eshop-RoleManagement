namespace Shopping.DomainModel.DTO.Category
{
   public class CategoryListItem
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool HasChild { get; set; }
        public int ProductCount { get; set; }
    }
}
