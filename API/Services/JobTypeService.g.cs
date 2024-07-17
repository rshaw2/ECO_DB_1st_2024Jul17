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
    /// The jobtypeService responsible for managing jobtype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting jobtype information.
    /// </remarks>
    public interface IJobTypeService
    {
        /// <summary>Retrieves a specific jobtype by its primary key</summary>
        /// <param name="id">The primary key of the jobtype</param>
        /// <returns>The jobtype data</returns>
        JobType GetById(Guid id);

        /// <summary>Retrieves a list of jobtypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of jobtypes</returns>
        List<JobType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new jobtype</summary>
        /// <param name="model">The jobtype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(JobType model);

        /// <summary>Updates a specific jobtype by its primary key</summary>
        /// <param name="id">The primary key of the jobtype</param>
        /// <param name="updatedEntity">The jobtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, JobType updatedEntity);

        /// <summary>Updates a specific jobtype by its primary key</summary>
        /// <param name="id">The primary key of the jobtype</param>
        /// <param name="updatedEntity">The jobtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<JobType> updatedEntity);

        /// <summary>Deletes a specific jobtype by its primary key</summary>
        /// <param name="id">The primary key of the jobtype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The jobtypeService responsible for managing jobtype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting jobtype information.
    /// </remarks>
    public class JobTypeService : IJobTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the JobType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public JobTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific jobtype by its primary key</summary>
        /// <param name="id">The primary key of the jobtype</param>
        /// <returns>The jobtype data</returns>
        public JobType GetById(Guid id)
        {
            var entityData = _dbContext.JobType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of jobtypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of jobtypes</returns>/// <exception cref="Exception"></exception>
        public List<JobType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetJobType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new jobtype</summary>
        /// <param name="model">The jobtype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(JobType model)
        {
            model.Id = CreateJobType(model);
            return model.Id;
        }

        /// <summary>Updates a specific jobtype by its primary key</summary>
        /// <param name="id">The primary key of the jobtype</param>
        /// <param name="updatedEntity">The jobtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, JobType updatedEntity)
        {
            UpdateJobType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific jobtype by its primary key</summary>
        /// <param name="id">The primary key of the jobtype</param>
        /// <param name="updatedEntity">The jobtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<JobType> updatedEntity)
        {
            PatchJobType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific jobtype by its primary key</summary>
        /// <param name="id">The primary key of the jobtype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteJobType(id);
            return true;
        }
        #region
        private List<JobType> GetJobType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.JobType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<JobType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(JobType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<JobType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateJobType(JobType model)
        {
            _dbContext.JobType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateJobType(Guid id, JobType updatedEntity)
        {
            _dbContext.JobType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteJobType(Guid id)
        {
            var entityData = _dbContext.JobType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.JobType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchJobType(Guid id, JsonPatchDocument<JobType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.JobType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.JobType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}