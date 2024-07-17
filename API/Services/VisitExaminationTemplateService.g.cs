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
    /// The visitexaminationtemplateService responsible for managing visitexaminationtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitexaminationtemplate information.
    /// </remarks>
    public interface IVisitExaminationTemplateService
    {
        /// <summary>Retrieves a specific visitexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplate</param>
        /// <returns>The visitexaminationtemplate data</returns>
        VisitExaminationTemplate GetById(Guid id);

        /// <summary>Retrieves a list of visitexaminationtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitexaminationtemplates</returns>
        List<VisitExaminationTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitexaminationtemplate</summary>
        /// <param name="model">The visitexaminationtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitExaminationTemplate model);

        /// <summary>Updates a specific visitexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplate</param>
        /// <param name="updatedEntity">The visitexaminationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitExaminationTemplate updatedEntity);

        /// <summary>Updates a specific visitexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplate</param>
        /// <param name="updatedEntity">The visitexaminationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitExaminationTemplate> updatedEntity);

        /// <summary>Deletes a specific visitexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitexaminationtemplateService responsible for managing visitexaminationtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitexaminationtemplate information.
    /// </remarks>
    public class VisitExaminationTemplateService : IVisitExaminationTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitExaminationTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitExaminationTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplate</param>
        /// <returns>The visitexaminationtemplate data</returns>
        public VisitExaminationTemplate GetById(Guid id)
        {
            var entityData = _dbContext.VisitExaminationTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitexaminationtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitexaminationtemplates</returns>/// <exception cref="Exception"></exception>
        public List<VisitExaminationTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitExaminationTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitexaminationtemplate</summary>
        /// <param name="model">The visitexaminationtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitExaminationTemplate model)
        {
            model.Id = CreateVisitExaminationTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplate</param>
        /// <param name="updatedEntity">The visitexaminationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitExaminationTemplate updatedEntity)
        {
            UpdateVisitExaminationTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplate</param>
        /// <param name="updatedEntity">The visitexaminationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitExaminationTemplate> updatedEntity)
        {
            PatchVisitExaminationTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitExaminationTemplate(id);
            return true;
        }
        #region
        private List<VisitExaminationTemplate> GetVisitExaminationTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitExaminationTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitExaminationTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitExaminationTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitExaminationTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitExaminationTemplate(VisitExaminationTemplate model)
        {
            _dbContext.VisitExaminationTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitExaminationTemplate(Guid id, VisitExaminationTemplate updatedEntity)
        {
            _dbContext.VisitExaminationTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitExaminationTemplate(Guid id)
        {
            var entityData = _dbContext.VisitExaminationTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitExaminationTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitExaminationTemplate(Guid id, JsonPatchDocument<VisitExaminationTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitExaminationTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitExaminationTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}