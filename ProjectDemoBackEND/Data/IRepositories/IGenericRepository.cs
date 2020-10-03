using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectDemoBackEND.Data.IRepositories
{
    public interface IGenericRepository<TClass> where TClass : class
    {
        Task<List<TClass>> GetAll();
        Task<TClass> GetById(int id);
        Task<List<TClass>> GetByCondition(Expression<Func<TClass, bool>> condition);
        Task<TClass> GetSingle(Expression<Func<TClass, bool>> condition);
        void add(TClass tclass);
        Task<bool> delete(int id);
        Task<bool> Save();
    }
}