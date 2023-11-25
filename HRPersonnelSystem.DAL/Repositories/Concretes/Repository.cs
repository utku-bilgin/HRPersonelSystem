using HRPersonnelSystem.Core.BaseEntities;
using HRPersonnelSystem.DAL.Concrete.Context;
using HRPersonnelSystem.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.DAL.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        private readonly PersonnelSystemDbContext _dbContext;

        public Repository(PersonnelSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Context için kullanılacak yeni değişken ismidir.
        /// </summary>
        private DbSet<T> db { get => _dbContext.Set<T>(); }

        /// <summary>
        /// Ekleme işlemi için yapılan metottur.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await db.AddAsync(entity);
        }


        /// <summary>
        /// İstenilene şarta göre db içerisinde "hiç var mı?" anlamaında sorgulayan metottur.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await db.AnyAsync(predicate);
        }


        /// <summary>
        /// Kaç adet olduğunu döndüren metottur.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate=null)
        {

            return   await db.CountAsync(predicate);
        }


        /// <summary>
        /// Soft Silme işlemini sağlayan metottur.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => db.Update(entity));
        }


        /// <summary>
        /// Hard Silme işlemini sağlayan metottur.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task HardDeleteAsync(T entity) //SİLME
        {
            await Task.Run(() => db.Remove(entity));
            
        }


        /// <summary>
        /// İstenilen şarta göre liste şeklinde verileri döndüren metottur.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = db;
            if(predicate!=null)
            {
                query=query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }


        /// <summary>
        /// İstenilen şarta göre tek değer şeklinde verileri döndüren metottur.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = db;
            query=query.Where(predicate);
			if (includeProperties.Any())
				foreach (var item in includeProperties)
					query = query.Include(item);

			return await query.SingleAsync();
        }


        /// <summary>
        /// ID ye göre veriyi bulup getiren metottur.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await db.FindAsync(id);
        }


        /// <summary>
        /// Güncelleme işlemi sağlayan metottur.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> UpdateAsync(T entity)
        {
           await Task.Run(() => db.Update(entity));
            return entity;
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            var query = db.Where(predicate);

            return query;
        }
    }
}
