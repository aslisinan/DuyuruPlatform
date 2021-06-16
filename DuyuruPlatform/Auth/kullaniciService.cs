using System.Linq;
using DuyuruPlatform.ViewModel;
using DuyuruPlatform.Models;


namespace DuyuruPlatform.Auth
{
    public class kullaniciService
    {
        DatabaseEntities db = new DatabaseEntities();
        public KullaniciBilgileriModel UyeOturumAc(string mail, string sifre)
        {
            KullaniciBilgileriModel kullanici = db.KULLANICI_BILGILERI.Where(x => x.MAIL == mail && x.SIFRE == sifre).Select(z => new KullaniciBilgileriModel()
            {
                ID=z.ID,
                AD=z.AD,
                SOYAD=z.SOYAD,
                TELEFON=z.TELEFON,
                SIFRE=z.SIFRE,
                YETKI_GRUP=z.YETKI_GRUP,
                DUYURU_GRUP=z.DUYURU_GRUP

            }).SingleOrDefault();
            return kullanici;
        }
    }
}