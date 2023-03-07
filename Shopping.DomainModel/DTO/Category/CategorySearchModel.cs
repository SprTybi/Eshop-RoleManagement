using Shopping.DomainModel.BaseModel;

namespace Shopping.DomainModel.DTO.Category
{
   public class CategorySearchModel:PageModel
    {
        public string CategoryName { get; set; }
        public int? ParentID { get; set; }
    }
}
