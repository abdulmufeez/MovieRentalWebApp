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
            //Email: abdul_mufeez@outlook.com
            //Pass: Adminmovierentalstore123?
            //Username: Staff
            //Email: mufeezmubeen1997@gmail.com
            //Pass: Staffmovierentalstore123?
            //Username: Guest
            //Email: guest@movierentalstore.com
            //Pass: Guestmovierentalstore123?
            filters.Add(new AuthorizeAttribute());
            //with this you can never access this web without using ssl
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
