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
    /// The batchcontextService responsible for managing batchcontext related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting batchcontext information.
    /// </remarks>
    public interface IBatchContextService
    {
        /// <summary>Retrieves a specific batchcontext by its primary key</summary>
        /// <param name="id">The primary key of the batchcontext</param>
        /// <returns>The batchcontext data</returns>
        BatchContext GetById(Guid id);

        /// <summary>Retrieves a list of batchcontexts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of batchcontexts</returns>
        List<BatchContext> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new batchcontext</summary>
        /// <param name="model">The batchcontext data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(BatchContext model);

        /// <summary>Updates a specific batchcontext by its primary key</summary>
        /// <param name="id">The primary key of the batchcontext</param>
        /// <param name="updatedEntity">The batchcontext data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, BatchContext updatedEntity);

        /// <summary>Updates a specific batchcontext by its primary key</summary>
        /// <param name="id">The primary key of the batchcontext</param>
        /// <param name="updatedEntity">The batchcontext data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<BatchContext> updatedEntity);

        /// <summary>Deletes a specific batchcontext by its primary key</summary>
        /// <param name="id">The primary key of the batchcontext</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The batchcontextService responsible for managing batchcontext related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting batchcontext information.
    /// </remarks>
    public class BatchContextService : IBatchContextService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the BatchContext class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public BatchContextService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific batchcontext by its primary key</summary>
        /// <param name="id">The primary key of the batchcontext</param>
        /// <returns>The batchcontext data</returns>
        public BatchContext GetById(Guid id)
        {
            var entityData = _dbContext.BatchContext.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of batchcontexts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of batchcontexts</returns>/// <exception cref="Exception"></exception>
        public List<BatchContext> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetBatchContext(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new batchcontext</summary>
        /// <param name="model">The batchcontext data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(BatchContext model)
        {
            model.Id = CreateBatchContext(model);
            return model.Id;
        }

        /// <summary>Updates a specific batchcontext by its primary key</summary>
        /// <param name="id">The primary key of the batchcontext</param>
        /// <param name="updatedEntity">The batchcontext data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, BatchContext updatedEntity)
        {
            UpdateBatchContext(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific batchcontext by its primary key</summary>
        /// <param name="id">The primary key of the batchcontext</param>
        /// <param name="updatedEntity">The batchcontext data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<BatchContext> updatedEntity)
        {
            PatchBatchContext(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific batchcontext by its primary key</summary>
        /// <param name="id">The primary key of the batchcontext</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteBatchContext(id);
            return true;
        }
        #region
        private List<BatchContext> GetBatchContext(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BatchContext.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BatchContext>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BatchContext), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BatchContext, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateBatchContext(BatchContext model)
        {
            _dbContext.BatchContext.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateBatchContext(Guid id, BatchContext updatedEntity)
        {
            _dbContext.BatchContext.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteBatchContext(Guid id)
        {
            var entityData = _dbContext.BatchContext.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BatchContext.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchBatchContext(Guid id, JsonPatchDocument<BatchContext> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BatchContext.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BatchContext.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}