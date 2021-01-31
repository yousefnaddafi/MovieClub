using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using App.Infrastucture.EF.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastucture.EF.Repositories
{
    public class ProductEfRepository : IProductRepository
    {
        private readonly ProductDbContext dbContext;

        public ProductEfRepository(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Insert(Product product)
        {
            //add to dbCOntext
            
        }

        public void Save()
        {
           //Save dbContext
        }
    }
}
