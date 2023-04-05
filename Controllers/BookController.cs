using BookStoreMVC.DLLs;
using BookStoreMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStoreMVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly string _uri = "https://localhost:7209/api/Book";
        private readonly object _userManager;

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
            return Redirect("/book/index");
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
            await new BookDLL().BookItHttpClient(_uri, id);

            return Redirect("/booking/create/" + id);
        }
    }
}
