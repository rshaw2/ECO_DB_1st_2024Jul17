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
    /// The aiprovidersettingsService responsible for managing aiprovidersettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting aiprovidersettings information.
    /// </remarks>
    public interface IAiProviderSettingsService
    {
        /// <summary>Retrieves a specific aiprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the aiprovidersettings</param>
        /// <returns>The aiprovidersettings data</returns>
        AiProviderSettings GetById(Guid id);

        /// <summary>Retrieves a list of aiprovidersettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aiprovidersettingss</returns>
        List<AiProviderSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new aiprovidersettings</summary>
        /// <param name="model">The aiprovidersettings data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AiProviderSettings model);

        /// <summary>Updates a specific aiprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the aiprovidersettings</param>
        /// <param name="updatedEntity">The aiprovidersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AiProviderSettings updatedEntity);

        /// <summary>Updates a specific aiprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the aiprovidersettings</param>
        /// <param name="updatedEntity">The aiprovidersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AiProviderSettings> updatedEntity);

        /// <summary>Deletes a specific aiprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the aiprovidersettings</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The aiprovidersettingsService responsible for managing aiprovidersettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting aiprovidersettings information.
    /// </remarks>
    public class AiProviderSettingsService : IAiProviderSettingsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AiProviderSettings class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AiProviderSettingsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific aiprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the aiprovidersettings</param>
        /// <returns>The aiprovidersettings data</returns>
        public AiProviderSettings GetById(Guid id)
        {
            var entityData = _dbContext.AiProviderSettings.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of aiprovidersettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aiprovidersettingss</returns>/// <exception cref="Exception"></exception>
        public List<AiProviderSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAiProviderSettings(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new aiprovidersettings</summary>
        /// <param name="model">The aiprovidersettings data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AiProviderSettings model)
        {
            model.Id = CreateAiProviderSettings(model);
            return model.Id;
        }

        /// <summary>Updates a specific aiprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the aiprovidersettings</param>
        /// <param name="updatedEntity">The aiprovidersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AiProviderSettings updatedEntity)
        {
            UpdateAiProviderSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific aiprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the aiprovidersettings</param>
        /// <param name="updatedEntity">The aiprovidersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AiProviderSettings> updatedEntity)
        {
            PatchAiProviderSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific aiprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the aiprovidersettings</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAiProviderSettings(id);
            return true;
        }
        #region
        private List<AiProviderSettings> GetAiProviderSettings(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AiProviderSettings.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AiProviderSettings>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AiProviderSettings), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AiProviderSettings, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAiProviderSettings(AiProviderSettings model)
        {
            _dbContext.AiProviderSettings.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAiProviderSettings(Guid id, AiProviderSettings updatedEntity)
        {
            _dbContext.AiProviderSettings.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAiProviderSettings(Guid id)
        {
            var entityData = _dbContext.AiProviderSettings.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AiProviderSettings.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAiProviderSettings(Guid id, JsonPatchDocument<AiProviderSettings> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AiProviderSettings.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AiProviderSettings.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}