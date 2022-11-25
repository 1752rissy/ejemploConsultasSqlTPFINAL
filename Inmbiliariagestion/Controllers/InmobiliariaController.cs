using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Inmbiliariagestion.Models;

namespace Inmbiliariagestion.Controllers
{
    public class InmobiliariaController : Controller
    {
        private DptoEntities db = new DptoEntities();

        // GET: Inmobiliaria
        public ActionResult Index()
        {
            return View(db.Inmobiliaria.ToList());
        }

        // GET: Inmobiliaria/Details/5
        public async Task<ActionResult> Details(string razonSocial)
        {
            if (razonSocial == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmobiliaria inmobiliaria = await db.Inmobiliaria.FindAsync(razonSocial);
            if (inmobiliaria == null)
            {
                return HttpNotFound();
            }
            return View(inmobiliaria);
        }

        // GET: Inmobiliaria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inmobiliaria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RazonSocial,Telefon")] Inmobiliaria inmobiliaria)
        {
            if (ModelState.IsValid)
            {
                db.Inmobiliaria.Add(inmobiliaria);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(inmobiliaria);
        }

        // GET: Inmobiliaria/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmobiliaria inmobiliaria = await db.Inmobiliaria.FindAsync(id);
            if (inmobiliaria == null)
            {
                return HttpNotFound();
            }
            return View(inmobiliaria);
        }

        // POST: Inmobiliaria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RazonSocial,Telefon")] Inmobiliaria inmobiliaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inmobiliaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inmobiliaria);
        }

        // GET: Inmobiliaria/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmobiliaria inmobiliaria = db.Inmobiliaria.Find(id);
            if (inmobiliaria == null)
            {
                return HttpNotFound();
            }
            return View(inmobiliaria);
        }

        // POST: Inmobiliaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Inmobiliaria inmobiliaria = await db.Inmobiliaria.FindAsync(id);
            db.Inmobiliaria.Remove(inmobiliaria);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
