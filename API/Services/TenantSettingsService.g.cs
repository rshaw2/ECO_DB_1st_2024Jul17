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
    /// The tenantsettingsService responsible for managing tenantsettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsettings information.
    /// </remarks>
    public interface ITenantSettingsService
    {
        /// <summary>Retrieves a specific tenantsettings by its primary key</summary>
        /// <param name="id">The primary key of the tenantsettings</param>
        /// <returns>The tenantsettings data</returns>
        TenantSettings GetById(Guid id);

        /// <summary>Retrieves a list of tenantsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsettingss</returns>
        List<TenantSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantsettings</summary>
        /// <param name="model">The tenantsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantSettings model);

        /// <summary>Updates a specific tenantsettings by its primary key</summary>
        /// <param name="id">The primary key of the tenantsettings</param>
        /// <param name="updatedEntity">The tenantsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantSettings updatedEntity);

        /// <summary>Updates a specific tenantsettings by its primary key</summary>
        /// <param name="id">The primary key of the tenantsettings</param>
        /// <param name="updatedEntity">The tenantsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantSettings> updatedEntity);

        /// <summary>Deletes a specific tenantsettings by its primary key</summary>
        /// <param name="id">The primary key of the tenantsettings</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantsettingsService responsible for managing tenantsettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsettings information.
    /// </remarks>
    public class TenantSettingsService : ITenantSettingsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantSettings class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantSettingsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantsettings by its primary key</summary>
        /// <param name="id">The primary key of the tenantsettings</param>
        /// <returns>The tenantsettings data</returns>
        public TenantSettings GetById(Guid id)
        {
            var entityData = _dbContext.TenantSettings.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsettingss</returns>/// <exception cref="Exception"></exception>
        public List<TenantSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantSettings(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantsettings</summary>
        /// <param name="model">The tenantsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantSettings model)
        {
            model.Id = CreateTenantSettings(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantsettings by its primary key</summary>
        /// <param name="id">The primary key of the tenantsettings</param>
        /// <param name="updatedEntity">The tenantsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantSettings updatedEntity)
        {
            UpdateTenantSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantsettings by its primary key</summary>
        /// <param name="id">The primary key of the tenantsettings</param>
        /// <param name="updatedEntity">The tenantsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantSettings> updatedEntity)
        {
            PatchTenantSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantsettings by its primary key</summary>
        /// <param name="id">The primary key of the tenantsettings</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantSettings(id);
            return true;
        }
        #region
        private List<TenantSettings> GetTenantSettings(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantSettings.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantSettings>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantSettings), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantSettings, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantSettings(TenantSettings model)
        {
            _dbContext.TenantSettings.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantSettings(Guid id, TenantSettings updatedEntity)
        {
            _dbContext.TenantSettings.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantSettings(Guid id)
        {
            var entityData = _dbContext.TenantSettings.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantSettings.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantSettings(Guid id, JsonPatchDocument<TenantSettings> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantSettings.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantSettings.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}