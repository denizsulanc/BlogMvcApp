using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace BlogMvcApp.Models
{
    //Bu class'a entity framework özelliklerini kazandırmamız gerekiyor
    //bunun için DbContext'den miras almamız gerekiyor bunu'da nugetlerden EntityFramework indirerek yapabiliriz
    public class BlogContext: DbContext //oluşacak veritabanı adı: BlogMvcApp.Models.BlogContext
    {
        public BlogContext():base("blogDb")
        {
            Database.SetInitializer(new BlogInitializer());
        }
        public DbSet<Blog> Bloglar { get; set; } 
        public DbSet<Category> Kategoriler { get; set; }

        //DbSet 

        //veritabanındaki içinde verileri tutan tablolar gibidir, list gibi çalışır
        //Generic tiptir yani istenilen entity tipini içinde tutabilir
    }
}