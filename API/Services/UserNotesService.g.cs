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
    /// The usernotesService responsible for managing usernotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting usernotes information.
    /// </remarks>
    public interface IUserNotesService
    {
        /// <summary>Retrieves a specific usernotes by its primary key</summary>
        /// <param name="id">The primary key of the usernotes</param>
        /// <returns>The usernotes data</returns>
        UserNotes GetById(Guid id);

        /// <summary>Retrieves a list of usernotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of usernotess</returns>
        List<UserNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new usernotes</summary>
        /// <param name="model">The usernotes data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UserNotes model);

        /// <summary>Updates a specific usernotes by its primary key</summary>
        /// <param name="id">The primary key of the usernotes</param>
        /// <param name="updatedEntity">The usernotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UserNotes updatedEntity);

        /// <summary>Updates a specific usernotes by its primary key</summary>
        /// <param name="id">The primary key of the usernotes</param>
        /// <param name="updatedEntity">The usernotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UserNotes> updatedEntity);

        /// <summary>Deletes a specific usernotes by its primary key</summary>
        /// <param name="id">The primary key of the usernotes</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The usernotesService responsible for managing usernotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting usernotes information.
    /// </remarks>
    public class UserNotesService : IUserNotesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UserNotes class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UserNotesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific usernotes by its primary key</summary>
        /// <param name="id">The primary key of the usernotes</param>
        /// <returns>The usernotes data</returns>
        public UserNotes GetById(Guid id)
        {
            var entityData = _dbContext.UserNotes.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of usernotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of usernotess</returns>/// <exception cref="Exception"></exception>
        public List<UserNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUserNotes(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new usernotes</summary>
        /// <param name="model">The usernotes data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UserNotes model)
        {
            model.Id = CreateUserNotes(model);
            return model.Id;
        }

        /// <summary>Updates a specific usernotes by its primary key</summary>
        /// <param name="id">The primary key of the usernotes</param>
        /// <param name="updatedEntity">The usernotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UserNotes updatedEntity)
        {
            UpdateUserNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific usernotes by its primary key</summary>
        /// <param name="id">The primary key of the usernotes</param>
        /// <param name="updatedEntity">The usernotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UserNotes> updatedEntity)
        {
            PatchUserNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific usernotes by its primary key</summary>
        /// <param name="id">The primary key of the usernotes</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUserNotes(id);
            return true;
        }
        #region
        private List<UserNotes> GetUserNotes(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UserNotes.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UserNotes>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UserNotes), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UserNotes, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUserNotes(UserNotes model)
        {
            _dbContext.UserNotes.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUserNotes(Guid id, UserNotes updatedEntity)
        {
            _dbContext.UserNotes.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUserNotes(Guid id)
        {
            var entityData = _dbContext.UserNotes.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UserNotes.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUserNotes(Guid id, JsonPatchDocument<UserNotes> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UserNotes.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UserNotes.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}