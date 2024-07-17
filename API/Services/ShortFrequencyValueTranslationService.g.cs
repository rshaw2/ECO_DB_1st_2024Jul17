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
    /// The shortfrequencyvaluetranslationService responsible for managing shortfrequencyvaluetranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting shortfrequencyvaluetranslation information.
    /// </remarks>
    public interface IShortFrequencyValueTranslationService
    {
        /// <summary>Retrieves a specific shortfrequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the shortfrequencyvaluetranslation</param>
        /// <returns>The shortfrequencyvaluetranslation data</returns>
        ShortFrequencyValueTranslation GetById(Guid id);

        /// <summary>Retrieves a list of shortfrequencyvaluetranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of shortfrequencyvaluetranslations</returns>
        List<ShortFrequencyValueTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new shortfrequencyvaluetranslation</summary>
        /// <param name="model">The shortfrequencyvaluetranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ShortFrequencyValueTranslation model);

        /// <summary>Updates a specific shortfrequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the shortfrequencyvaluetranslation</param>
        /// <param name="updatedEntity">The shortfrequencyvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ShortFrequencyValueTranslation updatedEntity);

        /// <summary>Updates a specific shortfrequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the shortfrequencyvaluetranslation</param>
        /// <param name="updatedEntity">The shortfrequencyvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ShortFrequencyValueTranslation> updatedEntity);

        /// <summary>Deletes a specific shortfrequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the shortfrequencyvaluetranslation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The shortfrequencyvaluetranslationService responsible for managing shortfrequencyvaluetranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting shortfrequencyvaluetranslation information.
    /// </remarks>
    public class ShortFrequencyValueTranslationService : IShortFrequencyValueTranslationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ShortFrequencyValueTranslation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ShortFrequencyValueTranslationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific shortfrequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the shortfrequencyvaluetranslation</param>
        /// <returns>The shortfrequencyvaluetranslation data</returns>
        public ShortFrequencyValueTranslation GetById(Guid id)
        {
            var entityData = _dbContext.ShortFrequencyValueTranslation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of shortfrequencyvaluetranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of shortfrequencyvaluetranslations</returns>/// <exception cref="Exception"></exception>
        public List<ShortFrequencyValueTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetShortFrequencyValueTranslation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new shortfrequencyvaluetranslation</summary>
        /// <param name="model">The shortfrequencyvaluetranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ShortFrequencyValueTranslation model)
        {
            model.Id = CreateShortFrequencyValueTranslation(model);
            return model.Id;
        }

        /// <summary>Updates a specific shortfrequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the shortfrequencyvaluetranslation</param>
        /// <param name="updatedEntity">The shortfrequencyvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ShortFrequencyValueTranslation updatedEntity)
        {
            UpdateShortFrequencyValueTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific shortfrequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the shortfrequencyvaluetranslation</param>
        /// <param name="updatedEntity">The shortfrequencyvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ShortFrequencyValueTranslation> updatedEntity)
        {
            PatchShortFrequencyValueTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific shortfrequencyvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the shortfrequencyvaluetranslation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteShortFrequencyValueTranslation(id);
            return true;
        }
        #region
        private List<ShortFrequencyValueTranslation> GetShortFrequencyValueTranslation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ShortFrequencyValueTranslation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ShortFrequencyValueTranslation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ShortFrequencyValueTranslation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ShortFrequencyValueTranslation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateShortFrequencyValueTranslation(ShortFrequencyValueTranslation model)
        {
            _dbContext.ShortFrequencyValueTranslation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateShortFrequencyValueTranslation(Guid id, ShortFrequencyValueTranslation updatedEntity)
        {
            _dbContext.ShortFrequencyValueTranslation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteShortFrequencyValueTranslation(Guid id)
        {
            var entityData = _dbContext.ShortFrequencyValueTranslation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ShortFrequencyValueTranslation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchShortFrequencyValueTranslation(Guid id, JsonPatchDocument<ShortFrequencyValueTranslation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ShortFrequencyValueTranslation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ShortFrequencyValueTranslation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}