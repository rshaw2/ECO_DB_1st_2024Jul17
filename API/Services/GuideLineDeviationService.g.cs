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
    /// The guidelinedeviationService responsible for managing guidelinedeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guidelinedeviation information.
    /// </remarks>
    public interface IGuideLineDeviationService
    {
        /// <summary>Retrieves a specific guidelinedeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinedeviation</param>
        /// <returns>The guidelinedeviation data</returns>
        GuideLineDeviation GetById(Guid id);

        /// <summary>Retrieves a list of guidelinedeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinedeviations</returns>
        List<GuideLineDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new guidelinedeviation</summary>
        /// <param name="model">The guidelinedeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(GuideLineDeviation model);

        /// <summary>Updates a specific guidelinedeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinedeviation</param>
        /// <param name="updatedEntity">The guidelinedeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GuideLineDeviation updatedEntity);

        /// <summary>Updates a specific guidelinedeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinedeviation</param>
        /// <param name="updatedEntity">The guidelinedeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GuideLineDeviation> updatedEntity);

        /// <summary>Deletes a specific guidelinedeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinedeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The guidelinedeviationService responsible for managing guidelinedeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guidelinedeviation information.
    /// </remarks>
    public class GuideLineDeviationService : IGuideLineDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GuideLineDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GuideLineDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific guidelinedeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinedeviation</param>
        /// <returns>The guidelinedeviation data</returns>
        public GuideLineDeviation GetById(Guid id)
        {
            var entityData = _dbContext.GuideLineDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of guidelinedeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinedeviations</returns>/// <exception cref="Exception"></exception>
        public List<GuideLineDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGuideLineDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new guidelinedeviation</summary>
        /// <param name="model">The guidelinedeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(GuideLineDeviation model)
        {
            model.Id = CreateGuideLineDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific guidelinedeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinedeviation</param>
        /// <param name="updatedEntity">The guidelinedeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GuideLineDeviation updatedEntity)
        {
            UpdateGuideLineDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific guidelinedeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinedeviation</param>
        /// <param name="updatedEntity">The guidelinedeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GuideLineDeviation> updatedEntity)
        {
            PatchGuideLineDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific guidelinedeviation by its primary key</summary>
        /// <param name="id">The primary key of the guidelinedeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGuideLineDeviation(id);
            return true;
        }
        #region
        private List<GuideLineDeviation> GetGuideLineDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GuideLineDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GuideLineDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GuideLineDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GuideLineDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGuideLineDeviation(GuideLineDeviation model)
        {
            _dbContext.GuideLineDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGuideLineDeviation(Guid id, GuideLineDeviation updatedEntity)
        {
            _dbContext.GuideLineDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGuideLineDeviation(Guid id)
        {
            var entityData = _dbContext.GuideLineDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GuideLineDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGuideLineDeviation(Guid id, JsonPatchDocument<GuideLineDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GuideLineDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GuideLineDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}