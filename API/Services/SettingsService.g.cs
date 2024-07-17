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
    /// The settingsService responsible for managing settings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting settings information.
    /// </remarks>
    public interface ISettingsService
    {
        /// <summary>Retrieves a specific settings by its primary key</summary>
        /// <param name="id">The primary key of the settings</param>
        /// <returns>The settings data</returns>
        Settings GetById(Guid id);

        /// <summary>Retrieves a list of settingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of settingss</returns>
        List<Settings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new settings</summary>
        /// <param name="model">The settings data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Settings model);

        /// <summary>Updates a specific settings by its primary key</summary>
        /// <param name="id">The primary key of the settings</param>
        /// <param name="updatedEntity">The settings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Settings updatedEntity);

        /// <summary>Updates a specific settings by its primary key</summary>
        /// <param name="id">The primary key of the settings</param>
        /// <param name="updatedEntity">The settings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Settings> updatedEntity);

        /// <summary>Deletes a specific settings by its primary key</summary>
        /// <param name="id">The primary key of the settings</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The settingsService responsible for managing settings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting settings information.
    /// </remarks>
    public class SettingsService : ISettingsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Settings class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SettingsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific settings by its primary key</summary>
        /// <param name="id">The primary key of the settings</param>
        /// <returns>The settings data</returns>
        public Settings GetById(Guid id)
        {
            var entityData = _dbContext.Settings.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of settingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of settingss</returns>/// <exception cref="Exception"></exception>
        public List<Settings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSettings(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new settings</summary>
        /// <param name="model">The settings data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Settings model)
        {
            model.Id = CreateSettings(model);
            return model.Id;
        }

        /// <summary>Updates a specific settings by its primary key</summary>
        /// <param name="id">The primary key of the settings</param>
        /// <param name="updatedEntity">The settings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Settings updatedEntity)
        {
            UpdateSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific settings by its primary key</summary>
        /// <param name="id">The primary key of the settings</param>
        /// <param name="updatedEntity">The settings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Settings> updatedEntity)
        {
            PatchSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific settings by its primary key</summary>
        /// <param name="id">The primary key of the settings</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSettings(id);
            return true;
        }
        #region
        private List<Settings> GetSettings(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Settings.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Settings>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Settings), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Settings, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSettings(Settings model)
        {
            _dbContext.Settings.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSettings(Guid id, Settings updatedEntity)
        {
            _dbContext.Settings.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSettings(Guid id)
        {
            var entityData = _dbContext.Settings.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Settings.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSettings(Guid id, JsonPatchDocument<Settings> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Settings.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Settings.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}