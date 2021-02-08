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
<<<<<<< HEAD
        
        Task<T> Get(int id);
        Task<List<T>> GetAll();  
=======
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        T Update(T item);
        void Delete(int id);
        IQueryable<T> GetQuery();
        Task Save();
    }
}
