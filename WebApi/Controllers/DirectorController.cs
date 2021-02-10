using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService DirectorService;

        public DirectorController(IDirectorService DirectorService)
        {
            this.DirectorService = DirectorService;
        }

        [HttpPost]
        public void Create(DirectorInputDto inputDto)
        {
            DirectorService.Create(inputDto);
        }

        [HttpPut]
        public Director Update(Director item)
        {
            this.DirectorService.Update(item);
            return item;
        }

        [HttpDelete]
        public int Delete(int id)
        {
            DirectorService.Delete(id);
            return id;
        }

        [HttpGet]
        public Task<Director> Get(int id)
        {
            return DirectorService.Get(id);
        }
    }
}
