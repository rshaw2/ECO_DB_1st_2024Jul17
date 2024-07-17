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
    /// The lifestylechoicetemplateparameterService responsible for managing lifestylechoicetemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting lifestylechoicetemplateparameter information.
    /// </remarks>
    public interface ILifeStyleChoiceTemplateParameterService
    {
        /// <summary>Retrieves a specific lifestylechoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplateparameter</param>
        /// <returns>The lifestylechoicetemplateparameter data</returns>
        LifeStyleChoiceTemplateParameter GetById(Guid id);

        /// <summary>Retrieves a list of lifestylechoicetemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of lifestylechoicetemplateparameters</returns>
        List<LifeStyleChoiceTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new lifestylechoicetemplateparameter</summary>
        /// <param name="model">The lifestylechoicetemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(LifeStyleChoiceTemplateParameter model);

        /// <summary>Updates a specific lifestylechoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplateparameter</param>
        /// <param name="updatedEntity">The lifestylechoicetemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, LifeStyleChoiceTemplateParameter updatedEntity);

        /// <summary>Updates a specific lifestylechoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplateparameter</param>
        /// <param name="updatedEntity">The lifestylechoicetemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<LifeStyleChoiceTemplateParameter> updatedEntity);

        /// <summary>Deletes a specific lifestylechoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplateparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The lifestylechoicetemplateparameterService responsible for managing lifestylechoicetemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting lifestylechoicetemplateparameter information.
    /// </remarks>
    public class LifeStyleChoiceTemplateParameterService : ILifeStyleChoiceTemplateParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the LifeStyleChoiceTemplateParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public LifeStyleChoiceTemplateParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific lifestylechoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplateparameter</param>
        /// <returns>The lifestylechoicetemplateparameter data</returns>
        public LifeStyleChoiceTemplateParameter GetById(Guid id)
        {
            var entityData = _dbContext.LifeStyleChoiceTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of lifestylechoicetemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of lifestylechoicetemplateparameters</returns>/// <exception cref="Exception"></exception>
        public List<LifeStyleChoiceTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetLifeStyleChoiceTemplateParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new lifestylechoicetemplateparameter</summary>
        /// <param name="model">The lifestylechoicetemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(LifeStyleChoiceTemplateParameter model)
        {
            model.Id = CreateLifeStyleChoiceTemplateParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific lifestylechoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplateparameter</param>
        /// <param name="updatedEntity">The lifestylechoicetemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, LifeStyleChoiceTemplateParameter updatedEntity)
        {
            UpdateLifeStyleChoiceTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific lifestylechoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplateparameter</param>
        /// <param name="updatedEntity">The lifestylechoicetemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<LifeStyleChoiceTemplateParameter> updatedEntity)
        {
            PatchLifeStyleChoiceTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific lifestylechoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the lifestylechoicetemplateparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteLifeStyleChoiceTemplateParameter(id);
            return true;
        }
        #region
        private List<LifeStyleChoiceTemplateParameter> GetLifeStyleChoiceTemplateParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LifeStyleChoiceTemplateParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LifeStyleChoiceTemplateParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LifeStyleChoiceTemplateParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LifeStyleChoiceTemplateParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateLifeStyleChoiceTemplateParameter(LifeStyleChoiceTemplateParameter model)
        {
            _dbContext.LifeStyleChoiceTemplateParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateLifeStyleChoiceTemplateParameter(Guid id, LifeStyleChoiceTemplateParameter updatedEntity)
        {
            _dbContext.LifeStyleChoiceTemplateParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteLifeStyleChoiceTemplateParameter(Guid id)
        {
            var entityData = _dbContext.LifeStyleChoiceTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LifeStyleChoiceTemplateParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchLifeStyleChoiceTemplateParameter(Guid id, JsonPatchDocument<LifeStyleChoiceTemplateParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LifeStyleChoiceTemplateParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LifeStyleChoiceTemplateParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}