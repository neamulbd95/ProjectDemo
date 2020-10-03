using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectDemoBackEND.Data.IRepositories;

namespace ProjectDemoBackEND.Data.Repositories
{
    public class GenericRepository<TClass> : IGenericRepository<TClass> where TClass : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TClass> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TClass>();
        }

        public void add(TClass tclass)
        {
            _dbSet.Add(tclass);
        }

        public async Task<bool> delete(int id)
        {
            var tClass = await _dbSet.FindAsync(id);

            if(tClass == null)
            {
                return false;
            }
            
            _dbSet.Remove(tClass);
            return true;
        }

        public async Task<List<TClass>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<TClass>> GetByCondition(Expression<Func<TClass, bool>> condition)
        {
            return await _dbSet.Where(condition).ToListAsync();
        }

        public async Task<TClass> GetById(int id)
        {
            return  await _dbSet.FindAsync(id);
        }

        public async Task<TClass> GetSingle(Expression<Func<TClass, bool>> condition)
        {
            return await _dbSet.FirstOrDefaultAsync(condition);
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync()>0;
        }
    }
}