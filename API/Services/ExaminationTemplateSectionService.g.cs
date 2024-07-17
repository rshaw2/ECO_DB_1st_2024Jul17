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
    /// The examinationtemplatesectionService responsible for managing examinationtemplatesection related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting examinationtemplatesection information.
    /// </remarks>
    public interface IExaminationTemplateSectionService
    {
        /// <summary>Retrieves a specific examinationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplatesection</param>
        /// <returns>The examinationtemplatesection data</returns>
        ExaminationTemplateSection GetById(Guid id);

        /// <summary>Retrieves a list of examinationtemplatesections based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of examinationtemplatesections</returns>
        List<ExaminationTemplateSection> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new examinationtemplatesection</summary>
        /// <param name="model">The examinationtemplatesection data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ExaminationTemplateSection model);

        /// <summary>Updates a specific examinationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplatesection</param>
        /// <param name="updatedEntity">The examinationtemplatesection data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ExaminationTemplateSection updatedEntity);

        /// <summary>Updates a specific examinationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplatesection</param>
        /// <param name="updatedEntity">The examinationtemplatesection data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ExaminationTemplateSection> updatedEntity);

        /// <summary>Deletes a specific examinationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplatesection</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The examinationtemplatesectionService responsible for managing examinationtemplatesection related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting examinationtemplatesection information.
    /// </remarks>
    public class ExaminationTemplateSectionService : IExaminationTemplateSectionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ExaminationTemplateSection class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ExaminationTemplateSectionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific examinationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplatesection</param>
        /// <returns>The examinationtemplatesection data</returns>
        public ExaminationTemplateSection GetById(Guid id)
        {
            var entityData = _dbContext.ExaminationTemplateSection.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of examinationtemplatesections based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of examinationtemplatesections</returns>/// <exception cref="Exception"></exception>
        public List<ExaminationTemplateSection> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetExaminationTemplateSection(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new examinationtemplatesection</summary>
        /// <param name="model">The examinationtemplatesection data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ExaminationTemplateSection model)
        {
            model.Id = CreateExaminationTemplateSection(model);
            return model.Id;
        }

        /// <summary>Updates a specific examinationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplatesection</param>
        /// <param name="updatedEntity">The examinationtemplatesection data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ExaminationTemplateSection updatedEntity)
        {
            UpdateExaminationTemplateSection(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific examinationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplatesection</param>
        /// <param name="updatedEntity">The examinationtemplatesection data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ExaminationTemplateSection> updatedEntity)
        {
            PatchExaminationTemplateSection(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific examinationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the examinationtemplatesection</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteExaminationTemplateSection(id);
            return true;
        }
        #region
        private List<ExaminationTemplateSection> GetExaminationTemplateSection(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ExaminationTemplateSection.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ExaminationTemplateSection>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ExaminationTemplateSection), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ExaminationTemplateSection, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateExaminationTemplateSection(ExaminationTemplateSection model)
        {
            _dbContext.ExaminationTemplateSection.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateExaminationTemplateSection(Guid id, ExaminationTemplateSection updatedEntity)
        {
            _dbContext.ExaminationTemplateSection.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteExaminationTemplateSection(Guid id)
        {
            var entityData = _dbContext.ExaminationTemplateSection.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ExaminationTemplateSection.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchExaminationTemplateSection(Guid id, JsonPatchDocument<ExaminationTemplateSection> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ExaminationTemplateSection.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ExaminationTemplateSection.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}