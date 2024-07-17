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
    /// The usergoogleauthorizationService responsible for managing usergoogleauthorization related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting usergoogleauthorization information.
    /// </remarks>
    public interface IUserGoogleAuthorizationService
    {
        /// <summary>Retrieves a specific usergoogleauthorization by its primary key</summary>
        /// <param name="id">The primary key of the usergoogleauthorization</param>
        /// <returns>The usergoogleauthorization data</returns>
        UserGoogleAuthorization GetById(Guid id);

        /// <summary>Retrieves a list of usergoogleauthorizations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of usergoogleauthorizations</returns>
        List<UserGoogleAuthorization> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new usergoogleauthorization</summary>
        /// <param name="model">The usergoogleauthorization data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UserGoogleAuthorization model);

        /// <summary>Updates a specific usergoogleauthorization by its primary key</summary>
        /// <param name="id">The primary key of the usergoogleauthorization</param>
        /// <param name="updatedEntity">The usergoogleauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UserGoogleAuthorization updatedEntity);

        /// <summary>Updates a specific usergoogleauthorization by its primary key</summary>
        /// <param name="id">The primary key of the usergoogleauthorization</param>
        /// <param name="updatedEntity">The usergoogleauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UserGoogleAuthorization> updatedEntity);

        /// <summary>Deletes a specific usergoogleauthorization by its primary key</summary>
        /// <param name="id">The primary key of the usergoogleauthorization</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The usergoogleauthorizationService responsible for managing usergoogleauthorization related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting usergoogleauthorization information.
    /// </remarks>
    public class UserGoogleAuthorizationService : IUserGoogleAuthorizationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UserGoogleAuthorization class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UserGoogleAuthorizationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific usergoogleauthorization by its primary key</summary>
        /// <param name="id">The primary key of the usergoogleauthorization</param>
        /// <returns>The usergoogleauthorization data</returns>
        public UserGoogleAuthorization GetById(Guid id)
        {
            var entityData = _dbContext.UserGoogleAuthorization.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of usergoogleauthorizations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of usergoogleauthorizations</returns>/// <exception cref="Exception"></exception>
        public List<UserGoogleAuthorization> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUserGoogleAuthorization(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new usergoogleauthorization</summary>
        /// <param name="model">The usergoogleauthorization data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UserGoogleAuthorization model)
        {
            model.Id = CreateUserGoogleAuthorization(model);
            return model.Id;
        }

        /// <summary>Updates a specific usergoogleauthorization by its primary key</summary>
        /// <param name="id">The primary key of the usergoogleauthorization</param>
        /// <param name="updatedEntity">The usergoogleauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UserGoogleAuthorization updatedEntity)
        {
            UpdateUserGoogleAuthorization(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific usergoogleauthorization by its primary key</summary>
        /// <param name="id">The primary key of the usergoogleauthorization</param>
        /// <param name="updatedEntity">The usergoogleauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UserGoogleAuthorization> updatedEntity)
        {
            PatchUserGoogleAuthorization(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific usergoogleauthorization by its primary key</summary>
        /// <param name="id">The primary key of the usergoogleauthorization</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUserGoogleAuthorization(id);
            return true;
        }
        #region
        private List<UserGoogleAuthorization> GetUserGoogleAuthorization(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UserGoogleAuthorization.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UserGoogleAuthorization>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UserGoogleAuthorization), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UserGoogleAuthorization, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUserGoogleAuthorization(UserGoogleAuthorization model)
        {
            _dbContext.UserGoogleAuthorization.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUserGoogleAuthorization(Guid id, UserGoogleAuthorization updatedEntity)
        {
            _dbContext.UserGoogleAuthorization.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUserGoogleAuthorization(Guid id)
        {
            var entityData = _dbContext.UserGoogleAuthorization.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UserGoogleAuthorization.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUserGoogleAuthorization(Guid id, JsonPatchDocument<UserGoogleAuthorization> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UserGoogleAuthorization.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UserGoogleAuthorization.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}