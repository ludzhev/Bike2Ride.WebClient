using System.Web.Mvc;

namespace Bike2Ride.WebClient.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LocationsController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}