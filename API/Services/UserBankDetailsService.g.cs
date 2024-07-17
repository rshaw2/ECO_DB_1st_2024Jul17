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
    /// The userbankdetailsService responsible for managing userbankdetails related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting userbankdetails information.
    /// </remarks>
    public interface IUserBankDetailsService
    {
        /// <summary>Retrieves a specific userbankdetails by its primary key</summary>
        /// <param name="id">The primary key of the userbankdetails</param>
        /// <returns>The userbankdetails data</returns>
        UserBankDetails GetById(Guid id);

        /// <summary>Retrieves a list of userbankdetailss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of userbankdetailss</returns>
        List<UserBankDetails> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new userbankdetails</summary>
        /// <param name="model">The userbankdetails data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UserBankDetails model);

        /// <summary>Updates a specific userbankdetails by its primary key</summary>
        /// <param name="id">The primary key of the userbankdetails</param>
        /// <param name="updatedEntity">The userbankdetails data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UserBankDetails updatedEntity);

        /// <summary>Updates a specific userbankdetails by its primary key</summary>
        /// <param name="id">The primary key of the userbankdetails</param>
        /// <param name="updatedEntity">The userbankdetails data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UserBankDetails> updatedEntity);

        /// <summary>Deletes a specific userbankdetails by its primary key</summary>
        /// <param name="id">The primary key of the userbankdetails</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The userbankdetailsService responsible for managing userbankdetails related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting userbankdetails information.
    /// </remarks>
    public class UserBankDetailsService : IUserBankDetailsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UserBankDetails class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UserBankDetailsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific userbankdetails by its primary key</summary>
        /// <param name="id">The primary key of the userbankdetails</param>
        /// <returns>The userbankdetails data</returns>
        public UserBankDetails GetById(Guid id)
        {
            var entityData = _dbContext.UserBankDetails.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of userbankdetailss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of userbankdetailss</returns>/// <exception cref="Exception"></exception>
        public List<UserBankDetails> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUserBankDetails(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new userbankdetails</summary>
        /// <param name="model">The userbankdetails data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UserBankDetails model)
        {
            model.Id = CreateUserBankDetails(model);
            return model.Id;
        }

        /// <summary>Updates a specific userbankdetails by its primary key</summary>
        /// <param name="id">The primary key of the userbankdetails</param>
        /// <param name="updatedEntity">The userbankdetails data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UserBankDetails updatedEntity)
        {
            UpdateUserBankDetails(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific userbankdetails by its primary key</summary>
        /// <param name="id">The primary key of the userbankdetails</param>
        /// <param name="updatedEntity">The userbankdetails data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UserBankDetails> updatedEntity)
        {
            PatchUserBankDetails(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific userbankdetails by its primary key</summary>
        /// <param name="id">The primary key of the userbankdetails</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUserBankDetails(id);
            return true;
        }
        #region
        private List<UserBankDetails> GetUserBankDetails(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UserBankDetails.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UserBankDetails>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UserBankDetails), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UserBankDetails, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUserBankDetails(UserBankDetails model)
        {
            _dbContext.UserBankDetails.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUserBankDetails(Guid id, UserBankDetails updatedEntity)
        {
            _dbContext.UserBankDetails.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUserBankDetails(Guid id)
        {
            var entityData = _dbContext.UserBankDetails.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UserBankDetails.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUserBankDetails(Guid id, JsonPatchDocument<UserBankDetails> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UserBankDetails.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UserBankDetails.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}