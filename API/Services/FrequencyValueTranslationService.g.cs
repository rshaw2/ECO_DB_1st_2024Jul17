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
    /// The frequencyvaluetranslationService responsible for managing frequencyvaluetranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting frequencyvaluetranslation information.
    /// </remarks>
    public interface IFrequencyValueTranslationService
    {
        /// <summary>Retrieves a specific frequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvaluetranslation</param>
        /// <returns>The frequencyvaluetranslation data</returns>
        FrequencyValueTranslation GetById(Guid id);

        /// <summary>Retrieves a list of frequencyvaluetranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of frequencyvaluetranslations</returns>
        List<FrequencyValueTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new frequencyvaluetranslation</summary>
        /// <param name="model">The frequencyvaluetranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(FrequencyValueTranslation model);

        /// <summary>Updates a specific frequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvaluetranslation</param>
        /// <param name="updatedEntity">The frequencyvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, FrequencyValueTranslation updatedEntity);

        /// <summary>Updates a specific frequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvaluetranslation</param>
        /// <param name="updatedEntity">The frequencyvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<FrequencyValueTranslation> updatedEntity);

        /// <summary>Deletes a specific frequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvaluetranslation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The frequencyvaluetranslationService responsible for managing frequencyvaluetranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting frequencyvaluetranslation information.
    /// </remarks>
    public class FrequencyValueTranslationService : IFrequencyValueTranslationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the FrequencyValueTranslation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public FrequencyValueTranslationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific frequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvaluetranslation</param>
        /// <returns>The frequencyvaluetranslation data</returns>
        public FrequencyValueTranslation GetById(Guid id)
        {
            var entityData = _dbContext.FrequencyValueTranslation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of frequencyvaluetranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of frequencyvaluetranslations</returns>/// <exception cref="Exception"></exception>
        public List<FrequencyValueTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetFrequencyValueTranslation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new frequencyvaluetranslation</summary>
        /// <param name="model">The frequencyvaluetranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(FrequencyValueTranslation model)
        {
            model.Id = CreateFrequencyValueTranslation(model);
            return model.Id;
        }

        /// <summary>Updates a specific frequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvaluetranslation</param>
        /// <param name="updatedEntity">The frequencyvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, FrequencyValueTranslation updatedEntity)
        {
            UpdateFrequencyValueTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific frequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvaluetranslation</param>
        /// <param name="updatedEntity">The frequencyvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<FrequencyValueTranslation> updatedEntity)
        {
            PatchFrequencyValueTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific frequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvaluetranslation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteFrequencyValueTranslation(id);
            return true;
        }
        #region
        private List<FrequencyValueTranslation> GetFrequencyValueTranslation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.FrequencyValueTranslation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<FrequencyValueTranslation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(FrequencyValueTranslation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<FrequencyValueTranslation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateFrequencyValueTranslation(FrequencyValueTranslation model)
        {
            _dbContext.FrequencyValueTranslation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateFrequencyValueTranslation(Guid id, FrequencyValueTranslation updatedEntity)
        {
            _dbContext.FrequencyValueTranslation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteFrequencyValueTranslation(Guid id)
        {
            var entityData = _dbContext.FrequencyValueTranslation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.FrequencyValueTranslation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchFrequencyValueTranslation(Guid id, JsonPatchDocument<FrequencyValueTranslation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.FrequencyValueTranslation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.FrequencyValueTranslation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}