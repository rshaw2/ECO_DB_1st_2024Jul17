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
    /// The jobitemService responsible for managing jobitem related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting jobitem information.
    /// </remarks>
    public interface IJobItemService
    {
        /// <summary>Retrieves a specific jobitem by its primary key</summary>
        /// <param name="id">The primary key of the jobitem</param>
        /// <returns>The jobitem data</returns>
        JobItem GetById(Guid id);

        /// <summary>Retrieves a list of jobitems based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of jobitems</returns>
        List<JobItem> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new jobitem</summary>
        /// <param name="model">The jobitem data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(JobItem model);

        /// <summary>Updates a specific jobitem by its primary key</summary>
        /// <param name="id">The primary key of the jobitem</param>
        /// <param name="updatedEntity">The jobitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, JobItem updatedEntity);

        /// <summary>Updates a specific jobitem by its primary key</summary>
        /// <param name="id">The primary key of the jobitem</param>
        /// <param name="updatedEntity">The jobitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<JobItem> updatedEntity);

        /// <summary>Deletes a specific jobitem by its primary key</summary>
        /// <param name="id">The primary key of the jobitem</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The jobitemService responsible for managing jobitem related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting jobitem information.
    /// </remarks>
    public class JobItemService : IJobItemService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the JobItem class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public JobItemService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific jobitem by its primary key</summary>
        /// <param name="id">The primary key of the jobitem</param>
        /// <returns>The jobitem data</returns>
        public JobItem GetById(Guid id)
        {
            var entityData = _dbContext.JobItem.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of jobitems based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of jobitems</returns>/// <exception cref="Exception"></exception>
        public List<JobItem> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetJobItem(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new jobitem</summary>
        /// <param name="model">The jobitem data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(JobItem model)
        {
            model.Id = CreateJobItem(model);
            return model.Id;
        }

        /// <summary>Updates a specific jobitem by its primary key</summary>
        /// <param name="id">The primary key of the jobitem</param>
        /// <param name="updatedEntity">The jobitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, JobItem updatedEntity)
        {
            UpdateJobItem(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific jobitem by its primary key</summary>
        /// <param name="id">The primary key of the jobitem</param>
        /// <param name="updatedEntity">The jobitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<JobItem> updatedEntity)
        {
            PatchJobItem(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific jobitem by its primary key</summary>
        /// <param name="id">The primary key of the jobitem</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteJobItem(id);
            return true;
        }
        #region
        private List<JobItem> GetJobItem(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.JobItem.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<JobItem>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(JobItem), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<JobItem, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateJobItem(JobItem model)
        {
            _dbContext.JobItem.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateJobItem(Guid id, JobItem updatedEntity)
        {
            _dbContext.JobItem.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteJobItem(Guid id)
        {
            var entityData = _dbContext.JobItem.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.JobItem.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchJobItem(Guid id, JsonPatchDocument<JobItem> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.JobItem.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.JobItem.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}