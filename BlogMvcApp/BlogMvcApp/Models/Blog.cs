using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class Blog
    {
        //[Required] komutunu istediğimiz property için kullanabiliriz not null (boş geçilemez) anlamındadır
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public string Icerik { get; set; }
        public DateTime EklenmeTarihi { get; set; } //Eğer tarihi form'dan eklemek istersek yeniden Datetime? yapmalıyız
        public bool Onay { get; set; }
        public bool Anasayfa { get; set; }    
        public int CategoryId { get; set; }
        //Navigation property
        //Programda kullanılacak
        public Category Category { get; set; }

    }
}
