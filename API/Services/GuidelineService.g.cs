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
    /// The guidelineService responsible for managing guideline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guideline information.
    /// </remarks>
    public interface IGuidelineService
    {
        /// <summary>Retrieves a specific guideline by its primary key</summary>
        /// <param name="id">The primary key of the guideline</param>
        /// <returns>The guideline data</returns>
        Guideline GetById(Guid id);

        /// <summary>Retrieves a list of guidelines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelines</returns>
        List<Guideline> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new guideline</summary>
        /// <param name="model">The guideline data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Guideline model);

        /// <summary>Updates a specific guideline by its primary key</summary>
        /// <param name="id">The primary key of the guideline</param>
        /// <param name="updatedEntity">The guideline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Guideline updatedEntity);

        /// <summary>Updates a specific guideline by its primary key</summary>
        /// <param name="id">The primary key of the guideline</param>
        /// <param name="updatedEntity">The guideline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Guideline> updatedEntity);

        /// <summary>Deletes a specific guideline by its primary key</summary>
        /// <param name="id">The primary key of the guideline</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The guidelineService responsible for managing guideline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guideline information.
    /// </remarks>
    public class GuidelineService : IGuidelineService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Guideline class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GuidelineService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific guideline by its primary key</summary>
        /// <param name="id">The primary key of the guideline</param>
        /// <returns>The guideline data</returns>
        public Guideline GetById(Guid id)
        {
            var entityData = _dbContext.Guideline.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of guidelines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelines</returns>/// <exception cref="Exception"></exception>
        public List<Guideline> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGuideline(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new guideline</summary>
        /// <param name="model">The guideline data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Guideline model)
        {
            model.Id = CreateGuideline(model);
            return model.Id;
        }

        /// <summary>Updates a specific guideline by its primary key</summary>
        /// <param name="id">The primary key of the guideline</param>
        /// <param name="updatedEntity">The guideline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Guideline updatedEntity)
        {
            UpdateGuideline(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific guideline by its primary key</summary>
        /// <param name="id">The primary key of the guideline</param>
        /// <param name="updatedEntity">The guideline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Guideline> updatedEntity)
        {
            PatchGuideline(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific guideline by its primary key</summary>
        /// <param name="id">The primary key of the guideline</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGuideline(id);
            return true;
        }
        #region
        private List<Guideline> GetGuideline(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Guideline.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Guideline>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Guideline), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Guideline, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGuideline(Guideline model)
        {
            _dbContext.Guideline.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGuideline(Guid id, Guideline updatedEntity)
        {
            _dbContext.Guideline.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGuideline(Guid id)
        {
            var entityData = _dbContext.Guideline.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Guideline.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGuideline(Guid id, JsonPatchDocument<Guideline> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Guideline.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Guideline.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}