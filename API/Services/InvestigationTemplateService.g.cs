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
    /// The investigationtemplateService responsible for managing investigationtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationtemplate information.
    /// </remarks>
    public interface IInvestigationTemplateService
    {
        /// <summary>Retrieves a specific investigationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplate</param>
        /// <returns>The investigationtemplate data</returns>
        InvestigationTemplate GetById(Guid id);

        /// <summary>Retrieves a list of investigationtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationtemplates</returns>
        List<InvestigationTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new investigationtemplate</summary>
        /// <param name="model">The investigationtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InvestigationTemplate model);

        /// <summary>Updates a specific investigationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplate</param>
        /// <param name="updatedEntity">The investigationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvestigationTemplate updatedEntity);

        /// <summary>Updates a specific investigationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplate</param>
        /// <param name="updatedEntity">The investigationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvestigationTemplate> updatedEntity);

        /// <summary>Deletes a specific investigationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The investigationtemplateService responsible for managing investigationtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationtemplate information.
    /// </remarks>
    public class InvestigationTemplateService : IInvestigationTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvestigationTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvestigationTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific investigationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplate</param>
        /// <returns>The investigationtemplate data</returns>
        public InvestigationTemplate GetById(Guid id)
        {
            var entityData = _dbContext.InvestigationTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of investigationtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationtemplates</returns>/// <exception cref="Exception"></exception>
        public List<InvestigationTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvestigationTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new investigationtemplate</summary>
        /// <param name="model">The investigationtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InvestigationTemplate model)
        {
            model.Id = CreateInvestigationTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific investigationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplate</param>
        /// <param name="updatedEntity">The investigationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvestigationTemplate updatedEntity)
        {
            UpdateInvestigationTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific investigationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplate</param>
        /// <param name="updatedEntity">The investigationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvestigationTemplate> updatedEntity)
        {
            PatchInvestigationTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific investigationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvestigationTemplate(id);
            return true;
        }
        #region
        private List<InvestigationTemplate> GetInvestigationTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvestigationTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvestigationTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvestigationTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvestigationTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInvestigationTemplate(InvestigationTemplate model)
        {
            _dbContext.InvestigationTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInvestigationTemplate(Guid id, InvestigationTemplate updatedEntity)
        {
            _dbContext.InvestigationTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvestigationTemplate(Guid id)
        {
            var entityData = _dbContext.InvestigationTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvestigationTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvestigationTemplate(Guid id, JsonPatchDocument<InvestigationTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvestigationTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvestigationTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}