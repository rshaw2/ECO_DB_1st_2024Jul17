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
    /// The credentialhistoryService responsible for managing credentialhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting credentialhistory information.
    /// </remarks>
    public interface ICredentialHistoryService
    {
        /// <summary>Retrieves a specific credentialhistory by its primary key</summary>
        /// <param name="id">The primary key of the credentialhistory</param>
        /// <returns>The credentialhistory data</returns>
        CredentialHistory GetById(Guid id);

        /// <summary>Retrieves a list of credentialhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of credentialhistorys</returns>
        List<CredentialHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new credentialhistory</summary>
        /// <param name="model">The credentialhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CredentialHistory model);

        /// <summary>Updates a specific credentialhistory by its primary key</summary>
        /// <param name="id">The primary key of the credentialhistory</param>
        /// <param name="updatedEntity">The credentialhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CredentialHistory updatedEntity);

        /// <summary>Updates a specific credentialhistory by its primary key</summary>
        /// <param name="id">The primary key of the credentialhistory</param>
        /// <param name="updatedEntity">The credentialhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CredentialHistory> updatedEntity);

        /// <summary>Deletes a specific credentialhistory by its primary key</summary>
        /// <param name="id">The primary key of the credentialhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The credentialhistoryService responsible for managing credentialhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting credentialhistory information.
    /// </remarks>
    public class CredentialHistoryService : ICredentialHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CredentialHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CredentialHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific credentialhistory by its primary key</summary>
        /// <param name="id">The primary key of the credentialhistory</param>
        /// <returns>The credentialhistory data</returns>
        public CredentialHistory GetById(Guid id)
        {
            var entityData = _dbContext.CredentialHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of credentialhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of credentialhistorys</returns>/// <exception cref="Exception"></exception>
        public List<CredentialHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCredentialHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new credentialhistory</summary>
        /// <param name="model">The credentialhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CredentialHistory model)
        {
            model.Id = CreateCredentialHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific credentialhistory by its primary key</summary>
        /// <param name="id">The primary key of the credentialhistory</param>
        /// <param name="updatedEntity">The credentialhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CredentialHistory updatedEntity)
        {
            UpdateCredentialHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific credentialhistory by its primary key</summary>
        /// <param name="id">The primary key of the credentialhistory</param>
        /// <param name="updatedEntity">The credentialhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CredentialHistory> updatedEntity)
        {
            PatchCredentialHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific credentialhistory by its primary key</summary>
        /// <param name="id">The primary key of the credentialhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCredentialHistory(id);
            return true;
        }
        #region
        private List<CredentialHistory> GetCredentialHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CredentialHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CredentialHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CredentialHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CredentialHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCredentialHistory(CredentialHistory model)
        {
            _dbContext.CredentialHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCredentialHistory(Guid id, CredentialHistory updatedEntity)
        {
            _dbContext.CredentialHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCredentialHistory(Guid id)
        {
            var entityData = _dbContext.CredentialHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CredentialHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCredentialHistory(Guid id, JsonPatchDocument<CredentialHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CredentialHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CredentialHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}