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
    /// The guidelinesuggestionService responsible for managing guidelinesuggestion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guidelinesuggestion information.
    /// </remarks>
    public interface IGuidelineSuggestionService
    {
        /// <summary>Retrieves a specific guidelinesuggestion by its primary key</summary>
        /// <param name="id">The primary key of the guidelinesuggestion</param>
        /// <returns>The guidelinesuggestion data</returns>
        GuidelineSuggestion GetById(Guid id);

        /// <summary>Retrieves a list of guidelinesuggestions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinesuggestions</returns>
        List<GuidelineSuggestion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new guidelinesuggestion</summary>
        /// <param name="model">The guidelinesuggestion data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(GuidelineSuggestion model);

        /// <summary>Updates a specific guidelinesuggestion by its primary key</summary>
        /// <param name="id">The primary key of the guidelinesuggestion</param>
        /// <param name="updatedEntity">The guidelinesuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GuidelineSuggestion updatedEntity);

        /// <summary>Updates a specific guidelinesuggestion by its primary key</summary>
        /// <param name="id">The primary key of the guidelinesuggestion</param>
        /// <param name="updatedEntity">The guidelinesuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GuidelineSuggestion> updatedEntity);

        /// <summary>Deletes a specific guidelinesuggestion by its primary key</summary>
        /// <param name="id">The primary key of the guidelinesuggestion</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The guidelinesuggestionService responsible for managing guidelinesuggestion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guidelinesuggestion information.
    /// </remarks>
    public class GuidelineSuggestionService : IGuidelineSuggestionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GuidelineSuggestion class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GuidelineSuggestionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific guidelinesuggestion by its primary key</summary>
        /// <param name="id">The primary key of the guidelinesuggestion</param>
        /// <returns>The guidelinesuggestion data</returns>
        public GuidelineSuggestion GetById(Guid id)
        {
            var entityData = _dbContext.GuidelineSuggestion.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of guidelinesuggestions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinesuggestions</returns>/// <exception cref="Exception"></exception>
        public List<GuidelineSuggestion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGuidelineSuggestion(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new guidelinesuggestion</summary>
        /// <param name="model">The guidelinesuggestion data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(GuidelineSuggestion model)
        {
            model.Id = CreateGuidelineSuggestion(model);
            return model.Id;
        }

        /// <summary>Updates a specific guidelinesuggestion by its primary key</summary>
        /// <param name="id">The primary key of the guidelinesuggestion</param>
        /// <param name="updatedEntity">The guidelinesuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GuidelineSuggestion updatedEntity)
        {
            UpdateGuidelineSuggestion(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific guidelinesuggestion by its primary key</summary>
        /// <param name="id">The primary key of the guidelinesuggestion</param>
        /// <param name="updatedEntity">The guidelinesuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GuidelineSuggestion> updatedEntity)
        {
            PatchGuidelineSuggestion(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific guidelinesuggestion by its primary key</summary>
        /// <param name="id">The primary key of the guidelinesuggestion</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGuidelineSuggestion(id);
            return true;
        }
        #region
        private List<GuidelineSuggestion> GetGuidelineSuggestion(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GuidelineSuggestion.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GuidelineSuggestion>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GuidelineSuggestion), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GuidelineSuggestion, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGuidelineSuggestion(GuidelineSuggestion model)
        {
            _dbContext.GuidelineSuggestion.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGuidelineSuggestion(Guid id, GuidelineSuggestion updatedEntity)
        {
            _dbContext.GuidelineSuggestion.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGuidelineSuggestion(Guid id)
        {
            var entityData = _dbContext.GuidelineSuggestion.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GuidelineSuggestion.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGuidelineSuggestion(Guid id, JsonPatchDocument<GuidelineSuggestion> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GuidelineSuggestion.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GuidelineSuggestion.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}