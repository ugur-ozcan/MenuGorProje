// File: MenuGor.Core/Constants/NotificationTypes.cs

namespace MenuGor.Core.Constants
{
    /// <summary>
    /// Bildirim türleri için enum
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// E-posta bildirimi
        /// </summary>
        Email = 1,

        /// <summary>
        /// SMS bildirimi
        /// </summary>
        SMS = 2,

        /// <summary>
        /// Uygulama içi bildirim
        /// </summary>
        InApp = 3,

        /// <summary>
        /// Push notification
        /// </summary>
        Push = 4
    }
}