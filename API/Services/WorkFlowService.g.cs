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
    /// The workflowService responsible for managing workflow related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting workflow information.
    /// </remarks>
    public interface IWorkFlowService
    {
        /// <summary>Retrieves a specific workflow by its primary key</summary>
        /// <param name="id">The primary key of the workflow</param>
        /// <returns>The workflow data</returns>
        WorkFlow GetById(Guid id);

        /// <summary>Retrieves a list of workflows based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of workflows</returns>
        List<WorkFlow> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new workflow</summary>
        /// <param name="model">The workflow data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(WorkFlow model);

        /// <summary>Updates a specific workflow by its primary key</summary>
        /// <param name="id">The primary key of the workflow</param>
        /// <param name="updatedEntity">The workflow data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, WorkFlow updatedEntity);

        /// <summary>Updates a specific workflow by its primary key</summary>
        /// <param name="id">The primary key of the workflow</param>
        /// <param name="updatedEntity">The workflow data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<WorkFlow> updatedEntity);

        /// <summary>Deletes a specific workflow by its primary key</summary>
        /// <param name="id">The primary key of the workflow</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The workflowService responsible for managing workflow related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting workflow information.
    /// </remarks>
    public class WorkFlowService : IWorkFlowService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the WorkFlow class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public WorkFlowService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific workflow by its primary key</summary>
        /// <param name="id">The primary key of the workflow</param>
        /// <returns>The workflow data</returns>
        public WorkFlow GetById(Guid id)
        {
            var entityData = _dbContext.WorkFlow.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of workflows based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of workflows</returns>/// <exception cref="Exception"></exception>
        public List<WorkFlow> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetWorkFlow(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new workflow</summary>
        /// <param name="model">The workflow data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(WorkFlow model)
        {
            model.Id = CreateWorkFlow(model);
            return model.Id;
        }

        /// <summary>Updates a specific workflow by its primary key</summary>
        /// <param name="id">The primary key of the workflow</param>
        /// <param name="updatedEntity">The workflow data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, WorkFlow updatedEntity)
        {
            UpdateWorkFlow(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific workflow by its primary key</summary>
        /// <param name="id">The primary key of the workflow</param>
        /// <param name="updatedEntity">The workflow data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<WorkFlow> updatedEntity)
        {
            PatchWorkFlow(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific workflow by its primary key</summary>
        /// <param name="id">The primary key of the workflow</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteWorkFlow(id);
            return true;
        }
        #region
        private List<WorkFlow> GetWorkFlow(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.WorkFlow.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<WorkFlow>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(WorkFlow), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<WorkFlow, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateWorkFlow(WorkFlow model)
        {
            _dbContext.WorkFlow.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateWorkFlow(Guid id, WorkFlow updatedEntity)
        {
            _dbContext.WorkFlow.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteWorkFlow(Guid id)
        {
            var entityData = _dbContext.WorkFlow.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.WorkFlow.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchWorkFlow(Guid id, JsonPatchDocument<WorkFlow> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.WorkFlow.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.WorkFlow.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}