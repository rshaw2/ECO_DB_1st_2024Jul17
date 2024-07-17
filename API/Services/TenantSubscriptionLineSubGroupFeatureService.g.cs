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
    /// The tenantsubscriptionlinesubgroupfeatureService responsible for managing tenantsubscriptionlinesubgroupfeature related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsubscriptionlinesubgroupfeature information.
    /// </remarks>
    public interface ITenantSubscriptionLineSubGroupFeatureService
    {
        /// <summary>Retrieves a specific tenantsubscriptionlinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeature</param>
        /// <returns>The tenantsubscriptionlinesubgroupfeature data</returns>
        TenantSubscriptionLineSubGroupFeature GetById(Guid id);

        /// <summary>Retrieves a list of tenantsubscriptionlinesubgroupfeatures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsubscriptionlinesubgroupfeatures</returns>
        List<TenantSubscriptionLineSubGroupFeature> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantsubscriptionlinesubgroupfeature</summary>
        /// <param name="model">The tenantsubscriptionlinesubgroupfeature data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantSubscriptionLineSubGroupFeature model);

        /// <summary>Updates a specific tenantsubscriptionlinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeature</param>
        /// <param name="updatedEntity">The tenantsubscriptionlinesubgroupfeature data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantSubscriptionLineSubGroupFeature updatedEntity);

        /// <summary>Updates a specific tenantsubscriptionlinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeature</param>
        /// <param name="updatedEntity">The tenantsubscriptionlinesubgroupfeature data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantSubscriptionLineSubGroupFeature> updatedEntity);

        /// <summary>Deletes a specific tenantsubscriptionlinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeature</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantsubscriptionlinesubgroupfeatureService responsible for managing tenantsubscriptionlinesubgroupfeature related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsubscriptionlinesubgroupfeature information.
    /// </remarks>
    public class TenantSubscriptionLineSubGroupFeatureService : ITenantSubscriptionLineSubGroupFeatureService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantSubscriptionLineSubGroupFeature class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantSubscriptionLineSubGroupFeatureService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantsubscriptionlinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeature</param>
        /// <returns>The tenantsubscriptionlinesubgroupfeature data</returns>
        public TenantSubscriptionLineSubGroupFeature GetById(Guid id)
        {
            var entityData = _dbContext.TenantSubscriptionLineSubGroupFeature.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantsubscriptionlinesubgroupfeatures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsubscriptionlinesubgroupfeatures</returns>/// <exception cref="Exception"></exception>
        public List<TenantSubscriptionLineSubGroupFeature> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantSubscriptionLineSubGroupFeature(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantsubscriptionlinesubgroupfeature</summary>
        /// <param name="model">The tenantsubscriptionlinesubgroupfeature data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantSubscriptionLineSubGroupFeature model)
        {
            model.Id = CreateTenantSubscriptionLineSubGroupFeature(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantsubscriptionlinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeature</param>
        /// <param name="updatedEntity">The tenantsubscriptionlinesubgroupfeature data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantSubscriptionLineSubGroupFeature updatedEntity)
        {
            UpdateTenantSubscriptionLineSubGroupFeature(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantsubscriptionlinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeature</param>
        /// <param name="updatedEntity">The tenantsubscriptionlinesubgroupfeature data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantSubscriptionLineSubGroupFeature> updatedEntity)
        {
            PatchTenantSubscriptionLineSubGroupFeature(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantsubscriptionlinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeature</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantSubscriptionLineSubGroupFeature(id);
            return true;
        }
        #region
        private List<TenantSubscriptionLineSubGroupFeature> GetTenantSubscriptionLineSubGroupFeature(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantSubscriptionLineSubGroupFeature.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantSubscriptionLineSubGroupFeature>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantSubscriptionLineSubGroupFeature), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantSubscriptionLineSubGroupFeature, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantSubscriptionLineSubGroupFeature(TenantSubscriptionLineSubGroupFeature model)
        {
            _dbContext.TenantSubscriptionLineSubGroupFeature.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantSubscriptionLineSubGroupFeature(Guid id, TenantSubscriptionLineSubGroupFeature updatedEntity)
        {
            _dbContext.TenantSubscriptionLineSubGroupFeature.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantSubscriptionLineSubGroupFeature(Guid id)
        {
            var entityData = _dbContext.TenantSubscriptionLineSubGroupFeature.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantSubscriptionLineSubGroupFeature.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantSubscriptionLineSubGroupFeature(Guid id, JsonPatchDocument<TenantSubscriptionLineSubGroupFeature> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantSubscriptionLineSubGroupFeature.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantSubscriptionLineSubGroupFeature.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}