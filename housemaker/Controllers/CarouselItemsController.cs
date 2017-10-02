using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using housemaker.DAL;
using housemaker.Models;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace housemaker.Controllers
{
    public class CarouselItemsController : Controller
    {
        private SqlDbContext db = new SqlDbContext();

        // GET: CarouselItems
        public ActionResult Index()
        {
            return View(db.Photos.OrderByDescending(x => x.Id).ToList());
        }

        public ActionResult CarouselPartial()
        {
            return View(db.Photos.ToList());
        }

        // GET: CarouselItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselItem carouselItem = db.Photos.Find(id);
            if (carouselItem == null)
            {
                return HttpNotFound();
            }
            return View(carouselItem);
        }

        // GET: CarouselItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarouselItems/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsActive,IsShownCarousel,File,Headline,Text,Description,ButtonText,ButtonUrl")] CarouselItem carouselItem,
            HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                BinaryReader reader = null;

                try
                {
                    /*
                    if (upload != null && upload.ContentLength > 0)
                    {
                        carouselItem.Url = System.IO.Path.GetFileName(upload.FileName);
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            carouselItem.Photo = reader.ReadBytes(upload.ContentLength);
                        }
                        if (carouselItem.Photo != null && carouselItem.Photo.Length > 0)
                        {
                            carouselItem.Base64Image = Convert.ToBase64String(carouselItem.Photo);
                        }
                    }
                    */

                    if (carouselItem.File == null)
                        throw new ArgumentNullException("Ошибка загрузки файла");

                    carouselItem.File.InputStream.Position = 0;
                    reader = new BinaryReader(carouselItem.File.InputStream);
                    carouselItem.Photo = reader.ReadBytes(carouselItem.File.ContentLength);

                    var fileName = System.IO.Path.GetFileName(carouselItem.File.FileName);
                    var root = Server.MapPath("~/App_Data/photos");
                    var path = System.IO.Path.Combine(root, fileName);
                    FileInfo fileInfo = new FileInfo(path);
                    if (fileInfo.Exists)
                    {
                        var newname = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Name.LastIndexOf('.') - 1);
                        fileName = $"{newname}_{DateTime.Now:yyyyMMdd_HHmmss}{fileInfo.Extension}";
                        path = System.IO.Path.Combine(root, fileName);
                    }

                    carouselItem.Url = string.Concat("../App_Data/photos/", fileName);
                    carouselItem.File.SaveAs(path);

                    string ct = carouselItem.File.ContentType; //image/png

                    // byte[] data = new byte[carouselItem.File.ContentLength];
                    // carouselItem.Photo = new byte[carouselItem.File.ContentLength];
                    // carouselItem.File.InputStream.Read(carouselItem.Photo, 0, carouselItem.Photo.Length);


                    /*
                    if (carouselItem.Photo != null && data.Length > 0)
                    {
                        carouselItem.Photo = data;
                    }
                    else
                    {
                        using (Stream inputStream = carouselItem.File.InputStream)
                        {
                            MemoryStream memoryStream = inputStream as MemoryStream;
                            if (memoryStream == null)
                            {
                                memoryStream = new MemoryStream();
                                inputStream.CopyTo(memoryStream);
                            }
                            carouselItem.Photo = memoryStream.ToArray();
                        }
                    }
                    */

                    if (carouselItem.Photo == null || carouselItem.Photo.Length <= 0)
                        throw new InvalidOperationException("Ошибка при сохранении файла");

                    carouselItem.Base64Image = string.Concat("data:", ct, ";base64,", Convert.ToBase64String(carouselItem.Photo));

                    var cl = carouselItem.File.ContentLength;

                    db.Photos.Add(carouselItem);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                finally
                {
                    reader.Dispose();
                    if (reader != null)
                        reader = null;
                }
                return View(carouselItem);

            }

            return View(carouselItem);
        }

        // GET: CarouselItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselItem carouselItem = db.Photos.Find(id);
            if (carouselItem == null)
            {
                return HttpNotFound();
            }
            return View(carouselItem);
        }

        // POST: CarouselItems/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsActive,IsShownCarousel,Photo,Url,Base64Image,Headline,Text,Description,ButtonText,ButtonUrl")] CarouselItem carouselItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carouselItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carouselItem);
        }

        // GET: CarouselItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselItem carouselItem = db.Photos.Find(id);
            if (carouselItem == null)
            {
                return HttpNotFound();
            }
            return View(carouselItem);
        }

        // POST: CarouselItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarouselItem carouselItem = db.Photos.Find(id);
            db.Photos.Remove(carouselItem);
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
