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
    /// Controller responsible for managing chiefcomplaintvector_test related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting chiefcomplaintvector_test information.
    /// </remarks>
    [Route("api/dynamic/chiefcomplaintvector_test")]
    [Authorize]
    public class ChiefComplaintVector_TestController : BaseApiController
    {
        private readonly IChiefComplaintVector_TestService _chiefComplaintVector_TestService;

        /// <summary>
        /// Initializes a new instance of the ChiefComplaintVector_TestController class with the specified context.
        /// </summary>
        /// <param name="ichiefcomplaintvector_testservice">The ichiefcomplaintvector_testservice to be used by the controller.</param>
        public ChiefComplaintVector_TestController(IChiefComplaintVector_TestService ichiefcomplaintvector_testservice)
        {
            _chiefComplaintVector_TestService = ichiefcomplaintvector_testservice;
        }

        /// <summary>Adds a new chiefcomplaintvector_test</summary>
        /// <param name="model">The chiefcomplaintvector_test data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] ChiefComplaintVector_Test model)
        {
            model.TenantId = TenantId;
            var id = _chiefComplaintVector_TestService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of chiefcomplaintvector_tests based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplaintvector_tests</returns>
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

            var result = _chiefComplaintVector_TestService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <returns>The chiefcomplaintvector_test data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _chiefComplaintVector_TestService.GetById(id);
            return Ok(result);
        }

        /// <summary>Deletes a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
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
            var status = _chiefComplaintVector_TestService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <param name="updatedEntity">The chiefcomplaintvector_test data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] ChiefComplaintVector_Test updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            updatedEntity.TenantId = TenantId;
            var status = _chiefComplaintVector_TestService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <param name="updatedEntity">The chiefcomplaintvector_test data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<ChiefComplaintVector_Test> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = _chiefComplaintVector_TestService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}