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
    /// The productpackageService responsible for managing productpackage related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productpackage information.
    /// </remarks>
    public interface IProductPackageService
    {
        /// <summary>Retrieves a specific productpackage by its primary key</summary>
        /// <param name="id">The primary key of the productpackage</param>
        /// <returns>The productpackage data</returns>
        ProductPackage GetById(Guid id);

        /// <summary>Retrieves a list of productpackages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productpackages</returns>
        List<ProductPackage> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new productpackage</summary>
        /// <param name="model">The productpackage data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProductPackage model);

        /// <summary>Updates a specific productpackage by its primary key</summary>
        /// <param name="id">The primary key of the productpackage</param>
        /// <param name="updatedEntity">The productpackage data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProductPackage updatedEntity);

        /// <summary>Updates a specific productpackage by its primary key</summary>
        /// <param name="id">The primary key of the productpackage</param>
        /// <param name="updatedEntity">The productpackage data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProductPackage> updatedEntity);

        /// <summary>Deletes a specific productpackage by its primary key</summary>
        /// <param name="id">The primary key of the productpackage</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The productpackageService responsible for managing productpackage related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productpackage information.
    /// </remarks>
    public class ProductPackageService : IProductPackageService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProductPackage class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProductPackageService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific productpackage by its primary key</summary>
        /// <param name="id">The primary key of the productpackage</param>
        /// <returns>The productpackage data</returns>
        public ProductPackage GetById(Guid id)
        {
            var entityData = _dbContext.ProductPackage.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of productpackages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productpackages</returns>/// <exception cref="Exception"></exception>
        public List<ProductPackage> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProductPackage(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new productpackage</summary>
        /// <param name="model">The productpackage data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProductPackage model)
        {
            model.Id = CreateProductPackage(model);
            return model.Id;
        }

        /// <summary>Updates a specific productpackage by its primary key</summary>
        /// <param name="id">The primary key of the productpackage</param>
        /// <param name="updatedEntity">The productpackage data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProductPackage updatedEntity)
        {
            UpdateProductPackage(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific productpackage by its primary key</summary>
        /// <param name="id">The primary key of the productpackage</param>
        /// <param name="updatedEntity">The productpackage data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProductPackage> updatedEntity)
        {
            PatchProductPackage(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific productpackage by its primary key</summary>
        /// <param name="id">The primary key of the productpackage</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProductPackage(id);
            return true;
        }
        #region
        private List<ProductPackage> GetProductPackage(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProductPackage.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProductPackage>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProductPackage), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProductPackage, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProductPackage(ProductPackage model)
        {
            _dbContext.ProductPackage.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProductPackage(Guid id, ProductPackage updatedEntity)
        {
            _dbContext.ProductPackage.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProductPackage(Guid id)
        {
            var entityData = _dbContext.ProductPackage.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProductPackage.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProductPackage(Guid id, JsonPatchDocument<ProductPackage> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProductPackage.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProductPackage.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}