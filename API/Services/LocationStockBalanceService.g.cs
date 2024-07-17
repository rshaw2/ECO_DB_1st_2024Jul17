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
    /// The locationstockbalanceService responsible for managing locationstockbalance related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting locationstockbalance information.
    /// </remarks>
    public interface ILocationStockBalanceService
    {
        /// <summary>Retrieves a specific locationstockbalance by its primary key</summary>
        /// <param name="id">The primary key of the locationstockbalance</param>
        /// <returns>The locationstockbalance data</returns>
        LocationStockBalance GetById(Guid id);

        /// <summary>Retrieves a list of locationstockbalances based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of locationstockbalances</returns>
        List<LocationStockBalance> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new locationstockbalance</summary>
        /// <param name="model">The locationstockbalance data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(LocationStockBalance model);

        /// <summary>Updates a specific locationstockbalance by its primary key</summary>
        /// <param name="id">The primary key of the locationstockbalance</param>
        /// <param name="updatedEntity">The locationstockbalance data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, LocationStockBalance updatedEntity);

        /// <summary>Updates a specific locationstockbalance by its primary key</summary>
        /// <param name="id">The primary key of the locationstockbalance</param>
        /// <param name="updatedEntity">The locationstockbalance data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<LocationStockBalance> updatedEntity);

        /// <summary>Deletes a specific locationstockbalance by its primary key</summary>
        /// <param name="id">The primary key of the locationstockbalance</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The locationstockbalanceService responsible for managing locationstockbalance related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting locationstockbalance information.
    /// </remarks>
    public class LocationStockBalanceService : ILocationStockBalanceService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the LocationStockBalance class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public LocationStockBalanceService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific locationstockbalance by its primary key</summary>
        /// <param name="id">The primary key of the locationstockbalance</param>
        /// <returns>The locationstockbalance data</returns>
        public LocationStockBalance GetById(Guid id)
        {
            var entityData = _dbContext.LocationStockBalance.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of locationstockbalances based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of locationstockbalances</returns>/// <exception cref="Exception"></exception>
        public List<LocationStockBalance> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetLocationStockBalance(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new locationstockbalance</summary>
        /// <param name="model">The locationstockbalance data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(LocationStockBalance model)
        {
            model.Id = CreateLocationStockBalance(model);
            return model.Id;
        }

        /// <summary>Updates a specific locationstockbalance by its primary key</summary>
        /// <param name="id">The primary key of the locationstockbalance</param>
        /// <param name="updatedEntity">The locationstockbalance data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, LocationStockBalance updatedEntity)
        {
            UpdateLocationStockBalance(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific locationstockbalance by its primary key</summary>
        /// <param name="id">The primary key of the locationstockbalance</param>
        /// <param name="updatedEntity">The locationstockbalance data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<LocationStockBalance> updatedEntity)
        {
            PatchLocationStockBalance(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific locationstockbalance by its primary key</summary>
        /// <param name="id">The primary key of the locationstockbalance</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteLocationStockBalance(id);
            return true;
        }
        #region
        private List<LocationStockBalance> GetLocationStockBalance(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LocationStockBalance.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LocationStockBalance>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LocationStockBalance), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LocationStockBalance, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateLocationStockBalance(LocationStockBalance model)
        {
            _dbContext.LocationStockBalance.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateLocationStockBalance(Guid id, LocationStockBalance updatedEntity)
        {
            _dbContext.LocationStockBalance.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteLocationStockBalance(Guid id)
        {
            var entityData = _dbContext.LocationStockBalance.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LocationStockBalance.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchLocationStockBalance(Guid id, JsonPatchDocument<LocationStockBalance> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LocationStockBalance.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LocationStockBalance.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}