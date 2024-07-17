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
    /// The entityoperationService responsible for managing entityoperation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting entityoperation information.
    /// </remarks>
    public interface IEntityOperationService
    {
        /// <summary>Retrieves a specific entityoperation by its primary key</summary>
        /// <param name="id">The primary key of the entityoperation</param>
        /// <returns>The entityoperation data</returns>
        EntityOperation GetById(Guid id);

        /// <summary>Retrieves a list of entityoperations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entityoperations</returns>
        List<EntityOperation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new entityoperation</summary>
        /// <param name="model">The entityoperation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(EntityOperation model);

        /// <summary>Updates a specific entityoperation by its primary key</summary>
        /// <param name="id">The primary key of the entityoperation</param>
        /// <param name="updatedEntity">The entityoperation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, EntityOperation updatedEntity);

        /// <summary>Updates a specific entityoperation by its primary key</summary>
        /// <param name="id">The primary key of the entityoperation</param>
        /// <param name="updatedEntity">The entityoperation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<EntityOperation> updatedEntity);

        /// <summary>Deletes a specific entityoperation by its primary key</summary>
        /// <param name="id">The primary key of the entityoperation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The entityoperationService responsible for managing entityoperation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting entityoperation information.
    /// </remarks>
    public class EntityOperationService : IEntityOperationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the EntityOperation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public EntityOperationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific entityoperation by its primary key</summary>
        /// <param name="id">The primary key of the entityoperation</param>
        /// <returns>The entityoperation data</returns>
        public EntityOperation GetById(Guid id)
        {
            var entityData = _dbContext.EntityOperation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of entityoperations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entityoperations</returns>/// <exception cref="Exception"></exception>
        public List<EntityOperation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetEntityOperation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new entityoperation</summary>
        /// <param name="model">The entityoperation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(EntityOperation model)
        {
            model.Id = CreateEntityOperation(model);
            return model.Id;
        }

        /// <summary>Updates a specific entityoperation by its primary key</summary>
        /// <param name="id">The primary key of the entityoperation</param>
        /// <param name="updatedEntity">The entityoperation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, EntityOperation updatedEntity)
        {
            UpdateEntityOperation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific entityoperation by its primary key</summary>
        /// <param name="id">The primary key of the entityoperation</param>
        /// <param name="updatedEntity">The entityoperation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<EntityOperation> updatedEntity)
        {
            PatchEntityOperation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific entityoperation by its primary key</summary>
        /// <param name="id">The primary key of the entityoperation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteEntityOperation(id);
            return true;
        }
        #region
        private List<EntityOperation> GetEntityOperation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EntityOperation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EntityOperation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EntityOperation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EntityOperation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateEntityOperation(EntityOperation model)
        {
            _dbContext.EntityOperation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateEntityOperation(Guid id, EntityOperation updatedEntity)
        {
            _dbContext.EntityOperation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteEntityOperation(Guid id)
        {
            var entityData = _dbContext.EntityOperation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EntityOperation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchEntityOperation(Guid id, JsonPatchDocument<EntityOperation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EntityOperation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EntityOperation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}