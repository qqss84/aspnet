using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData _db;

        public RestaurantsController(IRestaurantData db)
        {
            _db = db;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            _db.Add(restaurant);
            return View();
        }
    }
}