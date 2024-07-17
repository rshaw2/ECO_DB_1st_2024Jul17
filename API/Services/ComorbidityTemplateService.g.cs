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
    /// The comorbiditytemplateService responsible for managing comorbiditytemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting comorbiditytemplate information.
    /// </remarks>
    public interface IComorbidityTemplateService
    {
        /// <summary>Retrieves a specific comorbiditytemplate by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditytemplate</param>
        /// <returns>The comorbiditytemplate data</returns>
        ComorbidityTemplate GetById(Guid id);

        /// <summary>Retrieves a list of comorbiditytemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of comorbiditytemplates</returns>
        List<ComorbidityTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new comorbiditytemplate</summary>
        /// <param name="model">The comorbiditytemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ComorbidityTemplate model);

        /// <summary>Updates a specific comorbiditytemplate by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditytemplate</param>
        /// <param name="updatedEntity">The comorbiditytemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ComorbidityTemplate updatedEntity);

        /// <summary>Updates a specific comorbiditytemplate by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditytemplate</param>
        /// <param name="updatedEntity">The comorbiditytemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ComorbidityTemplate> updatedEntity);

        /// <summary>Deletes a specific comorbiditytemplate by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditytemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The comorbiditytemplateService responsible for managing comorbiditytemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting comorbiditytemplate information.
    /// </remarks>
    public class ComorbidityTemplateService : IComorbidityTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ComorbidityTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ComorbidityTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific comorbiditytemplate by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditytemplate</param>
        /// <returns>The comorbiditytemplate data</returns>
        public ComorbidityTemplate GetById(Guid id)
        {
            var entityData = _dbContext.ComorbidityTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of comorbiditytemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of comorbiditytemplates</returns>/// <exception cref="Exception"></exception>
        public List<ComorbidityTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetComorbidityTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new comorbiditytemplate</summary>
        /// <param name="model">The comorbiditytemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ComorbidityTemplate model)
        {
            model.Id = CreateComorbidityTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific comorbiditytemplate by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditytemplate</param>
        /// <param name="updatedEntity">The comorbiditytemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ComorbidityTemplate updatedEntity)
        {
            UpdateComorbidityTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific comorbiditytemplate by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditytemplate</param>
        /// <param name="updatedEntity">The comorbiditytemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ComorbidityTemplate> updatedEntity)
        {
            PatchComorbidityTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific comorbiditytemplate by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditytemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteComorbidityTemplate(id);
            return true;
        }
        #region
        private List<ComorbidityTemplate> GetComorbidityTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ComorbidityTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ComorbidityTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ComorbidityTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ComorbidityTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateComorbidityTemplate(ComorbidityTemplate model)
        {
            _dbContext.ComorbidityTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateComorbidityTemplate(Guid id, ComorbidityTemplate updatedEntity)
        {
            _dbContext.ComorbidityTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteComorbidityTemplate(Guid id)
        {
            var entityData = _dbContext.ComorbidityTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ComorbidityTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchComorbidityTemplate(Guid id, JsonPatchDocument<ComorbidityTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ComorbidityTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ComorbidityTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}