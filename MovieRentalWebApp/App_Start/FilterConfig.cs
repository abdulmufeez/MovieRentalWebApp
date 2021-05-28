using System.Web;
using System.Web.Mvc;

namespace MovieRentalWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //This is used protect your app globally from anonymous users
            //Username: Admin
            //Email: admin@movierentalstore.com
            //Pass: Adminmovierentalstore123?
            filters.Add(new AuthorizeAttribute());
            //with this you can never access this web without using ssl
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
