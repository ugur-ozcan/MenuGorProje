// Category.cs
using System.Collections.Generic;

namespace MenuGor.Core.Entities
{
    public class Category : BaseEntity
    {
        // Kategori adı
        public string Name { get; set; }

        // Açıklama
        public string Description { get; set; }

        // Görüntüleme sırası
        public int DisplayOrder { get; set; }

        // Bağlı olduğu firma
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        // Bağlı olduğu şube (varsa)
        public int? BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        // Kategoriye ait ürünler
        public virtual ICollection<Product> Products { get; set; }
    }
}