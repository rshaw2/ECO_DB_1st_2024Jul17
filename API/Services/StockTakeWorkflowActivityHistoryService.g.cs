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
    /// The stocktakeworkflowactivityhistoryService responsible for managing stocktakeworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting stocktakeworkflowactivityhistory information.
    /// </remarks>
    public interface IStockTakeWorkflowActivityHistoryService
    {
        /// <summary>Retrieves a specific stocktakeworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktakeworkflowactivityhistory</param>
        /// <returns>The stocktakeworkflowactivityhistory data</returns>
        StockTakeWorkflowActivityHistory GetById(Guid id);

        /// <summary>Retrieves a list of stocktakeworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stocktakeworkflowactivityhistorys</returns>
        List<StockTakeWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new stocktakeworkflowactivityhistory</summary>
        /// <param name="model">The stocktakeworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(StockTakeWorkflowActivityHistory model);

        /// <summary>Updates a specific stocktakeworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktakeworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stocktakeworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, StockTakeWorkflowActivityHistory updatedEntity);

        /// <summary>Updates a specific stocktakeworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktakeworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stocktakeworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<StockTakeWorkflowActivityHistory> updatedEntity);

        /// <summary>Deletes a specific stocktakeworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktakeworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The stocktakeworkflowactivityhistoryService responsible for managing stocktakeworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting stocktakeworkflowactivityhistory information.
    /// </remarks>
    public class StockTakeWorkflowActivityHistoryService : IStockTakeWorkflowActivityHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the StockTakeWorkflowActivityHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public StockTakeWorkflowActivityHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific stocktakeworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktakeworkflowactivityhistory</param>
        /// <returns>The stocktakeworkflowactivityhistory data</returns>
        public StockTakeWorkflowActivityHistory GetById(Guid id)
        {
            var entityData = _dbContext.StockTakeWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of stocktakeworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stocktakeworkflowactivityhistorys</returns>/// <exception cref="Exception"></exception>
        public List<StockTakeWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetStockTakeWorkflowActivityHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new stocktakeworkflowactivityhistory</summary>
        /// <param name="model">The stocktakeworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(StockTakeWorkflowActivityHistory model)
        {
            model.Id = CreateStockTakeWorkflowActivityHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific stocktakeworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktakeworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stocktakeworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, StockTakeWorkflowActivityHistory updatedEntity)
        {
            UpdateStockTakeWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific stocktakeworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktakeworkflowactivityhistory</param>
        /// <param name="updatedEntity">The stocktakeworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<StockTakeWorkflowActivityHistory> updatedEntity)
        {
            PatchStockTakeWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific stocktakeworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the stocktakeworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteStockTakeWorkflowActivityHistory(id);
            return true;
        }
        #region
        private List<StockTakeWorkflowActivityHistory> GetStockTakeWorkflowActivityHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.StockTakeWorkflowActivityHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<StockTakeWorkflowActivityHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(StockTakeWorkflowActivityHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<StockTakeWorkflowActivityHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateStockTakeWorkflowActivityHistory(StockTakeWorkflowActivityHistory model)
        {
            _dbContext.StockTakeWorkflowActivityHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateStockTakeWorkflowActivityHistory(Guid id, StockTakeWorkflowActivityHistory updatedEntity)
        {
            _dbContext.StockTakeWorkflowActivityHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteStockTakeWorkflowActivityHistory(Guid id)
        {
            var entityData = _dbContext.StockTakeWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.StockTakeWorkflowActivityHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchStockTakeWorkflowActivityHistory(Guid id, JsonPatchDocument<StockTakeWorkflowActivityHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.StockTakeWorkflowActivityHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.StockTakeWorkflowActivityHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}