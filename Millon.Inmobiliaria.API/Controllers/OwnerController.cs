using Microsoft.AspNetCore.Mvc;
using Millon.Inmobiliaria.Application.Services.IServices;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Millon.Inmobiliaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerServices ServiceOwner;

        public OwnerController(IOwnerServices serviceOwner)
        {
            ServiceOwner = serviceOwner;
        }
        // GET: api/<OwnerController>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            var Result = ServiceOwner.GetAll();
            return Ok(Result);
        }

        // GET api/<OwnerController>/5
        [HttpGet("{idOwner}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get(int idOwner)
        {
            var Result = ServiceOwner.GetById(idOwner);
            return StatusCode(Result.StatusCode, Result);
        }

        // POST api/<OwnerController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] OwnerResquest entity)
        {
            var Result = await ServiceOwner.AddOwnerAsync(entity);
            return StatusCode(Result.StatusCode, Result);
        }
    }
}
