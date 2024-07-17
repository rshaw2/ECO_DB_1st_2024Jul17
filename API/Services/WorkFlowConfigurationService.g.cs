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
    /// The workflowconfigurationService responsible for managing workflowconfiguration related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting workflowconfiguration information.
    /// </remarks>
    public interface IWorkFlowConfigurationService
    {
        /// <summary>Retrieves a specific workflowconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfiguration</param>
        /// <returns>The workflowconfiguration data</returns>
        WorkFlowConfiguration GetById(Guid id);

        /// <summary>Retrieves a list of workflowconfigurations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of workflowconfigurations</returns>
        List<WorkFlowConfiguration> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new workflowconfiguration</summary>
        /// <param name="model">The workflowconfiguration data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(WorkFlowConfiguration model);

        /// <summary>Updates a specific workflowconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfiguration</param>
        /// <param name="updatedEntity">The workflowconfiguration data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, WorkFlowConfiguration updatedEntity);

        /// <summary>Updates a specific workflowconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfiguration</param>
        /// <param name="updatedEntity">The workflowconfiguration data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<WorkFlowConfiguration> updatedEntity);

        /// <summary>Deletes a specific workflowconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfiguration</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The workflowconfigurationService responsible for managing workflowconfiguration related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting workflowconfiguration information.
    /// </remarks>
    public class WorkFlowConfigurationService : IWorkFlowConfigurationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the WorkFlowConfiguration class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public WorkFlowConfigurationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific workflowconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfiguration</param>
        /// <returns>The workflowconfiguration data</returns>
        public WorkFlowConfiguration GetById(Guid id)
        {
            var entityData = _dbContext.WorkFlowConfiguration.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of workflowconfigurations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of workflowconfigurations</returns>/// <exception cref="Exception"></exception>
        public List<WorkFlowConfiguration> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetWorkFlowConfiguration(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new workflowconfiguration</summary>
        /// <param name="model">The workflowconfiguration data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(WorkFlowConfiguration model)
        {
            model.Id = CreateWorkFlowConfiguration(model);
            return model.Id;
        }

        /// <summary>Updates a specific workflowconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfiguration</param>
        /// <param name="updatedEntity">The workflowconfiguration data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, WorkFlowConfiguration updatedEntity)
        {
            UpdateWorkFlowConfiguration(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific workflowconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfiguration</param>
        /// <param name="updatedEntity">The workflowconfiguration data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<WorkFlowConfiguration> updatedEntity)
        {
            PatchWorkFlowConfiguration(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific workflowconfiguration by its primary key</summary>
        /// <param name="id">The primary key of the workflowconfiguration</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteWorkFlowConfiguration(id);
            return true;
        }
        #region
        private List<WorkFlowConfiguration> GetWorkFlowConfiguration(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.WorkFlowConfiguration.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<WorkFlowConfiguration>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(WorkFlowConfiguration), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<WorkFlowConfiguration, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateWorkFlowConfiguration(WorkFlowConfiguration model)
        {
            _dbContext.WorkFlowConfiguration.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateWorkFlowConfiguration(Guid id, WorkFlowConfiguration updatedEntity)
        {
            _dbContext.WorkFlowConfiguration.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteWorkFlowConfiguration(Guid id)
        {
            var entityData = _dbContext.WorkFlowConfiguration.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.WorkFlowConfiguration.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchWorkFlowConfiguration(Guid id, JsonPatchDocument<WorkFlowConfiguration> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.WorkFlowConfiguration.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.WorkFlowConfiguration.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}