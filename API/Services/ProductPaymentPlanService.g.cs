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
    /// The productpaymentplanService responsible for managing productpaymentplan related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productpaymentplan information.
    /// </remarks>
    public interface IProductPaymentPlanService
    {
        /// <summary>Retrieves a specific productpaymentplan by its primary key</summary>
        /// <param name="id">The primary key of the productpaymentplan</param>
        /// <returns>The productpaymentplan data</returns>
        ProductPaymentPlan GetById(Guid id);

        /// <summary>Retrieves a list of productpaymentplans based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productpaymentplans</returns>
        List<ProductPaymentPlan> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new productpaymentplan</summary>
        /// <param name="model">The productpaymentplan data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProductPaymentPlan model);

        /// <summary>Updates a specific productpaymentplan by its primary key</summary>
        /// <param name="id">The primary key of the productpaymentplan</param>
        /// <param name="updatedEntity">The productpaymentplan data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProductPaymentPlan updatedEntity);

        /// <summary>Updates a specific productpaymentplan by its primary key</summary>
        /// <param name="id">The primary key of the productpaymentplan</param>
        /// <param name="updatedEntity">The productpaymentplan data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProductPaymentPlan> updatedEntity);

        /// <summary>Deletes a specific productpaymentplan by its primary key</summary>
        /// <param name="id">The primary key of the productpaymentplan</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The productpaymentplanService responsible for managing productpaymentplan related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productpaymentplan information.
    /// </remarks>
    public class ProductPaymentPlanService : IProductPaymentPlanService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProductPaymentPlan class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProductPaymentPlanService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific productpaymentplan by its primary key</summary>
        /// <param name="id">The primary key of the productpaymentplan</param>
        /// <returns>The productpaymentplan data</returns>
        public ProductPaymentPlan GetById(Guid id)
        {
            var entityData = _dbContext.ProductPaymentPlan.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of productpaymentplans based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productpaymentplans</returns>/// <exception cref="Exception"></exception>
        public List<ProductPaymentPlan> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProductPaymentPlan(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new productpaymentplan</summary>
        /// <param name="model">The productpaymentplan data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProductPaymentPlan model)
        {
            model.Id = CreateProductPaymentPlan(model);
            return model.Id;
        }

        /// <summary>Updates a specific productpaymentplan by its primary key</summary>
        /// <param name="id">The primary key of the productpaymentplan</param>
        /// <param name="updatedEntity">The productpaymentplan data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProductPaymentPlan updatedEntity)
        {
            UpdateProductPaymentPlan(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific productpaymentplan by its primary key</summary>
        /// <param name="id">The primary key of the productpaymentplan</param>
        /// <param name="updatedEntity">The productpaymentplan data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProductPaymentPlan> updatedEntity)
        {
            PatchProductPaymentPlan(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific productpaymentplan by its primary key</summary>
        /// <param name="id">The primary key of the productpaymentplan</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProductPaymentPlan(id);
            return true;
        }
        #region
        private List<ProductPaymentPlan> GetProductPaymentPlan(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProductPaymentPlan.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProductPaymentPlan>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProductPaymentPlan), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProductPaymentPlan, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProductPaymentPlan(ProductPaymentPlan model)
        {
            _dbContext.ProductPaymentPlan.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProductPaymentPlan(Guid id, ProductPaymentPlan updatedEntity)
        {
            _dbContext.ProductPaymentPlan.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProductPaymentPlan(Guid id)
        {
            var entityData = _dbContext.ProductPaymentPlan.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProductPaymentPlan.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProductPaymentPlan(Guid id, JsonPatchDocument<ProductPaymentPlan> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProductPaymentPlan.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProductPaymentPlan.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}