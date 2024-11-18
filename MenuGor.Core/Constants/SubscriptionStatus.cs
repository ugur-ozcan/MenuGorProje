// File: MenuGor.Core/Constants/SubscriptionStatus.cs

namespace MenuGor.Core.Constants
{
    /// <summary>
    /// Abonelik durumları için enum
    /// </summary>
    public enum SubscriptionStatus
    {
        /// <summary>
        /// Aktif abonelik
        /// </summary>
        Active = 1,

        /// <summary>
        /// Süresi dolmuş abonelik
        /// </summary>
        Expired = 2,

        /// <summary>
        /// İptal edilmiş abonelik
        /// </summary>
        Cancelled = 3,

        /// <summary>
        /// Askıya alınmış abonelik
        /// </summary>
        Suspended = 4
    }
}