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
    /// The tagsmasterService responsible for managing tagsmaster related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tagsmaster information.
    /// </remarks>
    public interface ITagsMasterService
    {
        /// <summary>Retrieves a specific tagsmaster by its primary key</summary>
        /// <param name="id">The primary key of the tagsmaster</param>
        /// <returns>The tagsmaster data</returns>
        TagsMaster GetById(Guid id);

        /// <summary>Retrieves a list of tagsmasters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tagsmasters</returns>
        List<TagsMaster> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tagsmaster</summary>
        /// <param name="model">The tagsmaster data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TagsMaster model);

        /// <summary>Updates a specific tagsmaster by its primary key</summary>
        /// <param name="id">The primary key of the tagsmaster</param>
        /// <param name="updatedEntity">The tagsmaster data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TagsMaster updatedEntity);

        /// <summary>Updates a specific tagsmaster by its primary key</summary>
        /// <param name="id">The primary key of the tagsmaster</param>
        /// <param name="updatedEntity">The tagsmaster data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TagsMaster> updatedEntity);

        /// <summary>Deletes a specific tagsmaster by its primary key</summary>
        /// <param name="id">The primary key of the tagsmaster</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tagsmasterService responsible for managing tagsmaster related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tagsmaster information.
    /// </remarks>
    public class TagsMasterService : ITagsMasterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TagsMaster class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TagsMasterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tagsmaster by its primary key</summary>
        /// <param name="id">The primary key of the tagsmaster</param>
        /// <returns>The tagsmaster data</returns>
        public TagsMaster GetById(Guid id)
        {
            var entityData = _dbContext.TagsMaster.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tagsmasters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tagsmasters</returns>/// <exception cref="Exception"></exception>
        public List<TagsMaster> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTagsMaster(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tagsmaster</summary>
        /// <param name="model">The tagsmaster data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TagsMaster model)
        {
            model.Id = CreateTagsMaster(model);
            return model.Id;
        }

        /// <summary>Updates a specific tagsmaster by its primary key</summary>
        /// <param name="id">The primary key of the tagsmaster</param>
        /// <param name="updatedEntity">The tagsmaster data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TagsMaster updatedEntity)
        {
            UpdateTagsMaster(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tagsmaster by its primary key</summary>
        /// <param name="id">The primary key of the tagsmaster</param>
        /// <param name="updatedEntity">The tagsmaster data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TagsMaster> updatedEntity)
        {
            PatchTagsMaster(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tagsmaster by its primary key</summary>
        /// <param name="id">The primary key of the tagsmaster</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTagsMaster(id);
            return true;
        }
        #region
        private List<TagsMaster> GetTagsMaster(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TagsMaster.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TagsMaster>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TagsMaster), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TagsMaster, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTagsMaster(TagsMaster model)
        {
            _dbContext.TagsMaster.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTagsMaster(Guid id, TagsMaster updatedEntity)
        {
            _dbContext.TagsMaster.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTagsMaster(Guid id)
        {
            var entityData = _dbContext.TagsMaster.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TagsMaster.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTagsMaster(Guid id, JsonPatchDocument<TagsMaster> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TagsMaster.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TagsMaster.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}