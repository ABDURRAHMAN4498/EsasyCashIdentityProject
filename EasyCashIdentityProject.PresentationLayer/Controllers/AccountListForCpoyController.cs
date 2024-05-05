using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class AccountListForCpoyController : Controller
    {
        // GET: AccountListForCpoyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountListForCpoyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountListForCpoyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountListForCpoyController/Create
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

        // GET: AccountListForCpoyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountListForCpoyController/Edit/5
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

        // GET: AccountListForCpoyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountListForCpoyController/Delete/5
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
