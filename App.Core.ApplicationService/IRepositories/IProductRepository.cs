using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.IRepositories
{
    public interface IProductRepository
    {
        void Insert(Product product);
        void Save();
    }
}
