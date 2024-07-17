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
    /// The userrosterService responsible for managing userroster related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting userroster information.
    /// </remarks>
    public interface IUserRosterService
    {
        /// <summary>Retrieves a specific userroster by its primary key</summary>
        /// <param name="id">The primary key of the userroster</param>
        /// <returns>The userroster data</returns>
        UserRoster GetById(Guid id);

        /// <summary>Retrieves a list of userrosters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of userrosters</returns>
        List<UserRoster> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new userroster</summary>
        /// <param name="model">The userroster data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UserRoster model);

        /// <summary>Updates a specific userroster by its primary key</summary>
        /// <param name="id">The primary key of the userroster</param>
        /// <param name="updatedEntity">The userroster data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UserRoster updatedEntity);

        /// <summary>Updates a specific userroster by its primary key</summary>
        /// <param name="id">The primary key of the userroster</param>
        /// <param name="updatedEntity">The userroster data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UserRoster> updatedEntity);

        /// <summary>Deletes a specific userroster by its primary key</summary>
        /// <param name="id">The primary key of the userroster</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The userrosterService responsible for managing userroster related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting userroster information.
    /// </remarks>
    public class UserRosterService : IUserRosterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UserRoster class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UserRosterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific userroster by its primary key</summary>
        /// <param name="id">The primary key of the userroster</param>
        /// <returns>The userroster data</returns>
        public UserRoster GetById(Guid id)
        {
            var entityData = _dbContext.UserRoster.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of userrosters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of userrosters</returns>/// <exception cref="Exception"></exception>
        public List<UserRoster> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUserRoster(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new userroster</summary>
        /// <param name="model">The userroster data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UserRoster model)
        {
            model.Id = CreateUserRoster(model);
            return model.Id;
        }

        /// <summary>Updates a specific userroster by its primary key</summary>
        /// <param name="id">The primary key of the userroster</param>
        /// <param name="updatedEntity">The userroster data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UserRoster updatedEntity)
        {
            UpdateUserRoster(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific userroster by its primary key</summary>
        /// <param name="id">The primary key of the userroster</param>
        /// <param name="updatedEntity">The userroster data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UserRoster> updatedEntity)
        {
            PatchUserRoster(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific userroster by its primary key</summary>
        /// <param name="id">The primary key of the userroster</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUserRoster(id);
            return true;
        }
        #region
        private List<UserRoster> GetUserRoster(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UserRoster.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UserRoster>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UserRoster), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UserRoster, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUserRoster(UserRoster model)
        {
            _dbContext.UserRoster.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUserRoster(Guid id, UserRoster updatedEntity)
        {
            _dbContext.UserRoster.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUserRoster(Guid id)
        {
            var entityData = _dbContext.UserRoster.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UserRoster.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUserRoster(Guid id, JsonPatchDocument<UserRoster> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UserRoster.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UserRoster.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}