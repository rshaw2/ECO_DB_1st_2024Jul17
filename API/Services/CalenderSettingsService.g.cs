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
    /// The calendersettingsService responsible for managing calendersettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting calendersettings information.
    /// </remarks>
    public interface ICalenderSettingsService
    {
        /// <summary>Retrieves a specific calendersettings by its primary key</summary>
        /// <param name="id">The primary key of the calendersettings</param>
        /// <returns>The calendersettings data</returns>
        CalenderSettings GetById(Guid id);

        /// <summary>Retrieves a list of calendersettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of calendersettingss</returns>
        List<CalenderSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new calendersettings</summary>
        /// <param name="model">The calendersettings data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CalenderSettings model);

        /// <summary>Updates a specific calendersettings by its primary key</summary>
        /// <param name="id">The primary key of the calendersettings</param>
        /// <param name="updatedEntity">The calendersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CalenderSettings updatedEntity);

        /// <summary>Updates a specific calendersettings by its primary key</summary>
        /// <param name="id">The primary key of the calendersettings</param>
        /// <param name="updatedEntity">The calendersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CalenderSettings> updatedEntity);

        /// <summary>Deletes a specific calendersettings by its primary key</summary>
        /// <param name="id">The primary key of the calendersettings</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The calendersettingsService responsible for managing calendersettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting calendersettings information.
    /// </remarks>
    public class CalenderSettingsService : ICalenderSettingsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CalenderSettings class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CalenderSettingsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific calendersettings by its primary key</summary>
        /// <param name="id">The primary key of the calendersettings</param>
        /// <returns>The calendersettings data</returns>
        public CalenderSettings GetById(Guid id)
        {
            var entityData = _dbContext.CalenderSettings.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of calendersettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of calendersettingss</returns>/// <exception cref="Exception"></exception>
        public List<CalenderSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCalenderSettings(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new calendersettings</summary>
        /// <param name="model">The calendersettings data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CalenderSettings model)
        {
            model.Id = CreateCalenderSettings(model);
            return model.Id;
        }

        /// <summary>Updates a specific calendersettings by its primary key</summary>
        /// <param name="id">The primary key of the calendersettings</param>
        /// <param name="updatedEntity">The calendersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CalenderSettings updatedEntity)
        {
            UpdateCalenderSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific calendersettings by its primary key</summary>
        /// <param name="id">The primary key of the calendersettings</param>
        /// <param name="updatedEntity">The calendersettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CalenderSettings> updatedEntity)
        {
            PatchCalenderSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific calendersettings by its primary key</summary>
        /// <param name="id">The primary key of the calendersettings</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCalenderSettings(id);
            return true;
        }
        #region
        private List<CalenderSettings> GetCalenderSettings(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CalenderSettings.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CalenderSettings>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CalenderSettings), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CalenderSettings, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCalenderSettings(CalenderSettings model)
        {
            _dbContext.CalenderSettings.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCalenderSettings(Guid id, CalenderSettings updatedEntity)
        {
            _dbContext.CalenderSettings.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCalenderSettings(Guid id)
        {
            var entityData = _dbContext.CalenderSettings.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CalenderSettings.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCalenderSettings(Guid id, JsonPatchDocument<CalenderSettings> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CalenderSettings.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CalenderSettings.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}