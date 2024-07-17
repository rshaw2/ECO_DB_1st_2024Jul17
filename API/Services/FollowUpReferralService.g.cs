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
    /// The followupreferralService responsible for managing followupreferral related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting followupreferral information.
    /// </remarks>
    public interface IFollowUpReferralService
    {
        /// <summary>Retrieves a specific followupreferral by its primary key</summary>
        /// <param name="id">The primary key of the followupreferral</param>
        /// <returns>The followupreferral data</returns>
        FollowUpReferral GetById(Guid id);

        /// <summary>Retrieves a list of followupreferrals based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of followupreferrals</returns>
        List<FollowUpReferral> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new followupreferral</summary>
        /// <param name="model">The followupreferral data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(FollowUpReferral model);

        /// <summary>Updates a specific followupreferral by its primary key</summary>
        /// <param name="id">The primary key of the followupreferral</param>
        /// <param name="updatedEntity">The followupreferral data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, FollowUpReferral updatedEntity);

        /// <summary>Updates a specific followupreferral by its primary key</summary>
        /// <param name="id">The primary key of the followupreferral</param>
        /// <param name="updatedEntity">The followupreferral data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<FollowUpReferral> updatedEntity);

        /// <summary>Deletes a specific followupreferral by its primary key</summary>
        /// <param name="id">The primary key of the followupreferral</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The followupreferralService responsible for managing followupreferral related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting followupreferral information.
    /// </remarks>
    public class FollowUpReferralService : IFollowUpReferralService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the FollowUpReferral class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public FollowUpReferralService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific followupreferral by its primary key</summary>
        /// <param name="id">The primary key of the followupreferral</param>
        /// <returns>The followupreferral data</returns>
        public FollowUpReferral GetById(Guid id)
        {
            var entityData = _dbContext.FollowUpReferral.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of followupreferrals based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of followupreferrals</returns>/// <exception cref="Exception"></exception>
        public List<FollowUpReferral> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetFollowUpReferral(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new followupreferral</summary>
        /// <param name="model">The followupreferral data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(FollowUpReferral model)
        {
            model.Id = CreateFollowUpReferral(model);
            return model.Id;
        }

        /// <summary>Updates a specific followupreferral by its primary key</summary>
        /// <param name="id">The primary key of the followupreferral</param>
        /// <param name="updatedEntity">The followupreferral data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, FollowUpReferral updatedEntity)
        {
            UpdateFollowUpReferral(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific followupreferral by its primary key</summary>
        /// <param name="id">The primary key of the followupreferral</param>
        /// <param name="updatedEntity">The followupreferral data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<FollowUpReferral> updatedEntity)
        {
            PatchFollowUpReferral(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific followupreferral by its primary key</summary>
        /// <param name="id">The primary key of the followupreferral</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteFollowUpReferral(id);
            return true;
        }
        #region
        private List<FollowUpReferral> GetFollowUpReferral(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.FollowUpReferral.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<FollowUpReferral>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(FollowUpReferral), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<FollowUpReferral, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateFollowUpReferral(FollowUpReferral model)
        {
            _dbContext.FollowUpReferral.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateFollowUpReferral(Guid id, FollowUpReferral updatedEntity)
        {
            _dbContext.FollowUpReferral.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteFollowUpReferral(Guid id)
        {
            var entityData = _dbContext.FollowUpReferral.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.FollowUpReferral.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchFollowUpReferral(Guid id, JsonPatchDocument<FollowUpReferral> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.FollowUpReferral.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.FollowUpReferral.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}