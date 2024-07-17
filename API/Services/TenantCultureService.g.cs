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
    /// The tenantcultureService responsible for managing tenantculture related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantculture information.
    /// </remarks>
    public interface ITenantCultureService
    {
        /// <summary>Retrieves a specific tenantculture by its primary key</summary>
        /// <param name="id">The primary key of the tenantculture</param>
        /// <returns>The tenantculture data</returns>
        TenantCulture GetById(Guid id);

        /// <summary>Retrieves a list of tenantcultures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantcultures</returns>
        List<TenantCulture> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantculture</summary>
        /// <param name="model">The tenantculture data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantCulture model);

        /// <summary>Updates a specific tenantculture by its primary key</summary>
        /// <param name="id">The primary key of the tenantculture</param>
        /// <param name="updatedEntity">The tenantculture data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantCulture updatedEntity);

        /// <summary>Updates a specific tenantculture by its primary key</summary>
        /// <param name="id">The primary key of the tenantculture</param>
        /// <param name="updatedEntity">The tenantculture data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantCulture> updatedEntity);

        /// <summary>Deletes a specific tenantculture by its primary key</summary>
        /// <param name="id">The primary key of the tenantculture</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantcultureService responsible for managing tenantculture related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantculture information.
    /// </remarks>
    public class TenantCultureService : ITenantCultureService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantCulture class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantCultureService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantculture by its primary key</summary>
        /// <param name="id">The primary key of the tenantculture</param>
        /// <returns>The tenantculture data</returns>
        public TenantCulture GetById(Guid id)
        {
            var entityData = _dbContext.TenantCulture.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantcultures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantcultures</returns>/// <exception cref="Exception"></exception>
        public List<TenantCulture> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantCulture(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantculture</summary>
        /// <param name="model">The tenantculture data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantCulture model)
        {
            model.Id = CreateTenantCulture(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantculture by its primary key</summary>
        /// <param name="id">The primary key of the tenantculture</param>
        /// <param name="updatedEntity">The tenantculture data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantCulture updatedEntity)
        {
            UpdateTenantCulture(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantculture by its primary key</summary>
        /// <param name="id">The primary key of the tenantculture</param>
        /// <param name="updatedEntity">The tenantculture data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantCulture> updatedEntity)
        {
            PatchTenantCulture(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantculture by its primary key</summary>
        /// <param name="id">The primary key of the tenantculture</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantCulture(id);
            return true;
        }
        #region
        private List<TenantCulture> GetTenantCulture(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantCulture.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantCulture>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantCulture), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantCulture, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantCulture(TenantCulture model)
        {
            _dbContext.TenantCulture.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantCulture(Guid id, TenantCulture updatedEntity)
        {
            _dbContext.TenantCulture.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantCulture(Guid id)
        {
            var entityData = _dbContext.TenantCulture.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantCulture.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantCulture(Guid id, JsonPatchDocument<TenantCulture> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantCulture.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantCulture.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}