
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RentCar2.Models;
using RentCar2.ViewModels;

namespace RentCar.Controllers
{

    public class ServisController : ApiController
    {
        DBEntities1 db = new DBEntities1();
        SonucModel sonuc = new SonucModel();
        #region Kategori
        [HttpGet]
        [Route("api/kategoriliste")]
        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> liste = db.Kategori.Select(x => new KategoriModel()
            {
                kategoriId = x.kategoriId,
                kategoriAdi = x.kategoriAdi
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/kategoribyid/{kategoriId}")]
        public KategoriModel KategoriById(string kategoriId)

        {
            KategoriModel kayit = db.Kategori.Where(s => s.kategoriId == kategoriId).Select(x => new KategoriModel()
            {
                kategoriId = x.kategoriId,
                kategoriAdi = x.kategoriAdi
            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(KategoriModel model)
        {
            if (db.Kategori.Count(s => s.kategoriAdi == model.kategoriAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Var olan kategori eklenemez.";
                return sonuc;
            }
            Kategori yeni = new Kategori();
            yeni.kategoriId = Guid.NewGuid().ToString();
            yeni.kategoriAdi = model.kategoriAdi;
            db.Kategori.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori başarı ile kaydedildi.";
            return sonuc;

        }

        [HttpPut]
        [Route("api/kategoriduzenle")]
        public SonucModel KategoriDuzenle(KategoriModel model)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriId == model.kategoriId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori bulunamadı";
                return sonuc;
            }
            kayit.kategoriAdi = model.kategoriAdi;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Düzenlendi.";
            return sonuc;

        }
        [HttpDelete]
        [Route("api/kategorisil/{kategoriId}")]
        public SonucModel KategoriSil(string kategoriId)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriId == kategoriId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori bulunamadı";
                return sonuc;
            }
            if (db.Araba.Count(s => s.arabakategori == kategoriId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategoriye kayıtlı araba olduğundan kategori silinemedi";
                return sonuc;

            }
            db.Kategori.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silindi";

            return sonuc;
        }
        #endregion
        #region Araba
        [HttpGet]
        [Route("api/arabaliste")]
        public List<ArabaModel> ArabaListe()
        {
            List<ArabaModel> liste = db.Araba.Select(x => new ArabaModel()
            {
                arabaId = x.arabaId,
                arabaadi = x.arabaadi,
                arabakategori = x.arabakategori,
                arabaModel = x.arabaModel,
                imgUrl = x.imgUrl,
                kiralikdurum = x.kiralikdurum,
                kirUcret = x.kirUcret,
                vites = x.vites,
                arabakategoriAdi = x.Kategori.kategoriAdi
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/arababyid/{arabaId}")]
        public ArabaModel ArabaById(string arabaId)

        {
            ArabaModel kayit = db.Araba.Where(s => s.arabaId == arabaId).Select(x => new ArabaModel()
            {
                arabaId = x.arabaId,
                arabaadi = x.arabaadi,
                arabakategori = x.arabakategori,
                arabaModel = x.arabaModel,
                imgUrl = x.imgUrl,
                kiralikdurum = x.kiralikdurum,
                kirUcret = x.kirUcret,
                vites = x.vites,
                arabakategoriAdi = x.Kategori.kategoriAdi
            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/arabaekle")]
        public SonucModel ArabaEkle(ArabaModel model)
        {
            if (db.Araba.Count(s => s.arabaadi == model.arabaadi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Var olan araba eklenemez.";
                return sonuc;
            }
            Araba yeni = new Araba();
            yeni.arabaId = Guid.NewGuid().ToString();
            yeni.arabaadi = model.arabaadi;
            yeni.arabakategori = model.arabakategori;
            yeni.vites = model.vites;
            yeni.kiralikdurum = model.kiralikdurum;
            yeni.imgUrl = model.imgUrl;
            yeni.arabaModel = model.arabaModel;
            yeni.kirUcret = model.kirUcret;

            db.Araba.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Araba başarı ile kaydedildi.";
            return sonuc;

        }

        [HttpPut]
        [Route("api/arabaduzenle")]
        public SonucModel ArabaDuzenle(ArabaModel model)
        {
            Araba kayit = db.Araba.Where(s => s.arabaId == model.arabaId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Araba bulunamadı";
                return sonuc;
            }
            kayit.arabaadi = model.arabaadi;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Araba Düzenlendi.";
            return sonuc;

        }
        [HttpDelete]
        [Route("api/arabasil/{arabaId}")]
        public SonucModel Araba(string arabaId)
        {
            Araba kayit = db.Araba.Where(s => s.arabaId == arabaId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Araba bulunamadı";
                return sonuc;
            }
            if (kayit.kiralikdurum == 1)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Araba kiralık durumda olduğundan silinemez.";
                return sonuc;

            }
            db.Araba.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Araba Silindi";

            return sonuc;
        }
        #endregion
        #region Uye
        [HttpGet]
        [Route("api/uyeliste")]
        public List<UyeModel> UyeListe()
        {
            List<UyeModel> liste = db.Uye.Select(x => new UyeModel()
            {
                uyeId = x.uyeId,
                adsoyad = x.adsoyad,
                admin = x.admin,
                mail = x.mail,
                parola = x.parola,
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/uyebyid/{uyeId}")]
        public UyeModel UyeById(string uyeId)

        {
            UyeModel kayit = db.Uye.Where(s => s.uyeId == uyeId).Select(x => new UyeModel()
            {
                uyeId = x.uyeId,
                admin = x.admin,
                adsoyad = x.adsoyad,
                mail = x.mail,
                parola = x.parola,
            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/uyeekle")]
        public SonucModel UyeEkle(UyeModel model)
        {
            if (db.Uye.Count(s => s.adsoyad == model.adsoyad) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Var olan Üye eklenemez.";
                return sonuc;
            }
            Uye yeni = new Uye();
            yeni.uyeId = Guid.NewGuid().ToString();
            yeni.adsoyad = model.adsoyad;
            yeni.mail = model.mail;
            yeni.admin = model.admin;
            yeni.parola = model.parola;
            db.Uye.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye başarı ile kaydedildi.";
            return sonuc;

        }

        [HttpPut]
        [Route("api/uyeduzenle")]
        public SonucModel UyeDuzenle(UyeModel model)
        {
            Uye kayit = db.Uye.Where(s => s.uyeId == model.uyeId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Uye bulunamadı";
                return sonuc;
            }
            kayit.adsoyad = model.adsoyad;
            kayit.mail = model.mail;
            kayit.parola = model.parola;
            kayit.admin = model.admin;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Düzenlendi.";
            return sonuc;

        }
        [HttpDelete]
        [Route("api/uyesil/{uyeId}")]
        public SonucModel UyeSil(string uyeId)
        {
            Uye kayit = db.Uye.Where(s => s.uyeId == uyeId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye bulunamadı";
                return sonuc;
            }
            if (db.KiraKayit.Count(s => s.kimeKiraladi == uyeId) > 0 || db.KiraKayit.Count(s => s.kimKiraladi == uyeId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Uyeye kayıtlı araba olduğundan uye silinemedi";
                return sonuc;

            }
            db.Uye.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Silindi";

            return sonuc;
        }
        #endregion
        #region Kirakayit
        [HttpGet]
        [Route("api/kiraKayitliste")]
        public List<KiraKayitModel> KiraKayitListe()
        {
            List<KiraKayitModel> liste = db.KiraKayit.Select(x => new KiraKayitModel()
            {
                kiraKayitId = x.kiraKayitId,
                kimKiraladi = x.kimKiraladi,
                kimeKiraladi = x.kimeKiraladi,
                kirTarih = x.kirTarih,
                iadeTarih = x.iadeTarih,
                kirArabaId = x.kirArabaId
            }).ToList();
            foreach (var kayit in liste)
            {
                kayit.kirArabaBilgisi = ArabaById(kayit.kirArabaId);
                kayit.kimeKiraladiBilgisi = UyeById(kayit.kimeKiraladi);
                kayit.kimKiraladiBilgisi = UyeById(kayit.kimKiraladi);

            }

            return liste;
        }

        [HttpGet]
        [Route("api/kiraKayitbyid/{kiraKayitId}")]
        public KiraKayitModel KiraKayitById(string kiraKayitId)

        {
            KiraKayitModel kayit = db.KiraKayit.Where(s => s.kiraKayitId == kiraKayitId).Select(x => new KiraKayitModel()
            {
                kiraKayitId = x.kiraKayitId,
                kimKiraladi = x.kimKiraladi,
                kimeKiraladi = x.kimeKiraladi,
                kirTarih = x.kirTarih,
                iadeTarih = x.iadeTarih,
                kirArabaId = x.kirArabaId,
                kirArabaBilgisi = new ArabaModel()
                {
                    arabaId = x.kirArabaId,
                    arabaadi = x.Araba.arabaadi,
                    arabakategori = x.Araba.arabakategori,
                    arabaModel = x.Araba.arabaModel,
                    imgUrl = x.Araba.imgUrl,
                    kiralikdurum = x.Araba.kiralikdurum,
                    kirUcret = x.Araba.kirUcret,
                    vites = x.Araba.vites
                },
                kimeKiraladiBilgisi = new UyeModel()
                {
                    adsoyad = x.Uye.adsoyad,
                    mail= x.Uye.mail,
                    parola= x.Uye.parola,
                    uyeId =x.Uye.uyeId,
                    admin = x.Uye.admin

                },
                kimKiraladiBilgisi = new UyeModel()
                {
                    adsoyad = x.Uye.adsoyad,
                    mail = x.Uye.mail,
                    parola = x.Uye.parola,
                    uyeId = x.Uye.uyeId,
                    admin = x.Uye.admin

                }
            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/kiraKayitekle")]
        public SonucModel KiraKayitEkle(KiraKayitModel model)
        {
            if (db.KiraKayit.Count(s => s.kimKiraladi == model.kimKiraladi && s.kimeKiraladi == model.kimeKiraladi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Var olan kiralama kaydı eklenemez.";
                return sonuc;
            }
            KiraKayit yeni = new KiraKayit();
            yeni.kiraKayitId = Guid.NewGuid().ToString();
            yeni.kirArabaId = model.kirArabaId;
            yeni.kimKiraladi = model.kimKiraladi;
            yeni.kimeKiraladi = model.kimeKiraladi;
            yeni.kirTarih = model.kirTarih;
            yeni.iadeTarih = model.iadeTarih;
            db.KiraKayit.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "KiraKayit başarı ile kaydedildi.";
            return sonuc;

        }

        [HttpPut]
        [Route("api/kiraKayitduzenle")]
        public SonucModel KiraKayitDuzenle(KiraKayitModel model)
        {
            KiraKayit kayit = db.KiraKayit.Where(s => s.kiraKayitId == model.kiraKayitId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "KiraKayit bulunamadı";
                return sonuc;
            }
            kayit.kimKiraladi = model.kimKiraladi;
            kayit.kimeKiraladi = model.kimeKiraladi;
            kayit.kirTarih = model.kirTarih;
            kayit.iadeTarih = model.iadeTarih;
            kayit.kirArabaId = model.kirArabaId;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "KiraKayit Düzenlendi.";
            return sonuc;

        }
        [HttpDelete]
        [Route("api/kiraKayitsil/{kiraKayitId}")]
        public SonucModel KiraKayitSil(string kiraKayitId)
        {
            KiraKayit kayit = db.KiraKayit.Where(s => s.kiraKayitId == kiraKayitId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "KiraKayit bulunamadı";
                return sonuc;
            }
            db.KiraKayit.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "KiraKayit Silindi";

            return sonuc;
        }
        #endregion
    }
}