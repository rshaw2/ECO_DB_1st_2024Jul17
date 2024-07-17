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
    /// The entityfieldauthorizationService responsible for managing entityfieldauthorization related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting entityfieldauthorization information.
    /// </remarks>
    public interface IEntityFieldAuthorizationService
    {
        /// <summary>Retrieves a specific entityfieldauthorization by its primary key</summary>
        /// <param name="id">The primary key of the entityfieldauthorization</param>
        /// <returns>The entityfieldauthorization data</returns>
        EntityFieldAuthorization GetById(Guid id);

        /// <summary>Retrieves a list of entityfieldauthorizations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entityfieldauthorizations</returns>
        List<EntityFieldAuthorization> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new entityfieldauthorization</summary>
        /// <param name="model">The entityfieldauthorization data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(EntityFieldAuthorization model);

        /// <summary>Updates a specific entityfieldauthorization by its primary key</summary>
        /// <param name="id">The primary key of the entityfieldauthorization</param>
        /// <param name="updatedEntity">The entityfieldauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, EntityFieldAuthorization updatedEntity);

        /// <summary>Updates a specific entityfieldauthorization by its primary key</summary>
        /// <param name="id">The primary key of the entityfieldauthorization</param>
        /// <param name="updatedEntity">The entityfieldauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<EntityFieldAuthorization> updatedEntity);

        /// <summary>Deletes a specific entityfieldauthorization by its primary key</summary>
        /// <param name="id">The primary key of the entityfieldauthorization</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The entityfieldauthorizationService responsible for managing entityfieldauthorization related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting entityfieldauthorization information.
    /// </remarks>
    public class EntityFieldAuthorizationService : IEntityFieldAuthorizationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the EntityFieldAuthorization class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public EntityFieldAuthorizationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific entityfieldauthorization by its primary key</summary>
        /// <param name="id">The primary key of the entityfieldauthorization</param>
        /// <returns>The entityfieldauthorization data</returns>
        public EntityFieldAuthorization GetById(Guid id)
        {
            var entityData = _dbContext.EntityFieldAuthorization.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of entityfieldauthorizations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entityfieldauthorizations</returns>/// <exception cref="Exception"></exception>
        public List<EntityFieldAuthorization> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetEntityFieldAuthorization(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new entityfieldauthorization</summary>
        /// <param name="model">The entityfieldauthorization data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(EntityFieldAuthorization model)
        {
            model.Id = CreateEntityFieldAuthorization(model);
            return model.Id;
        }

        /// <summary>Updates a specific entityfieldauthorization by its primary key</summary>
        /// <param name="id">The primary key of the entityfieldauthorization</param>
        /// <param name="updatedEntity">The entityfieldauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, EntityFieldAuthorization updatedEntity)
        {
            UpdateEntityFieldAuthorization(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific entityfieldauthorization by its primary key</summary>
        /// <param name="id">The primary key of the entityfieldauthorization</param>
        /// <param name="updatedEntity">The entityfieldauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<EntityFieldAuthorization> updatedEntity)
        {
            PatchEntityFieldAuthorization(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific entityfieldauthorization by its primary key</summary>
        /// <param name="id">The primary key of the entityfieldauthorization</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteEntityFieldAuthorization(id);
            return true;
        }
        #region
        private List<EntityFieldAuthorization> GetEntityFieldAuthorization(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EntityFieldAuthorization.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EntityFieldAuthorization>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EntityFieldAuthorization), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EntityFieldAuthorization, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateEntityFieldAuthorization(EntityFieldAuthorization model)
        {
            _dbContext.EntityFieldAuthorization.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateEntityFieldAuthorization(Guid id, EntityFieldAuthorization updatedEntity)
        {
            _dbContext.EntityFieldAuthorization.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteEntityFieldAuthorization(Guid id)
        {
            var entityData = _dbContext.EntityFieldAuthorization.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EntityFieldAuthorization.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchEntityFieldAuthorization(Guid id, JsonPatchDocument<EntityFieldAuthorization> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EntityFieldAuthorization.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EntityFieldAuthorization.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}