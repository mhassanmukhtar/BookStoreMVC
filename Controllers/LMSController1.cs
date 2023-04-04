using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVC.Controllers
{
    public class LMSController1 : Controller
    {
        // GET: LMSController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: LMSController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LMSController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LMSController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: LMSController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LMSController1/Edit/5
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

        // GET: LMSController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LMSController1/Delete/5
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
