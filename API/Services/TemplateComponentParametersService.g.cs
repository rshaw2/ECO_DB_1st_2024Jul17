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
    /// The templatecomponentparametersService responsible for managing templatecomponentparameters related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting templatecomponentparameters information.
    /// </remarks>
    public interface ITemplateComponentParametersService
    {
        /// <summary>Retrieves a specific templatecomponentparameters by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponentparameters</param>
        /// <returns>The templatecomponentparameters data</returns>
        TemplateComponentParameters GetById(Guid id);

        /// <summary>Retrieves a list of templatecomponentparameterss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of templatecomponentparameterss</returns>
        List<TemplateComponentParameters> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new templatecomponentparameters</summary>
        /// <param name="model">The templatecomponentparameters data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TemplateComponentParameters model);

        /// <summary>Updates a specific templatecomponentparameters by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponentparameters</param>
        /// <param name="updatedEntity">The templatecomponentparameters data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TemplateComponentParameters updatedEntity);

        /// <summary>Updates a specific templatecomponentparameters by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponentparameters</param>
        /// <param name="updatedEntity">The templatecomponentparameters data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TemplateComponentParameters> updatedEntity);

        /// <summary>Deletes a specific templatecomponentparameters by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponentparameters</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The templatecomponentparametersService responsible for managing templatecomponentparameters related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting templatecomponentparameters information.
    /// </remarks>
    public class TemplateComponentParametersService : ITemplateComponentParametersService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TemplateComponentParameters class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TemplateComponentParametersService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific templatecomponentparameters by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponentparameters</param>
        /// <returns>The templatecomponentparameters data</returns>
        public TemplateComponentParameters GetById(Guid id)
        {
            var entityData = _dbContext.TemplateComponentParameters.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of templatecomponentparameterss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of templatecomponentparameterss</returns>/// <exception cref="Exception"></exception>
        public List<TemplateComponentParameters> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTemplateComponentParameters(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new templatecomponentparameters</summary>
        /// <param name="model">The templatecomponentparameters data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TemplateComponentParameters model)
        {
            model.Id = CreateTemplateComponentParameters(model);
            return model.Id;
        }

        /// <summary>Updates a specific templatecomponentparameters by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponentparameters</param>
        /// <param name="updatedEntity">The templatecomponentparameters data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TemplateComponentParameters updatedEntity)
        {
            UpdateTemplateComponentParameters(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific templatecomponentparameters by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponentparameters</param>
        /// <param name="updatedEntity">The templatecomponentparameters data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TemplateComponentParameters> updatedEntity)
        {
            PatchTemplateComponentParameters(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific templatecomponentparameters by its primary key</summary>
        /// <param name="id">The primary key of the templatecomponentparameters</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTemplateComponentParameters(id);
            return true;
        }
        #region
        private List<TemplateComponentParameters> GetTemplateComponentParameters(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TemplateComponentParameters.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TemplateComponentParameters>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TemplateComponentParameters), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TemplateComponentParameters, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTemplateComponentParameters(TemplateComponentParameters model)
        {
            _dbContext.TemplateComponentParameters.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTemplateComponentParameters(Guid id, TemplateComponentParameters updatedEntity)
        {
            _dbContext.TemplateComponentParameters.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTemplateComponentParameters(Guid id)
        {
            var entityData = _dbContext.TemplateComponentParameters.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TemplateComponentParameters.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTemplateComponentParameters(Guid id, JsonPatchDocument<TemplateComponentParameters> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TemplateComponentParameters.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TemplateComponentParameters.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}