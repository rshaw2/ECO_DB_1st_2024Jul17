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
    /// The productscheduleService responsible for managing productschedule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productschedule information.
    /// </remarks>
    public interface IProductScheduleService
    {
        /// <summary>Retrieves a specific productschedule by its primary key</summary>
        /// <param name="id">The primary key of the productschedule</param>
        /// <returns>The productschedule data</returns>
        ProductSchedule GetById(Guid id);

        /// <summary>Retrieves a list of productschedules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productschedules</returns>
        List<ProductSchedule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new productschedule</summary>
        /// <param name="model">The productschedule data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProductSchedule model);

        /// <summary>Updates a specific productschedule by its primary key</summary>
        /// <param name="id">The primary key of the productschedule</param>
        /// <param name="updatedEntity">The productschedule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProductSchedule updatedEntity);

        /// <summary>Updates a specific productschedule by its primary key</summary>
        /// <param name="id">The primary key of the productschedule</param>
        /// <param name="updatedEntity">The productschedule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProductSchedule> updatedEntity);

        /// <summary>Deletes a specific productschedule by its primary key</summary>
        /// <param name="id">The primary key of the productschedule</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The productscheduleService responsible for managing productschedule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productschedule information.
    /// </remarks>
    public class ProductScheduleService : IProductScheduleService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProductSchedule class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProductScheduleService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific productschedule by its primary key</summary>
        /// <param name="id">The primary key of the productschedule</param>
        /// <returns>The productschedule data</returns>
        public ProductSchedule GetById(Guid id)
        {
            var entityData = _dbContext.ProductSchedule.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of productschedules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productschedules</returns>/// <exception cref="Exception"></exception>
        public List<ProductSchedule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProductSchedule(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new productschedule</summary>
        /// <param name="model">The productschedule data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProductSchedule model)
        {
            model.Id = CreateProductSchedule(model);
            return model.Id;
        }

        /// <summary>Updates a specific productschedule by its primary key</summary>
        /// <param name="id">The primary key of the productschedule</param>
        /// <param name="updatedEntity">The productschedule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProductSchedule updatedEntity)
        {
            UpdateProductSchedule(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific productschedule by its primary key</summary>
        /// <param name="id">The primary key of the productschedule</param>
        /// <param name="updatedEntity">The productschedule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProductSchedule> updatedEntity)
        {
            PatchProductSchedule(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific productschedule by its primary key</summary>
        /// <param name="id">The primary key of the productschedule</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProductSchedule(id);
            return true;
        }
        #region
        private List<ProductSchedule> GetProductSchedule(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProductSchedule.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProductSchedule>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProductSchedule), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProductSchedule, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProductSchedule(ProductSchedule model)
        {
            _dbContext.ProductSchedule.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProductSchedule(Guid id, ProductSchedule updatedEntity)
        {
            _dbContext.ProductSchedule.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProductSchedule(Guid id)
        {
            var entityData = _dbContext.ProductSchedule.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProductSchedule.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProductSchedule(Guid id, JsonPatchDocument<ProductSchedule> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProductSchedule.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProductSchedule.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}