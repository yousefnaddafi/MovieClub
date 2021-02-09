using App.Core.Entities;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.IRepositories
{
    public interface IMovieRepository<T>
    {
        void Insert(T item);
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        T Update(T item);
        void Delete(int id);
        IQueryable<T> GetQuery();
        Task Save();
    }
}
