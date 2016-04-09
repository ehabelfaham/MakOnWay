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
    public class AboutUsController : Controller
    {

        //
        // GET: /CompanyAboutUs/

        public ActionResult Index()
        {
            using (CPanelEntities context = new CPanelEntities())
            {

                return View(context.CompanyAboutUs.ToList());
            }
        }

        //
        // GET: /CompanyAboutUs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CompanyAboutUs/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CompanyAboutUsModel collection)
        {
            try
            {
                using (CPanelEntities context = new CPanelEntities())
                {
                    if (collection.Image_Path == null || collection.Image_Path.ContentLength == 0)
                    {
                        ModelState.AddModelError("Image_Path", "Required field");
                    }
                    if (ModelState.IsValid)
                    {
                        // TODO: Add insert logic here
                        CompanyAboutU NewOnject = new CompanyAboutU();
                        NewOnject.AboutUs_txt_Ar = collection.AboutUs_txt_Ar;
                        NewOnject.AboutUs_txt_Eng = collection.AboutUs_txt_Eng;
                        NewOnject.HomeTxt_Ar = collection.HomeTxt_Ar;
                        NewOnject.AboutUs_txt_Eng = collection.AboutUs_txt_Eng;
                        context.CompanyAboutUs.Add(NewOnject);
                        context.SaveChanges();
                        HttpPostedFileBase file = collection.Image_Path;
                        string filePath = "";
                        if (file!=null&&file.ContentLength > 0)
                        {
                            string NewImgName = string.Format("{0}{1}.{2}", NewOnject.id, Guid.NewGuid().ToString(), file.ContentType.Replace("image/", "").ToString());
                            HttpPostedFileBase uploadedImage = Request.Files[collection.Image_Path.FileName];
                            filePath = Path.Combine(HttpContext.Server.MapPath("/images/AboutUs"), Path.GetFileName(file.FileName.Replace(file.FileName.ToString(), NewImgName)));
                            file.SaveAs(filePath);
                            NewOnject.Image_Path = (NewImgName);
                            context.SaveChanges();
                        }
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
        // GET: /CompanyAboutUs/Edit/5

        public ActionResult Edit(int id)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                CompanyAboutUsModel OldObject = context.CompanyAboutUs.Where(a => a.id == id).Select(a =>
                    new CompanyAboutUsModel()
                    {
                        AboutUs_txt_Ar = a.AboutUs_txt_Ar,
                        AboutUs_txt_Eng = a.AboutUs_txt_Eng,
                        HomeTxt_Ar = a.HomeTxt_Ar,
                        HomeTxt_Eng = a.HomeTxt_Eng,
                        Image_PathStr = a.Image_Path != null ? a.Image_Path : ""
                    }
                    ).SingleOrDefault<CompanyAboutUsModel>();
                return View(OldObject);
            }
        }

        //
        // POST: /CompanyAboutUs/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, CompanyAboutUsModel collection)
        {
            try
            {
                using (CPanelEntities context = new CPanelEntities())
                {
                    CompanyAboutUsModel OldObject = new CompanyAboutUsModel();
                    if (TryUpdateModel(OldObject))
                    {
                        // TODO: Add insert logic here
                        CompanyAboutU NewOnject = context.CompanyAboutUs.Where(a => a.id == id).SingleOrDefault();
                        NewOnject.AboutUs_txt_Eng = OldObject.AboutUs_txt_Eng;
                        NewOnject.AboutUs_txt_Ar = OldObject.AboutUs_txt_Ar;
                        NewOnject.HomeTxt_Ar = collection.HomeTxt_Ar;
                        NewOnject.HomeTxt_Eng = collection.HomeTxt_Eng;
                        context.SaveChanges();
                        if (OldObject.Image_Path != null)
                        {
                            HttpPostedFileBase file = OldObject.Image_Path;
                            string filePath = "";
                            if (file!=null&&file.ContentLength > 0)
                            {
                                string NewImgName = string.Format("{0}{1}.{2}", NewOnject.id, Guid.NewGuid().ToString(), file.ContentType.Replace("image/", "").ToString());
                                if (System.IO.File.Exists(Server.MapPath("/images/AboutUs/" + NewOnject.Image_Path)))
                                {
                                    System.IO.File.Delete(Server.MapPath("/images/AboutUs/" + NewOnject.Image_Path));
                                }
                                HttpPostedFileBase uploadedImage = Request.Files[OldObject.Image_Path.FileName];
                                filePath = Path.Combine(HttpContext.Server.MapPath("/images/AboutUs"), Path.GetFileName(file.FileName.Replace(file.FileName.ToString(), NewImgName)));
                                file.SaveAs(filePath);
                                NewOnject.Image_Path = (NewImgName);
                                context.SaveChanges();
                            }
                        }
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
        // GET: /CompanyAboutUs/Delete/5

        public ActionResult Delete(int id)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                CompanyAboutU NewOnject = context.CompanyAboutUs.Where(a => a.id == id).SingleOrDefault();
                if (NewOnject != null)
                {
                    try
                    {
                        // Delete the object with the specified key
                        // and save changes to delete the row from the data source.
                        context.CompanyAboutUs.Remove(NewOnject);
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
