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
    /// The entityvectorconfigurationService responsible for managing entityvectorconfiguration related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting entityvectorconfiguration information.
    /// </remarks>
    public interface IEntityVectorConfigurationService
    {
        /// <summary>Retrieves a specific entityvectorconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the entityvectorconfiguration</param>
        /// <returns>The entityvectorconfiguration data</returns>
        EntityVectorConfiguration GetById(Guid id);

        /// <summary>Retrieves a list of entityvectorconfigurations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entityvectorconfigurations</returns>
        List<EntityVectorConfiguration> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new entityvectorconfiguration</summary>
        /// <param name="model">The entityvectorconfiguration data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(EntityVectorConfiguration model);

        /// <summary>Updates a specific entityvectorconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the entityvectorconfiguration</param>
        /// <param name="updatedEntity">The entityvectorconfiguration data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, EntityVectorConfiguration updatedEntity);

        /// <summary>Updates a specific entityvectorconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the entityvectorconfiguration</param>
        /// <param name="updatedEntity">The entityvectorconfiguration data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<EntityVectorConfiguration> updatedEntity);

        /// <summary>Deletes a specific entityvectorconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the entityvectorconfiguration</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The entityvectorconfigurationService responsible for managing entityvectorconfiguration related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting entityvectorconfiguration information.
    /// </remarks>
    public class EntityVectorConfigurationService : IEntityVectorConfigurationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the EntityVectorConfiguration class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public EntityVectorConfigurationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific entityvectorconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the entityvectorconfiguration</param>
        /// <returns>The entityvectorconfiguration data</returns>
        public EntityVectorConfiguration GetById(Guid id)
        {
            var entityData = _dbContext.EntityVectorConfiguration.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of entityvectorconfigurations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entityvectorconfigurations</returns>/// <exception cref="Exception"></exception>
        public List<EntityVectorConfiguration> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetEntityVectorConfiguration(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new entityvectorconfiguration</summary>
        /// <param name="model">The entityvectorconfiguration data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(EntityVectorConfiguration model)
        {
            model.Id = CreateEntityVectorConfiguration(model);
            return model.Id;
        }

        /// <summary>Updates a specific entityvectorconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the entityvectorconfiguration</param>
        /// <param name="updatedEntity">The entityvectorconfiguration data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, EntityVectorConfiguration updatedEntity)
        {
            UpdateEntityVectorConfiguration(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific entityvectorconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the entityvectorconfiguration</param>
        /// <param name="updatedEntity">The entityvectorconfiguration data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<EntityVectorConfiguration> updatedEntity)
        {
            PatchEntityVectorConfiguration(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific entityvectorconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the entityvectorconfiguration</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteEntityVectorConfiguration(id);
            return true;
        }
        #region
        private List<EntityVectorConfiguration> GetEntityVectorConfiguration(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EntityVectorConfiguration.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EntityVectorConfiguration>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EntityVectorConfiguration), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EntityVectorConfiguration, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateEntityVectorConfiguration(EntityVectorConfiguration model)
        {
            _dbContext.EntityVectorConfiguration.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateEntityVectorConfiguration(Guid id, EntityVectorConfiguration updatedEntity)
        {
            _dbContext.EntityVectorConfiguration.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteEntityVectorConfiguration(Guid id)
        {
            var entityData = _dbContext.EntityVectorConfiguration.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EntityVectorConfiguration.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchEntityVectorConfiguration(Guid id, JsonPatchDocument<EntityVectorConfiguration> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EntityVectorConfiguration.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EntityVectorConfiguration.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}