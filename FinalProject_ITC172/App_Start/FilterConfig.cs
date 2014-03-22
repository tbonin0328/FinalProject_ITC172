using System.Web;
using System.Web.Mvc;

namespace FinalProject_ITC172
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}