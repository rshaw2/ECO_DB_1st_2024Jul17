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
    /// Controller responsible for managing productcategorygenderrule related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting productcategorygenderrule information.
    /// </remarks>
    [Route("api/dynamic/productcategorygenderrule")]
    [Authorize]
    public class ProductCategoryGenderRuleController : BaseApiController
    {
        private readonly IProductCategoryGenderRuleService _productCategoryGenderRuleService;

        /// <summary>
        /// Initializes a new instance of the ProductCategoryGenderRuleController class with the specified context.
        /// </summary>
        /// <param name="iproductcategorygenderruleservice">The iproductcategorygenderruleservice to be used by the controller.</param>
        public ProductCategoryGenderRuleController(IProductCategoryGenderRuleService iproductcategorygenderruleservice)
        {
            _productCategoryGenderRuleService = iproductcategorygenderruleservice;
        }

        /// <summary>Adds a new productcategorygenderrule</summary>
        /// <param name="model">The productcategorygenderrule data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] ProductCategoryGenderRule model)
        {
            model.TenantId = TenantId;
            var id = _productCategoryGenderRuleService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of productcategorygenderrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productcategorygenderrules</returns>
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

            var result = _productCategoryGenderRuleService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <returns>The productcategorygenderrule data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _productCategoryGenderRuleService.GetById(id);
            return Ok(result);
        }

        /// <summary>Deletes a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
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
            var status = _productCategoryGenderRuleService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <param name="updatedEntity">The productcategorygenderrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] ProductCategoryGenderRule updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            updatedEntity.TenantId = TenantId;
            var status = _productCategoryGenderRuleService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <param name="updatedEntity">The productcategorygenderrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<ProductCategoryGenderRule> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = _productCategoryGenderRuleService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}