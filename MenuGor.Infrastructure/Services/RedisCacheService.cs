// File: MenuGor.Infrastructure/Services/RedisCacheService.cs

using System;
using MenuGor.Core.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MenuGor.Infrastructure.Services
{
    /// <summary>
    /// Redis önbellek servisi implementasyonu
    /// </summary>
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _cache;

        /// <summary>
        /// Redis bağlantısını oluşturur
        /// </summary>
        /// <param name="redis">Redis bağlantı çoklayıcısı</param>
        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
        }

        /// <summary>
        /// Belirtilen anahtara ait değeri getirir
        /// </summary>
        /// <typeparam name="T">Değerin tipi</typeparam>
        /// <param name="key">Anahtar</param>
        /// <returns>Önbellekteki değer</returns>
        public T Get<T>(string key)
        {
            var value = _cache.StringGet(key);
            return value.HasValue ? JsonConvert.DeserializeObject<T>(value) : default;
        }

        /// <summary>
        /// Belirtilen anahtara değer atar
        /// </summary>
        /// <typeparam name="T">Değerin tipi</typeparam>
        /// <param name="key">Anahtar</param>
        /// <param name="value">Değer</param>
        /// <param name="expiry">Süre sonu (opsiyonel)</param>
        public void Set<T>(string key, T value, TimeSpan? expiry = null)
        {
            _cache.StringSet(key, JsonConvert.SerializeObject(value), expiry);
        }

        /// <summary>
        /// Belirtilen anahtarı önbellekten kaldırır
        /// </summary>
        /// <param name="key">Anahtar</param>
        public void Remove(string key)
        {
            _cache.KeyDelete(key);
        }
    }
}