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
    /// The referralorderService responsible for managing referralorder related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting referralorder information.
    /// </remarks>
    public interface IReferralOrderService
    {
        /// <summary>Retrieves a specific referralorder by its primary key</summary>
        /// <param name="id">The primary key of the referralorder</param>
        /// <returns>The referralorder data</returns>
        ReferralOrder GetById(Guid id);

        /// <summary>Retrieves a list of referralorders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of referralorders</returns>
        List<ReferralOrder> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new referralorder</summary>
        /// <param name="model">The referralorder data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ReferralOrder model);

        /// <summary>Updates a specific referralorder by its primary key</summary>
        /// <param name="id">The primary key of the referralorder</param>
        /// <param name="updatedEntity">The referralorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ReferralOrder updatedEntity);

        /// <summary>Updates a specific referralorder by its primary key</summary>
        /// <param name="id">The primary key of the referralorder</param>
        /// <param name="updatedEntity">The referralorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ReferralOrder> updatedEntity);

        /// <summary>Deletes a specific referralorder by its primary key</summary>
        /// <param name="id">The primary key of the referralorder</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The referralorderService responsible for managing referralorder related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting referralorder information.
    /// </remarks>
    public class ReferralOrderService : IReferralOrderService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ReferralOrder class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ReferralOrderService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific referralorder by its primary key</summary>
        /// <param name="id">The primary key of the referralorder</param>
        /// <returns>The referralorder data</returns>
        public ReferralOrder GetById(Guid id)
        {
            var entityData = _dbContext.ReferralOrder.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of referralorders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of referralorders</returns>/// <exception cref="Exception"></exception>
        public List<ReferralOrder> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetReferralOrder(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new referralorder</summary>
        /// <param name="model">The referralorder data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ReferralOrder model)
        {
            model.Id = CreateReferralOrder(model);
            return model.Id;
        }

        /// <summary>Updates a specific referralorder by its primary key</summary>
        /// <param name="id">The primary key of the referralorder</param>
        /// <param name="updatedEntity">The referralorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ReferralOrder updatedEntity)
        {
            UpdateReferralOrder(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific referralorder by its primary key</summary>
        /// <param name="id">The primary key of the referralorder</param>
        /// <param name="updatedEntity">The referralorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ReferralOrder> updatedEntity)
        {
            PatchReferralOrder(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific referralorder by its primary key</summary>
        /// <param name="id">The primary key of the referralorder</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteReferralOrder(id);
            return true;
        }
        #region
        private List<ReferralOrder> GetReferralOrder(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ReferralOrder.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ReferralOrder>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ReferralOrder), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ReferralOrder, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateReferralOrder(ReferralOrder model)
        {
            _dbContext.ReferralOrder.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateReferralOrder(Guid id, ReferralOrder updatedEntity)
        {
            _dbContext.ReferralOrder.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteReferralOrder(Guid id)
        {
            var entityData = _dbContext.ReferralOrder.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ReferralOrder.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchReferralOrder(Guid id, JsonPatchDocument<ReferralOrder> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ReferralOrder.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ReferralOrder.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}