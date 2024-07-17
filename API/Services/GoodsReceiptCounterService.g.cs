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
    /// The goodsreceiptcounterService responsible for managing goodsreceiptcounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting goodsreceiptcounter information.
    /// </remarks>
    public interface IGoodsReceiptCounterService
    {
        /// <summary>Retrieves a specific goodsreceiptcounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptcounter</param>
        /// <returns>The goodsreceiptcounter data</returns>
        GoodsReceiptCounter GetById(Guid id);

        /// <summary>Retrieves a list of goodsreceiptcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of goodsreceiptcounters</returns>
        List<GoodsReceiptCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new goodsreceiptcounter</summary>
        /// <param name="model">The goodsreceiptcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(GoodsReceiptCounter model);

        /// <summary>Updates a specific goodsreceiptcounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptcounter</param>
        /// <param name="updatedEntity">The goodsreceiptcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GoodsReceiptCounter updatedEntity);

        /// <summary>Updates a specific goodsreceiptcounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptcounter</param>
        /// <param name="updatedEntity">The goodsreceiptcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GoodsReceiptCounter> updatedEntity);

        /// <summary>Deletes a specific goodsreceiptcounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptcounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The goodsreceiptcounterService responsible for managing goodsreceiptcounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting goodsreceiptcounter information.
    /// </remarks>
    public class GoodsReceiptCounterService : IGoodsReceiptCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GoodsReceiptCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GoodsReceiptCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific goodsreceiptcounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptcounter</param>
        /// <returns>The goodsreceiptcounter data</returns>
        public GoodsReceiptCounter GetById(Guid id)
        {
            var entityData = _dbContext.GoodsReceiptCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of goodsreceiptcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of goodsreceiptcounters</returns>/// <exception cref="Exception"></exception>
        public List<GoodsReceiptCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGoodsReceiptCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new goodsreceiptcounter</summary>
        /// <param name="model">The goodsreceiptcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(GoodsReceiptCounter model)
        {
            model.TenantId = CreateGoodsReceiptCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific goodsreceiptcounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptcounter</param>
        /// <param name="updatedEntity">The goodsreceiptcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GoodsReceiptCounter updatedEntity)
        {
            UpdateGoodsReceiptCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific goodsreceiptcounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptcounter</param>
        /// <param name="updatedEntity">The goodsreceiptcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GoodsReceiptCounter> updatedEntity)
        {
            PatchGoodsReceiptCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific goodsreceiptcounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptcounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGoodsReceiptCounter(id);
            return true;
        }
        #region
        private List<GoodsReceiptCounter> GetGoodsReceiptCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GoodsReceiptCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GoodsReceiptCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GoodsReceiptCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GoodsReceiptCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateGoodsReceiptCounter(GoodsReceiptCounter model)
        {
            _dbContext.GoodsReceiptCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateGoodsReceiptCounter(Guid id, GoodsReceiptCounter updatedEntity)
        {
            _dbContext.GoodsReceiptCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGoodsReceiptCounter(Guid id)
        {
            var entityData = _dbContext.GoodsReceiptCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GoodsReceiptCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGoodsReceiptCounter(Guid id, JsonPatchDocument<GoodsReceiptCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GoodsReceiptCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GoodsReceiptCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}