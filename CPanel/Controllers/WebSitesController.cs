using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPanel.Models.DAL;
using CPanel.Models;
using System.IO;
using System.Data;
using System.Web.Services;

namespace CPanel.Controllers
{
    public class WebSitesController : Controller
    {
        //
        // GET: /Categorys/

        public ActionResult Index()
        {
            using (CPanelEntities context = new CPanelEntities())
            {

                return View(context.WebSiteTables.ToList());
            }
        }

        //
        // GET: /Categorys/Create

        public ActionResult Create()
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                return View();
            }
        }

        //
        // POST: /Categorys/Create

        [HttpPost]
        public ActionResult Create(WebSiteDataModel collection)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                try
                {
                    if (collection.Image_Path == null || collection.Image_Path.ContentLength == 0)
                    {
                        ModelState.AddModelError("Image_Path", "Required field");
                    }
                    if (ModelState.IsValid)
                    {
                        // TODO: Add insert logic here
                        WebSiteTable NewOnject = new WebSiteTable();
                        NewOnject.WebSite_Src = collection.WebSite_Src;
                        context.WebSiteTables.Add(NewOnject);
                        context.SaveChanges();
                        HttpPostedFileBase file = collection.Image_Path;
                        string filePath = "";
                        if (file!=null&&file.ContentLength > 0)
                        {
                            string NewImgName = string.Format("{0}{1}.{2}", NewOnject.id, Guid.NewGuid().ToString(), file.ContentType.Replace("image/", "").ToString());
                            HttpPostedFileBase uploadedImage = Request.Files[collection.Image_Path.FileName];
                            filePath = Path.Combine(HttpContext.Server.MapPath("/images/WebSites"), Path.GetFileName(file.FileName.Replace(file.FileName.ToString(), NewImgName)));
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
                catch
                {
                    return View(collection);
                }
            }
        }

        //
        // GET: /Categorys/Edit/5

        public ActionResult Edit(int id)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                WebSiteTable obj = context.WebSiteTables.Where(a => a.id == id).SingleOrDefault();
                WebSiteDataModel OldObject = new WebSiteDataModel()
                    {
                        WebSite_Src = obj.WebSite_Src,
                        Image_PathStr = obj.Image_Path != null ? obj.Image_Path : ""
                    };
                return View(OldObject);
            }
        }

        //
        // POST: /Categorys/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, WebSiteDataModel collection)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                try
                {
                    WebSiteDataModel OldObject = new WebSiteDataModel();
                    if (TryUpdateModel(OldObject))
                    {
                        // TODO: Add insert logic here
                        WebSiteTable NewOnject = context.WebSiteTables.Where(a => a.id == id).SingleOrDefault();
                        NewOnject.WebSite_Src = OldObject.WebSite_Src;
                        context.SaveChanges();
                        if (OldObject.Image_Path != null)
                        {
                            HttpPostedFileBase file = OldObject.Image_Path;
                            string filePath = "";
                            if (file!=null&&file.ContentLength > 0)
                            {
                                string NewImgName = string.Format("{0}{1}.{2}", NewOnject.id, Guid.NewGuid().ToString(), file.ContentType.Replace("image/", "").ToString());
                                if (System.IO.File.Exists(Server.MapPath("/images/WebSites/" + NewOnject.Image_Path)))
                                {
                                    System.IO.File.Delete(Server.MapPath("/images/WebSites/" + NewOnject.Image_Path));
                                }
                                HttpPostedFileBase uploadedImage = Request.Files[OldObject.Image_Path.FileName];
                                filePath = Path.Combine(HttpContext.Server.MapPath("/images/WebSites"), Path.GetFileName(file.FileName.Replace(file.FileName.ToString(), NewImgName)));
                                file.SaveAs(filePath);
                                NewOnject.Image_Path = (NewImgName);
                                context.SaveChanges();
                            }
                        }
                    }

                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(collection);
                }
            }
        }

        //
        // GET: /Categorys/Delete/5

        public ActionResult Delete(int id)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                WebSiteTable Obj = context.WebSiteTables.Where(a => a.id == id).SingleOrDefault();
                if (Obj != null)
                {
                    try
                    {
                        context.WebSiteTables.Remove(Obj);
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
