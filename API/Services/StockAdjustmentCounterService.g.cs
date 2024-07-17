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
    /// The stockadjustmentcounterService responsible for managing stockadjustmentcounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting stockadjustmentcounter information.
    /// </remarks>
    public interface IStockAdjustmentCounterService
    {
        /// <summary>Retrieves a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <returns>The stockadjustmentcounter data</returns>
        StockAdjustmentCounter GetById(Guid id);

        /// <summary>Retrieves a list of stockadjustmentcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stockadjustmentcounters</returns>
        List<StockAdjustmentCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new stockadjustmentcounter</summary>
        /// <param name="model">The stockadjustmentcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(StockAdjustmentCounter model);

        /// <summary>Updates a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <param name="updatedEntity">The stockadjustmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, StockAdjustmentCounter updatedEntity);

        /// <summary>Updates a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <param name="updatedEntity">The stockadjustmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<StockAdjustmentCounter> updatedEntity);

        /// <summary>Deletes a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The stockadjustmentcounterService responsible for managing stockadjustmentcounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting stockadjustmentcounter information.
    /// </remarks>
    public class StockAdjustmentCounterService : IStockAdjustmentCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the StockAdjustmentCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public StockAdjustmentCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <returns>The stockadjustmentcounter data</returns>
        public StockAdjustmentCounter GetById(Guid id)
        {
            var entityData = _dbContext.StockAdjustmentCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of stockadjustmentcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stockadjustmentcounters</returns>/// <exception cref="Exception"></exception>
        public List<StockAdjustmentCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetStockAdjustmentCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new stockadjustmentcounter</summary>
        /// <param name="model">The stockadjustmentcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(StockAdjustmentCounter model)
        {
            model.TenantId = CreateStockAdjustmentCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <param name="updatedEntity">The stockadjustmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, StockAdjustmentCounter updatedEntity)
        {
            UpdateStockAdjustmentCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <param name="updatedEntity">The stockadjustmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<StockAdjustmentCounter> updatedEntity)
        {
            PatchStockAdjustmentCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific stockadjustmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the stockadjustmentcounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteStockAdjustmentCounter(id);
            return true;
        }
        #region
        private List<StockAdjustmentCounter> GetStockAdjustmentCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.StockAdjustmentCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<StockAdjustmentCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(StockAdjustmentCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<StockAdjustmentCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateStockAdjustmentCounter(StockAdjustmentCounter model)
        {
            _dbContext.StockAdjustmentCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateStockAdjustmentCounter(Guid id, StockAdjustmentCounter updatedEntity)
        {
            _dbContext.StockAdjustmentCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteStockAdjustmentCounter(Guid id)
        {
            var entityData = _dbContext.StockAdjustmentCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.StockAdjustmentCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchStockAdjustmentCounter(Guid id, JsonPatchDocument<StockAdjustmentCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.StockAdjustmentCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.StockAdjustmentCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}