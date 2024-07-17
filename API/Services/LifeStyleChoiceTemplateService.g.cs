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
    /// The lifestylechoicetemplateService responsible for managing lifestylechoicetemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting lifestylechoicetemplate information.
    /// </remarks>
    public interface ILifeStyleChoiceTemplateService
    {
        /// <summary>Retrieves a specific lifestylechoicetemplate by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplate</param>
        /// <returns>The lifestylechoicetemplate data</returns>
        LifeStyleChoiceTemplate GetById(Guid id);

        /// <summary>Retrieves a list of lifestylechoicetemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of lifestylechoicetemplates</returns>
        List<LifeStyleChoiceTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new lifestylechoicetemplate</summary>
        /// <param name="model">The lifestylechoicetemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(LifeStyleChoiceTemplate model);

        /// <summary>Updates a specific lifestylechoicetemplate by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplate</param>
        /// <param name="updatedEntity">The lifestylechoicetemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, LifeStyleChoiceTemplate updatedEntity);

        /// <summary>Updates a specific lifestylechoicetemplate by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplate</param>
        /// <param name="updatedEntity">The lifestylechoicetemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<LifeStyleChoiceTemplate> updatedEntity);

        /// <summary>Deletes a specific lifestylechoicetemplate by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The lifestylechoicetemplateService responsible for managing lifestylechoicetemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting lifestylechoicetemplate information.
    /// </remarks>
    public class LifeStyleChoiceTemplateService : ILifeStyleChoiceTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the LifeStyleChoiceTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public LifeStyleChoiceTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific lifestylechoicetemplate by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplate</param>
        /// <returns>The lifestylechoicetemplate data</returns>
        public LifeStyleChoiceTemplate GetById(Guid id)
        {
            var entityData = _dbContext.LifeStyleChoiceTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of lifestylechoicetemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of lifestylechoicetemplates</returns>/// <exception cref="Exception"></exception>
        public List<LifeStyleChoiceTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetLifeStyleChoiceTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new lifestylechoicetemplate</summary>
        /// <param name="model">The lifestylechoicetemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(LifeStyleChoiceTemplate model)
        {
            model.Id = CreateLifeStyleChoiceTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific lifestylechoicetemplate by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplate</param>
        /// <param name="updatedEntity">The lifestylechoicetemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, LifeStyleChoiceTemplate updatedEntity)
        {
            UpdateLifeStyleChoiceTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific lifestylechoicetemplate by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplate</param>
        /// <param name="updatedEntity">The lifestylechoicetemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<LifeStyleChoiceTemplate> updatedEntity)
        {
            PatchLifeStyleChoiceTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific lifestylechoicetemplate by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteLifeStyleChoiceTemplate(id);
            return true;
        }
        #region
        private List<LifeStyleChoiceTemplate> GetLifeStyleChoiceTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LifeStyleChoiceTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LifeStyleChoiceTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LifeStyleChoiceTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LifeStyleChoiceTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateLifeStyleChoiceTemplate(LifeStyleChoiceTemplate model)
        {
            _dbContext.LifeStyleChoiceTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateLifeStyleChoiceTemplate(Guid id, LifeStyleChoiceTemplate updatedEntity)
        {
            _dbContext.LifeStyleChoiceTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteLifeStyleChoiceTemplate(Guid id)
        {
            var entityData = _dbContext.LifeStyleChoiceTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LifeStyleChoiceTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchLifeStyleChoiceTemplate(Guid id, JsonPatchDocument<LifeStyleChoiceTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LifeStyleChoiceTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LifeStyleChoiceTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}