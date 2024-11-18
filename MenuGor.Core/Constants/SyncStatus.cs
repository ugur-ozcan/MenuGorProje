// File: MenuGor.Core/Constants/SyncStatus.cs

namespace MenuGor.Core.Constants
{
    /// <summary>
    /// Senkronizasyon durumları için enum
    /// </summary>
    public enum SyncStatus
    {
        /// <summary>
        /// Senkronizasyon başarılı
        /// </summary>
        Success = 1,

        /// <summary>
        /// Senkronizasyon başarısız
        /// </summary>
        Failed = 2,

        /// <summary>
        /// Senkronizasyon kısmen başarılı
        /// </summary>
        PartialSuccess = 3,

        /// <summary>
        /// Senkronizasyon devam ediyor
        /// </summary>
        InProgress = 4
    }
}