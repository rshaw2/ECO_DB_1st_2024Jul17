using Microsoft.AspNetCore.Mvc;
using ECODB1st2024Jul17.Models;
using ECODB1st2024Jul17.Services;
using ECODB1st2024Jul17.Entities;
using ECODB1st2024Jul17.Filter;
using ECODB1st2024Jul17.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

namespace ECODB1st2024Jul17.Controllers
{
    /// <summary>
    /// Controller responsible for managing appointmentcounter related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting appointmentcounter information.
    /// </remarks>
    [Route("api/dynamic/appointmentcounter")]
    [Authorize]
    public class AppointmentCounterController : BaseApiController
    {
        private readonly IAppointmentCounterService _appointmentCounterService;

        /// <summary>
        /// Initializes a new instance of the AppointmentCounterController class with the specified context.
        /// </summary>
        /// <param name="iappointmentcounterservice">The iappointmentcounterservice to be used by the controller.</param>
        public AppointmentCounterController(IAppointmentCounterService iappointmentcounterservice)
        {
            _appointmentCounterService = iappointmentcounterservice;
        }

        /// <summary>Adds a new appointmentcounter</summary>
        /// <param name="model">The appointmentcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] AppointmentCounter model)
        {
            model.TenantId = TenantId;
            var id = _appointmentCounterService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of appointmentcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of appointmentcounters</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult Get([FromQuery] string filters, string searchTerm, int pageNumber = 1, int pageSize = 10, string sortField = null, string sortOrder = "asc")
        {
            List<FilterCriteria> filterCriteria = null;
            if (pageSize < 1)
            {
                return BadRequest("Page size invalid.");
            }

            if (pageNumber < 1)
            {
                return BadRequest("Page mumber invalid.");
            }

            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var result = _appointmentCounterService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <returns>The appointmentcounter data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _appointmentCounterService.GetById(id);
            return Ok(result);
        }

        /// <summary>Deletes a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var status = _appointmentCounterService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <param name="updatedEntity">The appointmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] AppointmentCounter updatedEntity)
        {
            if (id != updatedEntity.TenantId)
            {
                return BadRequest("Mismatched TenantId");
            }

            updatedEntity.TenantId = TenantId;
            var status = _appointmentCounterService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <param name="updatedEntity">The appointmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<AppointmentCounter> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = _appointmentCounterService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}