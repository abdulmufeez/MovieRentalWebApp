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
            //Email: mufeez@domain.com
            //Pass: Domainmufeez123?
            filters.Add(new AuthorizeAttribute()); 
        }
    }
}
