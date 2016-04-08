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
    public class CompanyProfileController : Controller
    {

        //
        // GET: /CompanyProfile/

        public ActionResult Index()
        {
            using (CPanelEntities context = new CPanelEntities())
            {

                return View(context.CompanyProfiles.ToList());
            }
        }

        public JsonResult BrandList()
        {
            using (CPanelEntities context = new CPanelEntities())
            {

                return Json(context.CompanyProfiles.ToList(), JsonRequestBehavior.AllowGet);
            }
        }


        //
        // GET: /CompanyProfile/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CompanyProfile/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CompanyProfileModel collection)
        {
            try
            {
                using (CPanelEntities context = new CPanelEntities())
                {
                    if (ModelState.IsValid)
                    {
                        // TODO: Add insert logic here
                        CompanyProfile NewOnject = new CompanyProfile();
                        NewOnject.Company_Profile_Ar = collection.Company_Profile_Ar;
                        NewOnject.Company_Profile_Eng = collection.Company_Profile_Eng;
                        NewOnject.InsertedDate = DateTime.Now;
                        context.CompanyProfiles.Add(NewOnject);
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
        // GET: /CompanyProfile/Edit/5

        public ActionResult Edit(int id)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                CompanyProfileModel OldObject = context.CompanyProfiles.Where(a => a.id == id).Select(a =>
                    new CompanyProfileModel()
                    {
                        Company_Profile_Ar = a.Company_Profile_Ar,
                        Company_Profile_Eng = a.Company_Profile_Eng
                    }
                    ).SingleOrDefault<CompanyProfileModel>();
                return View(OldObject);
            }
        }

        //
        // POST: /CompanyProfile/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, CompanyProfileModel collection)
        {
            try
            {
                using (CPanelEntities context = new CPanelEntities())
                {
                    CompanyProfileModel OldObject = new CompanyProfileModel();
                    if (TryUpdateModel(OldObject))
                    {
                        // TODO: Add insert logic here
                        CompanyProfile NewOnject = context.CompanyProfiles.Where(a => a.id == id).SingleOrDefault();
                        NewOnject.Company_Profile_Eng = OldObject.Company_Profile_Eng;
                        NewOnject.Company_Profile_Ar = OldObject.Company_Profile_Ar;
                        NewOnject.InsertedDate = DateTime.Now;
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
        // GET: /CompanyProfile/Delete/5

        public ActionResult Delete(int id)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                CompanyProfile NewOnject = context.CompanyProfiles.Where(a => a.id == id).SingleOrDefault();
                if (NewOnject!=null)
                {
                    try
                    {
                        // Delete the object with the specified key
                        // and save changes to delete the row from the data source.
                        context.CompanyProfiles.Remove(NewOnject);
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
