using System.Collections.Generic;
using DomainModel.BaseModel;
using Shopping.DomainModel.BaseModel;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;

namespace Shopping.BussinessServiceContract.Services
{
   public interface ICategoryBuss
   {
       OperationResult RegisterCategory(CategoryAddModel cat);
       OperationResult RemoveCategory(int CategoryID);
       OperationResult Update(CategoryUpdateModel cat);
        List<CategoryListItem> GetAllRoots();
       List<CategoryListItem> Search(CategorySearchModel sm, out int RecordCount);
       Category GetCategory(int CategoryID);
   }
}
