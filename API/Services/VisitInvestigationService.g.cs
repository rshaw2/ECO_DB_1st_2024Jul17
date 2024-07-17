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
    /// The visitinvestigationService responsible for managing visitinvestigation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitinvestigation information.
    /// </remarks>
    public interface IVisitInvestigationService
    {
        /// <summary>Retrieves a specific visitinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigation</param>
        /// <returns>The visitinvestigation data</returns>
        VisitInvestigation GetById(Guid id);

        /// <summary>Retrieves a list of visitinvestigations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitinvestigations</returns>
        List<VisitInvestigation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitinvestigation</summary>
        /// <param name="model">The visitinvestigation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitInvestigation model);

        /// <summary>Updates a specific visitinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigation</param>
        /// <param name="updatedEntity">The visitinvestigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitInvestigation updatedEntity);

        /// <summary>Updates a specific visitinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigation</param>
        /// <param name="updatedEntity">The visitinvestigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitInvestigation> updatedEntity);

        /// <summary>Deletes a specific visitinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitinvestigationService responsible for managing visitinvestigation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitinvestigation information.
    /// </remarks>
    public class VisitInvestigationService : IVisitInvestigationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitInvestigation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitInvestigationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigation</param>
        /// <returns>The visitinvestigation data</returns>
        public VisitInvestigation GetById(Guid id)
        {
            var entityData = _dbContext.VisitInvestigation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitinvestigations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitinvestigations</returns>/// <exception cref="Exception"></exception>
        public List<VisitInvestigation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitInvestigation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitinvestigation</summary>
        /// <param name="model">The visitinvestigation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitInvestigation model)
        {
            model.Id = CreateVisitInvestigation(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigation</param>
        /// <param name="updatedEntity">The visitinvestigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitInvestigation updatedEntity)
        {
            UpdateVisitInvestigation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigation</param>
        /// <param name="updatedEntity">The visitinvestigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitInvestigation> updatedEntity)
        {
            PatchVisitInvestigation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitInvestigation(id);
            return true;
        }
        #region
        private List<VisitInvestigation> GetVisitInvestigation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitInvestigation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitInvestigation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitInvestigation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitInvestigation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitInvestigation(VisitInvestigation model)
        {
            _dbContext.VisitInvestigation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitInvestigation(Guid id, VisitInvestigation updatedEntity)
        {
            _dbContext.VisitInvestigation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitInvestigation(Guid id)
        {
            var entityData = _dbContext.VisitInvestigation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitInvestigation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitInvestigation(Guid id, JsonPatchDocument<VisitInvestigation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitInvestigation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitInvestigation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}