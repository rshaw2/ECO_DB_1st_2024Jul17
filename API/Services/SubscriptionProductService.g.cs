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
    /// The subscriptionproductService responsible for managing subscriptionproduct related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting subscriptionproduct information.
    /// </remarks>
    public interface ISubscriptionProductService
    {
        /// <summary>Retrieves a specific subscriptionproduct by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionproduct</param>
        /// <returns>The subscriptionproduct data</returns>
        SubscriptionProduct GetById(Guid id);

        /// <summary>Retrieves a list of subscriptionproducts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of subscriptionproducts</returns>
        List<SubscriptionProduct> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new subscriptionproduct</summary>
        /// <param name="model">The subscriptionproduct data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SubscriptionProduct model);

        /// <summary>Updates a specific subscriptionproduct by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionproduct</param>
        /// <param name="updatedEntity">The subscriptionproduct data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SubscriptionProduct updatedEntity);

        /// <summary>Updates a specific subscriptionproduct by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionproduct</param>
        /// <param name="updatedEntity">The subscriptionproduct data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SubscriptionProduct> updatedEntity);

        /// <summary>Deletes a specific subscriptionproduct by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionproduct</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The subscriptionproductService responsible for managing subscriptionproduct related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting subscriptionproduct information.
    /// </remarks>
    public class SubscriptionProductService : ISubscriptionProductService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SubscriptionProduct class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SubscriptionProductService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific subscriptionproduct by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionproduct</param>
        /// <returns>The subscriptionproduct data</returns>
        public SubscriptionProduct GetById(Guid id)
        {
            var entityData = _dbContext.SubscriptionProduct.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of subscriptionproducts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of subscriptionproducts</returns>/// <exception cref="Exception"></exception>
        public List<SubscriptionProduct> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSubscriptionProduct(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new subscriptionproduct</summary>
        /// <param name="model">The subscriptionproduct data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SubscriptionProduct model)
        {
            model.Id = CreateSubscriptionProduct(model);
            return model.Id;
        }

        /// <summary>Updates a specific subscriptionproduct by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionproduct</param>
        /// <param name="updatedEntity">The subscriptionproduct data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SubscriptionProduct updatedEntity)
        {
            UpdateSubscriptionProduct(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific subscriptionproduct by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionproduct</param>
        /// <param name="updatedEntity">The subscriptionproduct data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SubscriptionProduct> updatedEntity)
        {
            PatchSubscriptionProduct(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific subscriptionproduct by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionproduct</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSubscriptionProduct(id);
            return true;
        }
        #region
        private List<SubscriptionProduct> GetSubscriptionProduct(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SubscriptionProduct.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SubscriptionProduct>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SubscriptionProduct), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SubscriptionProduct, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSubscriptionProduct(SubscriptionProduct model)
        {
            _dbContext.SubscriptionProduct.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSubscriptionProduct(Guid id, SubscriptionProduct updatedEntity)
        {
            _dbContext.SubscriptionProduct.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSubscriptionProduct(Guid id)
        {
            var entityData = _dbContext.SubscriptionProduct.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SubscriptionProduct.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSubscriptionProduct(Guid id, JsonPatchDocument<SubscriptionProduct> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SubscriptionProduct.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SubscriptionProduct.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}