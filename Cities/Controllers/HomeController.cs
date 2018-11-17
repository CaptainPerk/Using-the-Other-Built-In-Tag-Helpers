using Cities.Models;
using Cities.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Cities.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public HomeController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public ViewResult Index() => View(_cityRepository.Cities);

        public ViewResult Edit()
        {
            ViewBag.Countries = new SelectList(_cityRepository.Cities.Select(c => c.Country).Distinct());
            return View("Create", _cityRepository.Cities.First());
        }

        public ViewResult Create()
        {
            ViewBag.Countries = new SelectList(_cityRepository.Cities.Select(c => c.Country).Distinct());
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City newCity)
        {
            _cityRepository.AddCity(newCity);
            return RedirectToAction("Index");
        }
    }
}
