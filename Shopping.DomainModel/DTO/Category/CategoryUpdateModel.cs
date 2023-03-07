namespace Shopping.DomainModel.DTO.Category
{
   public class CategoryUpdateModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string MenuIcon { get; set; }
        public string Slug { get; set; }
    }
}
