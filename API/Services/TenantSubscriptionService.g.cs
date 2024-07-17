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
    /// The tenantsubscriptionService responsible for managing tenantsubscription related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsubscription information.
    /// </remarks>
    public interface ITenantSubscriptionService
    {
        /// <summary>Retrieves a specific tenantsubscription by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscription</param>
        /// <returns>The tenantsubscription data</returns>
        TenantSubscription GetById(Guid id);

        /// <summary>Retrieves a list of tenantsubscriptions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsubscriptions</returns>
        List<TenantSubscription> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantsubscription</summary>
        /// <param name="model">The tenantsubscription data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantSubscription model);

        /// <summary>Updates a specific tenantsubscription by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscription</param>
        /// <param name="updatedEntity">The tenantsubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantSubscription updatedEntity);

        /// <summary>Updates a specific tenantsubscription by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscription</param>
        /// <param name="updatedEntity">The tenantsubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantSubscription> updatedEntity);

        /// <summary>Deletes a specific tenantsubscription by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscription</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantsubscriptionService responsible for managing tenantsubscription related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsubscription information.
    /// </remarks>
    public class TenantSubscriptionService : ITenantSubscriptionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantSubscription class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantSubscriptionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantsubscription by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscription</param>
        /// <returns>The tenantsubscription data</returns>
        public TenantSubscription GetById(Guid id)
        {
            var entityData = _dbContext.TenantSubscription.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantsubscriptions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsubscriptions</returns>/// <exception cref="Exception"></exception>
        public List<TenantSubscription> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantSubscription(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantsubscription</summary>
        /// <param name="model">The tenantsubscription data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantSubscription model)
        {
            model.Id = CreateTenantSubscription(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantsubscription by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscription</param>
        /// <param name="updatedEntity">The tenantsubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantSubscription updatedEntity)
        {
            UpdateTenantSubscription(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantsubscription by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscription</param>
        /// <param name="updatedEntity">The tenantsubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantSubscription> updatedEntity)
        {
            PatchTenantSubscription(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantsubscription by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscription</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantSubscription(id);
            return true;
        }
        #region
        private List<TenantSubscription> GetTenantSubscription(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantSubscription.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantSubscription>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantSubscription), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantSubscription, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantSubscription(TenantSubscription model)
        {
            _dbContext.TenantSubscription.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantSubscription(Guid id, TenantSubscription updatedEntity)
        {
            _dbContext.TenantSubscription.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantSubscription(Guid id)
        {
            var entityData = _dbContext.TenantSubscription.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantSubscription.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantSubscription(Guid id, JsonPatchDocument<TenantSubscription> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantSubscription.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantSubscription.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}