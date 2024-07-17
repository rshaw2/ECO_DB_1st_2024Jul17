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
    /// The visittaskService responsible for managing visittask related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visittask information.
    /// </remarks>
    public interface IVisitTaskService
    {
        /// <summary>Retrieves a specific visittask by its primary key</summary>
        /// <param name="id">The primary key of the visittask</param>
        /// <returns>The visittask data</returns>
        VisitTask GetById(Guid id);

        /// <summary>Retrieves a list of visittasks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visittasks</returns>
        List<VisitTask> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visittask</summary>
        /// <param name="model">The visittask data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitTask model);

        /// <summary>Updates a specific visittask by its primary key</summary>
        /// <param name="id">The primary key of the visittask</param>
        /// <param name="updatedEntity">The visittask data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitTask updatedEntity);

        /// <summary>Updates a specific visittask by its primary key</summary>
        /// <param name="id">The primary key of the visittask</param>
        /// <param name="updatedEntity">The visittask data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitTask> updatedEntity);

        /// <summary>Deletes a specific visittask by its primary key</summary>
        /// <param name="id">The primary key of the visittask</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visittaskService responsible for managing visittask related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visittask information.
    /// </remarks>
    public class VisitTaskService : IVisitTaskService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitTask class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitTaskService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visittask by its primary key</summary>
        /// <param name="id">The primary key of the visittask</param>
        /// <returns>The visittask data</returns>
        public VisitTask GetById(Guid id)
        {
            var entityData = _dbContext.VisitTask.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visittasks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visittasks</returns>/// <exception cref="Exception"></exception>
        public List<VisitTask> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitTask(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visittask</summary>
        /// <param name="model">The visittask data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitTask model)
        {
            model.Id = CreateVisitTask(model);
            return model.Id;
        }

        /// <summary>Updates a specific visittask by its primary key</summary>
        /// <param name="id">The primary key of the visittask</param>
        /// <param name="updatedEntity">The visittask data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitTask updatedEntity)
        {
            UpdateVisitTask(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visittask by its primary key</summary>
        /// <param name="id">The primary key of the visittask</param>
        /// <param name="updatedEntity">The visittask data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitTask> updatedEntity)
        {
            PatchVisitTask(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visittask by its primary key</summary>
        /// <param name="id">The primary key of the visittask</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitTask(id);
            return true;
        }
        #region
        private List<VisitTask> GetVisitTask(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitTask.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitTask>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitTask), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitTask, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitTask(VisitTask model)
        {
            _dbContext.VisitTask.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitTask(Guid id, VisitTask updatedEntity)
        {
            _dbContext.VisitTask.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitTask(Guid id)
        {
            var entityData = _dbContext.VisitTask.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitTask.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitTask(Guid id, JsonPatchDocument<VisitTask> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitTask.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitTask.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}