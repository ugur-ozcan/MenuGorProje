// File: MenuGor.Core/Constants/CacheKeys.cs

namespace MenuGor.Core.Constants
{
    /// <summary>
    /// Önbellek anahtarları için sabit değerler
    /// </summary>
    public static class CacheKeys
    {
        /// <summary>
        /// Firma menüsü için önbellek anahtarı
        /// </summary>
        public const string CompanyMenu = "CompanyMenu_{0}"; // {0} yerine CompanyId gelecek

        /// <summary>
        /// Şube menüsü için önbellek anahtarı
        /// </summary>
        public const string BranchMenu = "BranchMenu_{0}"; // {0} yerine BranchId gelecek

        /// <summary>
        /// Kullanıcı rolleri için önbellek anahtarı
        /// </summary>
        public const string UserRoles = "UserRoles_{0}"; // {0} yerine UserId gelecek

        /// <summary>
        /// Firma ayarları için önbellek anahtarı
        /// </summary>
        public const string CompanySettings = "CompanySettings_{0}"; // {0} yerine CompanyId gelecek
    }
}