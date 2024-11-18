// Dealer.cs
using System;
using System.Collections.Generic;

namespace MenuGor.Core.Entities
{
    public class Dealer : BaseEntity
    {
        // Bayi adı
        public string Name { get; set; }

        // İletişim bilgileri
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Giriş bilgileri
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Şifrenin hash'lenmiş hali

        // Adres bilgisi
        public string Address { get; set; }

        // API anahtarı
        public string ApiKey { get; set; }

        // İzin verilen IP adresleri (virgülle ayrılmış liste)
        public string AllowedIpAddresses { get; set; }

        // Hesap durumu
        public bool IsLocked { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LastLoginDate { get; set; }

        // Bayiye bağlı firmalar
        public virtual ICollection<Company> Companies { get; set; }

        // Şifre değiştirme metodu (örnek implementasyon)
        public void ChangePassword(string newPasswordHash)
        {
            // Yeni şifreyi set et
            PasswordHash = newPasswordHash;

            // Başarısız giriş denemelerini sıfırla
            FailedLoginAttempts = 0;

            // Hesabı kilidi varsa kaldır
            IsLocked = false;

            // Son şifre değişikliği tarihini güncelle
            UpdatedDate = DateTime.UtcNow;
        }

        // Başarısız giriş denemesi kaydetme metodu
        public void RecordFailedLoginAttempt()
        {
            FailedLoginAttempts++;

            // Eğer başarısız deneme sayısı belirli bir limiti aşarsa hesabı kilitle
            if (FailedLoginAttempts >= 5) // Örnek olarak 5 deneme
            {
                IsLocked = true;
            }
        }

        // Başarılı giriş kaydetme metodu
        public void RecordSuccessfulLogin()
        {
            LastLoginDate = DateTime.UtcNow;
            FailedLoginAttempts = 0;
            IsLocked = false;
        }
    }
}