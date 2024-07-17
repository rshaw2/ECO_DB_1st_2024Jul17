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
    /// The productcategoryruleService responsible for managing productcategoryrule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productcategoryrule information.
    /// </remarks>
    public interface IProductCategoryRuleService
    {
        /// <summary>Retrieves a specific productcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategoryrule</param>
        /// <returns>The productcategoryrule data</returns>
        ProductCategoryRule GetById(Guid id);

        /// <summary>Retrieves a list of productcategoryrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productcategoryrules</returns>
        List<ProductCategoryRule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new productcategoryrule</summary>
        /// <param name="model">The productcategoryrule data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProductCategoryRule model);

        /// <summary>Updates a specific productcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategoryrule</param>
        /// <param name="updatedEntity">The productcategoryrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProductCategoryRule updatedEntity);

        /// <summary>Updates a specific productcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategoryrule</param>
        /// <param name="updatedEntity">The productcategoryrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProductCategoryRule> updatedEntity);

        /// <summary>Deletes a specific productcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategoryrule</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The productcategoryruleService responsible for managing productcategoryrule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productcategoryrule information.
    /// </remarks>
    public class ProductCategoryRuleService : IProductCategoryRuleService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProductCategoryRule class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProductCategoryRuleService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific productcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategoryrule</param>
        /// <returns>The productcategoryrule data</returns>
        public ProductCategoryRule GetById(Guid id)
        {
            var entityData = _dbContext.ProductCategoryRule.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of productcategoryrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productcategoryrules</returns>/// <exception cref="Exception"></exception>
        public List<ProductCategoryRule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProductCategoryRule(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new productcategoryrule</summary>
        /// <param name="model">The productcategoryrule data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProductCategoryRule model)
        {
            model.Id = CreateProductCategoryRule(model);
            return model.Id;
        }

        /// <summary>Updates a specific productcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategoryrule</param>
        /// <param name="updatedEntity">The productcategoryrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProductCategoryRule updatedEntity)
        {
            UpdateProductCategoryRule(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific productcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategoryrule</param>
        /// <param name="updatedEntity">The productcategoryrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProductCategoryRule> updatedEntity)
        {
            PatchProductCategoryRule(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific productcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategoryrule</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProductCategoryRule(id);
            return true;
        }
        #region
        private List<ProductCategoryRule> GetProductCategoryRule(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProductCategoryRule.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProductCategoryRule>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProductCategoryRule), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProductCategoryRule, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProductCategoryRule(ProductCategoryRule model)
        {
            _dbContext.ProductCategoryRule.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProductCategoryRule(Guid id, ProductCategoryRule updatedEntity)
        {
            _dbContext.ProductCategoryRule.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProductCategoryRule(Guid id)
        {
            var entityData = _dbContext.ProductCategoryRule.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProductCategoryRule.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProductCategoryRule(Guid id, JsonPatchDocument<ProductCategoryRule> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProductCategoryRule.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProductCategoryRule.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}