using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using App.Core.Entities.Model;
using App.Infrastucture.EF.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Infrastucture.EF.Repositories
{
    public class MovieEfRepository<T> : IMovieRepository<T> where T: class, IHasIdentity
    {
        private readonly MovieDbContext dbContext;

        public MovieEfRepository(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var item = this.dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
            this.dbContext.Remove(item);
        }

        public T Get(int id)
        {
            return this.dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return this.dbContext.Set<T>().ToList();
        }

        public IQueryable<T> Query => dbContext.Set<T>().AsQueryable();

        public void Insert(T item)
        {
            this.dbContext.Add<T>(item);

        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public T Update(T item)
        {
            this.dbContext.Update(item);
            return item;
        }

        public IQueryable<T> GetQuery()
        {
            return dbContext.Set<T>().AsQueryable();
        }

    }
}
