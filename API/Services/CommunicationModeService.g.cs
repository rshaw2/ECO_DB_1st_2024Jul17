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
    /// The communicationmodeService responsible for managing communicationmode related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationmode information.
    /// </remarks>
    public interface ICommunicationModeService
    {
        /// <summary>Retrieves a specific communicationmode by its primary key</summary>
        /// <param name="id">The primary key of the communicationmode</param>
        /// <returns>The communicationmode data</returns>
        CommunicationMode GetById(Guid id);

        /// <summary>Retrieves a list of communicationmodes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationmodes</returns>
        List<CommunicationMode> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationmode</summary>
        /// <param name="model">The communicationmode data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationMode model);

        /// <summary>Updates a specific communicationmode by its primary key</summary>
        /// <param name="id">The primary key of the communicationmode</param>
        /// <param name="updatedEntity">The communicationmode data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationMode updatedEntity);

        /// <summary>Updates a specific communicationmode by its primary key</summary>
        /// <param name="id">The primary key of the communicationmode</param>
        /// <param name="updatedEntity">The communicationmode data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationMode> updatedEntity);

        /// <summary>Deletes a specific communicationmode by its primary key</summary>
        /// <param name="id">The primary key of the communicationmode</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationmodeService responsible for managing communicationmode related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationmode information.
    /// </remarks>
    public class CommunicationModeService : ICommunicationModeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationMode class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationModeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationmode by its primary key</summary>
        /// <param name="id">The primary key of the communicationmode</param>
        /// <returns>The communicationmode data</returns>
        public CommunicationMode GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationMode.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationmodes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationmodes</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationMode> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationMode(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationmode</summary>
        /// <param name="model">The communicationmode data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationMode model)
        {
            model.Id = CreateCommunicationMode(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationmode by its primary key</summary>
        /// <param name="id">The primary key of the communicationmode</param>
        /// <param name="updatedEntity">The communicationmode data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationMode updatedEntity)
        {
            UpdateCommunicationMode(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationmode by its primary key</summary>
        /// <param name="id">The primary key of the communicationmode</param>
        /// <param name="updatedEntity">The communicationmode data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationMode> updatedEntity)
        {
            PatchCommunicationMode(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationmode by its primary key</summary>
        /// <param name="id">The primary key of the communicationmode</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationMode(id);
            return true;
        }
        #region
        private List<CommunicationMode> GetCommunicationMode(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationMode.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationMode>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationMode), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationMode, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationMode(CommunicationMode model)
        {
            _dbContext.CommunicationMode.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationMode(Guid id, CommunicationMode updatedEntity)
        {
            _dbContext.CommunicationMode.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationMode(Guid id)
        {
            var entityData = _dbContext.CommunicationMode.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationMode.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationMode(Guid id, JsonPatchDocument<CommunicationMode> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationMode.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationMode.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}