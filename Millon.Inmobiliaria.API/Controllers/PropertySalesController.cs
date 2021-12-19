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
    public class PropertySalesController : ControllerBase
    {
        /// <summary>
        /// Interface IPropertyTraceServices
        /// </summary>
        private readonly IPropertyTraceServices ServicesPropertyTrace;

        /// <summary>
        /// Inicializacion de controller PropertySalesController
        /// </summary>
        /// <param name="propertyTraceServices"></param>
        public PropertySalesController(IPropertyTraceServices servicesPropertyTrace)
        {
            ServicesPropertyTrace = servicesPropertyTrace;
        }

        // GET: api/<PropertySalesController>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            var Result = ServicesPropertyTrace.GetAll();
            return Ok(Result);
        }

        // GET api/<PropertySalesController>/5
        [HttpGet("{idProperty}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get(int idProperty)
        {
            var Result = ServicesPropertyTrace.GetById(idProperty);
            return StatusCode(Result.StatusCode, Result);
        }

        // POST api/<PropertySalesController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] PropertyTraceRequest entity)
        {
            var Result = await ServicesPropertyTrace.AddPropertyAsync(entity);
            return StatusCode(Result.StatusCode, Result);
        }

    }
}
