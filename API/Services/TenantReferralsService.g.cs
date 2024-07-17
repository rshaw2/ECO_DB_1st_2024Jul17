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
    /// The tenantreferralsService responsible for managing tenantreferrals related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantreferrals information.
    /// </remarks>
    public interface ITenantReferralsService
    {
        /// <summary>Retrieves a specific tenantreferrals by its primary key</summary>
        /// <param name="id">The primary key of the tenantreferrals</param>
        /// <returns>The tenantreferrals data</returns>
        TenantReferrals GetById(Guid id);

        /// <summary>Retrieves a list of tenantreferralss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantreferralss</returns>
        List<TenantReferrals> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantreferrals</summary>
        /// <param name="model">The tenantreferrals data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantReferrals model);

        /// <summary>Updates a specific tenantreferrals by its primary key</summary>
        /// <param name="id">The primary key of the tenantreferrals</param>
        /// <param name="updatedEntity">The tenantreferrals data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantReferrals updatedEntity);

        /// <summary>Updates a specific tenantreferrals by its primary key</summary>
        /// <param name="id">The primary key of the tenantreferrals</param>
        /// <param name="updatedEntity">The tenantreferrals data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantReferrals> updatedEntity);

        /// <summary>Deletes a specific tenantreferrals by its primary key</summary>
        /// <param name="id">The primary key of the tenantreferrals</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantreferralsService responsible for managing tenantreferrals related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantreferrals information.
    /// </remarks>
    public class TenantReferralsService : ITenantReferralsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantReferrals class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantReferralsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantreferrals by its primary key</summary>
        /// <param name="id">The primary key of the tenantreferrals</param>
        /// <returns>The tenantreferrals data</returns>
        public TenantReferrals GetById(Guid id)
        {
            var entityData = _dbContext.TenantReferrals.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantreferralss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantreferralss</returns>/// <exception cref="Exception"></exception>
        public List<TenantReferrals> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantReferrals(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantreferrals</summary>
        /// <param name="model">The tenantreferrals data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantReferrals model)
        {
            model.Id = CreateTenantReferrals(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantreferrals by its primary key</summary>
        /// <param name="id">The primary key of the tenantreferrals</param>
        /// <param name="updatedEntity">The tenantreferrals data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantReferrals updatedEntity)
        {
            UpdateTenantReferrals(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantreferrals by its primary key</summary>
        /// <param name="id">The primary key of the tenantreferrals</param>
        /// <param name="updatedEntity">The tenantreferrals data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantReferrals> updatedEntity)
        {
            PatchTenantReferrals(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantreferrals by its primary key</summary>
        /// <param name="id">The primary key of the tenantreferrals</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantReferrals(id);
            return true;
        }
        #region
        private List<TenantReferrals> GetTenantReferrals(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantReferrals.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantReferrals>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantReferrals), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantReferrals, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantReferrals(TenantReferrals model)
        {
            _dbContext.TenantReferrals.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantReferrals(Guid id, TenantReferrals updatedEntity)
        {
            _dbContext.TenantReferrals.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantReferrals(Guid id)
        {
            var entityData = _dbContext.TenantReferrals.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantReferrals.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantReferrals(Guid id, JsonPatchDocument<TenantReferrals> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantReferrals.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantReferrals.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}