using HotelsProject.Data;
using HotelsProject.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
namespace HotelsProject.Controllers
{
	public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        List<Hotel> hotelList = new List<Hotel>();

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;

        }

        //send mial 
   //      public async Task<string> SendEmail()
   //     {
   //         var Message = new MimeMessage();
			//Message.From.Add(new MailboxAddress("test message", "tuwaiq.asayil@gmail.com"));
   //         Message.To.Add(MailboxAddress.Parse("asayel.alsulami.cs@gmail.com"));
   //         Message.Subject = "test sen email from dashboard project";
   //         Message.Body = new TextPart("plain")
   //         {
   //             Text = Message.To.ToString()
   //         };

   //         using(var client = new SmtpClient())
   //         {
   //             try
   //             {
			//	    client.Connect("smtp.gmail.com");
   //             }
   //             catch
   //             {

   //             }
   //         }
      //         return "Ok";
   //     }

        // hotels methods ( Home dashboard )
        [Authorize]
        public IActionResult Index()
        {
			var currentUser = HttpContext.User.Identity.Name??null;
			CookieOptions option = new CookieOptions();
			option.Expires = DateTime.Now.AddMinutes(30);
			Response.Cookies.Append("UserName", currentUser, option);
			HttpContext.Session.SetString("userName", currentUser);

			ViewBag.CurrentUser = currentUser;


			var hotels = _context.hotel.ToList();

            return View(hotels);
        }

        [HttpPost]
        public IActionResult Index(string city)
        {

			ViewBag.CurrentUser = Request.Cookies["UserName"];
			var hotels = _context.hotel.ToList();

			var findHotels = hotels.Where(item => item.City == city);
			if (findHotels == null)
			{
				findHotels = _context.hotel.ToList();
                ViewBag.msg = "null";
			}
			
			return View(findHotels);
		}
	
        public IActionResult Delete(int id)
        {
            //Search document
            var hotelDelete = _context.hotel.SingleOrDefault(h => h.Id == id);
            //delete document
            if (hotelDelete != null)
            {
                _context.hotel.Remove(hotelDelete);
                _context.SaveChanges();
                TempData["Del"] = "Ok";
            } 
            
            return RedirectToAction("Index");

        }

		public IActionResult UpdateRecord(Hotel hotel)
		{
            if (ModelState.IsValid)
            {
                _context.hotel.Update(hotel);
			    _context.SaveChanges();
			    TempData["Edit"] = "Ok";
			    return RedirectToAction("Index");
            }
			
            return View(hotel);

		}
		public IActionResult Edit(int id)
		{
			var hotelEdit = _context.hotel.SingleOrDefault(hotel => hotel.Id == id);
			return View(hotelEdit);
		}

		public IActionResult CreateNewHotel(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.hotel.Add(hotel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var hotels = _context.hotel.ToList();

            return View("Index", hotels);
        }

        //end hotels methods

        //Room method

		public IActionResult Room()
		{
			//ViewBag.CurrentUser = Request.Cookies["UserName"];

			ViewBag.CurrentUser = HttpContext.Session.GetString("userName");
			var hotels = _context.hotel.ToList();
			ViewBag.hotels = hotels;

            var rooms = _context.room.ToList();

			return View(rooms);
		}

		[HttpPost]
		public IActionResult Room(string type)
		{

			ViewBag.CurrentUser = Request.Cookies["UserName"];
			var hotels = _context.hotel.ToList();
			ViewBag.hotels = hotels;

			var rooms = _context.room.ToList();

			var findrooms = rooms.Where(item => item.Type == type);
			if (findrooms == null)
			{
				findrooms = _context.room.ToList();
				ViewBag.msg = "null";
			}

			return View(findrooms);

		}

		public IActionResult CreateNewRoom(Room room )
		{
			_context.room.Add(room);
            _context.SaveChanges();


			return RedirectToAction("Room");
		}

		public IActionResult UpdateRoom(Room room)
		{
			if (ModelState.IsValid)
			{
				_context.room.Update(room);
				_context.SaveChanges();
				//TempData["Edit"] = "Ok";
				return RedirectToAction("Room");
			}

			return View(room);

		}
		public IActionResult EditRoom(int id)
		{
            //var hotels = _context.hotel.ToList();
            //ViewBag.hotels = hotels;

            var roomEdit = _context.room.SingleOrDefault(item => item.Id == id);
			return View(roomEdit);
		}


		public IActionResult DeleteRoom(int id)
		{
			//Search document
			var RoomDelete = _context.room.SingleOrDefault(h => h.Id == id);
			//delete document
			if (RoomDelete != null)
			{
				_context.room.Remove(RoomDelete);
				_context.SaveChanges();
				TempData["Del"] = "Ok";
			}

			return RedirectToAction("Room");

		}

		//end room methods

		// RoomDetails methods
		public IActionResult RoomDetails()
        {

			ViewBag.CurrentUser = Request.Cookies["UserName"];
			var hotels = _context.hotel.ToList();
			ViewBag.hotels = hotels;

            var rooms = _context.room.ToList();
            ViewBag.rooms = rooms;

            var roomDetails = _context.roomDetails.ToList();

			return View(roomDetails);
        }

		public IActionResult CreateNewRoomDetails(RoomDetails roomDetails)
		{
			_context.roomDetails.Add(roomDetails);
			_context.SaveChanges(); 

			return RedirectToAction("RoomDetails");
		}

        public IActionResult UpdateRoomDetails(RoomDetails roomDetails)
        {
            if (ModelState.IsValid)
            {
                _context.roomDetails.Update(roomDetails);
                _context.SaveChanges();
               
                return RedirectToAction("RoomDetails");
            }

            return View(roomDetails);

        }
        public IActionResult EditRoomDetails(int id)
        {
            var hotels = _context.hotel.ToList();
            ViewBag.hotels = hotels;

            var RDEdit = _context.roomDetails.SingleOrDefault(item => item.Id == id);
            return View(RDEdit);
        }

        public IActionResult DeleteRoomDetails(int id)
		{
			//Search document
			var RDDelete = _context.roomDetails.SingleOrDefault(h => h.Id == id);
			//delete document
			if (RDDelete != null)
			{
				_context.roomDetails.Remove(RDDelete);
				_context.SaveChanges();
				TempData["Del"] = "Ok";
			}

			return RedirectToAction("RoomDetails");

		}

	}
}
