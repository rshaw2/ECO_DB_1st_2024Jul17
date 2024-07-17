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
    /// The goodsreceiptworkflowactivityhistoryService responsible for managing goodsreceiptworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting goodsreceiptworkflowactivityhistory information.
    /// </remarks>
    public interface IGoodsReceiptWorkflowActivityHistoryService
    {
        /// <summary>Retrieves a specific goodsreceiptworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptworkflowactivityhistory</param>
        /// <returns>The goodsreceiptworkflowactivityhistory data</returns>
        GoodsReceiptWorkflowActivityHistory GetById(Guid id);

        /// <summary>Retrieves a list of goodsreceiptworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of goodsreceiptworkflowactivityhistorys</returns>
        List<GoodsReceiptWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new goodsreceiptworkflowactivityhistory</summary>
        /// <param name="model">The goodsreceiptworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(GoodsReceiptWorkflowActivityHistory model);

        /// <summary>Updates a specific goodsreceiptworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptworkflowactivityhistory</param>
        /// <param name="updatedEntity">The goodsreceiptworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GoodsReceiptWorkflowActivityHistory updatedEntity);

        /// <summary>Updates a specific goodsreceiptworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptworkflowactivityhistory</param>
        /// <param name="updatedEntity">The goodsreceiptworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GoodsReceiptWorkflowActivityHistory> updatedEntity);

        /// <summary>Deletes a specific goodsreceiptworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The goodsreceiptworkflowactivityhistoryService responsible for managing goodsreceiptworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting goodsreceiptworkflowactivityhistory information.
    /// </remarks>
    public class GoodsReceiptWorkflowActivityHistoryService : IGoodsReceiptWorkflowActivityHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GoodsReceiptWorkflowActivityHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GoodsReceiptWorkflowActivityHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific goodsreceiptworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptworkflowactivityhistory</param>
        /// <returns>The goodsreceiptworkflowactivityhistory data</returns>
        public GoodsReceiptWorkflowActivityHistory GetById(Guid id)
        {
            var entityData = _dbContext.GoodsReceiptWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of goodsreceiptworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of goodsreceiptworkflowactivityhistorys</returns>/// <exception cref="Exception"></exception>
        public List<GoodsReceiptWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGoodsReceiptWorkflowActivityHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new goodsreceiptworkflowactivityhistory</summary>
        /// <param name="model">The goodsreceiptworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(GoodsReceiptWorkflowActivityHistory model)
        {
            model.Id = CreateGoodsReceiptWorkflowActivityHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific goodsreceiptworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptworkflowactivityhistory</param>
        /// <param name="updatedEntity">The goodsreceiptworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GoodsReceiptWorkflowActivityHistory updatedEntity)
        {
            UpdateGoodsReceiptWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific goodsreceiptworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptworkflowactivityhistory</param>
        /// <param name="updatedEntity">The goodsreceiptworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GoodsReceiptWorkflowActivityHistory> updatedEntity)
        {
            PatchGoodsReceiptWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific goodsreceiptworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the goodsreceiptworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGoodsReceiptWorkflowActivityHistory(id);
            return true;
        }
        #region
        private List<GoodsReceiptWorkflowActivityHistory> GetGoodsReceiptWorkflowActivityHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GoodsReceiptWorkflowActivityHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GoodsReceiptWorkflowActivityHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GoodsReceiptWorkflowActivityHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GoodsReceiptWorkflowActivityHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGoodsReceiptWorkflowActivityHistory(GoodsReceiptWorkflowActivityHistory model)
        {
            _dbContext.GoodsReceiptWorkflowActivityHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGoodsReceiptWorkflowActivityHistory(Guid id, GoodsReceiptWorkflowActivityHistory updatedEntity)
        {
            _dbContext.GoodsReceiptWorkflowActivityHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGoodsReceiptWorkflowActivityHistory(Guid id)
        {
            var entityData = _dbContext.GoodsReceiptWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GoodsReceiptWorkflowActivityHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGoodsReceiptWorkflowActivityHistory(Guid id, JsonPatchDocument<GoodsReceiptWorkflowActivityHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GoodsReceiptWorkflowActivityHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GoodsReceiptWorkflowActivityHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}