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
    /// The allergytemplateparameterService responsible for managing allergytemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergytemplateparameter information.
    /// </remarks>
    public interface IAllergyTemplateParameterService
    {
        /// <summary>Retrieves a specific allergytemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplateparameter</param>
        /// <returns>The allergytemplateparameter data</returns>
        AllergyTemplateParameter GetById(Guid id);

        /// <summary>Retrieves a list of allergytemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergytemplateparameters</returns>
        List<AllergyTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new allergytemplateparameter</summary>
        /// <param name="model">The allergytemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AllergyTemplateParameter model);

        /// <summary>Updates a specific allergytemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplateparameter</param>
        /// <param name="updatedEntity">The allergytemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AllergyTemplateParameter updatedEntity);

        /// <summary>Updates a specific allergytemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplateparameter</param>
        /// <param name="updatedEntity">The allergytemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AllergyTemplateParameter> updatedEntity);

        /// <summary>Deletes a specific allergytemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplateparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The allergytemplateparameterService responsible for managing allergytemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergytemplateparameter information.
    /// </remarks>
    public class AllergyTemplateParameterService : IAllergyTemplateParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AllergyTemplateParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AllergyTemplateParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific allergytemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplateparameter</param>
        /// <returns>The allergytemplateparameter data</returns>
        public AllergyTemplateParameter GetById(Guid id)
        {
            var entityData = _dbContext.AllergyTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of allergytemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergytemplateparameters</returns>/// <exception cref="Exception"></exception>
        public List<AllergyTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAllergyTemplateParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new allergytemplateparameter</summary>
        /// <param name="model">The allergytemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AllergyTemplateParameter model)
        {
            model.Id = CreateAllergyTemplateParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific allergytemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplateparameter</param>
        /// <param name="updatedEntity">The allergytemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AllergyTemplateParameter updatedEntity)
        {
            UpdateAllergyTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific allergytemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplateparameter</param>
        /// <param name="updatedEntity">The allergytemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AllergyTemplateParameter> updatedEntity)
        {
            PatchAllergyTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific allergytemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the allergytemplateparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAllergyTemplateParameter(id);
            return true;
        }
        #region
        private List<AllergyTemplateParameter> GetAllergyTemplateParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AllergyTemplateParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AllergyTemplateParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AllergyTemplateParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AllergyTemplateParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAllergyTemplateParameter(AllergyTemplateParameter model)
        {
            _dbContext.AllergyTemplateParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAllergyTemplateParameter(Guid id, AllergyTemplateParameter updatedEntity)
        {
            _dbContext.AllergyTemplateParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAllergyTemplateParameter(Guid id)
        {
            var entityData = _dbContext.AllergyTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AllergyTemplateParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAllergyTemplateParameter(Guid id, JsonPatchDocument<AllergyTemplateParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AllergyTemplateParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AllergyTemplateParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}