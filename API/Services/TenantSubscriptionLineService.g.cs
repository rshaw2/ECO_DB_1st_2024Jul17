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
    /// The tenantsubscriptionlineService responsible for managing tenantsubscriptionline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsubscriptionline information.
    /// </remarks>
    public interface ITenantSubscriptionLineService
    {
        /// <summary>Retrieves a specific tenantsubscriptionline by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionline</param>
        /// <returns>The tenantsubscriptionline data</returns>
        TenantSubscriptionLine GetById(Guid id);

        /// <summary>Retrieves a list of tenantsubscriptionlines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsubscriptionlines</returns>
        List<TenantSubscriptionLine> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantsubscriptionline</summary>
        /// <param name="model">The tenantsubscriptionline data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantSubscriptionLine model);

        /// <summary>Updates a specific tenantsubscriptionline by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionline</param>
        /// <param name="updatedEntity">The tenantsubscriptionline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantSubscriptionLine updatedEntity);

        /// <summary>Updates a specific tenantsubscriptionline by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionline</param>
        /// <param name="updatedEntity">The tenantsubscriptionline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantSubscriptionLine> updatedEntity);

        /// <summary>Deletes a specific tenantsubscriptionline by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionline</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantsubscriptionlineService responsible for managing tenantsubscriptionline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsubscriptionline information.
    /// </remarks>
    public class TenantSubscriptionLineService : ITenantSubscriptionLineService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantSubscriptionLine class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantSubscriptionLineService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantsubscriptionline by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionline</param>
        /// <returns>The tenantsubscriptionline data</returns>
        public TenantSubscriptionLine GetById(Guid id)
        {
            var entityData = _dbContext.TenantSubscriptionLine.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantsubscriptionlines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsubscriptionlines</returns>/// <exception cref="Exception"></exception>
        public List<TenantSubscriptionLine> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantSubscriptionLine(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantsubscriptionline</summary>
        /// <param name="model">The tenantsubscriptionline data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantSubscriptionLine model)
        {
            model.Id = CreateTenantSubscriptionLine(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantsubscriptionline by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionline</param>
        /// <param name="updatedEntity">The tenantsubscriptionline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantSubscriptionLine updatedEntity)
        {
            UpdateTenantSubscriptionLine(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantsubscriptionline by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionline</param>
        /// <param name="updatedEntity">The tenantsubscriptionline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantSubscriptionLine> updatedEntity)
        {
            PatchTenantSubscriptionLine(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantsubscriptionline by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionline</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantSubscriptionLine(id);
            return true;
        }
        #region
        private List<TenantSubscriptionLine> GetTenantSubscriptionLine(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantSubscriptionLine.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantSubscriptionLine>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantSubscriptionLine), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantSubscriptionLine, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantSubscriptionLine(TenantSubscriptionLine model)
        {
            _dbContext.TenantSubscriptionLine.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantSubscriptionLine(Guid id, TenantSubscriptionLine updatedEntity)
        {
            _dbContext.TenantSubscriptionLine.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantSubscriptionLine(Guid id)
        {
            var entityData = _dbContext.TenantSubscriptionLine.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantSubscriptionLine.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantSubscriptionLine(Guid id, JsonPatchDocument<TenantSubscriptionLine> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantSubscriptionLine.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantSubscriptionLine.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}