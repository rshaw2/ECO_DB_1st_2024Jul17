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
    /// The batchtypecontextService responsible for managing batchtypecontext related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting batchtypecontext information.
    /// </remarks>
    public interface IBatchTypeContextService
    {
        /// <summary>Retrieves a specific batchtypecontext by its primary key</summary>
        /// <param name="id">The primary key of the batchtypecontext</param>
        /// <returns>The batchtypecontext data</returns>
        BatchTypeContext GetById(Guid id);

        /// <summary>Retrieves a list of batchtypecontexts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of batchtypecontexts</returns>
        List<BatchTypeContext> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new batchtypecontext</summary>
        /// <param name="model">The batchtypecontext data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(BatchTypeContext model);

        /// <summary>Updates a specific batchtypecontext by its primary key</summary>
        /// <param name="id">The primary key of the batchtypecontext</param>
        /// <param name="updatedEntity">The batchtypecontext data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, BatchTypeContext updatedEntity);

        /// <summary>Updates a specific batchtypecontext by its primary key</summary>
        /// <param name="id">The primary key of the batchtypecontext</param>
        /// <param name="updatedEntity">The batchtypecontext data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<BatchTypeContext> updatedEntity);

        /// <summary>Deletes a specific batchtypecontext by its primary key</summary>
        /// <param name="id">The primary key of the batchtypecontext</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The batchtypecontextService responsible for managing batchtypecontext related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting batchtypecontext information.
    /// </remarks>
    public class BatchTypeContextService : IBatchTypeContextService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the BatchTypeContext class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public BatchTypeContextService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific batchtypecontext by its primary key</summary>
        /// <param name="id">The primary key of the batchtypecontext</param>
        /// <returns>The batchtypecontext data</returns>
        public BatchTypeContext GetById(Guid id)
        {
            var entityData = _dbContext.BatchTypeContext.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of batchtypecontexts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of batchtypecontexts</returns>/// <exception cref="Exception"></exception>
        public List<BatchTypeContext> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetBatchTypeContext(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new batchtypecontext</summary>
        /// <param name="model">The batchtypecontext data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(BatchTypeContext model)
        {
            model.Id = CreateBatchTypeContext(model);
            return model.Id;
        }

        /// <summary>Updates a specific batchtypecontext by its primary key</summary>
        /// <param name="id">The primary key of the batchtypecontext</param>
        /// <param name="updatedEntity">The batchtypecontext data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, BatchTypeContext updatedEntity)
        {
            UpdateBatchTypeContext(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific batchtypecontext by its primary key</summary>
        /// <param name="id">The primary key of the batchtypecontext</param>
        /// <param name="updatedEntity">The batchtypecontext data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<BatchTypeContext> updatedEntity)
        {
            PatchBatchTypeContext(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific batchtypecontext by its primary key</summary>
        /// <param name="id">The primary key of the batchtypecontext</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteBatchTypeContext(id);
            return true;
        }
        #region
        private List<BatchTypeContext> GetBatchTypeContext(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BatchTypeContext.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BatchTypeContext>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BatchTypeContext), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BatchTypeContext, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateBatchTypeContext(BatchTypeContext model)
        {
            _dbContext.BatchTypeContext.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateBatchTypeContext(Guid id, BatchTypeContext updatedEntity)
        {
            _dbContext.BatchTypeContext.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteBatchTypeContext(Guid id)
        {
            var entityData = _dbContext.BatchTypeContext.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BatchTypeContext.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchBatchTypeContext(Guid id, JsonPatchDocument<BatchTypeContext> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BatchTypeContext.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BatchTypeContext.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}