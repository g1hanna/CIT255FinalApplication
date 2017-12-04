using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SLICKIce.DAL
{
    /// <summary>
    /// The mechanism responsible for managing savable data in the
    /// Repository pattern.
    /// </summary>
    /// <typeparam name="T">The type of record to use</param>
    public interface IRespository<T> : IDisposable where T : class
    {
        IQueryable<T> SelectAll();
        T SelectById(T record);
        void Insert(T record);
        void Update(T record);
        void Delete(T record);
        void Save();
    }
}