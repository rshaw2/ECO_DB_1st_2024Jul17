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
    /// The communicationverificationService responsible for managing communicationverification related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationverification information.
    /// </remarks>
    public interface ICommunicationVerificationService
    {
        /// <summary>Retrieves a specific communicationverification by its primary key</summary>
        /// <param name="id">The primary key of the communicationverification</param>
        /// <returns>The communicationverification data</returns>
        CommunicationVerification GetById(Guid id);

        /// <summary>Retrieves a list of communicationverifications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationverifications</returns>
        List<CommunicationVerification> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationverification</summary>
        /// <param name="model">The communicationverification data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationVerification model);

        /// <summary>Updates a specific communicationverification by its primary key</summary>
        /// <param name="id">The primary key of the communicationverification</param>
        /// <param name="updatedEntity">The communicationverification data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationVerification updatedEntity);

        /// <summary>Updates a specific communicationverification by its primary key</summary>
        /// <param name="id">The primary key of the communicationverification</param>
        /// <param name="updatedEntity">The communicationverification data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationVerification> updatedEntity);

        /// <summary>Deletes a specific communicationverification by its primary key</summary>
        /// <param name="id">The primary key of the communicationverification</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationverificationService responsible for managing communicationverification related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationverification information.
    /// </remarks>
    public class CommunicationVerificationService : ICommunicationVerificationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationVerification class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationVerificationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationverification by its primary key</summary>
        /// <param name="id">The primary key of the communicationverification</param>
        /// <returns>The communicationverification data</returns>
        public CommunicationVerification GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationVerification.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationverifications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationverifications</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationVerification> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationVerification(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationverification</summary>
        /// <param name="model">The communicationverification data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationVerification model)
        {
            model.Id = CreateCommunicationVerification(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationverification by its primary key</summary>
        /// <param name="id">The primary key of the communicationverification</param>
        /// <param name="updatedEntity">The communicationverification data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationVerification updatedEntity)
        {
            UpdateCommunicationVerification(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationverification by its primary key</summary>
        /// <param name="id">The primary key of the communicationverification</param>
        /// <param name="updatedEntity">The communicationverification data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationVerification> updatedEntity)
        {
            PatchCommunicationVerification(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationverification by its primary key</summary>
        /// <param name="id">The primary key of the communicationverification</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationVerification(id);
            return true;
        }
        #region
        private List<CommunicationVerification> GetCommunicationVerification(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationVerification.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationVerification>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationVerification), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationVerification, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationVerification(CommunicationVerification model)
        {
            _dbContext.CommunicationVerification.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationVerification(Guid id, CommunicationVerification updatedEntity)
        {
            _dbContext.CommunicationVerification.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationVerification(Guid id)
        {
            var entityData = _dbContext.CommunicationVerification.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationVerification.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationVerification(Guid id, JsonPatchDocument<CommunicationVerification> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationVerification.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationVerification.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}