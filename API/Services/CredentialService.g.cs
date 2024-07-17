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
    /// The credentialService responsible for managing credential related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting credential information.
    /// </remarks>
    public interface ICredentialService
    {
        /// <summary>Retrieves a specific credential by its primary key</summary>
        /// <param name="id">The primary key of the credential</param>
        /// <returns>The credential data</returns>
        Credential GetById(Guid id);

        /// <summary>Retrieves a list of credentials based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of credentials</returns>
        List<Credential> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new credential</summary>
        /// <param name="model">The credential data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Credential model);

        /// <summary>Updates a specific credential by its primary key</summary>
        /// <param name="id">The primary key of the credential</param>
        /// <param name="updatedEntity">The credential data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Credential updatedEntity);

        /// <summary>Updates a specific credential by its primary key</summary>
        /// <param name="id">The primary key of the credential</param>
        /// <param name="updatedEntity">The credential data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Credential> updatedEntity);

        /// <summary>Deletes a specific credential by its primary key</summary>
        /// <param name="id">The primary key of the credential</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The credentialService responsible for managing credential related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting credential information.
    /// </remarks>
    public class CredentialService : ICredentialService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Credential class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CredentialService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific credential by its primary key</summary>
        /// <param name="id">The primary key of the credential</param>
        /// <returns>The credential data</returns>
        public Credential GetById(Guid id)
        {
            var entityData = _dbContext.Credential.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of credentials based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of credentials</returns>/// <exception cref="Exception"></exception>
        public List<Credential> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCredential(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new credential</summary>
        /// <param name="model">The credential data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Credential model)
        {
            model.Id = CreateCredential(model);
            return model.Id;
        }

        /// <summary>Updates a specific credential by its primary key</summary>
        /// <param name="id">The primary key of the credential</param>
        /// <param name="updatedEntity">The credential data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Credential updatedEntity)
        {
            UpdateCredential(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific credential by its primary key</summary>
        /// <param name="id">The primary key of the credential</param>
        /// <param name="updatedEntity">The credential data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Credential> updatedEntity)
        {
            PatchCredential(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific credential by its primary key</summary>
        /// <param name="id">The primary key of the credential</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCredential(id);
            return true;
        }
        #region
        private List<Credential> GetCredential(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Credential.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Credential>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Credential), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Credential, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCredential(Credential model)
        {
            _dbContext.Credential.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCredential(Guid id, Credential updatedEntity)
        {
            _dbContext.Credential.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCredential(Guid id)
        {
            var entityData = _dbContext.Credential.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Credential.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCredential(Guid id, JsonPatchDocument<Credential> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Credential.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Credential.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}