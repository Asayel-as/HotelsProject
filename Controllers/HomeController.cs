using HotelsProject.Data;
using HotelsProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelsProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			var hotels = _context.hotel.ToList();

			return View(hotels);
		}
		public IActionResult Delete(int id)
		{
			//Search document
			var hotelDelete = _context.hotel.SingleOrDefault(h => h.Id == id);
			//delete document
			_context.hotel.Remove(hotelDelete);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}
		public IActionResult UpdateRecord(Hotel hotel)
		{
			if(ModelState.IsValid)
			{
				_context.hotel.Update(hotel);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			
			return View("Edit");
		}
		public IActionResult Edit(int id)
		{
			var hotelEdit = _context.hotel.SingleOrDefault(hotel => hotel.Id == id);

			return View(hotelEdit);


		}

		public IActionResult CreateNewRecord(Hotel hotel)
		{
			if (ModelState.IsValid)
			{
				_context.hotel.Add(hotel);
				_context.SaveChanges();
				return RedirectToAction("Index");

			}

			var hotels = _context.hotel.ToList();
			return RedirectToAction("Index", hotels);

		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}