using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T1_POOII.Models;

namespace T1_POOII.Controllers
{
    public class RegistroController : Controller
    {
        private MiDbContext db = new MiDbContext();

        public ActionResult Index()
        {
            var profesores = db.Profesores.ToList();
            return View(profesores);
        }

        public ActionResult Create()
        {
            return View(new Profesor());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                // Validación de unicidad de DNI
                if (db.Profesores.Any(p => p.DNI == profesor.DNI))
                {
                    ModelState.AddModelError("DNI", "Ya existe un profesor con este DNI. Ingrese un DNI diferente.");
                    return View(profesor);
                }

                db.Profesores.Add(profesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesor);
        }

        public ActionResult TestConexion()
        {
            try
            {
                using (var db = new MiDbContext())
                {
                    var cantidad = db.Profesores.Count();
                    return Content("Conexion OK, registros encontrados: " + cantidad);
                }
            }
            catch (Exception ex)
            {
                return Content("Error al conectar: " + ex.Message);
            }
        }

        public ActionResult Edit(string id)
        {
            var profesor = db.Profesores.Find(id);
            if (profesor == null) return HttpNotFound();
            return View(profesor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesor);
        }

        public ActionResult Details(string id)
        {
            var profesor = db.Profesores.Find(id);
            if (profesor == null) return HttpNotFound();
            return View(profesor);
        }

        public ActionResult Delete(string id)
        {
            var profesor = db.Profesores.Find(id);
            if (profesor == null) return HttpNotFound();
            return View(profesor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var profesor = db.Profesores.Find(id);
            db.Profesores.Remove(profesor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}