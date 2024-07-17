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
    /// The visitworkflowactivityhistoryService responsible for managing visitworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitworkflowactivityhistory information.
    /// </remarks>
    public interface IVisitWorkflowActivityHistoryService
    {
        /// <summary>Retrieves a specific visitworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowactivityhistory</param>
        /// <returns>The visitworkflowactivityhistory data</returns>
        VisitWorkflowActivityHistory GetById(Guid id);

        /// <summary>Retrieves a list of visitworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitworkflowactivityhistorys</returns>
        List<VisitWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitworkflowactivityhistory</summary>
        /// <param name="model">The visitworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitWorkflowActivityHistory model);

        /// <summary>Updates a specific visitworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowactivityhistory</param>
        /// <param name="updatedEntity">The visitworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitWorkflowActivityHistory updatedEntity);

        /// <summary>Updates a specific visitworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowactivityhistory</param>
        /// <param name="updatedEntity">The visitworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitWorkflowActivityHistory> updatedEntity);

        /// <summary>Deletes a specific visitworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitworkflowactivityhistoryService responsible for managing visitworkflowactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitworkflowactivityhistory information.
    /// </remarks>
    public class VisitWorkflowActivityHistoryService : IVisitWorkflowActivityHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitWorkflowActivityHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitWorkflowActivityHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowactivityhistory</param>
        /// <returns>The visitworkflowactivityhistory data</returns>
        public VisitWorkflowActivityHistory GetById(Guid id)
        {
            var entityData = _dbContext.VisitWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitworkflowactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitworkflowactivityhistorys</returns>/// <exception cref="Exception"></exception>
        public List<VisitWorkflowActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitWorkflowActivityHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitworkflowactivityhistory</summary>
        /// <param name="model">The visitworkflowactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitWorkflowActivityHistory model)
        {
            model.Id = CreateVisitWorkflowActivityHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowactivityhistory</param>
        /// <param name="updatedEntity">The visitworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitWorkflowActivityHistory updatedEntity)
        {
            UpdateVisitWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowactivityhistory</param>
        /// <param name="updatedEntity">The visitworkflowactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitWorkflowActivityHistory> updatedEntity)
        {
            PatchVisitWorkflowActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitworkflowactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowactivityhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitWorkflowActivityHistory(id);
            return true;
        }
        #region
        private List<VisitWorkflowActivityHistory> GetVisitWorkflowActivityHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitWorkflowActivityHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitWorkflowActivityHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitWorkflowActivityHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitWorkflowActivityHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitWorkflowActivityHistory(VisitWorkflowActivityHistory model)
        {
            _dbContext.VisitWorkflowActivityHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitWorkflowActivityHistory(Guid id, VisitWorkflowActivityHistory updatedEntity)
        {
            _dbContext.VisitWorkflowActivityHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitWorkflowActivityHistory(Guid id)
        {
            var entityData = _dbContext.VisitWorkflowActivityHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitWorkflowActivityHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitWorkflowActivityHistory(Guid id, JsonPatchDocument<VisitWorkflowActivityHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitWorkflowActivityHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitWorkflowActivityHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}