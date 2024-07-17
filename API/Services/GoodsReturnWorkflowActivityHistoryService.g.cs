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
    /// The goodsreturnworkflowactivityhistoryService responsible for managing goodsreturnworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting goodsreturnworkflowactivityhistory information.
    /// </remarks>
    public interface IGoodsReturnWorkflowActivityHistoryService
    {
        /// <summary>Retrieves a specific goodsreturnworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturnworkflowactivityhistory</param>
        /// <returns>The goodsreturnworkflowactivityhistory data</returns>
        GoodsReturnWorkflowActivityHistory GetById(Guid id);

        /// <summary>Retrieves a list of goodsreturnworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of goodsreturnworkflowactivityhistorys</returns>
        List<GoodsReturnWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new goodsreturnworkflowactivityhistory</summary>
        /// <param name="model">The goodsreturnworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(GoodsReturnWorkflowActivityHistory model);

        /// <summary>Updates a specific goodsreturnworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturnworkflowactivityhistory</param>
        /// <param name="updatedEntity">The goodsreturnworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GoodsReturnWorkflowActivityHistory updatedEntity);

        /// <summary>Updates a specific goodsreturnworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturnworkflowactivityhistory</param>
        /// <param name="updatedEntity">The goodsreturnworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GoodsReturnWorkflowActivityHistory> updatedEntity);

        /// <summary>Deletes a specific goodsreturnworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturnworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The goodsreturnworkflowactivityhistoryService responsible for managing goodsreturnworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting goodsreturnworkflowactivityhistory information.
    /// </remarks>
    public class GoodsReturnWorkflowActivityHistoryService : IGoodsReturnWorkflowActivityHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GoodsReturnWorkflowActivityHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GoodsReturnWorkflowActivityHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific goodsreturnworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturnworkflowactivityhistory</param>
        /// <returns>The goodsreturnworkflowactivityhistory data</returns>
        public GoodsReturnWorkflowActivityHistory GetById(Guid id)
        {
            var entityData = _dbContext.GoodsReturnWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of goodsreturnworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of goodsreturnworkflowactivityhistorys</returns>/// <exception cref="Exception"></exception>
        public List<GoodsReturnWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGoodsReturnWorkflowActivityHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new goodsreturnworkflowactivityhistory</summary>
        /// <param name="model">The goodsreturnworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(GoodsReturnWorkflowActivityHistory model)
        {
            model.Id = CreateGoodsReturnWorkflowActivityHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific goodsreturnworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturnworkflowactivityhistory</param>
        /// <param name="updatedEntity">The goodsreturnworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GoodsReturnWorkflowActivityHistory updatedEntity)
        {
            UpdateGoodsReturnWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific goodsreturnworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturnworkflowactivityhistory</param>
        /// <param name="updatedEntity">The goodsreturnworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GoodsReturnWorkflowActivityHistory> updatedEntity)
        {
            PatchGoodsReturnWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific goodsreturnworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreturnworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGoodsReturnWorkflowActivityHistory(id);
            return true;
        }
        #region
        private List<GoodsReturnWorkflowActivityHistory> GetGoodsReturnWorkflowActivityHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GoodsReturnWorkflowActivityHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GoodsReturnWorkflowActivityHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GoodsReturnWorkflowActivityHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GoodsReturnWorkflowActivityHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGoodsReturnWorkflowActivityHistory(GoodsReturnWorkflowActivityHistory model)
        {
            _dbContext.GoodsReturnWorkflowActivityHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGoodsReturnWorkflowActivityHistory(Guid id, GoodsReturnWorkflowActivityHistory updatedEntity)
        {
            _dbContext.GoodsReturnWorkflowActivityHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGoodsReturnWorkflowActivityHistory(Guid id)
        {
            var entityData = _dbContext.GoodsReturnWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GoodsReturnWorkflowActivityHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGoodsReturnWorkflowActivityHistory(Guid id, JsonPatchDocument<GoodsReturnWorkflowActivityHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GoodsReturnWorkflowActivityHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GoodsReturnWorkflowActivityHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}