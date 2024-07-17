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
    /// The guidelinetranslationService responsible for managing guidelinetranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guidelinetranslation information.
    /// </remarks>
    public interface IGuidelineTranslationService
    {
        /// <summary>Retrieves a specific guidelinetranslation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslation</param>
        /// <returns>The guidelinetranslation data</returns>
        GuidelineTranslation GetById(Guid id);

        /// <summary>Retrieves a list of guidelinetranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinetranslations</returns>
        List<GuidelineTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new guidelinetranslation</summary>
        /// <param name="model">The guidelinetranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(GuidelineTranslation model);

        /// <summary>Updates a specific guidelinetranslation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslation</param>
        /// <param name="updatedEntity">The guidelinetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GuidelineTranslation updatedEntity);

        /// <summary>Updates a specific guidelinetranslation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslation</param>
        /// <param name="updatedEntity">The guidelinetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GuidelineTranslation> updatedEntity);

        /// <summary>Deletes a specific guidelinetranslation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The guidelinetranslationService responsible for managing guidelinetranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guidelinetranslation information.
    /// </remarks>
    public class GuidelineTranslationService : IGuidelineTranslationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GuidelineTranslation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GuidelineTranslationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific guidelinetranslation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslation</param>
        /// <returns>The guidelinetranslation data</returns>
        public GuidelineTranslation GetById(Guid id)
        {
            var entityData = _dbContext.GuidelineTranslation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of guidelinetranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinetranslations</returns>/// <exception cref="Exception"></exception>
        public List<GuidelineTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGuidelineTranslation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new guidelinetranslation</summary>
        /// <param name="model">The guidelinetranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(GuidelineTranslation model)
        {
            model.Id = CreateGuidelineTranslation(model);
            return model.Id;
        }

        /// <summary>Updates a specific guidelinetranslation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslation</param>
        /// <param name="updatedEntity">The guidelinetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GuidelineTranslation updatedEntity)
        {
            UpdateGuidelineTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific guidelinetranslation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslation</param>
        /// <param name="updatedEntity">The guidelinetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GuidelineTranslation> updatedEntity)
        {
            PatchGuidelineTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific guidelinetranslation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGuidelineTranslation(id);
            return true;
        }
        #region
        private List<GuidelineTranslation> GetGuidelineTranslation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GuidelineTranslation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GuidelineTranslation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GuidelineTranslation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GuidelineTranslation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGuidelineTranslation(GuidelineTranslation model)
        {
            _dbContext.GuidelineTranslation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGuidelineTranslation(Guid id, GuidelineTranslation updatedEntity)
        {
            _dbContext.GuidelineTranslation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGuidelineTranslation(Guid id)
        {
            var entityData = _dbContext.GuidelineTranslation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GuidelineTranslation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGuidelineTranslation(Guid id, JsonPatchDocument<GuidelineTranslation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GuidelineTranslation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GuidelineTranslation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}