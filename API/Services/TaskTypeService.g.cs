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
    /// The tasktypeService responsible for managing tasktype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tasktype information.
    /// </remarks>
    public interface ITaskTypeService
    {
        /// <summary>Retrieves a specific tasktype by its primary key</summary>
        /// <param name="id">The primary key of the tasktype</param>
        /// <returns>The tasktype data</returns>
        TaskType GetById(Guid id);

        /// <summary>Retrieves a list of tasktypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tasktypes</returns>
        List<TaskType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tasktype</summary>
        /// <param name="model">The tasktype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TaskType model);

        /// <summary>Updates a specific tasktype by its primary key</summary>
        /// <param name="id">The primary key of the tasktype</param>
        /// <param name="updatedEntity">The tasktype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TaskType updatedEntity);

        /// <summary>Updates a specific tasktype by its primary key</summary>
        /// <param name="id">The primary key of the tasktype</param>
        /// <param name="updatedEntity">The tasktype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TaskType> updatedEntity);

        /// <summary>Deletes a specific tasktype by its primary key</summary>
        /// <param name="id">The primary key of the tasktype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tasktypeService responsible for managing tasktype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tasktype information.
    /// </remarks>
    public class TaskTypeService : ITaskTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TaskType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TaskTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tasktype by its primary key</summary>
        /// <param name="id">The primary key of the tasktype</param>
        /// <returns>The tasktype data</returns>
        public TaskType GetById(Guid id)
        {
            var entityData = _dbContext.TaskType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tasktypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tasktypes</returns>/// <exception cref="Exception"></exception>
        public List<TaskType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTaskType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tasktype</summary>
        /// <param name="model">The tasktype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TaskType model)
        {
            model.Id = CreateTaskType(model);
            return model.Id;
        }

        /// <summary>Updates a specific tasktype by its primary key</summary>
        /// <param name="id">The primary key of the tasktype</param>
        /// <param name="updatedEntity">The tasktype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TaskType updatedEntity)
        {
            UpdateTaskType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tasktype by its primary key</summary>
        /// <param name="id">The primary key of the tasktype</param>
        /// <param name="updatedEntity">The tasktype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TaskType> updatedEntity)
        {
            PatchTaskType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tasktype by its primary key</summary>
        /// <param name="id">The primary key of the tasktype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTaskType(id);
            return true;
        }
        #region
        private List<TaskType> GetTaskType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TaskType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TaskType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TaskType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TaskType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTaskType(TaskType model)
        {
            _dbContext.TaskType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTaskType(Guid id, TaskType updatedEntity)
        {
            _dbContext.TaskType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTaskType(Guid id)
        {
            var entityData = _dbContext.TaskType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TaskType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTaskType(Guid id, JsonPatchDocument<TaskType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TaskType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TaskType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}