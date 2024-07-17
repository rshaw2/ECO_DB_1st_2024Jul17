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
    /// The investigationorderworkflowactivityhistoryService responsible for managing investigationorderworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationorderworkflowactivityhistory information.
    /// </remarks>
    public interface IInvestigationOrderWorkflowActivityHistoryService
    {
        /// <summary>Retrieves a specific investigationorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderworkflowactivityhistory</param>
        /// <returns>The investigationorderworkflowactivityhistory data</returns>
        InvestigationOrderWorkflowActivityHistory GetById(Guid id);

        /// <summary>Retrieves a list of investigationorderworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationorderworkflowactivityhistorys</returns>
        List<InvestigationOrderWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new investigationorderworkflowactivityhistory</summary>
        /// <param name="model">The investigationorderworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InvestigationOrderWorkflowActivityHistory model);

        /// <summary>Updates a specific investigationorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderworkflowactivityhistory</param>
        /// <param name="updatedEntity">The investigationorderworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvestigationOrderWorkflowActivityHistory updatedEntity);

        /// <summary>Updates a specific investigationorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderworkflowactivityhistory</param>
        /// <param name="updatedEntity">The investigationorderworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvestigationOrderWorkflowActivityHistory> updatedEntity);

        /// <summary>Deletes a specific investigationorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The investigationorderworkflowactivityhistoryService responsible for managing investigationorderworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationorderworkflowactivityhistory information.
    /// </remarks>
    public class InvestigationOrderWorkflowActivityHistoryService : IInvestigationOrderWorkflowActivityHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvestigationOrderWorkflowActivityHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvestigationOrderWorkflowActivityHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific investigationorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderworkflowactivityhistory</param>
        /// <returns>The investigationorderworkflowactivityhistory data</returns>
        public InvestigationOrderWorkflowActivityHistory GetById(Guid id)
        {
            var entityData = _dbContext.InvestigationOrderWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of investigationorderworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationorderworkflowactivityhistorys</returns>/// <exception cref="Exception"></exception>
        public List<InvestigationOrderWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvestigationOrderWorkflowActivityHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new investigationorderworkflowactivityhistory</summary>
        /// <param name="model">The investigationorderworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InvestigationOrderWorkflowActivityHistory model)
        {
            model.Id = CreateInvestigationOrderWorkflowActivityHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific investigationorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderworkflowactivityhistory</param>
        /// <param name="updatedEntity">The investigationorderworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvestigationOrderWorkflowActivityHistory updatedEntity)
        {
            UpdateInvestigationOrderWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific investigationorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderworkflowactivityhistory</param>
        /// <param name="updatedEntity">The investigationorderworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvestigationOrderWorkflowActivityHistory> updatedEntity)
        {
            PatchInvestigationOrderWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific investigationorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvestigationOrderWorkflowActivityHistory(id);
            return true;
        }
        #region
        private List<InvestigationOrderWorkflowActivityHistory> GetInvestigationOrderWorkflowActivityHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvestigationOrderWorkflowActivityHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvestigationOrderWorkflowActivityHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvestigationOrderWorkflowActivityHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvestigationOrderWorkflowActivityHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInvestigationOrderWorkflowActivityHistory(InvestigationOrderWorkflowActivityHistory model)
        {
            _dbContext.InvestigationOrderWorkflowActivityHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInvestigationOrderWorkflowActivityHistory(Guid id, InvestigationOrderWorkflowActivityHistory updatedEntity)
        {
            _dbContext.InvestigationOrderWorkflowActivityHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvestigationOrderWorkflowActivityHistory(Guid id)
        {
            var entityData = _dbContext.InvestigationOrderWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvestigationOrderWorkflowActivityHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvestigationOrderWorkflowActivityHistory(Guid id, JsonPatchDocument<InvestigationOrderWorkflowActivityHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvestigationOrderWorkflowActivityHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvestigationOrderWorkflowActivityHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}