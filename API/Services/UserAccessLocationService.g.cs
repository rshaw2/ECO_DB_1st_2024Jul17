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
    /// The useraccesslocationService responsible for managing useraccesslocation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting useraccesslocation information.
    /// </remarks>
    public interface IUserAccessLocationService
    {
        /// <summary>Retrieves a specific useraccesslocation by its primary key</summary>
        /// <param name="id">The primary key of the useraccesslocation</param>
        /// <returns>The useraccesslocation data</returns>
        UserAccessLocation GetById(Guid id);

        /// <summary>Retrieves a list of useraccesslocations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of useraccesslocations</returns>
        List<UserAccessLocation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new useraccesslocation</summary>
        /// <param name="model">The useraccesslocation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UserAccessLocation model);

        /// <summary>Updates a specific useraccesslocation by its primary key</summary>
        /// <param name="id">The primary key of the useraccesslocation</param>
        /// <param name="updatedEntity">The useraccesslocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UserAccessLocation updatedEntity);

        /// <summary>Updates a specific useraccesslocation by its primary key</summary>
        /// <param name="id">The primary key of the useraccesslocation</param>
        /// <param name="updatedEntity">The useraccesslocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UserAccessLocation> updatedEntity);

        /// <summary>Deletes a specific useraccesslocation by its primary key</summary>
        /// <param name="id">The primary key of the useraccesslocation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The useraccesslocationService responsible for managing useraccesslocation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting useraccesslocation information.
    /// </remarks>
    public class UserAccessLocationService : IUserAccessLocationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UserAccessLocation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UserAccessLocationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific useraccesslocation by its primary key</summary>
        /// <param name="id">The primary key of the useraccesslocation</param>
        /// <returns>The useraccesslocation data</returns>
        public UserAccessLocation GetById(Guid id)
        {
            var entityData = _dbContext.UserAccessLocation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of useraccesslocations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of useraccesslocations</returns>/// <exception cref="Exception"></exception>
        public List<UserAccessLocation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUserAccessLocation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new useraccesslocation</summary>
        /// <param name="model">The useraccesslocation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UserAccessLocation model)
        {
            model.Id = CreateUserAccessLocation(model);
            return model.Id;
        }

        /// <summary>Updates a specific useraccesslocation by its primary key</summary>
        /// <param name="id">The primary key of the useraccesslocation</param>
        /// <param name="updatedEntity">The useraccesslocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UserAccessLocation updatedEntity)
        {
            UpdateUserAccessLocation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific useraccesslocation by its primary key</summary>
        /// <param name="id">The primary key of the useraccesslocation</param>
        /// <param name="updatedEntity">The useraccesslocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UserAccessLocation> updatedEntity)
        {
            PatchUserAccessLocation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific useraccesslocation by its primary key</summary>
        /// <param name="id">The primary key of the useraccesslocation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUserAccessLocation(id);
            return true;
        }
        #region
        private List<UserAccessLocation> GetUserAccessLocation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UserAccessLocation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UserAccessLocation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UserAccessLocation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UserAccessLocation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUserAccessLocation(UserAccessLocation model)
        {
            _dbContext.UserAccessLocation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUserAccessLocation(Guid id, UserAccessLocation updatedEntity)
        {
            _dbContext.UserAccessLocation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUserAccessLocation(Guid id)
        {
            var entityData = _dbContext.UserAccessLocation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UserAccessLocation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUserAccessLocation(Guid id, JsonPatchDocument<UserAccessLocation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UserAccessLocation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UserAccessLocation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}