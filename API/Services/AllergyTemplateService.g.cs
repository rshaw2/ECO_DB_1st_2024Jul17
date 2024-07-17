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
    /// The allergytemplateService responsible for managing allergytemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergytemplate information.
    /// </remarks>
    public interface IAllergyTemplateService
    {
        /// <summary>Retrieves a specific allergytemplate by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplate</param>
        /// <returns>The allergytemplate data</returns>
        AllergyTemplate GetById(Guid id);

        /// <summary>Retrieves a list of allergytemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergytemplates</returns>
        List<AllergyTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new allergytemplate</summary>
        /// <param name="model">The allergytemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AllergyTemplate model);

        /// <summary>Updates a specific allergytemplate by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplate</param>
        /// <param name="updatedEntity">The allergytemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AllergyTemplate updatedEntity);

        /// <summary>Updates a specific allergytemplate by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplate</param>
        /// <param name="updatedEntity">The allergytemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AllergyTemplate> updatedEntity);

        /// <summary>Deletes a specific allergytemplate by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The allergytemplateService responsible for managing allergytemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergytemplate information.
    /// </remarks>
    public class AllergyTemplateService : IAllergyTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AllergyTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AllergyTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific allergytemplate by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplate</param>
        /// <returns>The allergytemplate data</returns>
        public AllergyTemplate GetById(Guid id)
        {
            var entityData = _dbContext.AllergyTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of allergytemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergytemplates</returns>/// <exception cref="Exception"></exception>
        public List<AllergyTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAllergyTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new allergytemplate</summary>
        /// <param name="model">The allergytemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AllergyTemplate model)
        {
            model.Id = CreateAllergyTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific allergytemplate by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplate</param>
        /// <param name="updatedEntity">The allergytemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AllergyTemplate updatedEntity)
        {
            UpdateAllergyTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific allergytemplate by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplate</param>
        /// <param name="updatedEntity">The allergytemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AllergyTemplate> updatedEntity)
        {
            PatchAllergyTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific allergytemplate by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAllergyTemplate(id);
            return true;
        }
        #region
        private List<AllergyTemplate> GetAllergyTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AllergyTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AllergyTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AllergyTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AllergyTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAllergyTemplate(AllergyTemplate model)
        {
            _dbContext.AllergyTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAllergyTemplate(Guid id, AllergyTemplate updatedEntity)
        {
            _dbContext.AllergyTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAllergyTemplate(Guid id)
        {
            var entityData = _dbContext.AllergyTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AllergyTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAllergyTemplate(Guid id, JsonPatchDocument<AllergyTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AllergyTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AllergyTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}