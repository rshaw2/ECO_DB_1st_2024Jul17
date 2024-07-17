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
    /// The emrgeneralsettingsService responsible for managing emrgeneralsettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting emrgeneralsettings information.
    /// </remarks>
    public interface IEmrGeneralSettingsService
    {
        /// <summary>Retrieves a specific emrgeneralsettings by its primary key</summary>
        /// <param name="id">The primary key of the emrgeneralsettings</param>
        /// <returns>The emrgeneralsettings data</returns>
        EmrGeneralSettings GetById(Guid id);

        /// <summary>Retrieves a list of emrgeneralsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of emrgeneralsettingss</returns>
        List<EmrGeneralSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new emrgeneralsettings</summary>
        /// <param name="model">The emrgeneralsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(EmrGeneralSettings model);

        /// <summary>Updates a specific emrgeneralsettings by its primary key</summary>
        /// <param name="id">The primary key of the emrgeneralsettings</param>
        /// <param name="updatedEntity">The emrgeneralsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, EmrGeneralSettings updatedEntity);

        /// <summary>Updates a specific emrgeneralsettings by its primary key</summary>
        /// <param name="id">The primary key of the emrgeneralsettings</param>
        /// <param name="updatedEntity">The emrgeneralsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<EmrGeneralSettings> updatedEntity);

        /// <summary>Deletes a specific emrgeneralsettings by its primary key</summary>
        /// <param name="id">The primary key of the emrgeneralsettings</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The emrgeneralsettingsService responsible for managing emrgeneralsettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting emrgeneralsettings information.
    /// </remarks>
    public class EmrGeneralSettingsService : IEmrGeneralSettingsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the EmrGeneralSettings class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public EmrGeneralSettingsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific emrgeneralsettings by its primary key</summary>
        /// <param name="id">The primary key of the emrgeneralsettings</param>
        /// <returns>The emrgeneralsettings data</returns>
        public EmrGeneralSettings GetById(Guid id)
        {
            var entityData = _dbContext.EmrGeneralSettings.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of emrgeneralsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of emrgeneralsettingss</returns>/// <exception cref="Exception"></exception>
        public List<EmrGeneralSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetEmrGeneralSettings(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new emrgeneralsettings</summary>
        /// <param name="model">The emrgeneralsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(EmrGeneralSettings model)
        {
            model.Id = CreateEmrGeneralSettings(model);
            return model.Id;
        }

        /// <summary>Updates a specific emrgeneralsettings by its primary key</summary>
        /// <param name="id">The primary key of the emrgeneralsettings</param>
        /// <param name="updatedEntity">The emrgeneralsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, EmrGeneralSettings updatedEntity)
        {
            UpdateEmrGeneralSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific emrgeneralsettings by its primary key</summary>
        /// <param name="id">The primary key of the emrgeneralsettings</param>
        /// <param name="updatedEntity">The emrgeneralsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<EmrGeneralSettings> updatedEntity)
        {
            PatchEmrGeneralSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific emrgeneralsettings by its primary key</summary>
        /// <param name="id">The primary key of the emrgeneralsettings</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteEmrGeneralSettings(id);
            return true;
        }
        #region
        private List<EmrGeneralSettings> GetEmrGeneralSettings(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EmrGeneralSettings.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EmrGeneralSettings>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EmrGeneralSettings), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EmrGeneralSettings, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateEmrGeneralSettings(EmrGeneralSettings model)
        {
            _dbContext.EmrGeneralSettings.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateEmrGeneralSettings(Guid id, EmrGeneralSettings updatedEntity)
        {
            _dbContext.EmrGeneralSettings.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteEmrGeneralSettings(Guid id)
        {
            var entityData = _dbContext.EmrGeneralSettings.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EmrGeneralSettings.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchEmrGeneralSettings(Guid id, JsonPatchDocument<EmrGeneralSettings> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EmrGeneralSettings.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EmrGeneralSettings.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}