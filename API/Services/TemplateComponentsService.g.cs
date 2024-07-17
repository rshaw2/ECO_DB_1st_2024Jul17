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
    /// The templatecomponentsService responsible for managing templatecomponents related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting templatecomponents information.
    /// </remarks>
    public interface ITemplateComponentsService
    {
        /// <summary>Retrieves a specific templatecomponents by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponents</param>
        /// <returns>The templatecomponents data</returns>
        TemplateComponents GetById(Guid id);

        /// <summary>Retrieves a list of templatecomponentss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of templatecomponentss</returns>
        List<TemplateComponents> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new templatecomponents</summary>
        /// <param name="model">The templatecomponents data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TemplateComponents model);

        /// <summary>Updates a specific templatecomponents by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponents</param>
        /// <param name="updatedEntity">The templatecomponents data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TemplateComponents updatedEntity);

        /// <summary>Updates a specific templatecomponents by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponents</param>
        /// <param name="updatedEntity">The templatecomponents data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TemplateComponents> updatedEntity);

        /// <summary>Deletes a specific templatecomponents by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponents</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The templatecomponentsService responsible for managing templatecomponents related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting templatecomponents information.
    /// </remarks>
    public class TemplateComponentsService : ITemplateComponentsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TemplateComponents class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TemplateComponentsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific templatecomponents by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponents</param>
        /// <returns>The templatecomponents data</returns>
        public TemplateComponents GetById(Guid id)
        {
            var entityData = _dbContext.TemplateComponents.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of templatecomponentss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of templatecomponentss</returns>/// <exception cref="Exception"></exception>
        public List<TemplateComponents> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTemplateComponents(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new templatecomponents</summary>
        /// <param name="model">The templatecomponents data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TemplateComponents model)
        {
            model.Id = CreateTemplateComponents(model);
            return model.Id;
        }

        /// <summary>Updates a specific templatecomponents by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponents</param>
        /// <param name="updatedEntity">The templatecomponents data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TemplateComponents updatedEntity)
        {
            UpdateTemplateComponents(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific templatecomponents by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponents</param>
        /// <param name="updatedEntity">The templatecomponents data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TemplateComponents> updatedEntity)
        {
            PatchTemplateComponents(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific templatecomponents by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponents</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTemplateComponents(id);
            return true;
        }
        #region
        private List<TemplateComponents> GetTemplateComponents(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TemplateComponents.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TemplateComponents>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TemplateComponents), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TemplateComponents, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTemplateComponents(TemplateComponents model)
        {
            _dbContext.TemplateComponents.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTemplateComponents(Guid id, TemplateComponents updatedEntity)
        {
            _dbContext.TemplateComponents.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTemplateComponents(Guid id)
        {
            var entityData = _dbContext.TemplateComponents.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TemplateComponents.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTemplateComponents(Guid id, JsonPatchDocument<TemplateComponents> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TemplateComponents.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TemplateComponents.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}