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
    public class AlquilerController : Controller
    {
        private DptoEntities db = new DptoEntities();

        // GET: Alquiler
        public ActionResult Index()
        {
            var aLQUIILER = db.ALQUIILER.Include(a => a.Inquilino);
            return View(aLQUIILER.ToList());
        }

        // GET: Alquiler/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALQUIILER aLQUIILER = db.ALQUIILER.Find(id);
            if (aLQUIILER == null)
            {
                return HttpNotFound();
            }
            return View(aLQUIILER);
        }

        public ActionResult GetAlquilerByEstado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAlquilerByEstado(string estado)
        {
            string query = $"SELECT * from ALQUIILER where Estado = {estado}";
            IEnumerable<ALQUIILER> data = db.Database.SqlQuery<ALQUIILER>(query);

            return View(data.ToList());
        }

        // GET: Alquiler/Create
        public ActionResult Create()
        {
            ViewBag.Dni = new SelectList(db.Inquilino, "Dni", "Nombre");
            return View();
        }

        // POST: Alquiler/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoDpto,Domicilio,Tarifa,Aumento,Dni, Estado")] ALQUIILER aLQUIILER)
        {
            if (ModelState.IsValid)
            {
                db.ALQUIILER.Add(aLQUIILER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dni = new SelectList(db.Inquilino, "Dni", "Nombre", aLQUIILER.Dni);
            return View(aLQUIILER);
        }

        // GET: Alquiler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALQUIILER aLQUIILER = db.ALQUIILER.Find(id);
            if (aLQUIILER == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dni = new SelectList(db.Inquilino, "Dni", "Nombre", aLQUIILER.Dni);
            return View(aLQUIILER);
        }

        // POST: Alquiler/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoDpto,Domicilio,Tarifa,Aumento,Dni")] ALQUIILER aLQUIILER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLQUIILER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dni = new SelectList(db.Inquilino, "Dni", "Nombre", aLQUIILER.Dni);
            return View(aLQUIILER);
        }

        // GET: Alquiler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALQUIILER aLQUIILER = db.ALQUIILER.Find(id);
            if (aLQUIILER == null)
            {
                return HttpNotFound();
            }
            return View(aLQUIILER);
        }

        // POST: Alquiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALQUIILER aLQUIILER = db.ALQUIILER.Find(id);
            db.ALQUIILER.Remove(aLQUIILER);
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
