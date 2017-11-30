using System;
using System.Collections.Generic;
using System.Text;

namespace SLICKIce.DAL
{
    /// <summary>
    /// The mechanism responsible for managing savable data in the
    /// Repository pattern.
    /// </summary>
    /// <typeparam name="T">The type of record to use</param>
    public interface IRespository<T>
    {
        List<T> SelectAll();
        T SelectById(int id);
        void Insert(T record);
        void Update(T record);
        void Delete(int id);
        void Save();
    }
}