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
    /// The covercategoryclinicexclusionService responsible for managing covercategoryclinicexclusion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covercategoryclinicexclusion information.
    /// </remarks>
    public interface ICoverCategoryClinicExclusionService
    {
        /// <summary>Retrieves a specific covercategoryclinicexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryclinicexclusion</param>
        /// <returns>The covercategoryclinicexclusion data</returns>
        CoverCategoryClinicExclusion GetById(Guid id);

        /// <summary>Retrieves a list of covercategoryclinicexclusions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covercategoryclinicexclusions</returns>
        List<CoverCategoryClinicExclusion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new covercategoryclinicexclusion</summary>
        /// <param name="model">The covercategoryclinicexclusion data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CoverCategoryClinicExclusion model);

        /// <summary>Updates a specific covercategoryclinicexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryclinicexclusion</param>
        /// <param name="updatedEntity">The covercategoryclinicexclusion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CoverCategoryClinicExclusion updatedEntity);

        /// <summary>Updates a specific covercategoryclinicexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryclinicexclusion</param>
        /// <param name="updatedEntity">The covercategoryclinicexclusion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CoverCategoryClinicExclusion> updatedEntity);

        /// <summary>Deletes a specific covercategoryclinicexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryclinicexclusion</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The covercategoryclinicexclusionService responsible for managing covercategoryclinicexclusion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covercategoryclinicexclusion information.
    /// </remarks>
    public class CoverCategoryClinicExclusionService : ICoverCategoryClinicExclusionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CoverCategoryClinicExclusion class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CoverCategoryClinicExclusionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific covercategoryclinicexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryclinicexclusion</param>
        /// <returns>The covercategoryclinicexclusion data</returns>
        public CoverCategoryClinicExclusion GetById(Guid id)
        {
            var entityData = _dbContext.CoverCategoryClinicExclusion.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of covercategoryclinicexclusions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covercategoryclinicexclusions</returns>/// <exception cref="Exception"></exception>
        public List<CoverCategoryClinicExclusion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCoverCategoryClinicExclusion(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new covercategoryclinicexclusion</summary>
        /// <param name="model">The covercategoryclinicexclusion data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CoverCategoryClinicExclusion model)
        {
            model.Id = CreateCoverCategoryClinicExclusion(model);
            return model.Id;
        }

        /// <summary>Updates a specific covercategoryclinicexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryclinicexclusion</param>
        /// <param name="updatedEntity">The covercategoryclinicexclusion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CoverCategoryClinicExclusion updatedEntity)
        {
            UpdateCoverCategoryClinicExclusion(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific covercategoryclinicexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryclinicexclusion</param>
        /// <param name="updatedEntity">The covercategoryclinicexclusion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CoverCategoryClinicExclusion> updatedEntity)
        {
            PatchCoverCategoryClinicExclusion(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific covercategoryclinicexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryclinicexclusion</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCoverCategoryClinicExclusion(id);
            return true;
        }
        #region
        private List<CoverCategoryClinicExclusion> GetCoverCategoryClinicExclusion(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CoverCategoryClinicExclusion.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CoverCategoryClinicExclusion>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CoverCategoryClinicExclusion), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CoverCategoryClinicExclusion, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCoverCategoryClinicExclusion(CoverCategoryClinicExclusion model)
        {
            _dbContext.CoverCategoryClinicExclusion.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCoverCategoryClinicExclusion(Guid id, CoverCategoryClinicExclusion updatedEntity)
        {
            _dbContext.CoverCategoryClinicExclusion.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCoverCategoryClinicExclusion(Guid id)
        {
            var entityData = _dbContext.CoverCategoryClinicExclusion.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CoverCategoryClinicExclusion.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCoverCategoryClinicExclusion(Guid id, JsonPatchDocument<CoverCategoryClinicExclusion> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CoverCategoryClinicExclusion.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CoverCategoryClinicExclusion.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}