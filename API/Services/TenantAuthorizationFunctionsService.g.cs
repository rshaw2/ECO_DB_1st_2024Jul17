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
    /// The tenantauthorizationfunctionsService responsible for managing tenantauthorizationfunctions related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantauthorizationfunctions information.
    /// </remarks>
    public interface ITenantAuthorizationFunctionsService
    {
        /// <summary>Retrieves a specific tenantauthorizationfunctions by its primary key</summary>
        /// <param name="id">The primary key of the tenantauthorizationfunctions</param>
        /// <returns>The tenantauthorizationfunctions data</returns>
        TenantAuthorizationFunctions GetById(Guid id);

        /// <summary>Retrieves a list of tenantauthorizationfunctionss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantauthorizationfunctionss</returns>
        List<TenantAuthorizationFunctions> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantauthorizationfunctions</summary>
        /// <param name="model">The tenantauthorizationfunctions data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantAuthorizationFunctions model);

        /// <summary>Updates a specific tenantauthorizationfunctions by its primary key</summary>
        /// <param name="id">The primary key of the tenantauthorizationfunctions</param>
        /// <param name="updatedEntity">The tenantauthorizationfunctions data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantAuthorizationFunctions updatedEntity);

        /// <summary>Updates a specific tenantauthorizationfunctions by its primary key</summary>
        /// <param name="id">The primary key of the tenantauthorizationfunctions</param>
        /// <param name="updatedEntity">The tenantauthorizationfunctions data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantAuthorizationFunctions> updatedEntity);

        /// <summary>Deletes a specific tenantauthorizationfunctions by its primary key</summary>
        /// <param name="id">The primary key of the tenantauthorizationfunctions</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantauthorizationfunctionsService responsible for managing tenantauthorizationfunctions related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantauthorizationfunctions information.
    /// </remarks>
    public class TenantAuthorizationFunctionsService : ITenantAuthorizationFunctionsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantAuthorizationFunctions class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantAuthorizationFunctionsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantauthorizationfunctions by its primary key</summary>
        /// <param name="id">The primary key of the tenantauthorizationfunctions</param>
        /// <returns>The tenantauthorizationfunctions data</returns>
        public TenantAuthorizationFunctions GetById(Guid id)
        {
            var entityData = _dbContext.TenantAuthorizationFunctions.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantauthorizationfunctionss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantauthorizationfunctionss</returns>/// <exception cref="Exception"></exception>
        public List<TenantAuthorizationFunctions> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantAuthorizationFunctions(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantauthorizationfunctions</summary>
        /// <param name="model">The tenantauthorizationfunctions data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantAuthorizationFunctions model)
        {
            model.Id = CreateTenantAuthorizationFunctions(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantauthorizationfunctions by its primary key</summary>
        /// <param name="id">The primary key of the tenantauthorizationfunctions</param>
        /// <param name="updatedEntity">The tenantauthorizationfunctions data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantAuthorizationFunctions updatedEntity)
        {
            UpdateTenantAuthorizationFunctions(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantauthorizationfunctions by its primary key</summary>
        /// <param name="id">The primary key of the tenantauthorizationfunctions</param>
        /// <param name="updatedEntity">The tenantauthorizationfunctions data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantAuthorizationFunctions> updatedEntity)
        {
            PatchTenantAuthorizationFunctions(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantauthorizationfunctions by its primary key</summary>
        /// <param name="id">The primary key of the tenantauthorizationfunctions</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantAuthorizationFunctions(id);
            return true;
        }
        #region
        private List<TenantAuthorizationFunctions> GetTenantAuthorizationFunctions(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantAuthorizationFunctions.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantAuthorizationFunctions>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantAuthorizationFunctions), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantAuthorizationFunctions, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantAuthorizationFunctions(TenantAuthorizationFunctions model)
        {
            _dbContext.TenantAuthorizationFunctions.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantAuthorizationFunctions(Guid id, TenantAuthorizationFunctions updatedEntity)
        {
            _dbContext.TenantAuthorizationFunctions.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantAuthorizationFunctions(Guid id)
        {
            var entityData = _dbContext.TenantAuthorizationFunctions.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantAuthorizationFunctions.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantAuthorizationFunctions(Guid id, JsonPatchDocument<TenantAuthorizationFunctions> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantAuthorizationFunctions.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantAuthorizationFunctions.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}