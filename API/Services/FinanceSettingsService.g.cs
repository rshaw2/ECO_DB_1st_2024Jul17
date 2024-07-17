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
    /// The financesettingsService responsible for managing financesettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting financesettings information.
    /// </remarks>
    public interface IFinanceSettingsService
    {
        /// <summary>Retrieves a specific financesettings by its primary key</summary>
        /// <param name="id">The primary key of the financesettings</param>
        /// <returns>The financesettings data</returns>
        FinanceSettings GetById(Guid id);

        /// <summary>Retrieves a list of financesettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of financesettingss</returns>
        List<FinanceSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new financesettings</summary>
        /// <param name="model">The financesettings data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(FinanceSettings model);

        /// <summary>Updates a specific financesettings by its primary key</summary>
        /// <param name="id">The primary key of the financesettings</param>
        /// <param name="updatedEntity">The financesettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, FinanceSettings updatedEntity);

        /// <summary>Updates a specific financesettings by its primary key</summary>
        /// <param name="id">The primary key of the financesettings</param>
        /// <param name="updatedEntity">The financesettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<FinanceSettings> updatedEntity);

        /// <summary>Deletes a specific financesettings by its primary key</summary>
        /// <param name="id">The primary key of the financesettings</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The financesettingsService responsible for managing financesettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting financesettings information.
    /// </remarks>
    public class FinanceSettingsService : IFinanceSettingsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the FinanceSettings class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public FinanceSettingsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific financesettings by its primary key</summary>
        /// <param name="id">The primary key of the financesettings</param>
        /// <returns>The financesettings data</returns>
        public FinanceSettings GetById(Guid id)
        {
            var entityData = _dbContext.FinanceSettings.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of financesettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of financesettingss</returns>/// <exception cref="Exception"></exception>
        public List<FinanceSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetFinanceSettings(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new financesettings</summary>
        /// <param name="model">The financesettings data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(FinanceSettings model)
        {
            model.Id = CreateFinanceSettings(model);
            return model.Id;
        }

        /// <summary>Updates a specific financesettings by its primary key</summary>
        /// <param name="id">The primary key of the financesettings</param>
        /// <param name="updatedEntity">The financesettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, FinanceSettings updatedEntity)
        {
            UpdateFinanceSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific financesettings by its primary key</summary>
        /// <param name="id">The primary key of the financesettings</param>
        /// <param name="updatedEntity">The financesettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<FinanceSettings> updatedEntity)
        {
            PatchFinanceSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific financesettings by its primary key</summary>
        /// <param name="id">The primary key of the financesettings</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteFinanceSettings(id);
            return true;
        }
        #region
        private List<FinanceSettings> GetFinanceSettings(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.FinanceSettings.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<FinanceSettings>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(FinanceSettings), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<FinanceSettings, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateFinanceSettings(FinanceSettings model)
        {
            _dbContext.FinanceSettings.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateFinanceSettings(Guid id, FinanceSettings updatedEntity)
        {
            _dbContext.FinanceSettings.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteFinanceSettings(Guid id)
        {
            var entityData = _dbContext.FinanceSettings.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.FinanceSettings.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchFinanceSettings(Guid id, JsonPatchDocument<FinanceSettings> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.FinanceSettings.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.FinanceSettings.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}