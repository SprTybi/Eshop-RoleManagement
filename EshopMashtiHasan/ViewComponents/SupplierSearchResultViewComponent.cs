using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using Shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Supplier;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "SupplierSearchResult")]
    public class SupplierSearchResultViewComponent:ViewComponent
    {
        private readonly ISupplierBuss repo;

        public SupplierSearchResultViewComponent(ISupplierBuss repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke(SupplierSearchModel sm)
        {
            if (sm==null )
            {
                sm = new SupplierSearchModel { PageSize = 20 };
            }

            if (sm.PageSize==0)
            {
                sm.PageSize = 20;
            }
            int rc = 0;
            var lst = repo.Search(sm, out rc);
            return View(lst);
        }
    }
}
