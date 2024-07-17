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
    /// The productuomService responsible for managing productuom related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productuom information.
    /// </remarks>
    public interface IProductUomService
    {
        /// <summary>Retrieves a specific productuom by its primary key</summary>
        /// <param name="id">The primary key of the productuom</param>
        /// <returns>The productuom data</returns>
        ProductUom GetById(Guid id);

        /// <summary>Retrieves a list of productuoms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productuoms</returns>
        List<ProductUom> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new productuom</summary>
        /// <param name="model">The productuom data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProductUom model);

        /// <summary>Updates a specific productuom by its primary key</summary>
        /// <param name="id">The primary key of the productuom</param>
        /// <param name="updatedEntity">The productuom data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProductUom updatedEntity);

        /// <summary>Updates a specific productuom by its primary key</summary>
        /// <param name="id">The primary key of the productuom</param>
        /// <param name="updatedEntity">The productuom data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProductUom> updatedEntity);

        /// <summary>Deletes a specific productuom by its primary key</summary>
        /// <param name="id">The primary key of the productuom</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The productuomService responsible for managing productuom related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productuom information.
    /// </remarks>
    public class ProductUomService : IProductUomService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProductUom class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProductUomService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific productuom by its primary key</summary>
        /// <param name="id">The primary key of the productuom</param>
        /// <returns>The productuom data</returns>
        public ProductUom GetById(Guid id)
        {
            var entityData = _dbContext.ProductUom.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of productuoms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productuoms</returns>/// <exception cref="Exception"></exception>
        public List<ProductUom> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProductUom(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new productuom</summary>
        /// <param name="model">The productuom data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProductUom model)
        {
            model.Id = CreateProductUom(model);
            return model.Id;
        }

        /// <summary>Updates a specific productuom by its primary key</summary>
        /// <param name="id">The primary key of the productuom</param>
        /// <param name="updatedEntity">The productuom data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProductUom updatedEntity)
        {
            UpdateProductUom(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific productuom by its primary key</summary>
        /// <param name="id">The primary key of the productuom</param>
        /// <param name="updatedEntity">The productuom data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProductUom> updatedEntity)
        {
            PatchProductUom(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific productuom by its primary key</summary>
        /// <param name="id">The primary key of the productuom</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProductUom(id);
            return true;
        }
        #region
        private List<ProductUom> GetProductUom(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProductUom.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProductUom>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProductUom), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProductUom, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProductUom(ProductUom model)
        {
            _dbContext.ProductUom.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProductUom(Guid id, ProductUom updatedEntity)
        {
            _dbContext.ProductUom.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProductUom(Guid id)
        {
            var entityData = _dbContext.ProductUom.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProductUom.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProductUom(Guid id, JsonPatchDocument<ProductUom> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProductUom.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProductUom.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}