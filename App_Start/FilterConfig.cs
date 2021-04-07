using System.Web;
using System.Web.Mvc;

namespace Hospital_Management_Software
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
