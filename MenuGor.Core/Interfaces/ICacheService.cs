// File: MenuGor.Core/Interfaces/ICacheService.cs

using System;

namespace MenuGor.Core.Interfaces
{
    /// <summary>
    /// Önbellek işlemleri için arayüz
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Belirtilen anahtara ait değeri getirir
        /// </summary>
        /// <typeparam name="T">Değerin tipi</typeparam>
        /// <param name="key">Anahtar</param>
        /// <returns>Önbellekteki değer</returns>
        T Get<T>(string key);

        /// <summary>
        /// Belirtilen anahtara değer atar
        /// </summary>
        /// <typeparam name="T">Değerin tipi</typeparam>
        /// <param name="key">Anahtar</param>
        /// <param name="value">Değer</param>
        /// <param name="expiry">Süre sonu (opsiyonel)</param>
        void Set<T>(string key, T value, TimeSpan? expiry = null);

        /// <summary>
        /// Belirtilen anahtarı önbellekten kaldırır
        /// </summary>
        /// <param name="key">Anahtar</param>
        void Remove(string key);
    }
}