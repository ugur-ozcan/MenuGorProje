// File: MenuGor.Core/Entities/Templates/Template.cs

using System;

namespace MenuGor.Core.Entities.Templates
{
    /// <summary>
    /// Menü şablonlarını temsil eden entity
    /// </summary>
    public class Template : BaseEntity
    {
        /// <summary>
        /// Şablon adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Şablon açıklaması
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Şablonun HTML içeriği
        /// </summary>
        public string HtmlContent { get; set; }

        /// <summary>
        /// Şablonun CSS içeriği
        /// </summary>
        public string CssContent { get; set; }

        /// <summary>
        /// Şablonun JavaScript içeriği
        /// </summary>
        public string JsContent { get; set; }

        /// <summary>
        /// Şablon önizleme resmi URL'i
        /// </summary>
        public string PreviewImageUrl { get; set; }

        /// <summary>
        /// Şablonun aktif olup olmadığı
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Şablonun oluşturulma tarihi
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Şablonu oluşturan kullanıcı ID'si
        /// </summary>
        public int CreatedByUserId { get; set; }

        /// <summary>
        /// Şablonun son güncelleme tarihi
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        /// <summary>
        /// Şablonu son güncelleyen kullanıcı ID'si
        /// </summary>
        public int? LastUpdatedByUserId { get; set; }
    }
}