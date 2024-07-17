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
    /// The stockadjustmentworkflowactivityhistoryService responsible for managing stockadjustmentworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting stockadjustmentworkflowactivityhistory information.
    /// </remarks>
    public interface IStockAdjustmentWorkflowActivityHistoryService
    {
        /// <summary>Retrieves a specific stockadjustmentworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentworkflowactivityhistory</param>
        /// <returns>The stockadjustmentworkflowactivityhistory data</returns>
        StockAdjustmentWorkflowActivityHistory GetById(Guid id);

        /// <summary>Retrieves a list of stockadjustmentworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stockadjustmentworkflowactivityhistorys</returns>
        List<StockAdjustmentWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new stockadjustmentworkflowactivityhistory</summary>
        /// <param name="model">The stockadjustmentworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(StockAdjustmentWorkflowActivityHistory model);

        /// <summary>Updates a specific stockadjustmentworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stockadjustmentworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, StockAdjustmentWorkflowActivityHistory updatedEntity);

        /// <summary>Updates a specific stockadjustmentworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stockadjustmentworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<StockAdjustmentWorkflowActivityHistory> updatedEntity);

        /// <summary>Deletes a specific stockadjustmentworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The stockadjustmentworkflowactivityhistoryService responsible for managing stockadjustmentworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting stockadjustmentworkflowactivityhistory information.
    /// </remarks>
    public class StockAdjustmentWorkflowActivityHistoryService : IStockAdjustmentWorkflowActivityHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the StockAdjustmentWorkflowActivityHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public StockAdjustmentWorkflowActivityHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific stockadjustmentworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentworkflowactivityhistory</param>
        /// <returns>The stockadjustmentworkflowactivityhistory data</returns>
        public StockAdjustmentWorkflowActivityHistory GetById(Guid id)
        {
            var entityData = _dbContext.StockAdjustmentWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of stockadjustmentworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stockadjustmentworkflowactivityhistorys</returns>/// <exception cref="Exception"></exception>
        public List<StockAdjustmentWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetStockAdjustmentWorkflowActivityHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new stockadjustmentworkflowactivityhistory</summary>
        /// <param name="model">The stockadjustmentworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(StockAdjustmentWorkflowActivityHistory model)
        {
            model.Id = CreateStockAdjustmentWorkflowActivityHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific stockadjustmentworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stockadjustmentworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, StockAdjustmentWorkflowActivityHistory updatedEntity)
        {
            UpdateStockAdjustmentWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific stockadjustmentworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stockadjustmentworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<StockAdjustmentWorkflowActivityHistory> updatedEntity)
        {
            PatchStockAdjustmentWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific stockadjustmentworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteStockAdjustmentWorkflowActivityHistory(id);
            return true;
        }
        #region
        private List<StockAdjustmentWorkflowActivityHistory> GetStockAdjustmentWorkflowActivityHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.StockAdjustmentWorkflowActivityHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<StockAdjustmentWorkflowActivityHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(StockAdjustmentWorkflowActivityHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<StockAdjustmentWorkflowActivityHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateStockAdjustmentWorkflowActivityHistory(StockAdjustmentWorkflowActivityHistory model)
        {
            _dbContext.StockAdjustmentWorkflowActivityHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateStockAdjustmentWorkflowActivityHistory(Guid id, StockAdjustmentWorkflowActivityHistory updatedEntity)
        {
            _dbContext.StockAdjustmentWorkflowActivityHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteStockAdjustmentWorkflowActivityHistory(Guid id)
        {
            var entityData = _dbContext.StockAdjustmentWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.StockAdjustmentWorkflowActivityHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchStockAdjustmentWorkflowActivityHistory(Guid id, JsonPatchDocument<StockAdjustmentWorkflowActivityHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.StockAdjustmentWorkflowActivityHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.StockAdjustmentWorkflowActivityHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}