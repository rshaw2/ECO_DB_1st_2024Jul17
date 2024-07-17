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
    /// The subscriptionpriceService responsible for managing subscriptionprice related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting subscriptionprice information.
    /// </remarks>
    public interface ISubscriptionPriceService
    {
        /// <summary>Retrieves a specific subscriptionprice by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionprice</param>
        /// <returns>The subscriptionprice data</returns>
        SubscriptionPrice GetById(Guid id);

        /// <summary>Retrieves a list of subscriptionprices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of subscriptionprices</returns>
        List<SubscriptionPrice> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new subscriptionprice</summary>
        /// <param name="model">The subscriptionprice data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SubscriptionPrice model);

        /// <summary>Updates a specific subscriptionprice by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionprice</param>
        /// <param name="updatedEntity">The subscriptionprice data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SubscriptionPrice updatedEntity);

        /// <summary>Updates a specific subscriptionprice by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionprice</param>
        /// <param name="updatedEntity">The subscriptionprice data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SubscriptionPrice> updatedEntity);

        /// <summary>Deletes a specific subscriptionprice by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionprice</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The subscriptionpriceService responsible for managing subscriptionprice related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting subscriptionprice information.
    /// </remarks>
    public class SubscriptionPriceService : ISubscriptionPriceService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SubscriptionPrice class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SubscriptionPriceService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific subscriptionprice by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionprice</param>
        /// <returns>The subscriptionprice data</returns>
        public SubscriptionPrice GetById(Guid id)
        {
            var entityData = _dbContext.SubscriptionPrice.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of subscriptionprices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of subscriptionprices</returns>/// <exception cref="Exception"></exception>
        public List<SubscriptionPrice> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSubscriptionPrice(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new subscriptionprice</summary>
        /// <param name="model">The subscriptionprice data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SubscriptionPrice model)
        {
            model.Id = CreateSubscriptionPrice(model);
            return model.Id;
        }

        /// <summary>Updates a specific subscriptionprice by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionprice</param>
        /// <param name="updatedEntity">The subscriptionprice data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SubscriptionPrice updatedEntity)
        {
            UpdateSubscriptionPrice(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific subscriptionprice by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionprice</param>
        /// <param name="updatedEntity">The subscriptionprice data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SubscriptionPrice> updatedEntity)
        {
            PatchSubscriptionPrice(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific subscriptionprice by its primary key</summary>
        /// <param name="id">The primary key of the subscriptionprice</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSubscriptionPrice(id);
            return true;
        }
        #region
        private List<SubscriptionPrice> GetSubscriptionPrice(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SubscriptionPrice.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SubscriptionPrice>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SubscriptionPrice), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SubscriptionPrice, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSubscriptionPrice(SubscriptionPrice model)
        {
            _dbContext.SubscriptionPrice.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSubscriptionPrice(Guid id, SubscriptionPrice updatedEntity)
        {
            _dbContext.SubscriptionPrice.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSubscriptionPrice(Guid id)
        {
            var entityData = _dbContext.SubscriptionPrice.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SubscriptionPrice.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSubscriptionPrice(Guid id, JsonPatchDocument<SubscriptionPrice> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SubscriptionPrice.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SubscriptionPrice.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}