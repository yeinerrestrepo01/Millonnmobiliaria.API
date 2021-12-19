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
    public class PropertyImageController : ControllerBase
    {
        /// <summary>
        /// Interface IPropertyImageServices
        /// </summary>
        private readonly IPropertyImageServices ServicesPropertyImage;

        public PropertyImageController(IPropertyImageServices servicesPropertyImage)
        {
            ServicesPropertyImage = servicesPropertyImage;
        }

        // GET: api/<PropertyImageController>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            var Result = ServicesPropertyImage.GetAll();
            return Ok(Result);
        }

        // GET api/<PropertyImageController>/5
        [HttpGet("{idPropertyImage}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get(int idPropertyImage)
        {
            var Result = ServicesPropertyImage.GetById(idPropertyImage);
            return StatusCode(Result.StatusCode, Result);
        }

        // POST api/<PropertyImageController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromForm] PropertyImageRequest entity)
        {
            var Result = await ServicesPropertyImage.AddPropertyImageAsync(entity);
            return StatusCode(Result.StatusCode, Result);
        }

        // PUT api/<PropertyImageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
