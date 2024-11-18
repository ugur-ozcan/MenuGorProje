// Product.cs
namespace MenuGor.Core.Entities
{
    public class Product : BaseEntity
    {
        // Ürün adı
        public string Name { get; set; }

        // Açıklama
        public string Description { get; set; }

        // Fiyat
        public decimal Price { get; set; }

        // Resim URL'i
        public string ImageUrl { get; set; }

        // Görüntüleme sırası
        public int DisplayOrder { get; set; }

        // Bağlı olduğu kategori
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Bağlı olduğu firma
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        // Bağlı olduğu şube (varsa)
        public int? BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}