// File: MenuGor.Infrastructure/Data/Repository.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MenuGor.Core.Entities;
using MenuGor.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MenuGor.Infrastructure.Data
{
    /// <summary>
    /// Generic repository implementasyonu
    /// </summary>
    /// <typeparam name="T">Entity tipi</typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MenuGorDbContext _context;

        public Repository(MenuGorDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> spec)
        {
            return await _context.Set<T>().Where(spec).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> spec)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(spec);
        }
    }
}