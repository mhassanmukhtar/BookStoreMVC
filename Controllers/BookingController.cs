using BookStoreMVC.Areas.Identity.Data;
using BookStoreMVC.DLLs;
using BookStoreMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BookStoreMVC.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly string _bookUri = "https://localhost:7209/api/Book";
        private readonly string uri = "https://localhost:7209/api/BookingAPI";
        private object _userManager;

        // GET: BookingController
        public async Task<ActionResult> Index()
        {
            var response = await new BookingDLL().getBookingsHttpClient(uri);
            return View(response);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //// GET: BookingController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BookingController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Guid id)
        {
            try
            {
                string bookUri = _bookUri + "/" + id;
                Book book = await new BookDLL().getBookByIDHttpClient(bookUri);

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                var userEmail = User.FindFirstValue(ClaimTypes.Email); // will give the user's Email

                Booking booking = new Booking();
                booking.CustomerID = new Guid(userId);
                booking.CustomerName = userEmail;
                booking.BookingDate = DateTime.Now;
                booking.BookID = book.Id;
                booking.BookName = book.name;

                await new BookingDLL().CreateBooking(booking,uri);

                return Redirect("/book/index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(Guid id)
        {
        
            return Redirect("/booking/index");
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        

    }
}
