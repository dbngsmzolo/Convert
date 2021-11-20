using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Core.Data
{
    public interface IEntityRepository<T> 
        where T : //keyword used  when imposing a constraint on the generic parameter T
        class, //It must be a class (reference type) meaning T can't be an int, float, double, DateTime or any other struct (value type)
        IEntity, //The type argument must be or implement the specified IEntity. Multiple interface constraints can be specified. The constraining interface can also be generic.
        new() //must have a public parameter-less default constructor. Must be specified last

    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);
    }
}
