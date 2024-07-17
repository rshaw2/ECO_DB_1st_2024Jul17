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
    /// Controller responsible for managing tenantinvoiceline related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting tenantinvoiceline information.
    /// </remarks>
    [Route("api/dynamic/tenantinvoiceline")]
    [Authorize]
    public class TenantInvoiceLineController : BaseApiController
    {
        private readonly ITenantInvoiceLineService _tenantInvoiceLineService;

        /// <summary>
        /// Initializes a new instance of the TenantInvoiceLineController class with the specified context.
        /// </summary>
        /// <param name="itenantinvoicelineservice">The itenantinvoicelineservice to be used by the controller.</param>
        public TenantInvoiceLineController(ITenantInvoiceLineService itenantinvoicelineservice)
        {
            _tenantInvoiceLineService = itenantinvoicelineservice;
        }

        /// <summary>Adds a new tenantinvoiceline</summary>
        /// <param name="model">The tenantinvoiceline data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] TenantInvoiceLine model)
        {
            model.TenantId = TenantId;
            model.CreatedOn = DateTime.UtcNow;
            var id = _tenantInvoiceLineService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of tenantinvoicelines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantinvoicelines</returns>
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

            var result = _tenantInvoiceLineService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific tenantinvoiceline by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoiceline</param>
        /// <returns>The tenantinvoiceline data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _tenantInvoiceLineService.GetById(id);
            return Ok(result);
        }

        /// <summary>Deletes a specific tenantinvoiceline by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoiceline</param>
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
            var status = _tenantInvoiceLineService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific tenantinvoiceline by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoiceline</param>
        /// <param name="updatedEntity">The tenantinvoiceline data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] TenantInvoiceLine updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            updatedEntity.TenantId = TenantId;
            updatedEntity.UpdatedOn = DateTime.UtcNow;
            var status = _tenantInvoiceLineService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific tenantinvoiceline by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoiceline</param>
        /// <param name="updatedEntity">The tenantinvoiceline data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<TenantInvoiceLine> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = _tenantInvoiceLineService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}