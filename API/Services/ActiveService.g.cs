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
    /// The activeService responsible for managing active related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting active information.
    /// </remarks>
    public interface IActiveService
    {
        /// <summary>Retrieves a specific active by its primary key</summary>
        /// <param name="id">The primary key of the active</param>
        /// <returns>The active data</returns>
        Active GetById(Guid id);

        /// <summary>Retrieves a list of actives based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of actives</returns>
        List<Active> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new active</summary>
        /// <param name="model">The active data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Active model);

        /// <summary>Updates a specific active by its primary key</summary>
        /// <param name="id">The primary key of the active</param>
        /// <param name="updatedEntity">The active data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Active updatedEntity);

        /// <summary>Updates a specific active by its primary key</summary>
        /// <param name="id">The primary key of the active</param>
        /// <param name="updatedEntity">The active data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Active> updatedEntity);

        /// <summary>Deletes a specific active by its primary key</summary>
        /// <param name="id">The primary key of the active</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The activeService responsible for managing active related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting active information.
    /// </remarks>
    public class ActiveService : IActiveService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Active class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ActiveService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific active by its primary key</summary>
        /// <param name="id">The primary key of the active</param>
        /// <returns>The active data</returns>
        public Active GetById(Guid id)
        {
            var entityData = _dbContext.Active.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of actives based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of actives</returns>/// <exception cref="Exception"></exception>
        public List<Active> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetActive(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new active</summary>
        /// <param name="model">The active data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Active model)
        {
            model.Id = CreateActive(model);
            return model.Id;
        }

        /// <summary>Updates a specific active by its primary key</summary>
        /// <param name="id">The primary key of the active</param>
        /// <param name="updatedEntity">The active data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Active updatedEntity)
        {
            UpdateActive(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific active by its primary key</summary>
        /// <param name="id">The primary key of the active</param>
        /// <param name="updatedEntity">The active data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Active> updatedEntity)
        {
            PatchActive(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific active by its primary key</summary>
        /// <param name="id">The primary key of the active</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteActive(id);
            return true;
        }
        #region
        private List<Active> GetActive(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Active.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Active>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Active), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Active, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateActive(Active model)
        {
            _dbContext.Active.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateActive(Guid id, Active updatedEntity)
        {
            _dbContext.Active.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteActive(Guid id)
        {
            var entityData = _dbContext.Active.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Active.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchActive(Guid id, JsonPatchDocument<Active> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Active.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Active.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}