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
    /// The tenantsubscriptionadditionaluserService responsible for managing tenantsubscriptionadditionaluser related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsubscriptionadditionaluser information.
    /// </remarks>
    public interface ITenantSubscriptionAdditionalUserService
    {
        /// <summary>Retrieves a specific tenantsubscriptionadditionaluser by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionadditionaluser</param>
        /// <returns>The tenantsubscriptionadditionaluser data</returns>
        TenantSubscriptionAdditionalUser GetById(Guid id);

        /// <summary>Retrieves a list of tenantsubscriptionadditionalusers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsubscriptionadditionalusers</returns>
        List<TenantSubscriptionAdditionalUser> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantsubscriptionadditionaluser</summary>
        /// <param name="model">The tenantsubscriptionadditionaluser data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantSubscriptionAdditionalUser model);

        /// <summary>Updates a specific tenantsubscriptionadditionaluser by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionadditionaluser</param>
        /// <param name="updatedEntity">The tenantsubscriptionadditionaluser data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantSubscriptionAdditionalUser updatedEntity);

        /// <summary>Updates a specific tenantsubscriptionadditionaluser by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionadditionaluser</param>
        /// <param name="updatedEntity">The tenantsubscriptionadditionaluser data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantSubscriptionAdditionalUser> updatedEntity);

        /// <summary>Deletes a specific tenantsubscriptionadditionaluser by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionadditionaluser</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantsubscriptionadditionaluserService responsible for managing tenantsubscriptionadditionaluser related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantsubscriptionadditionaluser information.
    /// </remarks>
    public class TenantSubscriptionAdditionalUserService : ITenantSubscriptionAdditionalUserService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantSubscriptionAdditionalUser class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantSubscriptionAdditionalUserService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantsubscriptionadditionaluser by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionadditionaluser</param>
        /// <returns>The tenantsubscriptionadditionaluser data</returns>
        public TenantSubscriptionAdditionalUser GetById(Guid id)
        {
            var entityData = _dbContext.TenantSubscriptionAdditionalUser.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantsubscriptionadditionalusers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantsubscriptionadditionalusers</returns>/// <exception cref="Exception"></exception>
        public List<TenantSubscriptionAdditionalUser> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantSubscriptionAdditionalUser(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantsubscriptionadditionaluser</summary>
        /// <param name="model">The tenantsubscriptionadditionaluser data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantSubscriptionAdditionalUser model)
        {
            model.Id = CreateTenantSubscriptionAdditionalUser(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantsubscriptionadditionaluser by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionadditionaluser</param>
        /// <param name="updatedEntity">The tenantsubscriptionadditionaluser data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantSubscriptionAdditionalUser updatedEntity)
        {
            UpdateTenantSubscriptionAdditionalUser(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantsubscriptionadditionaluser by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionadditionaluser</param>
        /// <param name="updatedEntity">The tenantsubscriptionadditionaluser data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantSubscriptionAdditionalUser> updatedEntity)
        {
            PatchTenantSubscriptionAdditionalUser(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantsubscriptionadditionaluser by its primary key</summary>
        /// <param name="id">The primary key of the tenantsubscriptionadditionaluser</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantSubscriptionAdditionalUser(id);
            return true;
        }
        #region
        private List<TenantSubscriptionAdditionalUser> GetTenantSubscriptionAdditionalUser(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantSubscriptionAdditionalUser.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantSubscriptionAdditionalUser>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantSubscriptionAdditionalUser), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantSubscriptionAdditionalUser, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantSubscriptionAdditionalUser(TenantSubscriptionAdditionalUser model)
        {
            _dbContext.TenantSubscriptionAdditionalUser.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantSubscriptionAdditionalUser(Guid id, TenantSubscriptionAdditionalUser updatedEntity)
        {
            _dbContext.TenantSubscriptionAdditionalUser.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantSubscriptionAdditionalUser(Guid id)
        {
            var entityData = _dbContext.TenantSubscriptionAdditionalUser.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantSubscriptionAdditionalUser.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantSubscriptionAdditionalUser(Guid id, JsonPatchDocument<TenantSubscriptionAdditionalUser> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantSubscriptionAdditionalUser.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantSubscriptionAdditionalUser.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}