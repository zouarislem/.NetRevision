using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class CagnotteController : Controller
    {
        IServiceCagnotte sc;
        IServiceEntreprise se;

        public CagnotteController(IServiceCagnotte sc, IServiceEntreprise se)
        {
            this.sc = sc;
            this.se = se;
        }

        // GET: CagnotteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CagnotteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CagnotteController/Create
        public ActionResult Create()
        {
            
            ViewBag.EntrepriseList = new SelectList(se.GetAll(), "EntrepriseId", "NomEntreprise");

            ViewBag.TypeList = new SelectList(sc.GetAll(), "Type", "type");

            return View();
        }

        // POST: CagnotteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cagnotte cagnotte)
        {
            try
            {

                sc.Add(cagnotte);
                sc.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CagnotteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CagnotteController/Edit/5
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

        // GET: CagnotteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CagnotteController/Delete/5
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
