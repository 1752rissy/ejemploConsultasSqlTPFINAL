using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inmbiliariagestion.Models;

namespace Inmbiliariagestion.Controllers
{
    public class InquilinoController : Controller
    {
        private DptoEntities db = new DptoEntities();

        // GET: Inquilino
        public ActionResult Index()
        {
            var inquilino = db.Inquilino.Include(i => i.Inmobiliaria);
            return View(inquilino.ToList());
        }

        // GET: Inquilino/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquilino inquilino = db.Inquilino.Find(id);
            if (inquilino == null)
            {
                return HttpNotFound();
            }
            return View(inquilino);
        }

        // GET: Inquilino/Create
        public ActionResult Create()
        {
            ViewBag.RazonSocial = new SelectList(db.Inmobiliaria, "RazonSocial", "Telefon");
            return View();
        }

        // POST: Inquilino/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dni,Nombre,Apellido,RazonSocial")] Inquilino inquilino)
        {
            if (ModelState.IsValid)
            {
                db.Inquilino.Add(inquilino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RazonSocial = new SelectList(db.Inmobiliaria, "RazonSocial", "Telefon", inquilino.RazonSocial);
            return View(inquilino);
        }

        // GET: Inquilino/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquilino inquilino = db.Inquilino.Find(id);
            if (inquilino == null)
            {
                return HttpNotFound();
            }
            ViewBag.RazonSocial = new SelectList(db.Inmobiliaria, "RazonSocial", "Telefon", inquilino.RazonSocial);
            return View(inquilino);
        }

        // POST: Inquilino/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dni,Nombre,Apellido,RazonSocial")] Inquilino inquilino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inquilino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RazonSocial = new SelectList(db.Inmobiliaria, "RazonSocial", "Telefon", inquilino.RazonSocial);
            return View(inquilino);
        }

        // GET: Inquilino/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquilino inquilino = db.Inquilino.Find(id);
            if (inquilino == null)
            {
                return HttpNotFound();
            }
            return View(inquilino);
        }

        // POST: Inquilino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Inquilino inquilino = db.Inquilino.Find(id);
            db.Inquilino.Remove(inquilino);
            db.SaveChanges();
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
