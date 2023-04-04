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
        private readonly string _uri = "https://localhost:7209/api/Book";
        private object _userManager;

        // GET: BookingController
        public async Task<ActionResult> Index()
        {
            var response = await new BookDLL().getBookHttpClient(_uri);
            return View(response);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                Book book = new Book();
                book.name = collection["name"];
                book.title = collection["title"];
                book.description = collection["description"];
                book.author = collection["description"];
                book.quantity = Convert.ToInt32(collection["quantity"]);
                var response = await new BookDLL().createBookHttpClient(book, _uri);

                return RedirectToAction(nameof(Index));
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
            new BookDLL().deleteBookHttpClient(_uri + "/" + id);
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

        public async Task<ActionResult> BookIt(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            // For ASP.NET Core >= 5.0
            var userEmail = User.FindFirstValue(ClaimTypes.Email); // will give the user's Email

            await new BookDLL().BookItHttpClient(_uri, id);
            return Redirect("/booking/index");
        }

    }
}
