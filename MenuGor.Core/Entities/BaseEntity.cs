// File: MenuGor.Core/Entities/BaseEntity.cs

namespace MenuGor.Core.Entities
{
    /// <summary>
    /// Tüm entity'lerin miras aldığı temel sınıf
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Benzersiz tanımlayıcı
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Kaydı oluşturan kullanıcı
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Kayıt oluşturma tarihi
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Kaydı güncelleyen kullanıcı
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Son güncelleme tarihi
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Kaydı silen kullanıcı
        /// </summary>
        public string DeletedBy { get; set; }

        /// <summary>
        /// Silinme tarihi
        /// </summary>
        public DateTime? DeletedDate { get; set; }

        /// <summary>
        /// Silindi mi?
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Aktif mi?
        /// </summary>
        public bool IsActive { get; set; }

        // IPAddress alanını BaseEntity'den kaldırdık
    }
}