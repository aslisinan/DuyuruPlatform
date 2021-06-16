using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuyuruPlatform.ViewModel
{
    public class DuyuruOkunduBilgisiModel
    {
        public int ID { get; set; }
        public int DUYURU_ID { get; set; }
        public int KULLANICI_ID { get; set; }
        public bool OKUNDU { get; set; }

        public DuyuruModel duyuruBilgi { get; set; }

        public KullaniciBilgileriModel kullaniciBilgi { get; set; }
    }
}