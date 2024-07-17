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
    /// The communicationprovidersettingsService responsible for managing communicationprovidersettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationprovidersettings information.
    /// </remarks>
    public interface ICommunicationProviderSettingsService
    {
        /// <summary>Retrieves a specific communicationprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the communicationprovidersettings</param>
        /// <returns>The communicationprovidersettings data</returns>
        CommunicationProviderSettings GetById(Guid id);

        /// <summary>Retrieves a list of communicationprovidersettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationprovidersettingss</returns>
        List<CommunicationProviderSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationprovidersettings</summary>
        /// <param name="model">The communicationprovidersettings data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationProviderSettings model);

        /// <summary>Updates a specific communicationprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the communicationprovidersettings</param>
        /// <param name="updatedEntity">The communicationprovidersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationProviderSettings updatedEntity);

        /// <summary>Updates a specific communicationprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the communicationprovidersettings</param>
        /// <param name="updatedEntity">The communicationprovidersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationProviderSettings> updatedEntity);

        /// <summary>Deletes a specific communicationprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the communicationprovidersettings</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationprovidersettingsService responsible for managing communicationprovidersettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationprovidersettings information.
    /// </remarks>
    public class CommunicationProviderSettingsService : ICommunicationProviderSettingsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationProviderSettings class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationProviderSettingsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the communicationprovidersettings</param>
        /// <returns>The communicationprovidersettings data</returns>
        public CommunicationProviderSettings GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationProviderSettings.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationprovidersettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationprovidersettingss</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationProviderSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationProviderSettings(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationprovidersettings</summary>
        /// <param name="model">The communicationprovidersettings data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationProviderSettings model)
        {
            model.Id = CreateCommunicationProviderSettings(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the communicationprovidersettings</param>
        /// <param name="updatedEntity">The communicationprovidersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationProviderSettings updatedEntity)
        {
            UpdateCommunicationProviderSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the communicationprovidersettings</param>
        /// <param name="updatedEntity">The communicationprovidersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationProviderSettings> updatedEntity)
        {
            PatchCommunicationProviderSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationprovidersettings by its primary key</summary>
        /// <param name="id">The primary key of the communicationprovidersettings</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationProviderSettings(id);
            return true;
        }
        #region
        private List<CommunicationProviderSettings> GetCommunicationProviderSettings(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationProviderSettings.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationProviderSettings>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationProviderSettings), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationProviderSettings, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationProviderSettings(CommunicationProviderSettings model)
        {
            _dbContext.CommunicationProviderSettings.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationProviderSettings(Guid id, CommunicationProviderSettings updatedEntity)
        {
            _dbContext.CommunicationProviderSettings.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationProviderSettings(Guid id)
        {
            var entityData = _dbContext.CommunicationProviderSettings.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationProviderSettings.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationProviderSettings(Guid id, JsonPatchDocument<CommunicationProviderSettings> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationProviderSettings.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationProviderSettings.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}