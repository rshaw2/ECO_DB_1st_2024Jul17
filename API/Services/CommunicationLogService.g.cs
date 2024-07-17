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
    /// The communicationlogService responsible for managing communicationlog related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationlog information.
    /// </remarks>
    public interface ICommunicationLogService
    {
        /// <summary>Retrieves a specific communicationlog by its primary key</summary>
        /// <param name="id">The primary key of the communicationlog</param>
        /// <returns>The communicationlog data</returns>
        CommunicationLog GetById(Guid id);

        /// <summary>Retrieves a list of communicationlogs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationlogs</returns>
        List<CommunicationLog> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationlog</summary>
        /// <param name="model">The communicationlog data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationLog model);

        /// <summary>Updates a specific communicationlog by its primary key</summary>
        /// <param name="id">The primary key of the communicationlog</param>
        /// <param name="updatedEntity">The communicationlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationLog updatedEntity);

        /// <summary>Updates a specific communicationlog by its primary key</summary>
        /// <param name="id">The primary key of the communicationlog</param>
        /// <param name="updatedEntity">The communicationlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationLog> updatedEntity);

        /// <summary>Deletes a specific communicationlog by its primary key</summary>
        /// <param name="id">The primary key of the communicationlog</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationlogService responsible for managing communicationlog related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationlog information.
    /// </remarks>
    public class CommunicationLogService : ICommunicationLogService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationLog class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationLogService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationlog by its primary key</summary>
        /// <param name="id">The primary key of the communicationlog</param>
        /// <returns>The communicationlog data</returns>
        public CommunicationLog GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationLog.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationlogs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationlogs</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationLog> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationLog(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationlog</summary>
        /// <param name="model">The communicationlog data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationLog model)
        {
            model.Id = CreateCommunicationLog(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationlog by its primary key</summary>
        /// <param name="id">The primary key of the communicationlog</param>
        /// <param name="updatedEntity">The communicationlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationLog updatedEntity)
        {
            UpdateCommunicationLog(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationlog by its primary key</summary>
        /// <param name="id">The primary key of the communicationlog</param>
        /// <param name="updatedEntity">The communicationlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationLog> updatedEntity)
        {
            PatchCommunicationLog(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationlog by its primary key</summary>
        /// <param name="id">The primary key of the communicationlog</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationLog(id);
            return true;
        }
        #region
        private List<CommunicationLog> GetCommunicationLog(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationLog.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationLog>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationLog), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationLog, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationLog(CommunicationLog model)
        {
            _dbContext.CommunicationLog.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationLog(Guid id, CommunicationLog updatedEntity)
        {
            _dbContext.CommunicationLog.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationLog(Guid id)
        {
            var entityData = _dbContext.CommunicationLog.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationLog.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationLog(Guid id, JsonPatchDocument<CommunicationLog> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationLog.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationLog.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}