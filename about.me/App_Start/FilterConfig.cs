using System.Web;
using System.Web.Mvc;

namespace about.me
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
	  filters.Add(new HandleErrorAttribute());
        }
    }
}
