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
    /// The organizationsettingsfileService responsible for managing organizationsettingsfile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting organizationsettingsfile information.
    /// </remarks>
    public interface IOrganizationSettingsFileService
    {
        /// <summary>Retrieves a specific organizationsettingsfile by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettingsfile</param>
        /// <returns>The organizationsettingsfile data</returns>
        OrganizationSettingsFile GetById(Guid id);

        /// <summary>Retrieves a list of organizationsettingsfiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of organizationsettingsfiles</returns>
        List<OrganizationSettingsFile> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new organizationsettingsfile</summary>
        /// <param name="model">The organizationsettingsfile data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(OrganizationSettingsFile model);

        /// <summary>Updates a specific organizationsettingsfile by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettingsfile</param>
        /// <param name="updatedEntity">The organizationsettingsfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, OrganizationSettingsFile updatedEntity);

        /// <summary>Updates a specific organizationsettingsfile by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettingsfile</param>
        /// <param name="updatedEntity">The organizationsettingsfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<OrganizationSettingsFile> updatedEntity);

        /// <summary>Deletes a specific organizationsettingsfile by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettingsfile</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The organizationsettingsfileService responsible for managing organizationsettingsfile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting organizationsettingsfile information.
    /// </remarks>
    public class OrganizationSettingsFileService : IOrganizationSettingsFileService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the OrganizationSettingsFile class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public OrganizationSettingsFileService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific organizationsettingsfile by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettingsfile</param>
        /// <returns>The organizationsettingsfile data</returns>
        public OrganizationSettingsFile GetById(Guid id)
        {
            var entityData = _dbContext.OrganizationSettingsFile.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of organizationsettingsfiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of organizationsettingsfiles</returns>/// <exception cref="Exception"></exception>
        public List<OrganizationSettingsFile> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetOrganizationSettingsFile(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new organizationsettingsfile</summary>
        /// <param name="model">The organizationsettingsfile data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(OrganizationSettingsFile model)
        {
            model.Id = CreateOrganizationSettingsFile(model);
            return model.Id;
        }

        /// <summary>Updates a specific organizationsettingsfile by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettingsfile</param>
        /// <param name="updatedEntity">The organizationsettingsfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, OrganizationSettingsFile updatedEntity)
        {
            UpdateOrganizationSettingsFile(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific organizationsettingsfile by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettingsfile</param>
        /// <param name="updatedEntity">The organizationsettingsfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<OrganizationSettingsFile> updatedEntity)
        {
            PatchOrganizationSettingsFile(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific organizationsettingsfile by its primary key</summary>
        /// <param name="id">The primary key of the organizationsettingsfile</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteOrganizationSettingsFile(id);
            return true;
        }
        #region
        private List<OrganizationSettingsFile> GetOrganizationSettingsFile(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.OrganizationSettingsFile.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<OrganizationSettingsFile>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(OrganizationSettingsFile), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<OrganizationSettingsFile, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateOrganizationSettingsFile(OrganizationSettingsFile model)
        {
            _dbContext.OrganizationSettingsFile.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateOrganizationSettingsFile(Guid id, OrganizationSettingsFile updatedEntity)
        {
            _dbContext.OrganizationSettingsFile.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteOrganizationSettingsFile(Guid id)
        {
            var entityData = _dbContext.OrganizationSettingsFile.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.OrganizationSettingsFile.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchOrganizationSettingsFile(Guid id, JsonPatchDocument<OrganizationSettingsFile> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.OrganizationSettingsFile.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.OrganizationSettingsFile.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}