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
    public class FilesController : Controller
    {
        //
        // GET: /FileUpload/

        public ActionResult Index()
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                
                if (Session["UserId"] != null)
                {
                    int userId = (int)Session["UserId"];
                    List<FileUpload> LstFileUpload = context.FileUploads.Where(a => a.UserId == userId).ToList();
                    return View(LstFileUpload);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        //
        // GET: /FileUpload/

        public ActionResult PublicIndex()
        {
            using (CPanelEntities context = new CPanelEntities())
            {

                if (Session["UserId"] != null)
                {
                    int userId = (int)Session["UserId"];
                    EmployeeData obj = context.EmployeeDatas.Where(a => a.Emp_id == userId).SingleOrDefault();
                    List<FileUpload> LstFileUpload = context.FileUploads.Include("EmployeeData").Where(a => a.UserId != userId && a.IsPublic == true).ToList();
                    if(obj.Emp_IsAdmin==true)
                    {
                         LstFileUpload = context.FileUploads.Include("EmployeeData").Where(a => a.UserId != userId).ToList();
                    }
                    else
                    {
                         LstFileUpload = context.FileUploads.Include("EmployeeData").Where(a => a.UserId != userId && a.IsPublic == true).ToList();
                    }
                    return View(LstFileUpload);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        //
        // GET: /FileUpload/Create

        public ActionResult Create()
        {
            ViewBag.IsPublicLst = new SelectList(new[]
    {
        new { Value = "True", Text = "Public" },
        new { Value = "False", Text = "Private" },
    }, "Value", "Text");
            return View();
        }
        //
        // POST: /FileUpload/Create

        [HttpPost]
        public ActionResult Create(FileUpload collection)
        {
            try
            {
                using (CPanelEntities context = new CPanelEntities())
                {
                    if (Request.Files.Count > 0)
                    {


                        if (Session["UserId"] != null)
                        {
                            int userId = (int)Session["UserId"];
                            foreach (string inputTagName in Request.Files)
                            {
                                // TODO: Add insert logic here
                                FileUpload Obj = new FileUpload();
                                context.FileUploads.Add(Obj);
                                context.SaveChanges();
                                Obj.UserId = userId;
                                Obj.IsPublic = collection.IsPublic;
                                context.SaveChanges();
                                HttpPostedFileBase file = Request.Files[inputTagName];
                                string filePath = "";
                                if (file != null && file.ContentLength > 0)
                                {
                                    Obj.Name = file.FileName;
                                    string NewImgName = string.Format("{0}{1}{2}", Obj.Id, Guid.NewGuid().ToString(), file.FileName.ToString());
                                    HttpPostedFileBase uploadedImage = Request.Files[file.FileName];
                                    filePath = Path.Combine(HttpContext.Server.MapPath("/FileUpload"), Path.GetFileName(file.FileName.Replace(file.FileName.ToString(), NewImgName)));
                                    file.SaveAs(filePath);
                                    Obj.ImagePath = (NewImgName);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    context.FileUploads.Remove(Obj);
                                    context.SaveChanges();
                                }
                            }
                        }
                    }
                    else
                    {
                        ViewBag.IsPublicLst = new SelectList(new[]
    {
        new { Value = "True", Text = "Public" },
        new { Value = "False", Text = "Private" },
    }, "Value", "Text");
                        ModelState.AddModelError("source1", "Required field");
                        return View(collection);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.IsPublicLst = new SelectList(new[]
    {
        new { Value = "True", Text = "Public" },
        new { Value = "False", Text = "Private" },
    }, "Value", "Text");
                ModelState.AddModelError("source1", "Required field");
                return View(collection);
            }
        }
        //
        // GET: /FileUpload/Delete/5

        public ActionResult Delete(int id, MImageDataContext collection)
        {
            using (CPanelEntities context = new CPanelEntities())
            {
                FileUpload Obj = context.FileUploads.Where(a => a.Id == id).SingleOrDefault();
                if (Obj!=null)
                {
                    try
                    {
                        // Delete the object with the specified key
                        // and save changes to delete the row from the data source.
                        if (System.IO.File.Exists(Server.MapPath("/FileUpload/" + Obj.ImagePath)))
                        {
                            System.IO.File.Delete(Server.MapPath("/FileUpload/" + Obj.ImagePath));
                        }
                        context.FileUploads.Remove(Obj);
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

