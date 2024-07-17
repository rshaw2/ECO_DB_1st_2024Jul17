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
    /// The productcategorygenderruleService responsible for managing productcategorygenderrule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productcategorygenderrule information.
    /// </remarks>
    public interface IProductCategoryGenderRuleService
    {
        /// <summary>Retrieves a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <returns>The productcategorygenderrule data</returns>
        ProductCategoryGenderRule GetById(Guid id);

        /// <summary>Retrieves a list of productcategorygenderrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productcategorygenderrules</returns>
        List<ProductCategoryGenderRule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new productcategorygenderrule</summary>
        /// <param name="model">The productcategorygenderrule data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProductCategoryGenderRule model);

        /// <summary>Updates a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <param name="updatedEntity">The productcategorygenderrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProductCategoryGenderRule updatedEntity);

        /// <summary>Updates a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <param name="updatedEntity">The productcategorygenderrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProductCategoryGenderRule> updatedEntity);

        /// <summary>Deletes a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The productcategorygenderruleService responsible for managing productcategorygenderrule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productcategorygenderrule information.
    /// </remarks>
    public class ProductCategoryGenderRuleService : IProductCategoryGenderRuleService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProductCategoryGenderRule class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProductCategoryGenderRuleService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <returns>The productcategorygenderrule data</returns>
        public ProductCategoryGenderRule GetById(Guid id)
        {
            var entityData = _dbContext.ProductCategoryGenderRule.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of productcategorygenderrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productcategorygenderrules</returns>/// <exception cref="Exception"></exception>
        public List<ProductCategoryGenderRule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProductCategoryGenderRule(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new productcategorygenderrule</summary>
        /// <param name="model">The productcategorygenderrule data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProductCategoryGenderRule model)
        {
            model.Id = CreateProductCategoryGenderRule(model);
            return model.Id;
        }

        /// <summary>Updates a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <param name="updatedEntity">The productcategorygenderrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProductCategoryGenderRule updatedEntity)
        {
            UpdateProductCategoryGenderRule(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <param name="updatedEntity">The productcategorygenderrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProductCategoryGenderRule> updatedEntity)
        {
            PatchProductCategoryGenderRule(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific productcategorygenderrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorygenderrule</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProductCategoryGenderRule(id);
            return true;
        }
        #region
        private List<ProductCategoryGenderRule> GetProductCategoryGenderRule(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProductCategoryGenderRule.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProductCategoryGenderRule>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProductCategoryGenderRule), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProductCategoryGenderRule, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProductCategoryGenderRule(ProductCategoryGenderRule model)
        {
            _dbContext.ProductCategoryGenderRule.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProductCategoryGenderRule(Guid id, ProductCategoryGenderRule updatedEntity)
        {
            _dbContext.ProductCategoryGenderRule.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProductCategoryGenderRule(Guid id)
        {
            var entityData = _dbContext.ProductCategoryGenderRule.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProductCategoryGenderRule.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProductCategoryGenderRule(Guid id, JsonPatchDocument<ProductCategoryGenderRule> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProductCategoryGenderRule.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProductCategoryGenderRule.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}