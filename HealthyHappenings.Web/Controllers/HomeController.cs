using HealthyHappenings.Contract;
using HealthyHappenings.EBSource;
using HealthyHappenings.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthyHappenings.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			TempData["CurrentCity"] = "Bethesda";

			IHealthyHappeningService healthyHappeningService = new HealthyHappeningEBSourceService();
	        List<Event> events = healthyHappeningService.GetByCity("Bethesda");
	        if (events != null)
	        {
		        ViewBag.EventCount = events.Count();
	        }
			

            return View(events);
        }

		[HttpPost]
		public ActionResult Index(string txtCity)
		{
			TempData["CurrentCity"] = txtCity;
			TempData.Keep();


			IHealthyHappeningService healthyHappeningService = new HealthyHappeningEBSourceService();
			List<Event> events = healthyHappeningService.GetByCity(txtCity);
			if (events != null)
			{
				ViewBag.EventCount = events.Count();
			}


			return View(events);
			
		}

      
    }

    
}
