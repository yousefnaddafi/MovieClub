using App.Core.Entities;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Core.ApplicationService.IRepositories
{
    public interface IMovieRepository<T>
    {
        void Insert(T item);
        
        T Get(int id);
        List<T> GetAll();
        
        T Update(T item);
        void Delete(int id);
        

        void Save();
    }
}
