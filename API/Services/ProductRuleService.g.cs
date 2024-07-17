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
    /// The productruleService responsible for managing productrule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productrule information.
    /// </remarks>
    public interface IProductRuleService
    {
        /// <summary>Retrieves a specific productrule by its primary key</summary>
        /// <param name="id">The primary key of the productrule</param>
        /// <returns>The productrule data</returns>
        ProductRule GetById(Guid id);

        /// <summary>Retrieves a list of productrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productrules</returns>
        List<ProductRule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new productrule</summary>
        /// <param name="model">The productrule data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProductRule model);

        /// <summary>Updates a specific productrule by its primary key</summary>
        /// <param name="id">The primary key of the productrule</param>
        /// <param name="updatedEntity">The productrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProductRule updatedEntity);

        /// <summary>Updates a specific productrule by its primary key</summary>
        /// <param name="id">The primary key of the productrule</param>
        /// <param name="updatedEntity">The productrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProductRule> updatedEntity);

        /// <summary>Deletes a specific productrule by its primary key</summary>
        /// <param name="id">The primary key of the productrule</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The productruleService responsible for managing productrule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productrule information.
    /// </remarks>
    public class ProductRuleService : IProductRuleService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProductRule class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProductRuleService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific productrule by its primary key</summary>
        /// <param name="id">The primary key of the productrule</param>
        /// <returns>The productrule data</returns>
        public ProductRule GetById(Guid id)
        {
            var entityData = _dbContext.ProductRule.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of productrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productrules</returns>/// <exception cref="Exception"></exception>
        public List<ProductRule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProductRule(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new productrule</summary>
        /// <param name="model">The productrule data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProductRule model)
        {
            model.Id = CreateProductRule(model);
            return model.Id;
        }

        /// <summary>Updates a specific productrule by its primary key</summary>
        /// <param name="id">The primary key of the productrule</param>
        /// <param name="updatedEntity">The productrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProductRule updatedEntity)
        {
            UpdateProductRule(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific productrule by its primary key</summary>
        /// <param name="id">The primary key of the productrule</param>
        /// <param name="updatedEntity">The productrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProductRule> updatedEntity)
        {
            PatchProductRule(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific productrule by its primary key</summary>
        /// <param name="id">The primary key of the productrule</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProductRule(id);
            return true;
        }
        #region
        private List<ProductRule> GetProductRule(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProductRule.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProductRule>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProductRule), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProductRule, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProductRule(ProductRule model)
        {
            _dbContext.ProductRule.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProductRule(Guid id, ProductRule updatedEntity)
        {
            _dbContext.ProductRule.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProductRule(Guid id)
        {
            var entityData = _dbContext.ProductRule.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProductRule.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProductRule(Guid id, JsonPatchDocument<ProductRule> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProductRule.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProductRule.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}