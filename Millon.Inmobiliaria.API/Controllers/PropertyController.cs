using Microsoft.AspNetCore.Mvc;
using Millon.Inmobiliaria.Application.Services.IServices;
using Millon.Inmobiliaria.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Millon.Inmobiliaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyServices ServicesProperty;

        public PropertyController(IPropertyServices servicesProperty)
        {
            ServicesProperty = servicesProperty;
        }
        // GET: api/<PropertyController>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            var Result = ServicesProperty.GetAll();
            return Ok(Result);
        }

        // GET api/<PropertyController>/5
        [HttpGet("{idProperty}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get(int idProperty)
        {
            var Result = ServicesProperty.GetById(idProperty);
            return StatusCode(Result.StatusCode, Result);
        } 
        
        // GET api/<PropertyController>/5
        [HttpGet("/GetPropertyDetail/{idProperty}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetPropertyDetail(int idProperty)
        {
            var Result = ServicesProperty.GetByPropertyDetail(idProperty);
            return StatusCode(Result.StatusCode, Result);
        }

        // POST api/<PropertyController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] PropertyRequest entity)
        {
            var Result = await ServicesProperty.AddPropertyAsync(entity);
            return StatusCode(Result.StatusCode, Result);
        }

        [HttpPut("{idProperty}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put(int idProperty, [FromBody] PropertyUpdatePriceRequest entity)
        {
            var Result = await ServicesProperty.UpdatePrice(idProperty, entity);
            return StatusCode(Result.StatusCode, Result);
        }
    }
}
