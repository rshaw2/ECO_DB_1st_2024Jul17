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
    /// The covercategoryService responsible for managing covercategory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covercategory information.
    /// </remarks>
    public interface ICoverCategoryService
    {
        /// <summary>Retrieves a specific covercategory by its primary key</summary>
        /// <param name="id">The primary key of the covercategory</param>
        /// <returns>The covercategory data</returns>
        CoverCategory GetById(Guid id);

        /// <summary>Retrieves a list of covercategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covercategorys</returns>
        List<CoverCategory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new covercategory</summary>
        /// <param name="model">The covercategory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CoverCategory model);

        /// <summary>Updates a specific covercategory by its primary key</summary>
        /// <param name="id">The primary key of the covercategory</param>
        /// <param name="updatedEntity">The covercategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CoverCategory updatedEntity);

        /// <summary>Updates a specific covercategory by its primary key</summary>
        /// <param name="id">The primary key of the covercategory</param>
        /// <param name="updatedEntity">The covercategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CoverCategory> updatedEntity);

        /// <summary>Deletes a specific covercategory by its primary key</summary>
        /// <param name="id">The primary key of the covercategory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The covercategoryService responsible for managing covercategory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covercategory information.
    /// </remarks>
    public class CoverCategoryService : ICoverCategoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CoverCategory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CoverCategoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific covercategory by its primary key</summary>
        /// <param name="id">The primary key of the covercategory</param>
        /// <returns>The covercategory data</returns>
        public CoverCategory GetById(Guid id)
        {
            var entityData = _dbContext.CoverCategory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of covercategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covercategorys</returns>/// <exception cref="Exception"></exception>
        public List<CoverCategory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCoverCategory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new covercategory</summary>
        /// <param name="model">The covercategory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CoverCategory model)
        {
            model.Id = CreateCoverCategory(model);
            return model.Id;
        }

        /// <summary>Updates a specific covercategory by its primary key</summary>
        /// <param name="id">The primary key of the covercategory</param>
        /// <param name="updatedEntity">The covercategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CoverCategory updatedEntity)
        {
            UpdateCoverCategory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific covercategory by its primary key</summary>
        /// <param name="id">The primary key of the covercategory</param>
        /// <param name="updatedEntity">The covercategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CoverCategory> updatedEntity)
        {
            PatchCoverCategory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific covercategory by its primary key</summary>
        /// <param name="id">The primary key of the covercategory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCoverCategory(id);
            return true;
        }
        #region
        private List<CoverCategory> GetCoverCategory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CoverCategory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CoverCategory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CoverCategory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CoverCategory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCoverCategory(CoverCategory model)
        {
            _dbContext.CoverCategory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCoverCategory(Guid id, CoverCategory updatedEntity)
        {
            _dbContext.CoverCategory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCoverCategory(Guid id)
        {
            var entityData = _dbContext.CoverCategory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CoverCategory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCoverCategory(Guid id, JsonPatchDocument<CoverCategory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CoverCategory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CoverCategory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}