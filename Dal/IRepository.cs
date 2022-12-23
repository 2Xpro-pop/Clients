using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
public interface IRepository<T> where T: IIdPickable
{
    Task<IEnumerable<T>> GetAllAsync();
    Task UpdateAsync(T item);
    Task DeleteAsync(T item);
    Task AddAsync(T item);
    Task<T> SelectById(int id);
}
