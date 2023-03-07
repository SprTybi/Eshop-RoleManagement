using DomainModel.BaseModel;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;

namespace Shopping.DataAcceServiceContract.Repositories
{
   public interface ICategoryRepository : Base.IBaseRespositorySearchable<Category,int,CategorySearchModel,CategoryListItem,CategoryUpdateModel,CategoryAddModel>
   {
       int GetChildCount(int CategoryID);
       bool IsRoot(int CategoryID);
       int GetProductCount(int CategoryID);
       bool HasProduct(int CategoryID);
       bool ExistCategoryName(string CategoryName);
       bool ExistCategoryName(string CategoryName,int CategorID);
       bool ExistSlug(string Slug);
        List<CategoryListItem> GetAllRoots();
    }
}
