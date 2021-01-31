using App.Core.ApplicationService.Dtos.ProductDtos;
using App.Core.ApplicationService.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public int Create(ProductInsertInputDto inputDto)
        {
            var model = new Entities.Product()
            {
                Title = inputDto.Title
            };
            productRepository.Insert(model);
            productRepository.Save();
            return model.Id;
        }
    }
}
