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
    /// The aiprocessService responsible for managing aiprocess related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting aiprocess information.
    /// </remarks>
    public interface IAiProcessService
    {
        /// <summary>Retrieves a specific aiprocess by its primary key</summary>
        /// <param name="id">The primary key of the aiprocess</param>
        /// <returns>The aiprocess data</returns>
        AiProcess GetById(Guid id);

        /// <summary>Retrieves a list of aiprocesss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aiprocesss</returns>
        List<AiProcess> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new aiprocess</summary>
        /// <param name="model">The aiprocess data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AiProcess model);

        /// <summary>Updates a specific aiprocess by its primary key</summary>
        /// <param name="id">The primary key of the aiprocess</param>
        /// <param name="updatedEntity">The aiprocess data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AiProcess updatedEntity);

        /// <summary>Updates a specific aiprocess by its primary key</summary>
        /// <param name="id">The primary key of the aiprocess</param>
        /// <param name="updatedEntity">The aiprocess data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AiProcess> updatedEntity);

        /// <summary>Deletes a specific aiprocess by its primary key</summary>
        /// <param name="id">The primary key of the aiprocess</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The aiprocessService responsible for managing aiprocess related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting aiprocess information.
    /// </remarks>
    public class AiProcessService : IAiProcessService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AiProcess class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AiProcessService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific aiprocess by its primary key</summary>
        /// <param name="id">The primary key of the aiprocess</param>
        /// <returns>The aiprocess data</returns>
        public AiProcess GetById(Guid id)
        {
            var entityData = _dbContext.AiProcess.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of aiprocesss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aiprocesss</returns>/// <exception cref="Exception"></exception>
        public List<AiProcess> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAiProcess(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new aiprocess</summary>
        /// <param name="model">The aiprocess data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AiProcess model)
        {
            model.Id = CreateAiProcess(model);
            return model.Id;
        }

        /// <summary>Updates a specific aiprocess by its primary key</summary>
        /// <param name="id">The primary key of the aiprocess</param>
        /// <param name="updatedEntity">The aiprocess data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AiProcess updatedEntity)
        {
            UpdateAiProcess(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific aiprocess by its primary key</summary>
        /// <param name="id">The primary key of the aiprocess</param>
        /// <param name="updatedEntity">The aiprocess data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AiProcess> updatedEntity)
        {
            PatchAiProcess(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific aiprocess by its primary key</summary>
        /// <param name="id">The primary key of the aiprocess</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAiProcess(id);
            return true;
        }
        #region
        private List<AiProcess> GetAiProcess(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AiProcess.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AiProcess>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AiProcess), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AiProcess, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAiProcess(AiProcess model)
        {
            _dbContext.AiProcess.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAiProcess(Guid id, AiProcess updatedEntity)
        {
            _dbContext.AiProcess.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAiProcess(Guid id)
        {
            var entityData = _dbContext.AiProcess.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AiProcess.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAiProcess(Guid id, JsonPatchDocument<AiProcess> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AiProcess.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AiProcess.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}