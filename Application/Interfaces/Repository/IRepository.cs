using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keiko.Application.Interfaces.Repository;

public interface IRepository<T> where T : class
{
    Task<List<T>> FindAllAsync();

    Task<T> FindByIdAsync(Guid id);

    Task<T> InsertAsync(T entity);

    Task<T> EditAsync(T entity);

    Task<T> DeleteAsync(T entity);
}