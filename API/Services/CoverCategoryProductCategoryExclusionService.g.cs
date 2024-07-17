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
    /// The covercategoryproductcategoryexclusionService responsible for managing covercategoryproductcategoryexclusion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covercategoryproductcategoryexclusion information.
    /// </remarks>
    public interface ICoverCategoryProductCategoryExclusionService
    {
        /// <summary>Retrieves a specific covercategoryproductcategoryexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryproductcategoryexclusion</param>
        /// <returns>The covercategoryproductcategoryexclusion data</returns>
        CoverCategoryProductCategoryExclusion GetById(Guid id);

        /// <summary>Retrieves a list of covercategoryproductcategoryexclusions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covercategoryproductcategoryexclusions</returns>
        List<CoverCategoryProductCategoryExclusion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new covercategoryproductcategoryexclusion</summary>
        /// <param name="model">The covercategoryproductcategoryexclusion data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CoverCategoryProductCategoryExclusion model);

        /// <summary>Updates a specific covercategoryproductcategoryexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryproductcategoryexclusion</param>
        /// <param name="updatedEntity">The covercategoryproductcategoryexclusion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CoverCategoryProductCategoryExclusion updatedEntity);

        /// <summary>Updates a specific covercategoryproductcategoryexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryproductcategoryexclusion</param>
        /// <param name="updatedEntity">The covercategoryproductcategoryexclusion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CoverCategoryProductCategoryExclusion> updatedEntity);

        /// <summary>Deletes a specific covercategoryproductcategoryexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryproductcategoryexclusion</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The covercategoryproductcategoryexclusionService responsible for managing covercategoryproductcategoryexclusion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covercategoryproductcategoryexclusion information.
    /// </remarks>
    public class CoverCategoryProductCategoryExclusionService : ICoverCategoryProductCategoryExclusionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CoverCategoryProductCategoryExclusion class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CoverCategoryProductCategoryExclusionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific covercategoryproductcategoryexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryproductcategoryexclusion</param>
        /// <returns>The covercategoryproductcategoryexclusion data</returns>
        public CoverCategoryProductCategoryExclusion GetById(Guid id)
        {
            var entityData = _dbContext.CoverCategoryProductCategoryExclusion.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of covercategoryproductcategoryexclusions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covercategoryproductcategoryexclusions</returns>/// <exception cref="Exception"></exception>
        public List<CoverCategoryProductCategoryExclusion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCoverCategoryProductCategoryExclusion(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new covercategoryproductcategoryexclusion</summary>
        /// <param name="model">The covercategoryproductcategoryexclusion data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CoverCategoryProductCategoryExclusion model)
        {
            model.Id = CreateCoverCategoryProductCategoryExclusion(model);
            return model.Id;
        }

        /// <summary>Updates a specific covercategoryproductcategoryexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryproductcategoryexclusion</param>
        /// <param name="updatedEntity">The covercategoryproductcategoryexclusion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CoverCategoryProductCategoryExclusion updatedEntity)
        {
            UpdateCoverCategoryProductCategoryExclusion(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific covercategoryproductcategoryexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryproductcategoryexclusion</param>
        /// <param name="updatedEntity">The covercategoryproductcategoryexclusion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CoverCategoryProductCategoryExclusion> updatedEntity)
        {
            PatchCoverCategoryProductCategoryExclusion(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific covercategoryproductcategoryexclusion by its primary key</summary>
        /// <param name="id">The primary key of the covercategoryproductcategoryexclusion</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCoverCategoryProductCategoryExclusion(id);
            return true;
        }
        #region
        private List<CoverCategoryProductCategoryExclusion> GetCoverCategoryProductCategoryExclusion(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CoverCategoryProductCategoryExclusion.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CoverCategoryProductCategoryExclusion>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CoverCategoryProductCategoryExclusion), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CoverCategoryProductCategoryExclusion, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCoverCategoryProductCategoryExclusion(CoverCategoryProductCategoryExclusion model)
        {
            _dbContext.CoverCategoryProductCategoryExclusion.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCoverCategoryProductCategoryExclusion(Guid id, CoverCategoryProductCategoryExclusion updatedEntity)
        {
            _dbContext.CoverCategoryProductCategoryExclusion.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCoverCategoryProductCategoryExclusion(Guid id)
        {
            var entityData = _dbContext.CoverCategoryProductCategoryExclusion.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CoverCategoryProductCategoryExclusion.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCoverCategoryProductCategoryExclusion(Guid id, JsonPatchDocument<CoverCategoryProductCategoryExclusion> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CoverCategoryProductCategoryExclusion.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CoverCategoryProductCategoryExclusion.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}