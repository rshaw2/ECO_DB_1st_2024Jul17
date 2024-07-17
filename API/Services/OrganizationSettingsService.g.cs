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
    /// The organizationsettingsService responsible for managing organizationsettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting organizationsettings information.
    /// </remarks>
    public interface IOrganizationSettingsService
    {
        /// <summary>Retrieves a specific organizationsettings by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettings</param>
        /// <returns>The organizationsettings data</returns>
        OrganizationSettings GetById(Guid id);

        /// <summary>Retrieves a list of organizationsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of organizationsettingss</returns>
        List<OrganizationSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new organizationsettings</summary>
        /// <param name="model">The organizationsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(OrganizationSettings model);

        /// <summary>Updates a specific organizationsettings by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettings</param>
        /// <param name="updatedEntity">The organizationsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, OrganizationSettings updatedEntity);

        /// <summary>Updates a specific organizationsettings by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettings</param>
        /// <param name="updatedEntity">The organizationsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<OrganizationSettings> updatedEntity);

        /// <summary>Deletes a specific organizationsettings by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettings</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The organizationsettingsService responsible for managing organizationsettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting organizationsettings information.
    /// </remarks>
    public class OrganizationSettingsService : IOrganizationSettingsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the OrganizationSettings class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public OrganizationSettingsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific organizationsettings by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettings</param>
        /// <returns>The organizationsettings data</returns>
        public OrganizationSettings GetById(Guid id)
        {
            var entityData = _dbContext.OrganizationSettings.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of organizationsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of organizationsettingss</returns>/// <exception cref="Exception"></exception>
        public List<OrganizationSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetOrganizationSettings(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new organizationsettings</summary>
        /// <param name="model">The organizationsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(OrganizationSettings model)
        {
            model.Id = CreateOrganizationSettings(model);
            return model.Id;
        }

        /// <summary>Updates a specific organizationsettings by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettings</param>
        /// <param name="updatedEntity">The organizationsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, OrganizationSettings updatedEntity)
        {
            UpdateOrganizationSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific organizationsettings by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettings</param>
        /// <param name="updatedEntity">The organizationsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<OrganizationSettings> updatedEntity)
        {
            PatchOrganizationSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific organizationsettings by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettings</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteOrganizationSettings(id);
            return true;
        }
        #region
        private List<OrganizationSettings> GetOrganizationSettings(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.OrganizationSettings.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<OrganizationSettings>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(OrganizationSettings), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<OrganizationSettings, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateOrganizationSettings(OrganizationSettings model)
        {
            _dbContext.OrganizationSettings.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateOrganizationSettings(Guid id, OrganizationSettings updatedEntity)
        {
            _dbContext.OrganizationSettings.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteOrganizationSettings(Guid id)
        {
            var entityData = _dbContext.OrganizationSettings.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.OrganizationSettings.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchOrganizationSettings(Guid id, JsonPatchDocument<OrganizationSettings> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.OrganizationSettings.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.OrganizationSettings.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}