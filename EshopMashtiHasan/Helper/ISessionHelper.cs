using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingMashtiHasan.ViewModel;

namespace EshopMashtiHasan.Helper
{
    public interface ISessionHelper
    {
        void AddCurrentUserToSession(CurrentUser user);
        void RemoveCurrenrtFromSession(string Key);
        CurrentUser GetCurrentUser();

    }
}
