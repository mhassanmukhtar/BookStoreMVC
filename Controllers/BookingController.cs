using BookStoreMVC.DLLs;
using BookStoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BookStoreMVC.Controllers
{
    public class BookingController : Controller
    {
        // GET: BookingController
        public async Task<ActionResult> Index()
        {
            var uri = "https://localhost:7209/api/Book";
            var response = await new BookDLL().getBookHttpClient(uri);
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
                string uri = "https://localhost:7209/api/Book";
                Book book=new Book();
                book.title = collection["title"];
                book.description = collection["description"];
                book.author= collection["description"];
                book.quantity = Convert.ToInt32(collection["quantity"]);
                var response = await new BookDLL().createBookHttpClient(book, uri);

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
            var uri = "https://localhost:7209/api/Book/"+id;
            new BookDLL().deleteBookHttpClient(uri);
            return RedirectToAction("index");
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
