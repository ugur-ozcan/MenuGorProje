// Company.cs
using System.Collections.Generic;

namespace MenuGor.Core.Entities
{
    public class Company : BaseEntity
    {
        // Firma adı
        public string Name { get; set; }

        // URL için kullanılacak kısa ad
        public string Slug { get; set; }

        // İletişim bilgileri
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Sosyal medya bağlantıları
        public string InstagramLink { get; set; }

        // Veritabanı bağlantı bilgileri
        public string ConnectionString { get; set; }

        // Menü görünüm ayarları
        public string CategoryViewName { get; set; }
        public string ProductViewName { get; set; }

        // Şube kullanım durumu
        public bool HasBranches { get; set; }

        // Masa numarası kullanım durumu
        public bool UseTableNumbers { get; set; }

        // Tema ayarları
        public string ThemeSettings { get; set; } // JSON formatında saklanacak

        // Senkronizasyon ayarları
        public string SyncSettings { get; set; } // JSON formatında saklanacak

        // Bağlı olduğu bayi
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }

        // Firmaya ait şubeler
        public virtual ICollection<Branch> Branches { get; set; }

        // Firmaya ait kategoriler
        public virtual ICollection<Category> Categories { get; set; }

        // Firmaya ait ürünler
        public virtual ICollection<Product> Products { get; set; }
        public int BranchCount { get; set; } // Yeni eklenen property

    }
}