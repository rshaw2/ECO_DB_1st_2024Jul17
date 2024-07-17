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
    /// The tenantdeleteotpService responsible for managing tenantdeleteotp related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantdeleteotp information.
    /// </remarks>
    public interface ITenantDeleteOtpService
    {
        /// <summary>Retrieves a specific tenantdeleteotp by its primary key</summary>
        /// <param name="id">The primary key of the tenantdeleteotp</param>
        /// <returns>The tenantdeleteotp data</returns>
        TenantDeleteOtp GetById(Guid id);

        /// <summary>Retrieves a list of tenantdeleteotps based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantdeleteotps</returns>
        List<TenantDeleteOtp> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantdeleteotp</summary>
        /// <param name="model">The tenantdeleteotp data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantDeleteOtp model);

        /// <summary>Updates a specific tenantdeleteotp by its primary key</summary>
        /// <param name="id">The primary key of the tenantdeleteotp</param>
        /// <param name="updatedEntity">The tenantdeleteotp data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantDeleteOtp updatedEntity);

        /// <summary>Updates a specific tenantdeleteotp by its primary key</summary>
        /// <param name="id">The primary key of the tenantdeleteotp</param>
        /// <param name="updatedEntity">The tenantdeleteotp data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantDeleteOtp> updatedEntity);

        /// <summary>Deletes a specific tenantdeleteotp by its primary key</summary>
        /// <param name="id">The primary key of the tenantdeleteotp</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantdeleteotpService responsible for managing tenantdeleteotp related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantdeleteotp information.
    /// </remarks>
    public class TenantDeleteOtpService : ITenantDeleteOtpService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantDeleteOtp class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantDeleteOtpService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantdeleteotp by its primary key</summary>
        /// <param name="id">The primary key of the tenantdeleteotp</param>
        /// <returns>The tenantdeleteotp data</returns>
        public TenantDeleteOtp GetById(Guid id)
        {
            var entityData = _dbContext.TenantDeleteOtp.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantdeleteotps based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantdeleteotps</returns>/// <exception cref="Exception"></exception>
        public List<TenantDeleteOtp> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantDeleteOtp(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantdeleteotp</summary>
        /// <param name="model">The tenantdeleteotp data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantDeleteOtp model)
        {
            model.Id = CreateTenantDeleteOtp(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantdeleteotp by its primary key</summary>
        /// <param name="id">The primary key of the tenantdeleteotp</param>
        /// <param name="updatedEntity">The tenantdeleteotp data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantDeleteOtp updatedEntity)
        {
            UpdateTenantDeleteOtp(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantdeleteotp by its primary key</summary>
        /// <param name="id">The primary key of the tenantdeleteotp</param>
        /// <param name="updatedEntity">The tenantdeleteotp data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantDeleteOtp> updatedEntity)
        {
            PatchTenantDeleteOtp(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantdeleteotp by its primary key</summary>
        /// <param name="id">The primary key of the tenantdeleteotp</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantDeleteOtp(id);
            return true;
        }
        #region
        private List<TenantDeleteOtp> GetTenantDeleteOtp(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantDeleteOtp.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantDeleteOtp>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantDeleteOtp), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantDeleteOtp, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantDeleteOtp(TenantDeleteOtp model)
        {
            _dbContext.TenantDeleteOtp.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantDeleteOtp(Guid id, TenantDeleteOtp updatedEntity)
        {
            _dbContext.TenantDeleteOtp.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantDeleteOtp(Guid id)
        {
            var entityData = _dbContext.TenantDeleteOtp.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantDeleteOtp.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantDeleteOtp(Guid id, JsonPatchDocument<TenantDeleteOtp> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantDeleteOtp.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantDeleteOtp.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}