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
        public async Task Create(DirectorInputDto inputDto)
        {
            await DirectorService.Create(inputDto);
        }

        [HttpPut]
        public async Task<string> Update(DirectorUpdateDto item)
        {
            await this.DirectorService.Update(item);
            return $"the {item.Id} has been updated";
        }

        [HttpDelete]
        public async Task<int> Delete(int id)
        {
            await DirectorService.Delete(id);
            return id;
        }

        [HttpGet]
        public async Task<DirectorOutputDto> Get(int id)
        {
            return await DirectorService.Get(id);
        }
    }
}
