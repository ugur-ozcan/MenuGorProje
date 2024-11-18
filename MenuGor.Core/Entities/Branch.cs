// Branch.cs
using System.Collections.Generic;

namespace MenuGor.Core.Entities
{
    public class Branch : BaseEntity
    {
        // Bağlı olduğu firma
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        // Şube adı
        public string Name { get; set; }

        // URL için kullanılacak kısa ad
        public string Slug { get; set; }

        // Konum bilgisi
        public string Location { get; set; }

        // Veritabanı bağlantı bilgileri
        public string ConnectionString { get; set; }

        // Tema ayarları
        public string ThemeSettings { get; set; } // JSON formatında saklanacak

        // Senkronizasyon ayarları
        public string SyncSettings { get; set; } // JSON formatında saklanacak

        // Şubeye ait kategoriler
        public virtual ICollection<Category> Categories { get; set; }

        // Şubeye ait ürünler
        public virtual ICollection<Product> Products { get; set; }
    }
}