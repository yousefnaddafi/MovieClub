using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using App.Infrastucture.EF.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infrastucture.EF.Repositories
{
    public class MovieEfRepository<T> : IMovieRepository<T> where T : class, IHasIdentity
    {
        private readonly MovieDbContext dbContext;

        public MovieEfRepository(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public  async Task Delete(int id)
        {
            var item =await this.dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
             this.dbContext.Remove(item);
        }
         
        public async Task<T> Get(int id)
        {
            return await this.dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await  this.dbContext.Set<T>().ToListAsync();
        }

        public void Insert(T item)
        {
            this.dbContext.Add<T>(item);

        }

        public async Task Save()
        {
             await this.dbContext.SaveChangesAsync();
        }

        public T Update(T item)
        {
            this.dbContext.Update(item);
            return  item;
        }

        public IQueryable<T> GetQuery()
        {
            return dbContext.Set<T>().AsQueryable();
        }
    }
}
