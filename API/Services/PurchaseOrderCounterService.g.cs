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
    /// The purchaseordercounterService responsible for managing purchaseordercounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting purchaseordercounter information.
    /// </remarks>
    public interface IPurchaseOrderCounterService
    {
        /// <summary>Retrieves a specific purchaseordercounter by its primary key</summary>
        /// <param name="id">The primary key of the purchaseordercounter</param>
        /// <returns>The purchaseordercounter data</returns>
        PurchaseOrderCounter GetById(Guid id);

        /// <summary>Retrieves a list of purchaseordercounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of purchaseordercounters</returns>
        List<PurchaseOrderCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new purchaseordercounter</summary>
        /// <param name="model">The purchaseordercounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(PurchaseOrderCounter model);

        /// <summary>Updates a specific purchaseordercounter by its primary key</summary>
        /// <param name="id">The primary key of the purchaseordercounter</param>
        /// <param name="updatedEntity">The purchaseordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PurchaseOrderCounter updatedEntity);

        /// <summary>Updates a specific purchaseordercounter by its primary key</summary>
        /// <param name="id">The primary key of the purchaseordercounter</param>
        /// <param name="updatedEntity">The purchaseordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PurchaseOrderCounter> updatedEntity);

        /// <summary>Deletes a specific purchaseordercounter by its primary key</summary>
        /// <param name="id">The primary key of the purchaseordercounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The purchaseordercounterService responsible for managing purchaseordercounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting purchaseordercounter information.
    /// </remarks>
    public class PurchaseOrderCounterService : IPurchaseOrderCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PurchaseOrderCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PurchaseOrderCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific purchaseordercounter by its primary key</summary>
        /// <param name="id">The primary key of the purchaseordercounter</param>
        /// <returns>The purchaseordercounter data</returns>
        public PurchaseOrderCounter GetById(Guid id)
        {
            var entityData = _dbContext.PurchaseOrderCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of purchaseordercounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of purchaseordercounters</returns>/// <exception cref="Exception"></exception>
        public List<PurchaseOrderCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPurchaseOrderCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new purchaseordercounter</summary>
        /// <param name="model">The purchaseordercounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(PurchaseOrderCounter model)
        {
            model.TenantId = CreatePurchaseOrderCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific purchaseordercounter by its primary key</summary>
        /// <param name="id">The primary key of the purchaseordercounter</param>
        /// <param name="updatedEntity">The purchaseordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PurchaseOrderCounter updatedEntity)
        {
            UpdatePurchaseOrderCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific purchaseordercounter by its primary key</summary>
        /// <param name="id">The primary key of the purchaseordercounter</param>
        /// <param name="updatedEntity">The purchaseordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PurchaseOrderCounter> updatedEntity)
        {
            PatchPurchaseOrderCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific purchaseordercounter by its primary key</summary>
        /// <param name="id">The primary key of the purchaseordercounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePurchaseOrderCounter(id);
            return true;
        }
        #region
        private List<PurchaseOrderCounter> GetPurchaseOrderCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PurchaseOrderCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PurchaseOrderCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PurchaseOrderCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PurchaseOrderCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreatePurchaseOrderCounter(PurchaseOrderCounter model)
        {
            _dbContext.PurchaseOrderCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdatePurchaseOrderCounter(Guid id, PurchaseOrderCounter updatedEntity)
        {
            _dbContext.PurchaseOrderCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePurchaseOrderCounter(Guid id)
        {
            var entityData = _dbContext.PurchaseOrderCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PurchaseOrderCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPurchaseOrderCounter(Guid id, JsonPatchDocument<PurchaseOrderCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PurchaseOrderCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PurchaseOrderCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}