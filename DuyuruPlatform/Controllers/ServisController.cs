using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DuyuruPlatform.Models;
using DuyuruPlatform.ViewModel;


namespace DuyuruPlatform.Controllers
{
    public class ServisController : ApiController
    {
        DatabaseEntities db = new DatabaseEntities();

        SonucModel sonuc = new SonucModel();

        #region Duyuru
        [HttpGet]
        [Route("api/duyuruliste")]
        public List<DuyuruModel> DuyuruListe()
        {
            List<DuyuruModel> liste = db.DUYURU.Select(x => new DuyuruModel()
            {
                ID = x.ID,
                BASLIK = x.BASLIK,
                ICERIK = x.ICERIK,
                DUYURU_TARIHI = x.DUYURU_TARIHI

            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/duyurubyid({duyuruId}")]
        public DuyuruModel DuyuruById(int duyuruId)
        {
            DuyuruModel kayit = db.DUYURU.Where(x => x.ID == duyuruId).Select(y => new DuyuruModel
            {
                ID = y.ID,
                BASLIK = y.BASLIK,
                ICERIK = y.ICERIK,
                DUYURU_TARIHI = y.DUYURU_TARIHI
            }).SingleOrDefault();

            return kayit;
        }

        [HttpPost]
        [Route("api/duyuruekle")]
        public SonucModel DuyuruEkle(DuyuruModel model)
        {
            if (db.DUYURU.Count(s => s.DUYURU_TARIHI == model.DUYURU_TARIHI && s.BASLIK == model.BASLIK) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Aynı bilgiler ile bir duyuru yayınlanmıştır. Duyuru ile ilgili bir güncelleme var ise lütfen revize ediniz.";
                return sonuc;
            }

            DUYURU duyuru = new DUYURU();
            duyuru.BASLIK = model.BASLIK;
            duyuru.DUYURU_TARIHI = DateTime.Now;
            duyuru.ICERIK = model.ICERIK;
            db.DUYURU.Add(duyuru);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Duyuru ekleme işlemi başarılı.";
            return sonuc;
        }

        [HttpPut]
        [Route("api/duyuruduzenle")]
        public SonucModel duyuruDuzenle(DuyuruModel model)
        {
            DUYURU kayit = db.DUYURU.Where(x => x.ID == model.ID).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen duyuru bilgileri sistemde kayıtlı değildir.";
            }

            kayit.BASLIK = model.BASLIK;
            kayit.DUYURU_TARIHI = model.DUYURU_TARIHI;
            kayit.ICERIK = model.ICERIK;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Duyuru bilgileri güncelleme işlemi başarılı.";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/duyurusil/{duyuruid}")]
        public SonucModel DuyuruSil(int duyuruId)
        {
            DUYURU kayit = db.DUYURU.Where(x => x.ID == duyuruId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Duyuru kaydı bulunamadı.";
                return sonuc;
            }

            if (db.DUYURU.Count(z => z.ID == duyuruId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Duyuruyu okuması için kullanıcı atandığı için, duyuru silinemez!";
                return sonuc;
            }

            db.DUYURU.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Duyuru silme işlemi başarılı.";
            return sonuc;
        }
        #endregion

        #region KullaniciBilgileri   

        [HttpGet]
        [Route("api/kullanicibilgileriliste")]
        public List<KullaniciBilgileriModel> KullaniciBilgileriListe()
        {
            List<KullaniciBilgileriModel> liste = db.KULLANICI_BILGILERI.Select(x => new KullaniciBilgileriModel()
            {
                AD = x.AD,
                SOYAD = x.SOYAD,
                DUYURU_GRUP = x.DUYURU_GRUP,
                MAIL = x.MAIL,
                SIFRE = x.SIFRE,
                TELEFON = x.TELEFON,
                YETKI_GRUP = x.YETKI_GRUP
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/kullanicibilgileribyid")]
        public KullaniciBilgileriModel KullaniciBilgileriById(int kullaniciId)
        {
            KullaniciBilgileriModel liste = db.KULLANICI_BILGILERI.Where(z => z.ID == kullaniciId).Select(x => new KullaniciBilgileriModel()
            {
                AD = x.AD,
                SOYAD = x.SOYAD,
                DUYURU_GRUP = x.DUYURU_GRUP,
                MAIL = x.MAIL,
                SIFRE = x.SIFRE,
                TELEFON = x.TELEFON,
                YETKI_GRUP = x.YETKI_GRUP
            }).SingleOrDefault();

            return liste;
        }

        [HttpPost]
        [Route("api/kullaniciekle")]
        public SonucModel kullaniciEkle(KullaniciBilgileriModel model)
        {
            if (db.KULLANICI_BILGILERI.Count(z => z.MAIL == model.MAIL) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen mail adresi sisteme kayıtlıdır.";
            }

            KULLANICI_BILGILERI kullanici = new KULLANICI_BILGILERI();
            kullanici.MAIL = model.MAIL;
            kullanici.SIFRE = model.SIFRE;
            kullanici.AD = model.AD;
            kullanici.SOYAD = model.SOYAD;
            kullanici.TELEFON = model.TELEFON;
            kullanici.YETKI_GRUP = model.YETKI_GRUP;
            kullanici.DUYURU_GRUP = model.DUYURU_GRUP;
            db.KULLANICI_BILGILERI.Add(kullanici);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kullanıcı bilgileri kayıt işlemi başarılı.";
            return sonuc;
        }

        [HttpPut]
        [Route("api/kullaniciduzenle")]
        public SonucModel kullaniciDuzenle(KullaniciBilgileriModel model)
        {
            KULLANICI_BILGILERI kayit = db.KULLANICI_BILGILERI.Where(x => x.ID == model.ID).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen mail adresi sistemde kayıtlı değildir.";
            }

            kayit.MAIL = model.MAIL;
            kayit.SIFRE = model.SIFRE;
            kayit.AD = model.AD;
            kayit.SOYAD = model.SOYAD;
            kayit.TELEFON = model.TELEFON;
            kayit.YETKI_GRUP = model.YETKI_GRUP;
            kayit.DUYURU_GRUP = model.DUYURU_GRUP;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kullanıcı bilgileri güncelleme işlemi başarılı.";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/kullanicisil({kullaniciId}")]
        public SonucModel kullanicisil(int kullaniciId)
        {

            KULLANICI_BILGILERI kayit = db.KULLANICI_BILGILERI.Where(s => s.ID == kullaniciId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen bilgilere ait kullanıcı bulunamadı.";
                return sonuc;
            }

            if (db.KULLANICI_BILGILERI.Count(z => z.ID == kullaniciId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kullanıcıya okuması için duyuru atandığı için, kullanıcı silinemez!";
                return sonuc;
            }

            db.KULLANICI_BILGILERI.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Girilen kullanıcı bilgisi için silme işlemi başarılı.";
            return sonuc;
        }

        #endregion

        #region DuyuruOkunduBilgisi

        [HttpGet]
        [Route("api/duyuruokunduliste/{duyuruId}")]
        public List<DuyuruOkunduBilgisiModel> DuyuruOkunduListe(int duyuruId)
        {
            List<DuyuruOkunduBilgisiModel> liste = db.DUYURU_OKUNDUBILGI.Where(s => s.DUYURU_ID == duyuruId).Select(x => new DuyuruOkunduBilgisiModel()
            {
                DUYURU_ID = x.DUYURU_ID,
                KULLANICI_ID = x.KULLANICI_ID,
                OKUNDU = x.OKUNDU
            }).ToList();

            foreach (var i in liste)
            {
                i.DUYURU_ID = Convert.ToInt32(DuyuruById(i.DUYURU_ID));
                i.KULLANICI_ID = Convert.ToInt32(KullaniciBilgileriById(i.KULLANICI_ID));
                i.OKUNDU = Convert.ToBoolean(i.OKUNDU);
            }


            return liste;
        }

        [HttpGet]
        [Route("api/kullaniciDuyuruliste/{kullaniciId}")]
        public List<DuyuruOkunduBilgisiModel> kullaniciDuyuruliste(int kullaniciId)
        {
            List<DuyuruOkunduBilgisiModel> liste = db.DUYURU_OKUNDUBILGI.Where(s => s.KULLANICI_ID == kullaniciId).Select(x => new DuyuruOkunduBilgisiModel()
            {
                DUYURU_ID = x.DUYURU_ID,
                KULLANICI_ID = x.KULLANICI_ID,
                OKUNDU = x.OKUNDU
            }).ToList();

            foreach (var i in liste)
            {
                i.DUYURU_ID = Convert.ToInt32(DuyuruById(i.DUYURU_ID));
                i.KULLANICI_ID = Convert.ToInt32(KullaniciBilgileriById(i.KULLANICI_ID));
                i.OKUNDU = Convert.ToBoolean(i.OKUNDU);
            }

            return liste;
        }

        [HttpPost]
        [Route("api/duyuruKayitEkle")]
        public SonucModel duyuruKayitEkle(DUYURU_OKUNDUBILGI model)
        {
            if (db.DUYURU_OKUNDUBILGI.Count(s => s.DUYURU_ID == model.ID && s.KULLANICI_ID == model.KULLANICI_ID) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Belirtilen duyuru kullanıcıya daha önce atanmıştır!";
                return sonuc;
            }

            DUYURU_OKUNDUBILGI yeni = new DUYURU_OKUNDUBILGI();
            yeni.DUYURU_ID = model.DUYURU_ID;
            yeni.KULLANICI_ID = model.KULLANICI_ID;
            yeni.OKUNDU = model.OKUNDU;
            db.DUYURU_OKUNDUBILGI.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Duyuruya kullanıcı atama işlemi başarılı.";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/duyuruKayitSil/{duyuruKayitId}")]
        public SonucModel duyuruKayitSil(int duyuruKayitId)
        {
            DUYURU_OKUNDUBILGI kayit = db.DUYURU_OKUNDUBILGI.Where(s => s.DUYURU_ID == duyuruKayitId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Duyuru -> Kullanıcı kaydı bulunamadı.";
                return sonuc;
            }

            db.DUYURU_OKUNDUBILGI.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Duyuru -> Kullanıcı kaydı silindi.";

            return sonuc;
        }
        #endregion
    }
}
