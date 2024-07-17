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
    /// The loginhistoryService responsible for managing loginhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting loginhistory information.
    /// </remarks>
    public interface ILoginHistoryService
    {
        /// <summary>Retrieves a specific loginhistory by its primary key</summary>
        /// <param name="id">The primary key of the loginhistory</param>
        /// <returns>The loginhistory data</returns>
        LoginHistory GetById(Guid id);

        /// <summary>Retrieves a list of loginhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of loginhistorys</returns>
        List<LoginHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new loginhistory</summary>
        /// <param name="model">The loginhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(LoginHistory model);

        /// <summary>Updates a specific loginhistory by its primary key</summary>
        /// <param name="id">The primary key of the loginhistory</param>
        /// <param name="updatedEntity">The loginhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, LoginHistory updatedEntity);

        /// <summary>Updates a specific loginhistory by its primary key</summary>
        /// <param name="id">The primary key of the loginhistory</param>
        /// <param name="updatedEntity">The loginhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<LoginHistory> updatedEntity);

        /// <summary>Deletes a specific loginhistory by its primary key</summary>
        /// <param name="id">The primary key of the loginhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The loginhistoryService responsible for managing loginhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting loginhistory information.
    /// </remarks>
    public class LoginHistoryService : ILoginHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the LoginHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public LoginHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific loginhistory by its primary key</summary>
        /// <param name="id">The primary key of the loginhistory</param>
        /// <returns>The loginhistory data</returns>
        public LoginHistory GetById(Guid id)
        {
            var entityData = _dbContext.LoginHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of loginhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of loginhistorys</returns>/// <exception cref="Exception"></exception>
        public List<LoginHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetLoginHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new loginhistory</summary>
        /// <param name="model">The loginhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(LoginHistory model)
        {
            model.Id = CreateLoginHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific loginhistory by its primary key</summary>
        /// <param name="id">The primary key of the loginhistory</param>
        /// <param name="updatedEntity">The loginhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, LoginHistory updatedEntity)
        {
            UpdateLoginHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific loginhistory by its primary key</summary>
        /// <param name="id">The primary key of the loginhistory</param>
        /// <param name="updatedEntity">The loginhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<LoginHistory> updatedEntity)
        {
            PatchLoginHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific loginhistory by its primary key</summary>
        /// <param name="id">The primary key of the loginhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteLoginHistory(id);
            return true;
        }
        #region
        private List<LoginHistory> GetLoginHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LoginHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LoginHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LoginHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LoginHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateLoginHistory(LoginHistory model)
        {
            _dbContext.LoginHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateLoginHistory(Guid id, LoginHistory updatedEntity)
        {
            _dbContext.LoginHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteLoginHistory(Guid id)
        {
            var entityData = _dbContext.LoginHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LoginHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchLoginHistory(Guid id, JsonPatchDocument<LoginHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LoginHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LoginHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}