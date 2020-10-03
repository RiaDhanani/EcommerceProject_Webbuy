using System.Web;
using System.Web.Mvc;

namespace EcommerceProject_Webbuy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
