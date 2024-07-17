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
    /// The emrtemplateService responsible for managing emrtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting emrtemplate information.
    /// </remarks>
    public interface IEmrTemplateService
    {
        /// <summary>Retrieves a specific emrtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emrtemplate</param>
        /// <returns>The emrtemplate data</returns>
        EmrTemplate GetById(Guid id);

        /// <summary>Retrieves a list of emrtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of emrtemplates</returns>
        List<EmrTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new emrtemplate</summary>
        /// <param name="model">The emrtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(EmrTemplate model);

        /// <summary>Updates a specific emrtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emrtemplate</param>
        /// <param name="updatedEntity">The emrtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, EmrTemplate updatedEntity);

        /// <summary>Updates a specific emrtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emrtemplate</param>
        /// <param name="updatedEntity">The emrtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<EmrTemplate> updatedEntity);

        /// <summary>Deletes a specific emrtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emrtemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The emrtemplateService responsible for managing emrtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting emrtemplate information.
    /// </remarks>
    public class EmrTemplateService : IEmrTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the EmrTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public EmrTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific emrtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emrtemplate</param>
        /// <returns>The emrtemplate data</returns>
        public EmrTemplate GetById(Guid id)
        {
            var entityData = _dbContext.EmrTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of emrtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of emrtemplates</returns>/// <exception cref="Exception"></exception>
        public List<EmrTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetEmrTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new emrtemplate</summary>
        /// <param name="model">The emrtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(EmrTemplate model)
        {
            model.Id = CreateEmrTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific emrtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emrtemplate</param>
        /// <param name="updatedEntity">The emrtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, EmrTemplate updatedEntity)
        {
            UpdateEmrTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific emrtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emrtemplate</param>
        /// <param name="updatedEntity">The emrtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<EmrTemplate> updatedEntity)
        {
            PatchEmrTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific emrtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emrtemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteEmrTemplate(id);
            return true;
        }
        #region
        private List<EmrTemplate> GetEmrTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EmrTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EmrTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EmrTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EmrTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateEmrTemplate(EmrTemplate model)
        {
            _dbContext.EmrTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateEmrTemplate(Guid id, EmrTemplate updatedEntity)
        {
            _dbContext.EmrTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteEmrTemplate(Guid id)
        {
            var entityData = _dbContext.EmrTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EmrTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchEmrTemplate(Guid id, JsonPatchDocument<EmrTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EmrTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EmrTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}