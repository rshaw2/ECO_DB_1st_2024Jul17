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
    /// Controller responsible for managing stockadjustmentcounter related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting stockadjustmentcounter information.
    /// </remarks>
    [Route("api/dynamic/stockadjustmentcounter")]
    [Authorize]
    public class StockAdjustmentCounterController : BaseApiController
    {
        private readonly IStockAdjustmentCounterService _stockAdjustmentCounterService;

        /// <summary>
        /// Initializes a new instance of the StockAdjustmentCounterController class with the specified context.
        /// </summary>
        /// <param name="istockadjustmentcounterservice">The istockadjustmentcounterservice to be used by the controller.</param>
        public StockAdjustmentCounterController(IStockAdjustmentCounterService istockadjustmentcounterservice)
        {
            _stockAdjustmentCounterService = istockadjustmentcounterservice;
        }

        /// <summary>Adds a new stockadjustmentcounter</summary>
        /// <param name="model">The stockadjustmentcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] StockAdjustmentCounter model)
        {
            model.TenantId = TenantId;
            var id = _stockAdjustmentCounterService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of stockadjustmentcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stockadjustmentcounters</returns>
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

            var result = _stockAdjustmentCounterService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <returns>The stockadjustmentcounter data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _stockAdjustmentCounterService.GetById(id);
            return Ok(result);
        }

        /// <summary>Deletes a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
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
            var status = _stockAdjustmentCounterService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <param name="updatedEntity">The stockadjustmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] StockAdjustmentCounter updatedEntity)
        {
            if (id != updatedEntity.TenantId)
            {
                return BadRequest("Mismatched TenantId");
            }

            updatedEntity.TenantId = TenantId;
            var status = _stockAdjustmentCounterService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <param name="updatedEntity">The stockadjustmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<StockAdjustmentCounter> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = _stockAdjustmentCounterService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}