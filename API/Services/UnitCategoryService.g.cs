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
    /// The unitcategoryService responsible for managing unitcategory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting unitcategory information.
    /// </remarks>
    public interface IUnitCategoryService
    {
        /// <summary>Retrieves a specific unitcategory by its primary key</summary>
        /// <param name="id">The primary key of the unitcategory</param>
        /// <returns>The unitcategory data</returns>
        UnitCategory GetById(Guid id);

        /// <summary>Retrieves a list of unitcategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of unitcategorys</returns>
        List<UnitCategory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new unitcategory</summary>
        /// <param name="model">The unitcategory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UnitCategory model);

        /// <summary>Updates a specific unitcategory by its primary key</summary>
        /// <param name="id">The primary key of the unitcategory</param>
        /// <param name="updatedEntity">The unitcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UnitCategory updatedEntity);

        /// <summary>Updates a specific unitcategory by its primary key</summary>
        /// <param name="id">The primary key of the unitcategory</param>
        /// <param name="updatedEntity">The unitcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UnitCategory> updatedEntity);

        /// <summary>Deletes a specific unitcategory by its primary key</summary>
        /// <param name="id">The primary key of the unitcategory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The unitcategoryService responsible for managing unitcategory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting unitcategory information.
    /// </remarks>
    public class UnitCategoryService : IUnitCategoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UnitCategory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UnitCategoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific unitcategory by its primary key</summary>
        /// <param name="id">The primary key of the unitcategory</param>
        /// <returns>The unitcategory data</returns>
        public UnitCategory GetById(Guid id)
        {
            var entityData = _dbContext.UnitCategory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of unitcategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of unitcategorys</returns>/// <exception cref="Exception"></exception>
        public List<UnitCategory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUnitCategory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new unitcategory</summary>
        /// <param name="model">The unitcategory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UnitCategory model)
        {
            model.Id = CreateUnitCategory(model);
            return model.Id;
        }

        /// <summary>Updates a specific unitcategory by its primary key</summary>
        /// <param name="id">The primary key of the unitcategory</param>
        /// <param name="updatedEntity">The unitcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UnitCategory updatedEntity)
        {
            UpdateUnitCategory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific unitcategory by its primary key</summary>
        /// <param name="id">The primary key of the unitcategory</param>
        /// <param name="updatedEntity">The unitcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UnitCategory> updatedEntity)
        {
            PatchUnitCategory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific unitcategory by its primary key</summary>
        /// <param name="id">The primary key of the unitcategory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUnitCategory(id);
            return true;
        }
        #region
        private List<UnitCategory> GetUnitCategory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UnitCategory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UnitCategory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UnitCategory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UnitCategory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUnitCategory(UnitCategory model)
        {
            _dbContext.UnitCategory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUnitCategory(Guid id, UnitCategory updatedEntity)
        {
            _dbContext.UnitCategory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUnitCategory(Guid id)
        {
            var entityData = _dbContext.UnitCategory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UnitCategory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUnitCategory(Guid id, JsonPatchDocument<UnitCategory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UnitCategory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UnitCategory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}