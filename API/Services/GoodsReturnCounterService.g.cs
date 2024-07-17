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
    /// The goodsreturncounterService responsible for managing goodsreturncounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting goodsreturncounter information.
    /// </remarks>
    public interface IGoodsReturnCounterService
    {
        /// <summary>Retrieves a specific goodsreturncounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturncounter</param>
        /// <returns>The goodsreturncounter data</returns>
        GoodsReturnCounter GetById(Guid id);

        /// <summary>Retrieves a list of goodsreturncounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of goodsreturncounters</returns>
        List<GoodsReturnCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new goodsreturncounter</summary>
        /// <param name="model">The goodsreturncounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(GoodsReturnCounter model);

        /// <summary>Updates a specific goodsreturncounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturncounter</param>
        /// <param name="updatedEntity">The goodsreturncounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GoodsReturnCounter updatedEntity);

        /// <summary>Updates a specific goodsreturncounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturncounter</param>
        /// <param name="updatedEntity">The goodsreturncounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GoodsReturnCounter> updatedEntity);

        /// <summary>Deletes a specific goodsreturncounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturncounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The goodsreturncounterService responsible for managing goodsreturncounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting goodsreturncounter information.
    /// </remarks>
    public class GoodsReturnCounterService : IGoodsReturnCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GoodsReturnCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GoodsReturnCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific goodsreturncounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturncounter</param>
        /// <returns>The goodsreturncounter data</returns>
        public GoodsReturnCounter GetById(Guid id)
        {
            var entityData = _dbContext.GoodsReturnCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of goodsreturncounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of goodsreturncounters</returns>/// <exception cref="Exception"></exception>
        public List<GoodsReturnCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGoodsReturnCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new goodsreturncounter</summary>
        /// <param name="model">The goodsreturncounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(GoodsReturnCounter model)
        {
            model.TenantId = CreateGoodsReturnCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific goodsreturncounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturncounter</param>
        /// <param name="updatedEntity">The goodsreturncounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GoodsReturnCounter updatedEntity)
        {
            UpdateGoodsReturnCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific goodsreturncounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturncounter</param>
        /// <param name="updatedEntity">The goodsreturncounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GoodsReturnCounter> updatedEntity)
        {
            PatchGoodsReturnCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific goodsreturncounter by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturncounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGoodsReturnCounter(id);
            return true;
        }
        #region
        private List<GoodsReturnCounter> GetGoodsReturnCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GoodsReturnCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GoodsReturnCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GoodsReturnCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GoodsReturnCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateGoodsReturnCounter(GoodsReturnCounter model)
        {
            _dbContext.GoodsReturnCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateGoodsReturnCounter(Guid id, GoodsReturnCounter updatedEntity)
        {
            _dbContext.GoodsReturnCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGoodsReturnCounter(Guid id)
        {
            var entityData = _dbContext.GoodsReturnCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GoodsReturnCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGoodsReturnCounter(Guid id, JsonPatchDocument<GoodsReturnCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GoodsReturnCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GoodsReturnCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}