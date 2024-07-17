using ECODB1st2024Jul17.Models;
using ECODB1st2024Jul17.Data;
using ECODB1st2024Jul17.Filter;
using ECODB1st2024Jul17.Entities;
using ECODB1st2024Jul17.Logger;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq.Expressions;

namespace ECODB1st2024Jul17.Services
{
    /// <summary>
    /// The visitinvestigationresultService responsible for managing visitinvestigationresult related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitinvestigationresult information.
    /// </remarks>
    public interface IVisitInvestigationResultService
    {
        /// <summary>Retrieves a specific visitinvestigationresult by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresult</param>
        /// <returns>The visitinvestigationresult data</returns>
        VisitInvestigationResult GetById(Guid id);

        /// <summary>Retrieves a list of visitinvestigationresults based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitinvestigationresults</returns>
        List<VisitInvestigationResult> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitinvestigationresult</summary>
        /// <param name="model">The visitinvestigationresult data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitInvestigationResult model);

        /// <summary>Updates a specific visitinvestigationresult by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresult</param>
        /// <param name="updatedEntity">The visitinvestigationresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitInvestigationResult updatedEntity);

        /// <summary>Updates a specific visitinvestigationresult by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresult</param>
        /// <param name="updatedEntity">The visitinvestigationresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitInvestigationResult> updatedEntity);

        /// <summary>Deletes a specific visitinvestigationresult by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresult</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitinvestigationresultService responsible for managing visitinvestigationresult related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitinvestigationresult information.
    /// </remarks>
    public class VisitInvestigationResultService : IVisitInvestigationResultService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitInvestigationResult class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitInvestigationResultService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitinvestigationresult by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresult</param>
        /// <returns>The visitinvestigationresult data</returns>
        public VisitInvestigationResult GetById(Guid id)
        {
            var entityData = _dbContext.VisitInvestigationResult.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitinvestigationresults based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitinvestigationresults</returns>/// <exception cref="Exception"></exception>
        public List<VisitInvestigationResult> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitInvestigationResult(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitinvestigationresult</summary>
        /// <param name="model">The visitinvestigationresult data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitInvestigationResult model)
        {
            model.Id = CreateVisitInvestigationResult(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitinvestigationresult by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresult</param>
        /// <param name="updatedEntity">The visitinvestigationresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitInvestigationResult updatedEntity)
        {
            UpdateVisitInvestigationResult(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitinvestigationresult by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresult</param>
        /// <param name="updatedEntity">The visitinvestigationresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitInvestigationResult> updatedEntity)
        {
            PatchVisitInvestigationResult(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitinvestigationresult by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresult</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitInvestigationResult(id);
            return true;
        }
        #region
        private List<VisitInvestigationResult> GetVisitInvestigationResult(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitInvestigationResult.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitInvestigationResult>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitInvestigationResult), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitInvestigationResult, object>>(Expression.Convert(property, typeof(object)), parameter);
                if (sortOrder.Equals("asc", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.OrderBy(lambda);
                }
                else if (sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.OrderByDescending(lambda);
                }
                else
                {
                    throw new ApplicationException("Invalid sort order. Use 'asc' or 'desc'");
                }
            }

            var paginatedResult = result.Skip(skip).Take(pageSize).ToList();
            return paginatedResult;
        }

        private Guid CreateVisitInvestigationResult(VisitInvestigationResult model)
        {
            _dbContext.VisitInvestigationResult.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitInvestigationResult(Guid id, VisitInvestigationResult updatedEntity)
        {
            _dbContext.VisitInvestigationResult.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitInvestigationResult(Guid id)
        {
            var entityData = _dbContext.VisitInvestigationResult.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitInvestigationResult.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitInvestigationResult(Guid id, JsonPatchDocument<VisitInvestigationResult> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitInvestigationResult.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitInvestigationResult.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}