using Microsoft.AspNetCore.Mvc;
using Shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "CategoryList")]
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly ICategoryBuss buss;
        public CategoryListViewComponent(ICategoryBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(CategorySearchModel sm)
        {

            if (sm==null || sm.PageSize==0)
            {
                sm.PageSize = 20;
            }
            int rc = 0;
            var cats = buss.Search(sm, out rc);
            return View(cats);
        }
    }
}