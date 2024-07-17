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
    /// The batchintervalService responsible for managing batchinterval related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting batchinterval information.
    /// </remarks>
    public interface IBatchIntervalService
    {
        /// <summary>Retrieves a specific batchinterval by its primary key</summary>
        /// <param name="id">The primary key of the batchinterval</param>
        /// <returns>The batchinterval data</returns>
        BatchInterval GetById(Guid id);

        /// <summary>Retrieves a list of batchintervals based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of batchintervals</returns>
        List<BatchInterval> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new batchinterval</summary>
        /// <param name="model">The batchinterval data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(BatchInterval model);

        /// <summary>Updates a specific batchinterval by its primary key</summary>
        /// <param name="id">The primary key of the batchinterval</param>
        /// <param name="updatedEntity">The batchinterval data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, BatchInterval updatedEntity);

        /// <summary>Updates a specific batchinterval by its primary key</summary>
        /// <param name="id">The primary key of the batchinterval</param>
        /// <param name="updatedEntity">The batchinterval data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<BatchInterval> updatedEntity);

        /// <summary>Deletes a specific batchinterval by its primary key</summary>
        /// <param name="id">The primary key of the batchinterval</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The batchintervalService responsible for managing batchinterval related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting batchinterval information.
    /// </remarks>
    public class BatchIntervalService : IBatchIntervalService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the BatchInterval class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public BatchIntervalService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific batchinterval by its primary key</summary>
        /// <param name="id">The primary key of the batchinterval</param>
        /// <returns>The batchinterval data</returns>
        public BatchInterval GetById(Guid id)
        {
            var entityData = _dbContext.BatchInterval.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of batchintervals based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of batchintervals</returns>/// <exception cref="Exception"></exception>
        public List<BatchInterval> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetBatchInterval(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new batchinterval</summary>
        /// <param name="model">The batchinterval data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(BatchInterval model)
        {
            model.Id = CreateBatchInterval(model);
            return model.Id;
        }

        /// <summary>Updates a specific batchinterval by its primary key</summary>
        /// <param name="id">The primary key of the batchinterval</param>
        /// <param name="updatedEntity">The batchinterval data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, BatchInterval updatedEntity)
        {
            UpdateBatchInterval(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific batchinterval by its primary key</summary>
        /// <param name="id">The primary key of the batchinterval</param>
        /// <param name="updatedEntity">The batchinterval data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<BatchInterval> updatedEntity)
        {
            PatchBatchInterval(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific batchinterval by its primary key</summary>
        /// <param name="id">The primary key of the batchinterval</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteBatchInterval(id);
            return true;
        }
        #region
        private List<BatchInterval> GetBatchInterval(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BatchInterval.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BatchInterval>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BatchInterval), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BatchInterval, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateBatchInterval(BatchInterval model)
        {
            _dbContext.BatchInterval.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateBatchInterval(Guid id, BatchInterval updatedEntity)
        {
            _dbContext.BatchInterval.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteBatchInterval(Guid id)
        {
            var entityData = _dbContext.BatchInterval.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BatchInterval.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchBatchInterval(Guid id, JsonPatchDocument<BatchInterval> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BatchInterval.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BatchInterval.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}