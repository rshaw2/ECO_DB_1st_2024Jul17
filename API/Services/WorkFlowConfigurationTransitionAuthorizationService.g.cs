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
    /// The workflowconfigurationtransitionauthorizationService responsible for managing workflowconfigurationtransitionauthorization related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting workflowconfigurationtransitionauthorization information.
    /// </remarks>
    public interface IWorkFlowConfigurationTransitionAuthorizationService
    {
        /// <summary>Retrieves a specific workflowconfigurationtransitionauthorization by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfigurationtransitionauthorization</param>
        /// <returns>The workflowconfigurationtransitionauthorization data</returns>
        WorkFlowConfigurationTransitionAuthorization GetById(Guid id);

        /// <summary>Retrieves a list of workflowconfigurationtransitionauthorizations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of workflowconfigurationtransitionauthorizations</returns>
        List<WorkFlowConfigurationTransitionAuthorization> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new workflowconfigurationtransitionauthorization</summary>
        /// <param name="model">The workflowconfigurationtransitionauthorization data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(WorkFlowConfigurationTransitionAuthorization model);

        /// <summary>Updates a specific workflowconfigurationtransitionauthorization by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfigurationtransitionauthorization</param>
        /// <param name="updatedEntity">The workflowconfigurationtransitionauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, WorkFlowConfigurationTransitionAuthorization updatedEntity);

        /// <summary>Updates a specific workflowconfigurationtransitionauthorization by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfigurationtransitionauthorization</param>
        /// <param name="updatedEntity">The workflowconfigurationtransitionauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<WorkFlowConfigurationTransitionAuthorization> updatedEntity);

        /// <summary>Deletes a specific workflowconfigurationtransitionauthorization by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfigurationtransitionauthorization</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The workflowconfigurationtransitionauthorizationService responsible for managing workflowconfigurationtransitionauthorization related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting workflowconfigurationtransitionauthorization information.
    /// </remarks>
    public class WorkFlowConfigurationTransitionAuthorizationService : IWorkFlowConfigurationTransitionAuthorizationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the WorkFlowConfigurationTransitionAuthorization class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public WorkFlowConfigurationTransitionAuthorizationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific workflowconfigurationtransitionauthorization by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfigurationtransitionauthorization</param>
        /// <returns>The workflowconfigurationtransitionauthorization data</returns>
        public WorkFlowConfigurationTransitionAuthorization GetById(Guid id)
        {
            var entityData = _dbContext.WorkFlowConfigurationTransitionAuthorization.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of workflowconfigurationtransitionauthorizations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of workflowconfigurationtransitionauthorizations</returns>/// <exception cref="Exception"></exception>
        public List<WorkFlowConfigurationTransitionAuthorization> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetWorkFlowConfigurationTransitionAuthorization(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new workflowconfigurationtransitionauthorization</summary>
        /// <param name="model">The workflowconfigurationtransitionauthorization data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(WorkFlowConfigurationTransitionAuthorization model)
        {
            model.Id = CreateWorkFlowConfigurationTransitionAuthorization(model);
            return model.Id;
        }

        /// <summary>Updates a specific workflowconfigurationtransitionauthorization by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfigurationtransitionauthorization</param>
        /// <param name="updatedEntity">The workflowconfigurationtransitionauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, WorkFlowConfigurationTransitionAuthorization updatedEntity)
        {
            UpdateWorkFlowConfigurationTransitionAuthorization(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific workflowconfigurationtransitionauthorization by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfigurationtransitionauthorization</param>
        /// <param name="updatedEntity">The workflowconfigurationtransitionauthorization data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<WorkFlowConfigurationTransitionAuthorization> updatedEntity)
        {
            PatchWorkFlowConfigurationTransitionAuthorization(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific workflowconfigurationtransitionauthorization by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfigurationtransitionauthorization</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteWorkFlowConfigurationTransitionAuthorization(id);
            return true;
        }
        #region
        private List<WorkFlowConfigurationTransitionAuthorization> GetWorkFlowConfigurationTransitionAuthorization(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.WorkFlowConfigurationTransitionAuthorization.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<WorkFlowConfigurationTransitionAuthorization>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(WorkFlowConfigurationTransitionAuthorization), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<WorkFlowConfigurationTransitionAuthorization, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateWorkFlowConfigurationTransitionAuthorization(WorkFlowConfigurationTransitionAuthorization model)
        {
            _dbContext.WorkFlowConfigurationTransitionAuthorization.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateWorkFlowConfigurationTransitionAuthorization(Guid id, WorkFlowConfigurationTransitionAuthorization updatedEntity)
        {
            _dbContext.WorkFlowConfigurationTransitionAuthorization.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteWorkFlowConfigurationTransitionAuthorization(Guid id)
        {
            var entityData = _dbContext.WorkFlowConfigurationTransitionAuthorization.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.WorkFlowConfigurationTransitionAuthorization.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchWorkFlowConfigurationTransitionAuthorization(Guid id, JsonPatchDocument<WorkFlowConfigurationTransitionAuthorization> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.WorkFlowConfigurationTransitionAuthorization.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.WorkFlowConfigurationTransitionAuthorization.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}