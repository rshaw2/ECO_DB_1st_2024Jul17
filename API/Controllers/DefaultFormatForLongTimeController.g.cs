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
    /// Controller responsible for managing defaultformatforlongtime related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting defaultformatforlongtime information.
    /// </remarks>
    [Route("api/dynamic/defaultformatforlongtime")]
    [Authorize]
    public class DefaultFormatForLongTimeController : BaseApiController
    {
        private readonly IDefaultFormatForLongTimeService _defaultFormatForLongTimeService;

        /// <summary>
        /// Initializes a new instance of the DefaultFormatForLongTimeController class with the specified context.
        /// </summary>
        /// <param name="idefaultformatforlongtimeservice">The idefaultformatforlongtimeservice to be used by the controller.</param>
        public DefaultFormatForLongTimeController(IDefaultFormatForLongTimeService idefaultformatforlongtimeservice)
        {
            _defaultFormatForLongTimeService = idefaultformatforlongtimeservice;
        }

        /// <summary>Adds a new defaultformatforlongtime</summary>
        /// <param name="model">The defaultformatforlongtime data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] DefaultFormatForLongTime model)
        {
            model.TenantId = TenantId;
            model.CreatedBy = UserId;
            model.CreatedOn = DateTime.UtcNow;
            var id = _defaultFormatForLongTimeService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of defaultformatforlongtimes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of defaultformatforlongtimes</returns>
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

            var result = _defaultFormatForLongTimeService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific defaultformatforlongtime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongtime</param>
        /// <returns>The defaultformatforlongtime data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _defaultFormatForLongTimeService.GetById(id);
            return Ok(result);
        }

        /// <summary>Deletes a specific defaultformatforlongtime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongtime</param>
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
            var status = _defaultFormatForLongTimeService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific defaultformatforlongtime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongtime</param>
        /// <param name="updatedEntity">The defaultformatforlongtime data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] DefaultFormatForLongTime updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            updatedEntity.TenantId = TenantId;
            updatedEntity.UpdatedBy = UserId;
            updatedEntity.UpdatedOn = DateTime.UtcNow;
            var status = _defaultFormatForLongTimeService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific defaultformatforlongtime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongtime</param>
        /// <param name="updatedEntity">The defaultformatforlongtime data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<DefaultFormatForLongTime> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = _defaultFormatForLongTimeService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}