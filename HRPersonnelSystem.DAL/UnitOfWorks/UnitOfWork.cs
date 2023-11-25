using HRPersonnelSystem.DAL.Concrete.Context;
using HRPersonnelSystem.DAL.Repositories.Abstractions;
using HRPersonnelSystem.DAL.Repositories.Concretes;
using HRPersonnelSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonnelSystemDbContext _dbContext;

        public UnitOfWork(PersonnelSystemDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
       

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        /// <summary>
        /// Asenkron kullanılmaması durumunda kayıt işlemini sağlayan metottur.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Asenkron olarak kayıt işlemini sağlayan metottur.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Jenerik olarak tüm repository metotlarına ulaşılmasını sağlayan metottur.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(_dbContext);
        }
    }
}
