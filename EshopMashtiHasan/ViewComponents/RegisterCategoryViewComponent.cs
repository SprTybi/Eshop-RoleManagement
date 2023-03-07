using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RegisterCategory")]
    public class RegisterCategoryViewComponent:ViewComponent
    {
        private readonly ICategoryBuss buss;
        private void InflatedrpSearchCategory()
        {
            var firstLevelCategories = buss.GetAllRoots();
            firstLevelCategories.Insert(0, new CategoryListItem {CategoryID=-1,CategoryName="...رده اصلی..." });
            SelectList drpCat = new SelectList(firstLevelCategories, "CategoryID", "CategoryName");
            ViewBag.drpCat = drpCat;
        }
        public RegisterCategoryViewComponent(ICategoryBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke()
        {
            InflatedrpSearchCategory();
            return View();
        }
    }
}
