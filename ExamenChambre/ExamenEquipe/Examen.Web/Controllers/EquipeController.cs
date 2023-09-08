using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Web.Controllers
{
    public class EquipeController : Controller
    {
        IServiceEquipe serviceEquipe;

        public EquipeController(IServiceEquipe serviceEquipe)
        {
            this.serviceEquipe = serviceEquipe;
        }
        ///Search
        [HttpPost]
        public ActionResult Index(string filter)
        {
            var list = serviceEquipe.GetAll();
            if (!String.IsNullOrEmpty(filter))
            {
                list = list.Where(p => p.NomEquipe.ToString().Equals(filter)).ToList();
            }
            return View(list);
        }
        // GET: EquipeController
        public ActionResult Index()
        {
            return View(serviceEquipe.GetAll());
        }

        // GET: EquipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipe e, IFormFile file)
        {
            e.Logo = file.FileName;
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", file.FileName);
                using System.IO.Stream stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
            }
            try
            {
                serviceEquipe.Add(e);
                serviceEquipe.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquipeController/Edit/5
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

        // GET: EquipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquipeController/Delete/5
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
