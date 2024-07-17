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
    /// The visitinvestigationrecurrenceService responsible for managing visitinvestigationrecurrence related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitinvestigationrecurrence information.
    /// </remarks>
    public interface IVisitInvestigationRecurrenceService
    {
        /// <summary>Retrieves a specific visitinvestigationrecurrence by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationrecurrence</param>
        /// <returns>The visitinvestigationrecurrence data</returns>
        VisitInvestigationRecurrence GetById(Guid id);

        /// <summary>Retrieves a list of visitinvestigationrecurrences based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitinvestigationrecurrences</returns>
        List<VisitInvestigationRecurrence> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitinvestigationrecurrence</summary>
        /// <param name="model">The visitinvestigationrecurrence data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitInvestigationRecurrence model);

        /// <summary>Updates a specific visitinvestigationrecurrence by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationrecurrence</param>
        /// <param name="updatedEntity">The visitinvestigationrecurrence data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitInvestigationRecurrence updatedEntity);

        /// <summary>Updates a specific visitinvestigationrecurrence by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationrecurrence</param>
        /// <param name="updatedEntity">The visitinvestigationrecurrence data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitInvestigationRecurrence> updatedEntity);

        /// <summary>Deletes a specific visitinvestigationrecurrence by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationrecurrence</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitinvestigationrecurrenceService responsible for managing visitinvestigationrecurrence related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitinvestigationrecurrence information.
    /// </remarks>
    public class VisitInvestigationRecurrenceService : IVisitInvestigationRecurrenceService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitInvestigationRecurrence class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitInvestigationRecurrenceService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitinvestigationrecurrence by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationrecurrence</param>
        /// <returns>The visitinvestigationrecurrence data</returns>
        public VisitInvestigationRecurrence GetById(Guid id)
        {
            var entityData = _dbContext.VisitInvestigationRecurrence.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitinvestigationrecurrences based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitinvestigationrecurrences</returns>/// <exception cref="Exception"></exception>
        public List<VisitInvestigationRecurrence> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitInvestigationRecurrence(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitinvestigationrecurrence</summary>
        /// <param name="model">The visitinvestigationrecurrence data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitInvestigationRecurrence model)
        {
            model.Id = CreateVisitInvestigationRecurrence(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitinvestigationrecurrence by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationrecurrence</param>
        /// <param name="updatedEntity">The visitinvestigationrecurrence data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitInvestigationRecurrence updatedEntity)
        {
            UpdateVisitInvestigationRecurrence(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitinvestigationrecurrence by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationrecurrence</param>
        /// <param name="updatedEntity">The visitinvestigationrecurrence data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitInvestigationRecurrence> updatedEntity)
        {
            PatchVisitInvestigationRecurrence(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitinvestigationrecurrence by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationrecurrence</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitInvestigationRecurrence(id);
            return true;
        }
        #region
        private List<VisitInvestigationRecurrence> GetVisitInvestigationRecurrence(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitInvestigationRecurrence.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitInvestigationRecurrence>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitInvestigationRecurrence), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitInvestigationRecurrence, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitInvestigationRecurrence(VisitInvestigationRecurrence model)
        {
            _dbContext.VisitInvestigationRecurrence.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitInvestigationRecurrence(Guid id, VisitInvestigationRecurrence updatedEntity)
        {
            _dbContext.VisitInvestigationRecurrence.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitInvestigationRecurrence(Guid id)
        {
            var entityData = _dbContext.VisitInvestigationRecurrence.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitInvestigationRecurrence.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitInvestigationRecurrence(Guid id, JsonPatchDocument<VisitInvestigationRecurrence> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitInvestigationRecurrence.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitInvestigationRecurrence.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}