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
    /// The usercredentialloginService responsible for managing usercredentiallogin related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting usercredentiallogin information.
    /// </remarks>
    public interface IUserCredentialLoginService
    {
        /// <summary>Retrieves a specific usercredentiallogin by its primary key</summary>
        /// <param name="id">The primary key of the usercredentiallogin</param>
        /// <returns>The usercredentiallogin data</returns>
        UserCredentialLogin GetById(Guid id);

        /// <summary>Retrieves a list of usercredentiallogins based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of usercredentiallogins</returns>
        List<UserCredentialLogin> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new usercredentiallogin</summary>
        /// <param name="model">The usercredentiallogin data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UserCredentialLogin model);

        /// <summary>Updates a specific usercredentiallogin by its primary key</summary>
        /// <param name="id">The primary key of the usercredentiallogin</param>
        /// <param name="updatedEntity">The usercredentiallogin data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UserCredentialLogin updatedEntity);

        /// <summary>Updates a specific usercredentiallogin by its primary key</summary>
        /// <param name="id">The primary key of the usercredentiallogin</param>
        /// <param name="updatedEntity">The usercredentiallogin data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UserCredentialLogin> updatedEntity);

        /// <summary>Deletes a specific usercredentiallogin by its primary key</summary>
        /// <param name="id">The primary key of the usercredentiallogin</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The usercredentialloginService responsible for managing usercredentiallogin related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting usercredentiallogin information.
    /// </remarks>
    public class UserCredentialLoginService : IUserCredentialLoginService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UserCredentialLogin class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UserCredentialLoginService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific usercredentiallogin by its primary key</summary>
        /// <param name="id">The primary key of the usercredentiallogin</param>
        /// <returns>The usercredentiallogin data</returns>
        public UserCredentialLogin GetById(Guid id)
        {
            var entityData = _dbContext.UserCredentialLogin.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of usercredentiallogins based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of usercredentiallogins</returns>/// <exception cref="Exception"></exception>
        public List<UserCredentialLogin> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUserCredentialLogin(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new usercredentiallogin</summary>
        /// <param name="model">The usercredentiallogin data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UserCredentialLogin model)
        {
            model.Id = CreateUserCredentialLogin(model);
            return model.Id;
        }

        /// <summary>Updates a specific usercredentiallogin by its primary key</summary>
        /// <param name="id">The primary key of the usercredentiallogin</param>
        /// <param name="updatedEntity">The usercredentiallogin data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UserCredentialLogin updatedEntity)
        {
            UpdateUserCredentialLogin(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific usercredentiallogin by its primary key</summary>
        /// <param name="id">The primary key of the usercredentiallogin</param>
        /// <param name="updatedEntity">The usercredentiallogin data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UserCredentialLogin> updatedEntity)
        {
            PatchUserCredentialLogin(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific usercredentiallogin by its primary key</summary>
        /// <param name="id">The primary key of the usercredentiallogin</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUserCredentialLogin(id);
            return true;
        }
        #region
        private List<UserCredentialLogin> GetUserCredentialLogin(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UserCredentialLogin.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UserCredentialLogin>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UserCredentialLogin), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UserCredentialLogin, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUserCredentialLogin(UserCredentialLogin model)
        {
            _dbContext.UserCredentialLogin.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUserCredentialLogin(Guid id, UserCredentialLogin updatedEntity)
        {
            _dbContext.UserCredentialLogin.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUserCredentialLogin(Guid id)
        {
            var entityData = _dbContext.UserCredentialLogin.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UserCredentialLogin.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUserCredentialLogin(Guid id, JsonPatchDocument<UserCredentialLogin> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UserCredentialLogin.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UserCredentialLogin.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}