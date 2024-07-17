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
    /// The procedureorderworkflowactivityhistoryService responsible for managing procedureorderworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting procedureorderworkflowactivityhistory information.
    /// </remarks>
    public interface IProcedureOrderWorkflowActivityHistoryService
    {
        /// <summary>Retrieves a specific procedureorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderworkflowactivityhistory</param>
        /// <returns>The procedureorderworkflowactivityhistory data</returns>
        ProcedureOrderWorkflowActivityHistory GetById(Guid id);

        /// <summary>Retrieves a list of procedureorderworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of procedureorderworkflowactivityhistorys</returns>
        List<ProcedureOrderWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new procedureorderworkflowactivityhistory</summary>
        /// <param name="model">The procedureorderworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProcedureOrderWorkflowActivityHistory model);

        /// <summary>Updates a specific procedureorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderworkflowactivityhistory</param>
        /// <param name="updatedEntity">The procedureorderworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProcedureOrderWorkflowActivityHistory updatedEntity);

        /// <summary>Updates a specific procedureorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderworkflowactivityhistory</param>
        /// <param name="updatedEntity">The procedureorderworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProcedureOrderWorkflowActivityHistory> updatedEntity);

        /// <summary>Deletes a specific procedureorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The procedureorderworkflowactivityhistoryService responsible for managing procedureorderworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting procedureorderworkflowactivityhistory information.
    /// </remarks>
    public class ProcedureOrderWorkflowActivityHistoryService : IProcedureOrderWorkflowActivityHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProcedureOrderWorkflowActivityHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProcedureOrderWorkflowActivityHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific procedureorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderworkflowactivityhistory</param>
        /// <returns>The procedureorderworkflowactivityhistory data</returns>
        public ProcedureOrderWorkflowActivityHistory GetById(Guid id)
        {
            var entityData = _dbContext.ProcedureOrderWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of procedureorderworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of procedureorderworkflowactivityhistorys</returns>/// <exception cref="Exception"></exception>
        public List<ProcedureOrderWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProcedureOrderWorkflowActivityHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new procedureorderworkflowactivityhistory</summary>
        /// <param name="model">The procedureorderworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProcedureOrderWorkflowActivityHistory model)
        {
            model.Id = CreateProcedureOrderWorkflowActivityHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific procedureorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderworkflowactivityhistory</param>
        /// <param name="updatedEntity">The procedureorderworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProcedureOrderWorkflowActivityHistory updatedEntity)
        {
            UpdateProcedureOrderWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific procedureorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderworkflowactivityhistory</param>
        /// <param name="updatedEntity">The procedureorderworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProcedureOrderWorkflowActivityHistory> updatedEntity)
        {
            PatchProcedureOrderWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific procedureorderworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProcedureOrderWorkflowActivityHistory(id);
            return true;
        }
        #region
        private List<ProcedureOrderWorkflowActivityHistory> GetProcedureOrderWorkflowActivityHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProcedureOrderWorkflowActivityHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProcedureOrderWorkflowActivityHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProcedureOrderWorkflowActivityHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProcedureOrderWorkflowActivityHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProcedureOrderWorkflowActivityHistory(ProcedureOrderWorkflowActivityHistory model)
        {
            _dbContext.ProcedureOrderWorkflowActivityHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProcedureOrderWorkflowActivityHistory(Guid id, ProcedureOrderWorkflowActivityHistory updatedEntity)
        {
            _dbContext.ProcedureOrderWorkflowActivityHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProcedureOrderWorkflowActivityHistory(Guid id)
        {
            var entityData = _dbContext.ProcedureOrderWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProcedureOrderWorkflowActivityHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProcedureOrderWorkflowActivityHistory(Guid id, JsonPatchDocument<ProcedureOrderWorkflowActivityHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProcedureOrderWorkflowActivityHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProcedureOrderWorkflowActivityHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}