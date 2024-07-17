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
    /// The tenantextensionService responsible for managing tenantextension related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantextension information.
    /// </remarks>
    public interface ITenantExtensionService
    {
        /// <summary>Retrieves a specific tenantextension by its primary key</summary>
        /// <param name="id">The primary key of the tenantextension</param>
        /// <returns>The tenantextension data</returns>
        TenantExtension GetById(Guid id);

        /// <summary>Retrieves a list of tenantextensions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantextensions</returns>
        List<TenantExtension> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantextension</summary>
        /// <param name="model">The tenantextension data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantExtension model);

        /// <summary>Updates a specific tenantextension by its primary key</summary>
        /// <param name="id">The primary key of the tenantextension</param>
        /// <param name="updatedEntity">The tenantextension data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantExtension updatedEntity);

        /// <summary>Updates a specific tenantextension by its primary key</summary>
        /// <param name="id">The primary key of the tenantextension</param>
        /// <param name="updatedEntity">The tenantextension data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantExtension> updatedEntity);

        /// <summary>Deletes a specific tenantextension by its primary key</summary>
        /// <param name="id">The primary key of the tenantextension</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantextensionService responsible for managing tenantextension related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantextension information.
    /// </remarks>
    public class TenantExtensionService : ITenantExtensionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantExtension class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantExtensionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantextension by its primary key</summary>
        /// <param name="id">The primary key of the tenantextension</param>
        /// <returns>The tenantextension data</returns>
        public TenantExtension GetById(Guid id)
        {
            var entityData = _dbContext.TenantExtension.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantextensions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantextensions</returns>/// <exception cref="Exception"></exception>
        public List<TenantExtension> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantExtension(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantextension</summary>
        /// <param name="model">The tenantextension data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantExtension model)
        {
            model.Id = CreateTenantExtension(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantextension by its primary key</summary>
        /// <param name="id">The primary key of the tenantextension</param>
        /// <param name="updatedEntity">The tenantextension data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantExtension updatedEntity)
        {
            UpdateTenantExtension(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantextension by its primary key</summary>
        /// <param name="id">The primary key of the tenantextension</param>
        /// <param name="updatedEntity">The tenantextension data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantExtension> updatedEntity)
        {
            PatchTenantExtension(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantextension by its primary key</summary>
        /// <param name="id">The primary key of the tenantextension</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantExtension(id);
            return true;
        }
        #region
        private List<TenantExtension> GetTenantExtension(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantExtension.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantExtension>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantExtension), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantExtension, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantExtension(TenantExtension model)
        {
            _dbContext.TenantExtension.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantExtension(Guid id, TenantExtension updatedEntity)
        {
            _dbContext.TenantExtension.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantExtension(Guid id)
        {
            var entityData = _dbContext.TenantExtension.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantExtension.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantExtension(Guid id, JsonPatchDocument<TenantExtension> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantExtension.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantExtension.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}