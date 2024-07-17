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
    /// The guidelinetranslationdeviationService responsible for managing guidelinetranslationdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guidelinetranslationdeviation information.
    /// </remarks>
    public interface IGuidelineTranslationDeviationService
    {
        /// <summary>Retrieves a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <returns>The guidelinetranslationdeviation data</returns>
        GuidelineTranslationDeviation GetById(Guid id);

        /// <summary>Retrieves a list of guidelinetranslationdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinetranslationdeviations</returns>
        List<GuidelineTranslationDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new guidelinetranslationdeviation</summary>
        /// <param name="model">The guidelinetranslationdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(GuidelineTranslationDeviation model);

        /// <summary>Updates a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <param name="updatedEntity">The guidelinetranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GuidelineTranslationDeviation updatedEntity);

        /// <summary>Updates a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <param name="updatedEntity">The guidelinetranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GuidelineTranslationDeviation> updatedEntity);

        /// <summary>Deletes a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The guidelinetranslationdeviationService responsible for managing guidelinetranslationdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guidelinetranslationdeviation information.
    /// </remarks>
    public class GuidelineTranslationDeviationService : IGuidelineTranslationDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GuidelineTranslationDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GuidelineTranslationDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <returns>The guidelinetranslationdeviation data</returns>
        public GuidelineTranslationDeviation GetById(Guid id)
        {
            var entityData = _dbContext.GuidelineTranslationDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of guidelinetranslationdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinetranslationdeviations</returns>/// <exception cref="Exception"></exception>
        public List<GuidelineTranslationDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGuidelineTranslationDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new guidelinetranslationdeviation</summary>
        /// <param name="model">The guidelinetranslationdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(GuidelineTranslationDeviation model)
        {
            model.Id = CreateGuidelineTranslationDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <param name="updatedEntity">The guidelinetranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GuidelineTranslationDeviation updatedEntity)
        {
            UpdateGuidelineTranslationDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <param name="updatedEntity">The guidelinetranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GuidelineTranslationDeviation> updatedEntity)
        {
            PatchGuidelineTranslationDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific guidelinetranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinetranslationdeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGuidelineTranslationDeviation(id);
            return true;
        }
        #region
        private List<GuidelineTranslationDeviation> GetGuidelineTranslationDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GuidelineTranslationDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GuidelineTranslationDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GuidelineTranslationDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GuidelineTranslationDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGuidelineTranslationDeviation(GuidelineTranslationDeviation model)
        {
            _dbContext.GuidelineTranslationDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGuidelineTranslationDeviation(Guid id, GuidelineTranslationDeviation updatedEntity)
        {
            _dbContext.GuidelineTranslationDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGuidelineTranslationDeviation(Guid id)
        {
            var entityData = _dbContext.GuidelineTranslationDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GuidelineTranslationDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGuidelineTranslationDeviation(Guid id, JsonPatchDocument<GuidelineTranslationDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GuidelineTranslationDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GuidelineTranslationDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}