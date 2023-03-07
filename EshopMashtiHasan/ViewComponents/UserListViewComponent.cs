using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.User;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "UserList")]
    public class UserListViewComponent : ViewComponent
    {
        private readonly IUserBuss buss;
        public UserListViewComponent(IUserBuss buss)
        {
            this.buss = buss;
        }

        public IViewComponentResult Invoke(UserSearchModel sm)
        {
            if (sm.PageSize == 0 || sm == null)
            {
                sm.PageSize = 20;
            }
            int rc = 0;
            var users = buss.Search(sm, out rc);
            return View(users);
        }
    }
}
