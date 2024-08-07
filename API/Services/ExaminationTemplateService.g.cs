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
    /// The examinationtemplateService responsible for managing examinationtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting examinationtemplate information.
    /// </remarks>
    public interface IExaminationTemplateService
    {
        /// <summary>Retrieves a specific examinationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplate</param>
        /// <returns>The examinationtemplate data</returns>
        ExaminationTemplate GetById(Guid id);

        /// <summary>Retrieves a list of examinationtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of examinationtemplates</returns>
        List<ExaminationTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new examinationtemplate</summary>
        /// <param name="model">The examinationtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ExaminationTemplate model);

        /// <summary>Updates a specific examinationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplate</param>
        /// <param name="updatedEntity">The examinationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ExaminationTemplate updatedEntity);

        /// <summary>Updates a specific examinationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplate</param>
        /// <param name="updatedEntity">The examinationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ExaminationTemplate> updatedEntity);

        /// <summary>Deletes a specific examinationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The examinationtemplateService responsible for managing examinationtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting examinationtemplate information.
    /// </remarks>
    public class ExaminationTemplateService : IExaminationTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ExaminationTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ExaminationTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific examinationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplate</param>
        /// <returns>The examinationtemplate data</returns>
        public ExaminationTemplate GetById(Guid id)
        {
            var entityData = _dbContext.ExaminationTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of examinationtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of examinationtemplates</returns>/// <exception cref="Exception"></exception>
        public List<ExaminationTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetExaminationTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new examinationtemplate</summary>
        /// <param name="model">The examinationtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ExaminationTemplate model)
        {
            model.Id = CreateExaminationTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific examinationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplate</param>
        /// <param name="updatedEntity">The examinationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ExaminationTemplate updatedEntity)
        {
            UpdateExaminationTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific examinationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplate</param>
        /// <param name="updatedEntity">The examinationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ExaminationTemplate> updatedEntity)
        {
            PatchExaminationTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific examinationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteExaminationTemplate(id);
            return true;
        }
        #region
        private List<ExaminationTemplate> GetExaminationTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ExaminationTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ExaminationTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ExaminationTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ExaminationTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateExaminationTemplate(ExaminationTemplate model)
        {
            _dbContext.ExaminationTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateExaminationTemplate(Guid id, ExaminationTemplate updatedEntity)
        {
            _dbContext.ExaminationTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteExaminationTemplate(Guid id)
        {
            var entityData = _dbContext.ExaminationTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ExaminationTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchExaminationTemplate(Guid id, JsonPatchDocument<ExaminationTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ExaminationTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ExaminationTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}