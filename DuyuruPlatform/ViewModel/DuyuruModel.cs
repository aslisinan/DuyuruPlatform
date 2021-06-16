using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuyuruPlatform.ViewModel
{
    public class DuyuruModel
    {
        public int ID { get; set; }
        public string BASLIK { get; set; }
        public string ICERIK { get; set; }
        public System.DateTime DUYURU_TARIHI { get; set; }
    }
}