using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuyuruPlatform.ViewModel
{
    public class KullaniciBilgileriModel
    {
        public int ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string TELEFON { get; set; }
        public string MAIL { get; set; }
        public string SIFRE { get; set; }
        public string YETKI_GRUP { get; set; }
        public string DUYURU_GRUP { get; set; }
    }
}