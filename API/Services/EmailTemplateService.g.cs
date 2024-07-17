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
    /// The emailtemplateService responsible for managing emailtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting emailtemplate information.
    /// </remarks>
    public interface IEmailTemplateService
    {
        /// <summary>Retrieves a specific emailtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emailtemplate</param>
        /// <returns>The emailtemplate data</returns>
        EmailTemplate GetById(Guid id);

        /// <summary>Retrieves a list of emailtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of emailtemplates</returns>
        List<EmailTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new emailtemplate</summary>
        /// <param name="model">The emailtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(EmailTemplate model);

        /// <summary>Updates a specific emailtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emailtemplate</param>
        /// <param name="updatedEntity">The emailtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, EmailTemplate updatedEntity);

        /// <summary>Updates a specific emailtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emailtemplate</param>
        /// <param name="updatedEntity">The emailtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<EmailTemplate> updatedEntity);

        /// <summary>Deletes a specific emailtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emailtemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The emailtemplateService responsible for managing emailtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting emailtemplate information.
    /// </remarks>
    public class EmailTemplateService : IEmailTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the EmailTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public EmailTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific emailtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emailtemplate</param>
        /// <returns>The emailtemplate data</returns>
        public EmailTemplate GetById(Guid id)
        {
            var entityData = _dbContext.EmailTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of emailtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of emailtemplates</returns>/// <exception cref="Exception"></exception>
        public List<EmailTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetEmailTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new emailtemplate</summary>
        /// <param name="model">The emailtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(EmailTemplate model)
        {
            model.Id = CreateEmailTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific emailtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emailtemplate</param>
        /// <param name="updatedEntity">The emailtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, EmailTemplate updatedEntity)
        {
            UpdateEmailTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific emailtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emailtemplate</param>
        /// <param name="updatedEntity">The emailtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<EmailTemplate> updatedEntity)
        {
            PatchEmailTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific emailtemplate by its primary key</summary>
        /// <param name="id">The primary key of the emailtemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteEmailTemplate(id);
            return true;
        }
        #region
        private List<EmailTemplate> GetEmailTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EmailTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EmailTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EmailTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EmailTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateEmailTemplate(EmailTemplate model)
        {
            _dbContext.EmailTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateEmailTemplate(Guid id, EmailTemplate updatedEntity)
        {
            _dbContext.EmailTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteEmailTemplate(Guid id)
        {
            var entityData = _dbContext.EmailTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EmailTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchEmailTemplate(Guid id, JsonPatchDocument<EmailTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EmailTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EmailTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}