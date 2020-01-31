using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlogMvcApp.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext> //BlogContext adında veritabanı yoksa veya model yapılarında bir değişiklik olursa bu sınıf çalışır
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> kategoriler = new List<Category>()
            {
                new Category(){KategoriAdi="C#"},
                new Category(){KategoriAdi="Asp.net MVC"},
                new Category(){KategoriAdi="Windows Form"},
                new Category(){KategoriAdi="C# Console"},
                new Category(){KategoriAdi="SQL"},
                new Category(){KategoriAdi="Diziler"},
            };

            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            }
            context.SaveChanges();

            List<Blog> bloglar = new List<Blog>
            {
                new Blog(){ Baslik="C# Hakkında", Aciklama="C# HakkındaC# Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Icerik="C# Hakkında C# Hakkında C# Hakkında C# Hakkında C# Hakkında", Resim="1.jpg", CategoryId=1},
                new Blog(){ Baslik="C# Hakkında", Aciklama="C# HakkındaC# Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-30), Anasayfa=false, Onay=false, Icerik="C# Hakkında C# Hakkında C# Hakkında C# Hakkında C# Hakkında", Resim="1.jpg", CategoryId=1},
                new Blog(){ Baslik="C# Hakkında", Aciklama="C# HakkındaC# Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Icerik="C# Hakkında C# Hakkında C# Hakkında C# Hakkında C# Hakkında", Resim="1.jpg", CategoryId=1},
                new Blog(){ Baslik=".Net Hakkında", Aciklama=".Net Hakkında .Net Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-20), Anasayfa=true, Onay=true, Icerik=".Net Hakkında .Net Hakkında .Net Hakkında .Net Hakkında .Net Hakkında", Resim="2.jpg", CategoryId=2},
                new Blog(){ Baslik=".Net Hakkında", Aciklama=".Net Hakkında .Net Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true, Onay=false, Icerik=".Net Hakkında .Net Hakkında .Net Hakkında .Net Hakkında .Net Hakkında", Resim="2.jpg", CategoryId=2},
                new Blog(){ Baslik=".Net Hakkında", Aciklama=".Net Hakkında .Net Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-17), Anasayfa=false, Onay=true, Icerik=".Net Hakkında .Net Hakkında .Net Hakkında .Net Hakkında .Net Hakkında", Resim="2.jpg", CategoryId=2},
                new Blog(){ Baslik="Windows Hakkında", Aciklama="Windows Hakkında Windows Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Icerik="Windows Hakkında Windows Hakkında Windows Hakkında Windows Hakkında Windows Hakkında", Resim="3.jpg", CategoryId=3},
                new Blog(){ Baslik="Windows Hakkında", Aciklama="Windows Hakkında Windows Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-5), Anasayfa=true, Onay=false, Icerik="Windows Hakkında Windows Hakkında Windows Hakkında Windows Hakkında Windows Hakkında", Resim="3.jpg", CategoryId=3},
                new Blog(){ Baslik="Windows Hakkında", Aciklama="Windows Hakkında Windows Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Icerik="Windows Hakkında Windows Hakkında Windows Hakkında Windows Hakkında Windows Hakkında", Resim="3.jpg", CategoryId=3},
                new Blog(){ Baslik="Console Hakkında", Aciklama="Console Hakkında Console Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-30), Anasayfa=true, Onay=true, Icerik="Console Hakkında Console Hakkında Console Hakkında Console Hakkında Console Hakkında", Resim="4.jpg", CategoryId=4},
                new Blog(){ Baslik="Console Hakkında", Aciklama="Console Hakkında Console Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=false, Onay=true, Icerik="Console Hakkında Console Hakkında Console Hakkında Console Hakkında Console Hakkında", Resim="4.jpg", CategoryId=4},
                new Blog(){ Baslik="Console Hakkında", Aciklama="Console Hakkında Console Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-12), Anasayfa=true, Onay=false, Icerik="Console Hakkında Console Hakkında Console Hakkında Console Hakkında Console Hakkında", Resim="4.jpg", CategoryId=4},
                new Blog(){ Baslik="Sql Hakkında", Aciklama="Sql Hakkında Sql Hakkında Sql Hakkında Sql Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-12), Anasayfa=true, Onay=true, Icerik="Sql Hakkında Sql Hakkında Sql Hakkında Sql Hakkında Sql Hakkında", Resim="5.jpg", CategoryId=5},
            };

            foreach (var item in bloglar)
            {
                context.Bloglar.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }

    }
}