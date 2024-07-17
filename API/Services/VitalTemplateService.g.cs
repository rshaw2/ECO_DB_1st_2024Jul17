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
    /// The vitaltemplateService responsible for managing vitaltemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting vitaltemplate information.
    /// </remarks>
    public interface IVitalTemplateService
    {
        /// <summary>Retrieves a specific vitaltemplate by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplate</param>
        /// <returns>The vitaltemplate data</returns>
        VitalTemplate GetById(Guid id);

        /// <summary>Retrieves a list of vitaltemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of vitaltemplates</returns>
        List<VitalTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new vitaltemplate</summary>
        /// <param name="model">The vitaltemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VitalTemplate model);

        /// <summary>Updates a specific vitaltemplate by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplate</param>
        /// <param name="updatedEntity">The vitaltemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VitalTemplate updatedEntity);

        /// <summary>Updates a specific vitaltemplate by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplate</param>
        /// <param name="updatedEntity">The vitaltemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VitalTemplate> updatedEntity);

        /// <summary>Deletes a specific vitaltemplate by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The vitaltemplateService responsible for managing vitaltemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting vitaltemplate information.
    /// </remarks>
    public class VitalTemplateService : IVitalTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VitalTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VitalTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific vitaltemplate by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplate</param>
        /// <returns>The vitaltemplate data</returns>
        public VitalTemplate GetById(Guid id)
        {
            var entityData = _dbContext.VitalTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of vitaltemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of vitaltemplates</returns>/// <exception cref="Exception"></exception>
        public List<VitalTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVitalTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new vitaltemplate</summary>
        /// <param name="model">The vitaltemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VitalTemplate model)
        {
            model.Id = CreateVitalTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific vitaltemplate by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplate</param>
        /// <param name="updatedEntity">The vitaltemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VitalTemplate updatedEntity)
        {
            UpdateVitalTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific vitaltemplate by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplate</param>
        /// <param name="updatedEntity">The vitaltemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VitalTemplate> updatedEntity)
        {
            PatchVitalTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific vitaltemplate by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVitalTemplate(id);
            return true;
        }
        #region
        private List<VitalTemplate> GetVitalTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VitalTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VitalTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VitalTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VitalTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVitalTemplate(VitalTemplate model)
        {
            _dbContext.VitalTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVitalTemplate(Guid id, VitalTemplate updatedEntity)
        {
            _dbContext.VitalTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVitalTemplate(Guid id)
        {
            var entityData = _dbContext.VitalTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VitalTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVitalTemplate(Guid id, JsonPatchDocument<VitalTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VitalTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VitalTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}