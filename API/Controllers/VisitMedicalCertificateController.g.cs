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
    /// Controller responsible for managing visitmedicalcertificate related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting visitmedicalcertificate information.
    /// </remarks>
    [Route("api/dynamic/visitmedicalcertificate")]
    [Authorize]
    public class VisitMedicalCertificateController : BaseApiController
    {
        private readonly IVisitMedicalCertificateService _visitMedicalCertificateService;

        /// <summary>
        /// Initializes a new instance of the VisitMedicalCertificateController class with the specified context.
        /// </summary>
        /// <param name="ivisitmedicalcertificateservice">The ivisitmedicalcertificateservice to be used by the controller.</param>
        public VisitMedicalCertificateController(IVisitMedicalCertificateService ivisitmedicalcertificateservice)
        {
            _visitMedicalCertificateService = ivisitmedicalcertificateservice;
        }

        /// <summary>Adds a new visitmedicalcertificate</summary>
        /// <param name="model">The visitmedicalcertificate data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] VisitMedicalCertificate model)
        {
            model.TenantId = TenantId;
            model.CreatedBy = UserId;
            model.CreatedOn = DateTime.UtcNow;
            var id = _visitMedicalCertificateService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of visitmedicalcertificates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitmedicalcertificates</returns>
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

            var result = _visitMedicalCertificateService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific visitmedicalcertificate by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicalcertificate</param>
        /// <returns>The visitmedicalcertificate data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _visitMedicalCertificateService.GetById(id);
            return Ok(result);
        }

        /// <summary>Deletes a specific visitmedicalcertificate by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicalcertificate</param>
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
            var status = _visitMedicalCertificateService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific visitmedicalcertificate by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicalcertificate</param>
        /// <param name="updatedEntity">The visitmedicalcertificate data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] VisitMedicalCertificate updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            updatedEntity.TenantId = TenantId;
            updatedEntity.UpdatedBy = UserId;
            updatedEntity.UpdatedOn = DateTime.UtcNow;
            var status = _visitMedicalCertificateService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific visitmedicalcertificate by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicalcertificate</param>
        /// <param name="updatedEntity">The visitmedicalcertificate data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<VisitMedicalCertificate> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = _visitMedicalCertificateService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}