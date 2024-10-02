using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_EFCore.Controllers
{
    public class SenController : Controller
    {
        // GET: SenController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SenController/Create
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

        // GET: SenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SenController/Edit/5
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

        // GET: SenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SenController/Delete/5
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
