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
    /// The subscriptioncategoryService responsible for managing subscriptioncategory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting subscriptioncategory information.
    /// </remarks>
    public interface ISubscriptionCategoryService
    {
        /// <summary>Retrieves a specific subscriptioncategory by its primary key</summary>
        /// <param name="id">The primary key of the subscriptioncategory</param>
        /// <returns>The subscriptioncategory data</returns>
        SubscriptionCategory GetById(Guid id);

        /// <summary>Retrieves a list of subscriptioncategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of subscriptioncategorys</returns>
        List<SubscriptionCategory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new subscriptioncategory</summary>
        /// <param name="model">The subscriptioncategory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SubscriptionCategory model);

        /// <summary>Updates a specific subscriptioncategory by its primary key</summary>
        /// <param name="id">The primary key of the subscriptioncategory</param>
        /// <param name="updatedEntity">The subscriptioncategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SubscriptionCategory updatedEntity);

        /// <summary>Updates a specific subscriptioncategory by its primary key</summary>
        /// <param name="id">The primary key of the subscriptioncategory</param>
        /// <param name="updatedEntity">The subscriptioncategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SubscriptionCategory> updatedEntity);

        /// <summary>Deletes a specific subscriptioncategory by its primary key</summary>
        /// <param name="id">The primary key of the subscriptioncategory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The subscriptioncategoryService responsible for managing subscriptioncategory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting subscriptioncategory information.
    /// </remarks>
    public class SubscriptionCategoryService : ISubscriptionCategoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SubscriptionCategory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SubscriptionCategoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific subscriptioncategory by its primary key</summary>
        /// <param name="id">The primary key of the subscriptioncategory</param>
        /// <returns>The subscriptioncategory data</returns>
        public SubscriptionCategory GetById(Guid id)
        {
            var entityData = _dbContext.SubscriptionCategory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of subscriptioncategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of subscriptioncategorys</returns>/// <exception cref="Exception"></exception>
        public List<SubscriptionCategory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSubscriptionCategory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new subscriptioncategory</summary>
        /// <param name="model">The subscriptioncategory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SubscriptionCategory model)
        {
            model.Id = CreateSubscriptionCategory(model);
            return model.Id;
        }

        /// <summary>Updates a specific subscriptioncategory by its primary key</summary>
        /// <param name="id">The primary key of the subscriptioncategory</param>
        /// <param name="updatedEntity">The subscriptioncategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SubscriptionCategory updatedEntity)
        {
            UpdateSubscriptionCategory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific subscriptioncategory by its primary key</summary>
        /// <param name="id">The primary key of the subscriptioncategory</param>
        /// <param name="updatedEntity">The subscriptioncategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SubscriptionCategory> updatedEntity)
        {
            PatchSubscriptionCategory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific subscriptioncategory by its primary key</summary>
        /// <param name="id">The primary key of the subscriptioncategory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSubscriptionCategory(id);
            return true;
        }
        #region
        private List<SubscriptionCategory> GetSubscriptionCategory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SubscriptionCategory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SubscriptionCategory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SubscriptionCategory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SubscriptionCategory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSubscriptionCategory(SubscriptionCategory model)
        {
            _dbContext.SubscriptionCategory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSubscriptionCategory(Guid id, SubscriptionCategory updatedEntity)
        {
            _dbContext.SubscriptionCategory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSubscriptionCategory(Guid id)
        {
            var entityData = _dbContext.SubscriptionCategory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SubscriptionCategory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSubscriptionCategory(Guid id, JsonPatchDocument<SubscriptionCategory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SubscriptionCategory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SubscriptionCategory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}