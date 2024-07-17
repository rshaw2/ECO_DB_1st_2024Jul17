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
    /// The requisitionworkflowactivityhistoryService responsible for managing requisitionworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting requisitionworkflowactivityhistory information.
    /// </remarks>
    public interface IRequisitionWorkflowActivityHistoryService
    {
        /// <summary>Retrieves a specific requisitionworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the requisitionworkflowactivityhistory</param>
        /// <returns>The requisitionworkflowactivityhistory data</returns>
        RequisitionWorkflowActivityHistory GetById(Guid id);

        /// <summary>Retrieves a list of requisitionworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of requisitionworkflowactivityhistorys</returns>
        List<RequisitionWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new requisitionworkflowactivityhistory</summary>
        /// <param name="model">The requisitionworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(RequisitionWorkflowActivityHistory model);

        /// <summary>Updates a specific requisitionworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the requisitionworkflowactivityhistory</param>
        /// <param name="updatedEntity">The requisitionworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, RequisitionWorkflowActivityHistory updatedEntity);

        /// <summary>Updates a specific requisitionworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the requisitionworkflowactivityhistory</param>
        /// <param name="updatedEntity">The requisitionworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<RequisitionWorkflowActivityHistory> updatedEntity);

        /// <summary>Deletes a specific requisitionworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the requisitionworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The requisitionworkflowactivityhistoryService responsible for managing requisitionworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting requisitionworkflowactivityhistory information.
    /// </remarks>
    public class RequisitionWorkflowActivityHistoryService : IRequisitionWorkflowActivityHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the RequisitionWorkflowActivityHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public RequisitionWorkflowActivityHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific requisitionworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the requisitionworkflowactivityhistory</param>
        /// <returns>The requisitionworkflowactivityhistory data</returns>
        public RequisitionWorkflowActivityHistory GetById(Guid id)
        {
            var entityData = _dbContext.RequisitionWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of requisitionworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of requisitionworkflowactivityhistorys</returns>/// <exception cref="Exception"></exception>
        public List<RequisitionWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetRequisitionWorkflowActivityHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new requisitionworkflowactivityhistory</summary>
        /// <param name="model">The requisitionworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(RequisitionWorkflowActivityHistory model)
        {
            model.Id = CreateRequisitionWorkflowActivityHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific requisitionworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the requisitionworkflowactivityhistory</param>
        /// <param name="updatedEntity">The requisitionworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, RequisitionWorkflowActivityHistory updatedEntity)
        {
            UpdateRequisitionWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific requisitionworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the requisitionworkflowactivityhistory</param>
        /// <param name="updatedEntity">The requisitionworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<RequisitionWorkflowActivityHistory> updatedEntity)
        {
            PatchRequisitionWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific requisitionworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the requisitionworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteRequisitionWorkflowActivityHistory(id);
            return true;
        }
        #region
        private List<RequisitionWorkflowActivityHistory> GetRequisitionWorkflowActivityHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.RequisitionWorkflowActivityHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<RequisitionWorkflowActivityHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(RequisitionWorkflowActivityHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<RequisitionWorkflowActivityHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateRequisitionWorkflowActivityHistory(RequisitionWorkflowActivityHistory model)
        {
            _dbContext.RequisitionWorkflowActivityHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateRequisitionWorkflowActivityHistory(Guid id, RequisitionWorkflowActivityHistory updatedEntity)
        {
            _dbContext.RequisitionWorkflowActivityHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteRequisitionWorkflowActivityHistory(Guid id)
        {
            var entityData = _dbContext.RequisitionWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.RequisitionWorkflowActivityHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchRequisitionWorkflowActivityHistory(Guid id, JsonPatchDocument<RequisitionWorkflowActivityHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.RequisitionWorkflowActivityHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.RequisitionWorkflowActivityHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}