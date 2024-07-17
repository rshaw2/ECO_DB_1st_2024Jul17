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
    /// The visitcounterService responsible for managing visitcounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitcounter information.
    /// </remarks>
    public interface IVisitCounterService
    {
        /// <summary>Retrieves a specific visitcounter by its primary key</summary>
        /// <param name="id">The primary key of the visitcounter</param>
        /// <returns>The visitcounter data</returns>
        VisitCounter GetById(Guid id);

        /// <summary>Retrieves a list of visitcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitcounters</returns>
        List<VisitCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitcounter</summary>
        /// <param name="model">The visitcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(VisitCounter model);

        /// <summary>Updates a specific visitcounter by its primary key</summary>
        /// <param name="id">The primary key of the visitcounter</param>
        /// <param name="updatedEntity">The visitcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitCounter updatedEntity);

        /// <summary>Updates a specific visitcounter by its primary key</summary>
        /// <param name="id">The primary key of the visitcounter</param>
        /// <param name="updatedEntity">The visitcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitCounter> updatedEntity);

        /// <summary>Deletes a specific visitcounter by its primary key</summary>
        /// <param name="id">The primary key of the visitcounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitcounterService responsible for managing visitcounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitcounter information.
    /// </remarks>
    public class VisitCounterService : IVisitCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitcounter by its primary key</summary>
        /// <param name="id">The primary key of the visitcounter</param>
        /// <returns>The visitcounter data</returns>
        public VisitCounter GetById(Guid id)
        {
            var entityData = _dbContext.VisitCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitcounters</returns>/// <exception cref="Exception"></exception>
        public List<VisitCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitcounter</summary>
        /// <param name="model">The visitcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(VisitCounter model)
        {
            model.TenantId = CreateVisitCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific visitcounter by its primary key</summary>
        /// <param name="id">The primary key of the visitcounter</param>
        /// <param name="updatedEntity">The visitcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitCounter updatedEntity)
        {
            UpdateVisitCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitcounter by its primary key</summary>
        /// <param name="id">The primary key of the visitcounter</param>
        /// <param name="updatedEntity">The visitcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitCounter> updatedEntity)
        {
            PatchVisitCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitcounter by its primary key</summary>
        /// <param name="id">The primary key of the visitcounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitCounter(id);
            return true;
        }
        #region
        private List<VisitCounter> GetVisitCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateVisitCounter(VisitCounter model)
        {
            _dbContext.VisitCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateVisitCounter(Guid id, VisitCounter updatedEntity)
        {
            _dbContext.VisitCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitCounter(Guid id)
        {
            var entityData = _dbContext.VisitCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitCounter(Guid id, JsonPatchDocument<VisitCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}