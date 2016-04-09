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
    public class imgController : Controller
    {
        //
        // GET: /ImagesGallery/

        public ActionResult Index(int? Product_id)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                List<ImagesGallery> LstImagesGallery = context.ImagesGalleries.ToList();
                return View(LstImagesGallery);
            }
        }

        //
        // GET: /ImagesGallery/Create

        public ActionResult Create( )
        {
            return View();
        }

        //
        // POST: /ImagesGallery/Create

        [HttpPost]
        public ActionResult Create(MImageDataContext collection)
        {
            try
            {
                using (CPanelEntities context = new CPanelEntities())
                {
                    if (Request.Files.Count > 0)
                    {

                        foreach (string inputTagName in Request.Files)
                        {
                            // TODO: Add insert logic here
                            ImagesGallery Obj = new ImagesGallery();
                            context.ImagesGalleries.Add(Obj);
                            context.SaveChanges();
                            HttpPostedFileBase file = Request.Files[inputTagName];
                            string filePath = "";
                            if (file!=null&&file.ContentLength > 0)
                            {
                                string NewImgName = string.Format("{0}{1}.{2}", Obj.Image_id, Guid.NewGuid().ToString(), file.ContentType.Replace("image/", "").ToString());
                                HttpPostedFileBase uploadedImage = Request.Files[file.FileName];
                                filePath = Path.Combine(HttpContext.Server.MapPath("/images/img"), Path.GetFileName(file.FileName.Replace(file.FileName.ToString(), NewImgName)));
                                file.SaveAs(filePath);
                                Obj.Image_Path = (NewImgName);
                                context.SaveChanges();
                            }
                            else
                            {
                                context.ImagesGalleries.Remove(Obj);
                                context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("source1", "Required field");
                        ModelState.AddModelError("source2", "Required field");
                        ModelState.AddModelError("source3", "Required field");
                        ModelState.AddModelError("source4", "Required field");
                        return View(collection);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //
        // GET: /ImagesGallery/Delete/5

        public ActionResult Delete(int id, MImageDataContext collection)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                ImagesGallery Obj = context.ImagesGalleries.Where(a => a.Image_id == id).SingleOrDefault();
                if (Obj!=null)
                {
                    try
                    {
                        // Delete the object with the specified key
                        // and save changes to delete the row from the data source.
                        if (System.IO.File.Exists(Server.MapPath("/images/img/" + Obj.Image_Path)))
                        {
                            System.IO.File.Delete(Server.MapPath("/images/img/" + Obj.Image_Path));
                        }
                        context.ImagesGalleries.Remove(Obj);
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
