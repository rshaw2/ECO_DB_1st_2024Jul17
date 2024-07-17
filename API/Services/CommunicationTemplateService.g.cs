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
    /// The communicationtemplateService responsible for managing communicationtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationtemplate information.
    /// </remarks>
    public interface ICommunicationTemplateService
    {
        /// <summary>Retrieves a specific communicationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplate</param>
        /// <returns>The communicationtemplate data</returns>
        CommunicationTemplate GetById(Guid id);

        /// <summary>Retrieves a list of communicationtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationtemplates</returns>
        List<CommunicationTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationtemplate</summary>
        /// <param name="model">The communicationtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationTemplate model);

        /// <summary>Updates a specific communicationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplate</param>
        /// <param name="updatedEntity">The communicationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationTemplate updatedEntity);

        /// <summary>Updates a specific communicationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplate</param>
        /// <param name="updatedEntity">The communicationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationTemplate> updatedEntity);

        /// <summary>Deletes a specific communicationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationtemplateService responsible for managing communicationtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationtemplate information.
    /// </remarks>
    public class CommunicationTemplateService : ICommunicationTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplate</param>
        /// <returns>The communicationtemplate data</returns>
        public CommunicationTemplate GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationtemplates</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationtemplate</summary>
        /// <param name="model">The communicationtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationTemplate model)
        {
            model.Id = CreateCommunicationTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplate</param>
        /// <param name="updatedEntity">The communicationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationTemplate updatedEntity)
        {
            UpdateCommunicationTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplate</param>
        /// <param name="updatedEntity">The communicationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationTemplate> updatedEntity)
        {
            PatchCommunicationTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationTemplate(id);
            return true;
        }
        #region
        private List<CommunicationTemplate> GetCommunicationTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationTemplate(CommunicationTemplate model)
        {
            _dbContext.CommunicationTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationTemplate(Guid id, CommunicationTemplate updatedEntity)
        {
            _dbContext.CommunicationTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationTemplate(Guid id)
        {
            var entityData = _dbContext.CommunicationTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationTemplate(Guid id, JsonPatchDocument<CommunicationTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}