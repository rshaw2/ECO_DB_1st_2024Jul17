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
    /// The integrationusertokenService responsible for managing integrationusertoken related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting integrationusertoken information.
    /// </remarks>
    public interface IIntegrationUserTokenService
    {
        /// <summary>Retrieves a specific integrationusertoken by its primary key</summary>
        /// <param name="id">The primary key of the integrationusertoken</param>
        /// <returns>The integrationusertoken data</returns>
        IntegrationUserToken GetById(Guid id);

        /// <summary>Retrieves a list of integrationusertokens based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of integrationusertokens</returns>
        List<IntegrationUserToken> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new integrationusertoken</summary>
        /// <param name="model">The integrationusertoken data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(IntegrationUserToken model);

        /// <summary>Updates a specific integrationusertoken by its primary key</summary>
        /// <param name="id">The primary key of the integrationusertoken</param>
        /// <param name="updatedEntity">The integrationusertoken data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, IntegrationUserToken updatedEntity);

        /// <summary>Updates a specific integrationusertoken by its primary key</summary>
        /// <param name="id">The primary key of the integrationusertoken</param>
        /// <param name="updatedEntity">The integrationusertoken data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<IntegrationUserToken> updatedEntity);

        /// <summary>Deletes a specific integrationusertoken by its primary key</summary>
        /// <param name="id">The primary key of the integrationusertoken</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The integrationusertokenService responsible for managing integrationusertoken related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting integrationusertoken information.
    /// </remarks>
    public class IntegrationUserTokenService : IIntegrationUserTokenService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the IntegrationUserToken class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public IntegrationUserTokenService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific integrationusertoken by its primary key</summary>
        /// <param name="id">The primary key of the integrationusertoken</param>
        /// <returns>The integrationusertoken data</returns>
        public IntegrationUserToken GetById(Guid id)
        {
            var entityData = _dbContext.IntegrationUserToken.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of integrationusertokens based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of integrationusertokens</returns>/// <exception cref="Exception"></exception>
        public List<IntegrationUserToken> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetIntegrationUserToken(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new integrationusertoken</summary>
        /// <param name="model">The integrationusertoken data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(IntegrationUserToken model)
        {
            model.Id = CreateIntegrationUserToken(model);
            return model.Id;
        }

        /// <summary>Updates a specific integrationusertoken by its primary key</summary>
        /// <param name="id">The primary key of the integrationusertoken</param>
        /// <param name="updatedEntity">The integrationusertoken data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, IntegrationUserToken updatedEntity)
        {
            UpdateIntegrationUserToken(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific integrationusertoken by its primary key</summary>
        /// <param name="id">The primary key of the integrationusertoken</param>
        /// <param name="updatedEntity">The integrationusertoken data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<IntegrationUserToken> updatedEntity)
        {
            PatchIntegrationUserToken(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific integrationusertoken by its primary key</summary>
        /// <param name="id">The primary key of the integrationusertoken</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteIntegrationUserToken(id);
            return true;
        }
        #region
        private List<IntegrationUserToken> GetIntegrationUserToken(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.IntegrationUserToken.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<IntegrationUserToken>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(IntegrationUserToken), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<IntegrationUserToken, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateIntegrationUserToken(IntegrationUserToken model)
        {
            _dbContext.IntegrationUserToken.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateIntegrationUserToken(Guid id, IntegrationUserToken updatedEntity)
        {
            _dbContext.IntegrationUserToken.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteIntegrationUserToken(Guid id)
        {
            var entityData = _dbContext.IntegrationUserToken.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.IntegrationUserToken.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchIntegrationUserToken(Guid id, JsonPatchDocument<IntegrationUserToken> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.IntegrationUserToken.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.IntegrationUserToken.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}