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
    /// The followupresultService responsible for managing followupresult related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting followupresult information.
    /// </remarks>
    public interface IFollowupResultService
    {
        /// <summary>Retrieves a specific followupresult by its primary key</summary>
        /// <param name="id">The primary key of the followupresult</param>
        /// <returns>The followupresult data</returns>
        FollowupResult GetById(Guid id);

        /// <summary>Retrieves a list of followupresults based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of followupresults</returns>
        List<FollowupResult> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new followupresult</summary>
        /// <param name="model">The followupresult data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(FollowupResult model);

        /// <summary>Updates a specific followupresult by its primary key</summary>
        /// <param name="id">The primary key of the followupresult</param>
        /// <param name="updatedEntity">The followupresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, FollowupResult updatedEntity);

        /// <summary>Updates a specific followupresult by its primary key</summary>
        /// <param name="id">The primary key of the followupresult</param>
        /// <param name="updatedEntity">The followupresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<FollowupResult> updatedEntity);

        /// <summary>Deletes a specific followupresult by its primary key</summary>
        /// <param name="id">The primary key of the followupresult</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The followupresultService responsible for managing followupresult related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting followupresult information.
    /// </remarks>
    public class FollowupResultService : IFollowupResultService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the FollowupResult class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public FollowupResultService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific followupresult by its primary key</summary>
        /// <param name="id">The primary key of the followupresult</param>
        /// <returns>The followupresult data</returns>
        public FollowupResult GetById(Guid id)
        {
            var entityData = _dbContext.FollowupResult.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of followupresults based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of followupresults</returns>/// <exception cref="Exception"></exception>
        public List<FollowupResult> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetFollowupResult(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new followupresult</summary>
        /// <param name="model">The followupresult data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(FollowupResult model)
        {
            model.Id = CreateFollowupResult(model);
            return model.Id;
        }

        /// <summary>Updates a specific followupresult by its primary key</summary>
        /// <param name="id">The primary key of the followupresult</param>
        /// <param name="updatedEntity">The followupresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, FollowupResult updatedEntity)
        {
            UpdateFollowupResult(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific followupresult by its primary key</summary>
        /// <param name="id">The primary key of the followupresult</param>
        /// <param name="updatedEntity">The followupresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<FollowupResult> updatedEntity)
        {
            PatchFollowupResult(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific followupresult by its primary key</summary>
        /// <param name="id">The primary key of the followupresult</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteFollowupResult(id);
            return true;
        }
        #region
        private List<FollowupResult> GetFollowupResult(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.FollowupResult.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<FollowupResult>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(FollowupResult), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<FollowupResult, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateFollowupResult(FollowupResult model)
        {
            _dbContext.FollowupResult.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateFollowupResult(Guid id, FollowupResult updatedEntity)
        {
            _dbContext.FollowupResult.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteFollowupResult(Guid id)
        {
            var entityData = _dbContext.FollowupResult.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.FollowupResult.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchFollowupResult(Guid id, JsonPatchDocument<FollowupResult> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.FollowupResult.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.FollowupResult.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}