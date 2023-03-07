using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.BaseModel;
using Shopping.BussinessServiceContract.Services;
using Shopping.DataAcceServiceContract.Repositories;
using Shopping.DomainModel.BaseModel;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;

namespace Shopping.Bussiness.Implementations
{
   public class CategoryBuss : ICategoryBuss
   {
       private readonly  ICategoryRepository repo;

       public CategoryBuss(ICategoryRepository repo)
       {
           this.repo = repo;
       }

        public OperationResult RegisterCategory(CategoryAddModel cat)
        {
            if (repo.ExistSlug(cat.Slug))
            {
                return new OperationResult("RegisterCategory","Category").ToFail("slug Already Exist");
            }
            if (repo.ExistCategoryName(cat.CategoryName))
            {
                return new OperationResult("RegisterCategory", "Category").ToFail("CategoryName Already Exist");
            }

            return repo.Add(cat);
        }

        public OperationResult RemoveCategory(int CategoryID)
        {
            if (repo.HasProduct(CategoryID))
            {
               
                    return new OperationResult("Remove", "Category").ToFail("This Category Has Related Product");
            }
            if (repo.GetChildCount(CategoryID) > 0)
            {

                return new OperationResult("Remove", "Category").ToFail("This Category Has Related Sub Categories");
            }

            return repo.Delete(CategoryID);
        }

        public OperationResult Update(CategoryUpdateModel cat)
        {
            if (repo.ExistCategoryName(cat.CategoryName,cat.CategoryID))
            {

                return new OperationResult("Update", "Category").ToFail("This Category Name Has been Assigned to Another Category");
            }

            return repo.Update(cat);
        }

        public List<CategoryListItem> Search(CategorySearchModel sm, out int RecordCount)
        {
            if (sm.PageSize ==0)
            {
                sm.PageSize = 20;
            }

            return repo.Search(sm, out RecordCount);
        }

        public Category GetCategory(int CategoryID)
        {
            return repo.Get(CategoryID);
        }

        public List<CategoryListItem> GetAllRoots()
        {
            return repo.GetAllRoots();
        }
    }
}
