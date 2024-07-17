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
    /// The tenantsubscriptionlinesubgroupfeatureparameterService responsible for managing tenantsubscriptionlinesubgroupfeatureparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsubscriptionlinesubgroupfeatureparameter information.
    /// </remarks>
    public interface ITenantSubscriptionLineSubGroupFeatureParameterService
    {
        /// <summary>Retrieves a specific tenantsubscriptionlinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeatureparameter</param>
        /// <returns>The tenantsubscriptionlinesubgroupfeatureparameter data</returns>
        TenantSubscriptionLineSubGroupFeatureParameter GetById(Guid id);

        /// <summary>Retrieves a list of tenantsubscriptionlinesubgroupfeatureparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsubscriptionlinesubgroupfeatureparameters</returns>
        List<TenantSubscriptionLineSubGroupFeatureParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantsubscriptionlinesubgroupfeatureparameter</summary>
        /// <param name="model">The tenantsubscriptionlinesubgroupfeatureparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantSubscriptionLineSubGroupFeatureParameter model);

        /// <summary>Updates a specific tenantsubscriptionlinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeatureparameter</param>
        /// <param name="updatedEntity">The tenantsubscriptionlinesubgroupfeatureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantSubscriptionLineSubGroupFeatureParameter updatedEntity);

        /// <summary>Updates a specific tenantsubscriptionlinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeatureparameter</param>
        /// <param name="updatedEntity">The tenantsubscriptionlinesubgroupfeatureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantSubscriptionLineSubGroupFeatureParameter> updatedEntity);

        /// <summary>Deletes a specific tenantsubscriptionlinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeatureparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantsubscriptionlinesubgroupfeatureparameterService responsible for managing tenantsubscriptionlinesubgroupfeatureparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsubscriptionlinesubgroupfeatureparameter information.
    /// </remarks>
    public class TenantSubscriptionLineSubGroupFeatureParameterService : ITenantSubscriptionLineSubGroupFeatureParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantSubscriptionLineSubGroupFeatureParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantSubscriptionLineSubGroupFeatureParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantsubscriptionlinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeatureparameter</param>
        /// <returns>The tenantsubscriptionlinesubgroupfeatureparameter data</returns>
        public TenantSubscriptionLineSubGroupFeatureParameter GetById(Guid id)
        {
            var entityData = _dbContext.TenantSubscriptionLineSubGroupFeatureParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantsubscriptionlinesubgroupfeatureparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsubscriptionlinesubgroupfeatureparameters</returns>/// <exception cref="Exception"></exception>
        public List<TenantSubscriptionLineSubGroupFeatureParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantSubscriptionLineSubGroupFeatureParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantsubscriptionlinesubgroupfeatureparameter</summary>
        /// <param name="model">The tenantsubscriptionlinesubgroupfeatureparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantSubscriptionLineSubGroupFeatureParameter model)
        {
            model.Id = CreateTenantSubscriptionLineSubGroupFeatureParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantsubscriptionlinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeatureparameter</param>
        /// <param name="updatedEntity">The tenantsubscriptionlinesubgroupfeatureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantSubscriptionLineSubGroupFeatureParameter updatedEntity)
        {
            UpdateTenantSubscriptionLineSubGroupFeatureParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantsubscriptionlinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeatureparameter</param>
        /// <param name="updatedEntity">The tenantsubscriptionlinesubgroupfeatureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantSubscriptionLineSubGroupFeatureParameter> updatedEntity)
        {
            PatchTenantSubscriptionLineSubGroupFeatureParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantsubscriptionlinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionlinesubgroupfeatureparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantSubscriptionLineSubGroupFeatureParameter(id);
            return true;
        }
        #region
        private List<TenantSubscriptionLineSubGroupFeatureParameter> GetTenantSubscriptionLineSubGroupFeatureParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantSubscriptionLineSubGroupFeatureParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantSubscriptionLineSubGroupFeatureParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantSubscriptionLineSubGroupFeatureParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantSubscriptionLineSubGroupFeatureParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantSubscriptionLineSubGroupFeatureParameter(TenantSubscriptionLineSubGroupFeatureParameter model)
        {
            _dbContext.TenantSubscriptionLineSubGroupFeatureParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantSubscriptionLineSubGroupFeatureParameter(Guid id, TenantSubscriptionLineSubGroupFeatureParameter updatedEntity)
        {
            _dbContext.TenantSubscriptionLineSubGroupFeatureParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantSubscriptionLineSubGroupFeatureParameter(Guid id)
        {
            var entityData = _dbContext.TenantSubscriptionLineSubGroupFeatureParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantSubscriptionLineSubGroupFeatureParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantSubscriptionLineSubGroupFeatureParameter(Guid id, JsonPatchDocument<TenantSubscriptionLineSubGroupFeatureParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantSubscriptionLineSubGroupFeatureParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantSubscriptionLineSubGroupFeatureParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}