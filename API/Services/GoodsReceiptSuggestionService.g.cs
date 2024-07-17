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
    /// The goodsreceiptsuggestionService responsible for managing goodsreceiptsuggestion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting goodsreceiptsuggestion information.
    /// </remarks>
    public interface IGoodsReceiptSuggestionService
    {
        /// <summary>Retrieves a specific goodsreceiptsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptsuggestion</param>
        /// <returns>The goodsreceiptsuggestion data</returns>
        GoodsReceiptSuggestion GetById(Guid id);

        /// <summary>Retrieves a list of goodsreceiptsuggestions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of goodsreceiptsuggestions</returns>
        List<GoodsReceiptSuggestion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new goodsreceiptsuggestion</summary>
        /// <param name="model">The goodsreceiptsuggestion data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(GoodsReceiptSuggestion model);

        /// <summary>Updates a specific goodsreceiptsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptsuggestion</param>
        /// <param name="updatedEntity">The goodsreceiptsuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GoodsReceiptSuggestion updatedEntity);

        /// <summary>Updates a specific goodsreceiptsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptsuggestion</param>
        /// <param name="updatedEntity">The goodsreceiptsuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GoodsReceiptSuggestion> updatedEntity);

        /// <summary>Deletes a specific goodsreceiptsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptsuggestion</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The goodsreceiptsuggestionService responsible for managing goodsreceiptsuggestion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting goodsreceiptsuggestion information.
    /// </remarks>
    public class GoodsReceiptSuggestionService : IGoodsReceiptSuggestionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GoodsReceiptSuggestion class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GoodsReceiptSuggestionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific goodsreceiptsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptsuggestion</param>
        /// <returns>The goodsreceiptsuggestion data</returns>
        public GoodsReceiptSuggestion GetById(Guid id)
        {
            var entityData = _dbContext.GoodsReceiptSuggestion.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of goodsreceiptsuggestions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of goodsreceiptsuggestions</returns>/// <exception cref="Exception"></exception>
        public List<GoodsReceiptSuggestion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGoodsReceiptSuggestion(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new goodsreceiptsuggestion</summary>
        /// <param name="model">The goodsreceiptsuggestion data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(GoodsReceiptSuggestion model)
        {
            model.Id = CreateGoodsReceiptSuggestion(model);
            return model.Id;
        }

        /// <summary>Updates a specific goodsreceiptsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptsuggestion</param>
        /// <param name="updatedEntity">The goodsreceiptsuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GoodsReceiptSuggestion updatedEntity)
        {
            UpdateGoodsReceiptSuggestion(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific goodsreceiptsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptsuggestion</param>
        /// <param name="updatedEntity">The goodsreceiptsuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GoodsReceiptSuggestion> updatedEntity)
        {
            PatchGoodsReceiptSuggestion(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific goodsreceiptsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptsuggestion</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGoodsReceiptSuggestion(id);
            return true;
        }
        #region
        private List<GoodsReceiptSuggestion> GetGoodsReceiptSuggestion(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GoodsReceiptSuggestion.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GoodsReceiptSuggestion>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GoodsReceiptSuggestion), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GoodsReceiptSuggestion, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGoodsReceiptSuggestion(GoodsReceiptSuggestion model)
        {
            _dbContext.GoodsReceiptSuggestion.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGoodsReceiptSuggestion(Guid id, GoodsReceiptSuggestion updatedEntity)
        {
            _dbContext.GoodsReceiptSuggestion.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGoodsReceiptSuggestion(Guid id)
        {
            var entityData = _dbContext.GoodsReceiptSuggestion.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GoodsReceiptSuggestion.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGoodsReceiptSuggestion(Guid id, JsonPatchDocument<GoodsReceiptSuggestion> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GoodsReceiptSuggestion.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GoodsReceiptSuggestion.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}