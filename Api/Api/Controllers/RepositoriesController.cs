using Api.Entities;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    public class RepositoriesController : ControllerBase
    {
        private readonly RepositoriesService _service;

        public RepositoriesController(RepositoriesService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/repositories")]
        public async Task<ActionResult<List<RepositorieData>>> Get()
        {
            var response = await _service.GetRepositoriesChallenge();
            
            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
