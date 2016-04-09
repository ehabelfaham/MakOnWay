using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPanel.Models.DAL;
using CPanel.Models;
using System.IO;
using System.Data;


namespace CPanel.Controllers
{
    public class ContactUsController : Controller
    {

        //
        // GET: /CompanyContactUs/

        public ActionResult Index()
        {
            using (CPanelEntities context = new CPanelEntities())
            {

                return View(context.CompanyContactUs.ToList());
            }
        }

        public JsonResult BrandList()
        {
            using (CPanelEntities context = new CPanelEntities())
            {

                return Json(context.CompanyContactUs.ToList(), JsonRequestBehavior.AllowGet);
            }
        }


        //
        // GET: /CompanyContactUs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CompanyContactUs/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CompanyContactUsModel collection)
        {
            try
            {
                using (CPanelEntities context = new CPanelEntities())
                {
                    if (ModelState.IsValid)
                    {
                        // TODO: Add insert logic here
                        CompanyContactU NewOnject = new CompanyContactU();
                        NewOnject.ContactUs_Ar = collection.ContactUs_Ar;
                        NewOnject.ContactUs_Eng = collection.ContactUs_Eng;
                        
                        context.CompanyContactUs.Add(NewOnject);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(collection);
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CompanyContactUs/Edit/5

        public ActionResult Edit(int id)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                CompanyContactUsModel OldObject = context.CompanyContactUs.Where(a => a.id == id).Select(a =>
                    new CompanyContactUsModel()
                    {
                        ContactUs_Ar = a.ContactUs_Ar,
                        ContactUs_Eng = a.ContactUs_Eng
                    }
                    ).SingleOrDefault<CompanyContactUsModel>();
                return View(OldObject);
            }
        }

        //
        // POST: /CompanyContactUs/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, CompanyContactUsModel collection)
        {
            try
            {
                using (CPanelEntities context = new CPanelEntities())
                {
                    CompanyContactUsModel OldObject = new CompanyContactUsModel();
                    if (TryUpdateModel(OldObject))
                    {
                        // TODO: Add insert logic here
                        CompanyContactU NewOnject = context.CompanyContactUs.Where(a => a.id == id).SingleOrDefault();
                        NewOnject.ContactUs_Eng = OldObject.ContactUs_Eng;
                        NewOnject.ContactUs_Ar = OldObject.ContactUs_Ar;
                        context.SaveChanges();
                    }

                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CompanyContactUs/Delete/5

        public ActionResult Delete(int id)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                CompanyContactU NewOnject = context.CompanyContactUs.Where(a => a.id == id).SingleOrDefault();
                if (NewOnject!=null)
                {
                    try
                    {
                        // Delete the object with the specified key
                        // and save changes to delete the row from the data source.
                        context.CompanyContactUs.Remove(NewOnject);
                        context.SaveChanges();
                    }
                    catch (OptimisticConcurrencyException ex)
                    {
                        throw new InvalidOperationException(string.Format(
                            "The product with an ID of '{0}' could not be deleted.\n"
                            + "Make sure that any related objects are already deleted.\n",
                            id), ex);
                    }
                }
                else
                {
                    throw new InvalidOperationException(string.Format(
                        "The product with an ID of '{0}' could not be found.\n"
                        + "Make sure that Product exists.\n",
                        id));
                }
                return RedirectToAction("Index");
            }
        }

    }
}
