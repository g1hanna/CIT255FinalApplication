using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SLICKIce.DAL
{
    /// <summary>
    /// The mechanism responsible for managing savable data in the
    /// Repository pattern.
    /// </summary>
    /// <typeparam name="T">The type of record to use</param>
    public interface IRespositoryAsync<T> : IRespository<T> where T : class
    {
        Task<IEnumerable<T>> SelectAllAsync();
        Task<T> SelectByIdAsync(T record);
        Task SaveAsync();
        Task InsertAsync(T record);
        Task DeleteAsync(T record);
        Task UpdateAsync(T record);
    }
}