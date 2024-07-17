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
    /// Controller responsible for managing chiefcomplainttemplate related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting chiefcomplainttemplate information.
    /// </remarks>
    [Route("api/dynamic/chiefcomplainttemplate")]
    [Authorize]
    public class ChiefComplaintTemplateController : BaseApiController
    {
        private readonly IChiefComplaintTemplateService _chiefComplaintTemplateService;

        /// <summary>
        /// Initializes a new instance of the ChiefComplaintTemplateController class with the specified context.
        /// </summary>
        /// <param name="ichiefcomplainttemplateservice">The ichiefcomplainttemplateservice to be used by the controller.</param>
        public ChiefComplaintTemplateController(IChiefComplaintTemplateService ichiefcomplainttemplateservice)
        {
            _chiefComplaintTemplateService = ichiefcomplainttemplateservice;
        }

        /// <summary>Adds a new chiefcomplainttemplate</summary>
        /// <param name="model">The chiefcomplainttemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] ChiefComplaintTemplate model)
        {
            model.CreatedBy = UserId;
            model.CreatedOn = DateTime.UtcNow;
            model.TenantId = TenantId;
            var id = _chiefComplaintTemplateService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of chiefcomplainttemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplainttemplates</returns>
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

            var result = _chiefComplaintTemplateService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <returns>The chiefcomplainttemplate data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _chiefComplaintTemplateService.GetById(id);
            return Ok(result);
        }

        /// <summary>Deletes a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
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
            var status = _chiefComplaintTemplateService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <param name="updatedEntity">The chiefcomplainttemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] ChiefComplaintTemplate updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            updatedEntity.TenantId = TenantId;
            updatedEntity.UpdatedBy = UserId;
            updatedEntity.UpdatedOn = DateTime.UtcNow;
            var status = _chiefComplaintTemplateService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <param name="updatedEntity">The chiefcomplainttemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<ChiefComplaintTemplate> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = _chiefComplaintTemplateService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}