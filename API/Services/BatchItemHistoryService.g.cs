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
    /// The batchitemhistoryService responsible for managing batchitemhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting batchitemhistory information.
    /// </remarks>
    public interface IBatchItemHistoryService
    {
        /// <summary>Retrieves a specific batchitemhistory by its primary key</summary>
        /// <param name="id">The primary key of the batchitemhistory</param>
        /// <returns>The batchitemhistory data</returns>
        BatchItemHistory GetById(Guid id);

        /// <summary>Retrieves a list of batchitemhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of batchitemhistorys</returns>
        List<BatchItemHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new batchitemhistory</summary>
        /// <param name="model">The batchitemhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(BatchItemHistory model);

        /// <summary>Updates a specific batchitemhistory by its primary key</summary>
        /// <param name="id">The primary key of the batchitemhistory</param>
        /// <param name="updatedEntity">The batchitemhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, BatchItemHistory updatedEntity);

        /// <summary>Updates a specific batchitemhistory by its primary key</summary>
        /// <param name="id">The primary key of the batchitemhistory</param>
        /// <param name="updatedEntity">The batchitemhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<BatchItemHistory> updatedEntity);

        /// <summary>Deletes a specific batchitemhistory by its primary key</summary>
        /// <param name="id">The primary key of the batchitemhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The batchitemhistoryService responsible for managing batchitemhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting batchitemhistory information.
    /// </remarks>
    public class BatchItemHistoryService : IBatchItemHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the BatchItemHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public BatchItemHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific batchitemhistory by its primary key</summary>
        /// <param name="id">The primary key of the batchitemhistory</param>
        /// <returns>The batchitemhistory data</returns>
        public BatchItemHistory GetById(Guid id)
        {
            var entityData = _dbContext.BatchItemHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of batchitemhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of batchitemhistorys</returns>/// <exception cref="Exception"></exception>
        public List<BatchItemHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetBatchItemHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new batchitemhistory</summary>
        /// <param name="model">The batchitemhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(BatchItemHistory model)
        {
            model.Id = CreateBatchItemHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific batchitemhistory by its primary key</summary>
        /// <param name="id">The primary key of the batchitemhistory</param>
        /// <param name="updatedEntity">The batchitemhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, BatchItemHistory updatedEntity)
        {
            UpdateBatchItemHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific batchitemhistory by its primary key</summary>
        /// <param name="id">The primary key of the batchitemhistory</param>
        /// <param name="updatedEntity">The batchitemhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<BatchItemHistory> updatedEntity)
        {
            PatchBatchItemHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific batchitemhistory by its primary key</summary>
        /// <param name="id">The primary key of the batchitemhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteBatchItemHistory(id);
            return true;
        }
        #region
        private List<BatchItemHistory> GetBatchItemHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BatchItemHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BatchItemHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BatchItemHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BatchItemHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateBatchItemHistory(BatchItemHistory model)
        {
            _dbContext.BatchItemHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateBatchItemHistory(Guid id, BatchItemHistory updatedEntity)
        {
            _dbContext.BatchItemHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteBatchItemHistory(Guid id)
        {
            var entityData = _dbContext.BatchItemHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BatchItemHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchBatchItemHistory(Guid id, JsonPatchDocument<BatchItemHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BatchItemHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BatchItemHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}