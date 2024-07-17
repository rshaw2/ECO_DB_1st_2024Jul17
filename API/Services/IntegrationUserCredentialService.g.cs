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
    /// The integrationusercredentialService responsible for managing integrationusercredential related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting integrationusercredential information.
    /// </remarks>
    public interface IIntegrationUserCredentialService
    {
        /// <summary>Retrieves a specific integrationusercredential by its primary key</summary>
        /// <param name="id">The primary key of the integrationusercredential</param>
        /// <returns>The integrationusercredential data</returns>
        IntegrationUserCredential GetById(Guid id);

        /// <summary>Retrieves a list of integrationusercredentials based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of integrationusercredentials</returns>
        List<IntegrationUserCredential> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new integrationusercredential</summary>
        /// <param name="model">The integrationusercredential data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(IntegrationUserCredential model);

        /// <summary>Updates a specific integrationusercredential by its primary key</summary>
        /// <param name="id">The primary key of the integrationusercredential</param>
        /// <param name="updatedEntity">The integrationusercredential data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, IntegrationUserCredential updatedEntity);

        /// <summary>Updates a specific integrationusercredential by its primary key</summary>
        /// <param name="id">The primary key of the integrationusercredential</param>
        /// <param name="updatedEntity">The integrationusercredential data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<IntegrationUserCredential> updatedEntity);

        /// <summary>Deletes a specific integrationusercredential by its primary key</summary>
        /// <param name="id">The primary key of the integrationusercredential</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The integrationusercredentialService responsible for managing integrationusercredential related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting integrationusercredential information.
    /// </remarks>
    public class IntegrationUserCredentialService : IIntegrationUserCredentialService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the IntegrationUserCredential class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public IntegrationUserCredentialService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific integrationusercredential by its primary key</summary>
        /// <param name="id">The primary key of the integrationusercredential</param>
        /// <returns>The integrationusercredential data</returns>
        public IntegrationUserCredential GetById(Guid id)
        {
            var entityData = _dbContext.IntegrationUserCredential.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of integrationusercredentials based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of integrationusercredentials</returns>/// <exception cref="Exception"></exception>
        public List<IntegrationUserCredential> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetIntegrationUserCredential(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new integrationusercredential</summary>
        /// <param name="model">The integrationusercredential data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(IntegrationUserCredential model)
        {
            model.Id = CreateIntegrationUserCredential(model);
            return model.Id;
        }

        /// <summary>Updates a specific integrationusercredential by its primary key</summary>
        /// <param name="id">The primary key of the integrationusercredential</param>
        /// <param name="updatedEntity">The integrationusercredential data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, IntegrationUserCredential updatedEntity)
        {
            UpdateIntegrationUserCredential(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific integrationusercredential by its primary key</summary>
        /// <param name="id">The primary key of the integrationusercredential</param>
        /// <param name="updatedEntity">The integrationusercredential data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<IntegrationUserCredential> updatedEntity)
        {
            PatchIntegrationUserCredential(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific integrationusercredential by its primary key</summary>
        /// <param name="id">The primary key of the integrationusercredential</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteIntegrationUserCredential(id);
            return true;
        }
        #region
        private List<IntegrationUserCredential> GetIntegrationUserCredential(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.IntegrationUserCredential.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<IntegrationUserCredential>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(IntegrationUserCredential), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<IntegrationUserCredential, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateIntegrationUserCredential(IntegrationUserCredential model)
        {
            _dbContext.IntegrationUserCredential.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateIntegrationUserCredential(Guid id, IntegrationUserCredential updatedEntity)
        {
            _dbContext.IntegrationUserCredential.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteIntegrationUserCredential(Guid id)
        {
            var entityData = _dbContext.IntegrationUserCredential.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.IntegrationUserCredential.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchIntegrationUserCredential(Guid id, JsonPatchDocument<IntegrationUserCredential> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.IntegrationUserCredential.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.IntegrationUserCredential.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}