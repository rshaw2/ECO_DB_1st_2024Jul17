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
    /// The aiprocesstemplateService responsible for managing aiprocesstemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting aiprocesstemplate information.
    /// </remarks>
    public interface IAiProcessTemplateService
    {
        /// <summary>Retrieves a specific aiprocesstemplate by its primary key</summary>
        /// <param name="id">The primary key of the aiprocesstemplate</param>
        /// <returns>The aiprocesstemplate data</returns>
        AiProcessTemplate GetById(Guid id);

        /// <summary>Retrieves a list of aiprocesstemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aiprocesstemplates</returns>
        List<AiProcessTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new aiprocesstemplate</summary>
        /// <param name="model">The aiprocesstemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AiProcessTemplate model);

        /// <summary>Updates a specific aiprocesstemplate by its primary key</summary>
        /// <param name="id">The primary key of the aiprocesstemplate</param>
        /// <param name="updatedEntity">The aiprocesstemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AiProcessTemplate updatedEntity);

        /// <summary>Updates a specific aiprocesstemplate by its primary key</summary>
        /// <param name="id">The primary key of the aiprocesstemplate</param>
        /// <param name="updatedEntity">The aiprocesstemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AiProcessTemplate> updatedEntity);

        /// <summary>Deletes a specific aiprocesstemplate by its primary key</summary>
        /// <param name="id">The primary key of the aiprocesstemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The aiprocesstemplateService responsible for managing aiprocesstemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting aiprocesstemplate information.
    /// </remarks>
    public class AiProcessTemplateService : IAiProcessTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AiProcessTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AiProcessTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific aiprocesstemplate by its primary key</summary>
        /// <param name="id">The primary key of the aiprocesstemplate</param>
        /// <returns>The aiprocesstemplate data</returns>
        public AiProcessTemplate GetById(Guid id)
        {
            var entityData = _dbContext.AiProcessTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of aiprocesstemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aiprocesstemplates</returns>/// <exception cref="Exception"></exception>
        public List<AiProcessTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAiProcessTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new aiprocesstemplate</summary>
        /// <param name="model">The aiprocesstemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AiProcessTemplate model)
        {
            model.Id = CreateAiProcessTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific aiprocesstemplate by its primary key</summary>
        /// <param name="id">The primary key of the aiprocesstemplate</param>
        /// <param name="updatedEntity">The aiprocesstemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AiProcessTemplate updatedEntity)
        {
            UpdateAiProcessTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific aiprocesstemplate by its primary key</summary>
        /// <param name="id">The primary key of the aiprocesstemplate</param>
        /// <param name="updatedEntity">The aiprocesstemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AiProcessTemplate> updatedEntity)
        {
            PatchAiProcessTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific aiprocesstemplate by its primary key</summary>
        /// <param name="id">The primary key of the aiprocesstemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAiProcessTemplate(id);
            return true;
        }
        #region
        private List<AiProcessTemplate> GetAiProcessTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AiProcessTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AiProcessTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AiProcessTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AiProcessTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAiProcessTemplate(AiProcessTemplate model)
        {
            _dbContext.AiProcessTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAiProcessTemplate(Guid id, AiProcessTemplate updatedEntity)
        {
            _dbContext.AiProcessTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAiProcessTemplate(Guid id)
        {
            var entityData = _dbContext.AiProcessTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AiProcessTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAiProcessTemplate(Guid id, JsonPatchDocument<AiProcessTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AiProcessTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AiProcessTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}