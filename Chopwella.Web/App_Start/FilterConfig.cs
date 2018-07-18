using System.Web.Mvc;

namespace Chopwella.Web.App_Start
{
    public class FilterConfig
    {
        public static void Configure(GlobalFilterCollection filter)
        {
            filter.Add(new AuthorizeAttribute());
        }
    }
}