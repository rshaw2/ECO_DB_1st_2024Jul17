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
    /// The stocktransferworkflowactivityhistoryService responsible for managing stocktransferworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting stocktransferworkflowactivityhistory information.
    /// </remarks>
    public interface IStockTransferWorkflowActivityHistoryService
    {
        /// <summary>Retrieves a specific stocktransferworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktransferworkflowactivityhistory</param>
        /// <returns>The stocktransferworkflowactivityhistory data</returns>
        StockTransferWorkflowActivityHistory GetById(Guid id);

        /// <summary>Retrieves a list of stocktransferworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stocktransferworkflowactivityhistorys</returns>
        List<StockTransferWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new stocktransferworkflowactivityhistory</summary>
        /// <param name="model">The stocktransferworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(StockTransferWorkflowActivityHistory model);

        /// <summary>Updates a specific stocktransferworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktransferworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stocktransferworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, StockTransferWorkflowActivityHistory updatedEntity);

        /// <summary>Updates a specific stocktransferworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktransferworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stocktransferworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<StockTransferWorkflowActivityHistory> updatedEntity);

        /// <summary>Deletes a specific stocktransferworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktransferworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The stocktransferworkflowactivityhistoryService responsible for managing stocktransferworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting stocktransferworkflowactivityhistory information.
    /// </remarks>
    public class StockTransferWorkflowActivityHistoryService : IStockTransferWorkflowActivityHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the StockTransferWorkflowActivityHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public StockTransferWorkflowActivityHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific stocktransferworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktransferworkflowactivityhistory</param>
        /// <returns>The stocktransferworkflowactivityhistory data</returns>
        public StockTransferWorkflowActivityHistory GetById(Guid id)
        {
            var entityData = _dbContext.StockTransferWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of stocktransferworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stocktransferworkflowactivityhistorys</returns>/// <exception cref="Exception"></exception>
        public List<StockTransferWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetStockTransferWorkflowActivityHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new stocktransferworkflowactivityhistory</summary>
        /// <param name="model">The stocktransferworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(StockTransferWorkflowActivityHistory model)
        {
            model.Id = CreateStockTransferWorkflowActivityHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific stocktransferworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktransferworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stocktransferworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, StockTransferWorkflowActivityHistory updatedEntity)
        {
            UpdateStockTransferWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific stocktransferworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktransferworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stocktransferworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<StockTransferWorkflowActivityHistory> updatedEntity)
        {
            PatchStockTransferWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific stocktransferworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktransferworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteStockTransferWorkflowActivityHistory(id);
            return true;
        }
        #region
        private List<StockTransferWorkflowActivityHistory> GetStockTransferWorkflowActivityHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.StockTransferWorkflowActivityHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<StockTransferWorkflowActivityHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(StockTransferWorkflowActivityHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<StockTransferWorkflowActivityHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateStockTransferWorkflowActivityHistory(StockTransferWorkflowActivityHistory model)
        {
            _dbContext.StockTransferWorkflowActivityHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateStockTransferWorkflowActivityHistory(Guid id, StockTransferWorkflowActivityHistory updatedEntity)
        {
            _dbContext.StockTransferWorkflowActivityHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteStockTransferWorkflowActivityHistory(Guid id)
        {
            var entityData = _dbContext.StockTransferWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.StockTransferWorkflowActivityHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchStockTransferWorkflowActivityHistory(Guid id, JsonPatchDocument<StockTransferWorkflowActivityHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.StockTransferWorkflowActivityHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.StockTransferWorkflowActivityHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}