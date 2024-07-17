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
    /// The orderablecomponentService responsible for managing orderablecomponent related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting orderablecomponent information.
    /// </remarks>
    public interface IOrderableComponentService
    {
        /// <summary>Retrieves a specific orderablecomponent by its primary key</summary>
        /// <param name="id">The primary key of the orderablecomponent</param>
        /// <returns>The orderablecomponent data</returns>
        OrderableComponent GetById(Guid id);

        /// <summary>Retrieves a list of orderablecomponents based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of orderablecomponents</returns>
        List<OrderableComponent> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new orderablecomponent</summary>
        /// <param name="model">The orderablecomponent data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(OrderableComponent model);

        /// <summary>Updates a specific orderablecomponent by its primary key</summary>
        /// <param name="id">The primary key of the orderablecomponent</param>
        /// <param name="updatedEntity">The orderablecomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, OrderableComponent updatedEntity);

        /// <summary>Updates a specific orderablecomponent by its primary key</summary>
        /// <param name="id">The primary key of the orderablecomponent</param>
        /// <param name="updatedEntity">The orderablecomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<OrderableComponent> updatedEntity);

        /// <summary>Deletes a specific orderablecomponent by its primary key</summary>
        /// <param name="id">The primary key of the orderablecomponent</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The orderablecomponentService responsible for managing orderablecomponent related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting orderablecomponent information.
    /// </remarks>
    public class OrderableComponentService : IOrderableComponentService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the OrderableComponent class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public OrderableComponentService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific orderablecomponent by its primary key</summary>
        /// <param name="id">The primary key of the orderablecomponent</param>
        /// <returns>The orderablecomponent data</returns>
        public OrderableComponent GetById(Guid id)
        {
            var entityData = _dbContext.OrderableComponent.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of orderablecomponents based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of orderablecomponents</returns>/// <exception cref="Exception"></exception>
        public List<OrderableComponent> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetOrderableComponent(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new orderablecomponent</summary>
        /// <param name="model">The orderablecomponent data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(OrderableComponent model)
        {
            model.Id = CreateOrderableComponent(model);
            return model.Id;
        }

        /// <summary>Updates a specific orderablecomponent by its primary key</summary>
        /// <param name="id">The primary key of the orderablecomponent</param>
        /// <param name="updatedEntity">The orderablecomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, OrderableComponent updatedEntity)
        {
            UpdateOrderableComponent(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific orderablecomponent by its primary key</summary>
        /// <param name="id">The primary key of the orderablecomponent</param>
        /// <param name="updatedEntity">The orderablecomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<OrderableComponent> updatedEntity)
        {
            PatchOrderableComponent(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific orderablecomponent by its primary key</summary>
        /// <param name="id">The primary key of the orderablecomponent</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteOrderableComponent(id);
            return true;
        }
        #region
        private List<OrderableComponent> GetOrderableComponent(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.OrderableComponent.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<OrderableComponent>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(OrderableComponent), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<OrderableComponent, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateOrderableComponent(OrderableComponent model)
        {
            _dbContext.OrderableComponent.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateOrderableComponent(Guid id, OrderableComponent updatedEntity)
        {
            _dbContext.OrderableComponent.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteOrderableComponent(Guid id)
        {
            var entityData = _dbContext.OrderableComponent.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.OrderableComponent.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchOrderableComponent(Guid id, JsonPatchDocument<OrderableComponent> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.OrderableComponent.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.OrderableComponent.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}