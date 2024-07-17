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
    /// The diagnosistemplateService responsible for managing diagnosistemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting diagnosistemplate information.
    /// </remarks>
    public interface IDiagnosisTemplateService
    {
        /// <summary>Retrieves a specific diagnosistemplate by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplate</param>
        /// <returns>The diagnosistemplate data</returns>
        DiagnosisTemplate GetById(Guid id);

        /// <summary>Retrieves a list of diagnosistemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of diagnosistemplates</returns>
        List<DiagnosisTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new diagnosistemplate</summary>
        /// <param name="model">The diagnosistemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DiagnosisTemplate model);

        /// <summary>Updates a specific diagnosistemplate by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplate</param>
        /// <param name="updatedEntity">The diagnosistemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DiagnosisTemplate updatedEntity);

        /// <summary>Updates a specific diagnosistemplate by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplate</param>
        /// <param name="updatedEntity">The diagnosistemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DiagnosisTemplate> updatedEntity);

        /// <summary>Deletes a specific diagnosistemplate by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The diagnosistemplateService responsible for managing diagnosistemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting diagnosistemplate information.
    /// </remarks>
    public class DiagnosisTemplateService : IDiagnosisTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DiagnosisTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DiagnosisTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific diagnosistemplate by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplate</param>
        /// <returns>The diagnosistemplate data</returns>
        public DiagnosisTemplate GetById(Guid id)
        {
            var entityData = _dbContext.DiagnosisTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of diagnosistemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of diagnosistemplates</returns>/// <exception cref="Exception"></exception>
        public List<DiagnosisTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDiagnosisTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new diagnosistemplate</summary>
        /// <param name="model">The diagnosistemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DiagnosisTemplate model)
        {
            model.Id = CreateDiagnosisTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific diagnosistemplate by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplate</param>
        /// <param name="updatedEntity">The diagnosistemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DiagnosisTemplate updatedEntity)
        {
            UpdateDiagnosisTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific diagnosistemplate by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplate</param>
        /// <param name="updatedEntity">The diagnosistemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DiagnosisTemplate> updatedEntity)
        {
            PatchDiagnosisTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific diagnosistemplate by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDiagnosisTemplate(id);
            return true;
        }
        #region
        private List<DiagnosisTemplate> GetDiagnosisTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DiagnosisTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DiagnosisTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DiagnosisTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DiagnosisTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDiagnosisTemplate(DiagnosisTemplate model)
        {
            _dbContext.DiagnosisTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDiagnosisTemplate(Guid id, DiagnosisTemplate updatedEntity)
        {
            _dbContext.DiagnosisTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDiagnosisTemplate(Guid id)
        {
            var entityData = _dbContext.DiagnosisTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DiagnosisTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDiagnosisTemplate(Guid id, JsonPatchDocument<DiagnosisTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DiagnosisTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DiagnosisTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}