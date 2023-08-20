using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Araba Eklendi";
        public static string Deleted = "Araba Silindi";
        public static string Updated = "Araba Güncellendi";
        public static string CarAddedError = "Araba en az 2 karakter olmalı ve günlük fiyat 0'dan fazla olmalıdır.";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string Failed = "Araba teslim edilmemiş";
        public static string ArabaListele = "Araba Listelendi";
        public static string BrandEkelendi = "Brand ekelendi";
        public static string BrandGuncellendi = "Brand güncellendi";
        public static string BrandSilindi = "Brand silindi";
        public static string RenkEklendi = "Renk eklendi";
        public static string RenkGuncellendi = "Renk Güncellendi";
        public static string RenkSilindi = "Renk Silindi";
        public static string CarCouldNotUpdated = "Araba güncellenemedi";
        public static string AuthorizationDenied = "Erişim reddedildi";
        public static string AccessTokenCreated = "Erişime  izin verildi";
        public static string UserNotFound = "Böyle bir kullanıcı yok";
       public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserRegistered = "Kullanıcı Kayıtlı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";

        public static string ArabaBulunmadı = "Araba Bulunmadı";
        public static string ArabaKiralandi = "Araba Kiralandı";
        public static string KiralamaTarihiBugundenOnceOlamaz="Kiralama Tarihi Bugünden Önce Olamaz";
        public static string AracIadeTarihBosBirakilamaz ="Bu Araç da Daha Sonra Bir Tarihte Kiralanmış Olduğu İçin İade Tarihi Boş Bırakılamaz";
        public static string AracGeriGetirilmedi = "Araç Geri Getirilmedi";
        public static string AracKiralamaTarihiDahaDolmadi = "Araç Kiralama Tarihi Daha Dolmadi";
        public static string AracZatenKiralanmisDurumda = "Araç Zaten Kiralanmiş Durumda";



        public static string ImageAdded = "Fotoğraf Eklendi!";
        public static string ImageDeleted = "Fotoğraf Silindi!";
        public static string ImageUpdated = "Fotoğraf Güncellendi!";
        public static string ImageGetAll = "Fotoğraflar Listelendi!";
        public static string ImageNotFound = "Fotoğraf Bulunamadı!";
        public static string ImageError = "Fotoğraf Eklenemedi!";
        public static string ImageGetById = "Fotoğraf ID Bilgisine Göre Getirildi!";

        public static string MusteriBulunamadı = "Musteri Bulunamadı";

        public static string KartNumarasiYalnizcaHarflerdenOlusmalidir = "Kart Numarası Yalnızca Harflerden Oluşmalıdır";
        public static string YilinSonİkiHanesiGirilmelidir= "Yılın Son İki HanesiGirilmelidir";

        public static string KartBilgileriYanlis = "Kart bilgileri yanlış";
        public static string OdemeGerceklesti = "Ödeme Başarılı";



        public static string ArabaResimleriListelendi = "Araba Resimleri Listelendi";
        public static string ArabaResimiListelendi = "Araba Resimi Listelendi";
        public static string ArabaResmiEklendi= "Araba Resmi Eklendi";
        public static string ArabaResimGuncellemeHatasi = "Resim Guncelleme Hatası";
        public static string ArabaResimGuncellendi="Araba Resim Guncellendi";
        public static string ArabaResimSilmeHatasi="Araba Resim Silme Hatası";
        public static string ArabaResimSilindi ="Araba Resim Silindi";
        public static string ArabaninResmiYok = "Arabanın Resmi Yok";
        public static string ResimYuklemeSayisinaUlasildi = "Resim Yükleme Sayısına Ulaşıldı";



        public static string PuanYetersiz = "Puan Yetersiz";



        public static string KullaniciYok = "Kullanıcı Yok";
        public static string KulaniciSilindi = "Kulanici Silindi";

        public static string EpostayaUlasilamaz= "Kullanıcı E-postası Kullanılamaz";
        public static string KulaniciGuncellendi = "Kulanıcı güncellendi";
        public static string KulSifreGun = "Kulanıcı Şifre Güncellendi";
    }
}
