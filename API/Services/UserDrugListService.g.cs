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
    /// The userdruglistService responsible for managing userdruglist related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting userdruglist information.
    /// </remarks>
    public interface IUserDrugListService
    {
        /// <summary>Retrieves a specific userdruglist by its primary key</summary>
        /// <param name="id">The primary key of the userdruglist</param>
        /// <returns>The userdruglist data</returns>
        UserDrugList GetById(Guid id);

        /// <summary>Retrieves a list of userdruglists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of userdruglists</returns>
        List<UserDrugList> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new userdruglist</summary>
        /// <param name="model">The userdruglist data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UserDrugList model);

        /// <summary>Updates a specific userdruglist by its primary key</summary>
        /// <param name="id">The primary key of the userdruglist</param>
        /// <param name="updatedEntity">The userdruglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UserDrugList updatedEntity);

        /// <summary>Updates a specific userdruglist by its primary key</summary>
        /// <param name="id">The primary key of the userdruglist</param>
        /// <param name="updatedEntity">The userdruglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UserDrugList> updatedEntity);

        /// <summary>Deletes a specific userdruglist by its primary key</summary>
        /// <param name="id">The primary key of the userdruglist</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The userdruglistService responsible for managing userdruglist related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting userdruglist information.
    /// </remarks>
    public class UserDrugListService : IUserDrugListService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UserDrugList class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UserDrugListService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific userdruglist by its primary key</summary>
        /// <param name="id">The primary key of the userdruglist</param>
        /// <returns>The userdruglist data</returns>
        public UserDrugList GetById(Guid id)
        {
            var entityData = _dbContext.UserDrugList.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of userdruglists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of userdruglists</returns>/// <exception cref="Exception"></exception>
        public List<UserDrugList> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUserDrugList(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new userdruglist</summary>
        /// <param name="model">The userdruglist data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UserDrugList model)
        {
            model.Id = CreateUserDrugList(model);
            return model.Id;
        }

        /// <summary>Updates a specific userdruglist by its primary key</summary>
        /// <param name="id">The primary key of the userdruglist</param>
        /// <param name="updatedEntity">The userdruglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UserDrugList updatedEntity)
        {
            UpdateUserDrugList(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific userdruglist by its primary key</summary>
        /// <param name="id">The primary key of the userdruglist</param>
        /// <param name="updatedEntity">The userdruglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UserDrugList> updatedEntity)
        {
            PatchUserDrugList(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific userdruglist by its primary key</summary>
        /// <param name="id">The primary key of the userdruglist</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUserDrugList(id);
            return true;
        }
        #region
        private List<UserDrugList> GetUserDrugList(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UserDrugList.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UserDrugList>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UserDrugList), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UserDrugList, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUserDrugList(UserDrugList model)
        {
            _dbContext.UserDrugList.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUserDrugList(Guid id, UserDrugList updatedEntity)
        {
            _dbContext.UserDrugList.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUserDrugList(Guid id)
        {
            var entityData = _dbContext.UserDrugList.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UserDrugList.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUserDrugList(Guid id, JsonPatchDocument<UserDrugList> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UserDrugList.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UserDrugList.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}