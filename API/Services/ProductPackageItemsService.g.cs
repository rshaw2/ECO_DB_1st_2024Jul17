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
    /// The productpackageitemsService responsible for managing productpackageitems related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productpackageitems information.
    /// </remarks>
    public interface IProductPackageItemsService
    {
        /// <summary>Retrieves a specific productpackageitems by its primary key</summary>
        /// <param name="id">The primary key of the productpackageitems</param>
        /// <returns>The productpackageitems data</returns>
        ProductPackageItems GetById(Guid id);

        /// <summary>Retrieves a list of productpackageitemss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productpackageitemss</returns>
        List<ProductPackageItems> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new productpackageitems</summary>
        /// <param name="model">The productpackageitems data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProductPackageItems model);

        /// <summary>Updates a specific productpackageitems by its primary key</summary>
        /// <param name="id">The primary key of the productpackageitems</param>
        /// <param name="updatedEntity">The productpackageitems data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProductPackageItems updatedEntity);

        /// <summary>Updates a specific productpackageitems by its primary key</summary>
        /// <param name="id">The primary key of the productpackageitems</param>
        /// <param name="updatedEntity">The productpackageitems data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProductPackageItems> updatedEntity);

        /// <summary>Deletes a specific productpackageitems by its primary key</summary>
        /// <param name="id">The primary key of the productpackageitems</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The productpackageitemsService responsible for managing productpackageitems related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productpackageitems information.
    /// </remarks>
    public class ProductPackageItemsService : IProductPackageItemsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProductPackageItems class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProductPackageItemsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific productpackageitems by its primary key</summary>
        /// <param name="id">The primary key of the productpackageitems</param>
        /// <returns>The productpackageitems data</returns>
        public ProductPackageItems GetById(Guid id)
        {
            var entityData = _dbContext.ProductPackageItems.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of productpackageitemss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productpackageitemss</returns>/// <exception cref="Exception"></exception>
        public List<ProductPackageItems> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProductPackageItems(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new productpackageitems</summary>
        /// <param name="model">The productpackageitems data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProductPackageItems model)
        {
            model.Id = CreateProductPackageItems(model);
            return model.Id;
        }

        /// <summary>Updates a specific productpackageitems by its primary key</summary>
        /// <param name="id">The primary key of the productpackageitems</param>
        /// <param name="updatedEntity">The productpackageitems data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProductPackageItems updatedEntity)
        {
            UpdateProductPackageItems(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific productpackageitems by its primary key</summary>
        /// <param name="id">The primary key of the productpackageitems</param>
        /// <param name="updatedEntity">The productpackageitems data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProductPackageItems> updatedEntity)
        {
            PatchProductPackageItems(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific productpackageitems by its primary key</summary>
        /// <param name="id">The primary key of the productpackageitems</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProductPackageItems(id);
            return true;
        }
        #region
        private List<ProductPackageItems> GetProductPackageItems(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProductPackageItems.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProductPackageItems>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProductPackageItems), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProductPackageItems, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProductPackageItems(ProductPackageItems model)
        {
            _dbContext.ProductPackageItems.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProductPackageItems(Guid id, ProductPackageItems updatedEntity)
        {
            _dbContext.ProductPackageItems.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProductPackageItems(Guid id)
        {
            var entityData = _dbContext.ProductPackageItems.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProductPackageItems.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProductPackageItems(Guid id, JsonPatchDocument<ProductPackageItems> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProductPackageItems.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProductPackageItems.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}