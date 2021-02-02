using App.Core.ApplicationService.ApplicationSerrvices.Products;
using App.Core.ApplicationService.Dtos.ProductDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieService productService;

        public CustomerController(IMovieService productService)
        {
            this.productService = productService;
        }
        [HttpPost]
        public void Create(Movie inputDto)
        {
            productService.Create(inputDto);
        }
    }
}
