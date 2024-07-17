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
    /// The referralordercounterService responsible for managing referralordercounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting referralordercounter information.
    /// </remarks>
    public interface IReferralOrderCounterService
    {
        /// <summary>Retrieves a specific referralordercounter by its primary key</summary>
        /// <param name="id">The primary key of the referralordercounter</param>
        /// <returns>The referralordercounter data</returns>
        ReferralOrderCounter GetById(Guid id);

        /// <summary>Retrieves a list of referralordercounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of referralordercounters</returns>
        List<ReferralOrderCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new referralordercounter</summary>
        /// <param name="model">The referralordercounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(ReferralOrderCounter model);

        /// <summary>Updates a specific referralordercounter by its primary key</summary>
        /// <param name="id">The primary key of the referralordercounter</param>
        /// <param name="updatedEntity">The referralordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ReferralOrderCounter updatedEntity);

        /// <summary>Updates a specific referralordercounter by its primary key</summary>
        /// <param name="id">The primary key of the referralordercounter</param>
        /// <param name="updatedEntity">The referralordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ReferralOrderCounter> updatedEntity);

        /// <summary>Deletes a specific referralordercounter by its primary key</summary>
        /// <param name="id">The primary key of the referralordercounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The referralordercounterService responsible for managing referralordercounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting referralordercounter information.
    /// </remarks>
    public class ReferralOrderCounterService : IReferralOrderCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ReferralOrderCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ReferralOrderCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific referralordercounter by its primary key</summary>
        /// <param name="id">The primary key of the referralordercounter</param>
        /// <returns>The referralordercounter data</returns>
        public ReferralOrderCounter GetById(Guid id)
        {
            var entityData = _dbContext.ReferralOrderCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of referralordercounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of referralordercounters</returns>/// <exception cref="Exception"></exception>
        public List<ReferralOrderCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetReferralOrderCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new referralordercounter</summary>
        /// <param name="model">The referralordercounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(ReferralOrderCounter model)
        {
            model.TenantId = CreateReferralOrderCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific referralordercounter by its primary key</summary>
        /// <param name="id">The primary key of the referralordercounter</param>
        /// <param name="updatedEntity">The referralordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ReferralOrderCounter updatedEntity)
        {
            UpdateReferralOrderCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific referralordercounter by its primary key</summary>
        /// <param name="id">The primary key of the referralordercounter</param>
        /// <param name="updatedEntity">The referralordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ReferralOrderCounter> updatedEntity)
        {
            PatchReferralOrderCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific referralordercounter by its primary key</summary>
        /// <param name="id">The primary key of the referralordercounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteReferralOrderCounter(id);
            return true;
        }
        #region
        private List<ReferralOrderCounter> GetReferralOrderCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ReferralOrderCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ReferralOrderCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ReferralOrderCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ReferralOrderCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateReferralOrderCounter(ReferralOrderCounter model)
        {
            _dbContext.ReferralOrderCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateReferralOrderCounter(Guid id, ReferralOrderCounter updatedEntity)
        {
            _dbContext.ReferralOrderCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteReferralOrderCounter(Guid id)
        {
            var entityData = _dbContext.ReferralOrderCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ReferralOrderCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchReferralOrderCounter(Guid id, JsonPatchDocument<ReferralOrderCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ReferralOrderCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ReferralOrderCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}