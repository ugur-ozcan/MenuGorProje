// File: MenuGor.Core/Entities/BlockedIp.cs

namespace MenuGor.Core.Entities
{
    /// <summary>
    /// Engellenen IP adreslerini tutan entity
    /// </summary>
    public class BlockedIp : BaseEntity
    {
        /// <summary>
        /// Engellenen IP adresi
        /// </summary>
        public string BlockedAddress { get; set; }

        /// <summary>
        /// IP'nin ne zamana kadar engellendiği
        /// </summary>
        public DateTime BlockedUntil { get; set; }

        /// <summary>
        /// IP'nin engellenme nedeni
        /// </summary>
        public string BlockReason { get; set; }
    }
}