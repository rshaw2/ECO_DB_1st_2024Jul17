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
    /// Controller responsible for managing visitchiefcomplaintnotes related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting visitchiefcomplaintnotes information.
    /// </remarks>
    [Route("api/dynamic/visitchiefcomplaintnotes")]
    [Authorize]
    public class VisitChiefComplaintNotesController : BaseApiController
    {
        private readonly IVisitChiefComplaintNotesService _visitChiefComplaintNotesService;

        /// <summary>
        /// Initializes a new instance of the VisitChiefComplaintNotesController class with the specified context.
        /// </summary>
        /// <param name="ivisitchiefcomplaintnotesservice">The ivisitchiefcomplaintnotesservice to be used by the controller.</param>
        public VisitChiefComplaintNotesController(IVisitChiefComplaintNotesService ivisitchiefcomplaintnotesservice)
        {
            _visitChiefComplaintNotesService = ivisitchiefcomplaintnotesservice;
        }

        /// <summary>Adds a new visitchiefcomplaintnotes</summary>
        /// <param name="model">The visitchiefcomplaintnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] VisitChiefComplaintNotes model)
        {
            model.TenantId = TenantId;
            model.CreatedBy = UserId;
            model.CreatedOn = DateTime.UtcNow;
            var id = _visitChiefComplaintNotesService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of visitchiefcomplaintnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitchiefcomplaintnotess</returns>
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

            var result = _visitChiefComplaintNotesService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <returns>The visitchiefcomplaintnotes data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _visitChiefComplaintNotesService.GetById(id);
            return Ok(result);
        }

        /// <summary>Deletes a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
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
            var status = _visitChiefComplaintNotesService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <param name="updatedEntity">The visitchiefcomplaintnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] VisitChiefComplaintNotes updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            updatedEntity.TenantId = TenantId;
            updatedEntity.UpdatedBy = UserId;
            updatedEntity.UpdatedOn = DateTime.UtcNow;
            var status = _visitChiefComplaintNotesService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <param name="updatedEntity">The visitchiefcomplaintnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<VisitChiefComplaintNotes> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = _visitChiefComplaintNotesService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}