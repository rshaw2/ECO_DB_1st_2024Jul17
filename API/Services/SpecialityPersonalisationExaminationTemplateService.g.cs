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
    /// The specialitypersonalisationexaminationtemplateService responsible for managing specialitypersonalisationexaminationtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationexaminationtemplate information.
    /// </remarks>
    public interface ISpecialityPersonalisationExaminationTemplateService
    {
        /// <summary>Retrieves a specific specialitypersonalisationexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationexaminationtemplate</param>
        /// <returns>The specialitypersonalisationexaminationtemplate data</returns>
        SpecialityPersonalisationExaminationTemplate GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationexaminationtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationexaminationtemplates</returns>
        List<SpecialityPersonalisationExaminationTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationexaminationtemplate</summary>
        /// <param name="model">The specialitypersonalisationexaminationtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationExaminationTemplate model);

        /// <summary>Updates a specific specialitypersonalisationexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationexaminationtemplate</param>
        /// <param name="updatedEntity">The specialitypersonalisationexaminationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationExaminationTemplate updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationexaminationtemplate</param>
        /// <param name="updatedEntity">The specialitypersonalisationexaminationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationExaminationTemplate> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationexaminationtemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationexaminationtemplateService responsible for managing specialitypersonalisationexaminationtemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationexaminationtemplate information.
    /// </remarks>
    public class SpecialityPersonalisationExaminationTemplateService : ISpecialityPersonalisationExaminationTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationExaminationTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationExaminationTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationexaminationtemplate</param>
        /// <returns>The specialitypersonalisationexaminationtemplate data</returns>
        public SpecialityPersonalisationExaminationTemplate GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationExaminationTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationexaminationtemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationexaminationtemplates</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationExaminationTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationExaminationTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationexaminationtemplate</summary>
        /// <param name="model">The specialitypersonalisationexaminationtemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationExaminationTemplate model)
        {
            model.Id = CreateSpecialityPersonalisationExaminationTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationexaminationtemplate</param>
        /// <param name="updatedEntity">The specialitypersonalisationexaminationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationExaminationTemplate updatedEntity)
        {
            UpdateSpecialityPersonalisationExaminationTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationexaminationtemplate</param>
        /// <param name="updatedEntity">The specialitypersonalisationexaminationtemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationExaminationTemplate> updatedEntity)
        {
            PatchSpecialityPersonalisationExaminationTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationexaminationtemplate by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationexaminationtemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationExaminationTemplate(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationExaminationTemplate> GetSpecialityPersonalisationExaminationTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationExaminationTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationExaminationTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationExaminationTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationExaminationTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationExaminationTemplate(SpecialityPersonalisationExaminationTemplate model)
        {
            _dbContext.SpecialityPersonalisationExaminationTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationExaminationTemplate(Guid id, SpecialityPersonalisationExaminationTemplate updatedEntity)
        {
            _dbContext.SpecialityPersonalisationExaminationTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationExaminationTemplate(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationExaminationTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationExaminationTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationExaminationTemplate(Guid id, JsonPatchDocument<SpecialityPersonalisationExaminationTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationExaminationTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationExaminationTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}