using Microsoft.AspNetCore.Mvc;
using RestaurantCatalog.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestaurantCatalog.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly RestaurantCatalogContext _db;

        public RestaurantController(RestaurantCatalogContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Restaurant> model = _db.Restaurants.Include(restaraunts => restaraunts.Cuisine).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
            ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
            return View(thisRestaurant);
        }


        public ActionResult Details(int id)
        {
            Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
            return View(thisRestaurant);
        }



    }
}
