using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name ="CategorySearchBox")]
    public class CategorySearchBoxViewComponent:ViewComponent
    {
        private readonly ICategoryBuss catBuss;
        private void InflatedrpSearchCategory()
        {
            var firstLevelCategories = catBuss.GetAllRoots();
            firstLevelCategories.Insert(0, new CategoryListItem { CategoryID = -1, CategoryName = "...رده اصلی..." });
            SelectList drpCat = new SelectList(firstLevelCategories, "CategoryID", "CategoryName");
            ViewBag.drpCat = drpCat;
        }
        public CategorySearchBoxViewComponent(ICategoryBuss catBuss)
        {
            this.catBuss = catBuss;
        }
        public IViewComponentResult Invoke(CategorySearchModel sm)
        {
            InflatedrpSearchCategory();
            return View(sm);
        } 
    }
}
