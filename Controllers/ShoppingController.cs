using HotelsProject.Data;
using HotelsProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelsProject.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly ApplicationDbContext _context;
        List<Hotel> hotelList = new List<Hotel>();

        public ShoppingController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var hotels = _context.hotel.ToList();

            return View(hotels);
        }
    }
}
