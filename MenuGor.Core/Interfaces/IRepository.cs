// File: MenuGor.Core/Interfaces/IRepository.cs

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MenuGor.Core.Entities;

namespace MenuGor.Core.Interfaces
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    /// <typeparam name="T">Entity tipi</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Belirtilen ID'ye sahip entity'yi getirir
        /// </summary>
        /// <param name="id">Entity ID'si</param>
        /// <returns>Bulunan entity veya null</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Tüm entity'leri getirir
        /// </summary>
        /// <returns>Entity listesi</returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Belirtilen koşula uyan entity'leri getirir
        /// </summary>
        /// <param name="spec">Filtreleme koşulu</param>
        /// <returns>Koşula uyan entity listesi</returns>
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> spec);

        /// <summary>
        /// Yeni bir entity ekler
        /// </summary>
        /// <param name="entity">Eklenecek entity</param>
        /// <returns>Eklenen entity</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Bir entity'yi günceller
        /// </summary>
        /// <param name="entity">Güncellenecek entity</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Bir entity'yi siler
        /// </summary>
        /// <param name="entity">Silinecek entity</param>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Belirtilen koşula uyan ilk entity'yi getirir
        /// </summary>
        /// <param name="spec">Filtreleme koşulu</param>
        /// <returns>Koşula uyan ilk entity veya null</returns>
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> spec);
    }
}