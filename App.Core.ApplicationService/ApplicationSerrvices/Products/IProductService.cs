using App.Core.ApplicationService.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Products
{
    public interface IProductService
    {
        int Create(ProductInsertInputDto inputDto);
    }
}
