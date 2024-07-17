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
    /// The authorizationlogService responsible for managing authorizationlog related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting authorizationlog information.
    /// </remarks>
    public interface IAuthorizationLogService
    {
        /// <summary>Retrieves a specific authorizationlog by its primary key</summary>
        /// <param name="id">The primary key of the authorizationlog</param>
        /// <returns>The authorizationlog data</returns>
        AuthorizationLog GetById(Guid id);

        /// <summary>Retrieves a list of authorizationlogs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of authorizationlogs</returns>
        List<AuthorizationLog> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new authorizationlog</summary>
        /// <param name="model">The authorizationlog data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AuthorizationLog model);

        /// <summary>Updates a specific authorizationlog by its primary key</summary>
        /// <param name="id">The primary key of the authorizationlog</param>
        /// <param name="updatedEntity">The authorizationlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AuthorizationLog updatedEntity);

        /// <summary>Updates a specific authorizationlog by its primary key</summary>
        /// <param name="id">The primary key of the authorizationlog</param>
        /// <param name="updatedEntity">The authorizationlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AuthorizationLog> updatedEntity);

        /// <summary>Deletes a specific authorizationlog by its primary key</summary>
        /// <param name="id">The primary key of the authorizationlog</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The authorizationlogService responsible for managing authorizationlog related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting authorizationlog information.
    /// </remarks>
    public class AuthorizationLogService : IAuthorizationLogService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AuthorizationLog class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AuthorizationLogService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific authorizationlog by its primary key</summary>
        /// <param name="id">The primary key of the authorizationlog</param>
        /// <returns>The authorizationlog data</returns>
        public AuthorizationLog GetById(Guid id)
        {
            var entityData = _dbContext.AuthorizationLog.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of authorizationlogs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of authorizationlogs</returns>/// <exception cref="Exception"></exception>
        public List<AuthorizationLog> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAuthorizationLog(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new authorizationlog</summary>
        /// <param name="model">The authorizationlog data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AuthorizationLog model)
        {
            model.Id = CreateAuthorizationLog(model);
            return model.Id;
        }

        /// <summary>Updates a specific authorizationlog by its primary key</summary>
        /// <param name="id">The primary key of the authorizationlog</param>
        /// <param name="updatedEntity">The authorizationlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AuthorizationLog updatedEntity)
        {
            UpdateAuthorizationLog(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific authorizationlog by its primary key</summary>
        /// <param name="id">The primary key of the authorizationlog</param>
        /// <param name="updatedEntity">The authorizationlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AuthorizationLog> updatedEntity)
        {
            PatchAuthorizationLog(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific authorizationlog by its primary key</summary>
        /// <param name="id">The primary key of the authorizationlog</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAuthorizationLog(id);
            return true;
        }
        #region
        private List<AuthorizationLog> GetAuthorizationLog(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AuthorizationLog.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AuthorizationLog>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AuthorizationLog), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AuthorizationLog, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAuthorizationLog(AuthorizationLog model)
        {
            _dbContext.AuthorizationLog.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAuthorizationLog(Guid id, AuthorizationLog updatedEntity)
        {
            _dbContext.AuthorizationLog.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAuthorizationLog(Guid id)
        {
            var entityData = _dbContext.AuthorizationLog.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AuthorizationLog.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAuthorizationLog(Guid id, JsonPatchDocument<AuthorizationLog> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AuthorizationLog.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AuthorizationLog.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}