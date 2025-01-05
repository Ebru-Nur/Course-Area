using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Shared.Constants
{
    public static class Message
    {
        public static class User
        {
            public const string KAYIT_BASARILI = "Kayıt olma başarılı";
            public const string GIRIS_BASARILI = "Giriş başarılı";
            public const string GUNCELLENDI = "Kullanıcı güncelleme başarılı";
            public const string SILINDI = "Kullanıcı silme başarılı";
            public const string EMAIL_BULUNMAKTA = "Email zaten kayıt olmuş";
            public const string KULLANICI_BULUNAMADI = "Girilen bilgiler ile hesap bulunamadı";
            public const string SIFRE_YANLIS = "Şifre yanlış girilmiş";


        }

        public static class Common
        {
            public const string GENEL_HATA = "Bir hata oluştu, daha sonra tekrar deneyin";
            public const string ISLEM_BASARILI = "İşlem başarılı";
            public const string VERI_GETIRILDI = "Veri getirme işlemi başarılı";
            public const string YETKISIZ_ERISIM = "Bu işlemi yapmaya yetkiniz yoktur";

        }

        public static class Course
        {
            public const string KAYIT_BASARILI = "Kurs kayıt işlemi başarılı";
        }
    }
}
