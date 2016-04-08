using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPanel.Models.DAL;

namespace CPanel.Controllers
{
    public class CityController : Controller
    {
        private CPanelEntities db = new CPanelEntities();

        //
        // GET: /City/

        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.Country);
            return View(cities.ToList());
        }


        //
        // GET: /City/Create

        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "ArName");
            return View();
        }

        //
        // POST: /City/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Countries, "ID", "ArName", city.CountryID);
            return View(city);
        }

        //
        // GET: /City/Edit/5

        public ActionResult Edit(int id = 0)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "ArName", city.CountryID);
            return View(city);
        }

        //
        // POST: /City/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "ArName", city.CountryID);
            return View(city);
        }

        //
        // Get: /City/Delete/5

        [HttpGet, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);
            db.Cities.Remove(city);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}