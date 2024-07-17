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
    /// The referralorderlineService responsible for managing referralorderline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting referralorderline information.
    /// </remarks>
    public interface IReferralOrderLineService
    {
        /// <summary>Retrieves a specific referralorderline by its primary key</summary>
        /// <param name="id">The primary key of the referralorderline</param>
        /// <returns>The referralorderline data</returns>
        ReferralOrderLine GetById(Guid id);

        /// <summary>Retrieves a list of referralorderlines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of referralorderlines</returns>
        List<ReferralOrderLine> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new referralorderline</summary>
        /// <param name="model">The referralorderline data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ReferralOrderLine model);

        /// <summary>Updates a specific referralorderline by its primary key</summary>
        /// <param name="id">The primary key of the referralorderline</param>
        /// <param name="updatedEntity">The referralorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ReferralOrderLine updatedEntity);

        /// <summary>Updates a specific referralorderline by its primary key</summary>
        /// <param name="id">The primary key of the referralorderline</param>
        /// <param name="updatedEntity">The referralorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ReferralOrderLine> updatedEntity);

        /// <summary>Deletes a specific referralorderline by its primary key</summary>
        /// <param name="id">The primary key of the referralorderline</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The referralorderlineService responsible for managing referralorderline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting referralorderline information.
    /// </remarks>
    public class ReferralOrderLineService : IReferralOrderLineService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ReferralOrderLine class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ReferralOrderLineService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific referralorderline by its primary key</summary>
        /// <param name="id">The primary key of the referralorderline</param>
        /// <returns>The referralorderline data</returns>
        public ReferralOrderLine GetById(Guid id)
        {
            var entityData = _dbContext.ReferralOrderLine.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of referralorderlines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of referralorderlines</returns>/// <exception cref="Exception"></exception>
        public List<ReferralOrderLine> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetReferralOrderLine(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new referralorderline</summary>
        /// <param name="model">The referralorderline data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ReferralOrderLine model)
        {
            model.Id = CreateReferralOrderLine(model);
            return model.Id;
        }

        /// <summary>Updates a specific referralorderline by its primary key</summary>
        /// <param name="id">The primary key of the referralorderline</param>
        /// <param name="updatedEntity">The referralorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ReferralOrderLine updatedEntity)
        {
            UpdateReferralOrderLine(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific referralorderline by its primary key</summary>
        /// <param name="id">The primary key of the referralorderline</param>
        /// <param name="updatedEntity">The referralorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ReferralOrderLine> updatedEntity)
        {
            PatchReferralOrderLine(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific referralorderline by its primary key</summary>
        /// <param name="id">The primary key of the referralorderline</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteReferralOrderLine(id);
            return true;
        }
        #region
        private List<ReferralOrderLine> GetReferralOrderLine(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ReferralOrderLine.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ReferralOrderLine>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ReferralOrderLine), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ReferralOrderLine, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateReferralOrderLine(ReferralOrderLine model)
        {
            _dbContext.ReferralOrderLine.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateReferralOrderLine(Guid id, ReferralOrderLine updatedEntity)
        {
            _dbContext.ReferralOrderLine.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteReferralOrderLine(Guid id)
        {
            var entityData = _dbContext.ReferralOrderLine.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ReferralOrderLine.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchReferralOrderLine(Guid id, JsonPatchDocument<ReferralOrderLine> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ReferralOrderLine.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ReferralOrderLine.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}