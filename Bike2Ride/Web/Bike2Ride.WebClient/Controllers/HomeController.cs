using System.Web.Mvc;

using Bike2Ride.WebClient.ViewModels;

namespace Bike2Ride.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeViewModel()
            {
                Title = "Home",
            };

            return this.View(model);
        }

        public ActionResult About()
        {
            var model = new AboutViewModel()
            {
                Title = "About",
                Message = "Your application description page."
            };

            return this.View(model);
        }

        public ActionResult Contact()
        {
            var model = new ContactViewModel()
            {
                Title = "Contact",
                Message = "Your contact page."
            };

            return this.View(model);
        }
    }
}
