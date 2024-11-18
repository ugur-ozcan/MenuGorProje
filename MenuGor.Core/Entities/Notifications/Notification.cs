// File: MenuGor.Core/Entities/Notifications/Notification.cs

using System;
using MenuGor.Core.Constants;

namespace MenuGor.Core.Entities.Notifications
{
    /// <summary>
    /// Bildirimleri temsil eden entity
    /// </summary>
    public class Notification : BaseEntity
    {
        /// <summary>
        /// Bildirim başlığı
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Bildirim içeriği
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Bildirim türü
        /// </summary>
        public NotificationType Type { get; set; }

        /// <summary>
        /// Bildirimin alıcısı (kullanıcı ID'si)
        /// </summary>
        public int RecipientUserId { get; set; }

        /// <summary>
        /// Bildirimin okunup okunmadığı
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Bildirimin okunma tarihi
        /// </summary>
        public DateTime? ReadDate { get; set; }

        /// <summary>
        /// Bildirimin gönderilme tarihi
        /// </summary>
        public DateTime SentDate { get; set; }

        /// <summary>
        /// İlgili firma ID'si (varsa)
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// İlgili şube ID'si (varsa)
        /// </summary>
        public int? BranchId { get; set; }

        /// <summary>
        /// İlgili bayi ID'si (varsa)
        /// </summary>
        public int? DealerId { get; set; }

        /// <summary>
        /// Bildirim için ek veri (JSON formatında)
        /// </summary>
        public string AdditionalData { get; set; }
    }
}