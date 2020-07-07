using System.Collections.Generic;
using AutoMapper;

namespace Project0
{
    //Repository interface to be used by all Individual Repos
    //Includes basic Insert, Update, Delete, and Find Methods
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}