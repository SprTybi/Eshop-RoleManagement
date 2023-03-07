using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMashtiHasan.Helper
{
    public interface ICookieHelper
    {
        bool WriteItemToCookie(string Key, string Value);
        string ReadItemFromCookie(string Key);
    }
}
