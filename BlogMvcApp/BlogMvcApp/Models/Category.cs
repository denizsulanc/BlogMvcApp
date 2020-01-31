using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class Category
    {
        //[Key] yazsaydık primary key'in adını değiştirebilirdik ve onun kütüphanesini yukarı eklememiz gerekirdi
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        //Programda kullanılacak
        public List<Blog> Bloglar { get; set; }
    }
}