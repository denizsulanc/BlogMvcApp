using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMvcApp.Models;

namespace BlogMvcApp.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int? id,string q) //soru işareti nullable özelliği veriyor ıd gelmezse tüm bloglar gelir
        {
            if (id != null) //id aynı olan kategorideki bloglar gelecek
            {
                var bloglar = db.Bloglar
                .Where(i => i.Onay == true && i.CategoryId == id)
                .OrderByDescending(i => i.EklenmeTarihi)
                .Select(i => new BlogModel
                {
                    Id = i.Id,
                    Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                    Aciklama = i.Aciklama,
                    EklenmeTarihi = i.EklenmeTarihi,
                    Anasayfa = i.Anasayfa,
                    Onay = i.Onay,
                    Resim = i.Resim,
                    KategoriAdi = i.Category.KategoriAdi,
                    CategoryId = i.CategoryId
                }).AsQueryable(); //Sorgunun devam etmesini sağlıyor
                if (string.IsNullOrEmpty(q) == false)
                {
                    bloglar = bloglar.Where(i => i.Baslik.Contains(q) || i.Aciklama.Contains(q));
                }
                return View(bloglar.ToList());
            }
            else
            {
                var bloglar = db.Bloglar
               .Where(i => i.Onay == true)
               .OrderByDescending(i => i.EklenmeTarihi)
               .Select(i => new BlogModel
               {
                   Id = i.Id,
                   Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                   Aciklama = i.Aciklama,
                   EklenmeTarihi = i.EklenmeTarihi,
                   Anasayfa = i.Anasayfa,
                   Onay = i.Onay,
                   Resim = i.Resim,
                   KategoriAdi = i.Category.KategoriAdi,
                   CategoryId = i.CategoryId
               }).AsQueryable(); //Sorgunun devam etmesini sağlıyor
                if (string.IsNullOrEmpty(q) == false)
                {
                    bloglar = bloglar.Where(i => i.Baslik.Contains(q) || i.Aciklama.Contains(q));
                }
                return View(bloglar.ToList());
            }
        }

        // GET: Blog
        public ActionResult Index()
        {
            var bloglar = db.Bloglar.Include(b => b.Category).OrderByDescending(i => i.EklenmeTarihi); //Her bloğun kategori bilgilerini de getirir
            return View(bloglar.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            var gelenKategori = db.Kategoriler.Find(blog.CategoryId);
            TempData["kategoriAdi"] = gelenKategori;

            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi"); //DropDownList de kullanılır seçilen kategori adına göre ıd tutar
            return View();
        }

        // POST: Blog/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Baslik,Aciklama,Resim,Icerik,CategoryId")] Blog blog) //Id ve eklenme tarihini sildik
        {
            if (ModelState.IsValid)
            {
                blog.EklenmeTarihi = DateTime.Now;

                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Aciklama,Resim,Icerik,Onay,Anasayfa,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(blog).State = EntityState.Modified; sadece güncellemek istediğimiz alanlar için aşağıdaki kodları yaparız

                var entity = db.Bloglar.Find(blog.Id);
                if (entity != null)
                {
                    entity.Baslik = blog.Baslik;
                    entity.Aciklama = blog.Aciklama;
                    entity.Resim = blog.Resim;
                    entity.Icerik = blog.Icerik;
                    entity.Onay = blog.Onay;
                    entity.Anasayfa = blog.Anasayfa;
                    entity.CategoryId = blog.CategoryId;

                    db.SaveChanges();
                    TempData["Blog"] = entity;
                    //RedirectToAction kullanarak TempData içindeki blog bilgisini taşıyabiliriz
                    return RedirectToAction("Index");
                }


            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
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
