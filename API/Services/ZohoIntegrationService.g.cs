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
    /// The zohointegrationService responsible for managing zohointegration related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting zohointegration information.
    /// </remarks>
    public interface IZohoIntegrationService
    {
        /// <summary>Retrieves a specific zohointegration by its primary key</summary>
        /// <param name="id">The primary key of the zohointegration</param>
        /// <returns>The zohointegration data</returns>
        ZohoIntegration GetById(Guid id);

        /// <summary>Retrieves a list of zohointegrations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of zohointegrations</returns>
        List<ZohoIntegration> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new zohointegration</summary>
        /// <param name="model">The zohointegration data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ZohoIntegration model);

        /// <summary>Updates a specific zohointegration by its primary key</summary>
        /// <param name="id">The primary key of the zohointegration</param>
        /// <param name="updatedEntity">The zohointegration data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ZohoIntegration updatedEntity);

        /// <summary>Updates a specific zohointegration by its primary key</summary>
        /// <param name="id">The primary key of the zohointegration</param>
        /// <param name="updatedEntity">The zohointegration data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ZohoIntegration> updatedEntity);

        /// <summary>Deletes a specific zohointegration by its primary key</summary>
        /// <param name="id">The primary key of the zohointegration</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The zohointegrationService responsible for managing zohointegration related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting zohointegration information.
    /// </remarks>
    public class ZohoIntegrationService : IZohoIntegrationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ZohoIntegration class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ZohoIntegrationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific zohointegration by its primary key</summary>
        /// <param name="id">The primary key of the zohointegration</param>
        /// <returns>The zohointegration data</returns>
        public ZohoIntegration GetById(Guid id)
        {
            var entityData = _dbContext.ZohoIntegration.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of zohointegrations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of zohointegrations</returns>/// <exception cref="Exception"></exception>
        public List<ZohoIntegration> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetZohoIntegration(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new zohointegration</summary>
        /// <param name="model">The zohointegration data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ZohoIntegration model)
        {
            model.Id = CreateZohoIntegration(model);
            return model.Id;
        }

        /// <summary>Updates a specific zohointegration by its primary key</summary>
        /// <param name="id">The primary key of the zohointegration</param>
        /// <param name="updatedEntity">The zohointegration data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ZohoIntegration updatedEntity)
        {
            UpdateZohoIntegration(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific zohointegration by its primary key</summary>
        /// <param name="id">The primary key of the zohointegration</param>
        /// <param name="updatedEntity">The zohointegration data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ZohoIntegration> updatedEntity)
        {
            PatchZohoIntegration(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific zohointegration by its primary key</summary>
        /// <param name="id">The primary key of the zohointegration</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteZohoIntegration(id);
            return true;
        }
        #region
        private List<ZohoIntegration> GetZohoIntegration(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ZohoIntegration.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ZohoIntegration>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ZohoIntegration), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ZohoIntegration, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateZohoIntegration(ZohoIntegration model)
        {
            _dbContext.ZohoIntegration.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateZohoIntegration(Guid id, ZohoIntegration updatedEntity)
        {
            _dbContext.ZohoIntegration.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteZohoIntegration(Guid id)
        {
            var entityData = _dbContext.ZohoIntegration.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ZohoIntegration.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchZohoIntegration(Guid id, JsonPatchDocument<ZohoIntegration> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ZohoIntegration.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ZohoIntegration.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}