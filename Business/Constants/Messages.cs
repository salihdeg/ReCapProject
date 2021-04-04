using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string EntityAdded = "Nesne eklendi";
        public static string NameInvalid = "İsim geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string Listed = "Listelendi";
        public static string Updated = "Düzenlendi";
        public static string Deleted = "Silindi";
        public static string EntityInvalid = "Nesne Kural Dışı";
        public static string DefaultError = "Bir Hata Oldu";
        public static string NotAvailable = "Müsait Değil";
        public static string MaxImageOfCarExceeded = "Arabanın Maximum Resmi Aşıldı";
        public static string FileDeleteError = "Dosya Silinirken Hata Oluştu";
        public static string FileCreateError = "Dosya Kopyalanırken Bir Hata Oluştu";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";
        public static string UserRegistered = "Kullanıcı Kaydedildi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Paralo Hatası";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Kayıtlı";
        public static string AccessTokenCreated = "Erişim Jetonu Oluşturuldu";
        public static string PaymentSuccess = "Payment Success";
    }
}
