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
    /// Controller responsible for managing guidelinetranslationdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting guidelinetranslationdeviation information.
    /// </remarks>
    [Route("api/dynamic/guidelinetranslationdeviation")]
    [Authorize]
    public class GuidelineTranslationDeviationController : BaseApiController
    {
        private readonly IGuidelineTranslationDeviationService _guidelineTranslationDeviationService;

        /// <summary>
        /// Initializes a new instance of the GuidelineTranslationDeviationController class with the specified context.
        /// </summary>
        /// <param name="iguidelinetranslationdeviationservice">The iguidelinetranslationdeviationservice to be used by the controller.</param>
        public GuidelineTranslationDeviationController(IGuidelineTranslationDeviationService iguidelinetranslationdeviationservice)
        {
            _guidelineTranslationDeviationService = iguidelinetranslationdeviationservice;
        }

        /// <summary>Adds a new guidelinetranslationdeviation</summary>
        /// <param name="model">The guidelinetranslationdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] GuidelineTranslationDeviation model)
        {
            model.TenantId = TenantId;
            var id = _guidelineTranslationDeviationService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of guidelinetranslationdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinetranslationdeviations</returns>
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

            var result = _guidelineTranslationDeviationService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <returns>The guidelinetranslationdeviation data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _guidelineTranslationDeviationService.GetById(id);
            return Ok(result);
        }

        /// <summary>Deletes a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
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
            var status = _guidelineTranslationDeviationService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <param name="updatedEntity">The guidelinetranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] GuidelineTranslationDeviation updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            updatedEntity.TenantId = TenantId;
            var status = _guidelineTranslationDeviationService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <param name="updatedEntity">The guidelinetranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<GuidelineTranslationDeviation> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = _guidelineTranslationDeviationService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}