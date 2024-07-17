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
    /// The stocktakecounterService responsible for managing stocktakecounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting stocktakecounter information.
    /// </remarks>
    public interface IStockTakeCounterService
    {
        /// <summary>Retrieves a specific stocktakecounter by its primary key</summary>
        /// <param name="id">The primary key of the stocktakecounter</param>
        /// <returns>The stocktakecounter data</returns>
        StockTakeCounter GetById(Guid id);

        /// <summary>Retrieves a list of stocktakecounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stocktakecounters</returns>
        List<StockTakeCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new stocktakecounter</summary>
        /// <param name="model">The stocktakecounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(StockTakeCounter model);

        /// <summary>Updates a specific stocktakecounter by its primary key</summary>
        /// <param name="id">The primary key of the stocktakecounter</param>
        /// <param name="updatedEntity">The stocktakecounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, StockTakeCounter updatedEntity);

        /// <summary>Updates a specific stocktakecounter by its primary key</summary>
        /// <param name="id">The primary key of the stocktakecounter</param>
        /// <param name="updatedEntity">The stocktakecounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<StockTakeCounter> updatedEntity);

        /// <summary>Deletes a specific stocktakecounter by its primary key</summary>
        /// <param name="id">The primary key of the stocktakecounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The stocktakecounterService responsible for managing stocktakecounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting stocktakecounter information.
    /// </remarks>
    public class StockTakeCounterService : IStockTakeCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the StockTakeCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public StockTakeCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific stocktakecounter by its primary key</summary>
        /// <param name="id">The primary key of the stocktakecounter</param>
        /// <returns>The stocktakecounter data</returns>
        public StockTakeCounter GetById(Guid id)
        {
            var entityData = _dbContext.StockTakeCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of stocktakecounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of stocktakecounters</returns>/// <exception cref="Exception"></exception>
        public List<StockTakeCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetStockTakeCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new stocktakecounter</summary>
        /// <param name="model">The stocktakecounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(StockTakeCounter model)
        {
            model.TenantId = CreateStockTakeCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific stocktakecounter by its primary key</summary>
        /// <param name="id">The primary key of the stocktakecounter</param>
        /// <param name="updatedEntity">The stocktakecounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, StockTakeCounter updatedEntity)
        {
            UpdateStockTakeCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific stocktakecounter by its primary key</summary>
        /// <param name="id">The primary key of the stocktakecounter</param>
        /// <param name="updatedEntity">The stocktakecounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<StockTakeCounter> updatedEntity)
        {
            PatchStockTakeCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific stocktakecounter by its primary key</summary>
        /// <param name="id">The primary key of the stocktakecounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteStockTakeCounter(id);
            return true;
        }
        #region
        private List<StockTakeCounter> GetStockTakeCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.StockTakeCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<StockTakeCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(StockTakeCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<StockTakeCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateStockTakeCounter(StockTakeCounter model)
        {
            _dbContext.StockTakeCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateStockTakeCounter(Guid id, StockTakeCounter updatedEntity)
        {
            _dbContext.StockTakeCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteStockTakeCounter(Guid id)
        {
            var entityData = _dbContext.StockTakeCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.StockTakeCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchStockTakeCounter(Guid id, JsonPatchDocument<StockTakeCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.StockTakeCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.StockTakeCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}