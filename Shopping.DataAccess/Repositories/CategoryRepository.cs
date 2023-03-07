using DomainModel.BaseModel;
using Shopping.DataAcceServiceContract.Repositories;
using Shopping.DomainModel.BaseModel;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;

namespace Shopping.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private CategoryListItem ToListItem(Category cat)
        {
           var lstItem = new CategoryListItem
            {
                CategoryID = cat.CategoryID
                ,
                CategoryName = cat.CategoryName
                //,
                //HasChild = cat.Children.Any()
                //,
                //ProductCount = cat.Products.Count
            };
           return lstItem;
        }
        private readonly EshopMashtiHasanContext db;

        public CategoryRepository(EshopMashtiHasanContext db)
        {
            this.db = db;
        }
        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryID == id);
        }
        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", "Category", id);
            try
            {
                var cat = Get(id);
                db.Categories.Remove(cat);
                db.SaveChanges();
                op.ToSuccess(id, "Delete Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail(id, "Delete Failed " + ex.Message);
            }
            return op;
        }
        public OperationResult Update(CategoryUpdateModel model)
        {
            var op = new OperationResult("Update", "Category", model.CategoryID);
            try
            {
                var cat = Get(model.CategoryID);
                cat.CategoryName = model.CategoryName;
                cat.Description = model.Description;
                cat.MenuIcon = model.MenuIcon;
                cat.Slug = model.Slug;
                db.SaveChanges();
                op.ToSuccess("Update Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Update Failed " + ex.Message);
            }

            return op;
        }
        public OperationResult Add(CategoryAddModel model)
        {
            var op = new OperationResult("Add", "Category");

            try
            {
                Category c = new Category
                {
                    CategoryName = model.CategoryName
                    ,
                    Description = model.Description
                    ,
                    MenuIcon = model.MenuIcon
                    ,
                    ParentID = model.ParentID
                    ,
                    Slug = model.Slug
                };
                if (model.ParentID==-1)
                {
                    c.ParentID = null;
                }
                db.Categories.Add(c);
                db.SaveChanges();
                op.RecordID = c.CategoryID;
                op.ToSuccess(c.CategoryID, "Add Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Add Failed " + ex.Message);
            }

            return op;
        }

        public List<CategoryListItem> Search(CategorySearchModel sm, out int RecordCount)
        {
            
            var q = from item in db.Categories select item;
            if (sm.ParentID==-1)
            {
                sm.ParentID = null;
            }
            if (sm.ParentID!=null )
            {
                q = q.Where(x => x.ParentID == sm.ParentID);
            }
            if (!string.IsNullOrEmpty(sm.CategoryName))
            {
                q = q.Where(x => x.CategoryName.StartsWith(sm.CategoryName));
            }

            RecordCount = q.Count();
            return q.Select(x => new CategoryListItem
            {
                CategoryID = x.CategoryID
                ,CategoryName = x.CategoryName
                ,HasChild = x.Children.Any()
                ,ProductCount=x.Products.Any() ? x.Products.Count() :0
            }).OrderByDescending(x=>x.CategoryID).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public int GetChildCount(int CategoryID)
        {
            return db.Categories.Count(x => x.ParentID == CategoryID);
        }

        public bool IsRoot(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public int GetProductCount(int CategoryID)
        {
            return db.Products.Count(x => x.CategoryID == CategoryID);
        }

        public bool HasProduct(int CategoryID)
        {
            return db.Products.Any(x => x.CategoryID == CategoryID);
        }

        public bool ExistCategoryName(string CategoryName)
        {
            return db.Categories.Any(x => x.CategoryName == CategoryName);
        }

        public bool ExistCategoryName(string CategoryName, int CategoryID)
        {
            return db.Categories.Any(x => x.CategoryName == CategoryName && x.CategoryID != CategoryID);
        }

        public bool ExistSlug(string Slug)
        {
            return db.Categories.Any(x => x.Slug == Slug);
        }

        public List<CategoryListItem> GetAllRoots()
        {
            var lst = db.Categories.ToList();
            
            return db.Categories.Where(x=>x.ParentID==null).ToList().Select(x => new CategoryListItem
            {
                CategoryID = x.CategoryID
                ,
                CategoryName = x.CategoryName


            }).OrderBy(x => x.CategoryName).ToList();
        }
    }
}
