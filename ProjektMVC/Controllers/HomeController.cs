using ProjektMVC.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjektMVC.Controllers
{
    public class HomeController : Controller
    {

        s13830Entities db = new s13830Entities();
        // GET: Home
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Przepis()
        {

            return View(db.Przepis.ToList());
        }




        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Przepi Przepis)
        {
            if (ModelState.IsValid)
            {
                db.Przepis.Add(Przepis);
                db.SaveChanges();
                return RedirectToAction("Przepis");
            }
            return View(Przepis);
        }





        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przepi Przepis = db.Przepis.Find(id);
            if (Przepis == null)
            {
                return HttpNotFound();
            }
            return View(Przepis);
        }

        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Przepi przepis = db.Przepis.Find(id);
            db.Przepis.Remove(przepis);
            db.SaveChanges();
            return RedirectToAction("Przepis");
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przepi przepis = db.Przepis.Find(id);
            if (przepis == null)
            {
                return HttpNotFound();
            }
            return View(przepis);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Przepi przepis)
        {
            if (ModelState.IsValid)
            {
                db.Entry<Przepi>(przepis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Przepis");

            }
            return View(przepis);
        }
    }
}