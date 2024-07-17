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
    /// The productcategorypatientcategoryruleService responsible for managing productcategorypatientcategoryrule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productcategorypatientcategoryrule information.
    /// </remarks>
    public interface IProductCategoryPatientCategoryRuleService
    {
        /// <summary>Retrieves a specific productcategorypatientcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorypatientcategoryrule</param>
        /// <returns>The productcategorypatientcategoryrule data</returns>
        ProductCategoryPatientCategoryRule GetById(Guid id);

        /// <summary>Retrieves a list of productcategorypatientcategoryrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productcategorypatientcategoryrules</returns>
        List<ProductCategoryPatientCategoryRule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new productcategorypatientcategoryrule</summary>
        /// <param name="model">The productcategorypatientcategoryrule data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProductCategoryPatientCategoryRule model);

        /// <summary>Updates a specific productcategorypatientcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorypatientcategoryrule</param>
        /// <param name="updatedEntity">The productcategorypatientcategoryrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProductCategoryPatientCategoryRule updatedEntity);

        /// <summary>Updates a specific productcategorypatientcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorypatientcategoryrule</param>
        /// <param name="updatedEntity">The productcategorypatientcategoryrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProductCategoryPatientCategoryRule> updatedEntity);

        /// <summary>Deletes a specific productcategorypatientcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorypatientcategoryrule</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The productcategorypatientcategoryruleService responsible for managing productcategorypatientcategoryrule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productcategorypatientcategoryrule information.
    /// </remarks>
    public class ProductCategoryPatientCategoryRuleService : IProductCategoryPatientCategoryRuleService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProductCategoryPatientCategoryRule class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProductCategoryPatientCategoryRuleService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific productcategorypatientcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorypatientcategoryrule</param>
        /// <returns>The productcategorypatientcategoryrule data</returns>
        public ProductCategoryPatientCategoryRule GetById(Guid id)
        {
            var entityData = _dbContext.ProductCategoryPatientCategoryRule.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of productcategorypatientcategoryrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productcategorypatientcategoryrules</returns>/// <exception cref="Exception"></exception>
        public List<ProductCategoryPatientCategoryRule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProductCategoryPatientCategoryRule(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new productcategorypatientcategoryrule</summary>
        /// <param name="model">The productcategorypatientcategoryrule data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProductCategoryPatientCategoryRule model)
        {
            model.Id = CreateProductCategoryPatientCategoryRule(model);
            return model.Id;
        }

        /// <summary>Updates a specific productcategorypatientcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorypatientcategoryrule</param>
        /// <param name="updatedEntity">The productcategorypatientcategoryrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProductCategoryPatientCategoryRule updatedEntity)
        {
            UpdateProductCategoryPatientCategoryRule(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific productcategorypatientcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorypatientcategoryrule</param>
        /// <param name="updatedEntity">The productcategorypatientcategoryrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProductCategoryPatientCategoryRule> updatedEntity)
        {
            PatchProductCategoryPatientCategoryRule(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific productcategorypatientcategoryrule by its primary key</summary>
        /// <param name="id">The primary key of the productcategorypatientcategoryrule</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProductCategoryPatientCategoryRule(id);
            return true;
        }
        #region
        private List<ProductCategoryPatientCategoryRule> GetProductCategoryPatientCategoryRule(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProductCategoryPatientCategoryRule.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProductCategoryPatientCategoryRule>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProductCategoryPatientCategoryRule), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProductCategoryPatientCategoryRule, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProductCategoryPatientCategoryRule(ProductCategoryPatientCategoryRule model)
        {
            _dbContext.ProductCategoryPatientCategoryRule.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProductCategoryPatientCategoryRule(Guid id, ProductCategoryPatientCategoryRule updatedEntity)
        {
            _dbContext.ProductCategoryPatientCategoryRule.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProductCategoryPatientCategoryRule(Guid id)
        {
            var entityData = _dbContext.ProductCategoryPatientCategoryRule.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProductCategoryPatientCategoryRule.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProductCategoryPatientCategoryRule(Guid id, JsonPatchDocument<ProductCategoryPatientCategoryRule> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProductCategoryPatientCategoryRule.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProductCategoryPatientCategoryRule.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}